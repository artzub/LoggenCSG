using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoggenCSG {
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

		private void button1_Click(object sender, EventArgs e) {
			using (var save = new SaveFileDialog()) {
				if (!string.IsNullOrWhiteSpace(FileName))
					save.FileName = FileName;

				save.Filter = "(*.log)|*.log|(*.xml)|*.xml|(*.db)|*.db|All files (*.*)|*.*";
				save.Title = "Select a file to save the log to " + Title;
				save.RestoreDirectory = true;
				if (save.ShowDialog(this) == DialogResult.OK)
					FileName = save.FileName;
			}
		}
	}
}
