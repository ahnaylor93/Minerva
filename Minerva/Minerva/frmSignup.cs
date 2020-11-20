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
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close this form and return to login
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //check existing credentials to prevent duplicate accounts
            //check admin code to determine access level
            //if credentials do not conflict, create new user
            //enter new user into database
        }
    }
}
