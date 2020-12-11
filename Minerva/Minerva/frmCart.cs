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
    public partial class frmCart : Form
    {
        public frmCart()
        {
            InitializeComponent();
        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            ProgOps.ConnectDB();

            // set main datatable
            ProgOps.UserTable = new DataTable();
            ProgOps._daRes = new SqlDataAdapter(Utils.DB_QUERY + "USER_DETAILS WHERE DESIGNATION = 'Patron'", ProgOps._cntDatabase);

            ProgOps._daRes.Fill(ProgOps.UserTable);

            DataColumn[] key = new DataColumn[1];
            key[0] = ProgOps.UserTable.Columns["USER_ID"];
            ProgOps.UserTable.PrimaryKey = key;
            ProgOps.CloseDB();

            lbxUsers.DataSource = ProgOps.UserTable;
            lbxUsers.ValueMember = ProgOps.UserTable.Columns[0].ToString();
            lbxUsers.DisplayMember = ProgOps.UserTable.Columns[3].ToString();

            dgvCart.DataSource = frmBooks.CartTable;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmBooks book = new frmBooks();
            this.Hide();
            book.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Checkout Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            frmBooks.CartTable.Clear();
            this.frmCart_Load(null, null);
        }

        private void lbxUsers_DoubleClick(object sender, EventArgs e)
        {
            String username = lbxUsers.SelectedItem.ToString();
            DataView dv = new DataView();
            dv = ProgOps.UserTable.DefaultView;
            dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", "USERNAME", username);
            int user_id = Convert.ToInt32(dv.Table.Columns[0].ToString());

            foreach (DataRow dr in frmBooks.CartTable.Rows)
            {
                dr.BeginEdit();
                dr["user_id"] = user_id;
                dr["username"] = username;
            }
        }
    }
}
