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
            string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            // string sqlquery = "Select * from [dbo].[product_table] ";
            string sqlquery = "Select * from [dbo].[temporary_table]";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            loaddata();
        }



        private void deletebutton_Click(object sender, EventArgs e)
        {
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int columnindex = dataGridView1.CurrentCell.ColumnIndex;

                string mainconn = ConfigurationManager.ConnectionStrings["myCONN"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "delete from temporary_table where PartName = '" + dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString() + "'";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                loaddata();
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
    }
}
