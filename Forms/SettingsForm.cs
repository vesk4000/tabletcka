using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabletcka.Forms
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private void ButtonRefresh_Click(object sender, EventArgs e)
		{
			//FormController.SetRedForms(int.Parse(LabelRed.Text));
		}
	}
}
