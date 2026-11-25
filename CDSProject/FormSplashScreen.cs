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
    public partial class FormSplashScreen : Form
    {
        public FormSplashScreen()
        {
            InitializeComponent();
            //142, 233, 176
            //103,192,136
            //this.BackColor = Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(233)))), ((int)(((byte)(176)))));
            //this.BackColor = Color.MediumOrchid;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            //this.BackColor = Color.Black;
            //this.TransparencyKey = Color.Black;
        }
    }
}
