using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System
{
    public partial class Mainpage : Form
    {
        public Mainpage()
        {
            InitializeComponent();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee EM = new Employee();
            EM.Show();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expenses EM = new Expenses();
            EM.Show();
        }

        private void addStufToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers EM = new Customers();
            EM.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password EM = new Change_Password();
            EM.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_User EM = new Add_User();
            EM.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_User EM = new Delete_User();
            EM.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product EM = new Product();
            EM.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales EM = new Sales();
            EM.Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff EM = new Staff();
            EM.Show();
        }
    }
}
