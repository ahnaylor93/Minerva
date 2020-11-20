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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            /*
            TODO:
            *establish database connection
            */
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //open the sign-up form
            frmSignup newSignup = new frmSignup();
            newSignup.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            /*
            TODO:
            *check entered credentials against credentials in database
            *determine the next form to open based on access level
            *hide login form
            */
        }
    }
}
