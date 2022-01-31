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

namespace TwenstyFirstJan.NewFolder1
{
    public partial class DForm : Form
    {
        int qt = 1;
        public DForm()
        {
            InitializeComponent();
        }
        private int chkqt()
        {

            string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
            SqlConnection sqlconn1 = new SqlConnection(mainconn);
            string sqlquery1 = "select stock_quantity from product_table where productId = @id ;";
            
            sqlconn1.Open();
            SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn1);
            sqlcomm1.Parameters.AddWithValue("@id",textBox5.Text);
            object result = sqlcomm1.ExecuteScalar();
            int value = (int)result;
            int stock = value;
            return stock;
        }
        private void tempbutton_Click(object sender, EventArgs e)
        {
            qt = int.Parse(textBox2.Text);
            //public void checkquantity(){   }
            int stock=chkqt();
            // int priceval = int.Parse(textBox1.Text);
            if (qt > stock)
            {
                MessageBox.Show("Not enough in stock \n " + stock.ToString());

            }
            else
            {
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                // string sqlquery = "Select * from [dbo].[product_table] ";

                string sqlquery = "insert into temporary_table(Id, quantity, price)values('" + textBox5.Text + "',@qt, '" + textBox1.Text + "')";

                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("@qt", qt);
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                MessageBox.Show("Item Added to Cart!");
                this.Close();
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            Search_Screen s2 = new Search_Screen();
            s2.Show();
        }

        private void DForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation newForm = new Navigation();

            newForm.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
