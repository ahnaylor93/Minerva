using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        List<models.APIBookModel> bookSearch;

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbxRes.Items.Clear();

            if (searchQuery == String.Empty)
            {
                MessageBox.Show("Be sure to enter information for your search", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                bookSearch = await ProgOps.GetBook(tbxSearch.Text);

                if (bookSearch != null)
                {
                    lblTitle.Text = bookSearch[0].title != null ? bookSearch[0].title : "No results available";
                    lblSubtitle.Text = bookSearch[0].subtitle != null ? bookSearch[0].subtitle : String.Empty;

                    foreach (var lbxItem in bookSearch)
                    {
                        lbxRes.Items.Add(new models.DBBookModel
                        {
                            ISBN = lbxItem.isbn == null ? "not listed" : lbxItem.isbn[0],
                            title = lbxItem.title == null ? "not listed" : lbxItem.title,
                            publish_date = lbxItem.publish_date == null ? "not listed" : lbxItem.publish_date[0],
                            actual_quantity = 5,
                            checked_in = 5,
                            checked_out = 0,
                            image_url = lbxItem.isbn == null ? "Image not available" : Utils.IMAGE_QUERY + lbxItem.isbn[0] + Utils.IMG_TAG,
                            author = lbxItem.author_name == null ? "not listed" : lbxItem.author_name[0],
                            subtitle = lbxItem.subtitle == null ? String.Empty : lbxItem.subtitle
                        });

                        lbxRes.DisplayMember = lbxItem.subtitle == null ? "lbxItem.title" : "lbxItem.title + '-' + lbxItem.subtitle";
                        lbxRes.ValueMember = "ISBN";
                    }
                }
                else
                {
                    MessageBox.Show("No results available. Please try again", "No results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
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

        private void lbxRes_DoubleClick(object sender, EventArgs e)
        {
            lbxBookRes.Items.Clear();

            var selected = lbxRes.SelectedItem as models.DBBookModel;

            if (selected != null)
            {
                lblTitle.Text = selected.title;
                lblSubtitle.Text = selected.author;

                if (selected.image_url != "Image not available")
                {
                    pbxCover.LoadAsync(selected.image_url);
                    lblImgRes.Visible = false;
                }
                else
                {
                    lblImgRes.Visible = true;
                }
            }

            lbxBookRes.Items.Add(String.Format("ISBN: {0}", selected.ISBN));
            lbxBookRes.Items.Add(String.Format("Title: {0}", selected.title));
            lbxBookRes.Items.Add(String.Format("Subtitle: {0}", selected.subtitle));
            lbxBookRes.Items.Add(String.Format("Publish Date: {0}", selected.publish_date));
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            lblImgRes.Visible = true;
        }
    }
}
