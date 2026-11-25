namespace CDSProject
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SignIn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ErrDisp = new System.Windows.Forms.Label();
            this.LinkRegister = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.chkRememberme = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // SignIn
            // 
            this.SignIn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.SignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SignIn.BorderRadius = 7;
            this.SignIn.ButtonText = "Login";
            this.SignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignIn.DisabledColor = System.Drawing.Color.Gray;
            this.SignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIn.Iconcolor = System.Drawing.Color.Transparent;
            this.SignIn.Iconimage = null;
            this.SignIn.Iconimage_right = null;
            this.SignIn.Iconimage_right_Selected = null;
            this.SignIn.Iconimage_Selected = null;
            this.SignIn.IconMarginLeft = 0;
            this.SignIn.IconMarginRight = 0;
            this.SignIn.IconRightVisible = true;
            this.SignIn.IconRightZoom = 0D;
            this.SignIn.IconVisible = true;
            this.SignIn.IconZoom = 90D;
            this.SignIn.IsTab = false;
            this.SignIn.Location = new System.Drawing.Point(333, 334);
            this.SignIn.Name = "SignIn";
            this.SignIn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.SignIn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.SignIn.OnHoverTextColor = System.Drawing.Color.White;
            this.SignIn.selected = false;
            this.SignIn.Size = new System.Drawing.Size(72, 29);
            this.SignIn.TabIndex = 53;
            this.SignIn.Text = "Login";
            this.SignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignIn.Textcolor = System.Drawing.Color.White;
            this.SignIn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // ErrDisp
            // 
            this.ErrDisp.AutoSize = true;
            this.ErrDisp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrDisp.ForeColor = System.Drawing.Color.Red;
            this.ErrDisp.Location = new System.Drawing.Point(161, 298);
            this.ErrDisp.Name = "ErrDisp";
            this.ErrDisp.Size = new System.Drawing.Size(185, 15);
            this.ErrDisp.TabIndex = 52;
            this.ErrDisp.Text = "** Please Fill your Accurate details";
            this.ErrDisp.Visible = false;
            // 
            // LinkRegister
            // 
            this.LinkRegister.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.LinkRegister.AutoSize = true;
            this.LinkRegister.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.LinkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkRegister.LinkColor = System.Drawing.Color.Silver;
            this.LinkRegister.Location = new System.Drawing.Point(156, 344);
            this.LinkRegister.Name = "LinkRegister";
            this.LinkRegister.Size = new System.Drawing.Size(129, 13);
            this.LinkRegister.TabIndex = 51;
            this.LinkRegister.TabStop = true;
            this.LinkRegister.Text = "Don\'t have an account?";
            this.LinkRegister.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.LinkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRegister_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(158, 269);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(248, 25);
            this.txtPassword.TabIndex = 50;
            this.txtPassword.Text = "admin";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(158, 215);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(248, 25);
            this.txtUsername.TabIndex = 49;
            this.txtUsername.Text = "admin";
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(155, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(154, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(241, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 35);
            this.label1.TabIndex = 46;
            this.label1.Text = "Login ";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.BorderRadius = 0;
            this.CloseBtn.ButtonText = "";
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.DisabledColor = System.Drawing.Color.Gray;
            this.CloseBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.CloseBtn.Iconimage = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Iconimage")));
            this.CloseBtn.Iconimage_right = null;
            this.CloseBtn.Iconimage_right_Selected = null;
            this.CloseBtn.Iconimage_Selected = null;
            this.CloseBtn.IconMarginLeft = 0;
            this.CloseBtn.IconMarginRight = 0;
            this.CloseBtn.IconRightVisible = true;
            this.CloseBtn.IconRightZoom = 0D;
            this.CloseBtn.IconVisible = true;
            this.CloseBtn.IconZoom = 40D;
            this.CloseBtn.IsTab = false;
            this.CloseBtn.Location = new System.Drawing.Point(501, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Normalcolor = System.Drawing.Color.Transparent;
            this.CloseBtn.OnHovercolor = System.Drawing.Color.Red;
            this.CloseBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.CloseBtn.selected = false;
            this.CloseBtn.Size = new System.Drawing.Size(27, 25);
            this.CloseBtn.TabIndex = 54;
            this.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseBtn.Textcolor = System.Drawing.Color.White;
            this.CloseBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // chkRememberme
            // 
            this.chkRememberme.AutoSize = true;
            this.chkRememberme.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberme.ForeColor = System.Drawing.Color.Snow;
            this.chkRememberme.Location = new System.Drawing.Point(160, 313);
            this.chkRememberme.Name = "chkRememberme";
            this.chkRememberme.Size = new System.Drawing.Size(110, 19);
            this.chkRememberme.TabIndex = 55;
            this.chkRememberme.Text = "Remember Me";
            this.chkRememberme.UseVisualStyleBackColor = false;
            this.chkRememberme.CheckedChanged += new System.EventHandler(this.chkRememberme_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(209, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(528, 393);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkRememberme);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.ErrDisp);
            this.Controls.Add(this.LinkRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuFlatButton SignIn;
        private System.Windows.Forms.Label ErrDisp;
        private System.Windows.Forms.LinkLabel LinkRegister;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton CloseBtn;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.CheckBox chkRememberme;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

