using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Logger {
	public abstract class SQLiteAppender : Appender {

		protected SQLiteAppender(string filename)
			: base() {
			InitContext(filename);
		}

		protected abstract void InitContext(string dbfilepath);

		protected abstract void AddData(LogEvent logEvent);

		protected override void DoAppend(LogEvent logEvent) {
			AddData(logEvent);
		}

		public abstract override void Dispose();
	}
}
