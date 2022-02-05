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
using TwenstyFirstJan.NewFolder1;

namespace TwenstyFirstJan
{
    public partial class updateinput : Form
    {
        public updateinput()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string connetionString;
                SqlConnection sqlconn;
                connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                sqlconn = new SqlConnection(connetionString);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand();


                // ye query sahi kernni hai
                cmd = new SqlCommand("update product_table set companyName = @companyName, partName = @partName, modelName = @modelName, stock_quantity = @stock_quantity , price = @price , rack = @rack ,maxStock = @maxstock where productId = @id;", sqlconn);
                cmd.Parameters.AddWithValue("@companyName", textBox1.Text);
                cmd.Parameters.AddWithValue("@partName", textBox2.Text);
                cmd.Parameters.AddWithValue("@modelName", textBox3.Text);
                cmd.Parameters.AddWithValue("@stock_quantity", textBox4.Text);
                cmd.Parameters.AddWithValue("@price", textBox5.Text);
                cmd.Parameters.AddWithValue("@rack", textBox6.Text);
                cmd.Parameters.AddWithValue("@maxStock", textBox7.Text);
                cmd.Parameters.AddWithValue("@id", textBox8.Text);


                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data UPDATED successfully!");
                }
                //SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                

                update r = new update();
                r.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }

        private void updateinput_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
