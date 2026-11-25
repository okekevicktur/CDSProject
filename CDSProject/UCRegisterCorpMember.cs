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
using System.IO;
using DPFP;
using DPFP.Capture;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Bunifu.Framework.UI;
using WindowsFormsControlLibrary1;
using System.Threading;
using System.Drawing.Imaging;

namespace CDSProject
{
    public partial class UCRegisterCorpMember : UserControl, DPFP.Capture.EventHandler
    {
      readonly SQLiteConnection con = new SQLiteConnection(@" Data Source=C:\Users\Pipper\source\repos\CDSProject\CDSDB.db; Integrated Security=True");
        
        public UCRegisterCorpMember()
        {
            InitializeComponent();
        }

        private void BtnAddCorp_Click(object sender, EventArgs e)
        {
           
            if (txtName.Text != "" && txtStatecode.Text != "" && txtCallup.Text != "" && txtSurname.Text != "" && txtothername.Text != "" && txtStream.Text != "" && txtYear.Text != "" && txtPhonenumber.Text != "" && txtBatch.Text != "")
            {
                string pathstring = "";
                if (txtPhonenumber.Text.Length < 11)
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "Phone number is incomplete";
                    label8.Visible = true;
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 5000;
                    timer.Tick += (source, E) =>
                    {
                        label8.Visible = false;
                        timer.Stop();
                    };
                    timer.Start();
                }

                else
                {
                    SQLiteCommand dbcmd = con.CreateCommand();


                    SQLiteDataAdapter sdac = new SQLiteDataAdapter("SELECT * FROM CorpData WHERE stateCode = '" + txtStatecode.Text + "' or callupNo = '" + txtCallup.Text + "'  ", con);
                    DataTable dtc = new DataTable();
                    sdac.Fill(dtc);

                    if (dtc.Rows.Count == 1)
                    {

                        MessageBox.Show("Sorry, this Corps member has already been registered", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }
                    else
                    {
                        string fname = txtName.Text+" "+txtSurname.Text + ".jpg";
                        string folder = "C:\\CDSAttendance\\CorpsMembers";
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                            pathstring = Path.Combine(folder, fname);
                            Image a = pictureBox1.Image;
                            a.Save(pathstring);
                        }
                        else
                        {
                            pathstring = Path.Combine(folder, fname);
                            Image a = pictureBox1.Image;
                            a.Save(pathstring);
                        }

                        dbcmd.CommandText = "INSERT INTO CorpData (corpName, surname, otherName, stateCode,callupNo,phoneNumber,passport,batch,stream,serviceYear) VALUES( @corpName,@surname,@otherName,@stateCode,@callupNo,@phoneNumber,@passport,@batch,@stream,@serviceYear)";
                        dbcmd.Parameters.AddWithValue("@corpName", txtName.Text);
                        dbcmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                        dbcmd.Parameters.AddWithValue("@otherName", txtothername.Text);
                        dbcmd.Parameters.AddWithValue("@stateCode", txtStatecode.Text);
                        dbcmd.Parameters.AddWithValue("@callupNo", txtCallup.Text);
                        dbcmd.Parameters.AddWithValue("@phoneNumber", txtPhonenumber.Text);
                        dbcmd.Parameters.AddWithValue("@passport", pathstring);
                        dbcmd.Parameters.AddWithValue("@batch", txtBatch.Text);
                        dbcmd.Parameters.AddWithValue("@stream", txtStream.Text);
                        dbcmd.Parameters.AddWithValue("@serviceYear", txtYear.Text);

                        dbcmd.ExecuteNonQuery();
                        // ExecuteQuery(txtquery1);
                        //loadData();
                        //disableStudent();
                        MessageBox.Show("Corp member is Successfully Added!", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // clearData();
                        //<<<<<FingerPrint section>>>>>>>>>>>>>    
                        //   StdName.Text = txt_Surname.Text + " " + txt_firstName.Text;
                        callupNo.Text = txtCallup.Text;
                        statecode.Text = txtStatecode.Text;
                        BtnstartCapture.Visible = true;
                        SearchBox.Visible = false;
                       // BtnstartCapture.Enabled = false;
                        //Btn_enroll.Enabled = true;
                        //btn_Save.Enabled = false;

                    }

                }

            }
            else
                         
            {
                MessageBox.Show(" Please provide appropriate details!", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //string Pathstring = "";
        string Chosen_file = "";

        private void BtnSelectPic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFD = new OpenFileDialog() { Filter = "JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png", ValidateNames = true, Multiselect = false };


                openFD.Title = "Insert an image ";
                openFD.InitialDirectory = "Pictures";
                //  openFD.FileName = txt_firstName.Text + txt_Surname.Text;

                if (openFD.ShowDialog() != DialogResult.Cancel)
                {
                    Chosen_file = openFD.FileName.ToString();
                    // LectProfPic.ImageLocation = chosen_file;
                    pictureBox1.Image = Image.FromFile(Chosen_file);
                }
                else
                {
                    MessageBox.Show("Operation cancelled !", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ex)
            {

                MessageBox.Show(ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void Clearcontrols()
        {
            //Control child;
            foreach (Control child in this.Controls)
            {
                ClearUtilities.ResetAllFormControls(child);
            }
            ClearUtilities.ResetAllFormControls(this);
            SearchBox.Visible = false;
            callupNo.Text = "                                ";
            statecode.Text = "                                ";
            label13.Location = new System.Drawing.Point(786, 365);
            Prompt.Location = new System.Drawing.Point(786, 387);
            label12.Location = new System.Drawing.Point(786, 412);
            StatusText.Location = new System.Drawing.Point(790, 434);
            
            //SearchBox.Location = new Point(815, 329);

        }

        #region ///Fingerprint Region

        /// <summary>
        ///  Biometric Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        delegate void Function(); // A simple delegate for Marshmalling calls from event handler to the GUI Thread

        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;

        private DPFP.Processing.Enrollment Enroller;

        private DPFP.Capture.Capture Capturer;


        private DPFP.Template Template;
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
        protected void MakeReport(string message)
        {
            this.Invoke(new Function(delegate ()
            {
                StatusText.AppendText(message + "\r\n");
            }));


        }
        private void UpdateStatus()
        {
            // Show number of samples needed.
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                {
                    Capturer.EventHandler = this;					// Subscribe for capturing events.

                }

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
        private void DrawPicture(Bitmap bitmap)
        {

            pictureBox2.Image = new Bitmap(bitmap, pictureBox2.Size);	// fit the image into the picture box                

        }
        private void onTemplateEnroll(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                //btn_Save.Enabled = Btn_back.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("The fingerprint has been enrolled", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Capturer.StopCapture();
                    Clearcontrols();
                    BtnstartCapture.Visible = false;
                }
                else
                    MessageBox.Show("The fingerprint is not Valid.", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }));
        }

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

        protected void Process(DPFP.Sample Sample)
        {
            try
            {
                ProcessMain(Sample);

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

                // Check quality of the sample and add to enroller if it's good
                if (features != null)
                    try
                    {
                        MakeReport("The fingerprint feature set was created.");
                        Enroller.AddFeatures(features);     // Add feature set to template.
                    }
                    finally
                    {
                        UpdateStatus();

                        // Check if template has been created.
                        switch (Enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing

                                byte[] serializedTemplate = null;

                                DateTime cur_date = DateTime.Now;
                                Enroller.Template.Serialize(ref serializedTemplate);

                                if (serializedTemplate != null)
                                {

                                    SQLiteCommand dbcmd = con.CreateCommand();
                                    try
                                    {
                                        // Store TemplateSerialize as string data                                                   s

                                        SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from Corpdata where callupNo = '" + callupNo.Text + "' and stateCode='" + statecode.Text + "' ", con);
                                        DataTable dt = new DataTable();
                                        sda.Fill(dt);

                                        // MessageBox.Show(dt.Rows.Count.ToString());

                                        if (dt.Rows.Count == 1)
                                        {
                                            String corpIDN = (dt.Rows[0][0].ToString());

                                            dbcmd.CommandText = "INSERT INTO fingerPrint ( fingerPrint, corpId ) VALUES ( @serializedTemplate, @CorperID )";
                                            dbcmd.Parameters.AddWithValue("@serializedTemplate", serializedTemplate);
                                            dbcmd.Parameters.AddWithValue("@CorperID", corpIDN);
                                            dbcmd.ExecuteNonQuery();

                                            //MessageBox.Show("Fingerprint Saved Successfully");

                                            OnTemplate(Enroller.Template);
                                            SetPrompt("FingerPrint has been saved succesfully");
                                           ///////////////////////
                                            Stop();
                                            BtnstartCapture.Visible = false;
                                            Clearcontrols();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Student has not been Added Succesfully", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }

                                }
                                                               
                                break;

                            case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                                Enroller.Clear();
                                Stop();
                                UpdateStatus();
                                OnTemplate(null);
                                Start();
                                //con.Close();
                                break;
                        }
                    }
            }
            catch (Exception)
            {

                throw;
            }
           
        }



        ///Fingerprint Envent Handlers
        #region
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            try
            {
                MakeReport("The fingerprint sample was captured.");
                SetPrompt("Scan the same fingerprint again.");
                Process(Sample);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("The finger was removed from the fingerprint reader.");
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

        #endregion

        private void BtnstartCapture_Click(object sender, EventArgs e)
        {
            try
            {
                Init();
                Stop();
                Start();
                OnTemplate += this.onTemplateEnroll;
                Enroller = new DPFP.Processing.Enrollment();
                UpdateStatus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UCRegisterCorpMember_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnContinueInstruct_Click(object sender, EventArgs e)
        {
            SearchBox.Visible = true;
            callupNo.Text  = "                                ";
            statecode.Text = "                                ";
            BtnstartCapture.Visible = false;
            label13.Location = new System.Drawing.Point(790, 430);
            Prompt.Location = new System.Drawing.Point(790, 452);
            label12.Location = new System.Drawing.Point(790, 477);
            StatusText.Location = new System.Drawing.Point(790, 499);

            SearchBox.Location = new System.Drawing.Point(815, 329);


            //815, 328
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSearch.Text!= string.Empty)
                {

                    SQLiteDataAdapter sdac = new SQLiteDataAdapter("SELECT * FROM CorpData WHERE stateCode = '" + txtSearch.Text + "' or callupNo = '" + txtSearch.Text + "'  ", con);

                    DataTable stdTab = new DataTable();
                    sdac.Fill(stdTab);
                    if (stdTab.Rows.Count == 1)
                    {

                        foreach (DataRow item in stdTab.Rows)
                        {

                            SQLiteDataAdapter sda = new SQLiteDataAdapter("SELECT * FROM fingerprint WHERE corpId = '" + item["Id"].ToString() + "' ", con);

                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Rows.Count == 1)
                            {
                                MessageBox.Show("Biometrics Already Captured", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clearcontrols();
                                return;
                            }
                            else
                            {

                                string avatar = item["passport"].ToString();
                                pictureBox1.Image = Image.FromFile(Path.Combine(avatar));
                                callupNo.Text = item["callupNo"].ToString();
                                statecode.Text = item["stateCode"].ToString();
                            }

                        }
                        SearchBox.Visible = false;
                        label13.Location = new System.Drawing.Point(786, 365);
                        Prompt.Location = new System.Drawing.Point(786, 387);
                        label12.Location = new System.Drawing.Point(786, 412);
                        StatusText.Location = new System.Drawing.Point(790, 434);
                        MessageBox.Show("Start biometrics Capture", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnstartCapture.Visible = true;

                    }

                    else
                    {

                        MessageBox.Show("Sorry this Corp Member has never been registered", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }

                }
                else
                {
                    MessageBox.Show("Please input state Code or Callup No.", "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
                                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCallup_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string dissallowedChars = @"\.<,>?;`:'][}{=+-_)(*&^~!#@$%|";

                //Disallow  unwanted char
                //if (char.IsLetter(e.KeyChar) == true)
                //{
                //    e.Handled = true;
                //    MessageBox.Show("phonenumbers must be numerical digits only");

                //    txtCallup.ForeColor = Color.Red;

                //}
                //check if dissalowed char is entered
                if (dissallowedChars.Contains(e.KeyChar))
                {
                    e.Handled = true;

                    //MessageBox.Show("phonenumbers must be numerical digits only");
                    //lecPhonenum.BackColor = Color.Red;
                    txtCallup.ForeColor = Color.Red;
                    //lecPhonenum.ForeColor = Color.White;
                }
                //if char entered is numbers
                else
                {
                    txtCallup.BackColor = Color.White;
                    txtCallup.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtStatecode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string dissallowedChars = @"\.<,>?;`:'][}{=+-_)(*&^~!#@$%|";

                //Disallow  unwanted char
                //if (char.IsLetter(e.KeyChar) == true)
                //{
                //    e.Handled = true;
                //    MessageBox.Show("phonenumbers must be numerical digits only");

                //    txtCallup.ForeColor = Color.Red;

                //}
                //check if dissalowed char is entered
                if (dissallowedChars.Contains(e.KeyChar))
                {
                    e.Handled = true;

                    //MessageBox.Show("phonenumbers must be numerical digits only");
                    //lecPhonenum.BackColor = Color.Red;
                    txtStatecode.ForeColor = Color.Red;
                    //lecPhonenum.ForeColor = Color.White;
                }
                //if char entered is numbers
                else
                {
                    txtStatecode.BackColor = Color.White;
                    txtStatecode.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPhonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string dissallowedChars = @"\.<,>?;`:']/[}{=+-_)(*&^~!#@$%|";

                //Disallow  unwanted char
                if (char.IsLetter(e.KeyChar) == true)
                {
                    e.Handled = true;
                   // MessageBox.Show("phonenumbers must be numerical digits only");

                    //txtCallup.ForeColor = Color.Red;

                }
                //check if dissalowed char is entered
                else if (dissallowedChars.Contains(e.KeyChar))
                {
                    e.Handled = true;

                    //MessageBox.Show("phonenumbers must be numerical digits only");
                    //lecPhonenum.BackColor = Color.Red;
                   // txtPhonenumber.ForeColor = Color.Red;
                    //lecPhonenum.ForeColor = Color.White;
                }
                //if char entered is numbers
                else
                {
                    //txtStatecode.BackColor = Color.White;
                    //txtStatecode.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string dissallowedChars = @"\.<,>?;`:][}{=+_)/(*&^~!#@$%|";

                //Disallow  unwanted char
               
                //check if dissalowed char is entered
                if (dissallowedChars.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
                //if char entered is numbers
                else
                {
                    //txtStatecode.BackColor = Color.White;
                    //txtStatecode.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "CDS ATTENDANCE TRACKER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    txtStatecode.ForeColor = Color.Red;
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

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        //WEB CAM FUNCTIONALITY
        #region
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }

        // When the user clicks on the start/stop button, start or release the camera and setup flags
        private void BtnStartCamera_Click(object sender, EventArgs e)
        {
            if (BtnStartCamera.ButtonText == "Start Camera" )
            {
                //MessageBox.Show("It IS");
                CaptureCamera();
                BtnStartCamera.ButtonText = "Stop Camera";
                isCameraRunning = true;
            }
            else
            {
                //MessageBox.Show("Its not");
                capture.Release();
                BtnStartCamera.ButtonText = "Start Camera";
                isCameraRunning = false;
            }
        }

        // When the user clicks on take snapshot, the image that is displayed in the pictureBox will be saved in your computer
        private void BtnTakeSnapShot_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                capture.Release();
                BtnStartCamera.ButtonText = "Start Camera";
                isCameraRunning = false;

                //string pathstring;
                //// Take snapshot of the current image generate by OpenCV in the Picture Box
                //Bitmap snapshot = new Bitmap(pictureBox1.Image);

                //// Save in some directory
                //// in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                //// snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                //// snapshot.Save(string.Format(@"C:\Users\sdkca\Desktop\{0}.png", Guid.NewGuid()), ImageFormat.Png);

                //string fname = txtName.Text + " " + txtSurname + ".png";
                //string folder = "C:\\Attendance\\Students";
                //if (!Directory.Exists(folder))
                //{
                //    Directory.CreateDirectory(folder);
                //   // pathstring = Path.Combine(folder, fname);
                //    //snapshot.Save(pathstring, ImageFormat.Png);
                //    snapshot.Save(string.Format(@"C:\Attendance\Students\{0}.png", Guid.NewGuid()), ImageFormat.Png);

                //}
                //else
                //{
                //    //pathstring = Path.Combine(folder, fname);
                //    //snapshot.Save(pathstring, ImageFormat.Png);
                //    snapshot.Save(string.Format(@"C:\Attendance\Students\{0}.png", Guid.NewGuid()), ImageFormat.Png);

                //}
            }
            else
            {
                MessageBox.Show("Cannot take picture if the camera isn't capturing image!"); 
            }
        }
        #endregion
    }
}
