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

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            // set main datatable
            ProgOps.TransactionTable = new DataTable();

            ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "T", ProgOps._cntDatabase);
            ProgOps._daRes.Fill(ProgOps.TransactionTable);
            DataColumn[] key = new DataColumn[1];
            key[0] = ProgOps.TransactionTable.Columns["TRANSACTION_ID"];
            ProgOps.TransactionTable.PrimaryKey = key;
            ProgOps.CloseDB();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    }
}
