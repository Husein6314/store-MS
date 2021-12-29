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

namespace Store_Management_System
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("insert into  Employee values ( '" + txtID.Text + "' ,'" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtTell.Text + "', '" + txtEmail.Text + "','" + txtLocation.Text + "','" + cmbGender.SelectedItem.ToString() + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfuly Saved");
            con.Close();
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are Sure want to Delete this Record?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
                con.Open();
                SqlCommand command = new SqlCommand("    Delete Employee where ID ='" + txtID.Text + "'", con);


                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfuly Deleted ");
                DisplayData();

            }
            else
            {

                MessageBox.Show("Enter ID");
            }
        }
        void DisplayData()
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select * from Employee", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];

            txtID.Text = row.Cells[0].Value.ToString();
            txtFname.Text = row.Cells[1].Value.ToString();
            txtLname.Text = row.Cells[2].Value.ToString();
            txtTell.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
            txtLocation.Text = row.Cells[5].Value.ToString();
            cmbGender.Text = row.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand(" update Employee set First_name= '" + txtFname.Text + "',  Last_name= '" + txtLname.Text + "' , Tell = '" + txtTell.Text + "' , Email = '" + txtEmail.Text + "' , Location = '" + txtLocation.Text + "', Gender = '" + cmbGender.Text + "'  where ID ='" + txtID.Text + "'  ", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfuly Updated");
            DisplayData();
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

