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
            ProgOps.ConnectDB();
        }

        public String searchQuery;
        public DataView dv;
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            // Hide result label
            lblRes.Visible = false;
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
            dgvTransactions.Columns[3].HeaderText = "Quantuty checked out";
            dgvTransactions.Columns[4].HeaderText = "Issued By";
            dgvTransactions.Columns[5].HeaderText = "Transaction ID";
            dgvTransactions.Columns[6].HeaderText = "Book Title";
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
                            dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USER_ID", searchQuery);
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
                        dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USERNAME", searchQuery);

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
                        dv = ProgOps.TransactionTable.DefaultView;
                        dv.RowFilter = "ISBN LIKE '" + searchQuery + "%'";
                        if (dv.Table.Rows.Count > 0)
                            dgvTransactions.DataSource = dv;
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                        }
                        break;
                    case "Quantity":
                        dv = ProgOps.TransactionTable.DefaultView;
                        dv.RowFilter = "QUANTITY LIKE '" + searchQuery + "%'";
                        if (dgvTransactions.Rows.Count > 0)
                            dgvTransactions.DataSource = dv;
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                        }
                        break;
                    case "Issuer":
                        dv = ProgOps.TransactionTable.DefaultView;
                        dv.RowFilter = "ISSUED_BY LIKE '" + searchQuery + "%'";
                        if (dv.Table.Rows.Count > 0)
                            dgvTransactions.DataSource = dv;
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                        }
                        break;
                    case "Trans. ID":
                        dv = ProgOps.TransactionTable.DefaultView;
                        dv.RowFilter = "TRANSACTION_ID LIKE '" + searchQuery + "%'";
                        if (dv.Table.Rows.Count > 0)
                            dgvTransactions.DataSource = dv;
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                        }
                        break;
                    case "Title":
                        dv = ProgOps.TransactionTable.DefaultView;
                        dv.RowFilter = "TITLE LIKE '" + searchQuery + "%'";
                        if (dv.Table.Rows.Count > 0)
                            dgvTransactions.DataSource = dv;
                        else
                        {
                            dgvTransactions.DataSource = dv;
                            lblRes.Visible = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset DataGridView   
            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = ProgOps.TransactionTable;

            // Reset forms
            lblRes.Visible = false;
            tbxSearch.Text = String.Empty;
        }
    }
}
