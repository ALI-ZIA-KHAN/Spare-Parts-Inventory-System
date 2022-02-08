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

        private void chkqt()
        {/*
            try
            {
                
                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn1 = new SqlConnection(mainconn);
                string sqlquery1 = "select stock_quantity from product_table where productId = @id ;";

                sqlconn1.Open();
                SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn1);
                sqlcomm1.Parameters.AddWithValue("@id", textBox5.Text);
                object result = sqlcomm1.ExecuteScalar();
                int value = (int)result;
                int stock = value;
                sqlconn1.Close();
                //return stock;
                int stock = int.Parse(textBox6.Text);
                if (qt > stock)
                {
                    MessageBox.Show("Not enough in stock \n " + stock.ToString());

                }
                else
                {
                    string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery = "insert into temporary_table(Id, quantity, price)values('" + textBox5.Text + "',@qt, '" + textBox1.Text + "')";

                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                    sqlcomm.Parameters.AddWithValue("@qt", qt);
                    //var i = 
                    sqlcomm.ExecuteNonQuery();
                    //if (i != 0)
                    //{
                    //    MessageBox.Show("Data is succcessfully saved");

                    //}

                    //SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                    //DataTable dt = new DataTable();
                    //sdr.Fill(dt);
                    //MessageBox.Show("Item Added to Cart!");
<<<<<<< HEAD
                    //this.Close();
=======
                    this.Close();
>>>>>>> 143d6a6c62a885c4ebeb5436f9ef04da2733dc83
                    this.Hide();
                }
                //    nechay wala part close() sey uper tyr kerna hai
                //Search_Screen s2 = new Search_Screen();
                //this.Hide();
                //s2.Show();
            }
            catch
            {
                MessageBox.Show("Retry");
            }*/
        } 
        private void tempbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                qt = 1;
            }
            else
            {
                qt = int.Parse(textBox2.Text);
            }

            //chkqt();

            try
            {
                
                int stock = int.Parse(textBox6.Text);
                if (qt > stock)
                {
                    MessageBox.Show("Not enough in stock \n  Left: " + stock.ToString());

                }
                else
                {
                    // this nechay
                    this.SendToBack();
                    string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery = "insert into temporary_table(Id, quantity, price)values('" + textBox5.Text + "',@qt, '" + textBox1.Text + "')";

                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                    sqlcomm.Parameters.AddWithValue("@qt", qt);
                    sqlcomm.ExecuteNonQuery();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            
            //Search_Screen s2 = new Search_Screen();
            //s2.Show();
            this.Hide();
            
        }

        private void DForm_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
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
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
