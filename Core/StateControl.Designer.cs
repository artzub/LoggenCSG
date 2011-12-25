namespace Core {
	partial class StateControl {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.Dock = System.Windows.Forms.DockStyle.Top;
			this.label.Location = new System.Drawing.Point(0, 0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(150, 13);
			this.label.TabIndex = 0;
			this.label.Text = "initialization...";
			// 
			// progressBar
			// 
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBar.Location = new System.Drawing.Point(0, 13);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(150, 23);
			this.progressBar.TabIndex = 1;
			// 
			// StateControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.label);
			this.Name = "StateControl";
			this.Size = new System.Drawing.Size(150, 36);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label;
		private System.Windows.Forms.ProgressBar progressBar;
	}
}
