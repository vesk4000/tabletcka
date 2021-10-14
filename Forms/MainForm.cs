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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public MainForm(FormColor color)
		{
			InitializeComponent();
			BackColor = color;
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (FormController.Settings == null)
			{
				SettingsForm settings = new SettingsForm();
				settings.Show();
				FormController.Settings = settings;
			}
			else
				FormController.Settings.BringToFront();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			FormController.Forms.Remove(this);
			FormController.CheckToCloseApp();
		}
	}
}
