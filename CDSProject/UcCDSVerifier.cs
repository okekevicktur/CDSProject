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
using DPFP;
using DPFP.Capture;
using System.IO;

namespace CDSProject
{

    public partial class UcCDSVerifier : UserControl,DPFP.Capture.EventHandler
    {
        readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");
        public UcCDSVerifier()
        {
            InitializeComponent();
        }

        private void UcCDSVerifier_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                dateTimePicker1.Value = DateTime.Now;
                Rowcall();
                SelectRow();
                Summary();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Rowcall()
        {
            try
            {

                string selectQuery = "SELECT surname,corpName,otherName FROM CorpData order by surname ";// HAVING COUNT(*)>1";

                SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQuery, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                rowcalltable.Rows.Clear();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow item in dt.Rows)
                    {
                        int n = rowcalltable.Rows.Add();
                        string Corpfullname = item["surname"].ToString() + " " + item["corpName"].ToString() + " " + item["otherName"].ToString();
                        rowcalltable.Rows[n].Cells[0].Value = Corpfullname;
                        rowcalltable.Rows[n].Cells[0].Style.ForeColor = Color.Black;

                    }
                    rowcalltable.ClearSelection();
                }
                else
                {
                    MessageBox.Show("No Report Exist yet for this course", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is :" + ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SelectRow()
        {

            string final = "Select * from TransactAttendance WHERE date='" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' ";//Select fingerprint from db for verification
            SQLiteDataAdapter sdafin = new SQLiteDataAdapter(final, con);
            DataTable dtdfin = new DataTable();
            sdafin.Fill(dtdfin);


            foreach (DataGridViewRow row in rowcalltable.Rows)
            {
                foreach (DataRow item3 in dtdfin.Rows)
                {
                    string fullnames = item3["name"].ToString();

                    if (row.Cells["corpHeader"].Value.ToString() == fullnames)
                    {
                        row.Cells["corpHeader"].Style.BackColor = Color.Green;
                        row.Cells["corpHeader"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        //  row.Cells["corpHeader"].Style.BackColor = Color.Gray;
                    }
                }
                rowcalltable.ClearSelection();
            }
        }

        public void Summary()
        {
            string selectQuery = "SELECT * FROM CorpData";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string corpDataCount = dt.Rows.Count.ToString();

            //<-------Attendance Count--------->
            string final = "Select * from TransactAttendance WHERE date='" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' ";
            SQLiteDataAdapter sdafin = new SQLiteDataAdapter(final, con);
            DataTable dtdfin = new DataTable();
            sdafin.Fill(dtdfin);
            string attDataCount = dtdfin.Rows.Count.ToString();
            labSummary.Text = String.Format("{0} of {1} Candidates Verified (Check Out)", attDataCount, corpDataCount);

            //////


        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVerifier.Text != string.Empty)
                {
                    string selectQuery = "SELECT stateCode,callupNo FROM CorpData where stateCode='" + txtVerifier.Text + "' or callupNo='" + txtVerifier.Text + "' ";

                    SQLiteDataAdapter sda = new SQLiteDataAdapter(selectQuery, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Corp Member Exist", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Corp Member Doesn't Exist in this CDS", "CDS TRACKER ALERT!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("You can verify with State Code or Callup Number", "CDS TRACKER ALERT!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is :" + ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        
        /// <summary>
        /// Fingerprint EventHandlers
        /// </summary>
        /// <param name="Capture"></param>
        /// <param name="ReaderSerialNumber"></param>
        /// <param name="Sample"></param>
        #region
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            try
            {
                MakeReport("The fingerprint sample was captured.");
                SetPrompt("Scan the same fingerprint again.");
                Process(Sample);
                Verify(Template);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("The finger was removed from the fingerprint reader.");
                Verify(Template);
                Verificator = new DPFP.Verification.Verification(); // Create a fingerprint template verificator
                UpdateStatus(0);
            }
            catch (Exception)
            {

                throw;
            }    
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("The fingerprint reader was touched.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("The fingerprint reader was connected.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("The fingerprint reader was disconnected.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            try
            {
                if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                    MakeReport("The quality of the fingerprint sample is good.");
                else
                    MakeReport("The quality of the fingerprint sample is poor.");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        /// <summary>
        /// Fingerprint Module Parameters and Field
        /// </summary>
        /// <param name="Capture"></param>
        /// <param name="ReaderSerialNumber"></param>
        /// <param name="Sample"></param>
        #region
        delegate void Function(); // a simple delegate for marshalling calls from event handlers to the GUI thread
        private DPFP.Template Template;
        private DPFP.Capture.Capture Capturer;
        public void Verify(DPFP.Template template)
        {
            Template = template;

        }
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        private DPFP.Verification.Verification Verificator;

        // public event OnTemplateEventHandler OnTemplate;
        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    SetPrompt("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }
        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't terminate capture!");
                }
            }
        }
        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate ()
            {
                StatusLine.Text = status;
            }));
        }
        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate ()
            {
                Prompt.Text = prompt;
            }));
        }
        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }
        protected void MakeReport(string message)
        {
            this.Invoke(new Function(delegate ()
            {
                StatusText.AppendText(message + "\r\n");
            }));
        }
        private void DrawPicture(Bitmap bitmap)
        {

            pictureBox2.Image = new Bitmap(bitmap, pictureBox2.Size);	// fit the image into the picture box

        }
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        private string Dtid { get; set; }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }
        protected virtual void ProcessMain(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }
        protected void Process(DPFP.Sample Sample)
        {
            try
            {
                string vquery = "Select * from fingerprint order by Id";//Select fingerprint from db for verification
                SQLiteDataAdapter sda = new SQLiteDataAdapter(vquery, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    byte[] _img = (byte[])dr["fingerPrint"];
                    MemoryStream ms = new MemoryStream(_img);
                    DPFP.Template Template = new DPFP.Template();
                    Template.DeSerialize(ms);
                    DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();

                    ProcessMain(Sample);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                    // Check quality of the sample and start verification if it's good
                    // TODO: move to a separate task
                    if (features != null)
                    {
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        // Compare the feature set with our template     
                        Verificator.Verify(features, Template, ref result);
                        UpdateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            Dtid = dr["corpId"].ToString();
                            //#region if fingerprint is verified
                            this.Invoke(new Function(delegate ()
                            {
                                dateTimePicker1.Value = DateTime.Now;
                            }));
                            string DupAtt = "Select * from TransactAttendance WHERE date='" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and stdId='" + Dtid + "'";//Select fingerprint from db for verification
                            SQLiteDataAdapter sdaDup = new SQLiteDataAdapter(DupAtt, con);
                            DataTable dtdup = new DataTable();
                            sdaDup.Fill(dtdup);
                            //MessageBox.Show(dtdup.Rows.Count.ToString());
                            if (dtdup.Rows.Count > 0)
                            {
                                #region  //CHeck if Already taken attendance
                                MakeReport("ATTENDANCE ALREADY TAKEN.");
                                this.Invoke(new Function(delegate ()
                                {

                                    string query = "Select * From CorpData where Id='" + Dtid + "'";
                                    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(query, con);
                                    DataTable stdTab = new DataTable();
                                    Adapter.Fill(stdTab);
                                    foreach (DataRow item in stdTab.Rows)
                                    {
                                        string avatar = item["passport"].ToString();
                                        pictureBox3.Image = Image.FromFile(Path.Combine(avatar));

                                        txtSurname.Text = item["surname"].ToString(); txtOthername.Text = item["otherName"].ToString();
                                        txtCallno.Text = item["callupNo"].ToString(); txtfirstname.Text = item["corpName"].ToString();
                                        txtstatcode.Text = item["stateCode"].ToString(); txtPhoneNo.Text = item["phoneNumber"].ToString();

                                    }
                                    panel4.Visible = true;
                                    MessageBox.Show("ATTENDANCE ALREADY TAKEN", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Rowcall();
                                    SelectRow();
                                    Summary();
                                }));
                                // return;
                                #endregion
                            }
                            else
                            {

                                // MessageBox.Show(dtid);
                                string att = "Select * from TransactAttendance WHERE stdId='" + Dtid + "'";//Select fingerprint from db for verification
                                SQLiteDataAdapter sdatt = new SQLiteDataAdapter(att, con);
                                DataTable dtatt = new DataTable();
                                sdatt.Fill(dtatt);
                                //MessageBox.Show(dtdup.Rows.Count.ToString());
                                if (dtatt.Rows.Count > 0)
                                {
                                    #region // if it Exist and needs to be updated
                                    this.Invoke(new Function(delegate ()
                                    {

                                        string que = "Select * From CorpData where Id='" + Dtid + "'";
                                        SQLiteDataAdapter Adapt = new SQLiteDataAdapter(que, con);
                                        DataTable std = new DataTable();
                                        Adapt.Fill(std);
                                        foreach (DataRow itm in std.Rows)
                                        {
                                            string avatar = itm["passport"].ToString();
                                            pictureBox3.Image = Image.FromFile(Path.Combine(avatar));

                                            txtSurname.Text = itm["surname"].ToString(); txtOthername.Text = itm["otherName"].ToString();
                                            txtCallno.Text = itm["callupNo"].ToString(); txtfirstname.Text = itm["corpName"].ToString();
                                            txtstatcode.Text = itm["stateCode"].ToString(); txtPhoneNo.Text = itm["phoneNumber"].ToString();


                                            string fullname = txtSurname.Text + " " + txtfirstname.Text + " " + txtOthername.Text;
                                            foreach (DataRow items in dtatt.Rows)
                                            {
                                                int times;
                                                if (items[dateTimePicker1.Value.ToString("MMM")].ToString() != string.Empty)
                                                {
                                                    if (Convert.ToInt32( items[dateTimePicker1.Value.ToString("MMM")]) < 3)
                                                    {
                                                        times = Convert.ToInt32(items[dateTimePicker1.Value.ToString("MMM")]);

                                                        times = times + 1;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Monthly Attendance is Exceeded. "+ "\r\n"+ "Recticfy with Admin", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Rowcall();
                                                        SelectRow();
                                                        Summary();
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    times = 1;
                                                }
                                                string insertTransac = "Update  TransactAttendance SET date='" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "','" + dateTimePicker1.Value.ToString("MMM") + "'= '" + times + "' where name='" + fullname + "'";
                                                SQLiteCommand commandTransac = new SQLiteCommand(insertTransac, con);
                                                if (commandTransac.ExecuteNonQuery() == 1)
                                                {




                                                    this.Invoke(new Function(delegate ()
                                                    {
                                                        panel4.Visible = true;

                                                        Rowcall();
                                                        SelectRow();
                                                        MessageBox.Show("Attendance successfully Taken", "CDS Tracker Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Summary();
                                                    }));

                                                }
                                            }

                                        }
                                        panel4.Visible = true;

                                    }));


                                    //return;
                                    #endregion
                                }
                                else
                                {

                                    MakeReport("The fingerprint was VERIFIED.");
                                    #region               ///Display Student Picture

                                    ///Display Student Picture

                                    string query = "Select * From CorpData where Id='" + Dtid + "'";
                                    SQLiteDataAdapter Adapter = new SQLiteDataAdapter(query, con);
                                    DataTable stdTab = new DataTable();
                                    Adapter.Fill(stdTab);
                                    foreach (DataRow item in stdTab.Rows)
                                    {
                                        string avatar = item["passport"].ToString();
                                        pictureBox3.Image = Image.FromFile(Path.Combine(avatar));
                                        this.Invoke(new Function(delegate ()
                                        {
                                            txtSurname.Text = item["surname"].ToString(); txtOthername.Text = item["otherName"].ToString();
                                            txtCallno.Text = item["callupNo"].ToString(); txtfirstname.Text = item["corpName"].ToString();
                                            txtstatcode.Text = item["stateCode"].ToString(); txtPhoneNo.Text = item["phoneNumber"].ToString();
                                            panel4.Visible = true;
                                        }));
                                        string fullnames = txtSurname.Text + " " + txtfirstname.Text + " " + txtOthername.Text;
                                        // loopmonth();
                                       
                                        string insertTransac = "INSERT INTO TransactAttendance  (date,name,statecode,stdId,'" + dateTimePicker1.Value.ToString("MMM") + "') VALUES ('" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "','" + fullnames + "','" + txtstatcode.Text + "','" + Dtid + "','" + +1 + "')";
                                        SQLiteCommand commandTransac = new SQLiteCommand(insertTransac, con);
                                        if (commandTransac.ExecuteNonQuery() == 1)
                                        {
                                            this.Invoke(new Function(delegate ()
                                            {
                                                MessageBox.Show("Attendance successfully Taken", "CDS Tracker Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Rowcall();
                                                SelectRow();
                                                Summary();
                                            }));

                                        }
                                    }
                                    //return;
                                    #endregion

                                }


                            }
                            return;

                        }
                        else
                        {

                            // MakeReport("The fingerprint was NOT VERIFIED.");
                            //this.Invoke(new Function(delegate()
                            //{
                            //    attSucc.Visible = false;
                            //    attTaken.Visible = false;
                            //    ntverified.Visible = true;
                            //}));
                            //return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        #endregion

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Init();
                Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void txtVerifier_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtVerifier.ForeColor = Color.Red;
                    //lecPhonenum.ForeColor = Color.White;
                }
                //if char entered is numbers
                else
                {
                    txtVerifier.BackColor = Color.White;
                    txtVerifier.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
