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
		
		public static void CreateForms ()
		{
			Form[] forms = new Form[10];

			for (int i = 0; i < 10; i ++)
			{
				forms[i] = new Form();
				Forms.Add(forms[i]);

				forms[i].Show();
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
			}
		}
	}
}
