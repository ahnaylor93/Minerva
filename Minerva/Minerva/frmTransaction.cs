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
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }

        public String searchQuery;
        public String del;
        public DataView dv;

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            ProgOps.ConnectDB();

            cbxSearch.SelectedItem = "User ID";

            // set main datatable
            ProgOps.TransactionTable = new DataTable();

            switch (frmLogin.access)
            {
                case "Patron":
                    ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY +
                        "TRANSACTION_DETAILS WHERE USER_ID = " + frmLogin.user_id, ProgOps._cntDatabase);
                    btnRemove.Enabled = false;
                    break;
                case "Employee":
                    ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "TRANSACTION_DETAILS", ProgOps._cntDatabase);
                    btnRemove.Enabled = false;
                    break;
                case "Admin":
                    ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "TRANSACTION_DETAILS", ProgOps._cntDatabase);
                    break;
                default:
                    break;
            }

            ProgOps._daRes.Fill(ProgOps.TransactionTable);
            DataColumn[] key = new DataColumn[1];
            key[0] = ProgOps.TransactionTable.Columns["TRANSACTION_ID"];
            ProgOps.TransactionTable.PrimaryKey = key;
            ProgOps.CloseDB();

            // Load DataGridView with DataTable info
            dgvTransactions.DataSource = ProgOps.TransactionTable;

            // Manually change column names
            dgvTransactions.Columns[0].HeaderText = "Patron ID";
            dgvTransactions.Columns[1].HeaderText = "Username";
            dgvTransactions.Columns[2].HeaderText = "Book ISBN";
            dgvTransactions.Columns[3].HeaderText = "Quantity";
            dgvTransactions.Columns[4].HeaderText = "Issued By";
            dgvTransactions.Columns[5].HeaderText = "Transaction ID";
            dgvTransactions.Columns[6].HeaderText = "Book Title";

            // Hide result label
            if (dgvTransactions.Rows.Count == 1) lblRes.Visible = true;
            else lblRes.Visible = false;
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
                    case "User ID":
                        if (!int.TryParse(searchQuery, out int num))
                        {
                            MessageBox.Show("Please enter a valid user id", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dv = ProgOps.TransactionTable.DefaultView;
                            del = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USER_ID", searchQuery);
                            dv.RowFilter = del;
                            if (dgvTransactions.Rows.Count == 1)
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = true;
                                tbxSearch.Text = String.Empty;
                            }
                            else
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = false;
                                tbxSearch.Text = String.Empty;
                            }
                        }
                        break;
                    case "Username":
                        dv = ProgOps.TransactionTable.DefaultView;
                        del = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USERNAME", searchQuery);
                        dv.RowFilter = del;

                        if (dgvTransactions.Rows.Count == 1)
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    case "ISBN":
                        if (!int.TryParse(searchQuery, out num))
                        {
                            MessageBox.Show("Please enter a valid user id", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dv = ProgOps.TransactionTable.DefaultView;
                            del = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "ISBN", searchQuery);
                            dv.RowFilter = del;
                            if (dgvTransactions.Rows.Count == 1)
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = true;
                                tbxSearch.Text = String.Empty;
                            }
                            else
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = false;
                                tbxSearch.Text = String.Empty;
                            }
                        }
                        break;
                    case "Quantity":
                        if (!int.TryParse(searchQuery, out num))
                        {
                            MessageBox.Show("Please enter a valid user id", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dv = ProgOps.TransactionTable.DefaultView;
                            del = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "QUANTITY", searchQuery);
                            dv.RowFilter = del;
                            if (dgvTransactions.Rows.Count == 1)
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = true;
                                tbxSearch.Text = String.Empty;
                            }
                            else
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = false;
                                tbxSearch.Text = String.Empty;
                            }
                        }
                        break;
                    case "Issuer":
                        dv = ProgOps.TransactionTable.DefaultView;
                        del = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "ISSUED_BY", searchQuery);
                        dv.RowFilter = del;

                        if (dgvTransactions.Rows.Count == 1)
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    case "Trans. ID":
                        if (!int.TryParse(searchQuery, out num))
                        {
                            MessageBox.Show("Please enter a valid user id", "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dv = ProgOps.TransactionTable.DefaultView;
                            dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "TRANSACTION_ID", searchQuery);
                            if (dgvTransactions.Rows.Count == 1)
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = true;
                                tbxSearch.Text = String.Empty;
                            }
                            else
                            {
                                dgvTransactions.DataSource = dv;
                                lblRes.Visible = false;
                                tbxSearch.Text = String.Empty;
                            }
                        }
                        break;
                    case "Title":
                        dv = ProgOps.TransactionTable.DefaultView;
                        del = "WHERE TITLE = " + searchQuery;
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "TITLE", searchQuery);

                        if (dgvTransactions.Rows.Count == 1)
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                            tbxSearch.Text = String.Empty;
                        }
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = false;
                            tbxSearch.Text = String.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.frmTransaction_Load(null, null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this transaction?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                int rowIndex = dgvTransactions.CurrentCell.RowIndex;
                int id = (int)dgvTransactions.Rows[rowIndex].Cells[5].Value;
                bool checker = ProgOps._deleteTransactionFromDB(id);
                if (checker)
                {
                    MessageBox.Show("Record Deleted Successfully", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmTransaction_Load(null, null);
                }
            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
