using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSProject
{
    public partial class LoginForm : Form
    {
        // Data Source = c:\mydb.db;Version=3;
        // Data Source = C:\SQLITEDATABASES\SQLITEDB1.sqlite;Version=3;New=False;Compress=True;
         // SQLiteConnection con = new SQLiteConnection(@"Data Source =CDSDB.db; Version=3; New=True;Compress=True;");
       SQLiteConnection con = new SQLiteConnection(@"Data Source =|DataDirectory|\CDSDB.db; Version=3; New=True;Compress=True;");

         //readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");
        public void saveSettings()
        {
            Properties.Settings.Default.username = txtUsername.Text;
            Properties.Settings.Default.password = txtPassword.Text;
            Properties.Settings.Default.Save();
        }
        public void unsaveSettings()
        {
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.password = string.Empty;
            Properties.Settings.Default.Save();
        }
        public void getSettings()
        {
            txtUsername.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
            if (txtPassword.Text == string.Empty && txtUsername.Text == string.Empty)
            {
                chkRememberme.Checked = false;
            }
            else
            {
                chkRememberme.Checked = true;
            }
        }
        public LoginForm(string username, string passwo)
        {          
            InitializeComponent();
          
            txtUsername.Text = username;
            txtPassword.Text = passwo;
        }

        private static string userl = "";
        private static string passl = "";

        public static string UserL { get => userl; set => userl = value; }
        public static string PassL { get => passl; set => passl = value; }
        private void SignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    ErrDisp.Visible = true;
                    ErrDisp.Text = "Type in your Login Details";
                }
                else
                {
                    UserL = txtUsername.Text;
                    PassL = txtPassword.Text;

                    SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from logDetail where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        // con.Open();
                        //MessageBox.Show("Con has opened");
                        MainPage mainPg = new MainPage();
                        mainPg.Show();
                        Hide();
                        SystemTimeChecker systim = new SystemTimeChecker();
                        systim.ShowDialog();
                        
                        

                    }
                    else
                    {
                        ErrDisp.Text = "Incorrect login details";
                        ErrDisp.Visible = true;
                    }
                }
            }
            catch ( SQLiteException ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


        private void LinkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                
                RegisterForm rgFrm = new RegisterForm();
                rgFrm.Show();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Application.Exit();
       
       

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string dissallowedChars = @"\<>?;`:'][}{=+_)(&^~#@$%|";
                ErrDisp.Visible = false;
                //check if dissalowed char is entered
                if (dissallowedChars.Contains(e.KeyChar))
                {
                    e.Handled = true;

                    //MessageBox.Show("phonenumbers must be numerical digits only");
                    //lecPhonenum.BackColor = Color.Red;
                   // txtVerifier.ForeColor = Color.Red;
                    ErrDisp.Text = "This character is not accepted";
                    ErrDisp.Visible = true;
                    //lecPhonenum.ForeColor = Color.White;
                }
                //if char entered is numbers
                else
                {
                    //txtVerifier.BackColor = Color.White;
                    //txtVerifier.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chkRememberme_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRememberme.Checked == true)
            {
                saveSettings();
            }
            else
            {
                unsaveSettings();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            getSettings();
            if (Program.SplashForm.IsDisposed)
            {
                
            }
            else
            {
                Program.SplashForm.Invoke(new MethodInvoker(delegate { Program.SplashForm.Close(); }));
                Program.SplashThread.Join();
                this.BringToFront();
                this.TopMost=true;
            }

        }
    }
}
