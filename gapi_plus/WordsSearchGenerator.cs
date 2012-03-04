using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Logger;
using Google.Apis.Plus.v1.Data;

namespace LoggenCSG {
	class WordsSearchGenerator : Generator {

		private static string curWord;

		public WordsSearchGenerator(string apiKey, IStater stater = null)
			: base(apiKey, stater) {
		}

		public WordsSearchGenerator(Google.Apis.Authentication.IAuthenticator auth, IStater stater = null)
			: base(auth, stater) {
		}

		static public void LogGen(Dictionary<Visualizers.Types, Appender> loggers,
			Visualizers.Types typelog,
			Dictionary<Rules, string> rules,
			KeyValuePair<Activity, ActivityCont> dicitem) {

			var item = dicitem.Key;
			var action = "A";

			var logEvent = Visualizers.TypeLogEvent[typelog]
				.GetConstructor(Type.EmptyTypes)
					.Invoke(Type.EmptyTypes) as LogEvent;

			var po = new PatternOption();

			po.Post = item;
			po.Type = TypePattern.post;
			po.Pattern = rules[Rules.NotShare];

			po.SharePath = ReplacePattern(po);

			po.Type = (TypePattern)Enum.Parse(typeof(TypePattern), item.Verb, true);
			po.Type = TypePattern.post;
			po.Pattern = rules[Rules.Post];

			var sharafile = po.PostFileName;

			po.PostFileName = ReplacePattern(po);
			logEvent.User = typelog == Visualizers.Types.Code_swarm ? curWord : GetActor(item.Actor, typelog);
			logEvent.Date = DateTime.Parse(item.Published);
			logEvent.Action = typelog == Visualizers.Types.Logstalgia ? "post" : action;
			logEvent.FileName = po.PostFileName;
			if (logEvent is LogstalgiaEvent)
				(logEvent as LogstalgiaEvent).Size = item.Object != null ? item.Object.Content.Length.ToString() : "100";
			if ((logEvent is GephiLogEvent)) {
				(logEvent as GephiLogEvent).From = curWord;
			}

			loggers[typelog].Append(logEvent);
		}

		protected override void doGenerate(GeneratorSetting setting, string word, int depth) {
			if (string.IsNullOrWhiteSpace(word) || setting == null)
				return;

			curWord = word;

			var acts = Service.Activities.Search(word);

			if (setting.UseDateRange)
				setting.MaxResults = 20;

			var step = setting.MaxResults / (double)20;
			string nextPage = string.Empty;

			if (users == null)
				users = new Dictionary<string, bool>();

			users[word] = true;

			while (step != 0) {

				var nextResults = 20;
				if (step-- < 1) {
					nextResults = (int)((step + 1) * 20);
					step = 0;
				}

				step = step == 0 && setting.UseDateRange ? 1 : step;

				acts.MaxResults = nextResults;
				acts.PageToken = nextPage;
				acts.OrderBy = Google.Apis.Plus.v1.ActivitiesResource.OrderBy.Recent;

				if (haveStater) {
					Stater.MaxPosition = nextResults;
					Stater.SetState("Load feeds ...");
				}

				Dictionary<Activity, ActivityCont> dicdate = null;

				try {
					var feed = acts.Fetch();

					if (dicdate == null)
						dicdate = new Dictionary<Activity, ActivityCont>();
					dicdate.Clear();

					nextPage = null;
					if (feed.Error == null) {
						nextPage = feed.NextPageToken;
						if (string.IsNullOrWhiteSpace(nextPage)) {
							step = 0;
							Stater.Position = Stater.MaxPosition;
						}

						if (haveStater) {
							Stater.MaxPosition = feed.Items.Count;
							Stater.SetState("Parsing ...");
						}

						foreach (var item in feed.Items) {

							if (setting.UseDateRange && !InRange(setting.DateFrom, setting.DateTo, item.Published)) {
								if (IsOutLeft(setting.DateFrom, item.Published)) {
									step = 0;
									break;
								}
								continue;
							}

							var ditem = dicdate[item] = new ActivityCont();

							if (haveStater)
								Stater.Inc();
						}

						GenerateLogs(dicdate, setting, loggers);
						
					}
					else {
						WriteLog(feed.Error.ToString(), this);
					}
				}
				catch (Exception e) {
					WriteLog(e, this);
					e.ShowError();
					step = 0;
				}
			}
		}
	}
}
