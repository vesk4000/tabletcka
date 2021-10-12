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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }
    }
}
