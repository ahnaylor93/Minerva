using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minerva
{
    public partial class frmAdminMenu : Form
    {
        public frmAdminMenu()
        {
            InitializeComponent();
        }

        private void frmAdminMenu_Load(object sender, EventArgs e)
        {
            lblUname.Text = frmLogin.username;
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmBooks book = new frmBooks();
            book.ShowDialog();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers();
            users.ShowDialog();
            this.Hide();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            frmEmployees employees = new frmEmployees();
            employees.ShowDialog();
            this.Hide();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            frmTransaction transact = new frmTransaction();
            transact.ShowDialog();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

    }
}
