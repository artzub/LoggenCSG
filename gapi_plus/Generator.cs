using System;
using System.Linq;

using Google.Apis.Plus.v1;

using Core;
using Logger;
using System.Collections.Generic;
using Google.Apis.Plus.v1.Data;
using System.Text.RegularExpressions;

namespace gapi_plus {
	internal class Generator : Core.Generator, IDisposable {

		protected enum TypePattern {
			post,
			share,
			checkin,
			comment,
			plus,
			reshare
		}

		protected enum DateType {
			TimeSpan,
			Date,
			Time,
			DateTime
		}

		protected class PatternOption {
			public TypePattern Type {
				get;
				set;
			}

			public Activity Post {
				get;
				set;
			}

			public Activity Share {
				get;
				set;
			}

			public Comment Comment {
				get;
				set;
			}

			public Person Person {
				get;
				set;
			}

			public string SharePath {
				get;
				set;
			}

			public string PostFileName {
				get;
				set;
			}

			public string Pattern {
				get;
				set;
			}

			public Visualizers.Types VisType {
				get;
				set;
			}
		}

		protected class PatternItem {
			public string Type {
				get;
				set;
			}

			public string Id {
				get;
				set;
			}

			public string Actor {
				get;
				set;
			}

			public string ActorName {
				get;
				set;
			}

			public string TimeSpan {
				get;
				set;
			}

			public string Date {
				get;
				set;
			}

			public string Time {
				get;
				set;
			}

			public string DateTime {
				get;
				set;
			}

			public string Title {
				get;
				set;
			}

			public string SharePath {
				get;
				set;
			}

			public string PostFileName {
				get;
				set;
			}
		}

		private string ApiKey {
			get;
			set;
		}

		private PlusService service = null;
		protected PlusService Service {
			get {
				if (service == null)
					service = new PlusService();
				service.Key = ApiKey;
				return service;
			}			
		}

		protected IStater Stater {
			get;
			set;
		}

		protected bool haveStater;		

		public Generator(string apiKey, IStater stater = null) {
			ApiKey = apiKey;
			Stater = stater;
			haveStater = stater != null;
		}


		protected static string DateString(string date, DateType type) {
			var str = date;
			var parseDate = DateTime.MinValue;
			var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
			try {
				System.Threading.Thread.CurrentThread.CurrentCulture = 
					System.Globalization.CultureInfo.CreateSpecificCulture("ja-JP");
				if (DateTime.TryParse(date, out parseDate))
					switch (type) {
						case DateType.TimeSpan:
							str = (parseDate - DateTime.Parse("1970/1/1")).TotalMilliseconds.ToString();
							break;
						case DateType.Date:
							str = parseDate.ToShortDateString();
							break;
						case DateType.Time:
							str = parseDate.ToShortTimeString();
							break;
						case DateType.DateTime:
							str = parseDate.ToString();
							break;
					}
			}
			finally {
				System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
			}
			return str;
		}

