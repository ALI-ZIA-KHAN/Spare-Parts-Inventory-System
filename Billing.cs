using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;

namespace TwenstyFirstJan
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Billing_Load(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "Select * from [dbo].[temporary_table] ";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            

               
            // method 1
            textBox6.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToInt32(row.Cells[3].FormattedValue)).Sum().ToString();



            sqlconn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    dataGridView1.Rows.Remove(row);
                }
                catch (Exception) {

                    MessageBox.Show("Error in Deletion");
                }
            }

            */

            dataGridView1.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation n2 = new Navigation();
            this.Hide();
            n2.Show();
        }
        Bitmap bitmap;
        private void button3_Click(object sender, EventArgs e)
        {
           
            
            printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0,150 , dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height; 
           
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            
            e.Graphics.DrawImage(bitmap,25,190 );

            Bitmap bmp = Properties.Resources.Capture;
            Image newImage= bmp;
            e.Graphics.DrawImage(newImage, 25, 25, newImage.Width, newImage.Height);
            e.Graphics.DrawString("Customer Name:" + textBox1.Text, new Font ("Arial", 12 ,FontStyle.Regular),Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Date:" + DateTime. Now, new Font ("Arial", 12), Brushes.Black, new Point (25, 200));
            e.Graphics.DrawString("Address:" + textBox3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Invoice No:" + textBox2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("Contact No:" + textBox5.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString(DashLabel.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 280));
            e.Graphics.DrawString(DashLabel.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 600));
            e.Graphics.DrawString("Total Amount:" + textBox6.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 630));
            e.Graphics.DrawString(Signature.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 630));
            e.Graphics.DrawString(DashLabel.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 650));
        }

        private void DashLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
