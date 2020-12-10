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
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        public int id;
        public String searchQuery;
        public DataView dv;

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            if (frmLogin.access != "Admin")
            {
                dgvEmployee.ReadOnly = true;
            }

            ProgOps.ConnectDB();

            cbxSearch.SelectedItem = "ID";

            // set main datatable
            ProgOps.UserTable = new DataTable();
            ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "USER_DETAILS WHERE DESIGNATION != 'Patron'", ProgOps._cntDatabase);

            ProgOps._daRes.Fill(ProgOps.UserTable);

            DataColumn[] key = new DataColumn[1];
            key[0] = ProgOps.UserTable.Columns["USER_ID"];
            ProgOps.UserTable.PrimaryKey = key;
            ProgOps.CloseDB();

            // Load DataGridView with DataTable info
            dgvEmployee.DataSource = ProgOps.UserTable;

            // Manually change column names
            dgvEmployee.Columns[0].HeaderText = "Employee ID";
            dgvEmployee.Columns[1].HeaderText = "First Name";
            dgvEmployee.Columns[2].HeaderText = "Last Name";
            dgvEmployee.Columns[3].HeaderText = "Username";
            dgvEmployee.Columns[4].HeaderText = "Password";
            dgvEmployee.Columns[5].HeaderText = "Designation";

            // Hide result label
            if (dgvEmployee.Rows.Count == 1) lblRes.Visible = true;
            else lblRes.Visible = false;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            searchQuery = tbxSearch.Text;
            if (searchQuery == " ")
            {
                MessageBox.Show("Please enter search criteria", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (cbxSearch.GetItemText(cbxSearch.SelectedItem))
                {
                    case "ID":
                        if (!int.TryParse(searchQuery, out int num))
                        {
                            MessageBox.Show("Please enter a valid user id", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dv = ProgOps.UserTable.DefaultView;
                            dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USER_ID", searchQuery);

                            if (dgvEmployee.Rows.Count == 1)
                            {
                                dgvEmployee.DataSource = dv;
                                lblRes.Visible = true;
                                tbxSearch.Text = String.Empty;
                            }
                            else
                            {
                                dgvEmployee.DataSource = dv;
                                lblRes.Visible = false;
                                tbxSearch.Text = String.Empty;
                            }
                        }
                        break;
                    case "First Name":
                        dv = ProgOps.UserTable.DefaultView;
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USER_FIRSTNAME", searchQuery);

                        if (dgvEmployee.Rows.Count == 1)
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    case "Last Name":
                        dv = ProgOps.UserTable.DefaultView;
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USER_LASTNAME", searchQuery);

                        if (dgvEmployee.Rows.Count == 1)
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    case "Username":
                        dv = ProgOps.UserTable.DefaultView;
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USERNAME", searchQuery);

                        if (dgvEmployee.Rows.Count == 1)
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    case "Password":
                        dv = ProgOps.UserTable.DefaultView;
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "PASSWORD", searchQuery);

                        if (dgvEmployee.Rows.Count == 1)
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    case "Designation":
                        dv = ProgOps.UserTable.DefaultView;
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "DESIGNATION", searchQuery);

                        if (dgvEmployee.Rows.Count == 1)
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvEmployee.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvEmployee.CurrentCell.RowIndex;
            int user_id = dgvEmployee.Rows[rowIndex].Cells[0].Value == null ? 0 : (int)dgvEmployee.Rows[rowIndex].Cells[0].Value;
            String firstname = dgvEmployee.Rows[rowIndex].Cells[1].Value == null ? String.Empty : (String)dgvEmployee.Rows[rowIndex].Cells[1].Value;
            String lastname = dgvEmployee.Rows[rowIndex].Cells[2].Value == null ? String.Empty : (String)dgvEmployee.Rows[rowIndex].Cells[2].Value;
            String username = dgvEmployee.Rows[rowIndex].Cells[3].Value == null ? String.Empty : (String)dgvEmployee.Rows[rowIndex].Cells[3].Value;
            String password = dgvEmployee.Rows[rowIndex].Cells[4].Value == null ? String.Empty : (String)dgvEmployee.Rows[rowIndex].Cells[4].Value;
            String designation = dgvEmployee.Rows[rowIndex].Cells[5].Value == null ? String.Empty : (String)dgvEmployee.Rows[rowIndex].Cells[5].Value;

            if (user_id != id)
            {
                MessageBox.Show("You may not change the employee id", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.frmEmployees_Load(null, null);
            }
            else if (firstname == String.Empty || lastname == String.Empty || username == String.Empty || password == String.Empty || designation == String.Empty)
            {
                MessageBox.Show("Please enter full employee information", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.frmEmployees_Load(null, null);
            }
            else if (user_id == frmLogin.user_id)
            {
                MessageBox.Show("You may not change your own information", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.frmEmployees_Load(null, null);
            }
            else
            {
                bool checker = ProgOps._updateUser(user_id, firstname, lastname, username, password, designation);
                if (checker)
                {
                    MessageBox.Show("Employee successfully Updated", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmEmployees_Load(null, null);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                int rowIndex = dgvEmployee.CurrentCell.RowIndex;
                int id = (int)dgvEmployee.Rows[rowIndex].Cells[0].Value;
                bool checker = ProgOps._deleteUserFromDB(id);
                if (checker)
                {
                    MessageBox.Show("Record Deleted Successfully", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmEmployees_Load(null, null);
                }
                else this.frmEmployees_Load(null, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (frmLogin.access)
            {
                case "Patron":
                    frmMainMenu main = new frmMainMenu();
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                    break;
                case "Employee":
                    frmEmployeeMenu emp = new frmEmployeeMenu();
                    this.Hide();
                    emp.ShowDialog();
                    this.Close();
                    break;
                case "Admin":
                    frmAdminMenu admin = new frmAdminMenu();
                    this.Hide();
                    admin.ShowDialog();
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvEmployee.CurrentCell.RowIndex;
            id = dgvEmployee.Rows[rowIndex].Cells[0].Value == null ? 0 : (int)dgvEmployee.Rows[rowIndex].Cells[0].Value;
        }
    }
}
