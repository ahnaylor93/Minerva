﻿using System;
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
    public partial class frmAdminMenu : Form
    {
        public frmAdminMenu()
        {
            InitializeComponent();
        }

        private void frmAdminMenu_Load(object sender, EventArgs e)
        {
            lblUname.Text = frmLogin.username;
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmBooks book = new frmBooks();
            this.Hide();
            book.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers();
            this.Hide();
            users.ShowDialog();
        }

        private void btnTransact_Click(object sender, EventArgs e)
        {
            frmTransaction transact = new frmTransaction();
            this.Hide();
            transact.ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            frmEmployees employees = new frmEmployees();
            this.Hide();
            employees.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit as " + frmLogin.username + " ? ", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                ProgOps.CloseDB();
                this.Close();
                Environment.Exit(0);
            }
        }
    }
}
