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
using System.Text.RegularExpressions;
namespace TwenstyFirstJan
{
    public partial class Additems : Form
    {

        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public Additems()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Additems_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            con = new SqlConnection(@"Server=tcp:masamual.database.windows.net,1433;Initial Catalog=alidb;Persist Security Info=False;User ID=ali;Password=Adminaccount@101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            cmd = new SqlCommand("INSERT INTO product_table(companyName,partName,modelName,stock_quantity,price,rack,maxStock) VALUES (@companyName,@partName,@modelName,@stock_quantity,@price,@rack,@maxStock)", con);
            cmd.Parameters.Add("@companyName", textBox1.Text);
            cmd.Parameters.Add("@partName", textBox2.Text);
            cmd.Parameters.Add("@modelName", textBox3.Text);
            cmd.Parameters.Add("@stock_quantity", textBox4.Text);
            cmd.Parameters.Add("@price", textBox5.Text);
            cmd.Parameters.Add("@rack", textBox6.Text);
            cmd.Parameters.Add("@maxStock", textBox7.Text);

            //     cmd.Parameters.Add("@modelName", comboBox1.SelectedItem.ToString());


            if (textBox1.Text=="" || textBox2.Text== "" || textBox3.Text=="" || textBox4.Text=="" ||
                textBox5.Text=="" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Fill all the fields");
            }else if ((!Regex.Match(textBox1.Text, "^[a-zA-Z]*$").Success) || (!Regex.Match(textBox2.Text, "^[a-zA-Z]*$").Success) ||
               (!Regex.Match(textBox4.Text, "^[0-9]*$").Success) || (!Regex.Match(textBox5.Text, "^[0-9]*$").Success))
            {

                MessageBox.Show("Wrong Format Of Data Entered");

            }
            else
            {
                var i= cmd.ExecuteNonQuery();
                if(i != 0)
                {
                    MessageBox.Show("Data is succcessfully saved");
                }
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Billing newForm = new Billing();
            this.Hide();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Navigation newForm = new Navigation();

            newForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //








        //  if (i != 0)
        //   {
        //         MessageBox.Show(i + "Data Saved");
        //    }//









    }
}
