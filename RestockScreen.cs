﻿using System;
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

            AddHeaderCheckBox();
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);


            string connetionString;
            SqlConnection sqlconn;
            connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
            sqlconn = new SqlConnection(connetionString);
            string sqlquery = "Select productID as 'Product ID',companyName as 'Company Name', partName as 'Part Name', modelName as 'Model Name', stock_quantity as 'Quantity left in Stock' from [dbo].[product_table] ";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
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
            string connetionString;
            SqlConnection sqlconn;
            connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
            sqlconn = new SqlConnection(connetionString);
            string sqlquery = "select productId, companyName as 'Company Name', partName as 'Part Name', modelName as 'Model Name', stock_quantity as 'Quantity left in Stock' from product_table where companyName like '%" + companytextbox.Text.ToString().ToLower() + "%' and partName like '%" + partnametextbox.Text.ToString().ToLower() + "%' and modelName like '%" + modelno.Text.ToString().ToLower() + "%'";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery,sqlconn);

            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
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
            string connetionString;
            SqlConnection sqlconn;
            connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
            sqlconn = new SqlConnection(connetionString);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand();

            string str = "(";
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chk"].Value) == true)
                {
                    str += row.Cells[1].Value.ToString() + ",";
                    //rows_with_checked_column.Add(row);
                }
            }
            str += "0)";

            cmd = new SqlCommand("update product_table set stock_quantity = maxStock where productId in " + str + ";", sqlconn);

            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();

            RestockScreen r = new RestockScreen();
            r.Show();
            this.Hide();
        }


        /*for (int i=0; i<=dataGridView1.RowCount - 1; i++)
        {
            if(Convert.ToBoolean(dataGridView1.Rows[i].Cells["chk"].Value)== true)
            {

            }
        }*/
    }

}

