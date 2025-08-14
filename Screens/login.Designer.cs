namespace ESMS
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.submit = new MaterialSkin.Controls.MaterialButton();
            this.username = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.passwd = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submit.AutoSize = false;
            this.submit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.submit.Depth = 0;
            this.submit.HighEmphasis = true;
            this.submit.Icon = null;
            this.submit.Location = new System.Drawing.Point(475, 321);
            this.submit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.submit.MouseState = MaterialSkin.MouseState.HOVER;
            this.submit.Name = "submit";
            this.submit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.submit.Size = new System.Drawing.Size(153, 36);
            this.submit.TabIndex = 2;
            this.submit.Text = "Login";
            this.submit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.submit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.submit.UseAccentColor = false;
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.username.AnimateReadOnly = false;
            this.username.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.username.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.username.Depth = 0;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.username.HideSelection = true;
            this.username.Hint = "User Name";
            this.username.LeadingIcon = null;
            this.username.Location = new System.Drawing.Point(362, 153);
            this.username.MaxLength = 32767;
            this.username.MouseState = MaterialSkin.MouseState.OUT;
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PrefixSuffixText = null;
            this.username.ReadOnly = false;
            this.username.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.username.SelectedText = "";
            this.username.SelectionLength = 0;
            this.username.SelectionStart = 0;
            this.username.ShortcutsEnabled = true;
            this.username.Size = new System.Drawing.Size(378, 48);
            this.username.TabIndex = 0;
            this.username.TabStop = false;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.username.TrailingIcon = null;
            this.username.UseSystemPasswordChar = false;
            this.username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.username_KeyDown);
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(71, 333);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(200, 23);
            this.materialCard1.TabIndex = 5;
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLinkLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.kryptonLinkLabel1.LinkBehavior = ComponentFactory.Krypton.Toolkit.KryptonLinkBehavior.HoverUnderline;
            this.kryptonLinkLabel1.LinkVisited = true;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(26, -2);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(40, 26);
            this.kryptonLinkLabel1.TabIndex = 0;
            this.kryptonLinkLabel1.Values.Text = "Help";
            this.kryptonLinkLabel1.LinkClicked += new System.EventHandler(this.kryptonLinkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.kryptonLinkLabel1);
            this.panel1.Location = new System.Drawing.Point(22, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 24);
            this.panel1.TabIndex = 4;
            
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::ESMS.Properties.Resources.help_icon_12;
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(190, -2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonLabel2.Size = new System.Drawing.Size(450, 29);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "SKILLS - SKILLS STUDENT MANAGEMENT SYSTEM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ESMS.Properties.Resources.d16be8c4701395972a4c753e93de1217__1__removebg_preview__1_;
            this.pictureBox1.Location = new System.Drawing.Point(48, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // passwd
            // 
            this.passwd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.passwd.AnimateReadOnly = false;
            this.passwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.passwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.passwd.Depth = 0;
            this.passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passwd.HideSelection = true;
            this.passwd.Hint = "Password";
            this.passwd.LeadingIcon = null;
            this.passwd.Location = new System.Drawing.Point(362, 230);
            this.passwd.MaxLength = 32767;
            this.passwd.MouseState = MaterialSkin.MouseState.OUT;
            this.passwd.Name = "passwd";
            this.passwd.PasswordChar = '●';
            this.passwd.PrefixSuffixText = null;
            this.passwd.ReadOnly = false;
            this.passwd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwd.SelectedText = "";
            this.passwd.SelectionLength = 0;
            this.passwd.SelectionStart = 0;
            this.passwd.ShortcutsEnabled = true;
            this.passwd.Size = new System.Drawing.Size(378, 48);
            this.passwd.TabIndex = 1;
            this.passwd.TabStop = false;
            this.passwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passwd.TrailingIcon = global::ESMS.Properties.Resources.show;
            this.passwd.UseSystemPasswordChar = true;
            this.passwd.TrailingIconClick += new System.EventHandler(this.passwd_TrailingIconClick);
            this.passwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwd_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(22, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "By Group A";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.submit);
            this.DrawerBackgroundWithAccent = true;
            this.DrawerUseColors = true;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_64;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(3, 88, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKILLS - LOGIN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton submit;
        private MaterialSkin.Controls.MaterialTextBox2 username;
        private MaterialSkin.Controls.MaterialTextBox2 passwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.Label label1;
    }
}

