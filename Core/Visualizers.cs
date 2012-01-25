using System;
using System.Collections.Generic;
using System.Reflection;
using Logger;

namespace Core {
	public class Visualizers {
		[Flags]
		public enum Types {
			None = 0,
			Code_swarm = 1,
			Gource = 2,
			Logstalgia = 4,
			Gephi = 7
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

		public static Types Logstalgia {
			get {
				return Types.Logstalgia;
			}
		}

		public static Types Gephi {
			get {
				return Types.Gephi;
			}
		}

		public static string[] Names {
			get {
				return Enum.GetNames(typeof(Types));
			}
		}

		public static object Parse(string name) {
			return Enum.Parse(typeof(Types), name, true);
		}

		public static Dictionary<Types, Type> Loggers = new Dictionary<Types, Type>() {
			{Code_swarm, typeof(CodeSwarmAppender)},
			{Gource, typeof(GourceAppender)},
			{Logstalgia, typeof(LogstalgiaAppender)},
			{Gephi, typeof(GephiAppender)}
		};

		public static Dictionary<Types, Type> TypeLogEvent = new Dictionary<Types, Type>() {
			{Code_swarm, typeof(LogEvent)},
			{Gource, typeof(LogEvent)},
			{Logstalgia, typeof(LogstalgiaEvent)},
			{Gephi, typeof(GephiLogEvent)}
		};

		public static string GetName(Types type) {
			return Enum.GetName(type.GetType(), type);
		}
	}
}
