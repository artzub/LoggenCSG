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
			this.nudMaxRes = new System.Windows.Forms.NumericUpDown();
			this.apip = new System.Windows.Forms.Panel();
			this.apikey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxRes)).BeginInit();
			this.apip.SuspendLayout();
			this.SuspendLayout();
			// 
			// btGen
			// 
			this.btGen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btGen.Location = new System.Drawing.Point(3, 70);
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
			this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tbID, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.profileId, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btGen, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.nudMaxRes, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.apip, 1, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 752);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tabControl2
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.tabControl2, 2);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(3, 104);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(655, 645);
			this.tabControl2.TabIndex = 6;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.dgRules);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(647, 619);
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
			this.dgRules.Size = new System.Drawing.Size(641, 613);
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
			this.tabPage3.Size = new System.Drawing.Size(647, 514);
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
			this.richTextBox1.Size = new System.Drawing.Size(627, 526);
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
			this.groupBox1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(655, 5);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Save to";
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
			// apip
			// 
			this.apip.Controls.Add(this.apikey);
			this.apip.Controls.Add(this.label1);
			this.apip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.apip.Location = new System.Drawing.Point(161, 70);
			this.apip.Name = "apip";
			this.apip.Padding = new System.Windows.Forms.Padding(3);
			this.apip.Size = new System.Drawing.Size(497, 28);
			this.apip.TabIndex = 7;
			// 
			// apikey
			// 
			this.apikey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.apikey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.apikey.Location = new System.Drawing.Point(47, 3);
			this.apikey.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.apikey.Name = "apikey";
			this.apikey.Size = new System.Drawing.Size(447, 23);
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
			((System.ComponentModel.ISupportInitialize)(this.nudMaxRes)).EndInit();
			this.apip.ResumeLayout(false);
			this.apip.PerformLayout();
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
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.DataGridView dgRules;
		private System.Windows.Forms.NumericUpDown nudMaxRes;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.Panel apip;
		private System.Windows.Forms.TextBox apikey;
		private System.Windows.Forms.Label label1;
	}
}

