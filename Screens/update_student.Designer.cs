namespace ESMS.Screens
{
    partial class update_student
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(update_student));
            this.par_tel = new MaterialSkin.Controls.MaterialTextBox();
            this.par_name = new MaterialSkin.Controls.MaterialTextBox();
            this.nic = new MaterialSkin.Controls.MaterialTextBox();
            this.name = new MaterialSkin.Controls.MaterialTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bdate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Address = new MaterialSkin.Controls.MaterialTextBox();
            this.gender = new MaterialSkin.Controls.MaterialComboBox();
            this.tel = new MaterialSkin.Controls.MaterialTextBox();
            this.course = new MaterialSkin.Controls.MaterialComboBox();
            this.courcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSMSDataSet2 = new ESMS.ESMSDataSet2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.qrcod = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.courcesTableAdapter = new ESMS.ESMSDataSet2TableAdapters.courcesTableAdapter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMSDataSet2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // par_tel
            // 
            this.par_tel.AnimateReadOnly = false;
            this.par_tel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.par_tel.Depth = 0;
            this.par_tel.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.par_tel.Hint = "Guardian Telephone";
            this.par_tel.LeadingIcon = null;
            this.par_tel.Location = new System.Drawing.Point(37, 439);
            this.par_tel.MaxLength = 50;
            this.par_tel.MouseState = MaterialSkin.MouseState.OUT;
            this.par_tel.Multiline = false;
            this.par_tel.Name = "par_tel";
            this.par_tel.Size = new System.Drawing.Size(380, 50);
            this.par_tel.TabIndex = 8;
            this.par_tel.Text = "";
            this.par_tel.TrailingIcon = null;
            this.par_tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.par_tel_KeyPress);
            // 
            // par_name
            // 
            this.par_name.AnimateReadOnly = false;
            this.par_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.par_name.Depth = 0;
            this.par_name.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.par_name.Hint = "Guardian Name";
            this.par_name.LeadingIcon = null;
            this.par_name.Location = new System.Drawing.Point(38, 378);
            this.par_name.MaxLength = 50;
            this.par_name.MouseState = MaterialSkin.MouseState.OUT;
            this.par_name.Multiline = false;
            this.par_name.Name = "par_name";
            this.par_name.Size = new System.Drawing.Size(380, 50);
            this.par_name.TabIndex = 7;
            this.par_name.Text = "";
            this.par_name.TrailingIcon = null;
            // 
            // nic
            // 
            this.nic.AnimateReadOnly = false;
            this.nic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nic.Depth = 0;
            this.nic.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nic.Hint = "NIC";
            this.nic.LeadingIcon = null;
            this.nic.Location = new System.Drawing.Point(35, 318);
            this.nic.MaxLength = 50;
            this.nic.MouseState = MaterialSkin.MouseState.OUT;
            this.nic.Multiline = false;
            this.nic.Name = "nic";
            this.nic.Size = new System.Drawing.Size(380, 50);
            this.nic.TabIndex = 6;
            this.nic.Text = "";
            this.nic.TrailingIcon = null;
            // 
            // name
            // 
            this.name.AnimateReadOnly = false;
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.name.Hint = "Name";
            this.name.LeadingIcon = null;
            this.name.Location = new System.Drawing.Point(38, 21);
            this.name.MaxLength = 50;
            this.name.MouseState = MaterialSkin.MouseState.OUT;
            this.name.Multiline = false;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(380, 50);
            this.name.TabIndex = 1;
            this.name.Text = "";
            this.name.TrailingIcon = null;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.bdate);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(38, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 50);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date of Birth";
            // 
            // bdate
            // 
            this.bdate.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.bdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.bdate.Location = new System.Drawing.Point(8, 22);
            this.bdate.Name = "bdate";
            this.bdate.Size = new System.Drawing.Size(361, 20);
            this.bdate.TabIndex = 2;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ESMS.Properties.Resources.plus;
            this.pictureBox4.Location = new System.Drawing.Point(374, 511);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::ESMS.Properties.Resources.arrow;
            this.pictureBox1.Location = new System.Drawing.Point(500, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Address
            // 
            this.Address.AnimateReadOnly = false;
            this.Address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Address.Depth = 0;
            this.Address.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Address.Hint = "Address";
            this.Address.LeadingIcon = null;
            this.Address.Location = new System.Drawing.Point(38, 199);
            this.Address.MaxLength = 50;
            this.Address.MouseState = MaterialSkin.MouseState.OUT;
            this.Address.Multiline = false;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(380, 50);
            this.Address.TabIndex = 4;
            this.Address.Text = "";
            this.Address.TrailingIcon = null;
            // 
            // gender
            // 
            this.gender.AutoResize = false;
            this.gender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gender.Depth = 0;
            this.gender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gender.DropDownHeight = 174;
            this.gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gender.DropDownWidth = 121;
            this.gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gender.FormattingEnabled = true;
            this.gender.Hint = "Gender";
            this.gender.IntegralHeight = false;
            this.gender.ItemHeight = 43;
            this.gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gender.Location = new System.Drawing.Point(38, 139);
            this.gender.MaxDropDownItems = 4;
            this.gender.MouseState = MaterialSkin.MouseState.OUT;
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(380, 49);
            this.gender.StartIndex = 0;
            this.gender.TabIndex = 3;
            // 
            // tel
            // 
            this.tel.AnimateReadOnly = false;
            this.tel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tel.Depth = 0;
            this.tel.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tel.Hint = "Telephone";
            this.tel.LeadingIcon = null;
            this.tel.Location = new System.Drawing.Point(38, 259);
            this.tel.MaxLength = 50;
            this.tel.MouseState = MaterialSkin.MouseState.OUT;
            this.tel.Multiline = false;
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(380, 50);
            this.tel.TabIndex = 5;
            this.tel.Text = "";
            this.tel.TrailingIcon = null;
            this.tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tel_KeyPress);
            // 
            // course
            // 
            this.course.AutoResize = false;
            this.course.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.course.DataSource = this.courcesBindingSource;
            this.course.Depth = 0;
            this.course.DisplayMember = "course_name";
            this.course.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.course.DropDownHeight = 174;
            this.course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.course.DropDownWidth = 121;
            this.course.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.course.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.course.FormattingEnabled = true;
            this.course.Hint = "Course";
            this.course.IntegralHeight = false;
            this.course.ItemHeight = 43;
            this.course.Location = new System.Drawing.Point(38, 504);
            this.course.MaxDropDownItems = 4;
            this.course.MouseState = MaterialSkin.MouseState.OUT;
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(321, 49);
            this.course.StartIndex = 0;
            this.course.TabIndex = 9;
            this.course.ValueMember = "id";
            // 
            // courcesBindingSource
            // 
            this.courcesBindingSource.DataMember = "cources";
            this.courcesBindingSource.DataSource = this.eSMSDataSet2;
            // 
            // eSMSDataSet2
            // 
            this.eSMSDataSet2.DataSetName = "ESMSDataSet2";
            this.eSMSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.materialButton2);
            this.panel1.Controls.Add(this.par_tel);
            this.panel1.Controls.Add(this.par_name);
            this.panel1.Controls.Add(this.nic);
            this.panel1.Controls.Add(this.qrcod);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.materialButton1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.Address);
            this.panel1.Controls.Add(this.gender);
            this.panel1.Controls.Add(this.tel);
            this.panel1.Controls.Add(this.course);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 749);
            this.panel1.TabIndex = 18;
            // 
            // materialButton2
            // 
            this.materialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(487, 694);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(73, 36);
            this.materialButton2.TabIndex = 12;
            this.materialButton2.Text = "Delete";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // qrcod
            // 
            this.qrcod.AllowPromptAsInput = true;
            this.qrcod.AnimateReadOnly = false;
            this.qrcod.AsciiOnly = false;
            this.qrcod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.qrcod.BeepOnError = false;
            this.qrcod.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.qrcod.Depth = 0;
            this.qrcod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.qrcod.HidePromptOnLeave = false;
            this.qrcod.HideSelection = true;
            this.qrcod.Hint = "Scan QR";
            this.qrcod.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.qrcod.LeadingIcon = null;
            this.qrcod.Location = new System.Drawing.Point(38, 621);
            this.qrcod.Mask = "";
            this.qrcod.MaxLength = 32767;
            this.qrcod.MouseState = MaterialSkin.MouseState.OUT;
            this.qrcod.Name = "qrcod";
            this.qrcod.PasswordChar = '\0';
            this.qrcod.PrefixSuffixText = null;
            this.qrcod.PromptChar = '_';
            this.qrcod.ReadOnly = false;
            this.qrcod.RejectInputOnFirstFailure = false;
            this.qrcod.ResetOnPrompt = true;
            this.qrcod.ResetOnSpace = true;
            this.qrcod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.qrcod.SelectedText = "";
            this.qrcod.SelectionLength = 0;
            this.qrcod.SelectionStart = 0;
            this.qrcod.ShortcutsEnabled = true;
            this.qrcod.Size = new System.Drawing.Size(380, 48);
            this.qrcod.SkipLiterals = true;
            this.qrcod.TabIndex = 10;
            this.qrcod.TabStop = false;
            this.qrcod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.qrcod.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.qrcod.TrailingIcon = global::ESMS.Properties.Resources.qr;
            this.qrcod.UseSystemPasswordChar = false;
            this.qrcod.ValidatingType = null;
            this.qrcod.Enter += new System.EventHandler(this.qrcod_Enter);
            // 
            // materialButton1
            // 
            this.materialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(663, 694);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(75, 36);
            this.materialButton1.TabIndex = 11;
            this.materialButton1.Text = "submit";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 563);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 48);
            this.flowLayoutPanel1.TabIndex = 15;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // courcesTableAdapter
            // 
            this.courcesTableAdapter.ClearBeforeFill = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // update_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "update_student";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.update_student_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.update_student_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMSDataSet2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox par_tel;
        private MaterialSkin.Controls.MaterialTextBox par_name;
        private MaterialSkin.Controls.MaterialTextBox nic;
        private MaterialSkin.Controls.MaterialTextBox name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker bdate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox Address;
        private MaterialSkin.Controls.MaterialComboBox gender;
        private MaterialSkin.Controls.MaterialTextBox tel;
        private MaterialSkin.Controls.MaterialComboBox course;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox qrcod;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ESMSDataSet2 eSMSDataSet2;
        private System.Windows.Forms.BindingSource courcesBindingSource;
        private ESMSDataSet2TableAdapters.courcesTableAdapter courcesTableAdapter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
    }
}