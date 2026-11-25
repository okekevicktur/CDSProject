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
    public partial class FormAdminConfirm : Form
    {
        readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");

        public FormAdminConfirm()
        {
            InitializeComponent();
        }
        public void unsaveSettings()
        {
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.password = string.Empty;
            Properties.Settings.Default.Save();
        }
        private void SignIn_Click(object sender, EventArgs e)
        {
            try
            {
                
                SQLiteDataAdapter sda = new SQLiteDataAdapter("select role, password from logDetail where role = '" + "Admin" + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == "Admin" && dt.Rows[0][1].ToString() == txtPassword.Text )
                    {
                        string txtQuery = ("DELETE FROM logDetail WHERE role='" + "Admin" + "' and password='" + txtPassword.Text + "'");
                        using (SQLiteCommand dbcmd = new SQLiteCommand(txtQuery, con))
                        {
                            dbcmd.ExecuteNonQuery();
                        }                   
                        MessageBox.Show("Admin Deleted Successfully", "CDS Attendance Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        unsaveSettings();
                        this.Close();
                        Application.Restart();
                    }
                    else if (dt.Rows[0][1].ToString() != txtPassword.Text)
                    {
                        MessageBox.Show("Incorrect Password", "CDS Attendance Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,  "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAdminConfirm_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();
        }
    }
}
