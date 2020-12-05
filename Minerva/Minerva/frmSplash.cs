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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        // publicly accessible variable to hold this instance of the splash screen
        public static frmSplash frmActiveSplash;

        int intTicks;

        private void frmSplash_Load(object sender, EventArgs e)
        {
            // assign this instance to frmActiveSplash
            frmActiveSplash = this;
            //start the timer
            intTicks = 0;
            tmrTimer.Start();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            intTicks++;
            if(intTicks >= 20)
            {
                tmrTimer.Stop();
                frmLogin newLogin = new frmLogin();
                this.Hide();
                newLogin.Show();          
            }
        }
    }
}
