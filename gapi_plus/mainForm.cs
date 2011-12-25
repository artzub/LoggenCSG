using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;

namespace gapi_plus {
	public partial class mainForm : Form {
		public mainForm() {
			InitializeComponent();
		}

		private RuleName[] rulesName = new[] {
			new RuleName() {Rule = Rules.SharePath, Name = "Share path", Row = 0},
			new RuleName() {Rule = Rules.ShareName, Name = "Share filename", Row = 0},
			new RuleName() {Rule = Rules.NotShare, Name = "if not share, path", Row = 0},
			new RuleName() {Rule = Rules.Post, Name = "Post", Row = 0},
			new RuleName() {Rule = Rules.Comment, Name = "Comment", Row = 0},
			new RuleName() {Rule = Rules.Plus, Name = "Plus", Row = 0},
			new RuleName() {Rule = Rules.Reshare, Name = "Reshare", Row = 0}
		};


		Dictionary<Visualizers.Types, Dictionary<Rules, string>> rules = null;

		private bool busy = false;

		private void mainForm_Load(object sender, EventArgs e) {
			var file = new System.IO.FileInfo("temp");
			try {
				if (file.Exists)
					file.Delete();
				using (var f = file.CreateText()) {
					f.Write(Properties.Resources.rules);
				}
				using (var f = file.OpenRead()) {
					richTextBox1.LoadFile(f, RichTextBoxStreamType.RichText);
				}
			}
			finally {
				if (file.Exists)
					file.Delete();
			}

			rules = new Dictionary<Visualizers.Types, Dictionary<Rules, string>>() {
				{Visualizers.Code_swarm, new Dictionary<Rules,string>()},
			    {Visualizers.Gource, new Dictionary<Rules, string>()}
			};

			var rule = rules[Visualizers.Code_swarm];
			rule[Rules.SharePath] = "/type/actor/";
			rule[Rules.ShareName] = "postId.type";
			rule[Rules.NotShare] = "/type";
			rule[Rules.Post] = "sharepath/id.type";
			rule[Rules.Comment] = "postfilename.type";
			rule[Rules.Plus] = "postfilename.type";
			rule[Rules.Reshare] = "postfilename.type";

			rule = rules[Visualizers.Gource];
			rule[Rules.SharePath] = "/type/actor/id/";
			rule[Rules.ShareName] = "id.type";
			rule[Rules.NotShare] = "/type";
			rule[Rules.Post] = "sharepath/id/id.type";
			rule[Rules.Comment] = "sharepath/types/date_actor.type";
			rule[Rules.Plus] = "sharepath/types/id/postid.type";
			rule[Rules.Reshare] = "sharepath/types/id/postid.type";

			fillData();
		}

		private void fillData() {
			busy = true;

			dgRules.Columns.Clear();
			dgRules.Columns[dgRules.Columns.Add("rulesCol", "Rules")].ReadOnly = true;

			foreach (var name in Visualizers.Names) {
				dgRules.Columns.Add(name + "Col", name);
			}

			foreach (var item in rulesName) {
				item.Row = dgRules.Rows.Add(item.Name, "none", "none");
			}

			foreach (var item in rules) {
				foreach (var rule in rulesName) {
					if (item.Value.Keys.Contains(rule.Rule))
						dgRules[item.Key.ToString() + "Col", rule.Row].Value = item.Value[rule.Rule];
				}
			}

			busy = false;
		}

		private Rules getRuleByRowIndex(int index) {
			foreach (var item in rulesName)
				if (item.Row == index)
					return item.Rule;
			return Rules.None;
		}
		
		private void dgRules_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			try {
				if (busy)
					return;

				var rule = getRuleByRowIndex(e.RowIndex);
				if (rule == Rules.None)
					return;

				var vis = Visualizers.Parse(dgRules.Columns[e.ColumnIndex].Name.Replace("Col", ""));

				if (vis == null)
					return;

				rules[(Visualizers.Types)vis][rule] = dgRules[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			catch (Exception ex) {
				ex.ShowError(this);
			}
		}

		private void btGen_Click(object sender, EventArgs e) {

			using (var sc = new StateControl()) {
				sc.Dock = DockStyle.Fill;
				tableLayoutPanel1.Controls.Add(sc, 1, 5);
				btGen.Enabled = false;
				try {
					(new Generator("AIzaSyCqVDlXyRu1I1HhUvvPjc_q2038gFSnb6U", sc)).Run(new GeneratorSetting() {
						ProfileID = tbID.Text,
						Rules = rules,
						VisLogs = Visualizers.Code_swarm | Visualizers.Gource,
						LogFiles = new Dictionary<Visualizers.Types, string> {
							{Visualizers.Code_swarm, tbFileCS.Text},
							{Visualizers.Gource, tbFileG.Text}
						},
						MaxResults = Convert.ToInt32(nudMaxRes.Value)
					});
				}
				finally {
					btGen.Enabled = true;
				}
			}
		}

		private void CheckEnabledGen() {
			btGen.Enabled = checkBox1.Checked | checkBox2.Checked;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			btBrowse1.Enabled = tbFileCS.Enabled = checkBox1.Checked;
			CheckEnabledGen();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e) {
			btBrowse2.Enabled = tbFileG.Enabled = checkBox2.Checked;
			CheckEnabledGen();
		}
	}
}
