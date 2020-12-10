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
    public partial class frmBooks : Form
    {

        public frmBooks()
        {
            InitializeComponent();
            models.APIHelper.InitializeClient();
        }

        public String searchQuery;


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            tbxSearch.Text = searchQuery;

            if (searchQuery == String.Empty)
            {
                MessageBox.Show("Be sure to enter information for your search", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                var bookSearch = await ProgOps.GetBook(searchQuery);

                lblTitle.Text = bookSearch[0].title != null ? bookSearch[0].title : "No results available";
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {

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

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
