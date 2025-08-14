using ESMS.Screens;
using System;
using System.Windows.Forms;

namespace ESMS.User_Controls
{
    public partial class courseadd : UserControl
    {
        public string coursename { get; set; }
        public int courseid { get; set; }
        public courseadd()
        {
            InitializeComponent();
        }

        private void course_Load(object sender, EventArgs e)
        {
            materialLabel1.Text = coursename;
        }
        public bool update { get; set; }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (update)
            {
                update_student.Instance.courses.Controls.Remove(this);
                update_student.Instance.crsids.Remove(courseid);
            }
            else
            {
                home.Instance.layoutPanel.Controls.Remove(this);
                home.Instance.crsids.Remove(courseid);
            }
        }
    }
}
