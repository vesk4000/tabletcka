using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabletcka.Services;

namespace tabletcka.Forms
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			numericUpDownRed.Value = FormController.NumberRedForms;
		}

		private void ButtonRefresh_Click(object sender, EventArgs e)
		{
			//FormController.SetRedForms(int.Parse(LabelRed.Text));
			FormController.RefreshForms((int)numericUpDownRed.Value);
		}

		private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			FormController.Settings = null;
			FormController.CheckToCloseApp();
		}
	}
}
