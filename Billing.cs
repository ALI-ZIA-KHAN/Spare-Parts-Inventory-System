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

        private void invoicenum()
        {
            try
            {
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn1 = new SqlConnection(mainconn);
                string sqlquery1 = "select max(invoice)+1 from log_table;";
                sqlconn1.Open();
                SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn1);
                object result = sqlcomm1.ExecuteScalar();
                int value = (int)result;
                textBox2.Text = value.ToString();
                sqlconn1.Close();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }

        
        private void data_display()
        {
            try
            {
                invoicenum();
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select p.companyName as 'Company' , p.partName as 'Part Name', p.modelName as 'Model Name' , t.price as 'Price' , t.quantity as 'Quantity' from [dbo].[product_table] p , [dbo].[temporary_table] t where p.productId=t.Id; ";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                textBox5.Text = "0334-3669215";

                textBox6.Text = (from DataGridViewRow row in dataGridView1.Rows where row.Cells[3].FormattedValue.ToString() != string.Empty select Convert.ToInt32(row.Cells[3].FormattedValue)).Sum().ToString();
                sqlconn.Close();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox2.ReadOnly = true;
            textBox5.Enabled = false;
            textBox5.ReadOnly = true;

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;
            
            data_display();
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
            try
            {
                SqlCommand cmd;
                SqlConnection con;
                con = new SqlConnection(@"Server=tcp:masamual.database.windows.net,1433;Initial Catalog=alidb;Persist Security Info=False;User ID=ali;Password=Adminaccount@101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                con.Open();
                cmd = new SqlCommand("delete temporary_table;", con);
                var i = cmd.ExecuteNonQuery();
                con.Close();
                data_display();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
            //dataGridView1.DataSource = null;
        }

        private void move_to_log()
        {
            try
            {
                //transfer data from temp to log
                SqlCommand cmd;
                SqlConnection con;
                con = new SqlConnection(@"Server=tcp:masamual.database.windows.net,1433;Initial Catalog=alidb;Persist Security Info=False;User ID=ali;Password=Adminaccount@101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                con.Open();
                cmd = new SqlCommand("UPDATE product_table  SET  stock_quantity = stock_quantity - e.quantity FROM   temporary_table as e WHERE  e.Id = product_table.productId; insert into log_table(Id,sold_quantity,sold_price,customer_name,customer_address,invoice,sold_date)  select Id, quantity,price,@cust,@addr,@inv, @date from temporary_table; delete temporary_table;", con);
                cmd.Parameters.AddWithValue("@cust", textBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@addr", textBox3.Text.ToString());
                int invval = int.Parse(textBox2.Text);
                cmd.Parameters.AddWithValue("@inv", invval);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date.ToString());

                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data is succcessfully saved");

                }
                con.Close();

                Search_Screen b2 = new Search_Screen();
                b2.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Navigation n2 = new Navigation();
            n2.Show();
            this.Hide();
        }
        Bitmap bitmap;
        private void button3_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            
            int height = dataGridView1.Height;
            dataGridView1.Height =37+(dataGridView1.RowCount+2) * dataGridView1.RowTemplate.Height * 4;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0,150 , dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;

            move_to_log();
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
      //      e.Graphics.DrawString(DashLabel.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 280));
       //    e.Graphics.DrawString(DashLabel.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 600));
            e.Graphics.DrawString("Total Amount:" + textBox6.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 1000));
      //      e.Graphics.DrawString(Signature.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 630));
       //     e.Graphics.DrawString(DashLabel.Text, new Font("Arial", 12), Brushes.Black, new Point(25, 650));
        }

        private void DashLabel_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            move_to_log();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
