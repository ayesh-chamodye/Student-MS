using System;
using System.Windows.Forms;

namespace ESMS.User_Controls
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://wa.me/+94766568369");
            this.Close();
        }

        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ayeshchamodye@gmail.com");
            this.Close();
        }
    }
}
