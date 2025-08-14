using ESMS.Properties;
using ESMS.Screens;
using ESMS.Settings;
using ESMS.User_Controls;
using MaterialSkin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ESMS
{
    public partial class Login : MaterialSkin.Controls.MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
            

        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
       

        private void submit_Click(object sender, EventArgs e)
        {
             
            using (SqlConnection conn = new SqlConnection(AppliationSettings.ConnectionString()))
            {
                string login = "SELECT '#' FROM users WHERE usr='" + username.Text + "' COLLATE Latin1_General_CS_AS AND password='" + passwd.Text + "' COLLATE Latin1_General_CS_AS";
                using (SqlCommand cmd = new SqlCommand(login, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (valid())
                    {
                        if (reader.Read())
                        {
                            home home = new home();
                            home.Show();
                            this.Hide();
                        }
                        else
                        {
                            notifydialog notifydialog = new notifydialog();
                            notifydialog.Title = "Error";
                            notifydialog.Message = "Username or Password is Incorrect!";
                            notifydialog.error = true;
                            notifydialog.Show();
                        }
                    }
                }


            }



        }
        private bool valid()
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                notifydialog notifydialog = new notifydialog();
                notifydialog.Title = "Error";
                notifydialog.Message = "Username can not be Empty!";
                notifydialog.error = true;
                notifydialog.Show();
                return false;


            }
            else
            {
                if (string.IsNullOrEmpty(passwd.Text))
                {
                    notifydialog notifydialog = new notifydialog();
                    notifydialog.Title = "Error";
                    notifydialog.Message = "Password can not be Empty!";
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

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                submit.PerformClick();
            }
        }
         
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SendKeys.Send("{Tab}");
            }
        }

        public bool showpwd {  get; set; } = false;
        private void passwd_TrailingIconClick(object sender, EventArgs e)
        {
            showpwd  = !showpwd;
            if (showpwd)
            {
                passwd.UseSystemPasswordChar = false;
                passwd.PasswordChar = '\0';
                passwd.TrailingIcon = Resources.hide;
                
            }
            else
            {
                passwd.UseSystemPasswordChar = true;
                passwd.TrailingIcon = Resources.show;
                passwd.PasswordChar = '●';
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "SKILLS - LOGIN", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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

       
    }
}
