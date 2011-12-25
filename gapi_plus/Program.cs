using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace gapi_plus {
	static class Program {
		public static void ShowError(this Exception ex, IWin32Window owner = null) {
			MessageBox.Show(
				owner,
				ex.Message + (
					ex.InnerException != null ?
						"\n" + ex.InnerException.Message :
						""
				),
				"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);
		}
		
		/// <summary>
		/// The main entry point for the application.
		/// "AIzaSyCqVDlXyRu1I1HhUvvPjc_q2038gFSnb6U"
		/// </summary>
		[STAThread]
		static void Main() {
			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new mainForm());
			}
			catch (Exception ex) {
				ex.ShowError();
			}
		}
	}
}
