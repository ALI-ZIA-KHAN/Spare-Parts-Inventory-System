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

namespace TwenstyFirstJan
{
    public partial class history1 : Form
    {
        //SqlCommand cmd;
        //SqlConnection con;
        //SqlDataAdapter da;
        public history1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void hsbu()
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                cnn = new SqlConnection(connetionString);

                cnn.Open();
                SqlCommand cmd = new SqlCommand();

                if (String.IsNullOrEmpty(textBox4.Text))
                {
                    cmd = new SqlCommand("select p.partName as [Part Name], p.companyName as [Company Name], p.modelName as [Model Name], p.stock_quantity as [Qty in Stock], p.price as Price, e. invoice as [Invoice no.], e.sold_price as [Sold Price], e.sold_quantity as [Sold Quantity], e.sold_date as Date, e.customer_name as [Customer Name], e.customer_address as [Customer Address] from product_table p, log_table e where ( p.productID = e.id) and(p.partName like '%" + textBox1.Text + "%' and p.companyName like '%" + textBox2.Text + "%' and p.modelName like '%" + textBox3.Text + "%') ;", cnn);
                }
                else
                {
                    cmd = new SqlCommand("select p.partName as [Part Name], p.companyName as [Company Name], p.modelName as [Model Name], p.stock_quantity as [Qty in Stock], p.price as Price, e. invoice as [Invoice no.], e.sold_price as [Sold Price], e.sold_quantity as [Sold Quantity], e.sold_date as Date, e.customer_name as [Customer Name], e.customer_address as [Customer Address] from product_table p, log_table e where (e.invoice = @inv and p.productID = e.id) and(p.partName like '%" + textBox1.Text + "%' and p.companyName like '%" + textBox2.Text + "%' and p.modelName like '%" + textBox3.Text + "%') ;", cnn);
                    int invvalue = int.Parse(textBox4.Text);
                    cmd.Parameters.AddWithValue("@inv", invvalue);
                }

                SqlDataAdapter sqd = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sqd.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hsbu();

            /*con = new SqlConnection(@"Server=tcp:masamual.database.windows.net,1433;Initial Catalog=alidb;Persist Security Info=False;User ID=ali;Password=Adminaccount@101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            SqlCommand cmd = new SqlCommand("select * from product_table where companyName like '%@c%' and partName like '%@p%' and modelName like '%@m%' ;", con);
            //cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@p", textBox4.Text.ToString());
            cmd.Parameters.AddWithValue("@c", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@m", textBox3.Text.ToString());
            //cmd.Parameters.AddWithValue("@i", textBox2.Text);

            con.Open();
            SqlDataAdapter sdr2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
*/
        }

        private void history1_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            hsbu();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation newForm = new Navigation();

            newForm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
