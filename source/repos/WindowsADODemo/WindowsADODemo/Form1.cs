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
using System.Xml.Linq;

namespace WindowsADODemo
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");

            con.Open();

            cmd = new SqlCommand("select * from DoverEmp", con);

            sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;
          
            con.Close();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");

            con.Open();
            int eid = Convert.ToInt32(txtid.Text);
            string name = txtname.Text;
            string dpt = txtDept.Text;
            int sal = Convert.ToInt32(txtSal.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            
            cmd = new SqlCommand("insert into DoverEmp values(@eid,@name,@dpt,@sal,@date)", con);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dpt", dpt);
            cmd.Parameters.AddWithValue("@sal", sal);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            MessageBox.Show("REcord Inserted");
            con.Close();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");

            con.Open();
            int eid = Convert.ToInt32(txtid.Text);
            string name = txtname.Text;
            string dpt = txtDept.Text;
            int sal = Convert.ToInt32(txtSal.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);

           cmd = new SqlCommand("update DoverEmp set Empname=@name,dept =@dpt,salary=@sal,JoiningDate=@date where Empid =@eid", con);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dpt", dpt);
            cmd.Parameters.AddWithValue("@sal", sal);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            MessageBox.Show("REcord Updated");
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");
            con.Open();
            int eid = Convert.ToInt32(txtid.Text);
            cmd = new SqlCommand("delete from DoverEmp where Empid =@eid", con);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.ExecuteNonQuery();
            MessageBox.Show("REcord Deleted");
            con.Close();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");
            con.Open();
            // int eid = Convert.ToInt32(txtid.Text);
           DateTime dat=Convert.ToDateTime(dateTimePicker1.Text);
            cmd = new SqlCommand("select * from DoverEmp where month(joiningdate) =month(@date)", con);
            cmd.Parameters.AddWithValue("@date", dat);
            MessageBox.Show("One Product search");
            sdr = cmd.ExecuteReader();
         //   txtname.Text = sdr[].ToString();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");

            con.Open();

            cmd = new SqlCommand("select * from DoverEmp", con);

            sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void btntot_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source = LAPTOP-BQF0DTHQ\\SQLEXPRESS; database = samp2024; integrated security = true;");
            con.Open();
            cmd = new SqlCommand("select count(*) from DoverEmp", con);
            int count = (int)cmd.ExecuteScalar();
            MessageBox.Show($"Total No: of Employees: {count}");



        }

    }
}
