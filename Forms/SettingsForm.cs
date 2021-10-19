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

		private float ratio = -1;
		bool dontUpdate = false;

		private void numericUpDownRed_ValueChanged(object sender, EventArgs e)
		{

			if(dontUpdate)
			{
				dontUpdate = false;
				return;
			}
			setNumericUpDownNumbers((int)numericUpDownRed.Value);
			dontUpdate = false;
		}

		private void numericUpDownBlack_ValueChanged(object sender, EventArgs e)
		{
			if (dontUpdate)
			{
				dontUpdate = false;
				return;
			}
			setNumericUpDownNumbers(-1, (int)numericUpDownBlack.Value);
			dontUpdate = false;
		}

		private void setNumericUpDownNumbers(int numRed = -1, int numBlack = -1)
		{
			if (!checkBoxKeepRedBlackRatio.Checked)
				return;
			if(numRed == -1)
			{
				dontUpdate = true;
				numericUpDownRed.Value = (int)(ratio * numBlack);
			}
			else if(numBlack == -1)
			{
				dontUpdate = true;
				numericUpDownBlack.Value = (int)((1 / ratio) * numRed);
			}
		}

		private void checkBoxKeepRedBlackRatio_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxKeepRedBlackRatio.Checked)
			{
				if (numericUpDownRed.Value == 0 && numericUpDownBlack.Value == 0)
					ratio = 1;
				else if (numericUpDownRed.Value != 0 && numericUpDownBlack.Value == 0)
					ratio = 1;
				else if (numericUpDownRed.Value == 0 && numericUpDownBlack.Value != 0)
					ratio = 1;
				else
					ratio = (float)(numericUpDownRed.Value / numericUpDownBlack.Value);
			}
		}
	}
}
