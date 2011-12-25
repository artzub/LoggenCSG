
namespace Logger {
	public class GourceAppender : FileAppender {
		public GourceAppender(string fileName) : 
			base(fileName, "|") {
		}
	}
}
