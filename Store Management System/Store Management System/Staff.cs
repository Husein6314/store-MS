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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];

            txtID.Text = row.Cells[0].Value.ToString();
            txtStaff_Name.Text = row.Cells[1].Value.ToString();
            cmbShift.Text = row.Cells[2].Value.ToString();
            txtSalary.Text = row.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("insert into  Staff values ( '" + txtID.Text + "' ,'" + txtStaff_Name.Text + "', '" + cmbShift.SelectedItem.ToString() + "', '" + txtSalary.Text + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfuly Saved");
            con.Close();
            DisplayData();
        }
        void DisplayData()
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select * from Staff", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand(" update Staff set Staff_Name= '" + txtStaff_Name.Text + "',  Shift= '" + cmbShift.SelectedItem.ToString() + "' , Salary = '" + txtSalary.Text + "') ", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfuly Updated");
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are Sure want to Delete this Record?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
                con.Open();
                SqlCommand command = new SqlCommand("    Delete Staff where ID ='" + txtID.Text + "'", con);


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
