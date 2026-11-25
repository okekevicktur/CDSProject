using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using WindowsFormsControlLibrary1;

namespace CDSProject
{
    class ClearUtilities
    {
        public static void ResetAllFormControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                if (control is BunifuCustomTextbox )
                {
                    BunifuCustomTextbox txtbox = (BunifuCustomTextbox)control;
                    txtbox.Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    ComboBox combobox = (ComboBox)control;
                    if (combobox.Items.Count > 0)
                        combobox.SelectedIndex = -1;
                }
                else if (control is CheckBox)
                {
                    CheckBox checkbox = (CheckBox)control;
                    checkbox.Checked = false;
                }
                else if (control is ListBox)
                {
                    ListBox listbox = (ListBox)control;
                    listbox.ClearSelected();
                }
                else if (control is PictureBox)
                {
                    PictureBox picbox = (PictureBox)control;
                    picbox.Image = null;
                }
                else if (control is RadioButton)
                {
                    RadioButton radiobutton = (RadioButton)control;
                    radiobutton.Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtpk = (DateTimePicker)control;
                    dtpk.Value = DateTime.Now;
                }
                else if (control.HasChildren)
                {
                    foreach (Control child in control.Controls)
                    {
                        ResetAllFormControls(child);
                    }
                }
            }
        }

    
    }
}
