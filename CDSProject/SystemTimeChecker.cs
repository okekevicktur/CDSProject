using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSProject
{
    public partial class SystemTimeChecker : Form
    {
        public SystemTimeChecker()
        {
            InitializeComponent();
        }

        private void SystemTimeChecker_Load(object sender, EventArgs e)
        {
            
            DateTime date= DateTime.Now;
            labDate.Text = date.ToString();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text: "Change the timezone to (UTC + 01) West Central African", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);


            System.Diagnostics.Process.Start("timedate.cpl");
            // Application.Restart();
            this.Close();
            //Application.Restart();
        }
    }
}
