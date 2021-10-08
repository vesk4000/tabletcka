using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabletcka.Services
{
	public static class FormController
	{
		public static void CreateForms ()
		{
			Form[] forms = new Form[10];

			for (int i = 0; i < 10; i ++)
			{
				forms[i] = new Form();

				forms[i].Show();
			}
		}

	}
}
