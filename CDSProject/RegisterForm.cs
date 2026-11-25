using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSProject
{
    public partial class RegisterForm : Form
    {
        //readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");
        SQLiteConnection con = new SQLiteConnection(@"Data Source =|DataDirectory|\CDSDB.sqlite; Version=3; New=True;Compress=True;");

        public RegisterForm() =>  InitializeComponent();
        
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        private static string user = "";
        private static string pass = "";

        public static string User { get => user; set => user = value; }
        public static string Pass { get => pass; set => pass = value; }

        public void unsaveSettings()
        {
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.password = string.Empty;
            Properties.Settings.Default.Save();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text == txtConfPassword.Text)
                {
                    User = txtUsername.Text;
                    Pass = txtPassword.Text;
                    
                    //Check for duplicates
                    SQLiteDataAdapter sda0 = new SQLiteDataAdapter("select * from logDetail where username = '" + txtUsername.Text + "' ", con);
                    DataTable dt0 = new DataTable();
                    sda0.Fill(dt0);
                    if (dt0.Rows.Count ==0)
                    {
                        SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from logDetail where role = '" + "Admin" + "'  ", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            DialogResult result = MessageBox.Show("Do you want to assume the ROLE of an ADMIN?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                //...
                                SQLiteCommand dbcmd = con.CreateCommand();
                                dbcmd.CommandText = "INSERT INTO logDetail (username, password, role) VALUES( @usern,@passw,@roler)";
                                dbcmd.Parameters.AddWithValue("@usern", RegisterForm.User);
                                dbcmd.Parameters.AddWithValue("@passw", RegisterForm.Pass);
                                dbcmd.Parameters.AddWithValue("@roler", "Admin");
                                dbcmd.ExecuteNonQuery();
                               
                                MessageBox.Show("Admin account created Successfully", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //this.Hide();
                                unsaveSettings();
                                LoginForm rgFrm = new LoginForm(User, Pass);
                                
                                rgFrm.Show();


                                this.Hide();
                            }
                            else if (result == DialogResult.No)
                            {
                                //...
                                SQLiteDataAdapter sda1 = new SQLiteDataAdapter("select * from logDetail where role = '" + "User" + "'  ", con);
                                DataTable dt1 = new DataTable();
                                sda1.Fill(dt1);
                                if (dt1.Rows.Count < 2)
                                {
                                    SQLiteCommand dbcmd = con.CreateCommand();
                                    dbcmd.CommandText = "INSERT INTO logDetail (username, password, role) VALUES( @usern,@passw,@roler)";
                                    dbcmd.Parameters.AddWithValue("@usern", RegisterForm.User);
                                    dbcmd.Parameters.AddWithValue("@passw", RegisterForm.Pass);
                                    dbcmd.Parameters.AddWithValue("@roler", "User");
                                    dbcmd.ExecuteNonQuery();
                             
                                    MessageBox.Show("User account created Successfully", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    unsaveSettings();
                                    LoginForm rgFrm = new LoginForm(User, Pass);
                                    rgFrm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Exceeded Number of Users: 2", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    return;
                                }
                            }

                        }
                        else
                        {
                            SQLiteDataAdapter sda1 = new SQLiteDataAdapter("select * from logDetail where role = '" + "User" + "'  ", con);
                            DataTable dt1 = new DataTable();
                            sda1.Fill(dt1);
                            if (dt1.Rows.Count < 2)
                            {
                                SQLiteCommand dbcmd = con.CreateCommand();
                                dbcmd.CommandText = "INSERT INTO logDetail (username, password, role) VALUES( @usern,@passw,@roler)";
                                dbcmd.Parameters.AddWithValue("@usern", RegisterForm.User);
                                dbcmd.Parameters.AddWithValue("@passw", RegisterForm.Pass);
                                dbcmd.Parameters.AddWithValue("@roler", "User");
                                dbcmd.ExecuteNonQuery();
                                
                                MessageBox.Show("User account created Successfully", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                unsaveSettings();
                                LoginForm rgFrm = new LoginForm(User, Pass);
                                rgFrm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Exceeded Number of Users :2", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                return;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("This Login detail cannot be accepted anymore \n Use a different username","CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                }
                else if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfPassword.Text == "")
                {
                    ErrDisp.Visible = true;
                }
                else if (txtPassword.Text != txtConfPassword.Text)
                {
                    ErrDisp.Text = "Password doesn't match";
                    ErrDisp.Visible = true;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LinkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm newlgfrm = new LoginForm( string.Empty, string.Empty);
            newlgfrm.Show();
            this.Hide();
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
    }
}
