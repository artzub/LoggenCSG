using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
	public abstract class Generator {

		protected abstract object GenerateLog(GeneratorSetting setting = null);

		public object Run(GeneratorSetting setting = null) {
			return GenerateLog(setting);
		}
	}
}
