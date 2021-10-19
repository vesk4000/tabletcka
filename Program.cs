using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabletcka.Forms;
using tabletcka.Services;

namespace tabletcka
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		public static SettingsForm Settings;

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Settings = new SettingsForm();
			FormController.Settings = Settings;
			Settings.Show();
			Application.Run();
		}
	}
}
