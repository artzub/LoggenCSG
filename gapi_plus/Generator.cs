using System;

using Google.Apis.Plus.v1;

using Core;
using Logger;

namespace gapi_plus {
	internal class Generator {

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

		public object Run(GeneratorSetting setting) {
			if (haveStater)
				Stater.SetState("Load feeds...", 10);

			var acts = Service.Activities.List(setting.ProfileID, setting.Collection);
			acts.MaxResults = setting.MaxResults;

			//var loggers = new Dictionary<Visualizers.Types, Appender>();

			var feed = acts.Fetch();

			if (haveStater) {
				Stater.SetState("Generation ...", 0);
				Stater.MaxPosition = feed.Items.Count * setting.LogFiles.Count;				
			}

			if (feed.Items.Count > 0) {
				foreach (var log in setting.LogFiles) {
					var logger = Visualizers.Loggers[log.Key].Invoke(new object[] { log.Value }) as Appender;
					 
					foreach (var item in feed.Items) {
						logger.Append(new LogEvent() {
							User = item.Actor.DisplayName,
							Date = DateTime.Parse(item.Published),
							Action = "A",
							FileName = string.Format("/{0}/{1}.{0}", item.Verb, item.Id)
						});
						if (haveStater)
							Stater.Inc();
					}
					logger = null;
				}
			}
			return true;
		}
	}
}
