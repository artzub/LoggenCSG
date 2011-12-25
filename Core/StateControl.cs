using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core {
	public partial class StateControl : UserControl, IStater {
		public StateControl() {
			InitializeComponent();
		}

		public int Position {
			get {
				return progressBar.Value;
			}
			set {
				if (value > MaxPosition)
					value = MaxPosition;
				if (value < progressBar.Minimum)
					value = progressBar.Minimum;
				progressBar.Value = value;
				Application.DoEvents();
			}
		}

		public int MaxPosition {
			get {
				return progressBar.Maximum;
			}
			set {
				if (value < progressBar.Minimum)
					value = 100;
				progressBar.Maximum = value;
				Application.DoEvents();
			}
		}

		public string StateLabel {
			get {
				return label.Text;
			}
			set {
				label.Text = value;
				Application.DoEvents();
			}
		}

		public void Inc(int value = 1) {
			Position += value;
			Application.DoEvents();
		}

		public void MovePosition(int newPosition) {
			Position = newPosition;
			Application.DoEvents();
		}

		public void SetState(string description, int position = 0, bool incPosition = false) {
			StateLabel = string.IsNullOrWhiteSpace(description) ? StateLabel : description;
			if (incPosition)
				Inc(position);
			else
				Position = position;
		}

		public void InitState(string description = default(string), int maxPosition = 100, int startPosition = 0) {
			StateLabel = string.IsNullOrWhiteSpace(description) ? "Initialization..." : description;
			Position = startPosition;
			MaxPosition = maxPosition;
		}
	}
}
