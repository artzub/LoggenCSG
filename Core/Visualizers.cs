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
			Logstalgia = 4
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
			{Types.Gource, typeof(GourceAppender).GetConstructor(new Type[] { typeof(string) })},
			{Types.Logstalgia, typeof(LogstalgiaAppender).GetConstructor(new Type[] { typeof(string) })}
		};

		public static Dictionary<Types, ConstructorInfo> TypeLogEvent = new Dictionary<Types, ConstructorInfo>() {
			{Types.Code_swarm, typeof(LogEvent).GetConstructor(Type.EmptyTypes)},
			{Types.Gource, typeof(LogEvent).GetConstructor(Type.EmptyTypes)},
			{Types.Logstalgia, typeof(LogstalgiaEvent).GetConstructor(Type.EmptyTypes)}
		};
	}
}
