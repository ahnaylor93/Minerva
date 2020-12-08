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

namespace Minerva
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            ProgOps.ConnectDB();
        }

        DataTable dt;
        public static String username;
        public static String access;
        String password;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // loads datatable on load 
            dt = new DataTable();

            ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "USER_DETAILS", ProgOps._cntDatabase);
            ProgOps._daRes.Fill(dt);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns["USER_ID"];
            dt.PrimaryKey = key;
            ProgOps.CloseDB();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmSignup signup = new frmSignup();
            signup.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;

            if (username == String.Empty || password == String.Empty)
            {
                MessageBox.Show("Username and Password are required", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            if (dr["USERNAME"].ToString() == username)
                            {
                                String pwCheck = dr.Field<String>("PASSWORD") != null ? dr.Field<String>("PASSWORD") : String.Empty;
                                //Determine access level
                                access = dr.Field<String>("DESIGNATION") != null ? dr.Field<String>("DESIGNATION") : String.Empty;
                                String user = dr.Field<String>("USER_FIRSTNAME") != null ? dr.Field<String>("USER_FIRSTNAME") + " " + dr.Field<String>("USER_LASTNAME") : String.Empty;

                                //Check credentials against DB
                                if (password == pwCheck)
                                {
                                    MessageBox.Show("Welcome to Minerva, " + user, "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                    //Determine form to open based on access level
                                    switch (access)
                                    {
                                        case "Patron":
                                            frmMainMenu main = new frmMainMenu();
                                            main.ShowDialog();
                                            this.Close();
                                            break;
                                        case "Employee":
                                            frmEmployeeMenu emp = new frmEmployeeMenu();
                                            emp.ShowDialog();
                                            this.Close();
                                            break;
                                        case "Admin":
                                            frmAdminMenu admin = new frmAdminMenu();
                                            admin.ShowDialog();
                                            this.Close();
                                            break;
                                        default:
                                            break;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Please check your information and try again", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbxUsername.Text = String.Empty;
                                    tbxPassword.Text = String.Empty;
                                }
                            }
                        }

                    }

                }

            }

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close the splash window to prevent it from keeping the program alive
            //after it should terminate
            frmSplash.frmActiveSplash.Close();
        }
    }
}
