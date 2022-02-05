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
using System.Drawing.Printing;

namespace TwenstyFirstJan
{
    public partial class RestockScreen : Form
    {
        public RestockScreen()
        {
            InitializeComponent();
        }

        private void RestockScreen_Load(object sender, EventArgs e)
        {
            bu();
            AddHeaderCheckBox();
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            /*
            try
            {
                AddHeaderCheckBox();
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                string connetionString;
                SqlConnection sqlconn;
                connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                sqlconn = new SqlConnection(connetionString);
                string sqlquery = "Select productID as 'Product ID',companyName as 'Company Name', partName as 'Part Name', modelName as 'Model Name', stock_quantity as 'Quantity left in Stock', maxStock as 'Max Stock' from [dbo].[product_table] ";
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

            */
        }

        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();
            HeaderCheckBox.Size = new Size(15, 15);
            //Add the CheckBox into the DataGridview
            this.dataGridView1.Controls.Add(HeaderCheckBox);
        }


        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chk"]).Value = HCheckBox.Checked;
            dataGridView1.RefreshEdit();
            IsHeaderCheckBoxClicked = false;
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }



        public void bu()
        {
            try
            {
                string connetionString;
                SqlConnection sqlconn;
                connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                sqlconn = new SqlConnection(connetionString);
                string sqlquery = "select productId as 'Id', companyName as 'Company Name', partName as 'Part Name', modelName as 'Model Name', stock_quantity as 'Quantity left in Stock' , maxStock - stock_quantity as 'Ordered Amount' , maxStock as 'Max Stock' from product_table where companyName like '%" + companytextbox.Text.ToString().ToLower() + "%' and partName like '%" + partnametextbox.Text.ToString().ToLower() + "%' and modelName like '%" + modelno.Text.ToString().ToLower() + "%'";
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

        private void partnametextbox_TextChanged(object sender, EventArgs e)
        {
            bu();
        }

        private void modelno_TextChanged(object sender, EventArgs e)
        {
            bu();
        }

        private void rsbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString;
                SqlConnection sqlconn;
                connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                sqlconn = new SqlConnection(connetionString);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand();


                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (Convert.ToBoolean(row.Cells["chk"].Value) == true)//(bool)(row.Cells["chk"]).Value || (CheckState)row.Cells["chk"].Value == CheckState.Checked)
                    {
                        // Do something
                        cmd = new SqlCommand("update product_table set stock_quantity = stock_quantity + @offset where productId = @prodid1;", sqlconn);

                        cmd.Parameters.AddWithValue("@prodid1", row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@offset", row.Cells[6].Value.ToString());
                        //var j = 
                        cmd.ExecuteNonQuery();
                        /*if (j == 0)
                        {
                            MessageBox.Show("some item can not be restocked \n {0}", dataGridView1.CurrentRow.Cells[2].Value.ToString());

                        }*/
                    }
                }
                MessageBox.Show("Restocked Successfully");


                /*
                string str = "(";
                //List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chk"].Value) == true)
                    {
                        //str += row.Cells[1].Value.ToString() + ",";
                        //rows_with_checked_column.Add(row);
                        cmd.Parameters.AddWithValue("@id", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@offset", row.Cells[5].Value.ToString());
                        var i = cmd.ExecuteNonQuery();
                        if (i == 0)
                        {
                            MessageBox.Show("some item can not be restocked \n {0}", dataGridView1.CurrentRow.Cells[2].Value.ToString());

                        }
                        
                    }
                }
                str += "0)";
                */
                //cmd = new SqlCommand("update product_table set stock_quantity = maxStock where productId in " + str + ";", sqlconn);

                //SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //sdr.Fill(dt);
                //dataGridView1.DataSource = dt;
                sqlconn.Close();

                RestockScreen r = new RestockScreen();
                r.Show();
                this.Hide();
            }
            catch
            {
                //MessageBox.Show("some item can not be restocked \n {0}", dataGridView1.CurrentRow.Cells[3].Value.ToString());

                MessageBox.Show("Retry");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation newForm = new Navigation();
            newForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }

}