		static protected string GetActor(Google.Apis.Plus.v1.Data.Activity.ActorData actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		static protected string GetActor(Google.Apis.Plus.v1.Data.Comment.ActorData actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		static protected string GetActor(Google.Apis.Plus.v1.Data.Activity.ObjectData.ActorData actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		static protected string GetActor(Google.Apis.Plus.v1.Data.Person actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
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

			var share = dicitem.Value.Share;
			if (share != null) {
				po.Post = item;
				po.Share = share;
				po.Pattern = rules[Rules.SharePath];
				po.Type = TypePattern.share;

				po.SharePath = ReplacePattern(po);
				
				po.Pattern = rules[Rules.ShareName];
				po.PostFileName = po.SharePath + ReplacePattern(po);
				po.PostFileName = po.PostFileName.Replace("//", "/");

				logEvent.User = GetActor(share.Actor, typelog);
				logEvent.Date = DateTime.Parse(share.Published);
				logEvent.Action = typelog == Visualizers.Types.Logstalgia ? "share" : action;
				logEvent.FileName = po.PostFileName;
				if (logEvent is LogstalgiaEvent)
					(logEvent as LogstalgiaEvent).Size = 
						!string.IsNullOrWhiteSpace(share.Title) ? 
							share.Title.Length.ToString() :
								string.IsNullOrWhiteSpace(item.Title) ? 
									item.Title.Length.ToString() : "200";
				loggers[typelog].Append(logEvent);

				action = "M";
			}
			else {
				po.Post = item;
				po.Type = TypePattern.post;
				po.Pattern = rules[Rules.NotShare];
				
				po.SharePath = ReplacePattern(po);
			}

			po.Type = (TypePattern)Enum.Parse(typeof(TypePattern), item.Verb, true);
			if (po.Type == TypePattern.share && share == null)
				po.Type = TypePattern.post;
			po.Pattern = rules[Rules.Post];

			var sharafile = po.PostFileName;

			po.PostFileName = ReplacePattern(po);			
			logEvent.User = GetActor(item.Actor, typelog);
			logEvent.Date = DateTime.Parse(item.Published);
			logEvent.Action = typelog == Visualizers.Types.Logstalgia ? "post" : action;
			logEvent.FileName = po.PostFileName;
			if (logEvent is LogstalgiaEvent)
				(logEvent as LogstalgiaEvent).Size = item.Object != null ? item.Object.Content.Length.ToString() : "100";
			if (share != null && (logEvent is GephiLogEvent)) {
				(logEvent as GephiLogEvent).From = sharafile;
			}

			loggers[typelog].Append(logEvent);

			if (item.Object != null) {

				if (item.Object.Replies.TotalItems > 0) {
					try {
						var listpl = dicitem.Value.Comments;

						po.Pattern = rules[Rules.Comment];
						po.Type = TypePattern.comment;

						foreach (var pl in listpl) {
							po.Comment = pl;
							po.Type = TypePattern.comment;
							var fnp = ReplacePattern(po);

							logEvent.User = GetActor(pl.Actor, typelog);
							logEvent.Date = DateTime.Parse(pl.Published);
							logEvent.Action = typelog == Visualizers.Types.Logstalgia ? "comment" : "A";
							logEvent.FileName = fnp;
							if (logEvent is LogstalgiaEvent)
								(logEvent as LogstalgiaEvent).Size = pl.Object != null ? pl.Object.Content.Length.ToString() : "1";
							if (logEvent is GephiLogEvent)
								(logEvent as GephiLogEvent).From = po.PostFileName;

							loggers[typelog].Append(logEvent);
						}
					}
					catch (Exception e) {
					}
				}

				long ticks = 0;

				if (item.Object.Plusoners.TotalItems > 0) {
					try {
						var listpl = dicitem.Value.Plusers;

						po.Pattern = rules[Rules.Plus];						

						foreach (var pl in listpl) {
							po.Person = pl;
							po.Type = TypePattern.plus;
							var fnp = ReplacePattern(po);

							logEvent.User = GetActor(pl, typelog);
							logEvent.Date = DateTime.Parse(item.Published).AddMinutes(ticks);
							logEvent.Action = typelog == Visualizers.Types.Logstalgia ? "plus" : "A";
							logEvent.FileName = fnp;
							if (logEvent is LogstalgiaEvent)
								(logEvent as LogstalgiaEvent).Size = "5";
							if (logEvent is GephiLogEvent)
								(logEvent as GephiLogEvent).From = po.PostFileName;

							loggers[typelog].Append(logEvent);

							ticks += 5;
						}
					}
					catch (Exception e) {
					}
				}

				ticks = 0;

				if (item.Object.Resharers.TotalItems > 0) {
					try {
						var listpl = dicitem.Value.Sharers;

						po.Pattern = rules[Rules.Plus];

						foreach (var pl in listpl) {
							po.Person = pl;
							po.Type = TypePattern.reshare;
							var fnp = ReplacePattern(po);

							logEvent.User = GetActor(pl, typelog);
							logEvent.Date = DateTime.Parse(item.Published).AddMinutes(ticks);
							logEvent.Action = typelog == Visualizers.Types.Logstalgia ? "reshare" : "A";
							logEvent.FileName = fnp;
							if (logEvent is LogstalgiaEvent)
								(logEvent as LogstalgiaEvent).Size = "5";
							if (logEvent is GephiLogEvent)
								(logEvent as GephiLogEvent).From = po.PostFileName;

							loggers[typelog].Append(logEvent);

							ticks += 5;
						}
					}
					catch (Exception e) {
					}
				}
			}
		}

		protected static string ApplyPattern(string pattern, PatternItem item, string prefix = "", string[] prefixignore = null) {
			var result = pattern;

			if (string.IsNullOrWhiteSpace(result))
				return string.Empty;

			var arr = item.GetType().GetProperties().ToArray();

			foreach (var prop in arr) {
				result = Regex.Replace(result,
					MakeRule(prop.Name, prefix, prefixignore), 
					string.Format("{0}", prop.GetValue(item, null)), 
					RegexOptions.IgnoreCase | RegexOptions.Multiline);
			}

			return result;
		}

		private static string MakeRule(string name, string prefix = "", string[] prefixignore = null) {
			return "{" + (
						prefixignore == null || 
						prefixignore.Count(x => 
							Regex.Match(x, name, RegexOptions.IgnoreCase).Success) == 0 ? 
							prefix : string.Empty
					) + name + "}";
		}

		protected static string GetTypePatternName(TypePattern type) {
			return Enum.GetName(typeof(TypePattern), type);
		}

		protected static string ForTitle(string input, int length = 20) {
			return string.IsNullOrEmpty(input) ? input : 
				input.Substring(0, input.Length > length ? length : input.Length);
		}

		protected static string ReplacePattern(PatternOption option) {
			if (option == null)
				return string.Empty;

			var result = option.Pattern;
			var prefix = string.Empty;
			var completed = false;

			PatternItem item = null;

			do {
				switch (option.Type) {
					case TypePattern.share:
					case TypePattern.checkin:
					case TypePattern.post:
						var post = option.Type == TypePattern.share ? option.Share : option.Post;
						
						item = null;
						if (post != null)
							item = new PatternItem() {
								Type = string.IsNullOrWhiteSpace(prefix) ? GetTypePatternName(option.Type) : "{type}",
								Id = post.Id,
								TimeSpan = DateString(post.Published, DateType.TimeSpan),
								Date = DateString(post.Published, DateType.Date),
								Time = DateString(post.Published, DateType.Time),
								DateTime = DateString(post.Published, DateType.DateTime),
								ActorName = post.Actor.DisplayName,
								Actor = post.Actor.Id,
								SharePath = !string.IsNullOrWhiteSpace(option.SharePath) ? option.SharePath : "{sharepath}",
								PostFileName = !string.IsNullOrWhiteSpace(option.PostFileName) ? option.PostFileName : "{postfilename}",
								Title = !string.IsNullOrWhiteSpace(post.Title) ? ForTitle(post.Title, 100) :
									(string.IsNullOrWhiteSpace(post.Object.Content) ? post.Id : 
										ForTitle(Regex.Replace(post.Object.Content, "<.*?>", "", RegexOptions.IgnoreCase | RegexOptions.Multiline), 100))
									 
							};

						if (!(completed = option.Type != TypePattern.share)) {							
							option.Type = TypePattern.post;
						}
						break;
					case TypePattern.comment:
						var comment = option.Comment;

						item = null;
						if (comment != null)
							item = new PatternItem() {
								Type = string.IsNullOrWhiteSpace(prefix) ? GetTypePatternName(option.Type) : "{type}",
								Id = comment.Id,
								TimeSpan = DateString(comment.Published, DateType.TimeSpan),
								Date = DateString(comment.Published, DateType.Date),
								Time = DateString(comment.Published, DateType.Time),
								DateTime = DateString(comment.Published, DateType.DateTime),
								ActorName = comment.Actor.DisplayName,
								Actor = comment.Actor.Id,
								SharePath = !string.IsNullOrWhiteSpace(option.SharePath) ? option.SharePath : "{sharepath}",
								PostFileName = !string.IsNullOrWhiteSpace(option.PostFileName) ? option.PostFileName : "{postfilename}",
								Title = comment.Object == null || string.IsNullOrWhiteSpace(comment.Object.Content) ? 
								comment.Id : ForTitle(Regex.Replace(comment.Object.Content, "<.*?>", "", RegexOptions.IgnoreCase | RegexOptions.Multiline), 100)
							};
						option.Type = TypePattern.post;
						break;
					case TypePattern.plus:
					case TypePattern.reshare:
						var person = option.Person;

						item = null;
						if (person != null) {
							item = new PatternItem() {
								Type = string.IsNullOrWhiteSpace(prefix) ? GetTypePatternName(option.Type) : "{type}",
								Id = person.Id,
								TimeSpan = DateString(DateTime.Now.ToString(), DateType.TimeSpan),
								Date = DateString(DateTime.Now.ToString(), DateType.Date),
								Time = DateString(DateTime.Now.ToString(), DateType.Time),
								DateTime = DateString(DateTime.Now.ToString(), DateType.DateTime),
								ActorName = person.DisplayName,
								Actor = person.Id,
								SharePath = !string.IsNullOrWhiteSpace(option.SharePath) ? option.SharePath : "{sharepath}",
								PostFileName = !string.IsNullOrWhiteSpace(option.PostFileName) ? option.PostFileName : "{postfilename}",
								Title = "{posttitle}"
							};
							post = option.Post;

							if (post != null) {
								item.TimeSpan = DateString(post.Published, DateType.TimeSpan);
								item.Date = DateString(post.Published, DateType.Date);
								item.Time = DateString(post.Published, DateType.Time);
								item.DateTime = DateString(post.Published, DateType.DateTime);
							}
						}
						option.Type = TypePattern.post;						
						break;
				}

				if (item != null && !string.IsNullOrWhiteSpace(result))
					result = ApplyPattern(result, item, prefix, new string[] { "type", "sharepath", "postfilename" });

				if (!completed)
					prefix = "post";
				else
					break;
			} while (!completed);

			if (result == "{type}:{title}")
				result = "вот же хер";

			return ReplaceForLog(result.Replace("//", "/"));
		}

		private static string ReplaceForLog(string p) {
			return p.Replace("\n", "")
					.Replace("\r", "")
					.Replace("!", "")
					.Replace("©", "")
					.Replace("►", "");
		}

		protected virtual void GenerateLogs(Dictionary<Activity, ActivityCont> data, 
			GeneratorSetting setting, Dictionary<Visualizers.Types, Appender> loggers) {
			if (haveStater)
				Stater.StateLabel = "Generation ...";

			if (haveStater) {
				Stater.MaxPosition = data.Count * loggers.Count;				
				Stater.SetState("Generate logs ...", 0);
			}

			foreach (var log in loggers.Keys) {
				var rules = setting.Rules[log];

				foreach (var dicitem in data) {

					setting.Methods[log](loggers, log, rules, dicitem);

					//LogGen(loggers, log.Key, rules, dicitem);

					if (haveStater)
						Stater.Inc();
				}
			}
		}

		protected Dictionary<Visualizers.Types, Appender> loggers = null;

		protected override object GenerateLog(Core.GeneratorSetting insetting = null) {

			var setting = insetting as GeneratorSetting;

			var acts = Service.Activities.List(setting.ProfileID, setting.Collection);

			var step = setting.MaxResults / (double)100;
			string nextPage = string.Empty;

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
					throw;
				}
			}
			
			while(step != 0) {

				var nextResults = 100;
				if(step-- < 1) {
					nextResults = (int)((step + 1) * 100);
					step = 0;
				}

				acts.MaxResults = nextResults;
				acts.PageToken = nextPage;

				if (haveStater) {
					Stater.MaxPosition = nextResults;					
					Stater.SetState("Load feeds ...");
				}

				Dictionary<Activity, ActivityCont> dicdate = null;				

				try {
					var feed = acts.Fetch();

					nextPage = feed.NextPageToken;
					if (string.IsNullOrWhiteSpace(nextPage)) {
						step = 0;
						Stater.Position = Stater.MaxPosition;
					}

					if (haveStater) {
						Stater.MaxPosition = feed.Items.Count;
						Stater.SetState("Parsing ...");
					}

					if (dicdate == null)
						dicdate = new Dictionary<Activity, ActivityCont>();
					dicdate.Clear();

					if (feed.Items.Count > 0) {						
						foreach (var item in feed.Items) {
								
							var ditem = dicdate[item] = new ActivityCont();

							if (item.Object != null) {

								if (item.Verb == "share" && 
									!string.IsNullOrWhiteSpace(item.Object.Id)) {
									try {
										ditem.Share = Service.Activities.Get(item.Object.Id).Fetch();
									}
									catch(Exception e) {
									}
								}

								if (item.Object.Replies.TotalItems > 0) {
									var plser = Service.Comments.List(item.Id);
									plser.MaxResults = setting.MaxComments;
									try {
										var listpl = plser.Fetch();

										ditem.Comments = listpl.Items;
									}
									catch (Exception e) {											
									}										
								}

								if (item.Object.Plusoners.TotalItems > 0) {
									var plser = Service.People.ListByActivity(item.Id, PeopleResource.Collection.Plusoners);
									plser.MaxResults = setting.MaxPluses;

									try {
										var listpl = plser.Fetch();

										ditem.Plusers = listpl.Items;
									}
									catch (Exception e) {											
									}
								}

								if (item.Object.Resharers.TotalItems > 0) {
									var plser = Service.People.ListByActivity(item.Id, PeopleResource.Collection.Resharers);
									plser.MaxResults = setting.MaxReshares;

									try {
										var listpl = plser.Fetch();

										ditem.Sharers = listpl.Items;
									}
									catch (Exception e) {											
									}										
								}
							}

							if (haveStater)
								Stater.Inc();
						}

						GenerateLogs(dicdate, setting, loggers);
					}
				}
				catch (Exception e) {
					e.ShowError();
					step = 0;
				}
			}
			return true;
		}

		public void Dispose() {
			if (loggers != null)
				foreach (var log in loggers.Keys) 
					loggers[log].Dispose();
			loggers = null;
		}
	}

	internal sealed class ActivityCont {
		public IList<Person> Plusers {
			get;
			set;
		}
		public IList<Person> Sharers {
			get;
			set;
		}
		public IList<Comment> Comments {
			get;
			set;
		}

		public Activity Share {
			get;
			set;
		}
	}

	delegate void GeneratorLogsMeth(Dictionary<Visualizers.Types, Appender> loggers, Visualizers.Types typelog, Dictionary<Rules, string> rules, KeyValuePair<Activity, ActivityCont> dicitem);
}
