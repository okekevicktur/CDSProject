using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CDSProject
{
    public partial class Admin_Account_Panel : UserControl
    {
        readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");

        public Admin_Account_Panel()
        {
            InitializeComponent();
            LoadData();
        }


        public void LoadData()
        {
            try
            {
                //where role = '" + "User" + "'
                string selectQuery = "SELECT * FROM logDetail order by role ASC ";

                SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQuery, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gridview.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = gridview.Rows.Add();
                        // DataGridStudent_info.Rows[n].Cells[0].Value = item["id"].ToString();
                        gridview.Rows[n].Cells[0].Value = (n + 1).ToString();
                        gridview.Rows[n].Cells[1].Value = item["username"].ToString();
                       // gridview.Rows[n].Cells[2].Value = item["password"].ToString();
                        gridview.Rows[n].Cells[2].Value = item["role"].ToString();

                    }
                    gridview.ClearSelection();
                }
                else
                {
                    //MessageBox.Show("No Search Result", "FAMS Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Admin_Account_Panel_Load(object sender, EventArgs e)
        {
            if(con.State== ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();
            LoadData();
        }

        private void BtnDelUser_Click(object sender, EventArgs e)
        {
            try
            {
                 if (gridview.RowCount != 0 && gridview.SelectedRows.Count==1)
                 {
                    
                    string idUser = gridview.SelectedRows[0].Cells[1].Value.ToString();
                    // string idpass = gridview.SelectedRows[0].Cells[2].Value.ToString();
                    string idrole = gridview.SelectedRows[0].Cells[2].Value.ToString();

                    //string removeVolCred = "DELETE FROM TableName WHERE ID = " + idLocRemv;

                    if (idrole == "Admin")
                    {
                        DialogResult Admindialog = MessageBox.Show("Admin Control will be lost if this account is deleted. \n Do you want to continue delete?", "CDS Attendance Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (Admindialog == DialogResult.Yes)
                        {
                            FormAdminConfirm adminConfirm = new FormAdminConfirm();
                            adminConfirm.ShowDialog();

                        }
                        else
                        {
                            return;
                        }
                        LoadData();
                    }
                    else
                    {
                        DialogResult Admindialog = MessageBox.Show("This User  would lose Login Privileges. \n Do you want to continue delete?", "CDS Attendance Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (Admindialog == DialogResult.Yes)
                        {

                            string txtQuery = ("DELETE FROM logDetail WHERE username='" + idUser + "' ");
                            using (SQLiteCommand dbcmd = new SQLiteCommand(txtQuery, con))
                            {
                                dbcmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("User Deleted Successfully", "CDS Attendance Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                else if(gridview.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please, Select User to delete", "CDS Attenance Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
