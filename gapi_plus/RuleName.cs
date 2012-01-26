using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggenCSG {
	enum Rules {
		SharePath,
		ShareName,
		NotShare,
		Post,
		Comment,
		Plus,
		Reshare,
		None
	}

	sealed internal class RuleName {
		public Rules Rule {
			get;
			set;
		}

		public String Name {
			get;
			set;
		}

		public int Row {
			get;
			set;
		}
	}
}
