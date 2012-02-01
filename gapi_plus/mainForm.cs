using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using System.IO;

namespace LoggenCSG {
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
			var file = new System.IO.FileInfo("temp.rtf");
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
				file.Refresh();
				if (file.Exists)
					file.Delete();
			}

			rules = new Dictionary<Visualizers.Types, Dictionary<Rules, string>>() {
				{Visualizers.Code_swarm, new Dictionary<Rules,string>()},
			    {Visualizers.Gource, new Dictionary<Rules, string>()},
				{Visualizers.Logstalgia, new Dictionary<Rules, string>()},
				{Visualizers.Gephi, new Dictionary<Rules, string>()}
			};

			var rule = rules[Visualizers.Code_swarm];
			rule[Rules.SharePath] = "/";
			rule[Rules.ShareName] = "{actor}.{type}";
			rule[Rules.NotShare] = "/";
			rule[Rules.Post] = "{sharepath}/{actor}.{type}";
			rule[Rules.Comment] = "{sharepath}/{actor}.{type}";
			rule[Rules.Plus] = "{sharepath}/{id}.{type}";
			rule[Rules.Reshare] = "{sharepath}/{id}.{type}";

			rule = rules[Visualizers.Gource];
			rule[Rules.SharePath] = "/{date}/{actor}/{type}/{id}/";
			rule[Rules.ShareName] = "{id}.{type}";
			rule[Rules.NotShare] = "/{date}/{actor}/{type}/{id}/";
			rule[Rules.Post] = "{sharepath}/{id}.{type}";
			rule[Rules.Comment] = "{sharepath}/{type}s/{date}/{id}.{type}";
			rule[Rules.Plus] = "{sharepath}/{type}s/{date}/{id}.{type}";
			rule[Rules.Reshare] = "{sharepath}/{type}s/{date}/{id}.{type}";

			rule = rules[Visualizers.Logstalgia];
			rule[Rules.SharePath] = "/";
			rule[Rules.ShareName] = "{actorname}_{title}.{type}";
			rule[Rules.NotShare] = "/";
			rule[Rules.Post] = "{sharepath}/{actorname}_{title}.{type}";
			rule[Rules.Comment] = "{sharepath}/{actorname}_{title}.{type}";
			rule[Rules.Plus] = "{sharepath}/{actorname}_{postid}.{type}";
			rule[Rules.Reshare] = "{sharepath}/{actorname}_{postid}.{type}";

			rule = rules[Visualizers.Gephi];
			rule[Rules.SharePath] = "";
			rule[Rules.ShareName] = "{type}:{title}";
			rule[Rules.NotShare] = "";
			rule[Rules.Post] = "{type}:{title}";
			rule[Rules.Comment] = "{type}:{title}";
			rule[Rules.Plus] = "{type}:{posttitle}";
			rule[Rules.Reshare] = "{type}:{posttitle}";

			fillData();
		}

		private void fillData() {
			busy = true;

			dgRules.Columns.Clear();
			dgRules.Columns[dgRules.Columns.Add("rulesCol", "Rules")].ReadOnly = true;

			var needNames = new Dictionary<Visualizers.Types, string>() {
				{Visualizers.Code_swarm, @"C:\actions.xml"},
				{Visualizers.Gource, @"C:\actions.log"},
				{Visualizers.Logstalgia, @"C:\actlogs.log"},
				{Visualizers.Gephi, @"C:\gephidata.db"}
			};

			foreach (var key in rules.Keys) {
				var name = Visualizers.GetName(key);
				dgRules.Columns.Add(name + "Col", name);

				var control = new OutFilePanel() {
					Title = name,
					FileName = needNames[key],
					Checked = true,
					Dock = DockStyle.Top,
					Tag = key
				};
				control.CheckedChanged += new System.EventHandler(cb_CheckedChanged);
				groupBox1.Controls.Add(control);
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

			if (tbID.Text.IsEmpty()) {
				new Exception("Enter Profile ID").ShowError(this);
				tbID.Focus();
				return;
			}

			if (apikey.Text.IsEmpty() && Program.OAuth2 == null) {
				new Exception("Enter your simple API key").ShowError(this);
				return;
			}

			using (var sc = new StateControl()) {
				sc.Dock = DockStyle.Fill;
				//tableLayoutPanel1.Controls.Remove(apip);
				tableLayoutPanel1.Controls.Add(sc, 1, 5);
				Application.DoEvents();

				btGen.Enabled = false;
				try {

					Visualizers.Types flags = Visualizers.Types.None;

					var filenames = new Dictionary<Visualizers.Types, string>();

					var controls = groupBox1.Controls.OfType<OutFilePanel>().Where(x => x.Checked);

					foreach (var cont in controls) {
						if (cont.Tag is Visualizers.Types) {
							var key = (Visualizers.Types)cont.Tag;

							if (cont.Checked) {
								flags = flags | key;
								filenames[key] = cont.FileName;
								if (File.Exists(cont.FileName))
									File.Delete(cont.FileName);
							}
						}
					}

					if (filenames.Count < 1)
						return;

					Generate(tbID.Text, sc, flags, filenames);
				}
				finally {
					btGen.Enabled = true;
					tableLayoutPanel1.Controls.Remove(sc);
					//tableLayoutPanel1.Controls.Add(apip, 1, 3);
				}
			}
		}

		private void Generate(string idProfile, StateControl sc, Visualizers.Types flags, Dictionary<Visualizers.Types, string> filenames) {
			var sett = new GeneratorSetting() {
				ProfileID = /*"101113754039426612780"*/idProfile,
				Rules = rules,
				VisLogs = (Visualizers.Types)flags,
				LogFiles = filenames,
				Methods = new Dictionary<Visualizers.Types, GeneratorLogsMeth> {
					//UD
					{Visualizers.Code_swarm, UDGenerator.LogGen},
					{Visualizers.Gource, Generator.LogGen},
					{Visualizers.Logstalgia, Generator.LogGen},
					{Visualizers.Gephi, Generator.LogGen},
				},
				MaxResults = Convert.ToInt32(nudMaxRes.Value),
				MaxComments = Convert.ToInt32(nudMaxComment.Value),
				MaxPluses = Convert.ToInt32(nudMaxPlus.Value),
				MaxReshares = Convert.ToInt32(nudMaxReshare.Value),
				Deep = checkBox1.Checked ? Convert.ToInt32(nudDeep.Value) : 0
			};

			//UD
			if (checkBox2.Checked) {
				new FollowersGenerator(apikey.Text, sc).Run(sett);
			}
			else {
				if (checkBox1.Checked)
					(Program.OAuth2 != null ? new RGenerator(Program.OAuth2, sc) : new RGenerator(apikey.Text, sc)).Run(sett);
				else
					(Program.OAuth2 != null ? new RGenerator(Program.OAuth2, sc) : new Generator(apikey.Text, sc)).Run(sett);
			}
		}

		private void CheckEnabledGen() {
			btGen.Enabled = groupBox1.Controls.OfType<OutFilePanel>().Count(x => (x as OutFilePanel).Checked) > 0;
		}

		private void cb_CheckedChanged(object sender, EventArgs e) {
			CheckEnabledGen();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show(this,
				string.Format("{0} v{1}\nUsed Google APIs.\nApache License v2 http://www.apache.org/licenses/ \nCreate by Artem Zubkov (ArtZub@gmail.com) © 2012.",
					Application.ProductName, Application.ProductVersion),
				"About programm", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e) {
			nudMaxComment.Enabled = 
				nudMaxPlus.Enabled = 
				nudMaxReshare.Enabled = !checkBox2.Checked;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			nudDeep.Enabled = checkBox1.Checked;
		}
	}
}
