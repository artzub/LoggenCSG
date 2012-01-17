using System;
 
namespace Logger {
	public abstract class Appender : IDisposable {

		protected Appender() {
		}

		~Appender() {
		}

		protected abstract void DoAppend(LogEvent logEvent); 

		public void Append(LogEvent logEvent) {
			DoAppend(logEvent);
		}

		public abstract void Dispose();
	}
}
