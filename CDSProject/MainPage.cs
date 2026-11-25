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
    public partial class MainPage : Form
    {
        readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");
        
        public MainPage()
        {
            InitializeComponent();
            admin();
        }
        private void ColorChange(Button btn)
        {
            //103, 192, 136
            BtnRegCorp.BackColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            BtnRegCorp.ForeColor = Color.White;
            BtnCdsAttPortal.BackColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            BtnCdsAttPortal.ForeColor = Color.White;
            BtnReport.BackColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            BtnReport.ForeColor = Color.White;
            ManageAccount.BackColor= Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            ManageAccount.ForeColor= Color.White;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Green;

        }
        private void ControlChange(UserControl UC)
        {
            ucCDSVerifier1.Visible = false;
            ucRegisterCorpMember1.Visible = false;
            admin_Account_Panel1.Visible = false;
            ucCDSReport1.Visible = false;
            UC.Dock = DockStyle.Fill;
            UC.BringToFront();
            UC.Visible = true;
        }
        private void BtnReport_Click(object sender, EventArgs e)
        {
            ColorChange(BtnReport);
            ControlChange(ucCDSReport1);
        }
        private void admin()
        {
            
            SQLiteDataAdapter sda = new SQLiteDataAdapter("select role from logDetail where username = '" + LoginForm.UserL + "' and password='" + LoginForm.PassL + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][0].ToString() == "Admin")
                {
                    WelcomeAdmin.Visible = true;
                    ManageAccount.Visible = true;
                }
                else
                {
                    ManageAccount.Visible = false;
                    WelcomeAdmin.Visible = false;
                }
            }
        }
        private void BtnCdsAttPortal_Click(object sender, EventArgs e)
        {
            ColorChange(BtnCdsAttPortal);
            ControlChange(ucCDSVerifier1);
        }

        private void BtnRegCorp_Click(object sender, EventArgs e)
        {
            ColorChange(BtnRegCorp);
            ControlChange(ucRegisterCorpMember1);
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void ManageAccount_Click(object sender, EventArgs e)
        {
            ColorChange(ManageAccount); 
            ControlChange(admin_Account_Panel1);
        }
    }
}
