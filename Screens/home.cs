using ESMS.Properties;
using ESMS.Settings;
using ESMS.User_Controls;
using MaterialSkin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ESMS.Screens
{

    public partial class home : MaterialSkin.Controls.MaterialForm
    {
        public static home Instance;
        public home()
        {
            InitializeComponent();
            Instance = this;
            this.KeyPreview = true;
            var theme = MaterialSkinManager.Instance;
            theme.AddFormToManage(this);
            qrc = qrcod;
            nam = materialLabel1;
            daob = materialLabel2;
            gend = materialLabel3;
            addr = materialLabel4;
            telno = materialLabel5;
            prof = pictureBox3;
            layoutPanel = flowLayoutPanel1;
            layoutPanel2 = flowLayoutPanel2;
            aten = materialSwitch1;
            attname = materialLabel6;
            attcourse = comboBox1;
            attpro = pictureBox5;
            nic_num = materialLabel7;
            parent_name = materialLabel8;
            parent_tele = materialLabel9;
            mn_crs = mn_crs_name;
            corse = this.courcesBindingSource;



        }
        public MaterialSkin.Controls.MaterialComboBox mn_crs;
        public MaterialSkin.Controls.MaterialMaskedTextBox qrc;
        public PictureBox attpro;
        public MaterialSkin.Controls.MaterialLabel attname;
        public ComboBox attcourse;
        public MaterialSkin.Controls.MaterialSwitch aten;
        public MaterialSkin.Controls.MaterialLabel nam;
        public MaterialSkin.Controls.MaterialLabel parent_name;
        public MaterialSkin.Controls.MaterialLabel parent_tele;
        public MaterialSkin.Controls.MaterialLabel nic_num;
        public MaterialSkin.Controls.MaterialLabel daob;
        public MaterialSkin.Controls.MaterialLabel gend;
        public MaterialSkin.Controls.MaterialLabel addr;
        public MaterialSkin.Controls.MaterialLabel telno;
        public MaterialSkin.Controls.MaterialLabel crs;
        public FlowLayoutPanel layoutPanel;
        public FlowLayoutPanel layoutPanel2;
        public PictureBox prof;
        public BindingSource corse;


        

        private void home_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;

            panel1.VerticalScroll.Enabled = true;
            // TODO: This line of code loads data into the 'eSMSDataSet1.student' table. You can move, or remove it, as needed.
            //            this.studentTableAdapter.Fill(this.eSMSDataSet1.student);
            // TODO: This line of code loads data into the 'eSMSDataSet.cources' table. You can move, or remove it, as needed.
            this.courcesTableAdapter.Fill(this.eSMSDataSet.cources);

            
            qrcod.Text = qrdec;
            mn_crs_name_SelectedIndexChanged(mn_crs_name, new EventArgs());
        }


        //closing dialog box
        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "SKILLS - HOME", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.ExitThread();
                    Environment.Exit(Environment.ExitCode);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
            
        }


        //clear register form
        private void materialButton2_Click(object sender, EventArgs e)
        {
            name.Text = "";
            bdate.Text = "";
            tel.Text = "";
            Address.Text = "";
            gender.Text = "";
            course.Text = "";
            pictureBox1.Image = Resources.arrow;
            qrcod.Text = "";
            flowLayoutPanel1.Controls.Clear();
            crsids.Clear();
            nic.Text = "";
            par_name.Text = "";
            par_tel.Text = "";
        }


        //get picture from file and set to picturebox
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog(this);
            pictureBox1.ImageLocation = openFileDialog1.FileName;

        }


        //convert image of picture box in to byte array
        private byte[] getpic()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
            return stream.GetBuffer();
        }

        //submit student details to database using stored procederes
        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
                    {

                        using (SqlCommand cmd = new SqlCommand("dbo.InsertStudent", conn))
                        {

                            string Name = name.Text;
                            DateTime dob = bdate.Value.Date;
                            string gen = gender.Text;
                            string address = Address.Text;
                            string telno = tel.Text;
                            string courseId = regcourses;
                            byte[] picture = getpic();
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


                            // For image data, use SqlParameter with SqlDbType.VarBinary and appropriate size
                            SqlParameter pictureParam = new SqlParameter("@picture", SqlDbType.VarBinary, picture.Length);
                            pictureParam.Value = picture;
                            cmd.Parameters.Add(pictureParam);

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.Title = "Saved!";
                                notifydialog.Message = "Student saved successfully!";
                                notifydialog.error = false;
                                notifydialog.Show();
                                materialButton2.PerformClick();

                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.Title = "Error!";
                                notifydialog.Message = "Error inserting student: {0} " + ex.Message;
                                notifydialog.error = true;
                                notifydialog.Show();

                            }




                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //qr decoded text value variable
        public string qrdec { get; set; }

        //check validate of registration form
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


        //trigger tab key to go through tab index when press enter
        private void home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{Tab}");
            }
        }

        //validate textboxes
        private void tel_TextChanged(object sender, EventArgs e)
        {
            if (tel.Text.Length > 10)
            {
                tel.SetErrorState(true);
                tel.TrailingIcon = Resources.warning;

            }
            else
            {
                tel.SetErrorState(false);
                tel.TrailingIcon = null;

            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (name.Text.Length < 1)
            {
                name.SetErrorState(true);
                name.TrailingIcon = Resources.warning;
            }
            else
            {
                name.SetErrorState(false);
                name.TrailingIcon = null;
            }
        }

        //open qr scaning form when click,doubleclick or enter using tab key to qr code textbox
        private void materialMaskedTextBox1_Click(object sender, EventArgs e)
        {
            qr qr = new qr();
            qr.register = true;
            qr.Show();
        }

        private void qrcod_DoubleClick(object sender, EventArgs e)
        {
            qr qr = new qr();
            qr.register = true;
            qr.Show();
        }

        private void qrcod_Enter(object sender, EventArgs e)
        {
            qr qr = new qr();
            qr.register = true;
            qr.Show();
        }
        //search student by entering mobile number
        private void materialTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                string query = "SELECT * FROM student WHERE tel = @Tel";
                using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tel", telser.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Process each row
                                while (reader.Read())
                                {
                                    // Access data by column index
                                    int id = reader.GetInt32(0); 
                                    string name = reader.GetString(1); 
                                    DateTime dob = reader.GetDateTime(2);                               
                                    string gen = reader.GetString(3);
                                    string address = reader.GetString(4);
                                    string tele = reader.GetString(5);
                                    string courid = reader.GetString(6);
                                    //get byte array of image from database
                                    byte[] img = (byte[])reader[7];

                                    //set byte array of image into picture box 
                                    using (MemoryStream ms = new MemoryStream(img))
                                    {

                                        pictureBox3.Image = Image.FromStream(ms, true, false);
                                    }
                                    materialLabel1.Text = name;
                                    materialLabel2.Text = dob.Date.ToString();
                                    materialLabel3.Text = gen;
                                    materialLabel4.Text = address;
                                    materialLabel5.Text = tele;
                                    ints = JsonConvert.DeserializeObject<int[]>(courid);
                                    home.Instance.layoutPanel2.Controls.Clear();




                                }
                            }
                            else
                            {
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.error = true;
                                notifydialog.Title = "Error";
                                notifydialog.Message = "Invalid mobile number " + telser.Text;
                                notifydialog.Show();
                            }
                        }
                    }
                }


                //getting course name from courses table according to id array of student table
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



                                    //adding course names to pannel with custom made usercontrols
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
        }
        public int[] ints { get; set; }
        private Image ConvertImageFromByteArray(byte[] img)
        {
            using (MemoryStream ms = new MemoryStream(img))
            {
                return Image.FromStream(ms);
            }
        }

        //open qr scan form when click on qr icon 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            qr qr = new qr();
            qr.manage = true;
            qr.Show();
        }

        public bool exist { get; set; }
        private void MaterialButton6_Click(object sender, EventArgs e)
        {

            string query = "SELECT * FROM student WHERE tel = @Tel";
            using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tel", telser.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            exist = true;
                            // Process each row
                            while (reader.Read())
                            {
                                // Access data by column index
                                id = reader.GetInt32(0); 
                                string name = reader.GetString(1); 
                                DateTime dob = reader.GetDateTime(2);    
                                string gen = reader.GetString(3);
                                string address = reader.GetString(4);
                                string tele = reader.GetString(5);
                                string courid = reader.GetString(6);
                                byte[] img = (byte[])reader[7];
                                qr = reader.GetString(8);
                                string nic = reader.GetString(9);
                                string par_name = reader.GetString(10);
                                string par_tel = reader.GetString(11);


                                materialLabel1.Text = name;
                                materialLabel2.Text = dob.Date.ToString();
                                materialLabel3.Text = gen;
                                materialLabel4.Text = address;
                                materialLabel5.Text = tele;
                                parent_tele.Text = par_tel;
                                parent_name.Text = par_name;
                                nic_num.Text = nic;
                                pictureBox3.Image = ConvertImageFromByteArray(img);
                                ints = JsonConvert.DeserializeObject<int[]>(courid);
                                home.Instance.layoutPanel2.Controls.Clear();




                            }
                        }
                        else
                        {
                            exist = false;
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.error = true;
                            notifydialog.Title = "Error";
                            notifydialog.Message = "Invalid mobile number " + telser.Text;
                            notifydialog.Show();
                        }
                    }

                }
            }
            try
            {
                if (exist)
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
            }
            catch (Exception ex)
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.error = true;
                notifydialog.Title = "Error";
                notifydialog.Message = ex.Message;
                notifydialog.Show();
            }
        }

        public string qr { get; set; }
        public List<int> crsids = new List<int>();
        public string regcourses { get; set; }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int courseid = Convert.ToInt16(course.SelectedValue);
            if (!crsids.Contains(courseid))
            {
                courseadd courseadd = new courseadd();
                courseadd.update = false;
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

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(qr))
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.error = true;
                notifydialog.Title = "Error";
                notifydialog.Message = "Invalid Student!";
                notifydialog.Show();

            }
            else
            {
                update_student update_Student = new update_student();
                update_Student.qr = qr;
                update_Student.Show();
            }

        }

        public int attendid { get; set; }
        bool isrolled { get; set; }
        bool das { get; set; }
        int roll {  get; set; }
        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (materialSwitch1.Checked)
                {
                    if (attname.Text != string.Empty)
                    {
                        using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                        {
                            con.Open();
                            string que = "SELECT '#' FROM attend WHERE course_id = @crse and stid = @stid and date = @date";
                            bool already;
                            using (SqlCommand command = new SqlCommand(que, con))
                            {
                                command.Parameters.AddWithValue("@crse", comboBox1.SelectedValue);
                                command.Parameters.AddWithValue("@stid", attendid);
                                command.Parameters.AddWithValue("@date", DateTime.Today);

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        already = true;
                                    }
                                    else
                                    {
                                        already = false;
                                    }
                                }
                            }


                            
                            

                            string rolldays = $"select '#' from attend where date ='{DateTime.Today}' and course_id = '{comboBox1.SelectedValue}'";
                            using (SqlCommand command = new SqlCommand(rolldays, con))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    das = reader.Read();
                                    

                                }
                            }

                            string getd = $"select * from cources where id ='{comboBox1.SelectedValue}'";
                            using (SqlCommand command = new SqlCommand(getd, con))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            roll = reader.GetInt32(4);
                                        }
                                    }
                                }
                            }



                            if (!das)
                            {
                                roll++;
                                
                                string addday = $"update cources set rolled ='{roll}'  where id = '{comboBox1.SelectedValue}'";
                                using (SqlCommand command = new SqlCommand(addday, con))
                                {
                                   command.ExecuteNonQuery();
                                    
                                    
                                    
                                }
                            }


                            //check wheather selected course rolled or not

                            string rolle = "SELECT * FROM cources WHERE id = @crse";
                            using (SqlCommand command = new SqlCommand(rolle, con))
                            {
                                command.Parameters.AddWithValue("@crse", comboBox1.SelectedValue);


                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DateTime date = reader.GetDateTime(3);
                                        if (date <= DateTime.Today)
                                        {
                                            isrolled = true;
                                        }
                                        else
                                        {
                                            isrolled = false;
                                        }
                                    }

                                }
                            }

                            string query = "SELECT * FROM payment WHERE course_id = @corseid and stid = @stid";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.Parameters.AddWithValue("@corseid", comboBox1.SelectedValue);
                                cmd.Parameters.AddWithValue("@stid", attendid);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            DateTime date = reader.GetDateTime(4);
                                            if (date.Month != DateTime.Today.Month)
                                            {
                                                notifydialog notifydialog = new notifydialog();
                                                notifydialog.error = true;
                                                notifydialog.Title = "Warning";
                                                notifydialog.Message = "Not paid";
                                                notifydialog.Show();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        notifydialog notifydialog = new notifydialog();
                                        notifydialog.error = true;
                                        notifydialog.Title = "Warning";
                                        notifydialog.Message = "Not paid";
                                        notifydialog.Show();
                                    }
                                }
                            }


                            if (isrolled)
                            {
                                if (!already)
                                {
                                    string attqry = "INSERT INTO attend (course_id,stid,date) VALUES(@crse,@stid,@date)";
                                    using (SqlCommand command = new SqlCommand(attqry, con))
                                    {
                                        command.Parameters.AddWithValue("@crse", comboBox1.SelectedValue);
                                        command.Parameters.AddWithValue("@stid", attendid);
                                        command.Parameters.AddWithValue("@date", DateTime.Today);
                                        command.ExecuteNonQuery();

                                        notifydialog notifydialog = new notifydialog();
                                        notifydialog.error = false;
                                        notifydialog.Title = "Attended";
                                        notifydialog.Message = attname.Text + " Attended Successfully";
                                        notifydialog.Show();


                                    }
                                }
                                else
                                {
                                    notifydialog notifydialog = new notifydialog();
                                    notifydialog.error = false;
                                    notifydialog.Title = "Attended";
                                    notifydialog.Message = "Already Attended";
                                    notifydialog.Show();
                                }
                            }
                            else
                            {
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.error = true;
                                notifydialog.Title = "Error";
                                notifydialog.Message = "Course not rolled yet!";
                                notifydialog.Show();
                                materialSwitch1.Checked = false;
                            }
                        }
                    }
                    else
                    {
                        notifydialog notifydialog = new notifydialog();
                        notifydialog.error = true;
                        notifydialog.Title = "Error";
                        notifydialog.Message = "Invalid Attend";
                        notifydialog.Show();
                        materialSwitch1.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            qr qr = new qr();
            qr.attend = true;
            qr.Show();
        }

        private void par_tel_TextChanged(object sender, EventArgs e)
        {
            if (tel.Text.Length > 10)
            {
                tel.SetErrorState(true);
                tel.TrailingIcon = Resources.warning;

            }
            else
            {
                tel.SetErrorState(false);
                tel.TrailingIcon = null;

            }
        }


        private void mn_crs_name_SelectedIndexChanged(object sender, EventArgs e)
        {

            string qry = "SELECT * FROM cources WHERE id='" + mn_crs_name.SelectedValue + "'";

            using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
            {

                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.HasRows)
                                {

                                    materialLabel10.Text = "Rs. " + reader.GetDouble(2).ToString();
                                    materialLabel11.Text = reader.GetDateTime(3).ToShortDateString();
                                }
                            }
                        }

                    }
                    catch (SqlException ex)
                    {

                        notifydialog notifydialog = new notifydialog();
                        notifydialog.Title = "Error!";
                        notifydialog.Message = ex.ToString();
                        notifydialog.error = true;
                        notifydialog.Show();

                    }
                }
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            if (mn_crs_name.Items.Count != 0)
            {
                update_courses update_Courses = new update_courses();
                update_Courses.id = Convert.ToInt16(mn_crs_name.SelectedValue);
                update_Courses.Show();
            }
            else
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.Title = "Error!";
                notifydialog.Message = "Invalid Update";
                notifydialog.error = true;
                notifydialog.Show();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            update_courses update_Course = new update_courses();
            update_Course.update = false;
            update_Course.Show();

        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;  // Prevent invalid character from being entered
            }
        }

        private void par_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;  // Prevent invalid character from being entered
            }
        }

        private void telser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;  // Prevent invalid character from being entered
            }
        }
        public int id { get; set; }
        private void materialButton5_Click(object sender, EventArgs e)
        {
            try
            {
                int userControlCount = flowLayoutPanel2.Controls.OfType<UserControl>().Count();
                if (userControlCount > 0)
                {
                    pay pay = new pay();
                    pay.stid = id;
                    pay.Show();
                }
                else
                {
                    notifydialog notifydialog = new notifydialog();
                    notifydialog.Title = "Error";
                    notifydialog.error = true;
                    notifydialog.Message = "No registered Courses";
                    notifydialog.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                con.Open();
                string que = "SELECT * FROM student WHERE tel = @tel";

                using (SqlCommand command = new SqlCommand(que, con))
                {
                    command.Parameters.AddWithValue("@tel", materialTextBox1.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                byte[] img = (byte[])reader[7];
                                string courid = reader.GetString(6);
                                string nam = reader.GetString(1);
                                attendid = reader.GetInt32(0);

                                if (courid.Contains(home.Instance.attcourse.SelectedValue.ToString()))
                                {
                                    attname.Text = nam;
                                    attpro.Image = ConvertImageFromByteArray(img);
                                    materialSwitch1.Checked = false;


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
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(qr))
            {
                student_attends student_Attends = new student_attends();
                student_Attends.stid = id;
                student_Attends.Show();
            }
            else
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.error = true;
                notifydialog.Title = "Error";
                notifydialog.Message = "Invalid Student!";
                notifydialog.Show();
            }
        }

        

        private void materialCard2_Click(object sender, EventArgs e)
        {
            pay_report pay_report = new pay_report();
            pay_report.Show();
        }

        private void materialCard1_Click(object sender, EventArgs e)
        {
            attend_report attend_Report = new attend_report();
            attend_Report.Show();
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
