using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
	public interface IStater {
		long Position {
			get;
			set;
		}

		long MaxPosition {
			get;
			set;
		}

		string StateLabel {
			get;
			set;
		}

		void Inc(long value = 1);

		void MovePosition(long newPosition);

		void SetState(string description, long position = 0, bool incPosition = false);

		void InitState(string description = default(string), long maxPosition = 100, long startPosition = 0);
	}
}
