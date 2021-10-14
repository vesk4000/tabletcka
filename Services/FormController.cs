using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabletcka.Forms;

namespace tabletcka.Services
{
	public static class FormController
	{
		public static int NumberRedForms = 0;
		public static List<Form> Forms = new List<Form> { Program.FirstForm };
		public static SettingsForm Settings;

		public static void RefreshForms(int numRedForms)
		{
			NumberRedForms = numRedForms;
			DeleteForms();
			CreateForms(numRedForms, FormColor.Red);
			if (Settings != null)
				Settings.BringToFront();
		}

		public static void DeleteForms()
		{
			while(Forms.Count > 0)
			{
				Forms[0].Close();
			}
		}

		public static void CreateForms()
		{
			FormActiveTest[] forms = new FormActiveTest[10];

			for (int i = 0; i < 10; i ++)
			{
				forms[i] = new FormActiveTest();
				Forms.Add(forms[i]);

				forms[i].Show();

				forms[i].WindowState = FormWindowState.Minimized;
			}
		}

		public static void CreateForms(int numberOfWindows)
		{
			FormActiveTest[] forms = new FormActiveTest[numberOfWindows];

			for (int i = 0; i < numberOfWindows; i++)
			{
				forms[i] = new FormActiveTest();
				Forms.Add(forms[i]);
				forms[i].Show();

				forms[i].WindowState = FormWindowState.Minimized;
			}
		}

		public static void CreateForms(int numForms, FormColor color)
		{
			for (int i = 0; i < numForms; i++)
			{
				MainForm form = new MainForm(color);
				Forms.Add(form);
				form.Show();
			}
		}

		public static void CheckToCloseApp()
		{
			if (Settings == null && Forms.Count == 0)
				Application.Exit();
		}
	}
}
