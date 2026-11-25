namespace CDSProject
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ManageAccount = new System.Windows.Forms.Button();
            this.BtnReport = new System.Windows.Forms.Button();
            this.BtnCdsAttPortal = new System.Windows.Forms.Button();
            this.BtnRegCorp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.admin_Account_Panel1 = new CDSProject.Admin_Account_Panel();
            this.WelcomeAdmin = new System.Windows.Forms.Label();
            this.ucCDSReport1 = new CDSProject.UcCDSReport();
            this.ucCDSVerifier1 = new CDSProject.UcCDSVerifier();
            this.ucRegisterCorpMember1 = new CDSProject.UCRegisterCorpMember();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.ManageAccount);
            this.panel1.Controls.Add(this.BtnReport);
            this.panel1.Controls.Add(this.BtnCdsAttPortal);
            this.panel1.Controls.Add(this.BtnRegCorp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 593);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(46, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(122, 123);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 61;
            this.pictureBox4.TabStop = false;
            // 
            // ManageAccount
            // 
            this.ManageAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.ManageAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ManageAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.ManageAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.ManageAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageAccount.ForeColor = System.Drawing.Color.White;
            this.ManageAccount.Location = new System.Drawing.Point(0, 444);
            this.ManageAccount.Name = "ManageAccount";
            this.ManageAccount.Size = new System.Drawing.Size(215, 41);
            this.ManageAccount.TabIndex = 9;
            this.ManageAccount.Text = "Manage Account";
            this.ManageAccount.UseVisualStyleBackColor = false;
            this.ManageAccount.Click += new System.EventHandler(this.ManageAccount_Click);
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.BtnReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.BtnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReport.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReport.ForeColor = System.Drawing.Color.White;
            this.BtnReport.Location = new System.Drawing.Point(1, 349);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(215, 41);
            this.BtnReport.TabIndex = 8;
            this.BtnReport.Text = "Attendance Report";
            this.BtnReport.UseVisualStyleBackColor = false;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // BtnCdsAttPortal
            // 
            this.BtnCdsAttPortal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.BtnCdsAttPortal.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCdsAttPortal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnCdsAttPortal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.BtnCdsAttPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCdsAttPortal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCdsAttPortal.ForeColor = System.Drawing.Color.White;
            this.BtnCdsAttPortal.Location = new System.Drawing.Point(1, 254);
            this.BtnCdsAttPortal.Name = "BtnCdsAttPortal";
            this.BtnCdsAttPortal.Size = new System.Drawing.Size(215, 41);
            this.BtnCdsAttPortal.TabIndex = 7;
            this.BtnCdsAttPortal.Text = "CDS Attendance Portal";
            this.BtnCdsAttPortal.UseVisualStyleBackColor = false;
            this.BtnCdsAttPortal.Click += new System.EventHandler(this.BtnCdsAttPortal_Click);
            // 
            // BtnRegCorp
            // 
            this.BtnRegCorp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.BtnRegCorp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnRegCorp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnRegCorp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.BtnRegCorp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegCorp.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegCorp.ForeColor = System.Drawing.Color.White;
            this.BtnRegCorp.Location = new System.Drawing.Point(1, 159);
            this.BtnRegCorp.Name = "BtnRegCorp";
            this.BtnRegCorp.Size = new System.Drawing.Size(215, 41);
            this.BtnRegCorp.TabIndex = 6;
            this.BtnRegCorp.Text = "Register Corps Member";
            this.BtnRegCorp.UseVisualStyleBackColor = false;
            this.BtnRegCorp.Click += new System.EventHandler(this.BtnRegCorp_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.admin_Account_Panel1);
            this.panel2.Controls.Add(this.WelcomeAdmin);
            this.panel2.Controls.Add(this.ucCDSReport1);
            this.panel2.Controls.Add(this.ucCDSVerifier1);
            this.panel2.Controls.Add(this.ucRegisterCorpMember1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(214, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 593);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(419, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reflecting attendance transparency ......";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(331, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // admin_Account_Panel1
            // 
            this.admin_Account_Panel1.BackColor = System.Drawing.Color.White;
            this.admin_Account_Panel1.Location = new System.Drawing.Point(515, 365);
            this.admin_Account_Panel1.Name = "admin_Account_Panel1";
            this.admin_Account_Panel1.Size = new System.Drawing.Size(505, 228);
            this.admin_Account_Panel1.TabIndex = 10;
            this.admin_Account_Panel1.Visible = false;
            // 
            // WelcomeAdmin
            // 
            this.WelcomeAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WelcomeAdmin.AutoSize = true;
            this.WelcomeAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WelcomeAdmin.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.WelcomeAdmin.Location = new System.Drawing.Point(428, 290);
            this.WelcomeAdmin.Name = "WelcomeAdmin";
            this.WelcomeAdmin.Size = new System.Drawing.Size(245, 42);
            this.WelcomeAdmin.TabIndex = 9;
            this.WelcomeAdmin.Text = "Welcome Admin";
            this.WelcomeAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WelcomeAdmin.Visible = false;
            // 
            // ucCDSReport1
            // 
            this.ucCDSReport1.BackColor = System.Drawing.Color.White;
            this.ucCDSReport1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucCDSReport1.BackgroundImage")));
            this.ucCDSReport1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ucCDSReport1.Location = new System.Drawing.Point(474, 348);
            this.ucCDSReport1.Name = "ucCDSReport1";
            this.ucCDSReport1.Size = new System.Drawing.Size(546, 245);
            this.ucCDSReport1.TabIndex = 8;
            this.ucCDSReport1.Visible = false;
            // 
            // ucCDSVerifier1
            // 
            this.ucCDSVerifier1.BackColor = System.Drawing.Color.White;
            this.ucCDSVerifier1.Location = new System.Drawing.Point(409, 335);
            this.ucCDSVerifier1.Name = "ucCDSVerifier1";
            this.ucCDSVerifier1.Size = new System.Drawing.Size(611, 258);
            this.ucCDSVerifier1.TabIndex = 7;
            this.ucCDSVerifier1.Visible = false;
            // 
            // ucRegisterCorpMember1
            // 
            this.ucRegisterCorpMember1.BackColor = System.Drawing.Color.White;
            this.ucRegisterCorpMember1.Location = new System.Drawing.Point(828, 0);
            this.ucRegisterCorpMember1.Name = "ucRegisterCorpMember1";
            this.ucRegisterCorpMember1.Size = new System.Drawing.Size(192, 593);
            this.ucRegisterCorpMember1.TabIndex = 6;
            this.ucRegisterCorpMember1.Visible = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 593);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Button BtnCdsAttPortal;
        private System.Windows.Forms.Button BtnRegCorp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private UCRegisterCorpMember ucRegisterCorpMember1;
        private UcCDSVerifier ucCDSVerifier1;
        private UcCDSReport ucCDSReport1;
        private System.Windows.Forms.Button ManageAccount;
        private System.Windows.Forms.Label WelcomeAdmin;
        private Admin_Account_Panel admin_Account_Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}