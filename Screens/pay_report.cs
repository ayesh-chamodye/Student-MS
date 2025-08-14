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
using System.Windows.Forms;

namespace ESMS.Screens
{
    public partial class pay_report : Form
    {
        public pay_report()
        {
            InitializeComponent();
        }

        private void pay_report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMSDataSet4.cources' table. You can move, or remove it, as needed.
            this.courcesTableAdapter.Fill(this.eSMSDataSet4.cources);
            showlist();
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showlist();
        }

        private void showlist()
        {

            int corse;
            string query = $"select s.Name,s.tel AS 'Telephone',c.course_name As 'Course',p.paid As 'Amount',p.date As 'Date' from payment p inner join student s on p.stid = s.stid left join cources c on c.id = p.course_id where c.id = '{materialComboBox1.SelectedValue}'";
            using(SqlConnection con = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query,con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    metroGrid1.DataSource = dt;
                }
            }
            
        }

       
    }
}
