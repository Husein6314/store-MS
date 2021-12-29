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
    public partial class Delete_User : Form
    {
        public Delete_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are Sure want to Delete this User?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
                con.Open();
                SqlCommand command = new SqlCommand("    Delete Login where Username ='" + txtUser.Text + "'", con);


                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfuly User Deleted ");
                DisplayData();

            }
            else
            {

                MessageBox.Show("Enter Username");
            }
        }
        void DisplayData()
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ADKU8P3;Initial Catalog=Store;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select * from Login", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dgvDeleteuser.DataSource = dt;
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
