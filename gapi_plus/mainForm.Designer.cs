namespace LoggenCSG {
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
			this.il16 = new System.Windows.Forms.ImageList();
			this.tlpGooglePlus = new System.Windows.Forms.TableLayoutPanel();
			this.cbDateRange = new System.Windows.Forms.CheckBox();
			this.cbFGraph = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.nudDeep = new System.Windows.Forms.NumericUpDown();
			this.cbDeep = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.nudMaxPlus = new System.Windows.Forms.NumericUpDown();
			this.nudMaxReshare = new System.Windows.Forms.NumericUpDown();
			this.nudMaxRes = new System.Windows.Forms.NumericUpDown();
			this.nudMaxComment = new System.Windows.Forms.NumericUpDown();
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
			this.apip = new System.Windows.Forms.Panel();
			this.apikey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tlpDates = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpGPlus = new System.Windows.Forms.TabPage();
			this.tpGAnalytics = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.tpLastfm = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tcGooglePlus = new System.Windows.Forms.TabControl();
			this.tpGPUsers = new System.Windows.Forms.TabPage();
			this.tpGPWords = new System.Windows.Forms.TabPage();
			this.tlpGooglePlus.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDeep)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxPlus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxReshare)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxRes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxComment)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.apip.SuspendLayout();
			this.tlpDates.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tcMain.SuspendLayout();
			this.tpGPlus.SuspendLayout();
			this.tpGAnalytics.SuspendLayout();
			this.tpLastfm.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tcGooglePlus.SuspendLayout();
			this.tpGPUsers.SuspendLayout();
			this.SuspendLayout();
			// 
			// btGen
			// 
			this.btGen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btGen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btGen.ImageIndex = 0;
			this.btGen.ImageList = this.il16;
			this.btGen.Location = new System.Drawing.Point(3, 168);
			this.btGen.Name = "btGen";
			this.btGen.Size = new System.Drawing.Size(152, 28);
			this.btGen.TabIndex = 0;
			this.btGen.Text = "Generate";
			this.btGen.UseVisualStyleBackColor = true;
			this.btGen.Click += new System.EventHandler(this.btGen_Click);
			// 
			// il16
			// 
			this.il16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il16.ImageStream")));
			this.il16.TransparentColor = System.Drawing.Color.Transparent;
			this.il16.Images.SetKeyName(0, "script_go.png");
			this.il16.Images.SetKeyName(1, "Google-Plus-icon.png");
			this.il16.Images.SetKeyName(2, "an.png");
			this.il16.Images.SetKeyName(3, "lastfm.ico");
			// 
			// tlpGooglePlus
			// 
			this.tlpGooglePlus.ColumnCount = 2;
			this.tlpGooglePlus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
			this.tlpGooglePlus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpGooglePlus.Controls.Add(this.cbDateRange, 0, 2);
			this.tlpGooglePlus.Controls.Add(this.cbFGraph, 0, 4);
			this.tlpGooglePlus.Controls.Add(this.tableLayoutPanel3, 0, 3);
			this.tlpGooglePlus.Controls.Add(this.tableLayoutPanel2, 1, 1);
			this.tlpGooglePlus.Controls.Add(this.tabControl2, 0, 7);
			this.tlpGooglePlus.Controls.Add(this.tbID, 1, 0);
			this.tlpGooglePlus.Controls.Add(this.profileId, 0, 0);
			this.tlpGooglePlus.Controls.Add(this.label2, 0, 1);
			this.tlpGooglePlus.Controls.Add(this.btGen, 0, 6);
			this.tlpGooglePlus.Controls.Add(this.groupBox1, 0, 5);
			this.tlpGooglePlus.Controls.Add(this.apip, 1, 6);
			this.tlpGooglePlus.Controls.Add(this.label5, 1, 4);
			this.tlpGooglePlus.Controls.Add(this.tlpDates, 1, 2);
			this.tlpGooglePlus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpGooglePlus.Location = new System.Drawing.Point(3, 3);
			this.tlpGooglePlus.Name = "tlpGooglePlus";
			this.tlpGooglePlus.RowCount = 8;
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpGooglePlus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpGooglePlus.Size = new System.Drawing.Size(657, 590);
			this.tlpGooglePlus.TabIndex = 1;
			// 
			// cbDateRange
			// 
			this.cbDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbDateRange.Location = new System.Drawing.Point(3, 59);
			this.cbDateRange.Name = "cbDateRange";
			this.cbDateRange.Size = new System.Drawing.Size(152, 22);
			this.cbDateRange.TabIndex = 13;
			this.cbDateRange.Text = "Date range";
			this.cbDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbDateRange.UseVisualStyleBackColor = true;
			this.cbDateRange.CheckedChanged += new System.EventHandler(this.cbDateRange_CheckedChanged);
			// 
			// cbFGraph
			// 
			this.cbFGraph.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbFGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbFGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbFGraph.Location = new System.Drawing.Point(3, 115);
			this.cbFGraph.Name = "cbFGraph";
			this.cbFGraph.Size = new System.Drawing.Size(152, 22);
			this.cbFGraph.TabIndex = 9;
			this.cbFGraph.Text = "Followers Graph";
			this.cbFGraph.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbFGraph.UseVisualStyleBackColor = true;
			this.cbFGraph.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tlpGooglePlus.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Controls.Add(this.nudDeep, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.cbDeep, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 84);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(657, 28);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// nudDeep
			// 
			this.nudDeep.Dock = System.Windows.Forms.DockStyle.Left;
			this.nudDeep.Enabled = false;
			this.nudDeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nudDeep.Location = new System.Drawing.Point(161, 3);
			this.nudDeep.Name = "nudDeep";
			this.nudDeep.Size = new System.Drawing.Size(91, 23);
			this.nudDeep.TabIndex = 10;
			// 
			// cbDeep
			// 
			this.cbDeep.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbDeep.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbDeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbDeep.Location = new System.Drawing.Point(3, 3);
			this.cbDeep.Name = "cbDeep";
			this.cbDeep.Size = new System.Drawing.Size(152, 22);
			this.cbDeep.TabIndex = 6;
			this.cbDeep.Text = "Deep";
			this.cbDeep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbDeep.UseVisualStyleBackColor = true;
			this.cbDeep.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 5;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.Controls.Add(this.nudMaxPlus, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudMaxReshare, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudMaxRes, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudMaxComment, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(158, 28);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(499, 28);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// nudMaxPlus
			// 
			this.nudMaxPlus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudMaxPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nudMaxPlus.Location = new System.Drawing.Point(201, 3);
			this.nudMaxPlus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudMaxPlus.Name = "nudMaxPlus";
			this.nudMaxPlus.Size = new System.Drawing.Size(93, 23);
			this.nudMaxPlus.TabIndex = 5;
			this.nudMaxPlus.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// nudMaxReshare
			// 
			this.nudMaxReshare.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudMaxReshare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nudMaxReshare.Location = new System.Drawing.Point(300, 3);
			this.nudMaxReshare.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudMaxReshare.Name = "nudMaxReshare";
			this.nudMaxReshare.Size = new System.Drawing.Size(93, 23);
			this.nudMaxReshare.TabIndex = 4;
			this.nudMaxReshare.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// nudMaxRes
			// 
			this.nudMaxRes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudMaxRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nudMaxRes.Location = new System.Drawing.Point(3, 3);
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
			this.nudMaxRes.Size = new System.Drawing.Size(93, 23);
			this.nudMaxRes.TabIndex = 3;
			this.nudMaxRes.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// nudMaxComment
			// 
			this.nudMaxComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudMaxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nudMaxComment.Location = new System.Drawing.Point(102, 3);
			this.nudMaxComment.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudMaxComment.Name = "nudMaxComment";
			this.nudMaxComment.Size = new System.Drawing.Size(93, 23);
			this.nudMaxComment.TabIndex = 2;
			this.nudMaxComment.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// tabControl2
			// 
			this.tlpGooglePlus.SetColumnSpan(this.tabControl2, 2);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(3, 202);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(651, 385);
			this.tabControl2.TabIndex = 6;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.dgRules);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(643, 359);
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
			this.dgRules.Size = new System.Drawing.Size(637, 353);
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
			this.tabPage3.Size = new System.Drawing.Size(633, 401);
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
			this.richTextBox1.Size = new System.Drawing.Size(613, 381);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// tbID
			// 
			this.tbID.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbID.Location = new System.Drawing.Point(161, 3);
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(493, 23);
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
			this.groupBox1.AutoSize = true;
			this.tlpGooglePlus.SetColumnSpan(this.groupBox1, 2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 143);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(651, 19);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Save to";
			// 
			// apip
			// 
			this.apip.Controls.Add(this.apikey);
			this.apip.Controls.Add(this.label1);
			this.apip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.apip.Location = new System.Drawing.Point(161, 168);
			this.apip.Name = "apip";
			this.apip.Padding = new System.Windows.Forms.Padding(3);
			this.apip.Size = new System.Drawing.Size(493, 28);
			this.apip.TabIndex = 7;
			this.apip.Visible = false;
			// 
			// apikey
			// 
			this.apikey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.apikey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.apikey.Location = new System.Drawing.Point(47, 3);
			this.apikey.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.apikey.Name = "apikey";
			this.apikey.Size = new System.Drawing.Size(443, 23);
			this.apikey.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "APIkey:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(161, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(493, 28);
			this.label5.TabIndex = 10;
			this.label5.Text = "Graph relations between users that \"in circles\" and \"have in circles\"";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tlpDates
			// 
			this.tlpDates.ColumnCount = 2;
			this.tlpDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDates.Controls.Add(this.panel1, 0, 0);
			this.tlpDates.Controls.Add(this.panel2, 1, 0);
			this.tlpDates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpDates.Enabled = false;
			this.tlpDates.Location = new System.Drawing.Point(158, 56);
			this.tlpDates.Margin = new System.Windows.Forms.Padding(0);
			this.tlpDates.Name = "tlpDates";
			this.tlpDates.RowCount = 1;
			this.tlpDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpDates.Size = new System.Drawing.Size(499, 28);
			this.tlpDates.TabIndex = 12;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dtpFrom);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(243, 22);
			this.panel1.TabIndex = 0;
			// 
			// dtpFrom
			// 
			this.dtpFrom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtpFrom.Location = new System.Drawing.Point(35, 0);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(208, 20);
			this.dtpFrom.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 22);
			this.label6.TabIndex = 0;
			this.label6.Text = "from:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dtpTo);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(252, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(244, 22);
			this.panel2.TabIndex = 1;
			// 
			// dtpTo
			// 
			this.dtpTo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtpTo.Location = new System.Drawing.Point(35, 0);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(209, 20);
			this.dtpTo.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 22);
			this.label7.TabIndex = 1;
			this.label7.Text = "to:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpGPlus);
			this.tcMain.Controls.Add(this.tpGAnalytics);
			this.tcMain.Controls.Add(this.tpLastfm);
			this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcMain.ImageList = this.il16;
			this.tcMain.Location = new System.Drawing.Point(0, 24);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(685, 655);
			this.tcMain.TabIndex = 1;
			this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
			// 
			// tpGPlus
			// 
			this.tpGPlus.Controls.Add(this.tcGooglePlus);
			this.tpGPlus.ImageIndex = 1;
			this.tpGPlus.Location = new System.Drawing.Point(4, 23);
			this.tpGPlus.Name = "tpGPlus";
			this.tpGPlus.Padding = new System.Windows.Forms.Padding(3);
			this.tpGPlus.Size = new System.Drawing.Size(677, 628);
			this.tpGPlus.TabIndex = 0;
			this.tpGPlus.Text = "Google+";
			this.tpGPlus.UseVisualStyleBackColor = true;
			// 
			// tpGAnalytics
			// 
			this.tpGAnalytics.Controls.Add(this.label3);
			this.tpGAnalytics.ImageIndex = 2;
			this.tpGAnalytics.Location = new System.Drawing.Point(4, 23);
			this.tpGAnalytics.Name = "tpGAnalytics";
			this.tpGAnalytics.Padding = new System.Windows.Forms.Padding(3);
			this.tpGAnalytics.Size = new System.Drawing.Size(653, 624);
			this.tpGAnalytics.TabIndex = 1;
			this.tpGAnalytics.Text = "Google Analytics";
			this.tpGAnalytics.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(647, 618);
			this.label3.TabIndex = 0;
			this.label3.Text = "Comming soon ...";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tpLastfm
			// 
			this.tpLastfm.Controls.Add(this.label4);
			this.tpLastfm.ImageIndex = 3;
			this.tpLastfm.Location = new System.Drawing.Point(4, 23);
			this.tpLastfm.Name = "tpLastfm";
			this.tpLastfm.Padding = new System.Windows.Forms.Padding(3);
			this.tpLastfm.Size = new System.Drawing.Size(653, 624);
			this.tpLastfm.TabIndex = 2;
			this.tpLastfm.Text = "Last.fm";
			this.tpLastfm.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(647, 618);
			this.label4.TabIndex = 1;
			this.label4.Text = "Comming soon ...";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(685, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.aboutToolStripMenuItem.Text = "&About ...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// tcGooglePlus
			// 
			this.tcGooglePlus.Controls.Add(this.tpGPUsers);
			this.tcGooglePlus.Controls.Add(this.tpGPWords);
			this.tcGooglePlus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcGooglePlus.Location = new System.Drawing.Point(3, 3);
			this.tcGooglePlus.Name = "tcGooglePlus";
			this.tcGooglePlus.SelectedIndex = 0;
			this.tcGooglePlus.Size = new System.Drawing.Size(671, 622);
			this.tcGooglePlus.TabIndex = 1;
			this.tcGooglePlus.SelectedIndexChanged += new System.EventHandler(this.tcGooglePlus_SelectedIndexChanged);
			// 
			// tpGPUsers
			// 
			this.tpGPUsers.Controls.Add(this.tlpGooglePlus);
			this.tpGPUsers.Location = new System.Drawing.Point(4, 22);
			this.tpGPUsers.Name = "tpGPUsers";
			this.tpGPUsers.Padding = new System.Windows.Forms.Padding(3);
			this.tpGPUsers.Size = new System.Drawing.Size(663, 596);
			this.tpGPUsers.TabIndex = 0;
			this.tpGPUsers.Text = "Users & Post";
			this.tpGPUsers.UseVisualStyleBackColor = true;
			// 
			// tpGPWords
			// 
			this.tpGPWords.Location = new System.Drawing.Point(4, 22);
			this.tpGPWords.Name = "tpGPWords";
			this.tpGPWords.Padding = new System.Windows.Forms.Padding(3);
			this.tpGPWords.Size = new System.Drawing.Size(663, 596);
			this.tpGPWords.TabIndex = 1;
			this.tpGPWords.Text = "Words";
			this.tpGPWords.UseVisualStyleBackColor = true;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.ClientSize = new System.Drawing.Size(685, 679);
			this.Controls.Add(this.tcMain);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "mainForm";
			this.Text = "LoggenCSG";
			this.Load += new System.EventHandler(this.mainForm_Load);
			this.tlpGooglePlus.ResumeLayout(false);
			this.tlpGooglePlus.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudDeep)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudMaxPlus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxReshare)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxRes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxComment)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgRules)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.apip.ResumeLayout(false);
			this.apip.PerformLayout();
			this.tlpDates.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tcMain.ResumeLayout(false);
			this.tpGPlus.ResumeLayout(false);
			this.tpGAnalytics.ResumeLayout(false);
			this.tpLastfm.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tcGooglePlus.ResumeLayout(false);
			this.tpGPUsers.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btGen;
		private System.Windows.Forms.TableLayoutPanel tlpGooglePlus;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.Label profileId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.DataGridView dgRules;
		private System.Windows.Forms.NumericUpDown nudMaxComment;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.Panel apip;
		private System.Windows.Forms.TextBox apikey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList il16;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpGPlus;
		private System.Windows.Forms.TabPage tpGAnalytics;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tpLastfm;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.NumericUpDown nudMaxPlus;
		private System.Windows.Forms.NumericUpDown nudMaxReshare;
		private System.Windows.Forms.NumericUpDown nudMaxRes;
		private System.Windows.Forms.CheckBox cbDeep;
		private System.Windows.Forms.CheckBox cbFGraph;
		private System.Windows.Forms.NumericUpDown nudDeep;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cbDateRange;
		private System.Windows.Forms.TableLayoutPanel tlpDates;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.TabControl tcGooglePlus;
		private System.Windows.Forms.TabPage tpGPUsers;
		private System.Windows.Forms.TabPage tpGPWords;
	}
}

