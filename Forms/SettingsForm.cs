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
			numericUpDownBlack.Value = FormController.NumberBlackForms;
		}

		private void ButtonRefresh_Click(object sender, EventArgs e)
		{
			FormController.RefreshForms((int)numericUpDownRed.Value, (int)numericUpDownBlack.Value);
		}

		private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			FormController.Settings = null;
			FormController.CheckToCloseApp();
		}

		private void numericUpDownRed_ValueChanged(object sender, EventArgs e)
		{
			/*if(checkBoxKeepRedBlackRatio.Checked)
			{
				numericUpDownBlack.Value = ((float)numericUpDownBlack / numericUpDownRed.Value) * 
			}*/
		}
	}
}
