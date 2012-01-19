
using System;
namespace Logger {
	public class LogstalgiaAppender : FileAppender {
		public LogstalgiaAppender(string fileName) :
			base(fileName, "|") {
		}

		private Int64 GetTime(DateTime date) {
			Int64 retval = 0;
			TimeSpan t = date - DateTime.Parse("1970/1/1");
			retval = Convert.ToInt64(t.TotalSeconds);
			//(Int64)(t.TotalMilliseconds + 0.5);
			return retval;
		}

		protected override string Parse(LogEvent logEvent) {
			return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
				delimiter,
				GetTime(logEvent.Date).ToString(),
				logEvent.User,				
				logEvent.FileName,
				logEvent.Action,
				(logEvent is LogstalgiaEvent) ? (logEvent as LogstalgiaEvent).Size : "1"
			);
		}
	}

	public class LogstalgiaEvent : LogEvent {
		public string Size {
			get;
			set;
		}
	}
}
