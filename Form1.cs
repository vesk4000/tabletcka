﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabletcka.Services;

namespace tabletcka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormController.CreateForms();

            Form currentForm = Form.ActiveForm;

            this.Activate();

            Task.Delay(2000);

            if (Form.ActiveForm == FormActiveTest.ActiveForm)
            {
                MessageBox.Show("Hey");
            }
        }
    }
}
