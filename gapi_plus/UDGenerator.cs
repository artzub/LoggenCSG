using System;

using Google.Apis.Plus.v1;

using Core;
using Logger;
using System.Collections.Generic;
using Google.Apis.Plus.v1.Data;

namespace gapi_plus {
	internal class UDGenerator : Generator {
		public UDGenerator(string apiKey, IStater stater = null) : 
			base(apiKey, stater) {
		}

		static public void LogGen(Dictionary<Visualizers.Types, Appender> loggers, Visualizers.Types typelog, Dictionary<Rules, string> rules, KeyValuePair<Activity, ActivityCont> dicitem) {
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
					.Replace("postid", item.Id)
					.Replace("id", item.Object.Id)
					.Replace("actor", item.Object.Actor.Id)
					.Replace("date", DateString(item.Published, typelog))
					.Replace("//", "/")
					;

				dic["postfilename"] = rules[Rules.ShareName];
				dic["postfilename"] = dic["sharepath"] + dic["postfilename"]
					.Replace("type", item.Verb)
					.Replace("postid", item.Id)
					.Replace("id", GetActor(item.Object.Actor, Visualizers.Code_swarm))
					.Replace("actor", item.Object.Actor.Id)
					.Replace("date", DateString(item.Published, typelog))
					.Replace("//", "/")
					;

				loggers[typelog].Append(new LogEvent() {
					User = item.Object.Id,
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
					.Replace("date", DateString(item.Published, typelog))
					.Replace("//", "/")
					;
			}

			dic["postfilename"] = rules[Rules.Post];
			dic["postfilename"] = dic["postfilename"]
				.Replace("type", item.Verb)
				.Replace("id", GetActor(item.Actor, Visualizers.Code_swarm))
				.Replace("actor", item.Actor.Id)
				.Replace("date", DateString(item.Published, typelog))
				.Replace("sharepath", dic["sharepath"])
				.Replace("//", "/")
				;


			loggers[typelog].Append(new LogEvent() {
				User = item.Id,
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

								.Replace("postid", item.Id)
								.Replace("postactor", item.Actor.Id)
								.Replace("postdate", DateString(item.Published, typelog))

								.Replace("id", GetActor(pl.Actor, Visualizers.Code_swarm))
								.Replace("actor", pl.Actor.Id)
								.Replace("date", DateString(pl.Published, typelog))
								.Replace("sharepath", dic["sharepath"])
								.Replace("postfilename", dic["postfilename"])
								.Replace("//", "/")
								;

							loggers[typelog].Append(new LogEvent() {
								User = item.Id,
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
								.Replace("postid", item.Id)
								.Replace("postactor", item.Actor.Id)
								.Replace("postdate", DateString(item.Published, typelog))
								.Replace("id", GetActor(pl, Visualizers.Code_swarm))
								.Replace("sharepath", dic["sharepath"])
								.Replace("postfilename", dic["postfilename"])
								.Replace("//", "/")
								;

							loggers[typelog].Append(new LogEvent() {
								User = item.Id,
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
								.Replace("postid", item.Id)
								.Replace("postactor", item.Actor.Id)
								.Replace("postdate", DateString(item.Published, typelog))
								.Replace("id", GetActor(pl, Visualizers.Code_swarm))
								.Replace("sharepath", dic["sharepath"])
								.Replace("postfilename", dic["postfilename"])
								.Replace("//", "/")
								;

							loggers[typelog].Append(new LogEvent() {
								User = item.Id,
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
		}
	}
}
