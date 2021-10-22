using New_Desktop;
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

using System.Diagnostics;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Web.UI.WebControls;

namespace tabletcka.Forms
{
	public partial class SettingsForm : Form
	{
		WindowDesktop _d = null;
		IntPtr _ptrDefaultDesktopThread;
		WindowDesktop _wdDefault = new WindowDesktop("Default");
		ListBox<string> lstDesktops;


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
				numericUpDownBlack.Value = ratio == 0 ? 0 : (int)((1 / ratio) * numRed);
			}
		}

		private void checkBoxKeepRedBlackRatio_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxKeepRedBlackRatio.Checked)
			{
				if (numericUpDownRed.Value == 0 && numericUpDownBlack.Value == 0)
					ratio = 1;
				else if (numericUpDownRed.Value != 0 && numericUpDownBlack.Value == 0)
					ratio = 0;
				else if (numericUpDownRed.Value == 0 && numericUpDownBlack.Value != 0)
					ratio = 0;
				else
					ratio = (float)(numericUpDownRed.Value / numericUpDownBlack.Value);
			}
		}

		private void NewDesktop_Click(object sender, EventArgs e)
		{
			try
			{
				//make a new desktop 
				_d = new WindowDesktop("myDesktop");

				//get all the desktops for this Window Station
				StringCollection scDesktops = WindowDesktop.GetDesktops();
				if (scDesktops != null && scDesktops.Count > 0)
				{
					for (int i = 0; i < scDesktops.Count; i++)
					{
						lstDesktops.Items.Add(scDesktops[i]);

						//get all the windows for the specified Desktop
						StringCollection scWindows = WindowDesktop.GetDesktopWindows(_d);
						if (scWindows != null && scWindows.Count > 0)
						{
							for (int j = 0; j < scWindows.Count; j++)
							{
								lstWindows.Items.Add(scWindows[j]);
							}
						}
					}
				}
			}
		}
    }
}
