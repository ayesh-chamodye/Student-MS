using ESMS.Settings;
using ESMS.User_Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ESMS.Screens
{
    public partial class update_courses : Form
    {
        public update_courses()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public int id { get; set; }
        public bool update { get; set; } = true;
        private void update_courses_Load(object sender, EventArgs e)
        {
            if (update)
            {
                string qry = "SELECT * FROM cources WHERE id='" + id + "'";

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
                                        string val = reader.GetDouble(2).ToString();
                                        string[] parts = val.Split('.');
                                        materialTextBox1.Text = reader.GetString(1);
                                        materialTextBox2.Text = parts[0];
                                        materialTextBox3.Text = parts.Length > 1 ? parts[1] : "00";
                                        roll.Value = reader.GetDateTime(3);
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
            else
            {
                materialButton1.Text = "Clear";
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {

            if (update)
            {
                string qry = "UPDATE [dbo].[cources] SET [course_name] = @name,[course_fee] = @fee,[roll_date] = @date WHERE id = @id";

                try
                {

                    using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(qry, con))
                        {

                            double fee = Double.Parse((materialTextBox2.Text.Trim() + "." + materialTextBox3.Text.Trim()).ToString());
                            DateTime date = roll.Value.Date;
                            command.Parameters.AddWithValue("@name", materialTextBox1.Text);
                            command.Parameters.AddWithValue("@fee", fee);
                            command.Parameters.AddWithValue("@date", date);
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();

                            notifydialog notifydialog = new notifydialog();
                            notifydialog.error = false;
                            notifydialog.Title = "Saved!";
                            notifydialog.Message = "Course saved successfully!";
                            notifydialog.Show();

                            home.Instance.Hide();
                            home h = new home();
                            h.Show();
                            this.Hide();

                        }

                    }
                }
                catch (Exception ex)
                {
                    notifydialog notifydialog = new notifydialog();
                    notifydialog.Title = "Error!";
                    notifydialog.Message = "Error save course: " + ex.Message;
                    notifydialog.error = true;
                    notifydialog.Show();
                }
            }
            else
            {

                if (Valid())
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                        {


                            using (SqlCommand command = new SqlCommand("dbo.insert_course", con))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                double fee = Double.Parse((materialTextBox2.Text.Trim() + "." + materialTextBox3.Text.Trim()).ToString());

                                command.Parameters.AddWithValue("@name", materialTextBox1.Text);
                                command.Parameters.AddWithValue("@fee", fee);
                                command.Parameters.AddWithValue("@date", roll.Value.ToShortDateString());
                                
                                con.Open();
                                command.ExecuteNonQuery();

                                notifydialog notifydialog = new notifydialog();
                                notifydialog.error = false;
                                notifydialog.Title = "Saved!";
                                notifydialog.Message = "Course saved successfully!";
                                notifydialog.Show();
                                this.Close();
                                home.Instance.Hide();
                                home h = new home();
                                h.Show();





                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        notifydialog notifydialog = new notifydialog();
                        notifydialog.Title = "Error!";
                        notifydialog.Message = "Error save course: " + ex.Message;
                        notifydialog.error = true;
                        notifydialog.Show();
                    }
                }
            }
        }

        private bool Valid()
        {
            if (String.IsNullOrEmpty(materialTextBox1.Text.Trim()))
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.Title = "Error!";
                notifydialog.Message = "Course name can not be empty!";
                notifydialog.error = true;
                notifydialog.Show();
                return false;
            }
            else
            {
                if (String.IsNullOrEmpty(materialTextBox2.Text.Trim()))
                {
                    notifydialog notifydialog = new notifydialog();
                    notifydialog.Title = "Error!";
                    notifydialog.Message = "Course fee can not be empty!";
                    notifydialog.error = true;
                    notifydialog.Show();
                    return false;
                }
                else { return true; }
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (update)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
                    {
                        con.Open();
                        string coqu = "SELECT * FROM student";
                        List<int> stids = new List<int>();
                        List<string> corseids = new List<string>();
                        using (SqlCommand command = new SqlCommand(coqu, con))
                        {




                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {

                                    int[] crs = JsonConvert.DeserializeObject<int[]>(reader.GetString(6));
                                    List<int> ints = new List<int>();
                                    foreach (int i in crs)
                                    {
                                        ints.Add(i);
                                    }



                                    if (crs.Contains(id))
                                    {
                                        ints.Remove(id);
                                        stids.Add(reader.GetInt32(0));
                                        string corse = JsonConvert.SerializeObject(ints.ToArray());
                                        corseids.Add(corse);
                                    }


                                }


                            }
                        }





                        foreach (int id in stids)
                        {

                            string upq = "UPDATE student set courseID = '" + corseids[stids.IndexOf(id)] + "' where stid = '" + id + "'";

                            using (SqlCommand cmd = new SqlCommand(upq, con))
                            {

                                cmd.CommandType = CommandType.Text;

                                cmd.ExecuteNonQuery();

                            }
                        }


                        string delq = "DELETE cources where id = '" + id + "'";

                        using (SqlCommand cmd = new SqlCommand(delq, con))
                        {

                            cmd.CommandType = CommandType.Text;

                            cmd.ExecuteNonQuery();

                            notifydialog notifydialog = new notifydialog();
                            notifydialog.error = false;
                            notifydialog.Title = "Saved!";
                            notifydialog.Message = "Course Deleted successfully!";
                            notifydialog.Show();
                            home.Instance.Hide();
                            home h = new home();
                            h.Show();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Clipboard.SetText(ex.ToString());
                }
            }
            else
            {
                materialTextBox1.Text = string.Empty;
                materialTextBox2.Text = string.Empty;
                materialTextBox3.Text = string.Empty;
            }
        }



        private void materialTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void materialTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || materialTextBox3.TextLength >= 2)
            {
                e.Handled = true; 
            }
        }

        private void update_courses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("{Tab}");
            }
        }
    }
}
