using System;

using Google.Apis.Plus.v1;

using Core;
using Logger;
using System.Collections.Generic;
using Google.Apis.Plus.v1.Data;

namespace gapi_plus {
	internal class Generator : Core.Generator {

		private string ApiKey {
			get;
			set;
		}

		private PlusService service = null;
		private PlusService Service {
			get {
				if (service == null)
					service = new PlusService();
				service.Key = ApiKey;
				return service;
			}			
		}

		private IStater Stater {
			get;
			set;
		}

		private bool haveStater;

		public Generator(string apiKey, IStater stater = null) {
			ApiKey = apiKey;
			Stater = stater;
			haveStater = stater != null;
		}

		public static string DateString(string date, Visualizers.Types logType) {
			var str = (DateTime.Parse(date) - DateTime.MinValue).TotalMilliseconds.ToString();
			return str;
		}

		private string GetActor(Google.Apis.Plus.v1.Data.Activity.ActorData actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		private string GetActor(Google.Apis.Plus.v1.Data.Comment.ActorData actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		private string GetActor(Google.Apis.Plus.v1.Data.Activity.ObjectData.ActorData actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		private string GetActor(Google.Apis.Plus.v1.Data.Person actor, Visualizers.Types logType) {
			return logType == Visualizers.Types.Code_swarm ? actor.Id : actor.DisplayName;
		}

		private sealed class ActivityCont {
			public IList<Person> Plusers {get; set;}
			public IList<Person> Sharers {get; set;}
			public IList<Comment> Comments {get; set;}
		}

		private void GenerateLogs(Dictionary<Activity, ActivityCont> data, GeneratorSetting setting, Dictionary<Visualizers.Types, Appender> loggers) {
			if (haveStater)
				Stater.StateLabel = "Generation ...";

			if (haveStater) {
				Stater.MaxPosition = data.Count * loggers.Count;				
				Stater.SetState("Generate logs ...", 0);
			}

			foreach (var log in setting.LogFiles) {
				var rules = setting.Rules[log.Key];

				foreach (var dicitem in data) {
					var item = dicitem.Key;
					
					var dic = new Dictionary<string, string>(){
									{"sharepath", ""},
									{"postfilename", ""}
								};

					var action = "A";

					if (item.Verb == "share" && 
						item.Object != null && 
						item.Object.Actor != null) {

						dic["sharepath"] = rules[Rules.SharePath];
						dic["sharepath"] = dic["sharepath"]
							.Replace("type", item.Verb)
							.Replace("id", item.Object.Id)
							.Replace("actor", item.Object.Actor.Id)
							.Replace("postId", item.Id)
							.Replace("date", DateString(item.Published, log.Key))
							.Replace("//", "/")
							;

						dic["postfilename"] = rules[Rules.ShareName];
						dic["postfilename"] = dic["sharepath"] + dic["postfilename"]
							.Replace("type", item.Verb)
							.Replace("id", item.Object.Id)
							.Replace("actor", item.Object.Actor.Id)
							.Replace("postId", item.Id)
							.Replace("date", DateString(item.Published, log.Key))
							.Replace("//", "/")
							;

						loggers[log.Key].Append(new LogEvent() {
							User = GetActor(item.Object.Actor, log.Key),
							Date = DateTime.Parse(item.Published),
							Action = action,
							FileName = dic["postfilename"]
						});

						action = "M";
					}
					else {
						dic["sharepath"] = rules[Rules.NotShare];
						dic["sharepath"] = dic["sharepath"]
							.Replace("type", item.Verb)
							.Replace("id", item.Id)
							.Replace("actor", item.Actor.Id)
							.Replace("date", DateString(item.Published, log.Key))
							.Replace("//", "/")
							;
					}

					dic["postfilename"] = rules[Rules.Post];
					dic["postfilename"] = dic["postfilename"]
						.Replace("type", item.Verb)
						.Replace("id", item.Id)
						.Replace("actor", item.Actor.Id)
						.Replace("date", DateString(item.Published, log.Key))
						.Replace("sharepath", dic["sharepath"])
						.Replace("//", "/")
						;


					loggers[log.Key].Append(new LogEvent() {
						User = GetActor(item.Actor, log.Key),
						Date = DateTime.Parse(item.Published),
						Action = action,
						FileName = dic["postfilename"]
					});

					if (item.Object != null) {

						if (item.Object.Resharers.TotalItems > 0) {
							try {
								var listpl = dicitem.Value.Comments;
								foreach (var pl in listpl) {
									var fnp = rules[Rules.Comment];
									fnp = fnp
										.Replace("type", "comment")
										.Replace("id", pl.Id)
										.Replace("actor", pl.Actor.Id)
										.Replace("date", DateString(pl.Published, log.Key))
										.Replace("postid", item.Id)
										.Replace("postactor", item.Actor.Id)
										.Replace("postdate", DateString(item.Published, log.Key))
										.Replace("sharepath", dic["sharepath"])
										.Replace("postfilename", dic["postfilename"])
										.Replace("//", "/")
										;

									loggers[log.Key].Append(new LogEvent() {
										User = GetActor(pl.Actor, log.Key),
										Date = DateTime.Parse(item.Published),
										Action = "A",
										FileName = fnp
									});
								}
							}
							catch (Exception e) {
							}
						}

						if (item.Object.Plusoners.TotalItems > 0) {
							try {
								var listpl = dicitem.Value.Plusers;

								foreach (var pl in listpl) {
									var fnp = rules[Rules.Plus];
									fnp = fnp
										.Replace("type", "plus")
										.Replace("id", pl.Id)
										.Replace("postid", item.Id)
										.Replace("postactor", item.Actor.Id)
										.Replace("postdate", DateString(item.Published, log.Key))
										.Replace("sharepath", dic["sharepath"])
										.Replace("postfilename", dic["postfilename"])
										.Replace("//", "/")
										;

									loggers[log.Key].Append(new LogEvent() {
										User = GetActor(pl, log.Key),
										Date = DateTime.Parse(item.Published),
										Action = "A",
										FileName = fnp
									});
								}
							}
							catch (Exception e) {
							}
						}

						if (item.Object.Resharers.TotalItems > 0) {
							try {
								var listpl = dicitem.Value.Sharers;

								foreach (var pl in listpl) {
									var fnp = rules[Rules.Plus];
									fnp = fnp
										.Replace("type", "reshare")
										.Replace("id", pl.Id)
										.Replace("postid", item.Id)
										.Replace("postactor", item.Actor.Id)
										.Replace("postdate", DateString(item.Published, log.Key))
										.Replace("sharepath", dic["sharepath"])
										.Replace("postfilename", dic["postfilename"])
										.Replace("//", "/")
										;

									loggers[log.Key].Append(new LogEvent() {
										User = GetActor(pl, log.Key),
										Date = DateTime.Parse(item.Published),
										Action = "A",
										FileName = fnp
									});
								}
							}
							catch (Exception e) {
							}
						}
					}

					if (haveStater)
						Stater.Inc();
				}
			}
		}

		public object Run(GeneratorSetting setting) {			

			var acts = Service.Activities.List(setting.ProfileID, setting.Collection);
			
			var step = setting.MaxResults / 100;
			string nextPage = string.Empty;

			var loggers = new Dictionary<Visualizers.Types, Appender>();
			foreach (var log in setting.LogFiles)
				loggers[log.Key] = Visualizers.Loggers[log.Key].Invoke(new object[] { log.Value }) as Appender;
			
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

								if (item.Object.Resharers.TotalItems > 0) {
									var plser = Service.Comments.List(item.Id);
									plser.MaxResults = 100;
									try {
										var listpl = plser.Fetch();

										ditem.Comments = listpl.Items;
									}
									catch (Exception e) {											
									}										
								}

								if (item.Object.Plusoners.TotalItems > 0) {
									var plser = Service.People.ListByActivity(item.Id, PeopleResource.Collection.Plusoners);
									plser.MaxResults = 100;

									try {
										var listpl = plser.Fetch();

										ditem.Plusers = listpl.Items;
									}
									catch (Exception e) {											
									}
								}

								if (item.Object.Resharers.TotalItems > 0) {
									var plser = Service.People.ListByActivity(item.Id, PeopleResource.Collection.Resharers);
									plser.MaxResults = 100;

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

			foreach (var log in setting.LogFiles) {
				loggers[log.Key] = null;
			}
			loggers = null;

			return true;
		}
	}
}
