namespace CDSProject
{
    partial class FormAdminConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminConfirm));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SignIn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.CancelBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(60, 54);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(248, 25);
            this.txtPassword.TabIndex = 52;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(60, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Input Admin Password";
            // 
            // SignIn
            // 
            this.SignIn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.SignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SignIn.BorderRadius = 7;
            this.SignIn.ButtonText = "Ok";
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
            this.SignIn.Location = new System.Drawing.Point(88, 93);
            this.SignIn.Name = "SignIn";
            this.SignIn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.SignIn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.SignIn.OnHoverTextColor = System.Drawing.Color.White;
            this.SignIn.selected = false;
            this.SignIn.Size = new System.Drawing.Size(72, 29);
            this.SignIn.TabIndex = 54;
            this.SignIn.Text = "Ok";
            this.SignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignIn.Textcolor = System.Drawing.Color.White;
            this.SignIn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.CancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelBtn.BorderRadius = 7;
            this.CancelBtn.ButtonText = "Cancel";
            this.CancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelBtn.DisabledColor = System.Drawing.Color.Gray;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.CancelBtn.Iconimage = null;
            this.CancelBtn.Iconimage_right = null;
            this.CancelBtn.Iconimage_right_Selected = null;
            this.CancelBtn.Iconimage_Selected = null;
            this.CancelBtn.IconMarginLeft = 0;
            this.CancelBtn.IconMarginRight = 0;
            this.CancelBtn.IconRightVisible = true;
            this.CancelBtn.IconRightZoom = 0D;
            this.CancelBtn.IconVisible = true;
            this.CancelBtn.IconZoom = 90D;
            this.CancelBtn.IsTab = false;
            this.CancelBtn.Location = new System.Drawing.Point(213, 93);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(195)))), ((int)(((byte)(138)))));
            this.CancelBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.CancelBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.CancelBtn.selected = false;
            this.CancelBtn.Size = new System.Drawing.Size(72, 29);
            this.CancelBtn.TabIndex = 55;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CancelBtn.Textcolor = System.Drawing.Color.White;
            this.CancelBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // FormAdminConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(363, 134);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdminConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin Password Confirm";
            this.Load += new System.EventHandler(this.FormAdminConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton SignIn;
        private Bunifu.Framework.UI.BunifuFlatButton CancelBtn;
    }
}