using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMS.Screens
{
    public partial class welcome : MaterialSkin.Controls.MaterialForm
    {
        public welcome()
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green800, Primary.Green700, Accent.Green400, TextShade.WHITE);        
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

       
    }
}
