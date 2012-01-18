﻿using System;

using Google.Apis.Plus.v1;

using Core;
using Logger;
using System.Collections.Generic;
using Google.Apis.Plus.v1.Data;

namespace gapi_plus {
	internal class RGenerator : Generator {
		public RGenerator(string apiKey, IStater stater = null) :
			base(apiKey, stater) {
		}

		protected override object GenerateLog(Core.GeneratorSetting insetting = null) {

			var setting = insetting as GeneratorSetting;

			var acts = Service.Activities.List(setting.ProfileID, setting.Collection);

			var step = setting.MaxResults / (double)100;
			string nextPage = string.Empty;

			var users = new Dictionary<string, bool>();

			users[setting.ProfileID] = true;

			loggers = new Dictionary<Visualizers.Types, Appender>();
			foreach (var log in setting.LogFiles)
				loggers[log.Key] = Visualizers.Loggers[log.Key].Invoke(new object[] { log.Value }) as Appender;			

			while (step != 0) {

				var nextResults = 100;
				if (step-- < 1) {
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

							if (item.Verb == "share" && 
								item.Object != null && 
								item.Object.Actor != null) {
								if (!users.ContainsKey(item.Object.Actor.Id)) {
									users[item.Object.Actor.Id] = true;
									var sset = setting.Clone();
									sset.ProfileID = item.Object.Actor.Id;
									base.GenerateLog(sset);
								}
							}

							if (item.Object != null) {

								if (item.Object.Resharers.TotalItems > 0) {
									var plser = Service.Comments.List(item.Id);
									plser.MaxResults = 100;
									try {
										var listpl = plser.Fetch();

										ditem.Comments = listpl.Items;

										foreach (var sitem in listpl.Items) {
											if (!users.ContainsKey(sitem.Actor.Id)) {
												users[sitem.Actor.Id] = true;
												var sset = setting.Clone();
												sset.ProfileID = sitem.Actor.Id;
												base.GenerateLog(sset);
											}
										}
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
										foreach (var sitem in listpl.Items) {
											if (!users.ContainsKey(sitem.Id)) {
												users[sitem.Id] = true;
												var sset = setting.Clone();
												sset.ProfileID = sitem.Id;
												base.GenerateLog(sset);
											}
										}
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
										foreach (var sitem in listpl.Items) {
											if (!users.ContainsKey(sitem.Id)) {
												users[sitem.Id] = true;
												var sset = setting.Clone();
												sset.ProfileID = sitem.Id;
												base.GenerateLog(sset);
											}
										}
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
				loggers[log.Key].Dispose();
			}
			loggers = null;

			return true;
		}
	}
}