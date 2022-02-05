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
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
        }

        public void loaddata()
        {
            try
            {
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select p.CompanyName as 'company', p.partName as 'part', p.modelName as 'model', t.price as 'Price', t.quantity as 'Quantity' from product_table p , temporary_table t where p.productId=t.Id; ";
                //string sqlquery = "Select * from [dbo].[temporary_table]";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
           
            this.WindowState = FormWindowState.Maximized;
            loaddata();
        }



        private void deletebutton_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    //int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                    //delete temporary_table from temporary_table e where e.Id = (select  productId p from product_table p where p.companyName like '" + dataGridView1.Rows[rowindex].Cells[0].Value.ToString() + "' and p.partName like '" + dataGridView1.Rows[rowindex].Cells[1].Value.ToString() + "' and p.modelName like '" + dataGridView1.Rows[rowindex].Cells[2].Value.ToString() + "' ) ;
                    //delete from temporary_table where CompanyName = '" + dataGridView1.Rows[rowindex].Cells[0].Value.ToString() + "' and PartName = '" + dataGridView1.Rows[rowindex].Cells[1].Value.ToString() + "' and modelName = '" + dataGridView1.Rows[rowindex].Cells[2].Value.ToString() + "'  
                    //delete from temporary_table e where e.Id = (select  productId from [dbo].[product_table] p where p.companyName like 'crown' and p.partName like 'airfilter' and p.modelName like 'cd70f' ) ;

                    string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery = "delete temporary_table from temporary_table e where e.Id = (select  productId p from product_table p where p.companyName like '" + dataGridView1.Rows[rowindex].Cells[0].Value.ToString() + "' and p.partName like '" + dataGridView1.Rows[rowindex].Cells[1].Value.ToString() + "' and p.modelName like '" + dataGridView1.Rows[rowindex].Cells[2].Value.ToString() + "' ) ;";
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                    SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    dataGridView1.DataSource = dt;
                    loaddata();
                    sqlconn.Close();
                }
                catch
                {
                    MessageBox.Show("Retry");
                }
            }
        }

        private void movetobillbutton_Click(object sender, EventArgs e)
        {
            Billing b1 = new Billing();
            this.Hide();
            b1.Show();
        }

        private void searchscreenbutton_Click(object sender, EventArgs e)
        {
            Search_Screen s1 = new Search_Screen();
            this.Hide();
            s1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation n1 = new Navigation();
            this.Hide();
            n1.Show();
        }

        /*/private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //transfer data from temp to log
                SqlCommand cmd;
                SqlConnection con;
                con = new SqlConnection(@"Server=tcp:masamual.database.windows.net,1433;Initial Catalog=alidb;Persist Security Info=False;User ID=ali;Password=Adminaccount@101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                con.Open();
                cmd = new SqlCommand("UPDATE product_table  SET  stock_quantity = stock_quantity - e.quantity FROM   temporary_table as e WHERE  e.Id = product_table.productId; insert into log_table(Id,sold_quantity,sold_price,customer_name,customer_address,invoice,sold_date)  select Id, quantity,price,@cust,@addr,@inv, @date from temporary_table; delete temporary_table;", con);
                cmd.Parameters.AddWithValue("@cust", "");
                cmd.Parameters.AddWithValue("@addr", "");
                int invval = int.Parse(textBox2.Text);
                cmd.Parameters.AddWithValue("@inv", invval);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date.ToString());

                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data is succcessfully saved");

                }
                con.Close();

                Billing b2 = new Billing();
                b2.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }*/
    }
}
