using System;

namespace Logger {
	public class LogEvent {
		public string FileName {
			get;
			set;
		}

		public string User {
			get;
			set;
		}

		public string Action {
			get;
			set;
		}

		public DateTime Date {
			get;
			set;
		}
	}
}
