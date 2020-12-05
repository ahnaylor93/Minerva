
// FRM SIGNUP
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

// FROM LOGIN
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
