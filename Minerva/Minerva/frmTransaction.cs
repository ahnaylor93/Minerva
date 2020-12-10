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

        private void frmTransaction_Load(object sender, EventArgs e)
        {
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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (frmLogin.access)
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
    }
}
