namespace Minerva
{
    partial class frmSplash
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
            this.components = new System.ComponentModel.Container();
            this.pbxSplash = new System.Windows.Forms.PictureBox();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxSplash
            // 
            this.pbxSplash.Image = global::Minerva.Properties.Resources.splash;
            this.pbxSplash.Location = new System.Drawing.Point(-1, -3);
            this.pbxSplash.Name = "pbxSplash";
            this.pbxSplash.Size = new System.Drawing.Size(1161, 633);
            this.pbxSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSplash.TabIndex = 0;
            this.pbxSplash.TabStop = false;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 625);
            this.Controls.Add(this.pbxSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxSplash;
        private System.Windows.Forms.Timer tmrTimer;
    }
}