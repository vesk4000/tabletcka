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

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form Settings = new SettingsForm();
			Settings.Show();
			Application.Run();
		}
	}
}
