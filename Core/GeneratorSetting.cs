using System.Collections.Generic;

namespace Core {
	public class GeneratorSetting {
		public Visualizers.Types VisLogs {
			get;
			set;
		}

		public Dictionary<Visualizers.Types, string> LogFiles {
			get;
			set;
		}
	}
}
