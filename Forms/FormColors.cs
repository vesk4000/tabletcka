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

public class FormColor
{
	private Color color;

	public FormColor(Color color)
	{
		this.color = color;
	}

	public static implicit operator Color(FormColor formColor) => formColor.color;

	public static FormColor Red = new FormColor(Color.Red);
	public static FormColor Black = new FormColor(Color.Black);
}
