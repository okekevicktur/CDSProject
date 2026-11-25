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
using Bunifu.Framework.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CDSProject
{
    public partial class UcCDSReport : UserControl
    {
        readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");

        public UcCDSReport()
        {
            InitializeComponent();
        }

        private void UcCDSReport_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            CustomPicker();
            LoadData();
        }
        private void ColorChange(Button btn)
        {
            //103, 192, 136 mo
            // 36, 129, 77
            MonthlyReportBtn.BackColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            MonthlyReportBtn.ForeColor = Color.White;
            GeneralReportBtn.BackColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            GeneralReportBtn.ForeColor = Color.White;
            SearchCorpBtn.BackColor = Color.FromArgb(((byte)(47)), ((int)(((byte)(133)))), ((int)(((byte)(60)))));
            SearchCorpBtn.ForeColor = Color.White;
            btn.BackColor = Color.White;
            btn.ForeColor =  Color.FromArgb(((byte)(36)), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
           

            //MonthlyReportBtn.BackColor = Color.White;
            //MonthlyReportBtn.ForeColor = Color.FromArgb(((byte)(103)), ((int)(((byte)(192)))), ((int)(((byte)(136)))));
            //GeneralReportBtn.BackColor = Color.White;
            //GeneralReportBtn.ForeColor = Color.FromArgb(((byte)(103)), ((int)(((byte)(192)))), ((int)(((byte)(136)))));
            //SearchCorpBtn.BackColor = Color.White;
            //SearchCorpBtn.ForeColor = Color.FromArgb(((byte)(103)), ((int)(((byte)(192)))), ((int)(((byte)(136)))));
            //btn.BackColor = Color.FromArgb(((byte)(36)), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            //btn.ForeColor = Color.White;

        }
        public void CustomPicker()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM yyyy";
        }
        public void LoadData()
        {
            try
            {
                string selectQuery = "SELECT * FROM TransactAttendance where date='" + dateTimePicker2.Value.ToString("MM/dd/yy") + "' ";

                SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQuery, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                // labelTot.Text = dt.Rows.Count.ToString();
                gridview.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = gridview.Rows.Add();
                        // DataGridStudent_info.Rows[n].Cells[0].Value = item["id"].ToString();
                        gridview.Rows[n].Cells[0].Value = (n + 1).ToString();
                        gridview.Rows[n].Cells[1].Value = item["name"].ToString();
                        gridview.Rows[n].Cells[2].Value = item["date"].ToString();

                    }
                    //datagridTotal();
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
        public void Trial()
        {

            string final = "SELECT * FROM TransactAttendance  ";// HAVING COUNT(*)>1";

            SQLiteDataAdapter sdafin = new SQLiteDataAdapter(final, con);
            DataTable dtdfin = new DataTable();
            sdafin.Fill(dtdfin);
            DataGridgen.Rows.Clear();
            foreach (DataRow item3 in dtdfin.Rows)
            {

                int n = DataGridgen.Rows.Add();

                DataGridgen.Rows[n].Cells[0].Value = (n + 1).ToString();
                DataGridgen.Rows[n].Cells[1].Value = item3["name"].ToString();
                DataGridgen.Rows[n].Cells[2].Value = item3["statecode"].ToString();

                int times;
                //////JAN////
                ///
                ///
                if (item3["Jan"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Jan"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[3].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[3].Value = "0%";
                    DataGridgen.Rows[n].Cells[3].Style.ForeColor = Color.Red;
                }
                ///Feb///
                ///
                ///

                if (item3["Feb"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Feb"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[4].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[4].Value = "0%";
                    DataGridgen.Rows[n].Cells[4].Style.ForeColor = Color.Red;
                }
                ///
                ///March
                ///

                if (item3["Mar"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Mar"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[5].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[5].Value = "0%";
                    DataGridgen.Rows[n].Cells[5].Style.ForeColor = Color.Red;
                }
                //APr////
                ///
                ///

                if (item3["Apr"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Apr"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[6].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[6].Value = "0%";
                    DataGridgen.Rows[n].Cells[6].Style.ForeColor = Color.Red;
                }


                ///MAY///
                ///
                if (item3["May"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["May"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[7].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[7].Value = "0%";
                    DataGridgen.Rows[n].Cells[7].Style.ForeColor = Color.Red;
                }
                //JUNN///

                ///
                if (item3["Jun"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Jun"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[8].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[8].Value = "0%";
                    DataGridgen.Rows[n].Cells[8].Style.ForeColor = Color.Red;
                }
                //JUl///

                ///
                if (item3["Jul"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Jul"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[9].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[9].Value = "0%";
                    DataGridgen.Rows[n].Cells[9].Style.ForeColor = Color.Red;
                }

                //AUG///

                ///
                if (item3["Aug"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Aug"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[10].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[10].Value = "0%";
                    DataGridgen.Rows[n].Cells[10].Style.ForeColor = Color.Red;
                }

                //Sep///

                ///
                if (item3["Sep"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Sep"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[11].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[11].Value = "0%";
                    DataGridgen.Rows[n].Cells[11].Style.ForeColor = Color.Red;
                }

                //Oct///

                ///
                if (item3["Oct"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Oct"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[12].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[12].Value = "0%";
                    DataGridgen.Rows[n].Cells[12].Style.ForeColor = Color.Red;
                }
                //Nov///

                ///
                if (item3["Nov"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Nov"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[13].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[13].Value = "0%";
                    DataGridgen.Rows[n].Cells[13].Style.ForeColor = Color.Red;
                }

                //Dec///

                ///
                if (item3["Dec"].ToString() != string.Empty)
                {
                    times = Convert.ToInt32(item3["Dec"]);
                    times = times * 25;
                    DataGridgen.Rows[n].Cells[14].Value = times + "%";
                }
                else
                {
                    DataGridgen.Rows[n].Cells[14].Value = "0%";
                    DataGridgen.Rows[n].Cells[14].Style.ForeColor = Color.Red;
                }

                #region
                //DataGridgen.Rows[n].Cells[3].Value = item3["Jan"].ToString();
                //DataGridgen.Rows[n].Cells[4].Value = item3["Feb"].ToString();
                //DataGridgen.Rows[n].Cells[5].Value = item3["Mar"].ToString();
                //DataGridgen.Rows[n].Cells[6].Value = item3["Apr"].ToString();
                //DataGridgen.Rows[n].Cells[7].Value = item3["May"].ToString();
                //DataGridgen.Rows[n].Cells[8].Value = item3["Jun"].ToString();
                //DataGridgen.Rows[n].Cells[9].Value = item3["Jul"].ToString();
                //DataGridgen.Rows[n].Cells[10].Value = item3["Aug"].ToString();
                //DataGridgen.Rows[n].Cells[11].Value = item3["Sep"].ToString();
                //DataGridgen.Rows[n].Cells[12].Value = item3["Oct"].ToString();
                //DataGridgen.Rows[n].Cells[13].Value = item3["Nov"].ToString();
                //DataGridgen.Rows[n].Cells[14].Value = item3["Dec"].ToString();
                #endregion

            }
            DataGridgen.ClearSelection();

        }



        private void MonthlyReportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ColorChange(MonthlyReportBtn);
                panel3.Dock = DockStyle.Fill; 
                SearchBox.Visible = false; 
                panel3.BringToFront(); 
                panel3.Visible = true;
                panel2.Visible = false;
                //string select1 = "SELECT * FROM TransactAttendance where date like '%" + dateTimePicker1.Value.ToString("MMM/yyyy") + "%' ";
                //string selectQuery = "SELECT surname,firstname, course,Mat_No,level,Profile_pic,stdID, COUNT(*) AttendanceCount  FROM TransactAttendance GROUP BY surname,firstname, course,Mat_No,level,Profile_pic,stdID ";// HAVING COUNT(*)>1";
                string monthname = dateTimePicker2.Value.ToString("MMM").ToString();
                string selectQ = "SELECT * FROM TransactAttendance  ";// HAVING COUNT(*)>1";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQ, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gridview.Rows.Clear();
                // labelTot.Text = dt.Rows.Count.ToString();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = gridview.Rows.Add();
                        // DataGridStudent_info.Rows[n].Cells[0].Value = item["id"].ToString();
                        gridview.Rows[n].Cells[0].Value = (n + 1).ToString();
                        gridview.Rows[n].Cells[1].Value = item["name"].ToString();
                        gridview.Rows[n].Cells[2].Value = item["statecode"].ToString();

                        int times;

                        if (item[monthname].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item[monthname]);
                            times = times * 25;
                            gridview.Rows[n].Cells[3].Value = times + "%";
                        }
                        else
                        {
                            gridview.Rows[n].Cells[3].Value = "0%";
                            gridview.Rows[n].Cells[3].Style.ForeColor = Color.Red;
                        }


                    }
                    gridview.ClearSelection();
                }
                else
                {
                    MessageBox.Show("No Search Result", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GeneralReportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ColorChange(GeneralReportBtn);
                panel2.BringToFront();
                panel2.Dock = DockStyle.Fill;
                SearchBox.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                Trial();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchCorpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ColorChange(SearchCorpBtn);
                panel2.Dock = DockStyle.Fill;
                panel2.BringToFront();
                panel2.Visible = true;
                SearchBox.Visible = true;
                panel3.Visible = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchCorp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != string.Empty)
                {
                    string final = "SELECT * FROM TransactAttendance where statecode like '%" + txtSearch.Text + "%' Or name like '%" + txtSearch.Text + "%' ";// HAVING COUNT(*)>1";

                    SQLiteDataAdapter sdafin = new SQLiteDataAdapter(final, con);
                    DataTable dtdfin = new DataTable();
                    sdafin.Fill(dtdfin);
                    DataGridgen.Rows.Clear();
                    foreach (DataRow item3 in dtdfin.Rows)
                    {
                        int n = DataGridgen.Rows.Add();

                        DataGridgen.Rows[n].Cells[0].Value = (n + 1).ToString();
                        DataGridgen.Rows[n].Cells[1].Value = item3["name"].ToString();
                        DataGridgen.Rows[n].Cells[2].Value = item3["statecode"].ToString();

                        int times;
                        //////JAN////
                        ///
                        ///
                        if (item3["Jan"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Jan"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[3].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[3].Value = "0%";
                            DataGridgen.Rows[n].Cells[3].Style.ForeColor = Color.Red;
                        }
                        ///Feb///
                        ///
                        ///

                        if (item3["Feb"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Feb"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[4].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[4].Value = "0%";
                            DataGridgen.Rows[n].Cells[4].Style.ForeColor = Color.Red;
                        }
                        ///
                        ///March
                        ///

                        if (item3["Mar"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Mar"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[5].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[5].Value = "0%";
                            DataGridgen.Rows[n].Cells[5].Style.ForeColor = Color.Red;
                        }
                        //APr////
                        ///
                        ///

                        if (item3["Apr"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Apr"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[6].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[6].Value = "0%";
                            DataGridgen.Rows[n].Cells[6].Style.ForeColor = Color.Red;
                        }


                        ///MAY///
                        ///
                        if (item3["May"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["May"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[7].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[7].Value = "0%";
                            DataGridgen.Rows[n].Cells[7].Style.ForeColor = Color.Red;
                        }
                        //JUNN///

                        ///
                        if (item3["Jun"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Jun"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[8].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[8].Value = "0%";
                            DataGridgen.Rows[n].Cells[8].Style.ForeColor = Color.Red;
                        }
                        //JUl///

                        ///
                        if (item3["Jul"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Jul"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[9].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[9].Value = "0%";
                            DataGridgen.Rows[n].Cells[9].Style.ForeColor = Color.Red;
                        }

                        //AUG///

                        ///
                        if (item3["Aug"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Aug"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[10].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[10].Value = "0%";
                            DataGridgen.Rows[n].Cells[10].Style.ForeColor = Color.Red;
                        }

                        //Sep///

                        ///
                        if (item3["Sep"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Sep"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[11].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[11].Value = "0%";
                            DataGridgen.Rows[n].Cells[11].Style.ForeColor = Color.Red;
                        }

                        //Oct///

                        ///
                        if (item3["Oct"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Oct"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[12].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[12].Value = "0%";
                            DataGridgen.Rows[n].Cells[12].Style.ForeColor = Color.Red;
                        }
                        //Nov///

                        ///
                        if (item3["Nov"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Nov"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[13].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[13].Value = "0%";
                            DataGridgen.Rows[n].Cells[13].Style.ForeColor = Color.Red;
                        }

                        //Dec///

                        ///
                        if (item3["Dec"].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item3["Dec"]);
                            times = times * 25;
                            DataGridgen.Rows[n].Cells[14].Value = times + "%";
                        }
                        else
                        {
                            DataGridgen.Rows[n].Cells[14].Value = "0%";
                            DataGridgen.Rows[n].Cells[14].Style.ForeColor = Color.Red;
                        }
                    }
                    DataGridgen.ClearSelection();
                }
                else
                {
                    MessageBox.Show("You can Search Corps Member with their State Code or Name", "CDS TRACKER ALERT!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
              

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchMonth_Click(object sender, EventArgs e)
        {
            try
            {
                //string select1 = "SELECT * FROM TransactAttendance where date like '%" + dateTimePicker1.Value.ToString("MMM/yyyy") + "%' ";
                //string selectQuery = "SELECT surname,firstname, course,Mat_No,level,Profile_pic,stdID, COUNT(*) AttendanceCount  FROM TransactAttendance GROUP BY surname,firstname, course,Mat_No,level,Profile_pic,stdID ";// HAVING COUNT(*)>1";
                string monthname = dateTimePicker2.Value.ToString("MMM").ToString();
                string selectQ = "SELECT * FROM TransactAttendance  ";// HAVING COUNT(*)>1";
                SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQ, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gridview.Rows.Clear();
                // labelTot.Text = dt.Rows.Count.ToString();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = gridview.Rows.Add();
                        // DataGridStudent_info.Rows[n].Cells[0].Value = item["id"].ToString();
                        gridview.Rows[n].Cells[0].Value = (n + 1).ToString();
                        gridview.Rows[n].Cells[1].Value = item["name"].ToString();
                        gridview.Rows[n].Cells[2].Value = item["statecode"].ToString();

                        int times;

                        if (item[monthname].ToString() != string.Empty)
                        {
                            times = Convert.ToInt32(item[monthname]);
                            times = times * 25;
                            gridview.Rows[n].Cells[3].Value = times + "%";
                        }
                        else
                        {
                            gridview.Rows[n].Cells[3].Value = "0%";
                            gridview.Rows[n].Cells[3].Style.ForeColor = Color.Red;
                        }


                    }
                    gridview.ClearSelection();
                }
                else
                {
                    MessageBox.Show("No Search Result", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void BtnSearchGen_Click(object sender, EventArgs e)
        {
            Trial();
        }

        private void MonthlyReportDownload_Click(object sender, EventArgs e)
        {
            if (DataGridgen.RowCount != 0)
            {

                ExportgridtoPDF(DataGridgen, dateTimePicker1.Value.ToString("MMM").ToString() + " General Report");
            }
            else
            {
                MessageBox.Show("No Record Exist", "CDS Tracker Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void ExportgridtoPDF(DataGridView dgrv, string filename)
        {
            try
            {
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable pdftable = new PdfPTable(dgrv.Columns.Count);
                pdftable.DefaultCell.Padding = 3;
                pdftable.TotalWidth = 1500f;
                //pdftable.LockedWidth = true;
                float[] widths = new float[] { 50f, 250f, 150f, 70f, 70f, 70f, 70f, 70f, 70f, 70f, 70f, 70f, 70f, 70f, 70f };
                pdftable.SetWidths(widths);
                pdftable.WidthPercentage = 100;
                pdftable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                // pdftable.DefaultCell.BorderWidth = 1;

                //Add Title
                PdfPCell cell;

                iTextSharp.text.Font ColFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, new iTextSharp.text.BaseColor(52, 174, 100));

                Chunk chunkcol = new Chunk(" GENERAL REPORT", ColFont);
                cell = new PdfPCell(new Paragraph(chunkcol));
                cell.Colspan = dgrv.Columns.Count;
                cell.Padding = 5;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdftable.AddCell(cell);
                pdftable.HeaderRows = 4;


                //Add Header
                foreach (DataGridViewColumn column in dgrv.Columns)
                {
                    iTextSharp.text.Font text1 = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(255, 255, 255));
                    // PdfPCell CellActext = new PdfPCell(new Phrase(new Chunk("Name", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GREEN))));
                    PdfPCell cell1 = new PdfPCell(new Phrase(column.HeaderText, text1));
                    cell1.BackgroundColor = new iTextSharp.text.BaseColor(52, 174, 100);
                    pdftable.AddCell(cell1);
                    // cell1.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);// BaseColor.WHITE;
                }
                pdftable.HeaderRows = 1;
                //Add datarow

                //Table Row Content
                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                for (int i = 0; i < dgrv.Rows.Count; i++)
                {
                    for (int k = 0; k < dgrv.Columns.Count; k++)
                    {//exclude cells in these  Columns

                        if (dgrv[k, i].Value != null)
                        {
                            pdftable.AddCell(new Phrase(dgrv[k, i].Value.ToString(), text));

                        }
                        else
                        {
                            pdftable.AddCell(new Phrase(""));
                        }
                    }

                }

                var savefiledialogue = new SaveFileDialog();
                savefiledialogue.FileName = filename;
                savefiledialogue.DefaultExt = ".pdf";
                savefiledialogue.Filter = "Pdf Files (*.pdf)|*.pdf";
                if (savefiledialogue.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialogue.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                        pdfdoc.Add(pdftable);
                        pdfdoc.Close();
                        stream.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void DownloadPdf_Click(object sender, EventArgs e)
        {
            if (gridview.RowCount != 0)
            {

                ExportMonthlygridtoPDF(gridview, dateTimePicker2.Value.ToString("MMM").ToString() + " Report");
            }
            else
            {
                MessageBox.Show("No Record Exist", "CDS Tracker Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void ExportMonthlygridtoPDF(DataGridView dgrv, string filename)
        {
            try
            {
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable pdftable = new PdfPTable(dgrv.Columns.Count);
                pdftable.DefaultCell.Padding = 3;
                pdftable.TotalWidth = 1000f;
                //pdftable.LockedWidth = true;
                float[] widths = new float[] { 40f, 400f, 200f, 120f };
                pdftable.SetWidths(widths);
                pdftable.WidthPercentage = 100;
                pdftable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                // pdftable.DefaultCell.BorderWidth = 1;

                //Add Title
                PdfPCell cell;

                iTextSharp.text.Font ColFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, new iTextSharp.text.BaseColor(52, 174, 100));

                Chunk chunkcol = new Chunk(dateTimePicker2.Value.ToString("MMM").ToString() + " Report", ColFont);
                cell = new PdfPCell(new Paragraph(chunkcol));
                cell.Colspan = dgrv.Columns.Count;
                cell.Padding = 5;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdftable.AddCell(cell);
                pdftable.HeaderRows = 4;


                //Add Header
                foreach (DataGridViewColumn column in dgrv.Columns)
                {
                    iTextSharp.text.Font text1 = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(255, 255, 255));
                    // PdfPCell CellActext = new PdfPCell(new Phrase(new Chunk("Name", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GREEN))));
                    PdfPCell cell1 = new PdfPCell(new Phrase(column.HeaderText, text1));
                    cell1.BackgroundColor = new iTextSharp.text.BaseColor(52, 174, 100);
                    pdftable.AddCell(cell1);
                    // cell1.BorderColor = new iTextSharp.text.BaseColor(255, 255, 255);// BaseColor.WHITE;
                }
                pdftable.HeaderRows = 1;
                //Add datarow

                //Table Row Content
                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                for (int i = 0; i < dgrv.Rows.Count; i++)
                {
                    for (int k = 0; k < dgrv.Columns.Count; k++)
                    {//exclude cells in these  Columns

                        if (dgrv[k, i].Value != null)
                        {
                            pdftable.AddCell(new Phrase(dgrv[k, i].Value.ToString(), text));

                        }
                        else
                        {
                            pdftable.AddCell(new Phrase(""));
                        }
                    }

                }

                var savefiledialogue = new SaveFileDialog();
                savefiledialogue.FileName = filename;
                savefiledialogue.DefaultExt = ".pdf";
                savefiledialogue.Filter = "Pdf Files (*.pdf)|*.pdf";
                if (savefiledialogue.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialogue.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                        pdfdoc.Add(pdftable);
                        pdfdoc.Close();
                        stream.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string dissallowedChars = @"\.<,>?;`:'][}{=+_)(*&^~!#@$%|";

                //check if dissalowed char is entered
                if (dissallowedChars.Contains(e.KeyChar))
                {
                    e.Handled = true;

                    //MessageBox.Show("phonenumbers must be numerical digits only");
                    //lecPhonenum.BackColor = Color.Red;
                    txtSearch.ForeColor = Color.Red;
                    //lecPhonenum.ForeColor = Color.White;
                }
                //if char entered is numbers
                else
                {
                    txtSearch.BackColor = Color.White;
                    txtSearch.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
