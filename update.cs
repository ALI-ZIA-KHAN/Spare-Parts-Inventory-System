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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void update_Load(object sender, EventArgs e)
        {
            bu();
        }

        public void bu()
        {
            try
            {
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select productId as 'Product ID',companyName as 'Company Name', partName as 'Part Name', modelName as 'Model Name', stock_quantity as 'Quantity left in Stock', price as 'Price Rs.', rack as 'Rack Number' ,maxStock as 'Max Stock' from product_table where companyName like '%" + companytextbox.Text.ToString().ToLower() + "%' and partName like '%" + partnametextbox.Text.ToString().ToLower() + "%' and modelName like '%" + modelno.Text.ToString().ToLower() + "%'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            bu();
        }

        private void upd()
        {

            updateinput f2 = new updateinput();
            f2.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f2.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f2.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f2.textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f2.textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f2.textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            f2.textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            f2.textBox8.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();


            f2.Show();
            this.Hide();
        }


        private void restockbutton_Click(object sender, EventArgs e)
        {
            //update
            upd();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                //int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                //delete temporary_table from temporary_table e where e.Id = (select  productId p from product_table p where p.companyName like '" + dataGridView1.Rows[rowindex].Cells[0].Value.ToString() + "' and p.partName like '" + dataGridView1.Rows[rowindex].Cells[1].Value.ToString() + "' and p.modelName like '" + dataGridView1.Rows[rowindex].Cells[2].Value.ToString() + "' ) ;
                //delete from temporary_table where CompanyName = '" + dataGridView1.Rows[rowindex].Cells[0].Value.ToString() + "' and PartName = '" + dataGridView1.Rows[rowindex].Cells[1].Value.ToString() + "' and modelName = '" + dataGridView1.Rows[rowindex].Cells[2].Value.ToString() + "'  
                //delete from temporary_table e where e.Id = (select  productId from [dbo].[product_table] p where p.companyName like 'crown' and p.partName like 'airfilter' and p.modelName like 'cd70f' ) ;

                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "delete from product_table where productId in (" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + ")  ;";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                //SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);

                var i = sqlcomm.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data is succcessfully DELETED");
                }
                //DataTable dt = new DataTable();
                //sdr.Fill(dt);
                //dataGridView1.DataSource = dt;
                //loaddata();
                bu();
                sqlconn.Close();
            }
            catch
            {
                // FK banai hui log table main tou comflict aa raha kabhi.
                MessageBox.Show("Product already sold, cannot be deleted!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation newForm = new Navigation();
            newForm.Show();
            this.Hide();
        }
    }
}
