using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabletcka
{
    public partial class FormActiveTest : Form
    {
        public FormActiveTest()
        {
            InitializeComponent();
        }

        private void FormActiveTest_Activated(object sender, EventArgs e)
        {
            MessageBox.Show("Hey hey");
        }

        protected override void OnActivated(EventArgs e)
        {
            MessageBox.Show("Hey hey"); 
        }
    }
}
