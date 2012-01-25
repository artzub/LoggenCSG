using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger {
	public class GephiLogEvent : LogstalgiaEvent {
		public string From {
			get;
			set;
		}
	}
}
