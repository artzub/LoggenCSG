using System.Linq;
using System.Collections.Generic;
using Core;
using System;

namespace LoggenCSG {
	internal class GeneratorSetting : Core.GeneratorSetting {
		public Visualizers.Types VisLogs {
			get;
			set;
		}

		public Dictionary<Visualizers.Types, string> LogFiles {
			get;
			set;
		}

		public Dictionary<Visualizers.Types, GeneratorLogsMeth> Methods {
			get;
			set;
		}

		public Dictionary<Visualizers.Types, Dictionary<Rules, string>> Rules {
			get;
			set;
		}

		public string ProfileID {
			get;
			set;
		}

		public Google.Apis.Plus.v1.ActivitiesResource.Collection Collection {
			get;
			set;
		}

		public int MaxResults {
			get;
			set;
		}

		public int MaxComments {
			get;
			set;
		}

		public int MaxPluses {
			get;
			set;
		}

		public int MaxReshares {
			get;
			set;
		}

		public int Deep {
			get;
			set;
		}

		public bool UseDateRange {
			get;
			set;
		}

		public DateTime DateFrom {
			get;
			set;
		}

		public DateTime DateTo {
			get;
			set;
		}

		public GeneratorSetting() {
			Collection = Google.Apis.Plus.v1.ActivitiesResource.Collection.Public;
		}

		public GeneratorSetting Clone() {

			var item = new GeneratorSetting();

			var arr = this.GetType().GetProperties().ToArray();

			foreach (var prop in arr) {
				prop.SetValue(item, prop.GetValue(this, null), null);
			}

			return item;
		}
	}
}
