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

			var action = "A";

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

				loggers[typelog].Append(new LogEvent() {
					User = item.Object.Id,
					Date = DateTime.Parse(item.Published),
					Action = action,
					FileName = po.PostFileName
				});

				action = "M";
			}
			else {
				po.Post = item;
				po.Type = TypePattern.post;
				po.Pattern = rules[Rules.NotShare];

				po.SharePath = ReplacePattern(po);
			}

			po.Type = TypePattern.post;
			po.Pattern = rules[Rules.Post];

			po.PostFileName = ReplacePattern(po);

			loggers[typelog].Append(new LogEvent() {
				User = item.Id,
				Date = DateTime.Parse(item.Published),
				Action = action,
				FileName = po.PostFileName
			});

			if (item.Object != null) {

				if (item.Object.Resharers.TotalItems > 0) {
					try {
						var listpl = dicitem.Value.Comments;
						po.Pattern = rules[Rules.Comment];
						po.Type = TypePattern.comment;
						foreach (var pl in listpl) {
							po.Comment = pl;
							var fnp = ReplacePattern(po);

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

				long ticks = 0;

				if (item.Object.Plusoners.TotalItems > 0) {
					try {
						var listpl = dicitem.Value.Plusers;

						po.Pattern = rules[Rules.Plus];
						po.Type = TypePattern.plus;

						foreach (var pl in listpl) {
							po.Person = pl;
							var fnp = ReplacePattern(po);

							loggers[typelog].Append(new LogEvent() {
								User = item.Id,
								Date = DateTime.Parse(item.Published).AddMinutes(ticks),
								Action = "A",
								FileName = fnp
							});

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
						po.Type = TypePattern.reshare;

						foreach (var pl in listpl) {
							po.Person = pl;
							var fnp = ReplacePattern(po);

							loggers[typelog].Append(new LogEvent() {
								User = item.Id,
								Date = DateTime.Parse(item.Published).AddMinutes(ticks),
								Action = "A",
								FileName = fnp
							});

							ticks += 5;
						}
					}
					catch (Exception e) {
					}
				}
			}
		}
	}
}
