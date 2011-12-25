using System;
using System.Collections.Generic;
using System.Reflection;
using Logger;

namespace gapi_plus {
	public class Visualizers {
		[Flags]
		public enum Types {
			Code_swarm,
			Gource
		}

		public static Types Gource {
			get {
				return Types.Gource;
			}
		}

		public static Types Code_swarm {
			get {
				return Types.Code_swarm;
			}
		}

		public static string[] Names {
			get {
				return Enum.GetNames(typeof(Types));
			}
		}

		public static object Parse(string name) {
			return Enum.Parse(typeof(Types), name);
		}

		public static Dictionary<Types, ConstructorInfo> Loggers = new Dictionary<Types, ConstructorInfo>() {
			{Types.Code_swarm, typeof(CodeSwarmAppender).GetConstructor(new Type[] { typeof(string) })},
			{Types.Gource, typeof(GourceAppender).GetConstructor(new Type[] { typeof(string) })}
		};
	}
}
