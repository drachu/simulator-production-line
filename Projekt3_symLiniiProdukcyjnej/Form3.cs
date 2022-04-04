using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3_symLiniiProdukcyjnej
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            labelCheckTime.Text = remainingTime.ToString();
            timer2.Start();
        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                FormSimulator.check = false;
                timer2.Stop();
                remainingTime = 10;
                this.Hide();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            labelCheckTime.Text = remainingTime.ToString()+"s";
            if (remainingTime == 0)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
