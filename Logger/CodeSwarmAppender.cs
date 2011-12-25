namespace Logger {
	public class CodeSwarmAppender : FileAppender {
		protected override string GetHeader() {
			return "<?xml vertion=\"1.0\" ?>\n<file_events>";
		}

		protected override string GetFooter() {
			return "</file_events>";
		}

		public CodeSwarmAppender(string fileName)
			: base(fileName) {
		}

		protected override string Parse(LogEvent logEvent) {
			return string.Format("<event filename=\"{0}\" author=\"{1}\" date=\"{2}\" action=\"{3}\" />",
				logEvent.FileName,
				logEvent.User,
				logEvent.Date.ToBinary(),
				logEvent.Action
			);
		}
	}
}
