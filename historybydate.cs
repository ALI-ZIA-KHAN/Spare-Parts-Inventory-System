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
    public partial class historybydate : Form
    {
        public historybydate()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation n3 = new Navigation();
            this.Hide();
            n3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();


            if (String.IsNullOrEmpty(textBox4.Text))
            {
                cmd = new SqlCommand("select p.companyName , p.partName , p.modelName , p.price*s.tquantity as [total price] , s.tquantity from [dbo].[product_table] as p   join (select sum(sold_quantity) as [tquantity], Id from [dbo].[log_table] group by Id ) as s on p.productId = s.Id  where p.partName like '%" + textBox2.Text.ToString() + "%' and p.companyName like '%" + textBox1.Text.ToString() + "%' and p.modelName like '%" + textBox3.Text.ToString() + "%' and e.sold_date between @d1 and @d2 ;", cnn);
                cmd.Parameters.AddWithValue("@d2", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Value);
            }
            else
            {
                cmd = new SqlCommand("select p.companyName , p.partName , p.modelName , p.price*s.tquantity as [total price] , s.tquantity from [dbo].[product_table] as p   join (select sum(sold_quantity) as [tquantity], Id from [dbo].[log_table] group by Id ) as s on p.productId = s.Id  where p.partName like '%" + textBox2.Text.ToString() + "%' and p.companyName like '%" + textBox1.Text.ToString() + "%' and p.modelName like '%" + textBox3.Text.ToString() + "%' and e.invoice = @inv and p.sold_date between @d1 and @d2 ;", cnn);
                int invvalue = int.Parse(textBox4.Text);
                cmd.Parameters.AddWithValue("@inv", invvalue);
                cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@d2", dateTimePicker2.Value);
            }


            /*
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                cmd = new SqlCommand("select p.partName as [Part Name], p.companyName as [Company Name], p.modelName as [Model Name], p.stock_quantity as [Qty in Stock], p.price as Price, e. invoice as [Invoice no.], e.sold_price as [Sold Price], e.sold_quantity as [Sold Quantity], e.sold_date as Date, e.customer_name as [Customer Name], e.customer_address as [Customer Address] from product_table p, log_table e where (e.invoice between 1 and 99999 and p.productID = e.id) and(p.partName like '%" + textBox1.Text + "%' and p.companyName like '%" + textBox2.Text + "%' and p.modelName like '%" + textBox3.Text + "%') ;", cnn);
            }
            else
            {
                cmd = new SqlCommand("select p.partName as [Part Name], p.companyName as [Company Name], p.modelName as [Model Name], p.stock_quantity as [Qty in Stock], p.price as Price, e. invoice as [Invoice no.], e.sold_price as [Sold Price], e.sold_quantity as [Sold Quantity], e.sold_date as Date, e.customer_name as [Customer Name], e.customer_address as [Customer Address] from product_table p, log_table e where (e.invoice = @inv and p.productID = e.id) and(p.partName like '%" + textBox1.Text + "%' and p.companyName like '%" + textBox2.Text + "%' and p.modelName like '%" + textBox3.Text + "%') ;", cnn);
                int invvalue = int.Parse(textBox4.Text);
                cmd.Parameters.AddWithValue("@inv", invvalue);
            }
            */


            SqlDataAdapter sqd = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            sqd.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            cnn.Close();
        }
    }
}
