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
        public DForm()
        {
            InitializeComponent();
        }

        private void tempbutton_Click(object sender, EventArgs e)
        {
           // int priceval = int.Parse(textBox1.Text);

            string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            // string sqlquery = "Select * from [dbo].[product_table] ";
            string sqlquery = "insert into temporary_table(CompanyName, PartName, input_quantity, input_price)values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox2.Text + "', '"+textBox1.Text+"')";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            MessageBox.Show("Item Added to Cart!");
            this.Close();
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
    }
}
