using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWindowsPayoda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Establishing a connection
            SqlConnection conn = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS;database=sampazure;integrated security=true;");

            //Open the connection
            conn.Open();
            //Prepared the command
            SqlCommand cmd = new SqlCommand("select * from Product", conn);

            //Execute the command
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            //Establishing a connection
            SqlConnection conn = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS;database=sampazure;integrated security=true;");

            //Open the connection
            conn.Open();

            int id = Convert.ToInt32(txtId.Text);
            string name = txtName.Text;
            decimal Price = Convert.ToDecimal(txtPrice.Text);
            //Prepared the command
            SqlCommand cmd = new SqlCommand("insert into Product values(@id,@name,@price)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", Price);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Inserted");
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            //Establishing a connection
            SqlConnection conn = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS;database=sampazure;integrated security=true;");

            //Open the connection
            conn.Open();
            //Prepared the command
            SqlCommand cmd = new SqlCommand("select * from Product", conn);

            //Execute the command
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //Establishing a connection
            SqlConnection conn = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS;database=sampazure;integrated security=true;");

            //Open the connection
            conn.Open();

            int id = Convert.ToInt32(txtId.Text);
            //Prepared the command
            SqlCommand cmd = new SqlCommand("select * from Product where ProId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            //Execute the command
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            while(sdr.Read())
            {
                txtName.Text = sdr[1].ToString();
            }          
            dt.Load(sdr);
            dataGridView1.DataSource= dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS;database=sampazure;integrated security=true;");

            //Open the connection
            conn.Open();
                       //Prepared the command
            SqlCommand cmd = new SqlCommand("select count(*) from Product", conn);
           int count = (int)cmd.ExecuteScalar();
            MessageBox.Show($"Total No: of Products:{count}");
        }
    }
}
