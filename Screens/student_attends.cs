using ESMS.Settings;
using ESMS.User_Controls;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ESMS.Screens
{
    public partial class student_attends : Form
    {
        public student_attends()
        {
            InitializeComponent();
        }
        public int stid { get; set; }
        public int[] coses { get; set; }
        private void student_attends_Load(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                con.Open();
                string ids = "select * from student where stid='" + stid + "'";
                using (SqlCommand cmd = new SqlCommand(ids, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {



                        while (reader.Read())
                        {
                            coses = JsonConvert.DeserializeObject<int[]>(reader.GetString(6));


                        }

                        if (coses.Length == 0)
                        {
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.Title = "Error";
                            notifydialog.error = true;
                            notifydialog.Message = "No registered Courses";
                            notifydialog.Show();
                            this.Close();
                        }
                    }

                }
                try
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add("id", typeof(int));
                    foreach (int i in coses)
                    {
                        string loadcrs = "select * from cources where id = '" + i + "'";

                        using (SqlCommand adap = new SqlCommand(loadcrs, con))
                        {
                            using (SqlDataReader reader = adap.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {

                                    while (reader.Read())
                                    {


                                        DataRow newRow = dt.NewRow();
                                        newRow["Name"] = reader.GetString(1);
                                        newRow["id"] = reader.GetInt32(0);
                                        dt.Rows.Add(newRow);



                                    }
                                    materialComboBox1.DataSource = dt;
                                    materialComboBox1.DisplayMember = "Name";
                                    materialComboBox1.ValueMember = "id";
                                    materialComboBox1.SelectedIndex = 0;

                                }
                                else
                                {
                                    notifydialog notifydialog = new notifydialog();
                                    notifydialog.Title = "Error";
                                    notifydialog.error = true;
                                    notifydialog.Message = "No registered Courses";
                                    notifydialog.Show();
                                    this.Close();
                                }

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

        public int progress { get; set; }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {






            circularProgressBar1.Value = 0;
            circularProgressBar1.Text = "0%";
            timer1.Start();
            attendance();


        }

        private void attendance()
        {
            using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                con.Open();
                DataRowView selectedItem = (DataRowView)materialComboBox1.SelectedItem;
                int selectedCrsId = (int)selectedItem["id"];
                string atten = $"select date from attend where stid='{stid}' and course_id = '{selectedCrsId}'";
                using (SqlDataAdapter adapter = new SqlDataAdapter(atten, con))
                {
                   DataTable data = new DataTable();
                    adapter.Fill(data);
                    metroGrid1.DataSource = data;

                }
            }
        }

        private double getprecentage()
        {
            double count = 0;
            double aldys = 0;
            try
            {
                string precqry = "select * from attend where stid = @stid and course_id = @crseid";
                using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                {
                    DataRowView selectedItem = (DataRowView)materialComboBox1.SelectedItem;
                    int selectedCrsId = (int)selectedItem["id"];
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(precqry, con))
                    {
                        cmd.Parameters.AddWithValue("@stid", (int)stid);

                        cmd.Parameters.AddWithValue("@crseid", (int)selectedCrsId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {
                                    count++;

                                }

                            }
                        }
                    }

                    string alldays = $"select rolled from cources where id ='{selectedCrsId}'";
                    using (SqlCommand cmd = new SqlCommand(alldays, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    aldys = reader.GetInt32(0);

                                }
                            }
                            else
                            {
                                notifydialog notifydialog = new notifydialog();
                                notifydialog.error = true;
                                notifydialog.Title = "Error";
                                notifydialog.Message = "Course not rolled yet!";
                                notifydialog.Show();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            double prec = (count / aldys) * 100;

            return prec;
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i < 5)
            {

                //circularProgressBar1.Value += 1;

            }
            else
            {
                timer1.Stop();
                if (getprecentage() > 0 && getprecentage() <  100)
                {


                    circularProgressBar1.Value = Convert.ToInt32(Math.Round(getprecentage()));
                    
                }
                else
                {
                    if(getprecentage() > 100)
                    {
                        circularProgressBar1.Value = 100;
                    }
                    else
                    {
                        circularProgressBar1.Value = 0;
                    }
                    
                }
                circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";


            }

            if (circularProgressBar1.Value < 30)
            {
                circularProgressBar1.ProgressColor = Color.Red;
            }
            else
            {
                if (circularProgressBar1.Value < 75)
                {
                    circularProgressBar1.ProgressColor = Color.Orange;
                }
                else
                {
                    circularProgressBar1.ProgressColor = Color.Green;
                }
            }
        }
    }
}
