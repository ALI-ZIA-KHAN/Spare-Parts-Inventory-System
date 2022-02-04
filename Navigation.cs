using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwenstyFirstJan
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search_Screen s1 = new Search_Screen();
            this.Hide();
            s1.Show();

                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            history1 h1 = new history1();
            this.Hide();
            h1.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            historybydate h2 = new historybydate();
            this.Hide();
            h2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Additems a1 = new Additems();
            this.Hide();
            a1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Billing b1 = new Billing();
            this.Hide();
            b1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            update l1 = new update();
            this.Hide();
            l1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RestockScreen r1 = new RestockScreen();
            this.Hide();
            r1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 fo1 = new Form1();
            this.Hide();
            fo1.Show();
        }

        private void Navigation_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].WindowState = FormWindowState.Maximized;
            }

        }
    }
}
