﻿namespace Minerva
{
    partial class frmBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxCover = new System.Windows.Forms.PictureBox();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbxRes = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCover
            // 
            this.pbxCover.Location = new System.Drawing.Point(34, 133);
            this.pbxCover.Margin = new System.Windows.Forms.Padding(1);
            this.pbxCover.Name = "pbxCover";
            this.pbxCover.Size = new System.Drawing.Size(237, 327);
            this.pbxCover.TabIndex = 0;
            this.pbxCover.TabStop = false;
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(307, 21);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(1);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(306, 20);
            this.tbxSearch.TabIndex = 0;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(296, 133);
            this.tbxDescription.Margin = new System.Windows.Forms.Padding(1);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(229, 327);
            this.tbxDescription.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(71, 62);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 21);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Book Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.Location = new System.Drawing.Point(71, 83);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(159, 22);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Subtitle";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(836, 513);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(163, 44);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "&Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCart
            // 
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.Location = new System.Drawing.Point(34, 513);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(163, 44);
            this.btnCart.TabIndex = 17;
            this.btnCart.Text = "Add to &Cart";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(657, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 20);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbxRes
            // 
            this.lbxRes.FormattingEnabled = true;
            this.lbxRes.Location = new System.Drawing.Point(736, 133);
            this.lbxRes.Name = "lbxRes";
            this.lbxRes.Size = new System.Drawing.Size(217, 329);
            this.lbxRes.TabIndex = 19;
            // 
            // frmBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1011, 569);
            this.Controls.Add(this.lbxRes);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.pbxCover);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minerva - Books";
            ((System.ComponentModel.ISupportInitialize)(this.pbxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxCover;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lbxRes;
    }
}