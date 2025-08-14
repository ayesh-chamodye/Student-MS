using ESMS.Settings;
using ESMS.User_Controls;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ESMS.Screens
{
    public partial class pay : Form
    {
        public pay()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        class courseitem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
        public int stid { get; set; }
        public int crsid { get; set; }
        public int[] coses { get; set; }
        private void pay_Load(object sender, EventArgs e)
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
                                    comboBox1.DataSource = dt;
                                    comboBox1.DisplayMember = "Name";
                                    comboBox1.ValueMember = "id";
                                    comboBox1.SelectedIndex = 0;
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
            // TODO: This line of code loads data into the 'eSMSDataSet3.cources' table. You can move, or remove it, as needed.
            this.courcesTableAdapter.Fill(this.eSMSDataSet3.cources);



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loadqry = "select * from payment where stid = @stid and course_id = @crsid ";
            if (!(comboBox1.Items.Count == 0))
            {
                using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(loadqry, conn))
                        {
                            DataRowView selectedItem = (DataRowView)comboBox1.SelectedItem;
                            int selectedCrsId = (int)selectedItem["id"];


                            cmd.Parameters.AddWithValue("@stid", (int)stid);
                            cmd.Parameters.AddWithValue("@crsid", (int)selectedCrsId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        paid.Text = reader.GetString(3);

                                    }
                                }
                                else
                                {
                                    paid.Text = "0.00";
                                }
                            }
                        }

                        string crsqry = "select * from cources where id = @crsid";

                        using (SqlCommand cmd = new SqlCommand(crsqry, conn))

                        {
                            DataRowView selectedItem = (DataRowView)comboBox1.SelectedItem;
                            int selectedCrsId = (int)selectedItem["id"];
                            cmd.Parameters.AddWithValue("@crsid", (int)selectedCrsId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        fee.Text = reader.GetDouble(2).ToString();
                                    }
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Clipboard.SetText(ex.ToString());
                    }

                    due.Text = ((Convert.ToDouble(fee.Text.Trim().ToString())) - (Convert.ToDouble(paid.Text.Trim().ToString()))).ToString();
                }

            }
            else
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.error = true;
                notifydialog.Title = "Error";
                notifydialog.Message = "Not registered to Cources!";
                notifydialog.Show();
                this.Close();
            }
        }

        private void pay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("{Tab}");
            }
        }

        int payid {  get; set; }
        private void materialButton8_Click(object sender, EventArgs e)
        {
            Double duea = Convert.ToDouble(due.Text);
            Double paya = Convert.ToDouble(materialTextBox2.Text + "." + materialTextBox3.Text);
            Double paida = Convert.ToDouble(paid.Text);

            if (duea > paya)
            {
                Double payment = paida + paya;


                
                using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
                {
                    conn.Open();
                    
                    bool has = false;
                    string query = "SELECT * FROM payment WHERE course_id = @corseid and stid = @stid";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataRowView selectedItem = (DataRowView)comboBox1.SelectedItem;
                        int selectedCrsId = (int)selectedItem["id"];
                        cmd.Parameters.AddWithValue("@corseid", (int)selectedCrsId);
                        cmd.Parameters.AddWithValue("@stid", (int)stid);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    payid = reader.GetInt32(0);
                                    has = true;
                                }
                            }
                            else
                            {
                                has = false;
                            }
                        }
                    }

                    if (has)
                    {
                        string update = "UPDATE payment SET paid = @paid , date = @day WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(update, conn))
                        {
                            DateTime dateTime = DateTime.Now;
                            cmd.Parameters.AddWithValue("@id", (int)payid);
                            cmd.Parameters.AddWithValue("@paid", (int)payment);
                            cmd.Parameters.AddWithValue("@day", dateTime.Date);
                            cmd.ExecuteNonQuery();
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.error = false;
                            notifydialog.Title = "Paid!";
                            notifydialog.Message = "Payment Successfull!";
                            notifydialog.Show();
                           
                        }
                    }
                    else
                    {
                        string insert = "INSERT INTO payment (course_id,stid,paid,date) VALUES (@corseid,@stid,@paid,@date)";
                        using (SqlCommand cmd = new SqlCommand(insert, conn))
                        {
                            DateTime dateTime = DateTime.Now;
                            DataRowView selectedItem = (DataRowView)comboBox1.SelectedItem;
                            int selectedCrsId = (int)selectedItem["id"];
                            cmd.Parameters.AddWithValue("@corseid", (int)selectedCrsId);
                            cmd.Parameters.AddWithValue("@stid", (int)stid);
                            cmd.Parameters.AddWithValue("@paid", (int)payment);
                            cmd.Parameters.AddWithValue("@date", dateTime.Date);
                            cmd.ExecuteNonQuery();
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.error = false;
                            notifydialog.Title = "Paid!";
                            notifydialog.Message = "Payment Successfull!";
                            notifydialog.Show();

                        }

                    }

                }
            }
            else
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.error = true;
                notifydialog.Title = "Error";
                notifydialog.Message = "Payment is Higher Than Due!";
                notifydialog.Show();
            }
        }



        private void materialTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || materialTextBox3.TextLength >= 2)
            {
                e.Handled = true;
            }
        }

        private void materialTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
