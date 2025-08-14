using System;
using System.Drawing;
using System.Windows.Forms;

namespace ESMS.User_Controls
{
    public partial class notifydialog : Form
    {
        public bool error { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public notifydialog()
        {
            InitializeComponent();
        }

        private void notifydialog_Load(object sender, EventArgs e)
        {
            title.Text = Title;
            message.Text = Message;
            if (error)
            {
                pictureBox1.Image = new Bitmap(Properties.Resources.error);
            }
            else
            {
                pictureBox1.Image = new Bitmap(Properties.Resources.check);

            }

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!error)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i == 15)
                    {
                        timer1.Stop();
                        this.Close();
                    }
                }
            }
        }
    }

}
