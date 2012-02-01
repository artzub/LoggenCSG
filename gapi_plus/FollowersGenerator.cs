using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Logger;
using Core;

namespace LoggenCSG {
	internal class FollowersGenerator : Generator {

		public FollowersGenerator(Google.Apis.Authentication.IAuthenticator auth, Core.IStater stater = null) 
			: base(auth, stater) {
		}

		public FollowersGenerator(string apiKey, Core.IStater stater = null) 
			: base(apiKey, stater) {

		}

		public enum Direction {
			visible,
			incoming
		}

		private Dictionary<string, bool> completeUser = new Dictionary<string, bool>();

		protected override object GenerateLog(Core.GeneratorSetting insetting = null) {

			try {

				var setting = insetting as GeneratorSetting;

				if (loggers == null)
					loggers = new Dictionary<Visualizers.Types, Appender>();
				foreach (var log in setting.LogFiles) {
					try {
						if (setting.VisLogs.HasFlag(log.Key) && (!loggers.ContainsKey(log.Key) || loggers[log.Key] == null))
							loggers[log.Key] = Visualizers.Loggers[log.Key]
								.GetConstructor(new Type[] { typeof(string) })
									.Invoke(new object[] { log.Value }) as Appender;
					}
					catch (Exception e) {
						WriteLog(e, this);
					}
				}

				var ids = setting.ProfileID.Split(new char[] { ';', ',' });

				foreach (var pid in ids) {
					try {
						if (!completeUser.Keys.Contains(pid))
							completeUser[pid] = true;
						else
							continue;

						using (var webc = new WebClient()) {

							webc.Encoding = Encoding.UTF8;
							var user = webc.DownloadString("https://www.googleapis.com/plus/v1/people/" + pid + "?pp=1&key=" + ClientCredentials.ApiKey);
							if (user.IsEmpty()) {
								throw new Exception("Error get information for " + pid);
							}

							user = Regex.Replace(user.Replace("\n", ""), ".*?\"displayName\": \"(.+?\").*", "$1").Replace("\"", "");

							webc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
							webc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Completed);

							//101113754039426612780

							if (!Directory.Exists("tempdata"))
								Directory.CreateDirectory("tempdata");

							DoGenerate(setting, pid, webc, user, setting.Deep);
						}
					}
					catch (Exception e) {
						WriteLog(e, this);
					}
				}

			}
			catch (Exception e) {
				e.ShowError();
			}

			return true;
		}

		private void DoGenerate(GeneratorSetting setting, string pid, WebClient webc, string user, int deep = 0) {
			var fileReq = new FileInfo(@"tempdata\" + pid);

			foreach (Direction dir in Enum.GetValues(typeof(Direction))) {

				try {

					if (fileReq.Exists)
						fileReq.Delete();

					if (haveStater) {
						Stater.MaxPosition = 2;
						Stater.SetState("Load data ...", 0);
					}

					var request = "https://plus.google.com/u/0/_/socialgraph/lookup/"+ dir.ToString() + "/?o=%5Bnull%2Cnull%2C%22" + pid + "%22%5D&rt=j&n=" + setting.MaxResults.ToString();

					busy = true;
					webc.DownloadFile(new Uri(request), fileReq.FullName);

					if (!errorLoad) {
						try {
							fileReq.Refresh();
							if (fileReq.Exists && fileReq.Length > 0) {

								var work = "";
								using (var rd = fileReq.OpenText()) {
									work = rd.ReadToEnd().Replace("\n", "");
								}
								fileReq.Delete();

								var users = new Dictionary<string, string>();

								Regex.Replace(work, @".*?\[\[,," + "\\\"" + @"(\d{21})" + "\\\"" + ".*?\\\"(.+?\\\").*?", 
									new MatchEvaluator(delegate(Match m) {
										if (m.Success)
											if (m.Groups.Count > 1)
												if (!users.ContainsKey(m.Groups[1].Value))
													users[m.Groups[1].Value] = m.Groups[2].Value.Replace("\"", "");
										return "";
									}));

								GenerateLogs(users, user, dir, setting, loggers);

								if (deep > 0) {
									var i = 0;
									foreach (var item in users) {
										if (!completeUser.Keys.Contains(item.Key) && i++ <= setting.MaxResults)
											completeUser[item.Key] = true;
										else
											continue;
										DoGenerate(setting, item.Key, webc, item.Value, deep - 1);
									}
								}
							}
						}
						catch (Exception e) {
							WriteLog(e, this);
						}
					}

				}
				catch (Exception e) {
					WriteLog(new Exception(dir == Direction.visible ? 
									"Perhaps the " + user + " hide users, that in him's circles." :
									"Perhaps the " + user + " has hidden users who have it in circles", e), this);
				}
			}
		}

		private bool busy;

		private bool errorLoad;

		private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
			if(haveStater) {
				Stater.MaxPosition += e.BytesReceived  > 0 ? e.BytesReceived : 2;
				Stater.Inc(e.BytesReceived);
			}				
		}

		private void Completed(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
			if(haveStater)
				Stater.MovePosition(Stater.MaxPosition);

			errorLoad = e.Cancelled || e.Error != null;
			busy = false;			
		}

		protected void GenerateLogs(Dictionary<string, string> data, string user, Direction dir, GeneratorSetting setting, Dictionary<Core.Visualizers.Types, Logger.Appender> loggers) {

			if (data == null || loggers == null)
				return;
			
			if (haveStater) {
				Stater.MaxPosition = setting.MaxResults < 100 ? setting.MaxResults : 100;
			}
			
			var curPos = 0;
			var arr = data.Values.ToArray();

			foreach (var key in loggers.Keys) {
				var logger = loggers[key];
				var logEvent = Core.Visualizers.TypeLogEvent[key]
				.GetConstructor(Type.EmptyTypes)
					.Invoke(Type.EmptyTypes) as LogEvent;
				logEvent.Date = DateTime.Now;
				logEvent.Action = "A";

				foreach (var item in arr) {
					if (haveStater && curPos++ % 100 == 0) {
						Stater.SetState("Generate...", 0);
					}

					switch (dir) {
						case Direction.visible:
							logEvent.User = user;
							logEvent.FileName = item;
							break;
						case Direction.incoming:
							logEvent.User = item;
							logEvent.FileName = user;
							break;
					}
					logger.Append(logEvent);
					if (haveStater)
						Stater.Inc();

					if (curPos >= setting.MaxResults)
						break;
				}
			}
		}

		/*private Dictionary<string, string> users = new Dictionary<string, string>();

		private string AddUsers(Match m) {
			if (m.Success)
				if (m.Groups.Count > 1)
					if (!users.ContainsKey(m.Groups[1].Value))
						users[m.Groups[1].Value] = m.Groups[2].Value.Replace("\"", "");
			return "";
		}*/
	}
}
