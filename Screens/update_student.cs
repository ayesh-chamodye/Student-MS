using ESMS.Settings;
using ESMS.User_Controls;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ESMS.Screens
{
    public partial class update_student : Form
    {
        public static update_student Instance { get; set; }
        public update_student()
        {
            InitializeComponent();
            this.KeyPreview = true;
            courses = flowLayoutPanel1;
            qrco = qrcod;
            Instance = this;

        }

        public FlowLayoutPanel courses { get; set; }
        public MaterialMaskedTextBox qrco {  get; set; }

        private void update_student_Load(object sender, EventArgs e)
        {

            this.courcesTableAdapter.Fill(this.eSMSDataSet2.cources);
            load_data();
        }

        public byte[] img { get; set; }
        private void load_data()
        {
            using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                conn.Open();
                string qry = "select * from student where qrcode='" + qr + "'";
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                int id = reader.GetInt32(0);
                                string Name = reader.GetString(1);
                                DateTime dob = reader.GetDateTime(2);
                                string gen = reader.GetString(3);
                                string address = reader.GetString(4);
                                string tele = reader.GetString(5);
                                string courid = reader.GetString(6);
                                img = (byte[])reader[7];
                                string Nic = reader.GetString(9);
                                string parent_name = reader.GetString(10);
                                string parent_tel = reader.GetString(11);

                                name.Text = Name;
                                bdate.Text = dob.Date.ToShortDateString();
                                gender.Text = gen;
                                Address.Text = address;
                                tel.Text = tele;
                                par_tel.Text = parent_tel;
                                par_name.Text = parent_name;
                                nic.Text = Nic;
                                qrcod.Text = qr;
                                pictureBox1.Image = ConvertImageFromByteArray(img);
                                ints = JsonConvert.DeserializeObject<int[]>(courid);
                                flowLayoutPanel1.Controls.Clear();





                            }
                        }
                        else
                        {
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.error = true;
                            notifydialog.Title = "Error";
                            notifydialog.Message = "Invalid QR code";
                            notifydialog.Show();

                        }
                    }

                }
            }



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



                                crsids.Add(i);
                                courseadd courseadd = new courseadd();
                                courseadd.update = true;
                                courseadd.coursename = reader.GetString(0);
                                courseadd.courseid = i;
                                flowLayoutPanel1.Controls.Add(courseadd);

                            }
                        }
                    }
                }
            }
        }


        public int[] ints { get; set; }
        private Image ConvertImageFromByteArray(byte[] img)
        {
            using (MemoryStream ms = new MemoryStream(img))
            {
                return Image.FromStream(ms);
            }
        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(name.Text))
            {

                notifydialog notifydialog = new notifydialog();
                notifydialog.Title = "Error!";
                notifydialog.Message = "Name can't be empty!";
                notifydialog.error = true;
                notifydialog.Show();
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(Address.Text))
                {
                    notifydialog notifydialog = new notifydialog();
                    notifydialog.Title = "Error!";
                    notifydialog.Message = "Address can't be empty!";
                    notifydialog.error = true;
                    notifydialog.Show();
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(tel.Text))
                    {
                        notifydialog notifydialog = new notifydialog();
                        notifydialog.Title = "Error!";
                        notifydialog.Message = "Telephone can't be empty!";
                        notifydialog.error = true;
                        notifydialog.Show();
                        return false;
                    }
                    else
                    {
                        if (flowLayoutPanel1.Controls.Count == 0)
                        {
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.Title = "Error!";
                            notifydialog.Message = "Courses can't be empty!";
                            notifydialog.error = true;
                            notifydialog.Show();
                            return false;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(par_tel.Text))
                            {
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.Title = "Error!";
                                notifydialog.Message = "Guardian Telephone can't be empty!";
                                notifydialog.error = true;
                                notifydialog.Show();
                                return false;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(par_name.Text))
                                {
                                    notifydialog notifydialog = new notifydialog();
                                    notifydialog.Title = "Error!";
                                    notifydialog.Message = "Guardian Name can't be empty!";
                                    notifydialog.error = true;
                                    notifydialog.Show();
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }

                        }

                    }
                }
            }
        }


        private byte[] getpic()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
            return stream.GetBuffer();
        }


        public bool pic_change { get; set; } = false;
        public string qr { get; set; }

        private void materialButton1_Click(object sender, EventArgs e)
        {

            if (Valid())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
                    {

                        using (SqlCommand cmd = new SqlCommand("dbo.updateStudents", conn))
                        {

                            int[] fin = crsids.ToArray();
                            regcourses = JsonConvert.SerializeObject(fin);
                            string Name = name.Text;
                            DateTime dob = bdate.Value.Date;
                            string gen = gender.Text;
                            string address = Address.Text;
                            string telno = tel.Text;
                            string courseId = regcourses;

                            string qrcode = qrcod.Text;
                            string pare_tel = par_tel.Text;
                            string pare_name = par_name.Text;
                            string nicn = nic.Text;


                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Name", Name));
                            cmd.Parameters.Add(new SqlParameter("@DOB", dob));
                            cmd.Parameters.Add(new SqlParameter("@Gender", gen));
                            cmd.Parameters.Add(new SqlParameter("@Address", address));
                            cmd.Parameters.Add(new SqlParameter("@tel", telno));
                            cmd.Parameters.Add(new SqlParameter("@courseID", courseId));
                            cmd.Parameters.Add(new SqlParameter("@qrcode", qrcode));
                            cmd.Parameters.Add(new SqlParameter("@nic", nicn));
                            cmd.Parameters.Add(new SqlParameter("@par_name", pare_name));
                            cmd.Parameters.Add(new SqlParameter("@parent_tel", pare_tel));
                            cmd.Parameters.Add(new SqlParameter("@searchqr", qr));



                            if (pic_change)
                            {
                                byte[] picture = getpic();
                                SqlParameter pictureParam = new SqlParameter("@picture", SqlDbType.VarBinary, picture.Length);
                                pictureParam.Value = picture;
                                cmd.Parameters.Add(pictureParam);
                            }
                            else
                            {
                                SqlParameter pictureParam = new SqlParameter("@picture", SqlDbType.VarBinary, img.Length);
                                pictureParam.Value = img;
                                cmd.Parameters.Add(pictureParam);
                            }

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.Title = "Saved!";
                                notifydialog.Message = "Student saved successfully!";
                                notifydialog.error = false;
                                notifydialog.Show();
                                this.Close();

                                home.Instance.Hide();
                                home h = new home();
                                h.Show();

                            }
                            catch (SqlException ex)
                            {

                                notifydialog notifydialog = new notifydialog();
                                notifydialog.Title = "Error!";
                                notifydialog.Message = "Error inserting student: " + ex.Message;
                                notifydialog.error = true;
                                notifydialog.Show();

                            }




                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public List<int> crsids = new List<int>();
        public string regcourses { get; set; }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int courseid = Convert.ToInt16(course.SelectedValue);
            if (!crsids.Contains(courseid))
            {
                courseadd courseadd = new courseadd();
                courseadd.update = true;
                courseadd.coursename = course.Text;
                courseadd.courseid = courseid;
                crsids.Add(courseid);
                flowLayoutPanel1.Controls.Add(courseadd);
                int[] fin = crsids.ToArray();
                regcourses = JsonConvert.SerializeObject(fin);
            }
            else
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.error = true;
                notifydialog.Title = "Error";
                notifydialog.Message = "Course Already Added";
                notifydialog.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pic_change = true;
            }
            else
            {
                pic_change = false;
            }


        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM [dbo].[student] WHERE qrcode='" + qr + "'";

            using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
            {

                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        notifydialog notifydialog = new notifydialog();
                        notifydialog.Title = "Deleted!";
                        notifydialog.Message = "Student Deleted successfully!";
                        notifydialog.error = false;
                        notifydialog.Show();
                        this.Close();
                        home.Instance.Hide();
                        home h = new home();
                        h.Show();

                    }
                    catch (SqlException ex)
                    {

                        notifydialog notifydialog = new notifydialog();
                        notifydialog.Title = "Error!";
                        notifydialog.Message = "Error Deleting student: " + ex.Message;
                        notifydialog.error = true;
                        notifydialog.Show();

                    }
                }
            }
        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void par_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;  // Prevent invalid character from being entered
            }
        }

        private void update_student_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("{Tab}");
            }
        }

        private void qrcod_Enter(object sender, EventArgs e)
        {
            qr qr = new qr();
            qr.updat = true;
            qr.Show();
        }
    }
}
