namespace gapi_plus {
	partial class mainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.btGen = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.dgRules = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.tbID = new System.Windows.Forms.TextBox();
			this.profileId = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbFileCS = new System.Windows.Forms.TextBox();
			this.btBrowse1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tbFileG = new System.Windows.Forms.TextBox();
			this.btBrowse2 = new System.Windows.Forms.Button();
			this.nudMaxRes = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxRes)).BeginInit();
			this.SuspendLayout();
			// 
			// btGen
			// 
			this.btGen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btGen.Location = new System.Drawing.Point(3, 143);
			this.btGen.Name = "btGen";
			this.btGen.Size = new System.Drawing.Size(152, 28);
			this.btGen.TabIndex = 0;
			this.btGen.Text = "Generate";
			this.btGen.UseVisualStyleBackColor = true;
			this.btGen.Click += new System.EventHandler(this.btGen_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.tbID, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.profileId, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btGen, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.nudMaxRes, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 752);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tabControl2
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.tabControl2, 2);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(3, 177);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(655, 572);
			this.tabControl2.TabIndex = 6;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.dgRules);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(647, 546);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Rules";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// dgRules
			// 
			this.dgRules.AllowUserToAddRows = false;
			this.dgRules.AllowUserToDeleteRows = false;
			this.dgRules.AllowUserToResizeRows = false;
			this.dgRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			this.dgRules.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgRules.Location = new System.Drawing.Point(3, 3);
			this.dgRules.Name = "dgRules";
			this.dgRules.RowHeadersWidth = 20;
			this.dgRules.Size = new System.Drawing.Size(641, 540);
			this.dgRules.TabIndex = 0;
			this.dgRules.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRules_CellValueChanged);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "n\\n";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Code_swarm";
			this.Column2.Name = "Column2";
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Gource";
			this.Column3.Name = "Column3";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
			this.tabPage3.Controls.Add(this.richTextBox1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
			this.tabPage3.Size = new System.Drawing.Size(647, 544);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "About rules ";
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(10, 10);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(627, 524);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// tbID
			// 
			this.tbID.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbID.Location = new System.Drawing.Point(161, 3);
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(497, 23);
			this.tbID.TabIndex = 1;
			// 
			// profileId
			// 
			this.profileId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.profileId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.profileId.Location = new System.Drawing.Point(3, 0);
			this.profileId.Name = "profileId";
			this.profileId.Size = new System.Drawing.Size(152, 28);
			this.profileId.TabIndex = 2;
			this.profileId.Text = "PROFILE ID:";
			this.profileId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(3, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 28);
			this.label2.TabIndex = 3;
			this.label2.Text = "Number of the last posts:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
			this.groupBox1.Controls.Add(this.tableLayoutPanel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 59);
			this.groupBox1.Name = "groupBox1";
			this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 3);
			this.groupBox1.Size = new System.Drawing.Size(655, 78);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Save to";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Controls.Add(this.checkBox2, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.checkBox1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(649, 59);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tbFileCS);
			this.panel1.Controls.Add(this.btBrowse1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(153, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(493, 23);
			this.panel1.TabIndex = 2;
			// 
			// tbFileCS
			// 
			this.tbFileCS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbFileCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbFileCS.Location = new System.Drawing.Point(0, 0);
			this.tbFileCS.Name = "tbFileCS";
			this.tbFileCS.Size = new System.Drawing.Size(418, 23);
			this.tbFileCS.TabIndex = 0;
			this.tbFileCS.Text = "actions.xml";
			// 
			// btBrowse1
			// 
			this.btBrowse1.Dock = System.Windows.Forms.DockStyle.Right;
			this.btBrowse1.Location = new System.Drawing.Point(418, 0);
			this.btBrowse1.Margin = new System.Windows.Forms.Padding(0);
			this.btBrowse1.Name = "btBrowse1";
			this.btBrowse1.Size = new System.Drawing.Size(75, 23);
			this.btBrowse1.TabIndex = 1;
			this.btBrowse1.Text = "Browse...";
			this.btBrowse1.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tbFileG);
			this.panel2.Controls.Add(this.btBrowse2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(153, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(493, 24);
			this.panel2.TabIndex = 3;
			// 
			// tbFileG
			// 
			this.tbFileG.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbFileG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbFileG.Location = new System.Drawing.Point(0, 0);
			this.tbFileG.Name = "tbFileG";
			this.tbFileG.Size = new System.Drawing.Size(418, 23);
			this.tbFileG.TabIndex = 0;
			this.tbFileG.Text = "actions.log";
			// 
			// btBrowse2
			// 
			this.btBrowse2.Dock = System.Windows.Forms.DockStyle.Right;
			this.btBrowse2.Location = new System.Drawing.Point(418, 0);
			this.btBrowse2.Margin = new System.Windows.Forms.Padding(0);
			this.btBrowse2.Name = "btBrowse2";
			this.btBrowse2.Size = new System.Drawing.Size(75, 24);
			this.btBrowse2.TabIndex = 1;
			this.btBrowse2.Text = "Browse...";
			this.btBrowse2.UseVisualStyleBackColor = true;
			// 
			// nudMaxRes
			// 
			this.nudMaxRes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudMaxRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nudMaxRes.Location = new System.Drawing.Point(161, 31);
			this.nudMaxRes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudMaxRes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudMaxRes.Name = "nudMaxRes";
			this.nudMaxRes.Size = new System.Drawing.Size(497, 23);
			this.nudMaxRes.TabIndex = 2;
			this.nudMaxRes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBox1.Location = new System.Drawing.Point(3, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.checkBox1.Size = new System.Drawing.Size(144, 23);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "code_swarm";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBox2.Location = new System.Drawing.Point(3, 32);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.checkBox2.Size = new System.Drawing.Size(144, 24);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "gource";
			this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.ClientSize = new System.Drawing.Size(661, 752);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "mainForm";
			this.Text = "GPLUS";
			this.Load += new System.EventHandler(this.mainForm_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgRules)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxRes)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btGen;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.Label profileId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbFileCS;
		private System.Windows.Forms.Button btBrowse1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox tbFileG;
		private System.Windows.Forms.Button btBrowse2;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.DataGridView dgRules;
		private System.Windows.Forms.NumericUpDown nudMaxRes;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

