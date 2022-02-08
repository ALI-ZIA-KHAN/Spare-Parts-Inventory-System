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
    public partial class Search_Screen : Form
    {
        public Search_Screen()
        {
            InitializeComponent();
        }

        private void Search_Screen_Load(object sender, EventArgs e)
        {
            bu();
            
        }

        private void partnametextbox_TextChanged(object sender, EventArgs e)
        {
            bu();
        }
        public void bu() 
        {
            try
            {
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select productId as 'Product ID',companyName as 'Company Name', partName as 'Part Name', modelName as 'Model Name', stock_quantity as 'Quantity left in Stock', price as 'Price Rs.', rack as 'Rack Number'  from product_table where companyName like '%" + companytextbox.Text.ToString().ToLower() + "%' and partName like '%" + partnametextbox.Text.ToString().ToLower() + "%' and modelName like '%" + modelno.Text.ToString().ToLower() + "%'";
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
        private void companytextbox_TextChanged(object sender, EventArgs e)
        {
            bu();
        }

        private void modelno_TextChanged(object sender, EventArgs e)
        {
            bu();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            bu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Additems newForm = new Additems();
            newForm.Show();
            this.Hide();
        }

        private void addtocart_Click(object sender, EventArgs e)
        {
            CartForm f3 = new CartForm();
            f3.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DForm f2 = new NewFolder1.DForm();
            f2.textBox1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f2.textBox6.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f2.textBox3.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f2.textBox4.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f2.textBox5.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f2.textBox7.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            f2.Show();
            f2.textBox2.Focus();
            //this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Navigation newForm = new Navigation();
            newForm.Show();
            this.Hide();
        }

        private void restockbutton_Click(object sender, EventArgs e)
        {
            CartForm b2 = new CartForm();
            b2.Show();
            this.Hide();

        }

        private void movetobillbutton_Click(object sender, EventArgs e)
        {
            Billing b1 = new Billing();
            this.Hide();
            b1.Show();
        }
    }
}
