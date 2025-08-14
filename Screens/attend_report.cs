using ESMS.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ESMS.Screens
{
    public partial class attend_report : Form
    {
        public attend_report()
        {
            InitializeComponent();
        }

        private void attend_report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMSDataSet5.cources' table. You can move, or remove it, as needed.
            this.courcesTableAdapter.Fill(this.eSMSDataSet5.cources);
            setdata();
        }

        private void setdata()
        {
            DateTime day = dateTimePicker1.Value.Date;
            string qry = $"select s.Name,s.tel AS 'Telephone',c.course_name AS 'Course',a.date AS 'Date' from attend a inner join student s on a.stid = s.stid left join cources c on a.course_id = c.id where a.date ='{day}' and a.course_id = '{materialComboBox1.SelectedValue}'";
            using(SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(qry,con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    metroGrid1.DataSource = dt;
                    kryptonLabel2.Text = dt.Rows.Count.ToString();
                }
            }
        }

       

      

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setdata();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            setdata();
        }
    }
}
