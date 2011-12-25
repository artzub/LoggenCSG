using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
	public interface IStater {
		int Position {
			get;
			set;
		}

		int MaxPosition {
			get;
			set;
		}

		string StateLabel {
			get;
			set;
		}

		void Inc(int value = 1);

		void MovePosition(int newPosition);

		void SetState(string description, int position = 0, bool incPosition = false);

		void InitState(string description = default(string), int maxPosition = 100, int startPosition = 0);
	}
}
