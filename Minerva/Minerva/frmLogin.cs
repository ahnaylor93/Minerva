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

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close the splash window to prevent it from keeping the program alive
            //after it should terminate
            frmSplash.frmActiveSplash.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

        }
    }
}
