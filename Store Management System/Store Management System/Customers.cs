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

namespace Store_Management_System
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("insert into  Customers values ( '" + txtID.Text + "' ,'" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtTell.Text + "', '" + txtEmail.Text + "','" + txtAddress.Text + "','" + cmbGender.SelectedItem.ToString() + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfuly Saved");
            con.Close();
            DisplayData();
        }

        void DisplayData()
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select * from Customers", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'storeDataSet.Customers' table. You can move, or remove it, as needed.
            

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand(" update Customers set First_name= '" + txtFname.Text + "',  Last_name= '" + txtLname.Text + "' , Tell = '" + txtTell.Text + "' , Email = '" + txtEmail.Text + "' , Address = '" + txtAddress.Text + "', Gender = '" + cmbGender.Text + "'  where ID ='" + txtID.Text + "'  ", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfuly Updated");
            DisplayData();
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
            txtAddress.Text = row.Cells[5].Value.ToString();
            cmbGender.Text = row.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are Sure want to Delete this Record?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
                con.Open();
                SqlCommand command = new SqlCommand("    Delete Customers where ID ='" + txtID.Text + "'", con);


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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
