using System;
namespace Logger {
	public class CodeSwarmAppender : FileAppender {
		protected override string GetHeader() {
			return "<?xml version=\"1.0\" ?>\n<file_events>";
		}

		protected override string GetFooter() {
			return "</file_events>";
		}

		private Int64 GetTime(DateTime date) {
			Int64 retval = 0;
			TimeSpan t = date - DateTime.Parse("1970/1/1");
			retval = Convert.ToInt64(t.TotalMilliseconds);
			//(Int64)(t.TotalMilliseconds + 0.5);
			return retval;
		}

		public CodeSwarmAppender(string fileName)
			: base(fileName) {
		}

		protected override string Parse(LogEvent logEvent) {
			return string.Format("<event filename=\"{0}\" author=\"{1}\" date=\"{2}\" action=\"{3}\" />",
				logEvent.FileName,
				logEvent.User,
				GetTime(logEvent.Date).ToString(),
				logEvent.Action
			);
		}
	}
}
