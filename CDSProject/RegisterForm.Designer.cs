namespace CDSProject
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ErrDisp = new System.Windows.Forms.Label();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LinkLogin = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SignUp = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ErrDisp
            // 
            this.ErrDisp.AutoSize = true;
            this.ErrDisp.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrDisp.ForeColor = System.Drawing.Color.Firebrick;
            this.ErrDisp.Location = new System.Drawing.Point(146, 334);
            this.ErrDisp.Name = "ErrDisp";
            this.ErrDisp.Size = new System.Drawing.Size(166, 15);
            this.ErrDisp.TabIndex = 57;
            this.ErrDisp.Text = "** Complete detail is required";
            this.ErrDisp.Visible = false;
            // 
            // txtConfPassword
            // 
            this.txtConfPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfPassword.Location = new System.Drawing.Point(149, 306);
            this.txtConfPassword.Name = "txtConfPassword";
            this.txtConfPassword.Size = new System.Drawing.Size(241, 23);
            this.txtConfPassword.TabIndex = 56;
            this.txtConfPassword.UseSystemPasswordChar = true;
            this.txtConfPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(146, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "Confirm Password";
            // 
            // LinkLogin
            // 
            this.LinkLogin.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.LinkLogin.AutoSize = true;
            this.LinkLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLogin.ForeColor = System.Drawing.Color.LightGray;
            this.LinkLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkLogin.LinkColor = System.Drawing.Color.Silver;
            this.LinkLogin.Location = new System.Drawing.Point(150, 369);
            this.LinkLogin.Name = "LinkLogin";
            this.LinkLogin.Size = new System.Drawing.Size(156, 13);
            this.LinkLogin.TabIndex = 54;
            this.LinkLogin.TabStop = true;
            this.LinkLogin.Text = "Already have an account?";
            this.LinkLogin.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.LinkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLogin_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(149, 251);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(241, 23);
            this.txtPassword.TabIndex = 53;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(149, 197);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(241, 23);
            this.txtUsername.TabIndex = 52;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(145, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(145, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(224, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 49;
            this.label1.Text = "REGISTER";
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
            this.CloseBtn.Location = new System.Drawing.Point(513, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Normalcolor = System.Drawing.Color.Transparent;
            this.CloseBtn.OnHovercolor = System.Drawing.Color.Red;
            this.CloseBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.CloseBtn.selected = false;
            this.CloseBtn.Size = new System.Drawing.Size(27, 25);
            this.CloseBtn.TabIndex = 59;
            this.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseBtn.Textcolor = System.Drawing.Color.White;
            this.CloseBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SignUp
            // 
            this.SignUp.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.SignUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SignUp.BorderRadius = 7;
            this.SignUp.ButtonText = "Sign Up";
            this.SignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignUp.DisabledColor = System.Drawing.Color.Gray;
            this.SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp.Iconcolor = System.Drawing.Color.Transparent;
            this.SignUp.Iconimage = null;
            this.SignUp.Iconimage_right = null;
            this.SignUp.Iconimage_right_Selected = null;
            this.SignUp.Iconimage_Selected = null;
            this.SignUp.IconMarginLeft = 0;
            this.SignUp.IconMarginRight = 0;
            this.SignUp.IconRightVisible = true;
            this.SignUp.IconRightZoom = 0D;
            this.SignUp.IconVisible = true;
            this.SignUp.IconZoom = 90D;
            this.SignUp.IsTab = false;
            this.SignUp.Location = new System.Drawing.Point(316, 361);
            this.SignUp.Name = "SignUp";
            this.SignUp.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.SignUp.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.SignUp.OnHoverTextColor = System.Drawing.Color.White;
            this.SignUp.selected = false;
            this.SignUp.Size = new System.Drawing.Size(72, 29);
            this.SignUp.TabIndex = 58;
            this.SignUp.Text = "Sign Up";
            this.SignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignUp.Textcolor = System.Drawing.Color.White;
            this.SignUp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(540, 405);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrDisp);
            this.Controls.Add(this.txtConfPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LinkLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SignUp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label ErrDisp;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel LinkLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton CloseBtn;
        private Bunifu.Framework.UI.BunifuFlatButton SignUp;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}