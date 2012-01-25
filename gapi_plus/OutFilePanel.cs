using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gapi_plus {
	public partial class OutFilePanel : UserControl {

		public bool Checked {
			get {
				return cbName.Checked;
			}
			set {
				cbName.Checked = value;
			}
		}

		public string Title {
			get {
				return cbName.Text;
			}
			set {
				cbName.Text = value;
			}
		}

		public string FileName {
			get {
				return textBox1.Text;
			}
			set {
				textBox1.Text = value;
			}
		}

		public EventHandler CheckedChanged;

		public OutFilePanel() {
			InitializeComponent();
		}

		private void cbName_CheckedChanged(object sender, EventArgs e) {
			panel1.Enabled = cbName.Checked;
			if (CheckedChanged != null)
				CheckedChanged(this, e);
		}
	}
}
