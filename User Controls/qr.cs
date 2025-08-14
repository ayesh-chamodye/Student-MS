using AForge.Video;
using AForge.Video.DirectShow;
using ESMS.Properties;
using ESMS.Screens;
using ESMS.Settings;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZXing;

namespace ESMS.User_Controls
{
    public partial class qr : Form
    {
        public static qr instance;
        public qr()
        {
            InitializeComponent();
            instance = this;

        }
        public bool register { get; set; } = false;
        public bool manage { get; set; } = false;
        public bool updat { get; set; } = false;
        public bool attend { get; set; } = false;

        FilterInfoCollection filterInfoCollection { get; set; }
        VideoCaptureDevice videoCaptureDevice { get; set; }

        private void qr_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cameras.Items.Add(filterInfo.Name);
                cameras.SelectedIndex = 0;
            }
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cameras.SelectedIndex].MonikerString);
            videoCaptureDevice.Start();
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            camon = true;

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {



            if (videoCaptureDevice.IsRunning)
            {

                while (videoCaptureDevice.IsRunning)
                {

                    if (!videoCaptureDevice.IsRunning)
                    {

                        this.Close();
                    }
                    else
                    {



                        videoCaptureDevice.Stop();
                        videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                    }
                    materialButton2.PerformClick();
                }

            }
            else
            {

                this.Close();
            }







        }

        private void cameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (camon)
            {

                pictureBox2_Click(pictureBox2, new EventArgs());
            }
            else
            {


                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cameras.SelectedIndex].MonikerString);
            }






        }

        public string qrcd { get; set; }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        public int[] ints { get; set; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    if (register)
                    {
                        using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                        {
                            con.Open();
                            string coqu = "SELECT '#' FROM student WHERE qrcode = @qr";
                            
                                using (SqlCommand command = new SqlCommand(coqu, con))
                                {



                                    command.Parameters.AddWithValue("@qr", result.ToString());

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (!reader.Read())
                                        {
                                            home.Instance.qrc.Text = result.ToString();
                                        }
                                        else
                                        {
                                            notifydialog notifydialog = new notifydialog();
                                            notifydialog.error = true;
                                            notifydialog.Title = "Error";
                                            notifydialog.Message = "QR Already registered!";
                                            notifydialog.Show();
                                        }
                                        

                                    }
                                }
                            
                        }
                        
                    }
                    else
                    {
                        if (manage)
                        {
                            string query = "SELECT * FROM student WHERE qrcode = @qr ";
                            using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
                            {
                                conn.Open();

                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@qr", result.ToString());

                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            // Process each row
                                            while (reader.Read())
                                            {
                                                // Access data by column name or index
                                                int id = reader.GetInt32(0); // Assuming ID is the first column (index 0)
                                                string name = reader.GetString(1); // Assuming name is the second column (index 1)
                                                DateTime dob = reader.GetDateTime(2);                               // ... and so on for other columns
                                                string gen = reader.GetString(3);
                                                string address = reader.GetString(4);
                                                string tele = reader.GetString(5);
                                                string courid = reader.GetString(6);
                                                byte[] img = (byte[])reader[7];
                                                qrcd = reader.GetString(8);
                                                string nic = reader.GetString(9);
                                                string par_name = reader.GetString(10);
                                                string par_tel = reader.GetString(11);

                                                home.Instance.exist = true;
                                                home.Instance.qr = qrcd;
                                                home.Instance.id = id;
                                                home.Instance.nam.Text = name;
                                                home.Instance.daob.Text = dob.Date.ToShortDateString();
                                                home.Instance.gend.Text = gen;
                                                home.Instance.addr.Text = address;
                                                home.Instance.telno.Text = tele;
                                                home.Instance.parent_tele.Text = par_tel;
                                                home.Instance.parent_name.Text = par_name;
                                                home.Instance.nic_num.Text = nic;
                                                home.Instance.prof.Image = ConvertImageFromByteArray(img);
                                                ints = JsonConvert.DeserializeObject<int[]>(courid);
                                                home.Instance.layoutPanel2.Controls.Clear();
                                                validqr = true;




                                            }
                                        }
                                        else
                                        {
                                            notifydialog notifydialog = new notifydialog();
                                            notifydialog.error = true;
                                            notifydialog.Title = "Error";
                                            notifydialog.Message = "Invalid QR code";
                                            notifydialog.Show();
                                            validqr = false;
                                        }
                                    }

                                }


                            }
                            if (validqr)
                            {
                                using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                                {
                                    con.Open();
                                    string coqu = "SELECT course_name FROM cources WHERE id = @id";
                                    foreach (int i in ints)
                                    {
                                        using (SqlCommand command = new SqlCommand(coqu, con))
                                        {



                                            command.Parameters.AddWithValue("@id", i);

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {


                                                while (reader.Read())
                                                {




                                                    courseadd courseadd = new courseadd();
                                                    courseadd.coursename = reader.GetString(0);
                                                    courseadd.courseid = i;
                                                    home.Instance.layoutPanel2.Controls.Add(courseadd);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            if (updat)
                            {

                                update_student.Instance.qrco.Text = result.ToString();
                            }
                            else
                            {
                                if (attend)
                                {


                                    using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                                    {
                                        con.Open();
                                        string que = "SELECT * FROM student WHERE qrcode = @qr";

                                        using (SqlCommand command = new SqlCommand(que, con))
                                        {
                                            command.Parameters.AddWithValue("@qr", result.ToString());

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.HasRows)
                                                {

                                                    while (reader.Read())
                                                    {
                                                        byte[] img = (byte[])reader[7];
                                                        string courid = reader.GetString(6);
                                                        string name = reader.GetString(1);
                                                        int stid = reader.GetInt32(0);

                                                        if (courid.Contains(home.Instance.attcourse.SelectedValue.ToString()))
                                                        {
                                                            home.Instance.attname.Text = name;
                                                            home.Instance.attpro.Image = ConvertImageFromByteArray(img);
                                                            home.Instance.attendid = stid;
                                                            home.Instance.aten.Checked = false;
                                                            home.Instance.aten.Checked = true;  


                                                        }
                                                        else
                                                        {
                                                            notifydialog notifydialog = new notifydialog();
                                                            notifydialog.error = true;
                                                            notifydialog.Title = "Error";
                                                            notifydialog.Message = "Student not registerd to course!";
                                                            notifydialog.Show();
                                                        }


                                                    }
                                                }
                                                else
                                                {

                                                    notifydialog notifydialog = new notifydialog();
                                                    notifydialog.error = true;
                                                    notifydialog.Title = "Error";
                                                    notifydialog.Message = "Invalid student!";
                                                    notifydialog.Show();
                                                }
                                            }
                                        }

                                    }
                                    // home.Instance.aten.Checked = true;
                                    // home.Instance.attname = 
                                }
                            }
                        }
                    }
                    if (!attend)
                    {
                        timer1.Stop();
                        if (videoCaptureDevice.IsRunning)
                        {
                            videoCaptureDevice.SignalToStop();

                            while (videoCaptureDevice.IsRunning)
                            {

                                if (!videoCaptureDevice.IsRunning)
                                {
                                    this.Close();
                                }
                                else
                                {
                                    videoCaptureDevice.Stop();
                                    videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                                    this.Close();
                                }
                            }

                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        public bool validqr { get; set; }

        private Image ConvertImageFromByteArray(byte[] img)
        {
            using (MemoryStream ms = new MemoryStream(img))
            {
                return Image.FromStream(ms);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            camon = !camon;

            if (!videoCaptureDevice.IsRunning)
            {

                pictureBox2.Image = Resources.camera__1_;
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cameras.SelectedIndex].MonikerString);
                videoCaptureDevice.Start();
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            }
            else
            {

                while (videoCaptureDevice.IsRunning)
                {
                    pictureBox2.Image = Resources.camera;

                    if (!videoCaptureDevice.IsRunning)
                    {
                        videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cameras.SelectedIndex].MonikerString);
                        videoCaptureDevice.Start();
                        videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    }
                    else
                    {
                        videoCaptureDevice.Stop();
                        videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                    }
                }


            }

        }


        public bool camon { get; set; }

        private void qr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning)
            {

                while (videoCaptureDevice.IsRunning)
                {

                    if (videoCaptureDevice.IsRunning)
                    {
                        videoCaptureDevice.Stop();
                        videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                    }
                    
                }

            }
            

        }
    }
}
