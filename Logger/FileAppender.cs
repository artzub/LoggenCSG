using System.IO;

namespace Logger {
	public class FileAppender : Appender {

		private string delimiter;

		protected virtual string Parse(LogEvent logEvent) {
			return string.Format("{1}{0}{2}{0}{3}{0}{4}", 
				delimiter,
				logEvent.Date,
				logEvent.User,
				logEvent.Action,
				logEvent.FileName
			);
		}

		protected virtual string GetHeader() {
			return "";
		}
		protected virtual string GetFooter() {
			return "";
		}

		public FileAppender(string fileName, string delimiter = ";") : base() {
			FileName = fileName;
			this.delimiter = delimiter;
		}

		public string FileName {
			get;
			set;
		}

		protected override void DoAppend(LogEvent logEvent) {
			var file = new FileInfo(FileName);

			if (!file.Exists)
				Write(GetHeader());

			Write(Parse(logEvent));			
		}

		private void Write(string str) {
			using (var file = new FileInfo(FileName).AppendText()) {
				file.WriteLine(str);
			}
		}

		~FileAppender() {
			Write(GetFooter());
		}
	}
}
