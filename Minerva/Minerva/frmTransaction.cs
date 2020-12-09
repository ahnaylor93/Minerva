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
                    break;
                default:
                    ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "TRANSACTION_DETAILS", ProgOps._cntDatabase);
                    break;
            }

            ProgOps._daRes.Fill(ProgOps.TransactionTable);
            DataColumn[] key = new DataColumn[1];
            key[0] = ProgOps.TransactionTable.Columns["TRANSACTION_ID"];
            ProgOps.TransactionTable.PrimaryKey = key;
            ProgOps.CloseDB();

            // Load DataGridView with DataTable info

            // set button for access
            switch (frmLogin.access)
            {
                case "Patron":
                    btnRemove.Enabled = false;
                    break;
                case "Employee":
                    btnRemove.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    }
}
