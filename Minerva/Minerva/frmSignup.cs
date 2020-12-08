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
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
            ProgOps.ConnectDB();
        }

        private DataTable dt;
        String username, firstname, lastname, password, checkPW, access, admin_code;

        private void frmSignup_Load(object sender, EventArgs e)
        {
            // loads datatable on load 
            dt = new DataTable();

            ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "USER_DETAILS", ProgOps._cntDatabase);
            ProgOps._daRes.Fill(dt);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns["USER_ID"];
            dt.PrimaryKey = key;

            // set default cbx value
            cbxDesig.SelectedItem = "Patron";
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            username = tbxUName.Text;
            firstname = tbxFN.Text;
            lastname = tbxLN.Text;
            password = tbxPW.Text;
            checkPW = tbxCPW.Text;
            access = cbxDesig.GetItemText(cbxDesig.SelectedItem);
            admin_code = tbxAdmin.Text;

            bool userExist = false;

            //check existing credentials to prevent duplicate accounts
            if (username == String.Empty || firstname == String.Empty
               || lastname == String.Empty || password == String.Empty)
            {
                MessageBox.Show("All data is required to complete user accounts", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SetDefaults();
            }
            else if (password != checkPW)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SetDefaults();
            }
            else if (access == "Employee" && admin_code != "emp" ||
                access == "Admin" && admin_code != "admin")
            {
                MessageBox.Show("Admin Code incorrect. Please check with supervisor for correct code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SetDefaults();
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["USERNAME"].ToString() == username)
                    {
                        MessageBox.Show("This account already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        SetDefaults();
                        userExist = true;
                    }
                }

                //if credentials do not conflict, create new user
                if (userExist == false)
                {
                    String upd;

                    int user_id = Utils._IDGenerator();

                    using (ProgOps._cntDatabase = new SqlConnection(Utils.CONNECT_STRING))
                    {
                        ProgOps._cntDatabase.Open();
                        upd = "INSERT INTO " + Utils.DB + ".USER_DETAILS ";
                        upd += "VALUES(@USER_ID, @USER_FIRSTNAME, @USER_LASTNAME, @USERNAME, @PASSWORD, @DESIGNATION)";
                        using (var cmd = new SqlCommand(upd, ProgOps._cntDatabase))
                        {
                            cmd.Parameters.AddWithValue("@USER_ID", user_id);
                            cmd.Parameters.AddWithValue("@USER_FIRSTNAME", firstname);
                            cmd.Parameters.AddWithValue("@USER_LASTNAME", lastname);
                            cmd.Parameters.AddWithValue("@USERNAME", username);
                            cmd.Parameters.AddWithValue("@PASSWORD", password);
                            cmd.Parameters.AddWithValue("@DESIGNATION", access);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    SetDefaults();
                    MessageBox.Show("Account Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // close Form
                    frmLogin login = new frmLogin();
                    login.Show();
                    this.Close();
                }
            }

            //enter new user into database
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close this form and return to login
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void SetDefaults()
        {
            tbxUName.Text = String.Empty;
            tbxFN.Text = String.Empty;
            tbxLN.Text = String.Empty;
            tbxPW.Text = String.Empty;
            tbxCPW.Text = String.Empty;
            cbxDesig.SelectedItem = "Patron";
            tbxAdmin.Text = String.Empty;
        }
    }
}
