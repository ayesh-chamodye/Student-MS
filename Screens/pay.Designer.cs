namespace ESMS.Screens
{
    partial class pay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pay));
            this.fee = new MaterialSkin.Controls.MaterialLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.paid = new MaterialSkin.Controls.MaterialLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.materialTextBox3 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.materialButton8 = new MaterialSkin.Controls.MaterialButton();
            this.due = new MaterialSkin.Controls.MaterialLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.eSMSDataSet3 = new ESMS.ESMSDataSet3();
            this.courcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courcesTableAdapter = new ESMS.ESMSDataSet3TableAdapters.courcesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.eSMSDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courcesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fee
            // 
            this.fee.AutoSize = true;
            this.fee.Depth = 0;
            this.fee.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fee.Location = new System.Drawing.Point(275, 58);
            this.fee.MouseState = MaterialSkin.MouseState.HOVER;
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(1, 0);
            this.fee.TabIndex = 12;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(101, 58);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(42, 29);
            this.kryptonLabel3.TabIndex = 11;
            this.kryptonLabel3.Values.Text = "Fee";
            // 
            // paid
            // 
            this.paid.AutoSize = true;
            this.paid.Depth = 0;
            this.paid.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.paid.Location = new System.Drawing.Point(275, 121);
            this.paid.MouseState = MaterialSkin.MouseState.HOVER;
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(1, 0);
            this.paid.TabIndex = 14;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(101, 121);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(51, 29);
            this.kryptonLabel1.TabIndex = 13;
            this.kryptonLabel1.Values.Text = "Paid";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(261, 254);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(38, 29);
            this.kryptonLabel2.TabIndex = 49;
            this.kryptonLabel2.Values.Text = "Rs.";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(457, 254);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(18, 29);
            this.kryptonLabel4.TabIndex = 48;
            this.kryptonLabel4.Values.Text = ".";
            // 
            // materialTextBox3
            // 
            this.materialTextBox3.AnimateReadOnly = false;
            this.materialTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox3.Depth = 0;
            this.materialTextBox3.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox3.LeadingIcon = null;
            this.materialTextBox3.Location = new System.Drawing.Point(477, 239);
            this.materialTextBox3.MaxLength = 50;
            this.materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox3.Multiline = false;
            this.materialTextBox3.Name = "materialTextBox3";
            this.materialTextBox3.Size = new System.Drawing.Size(58, 50);
            this.materialTextBox3.TabIndex = 3;
            this.materialTextBox3.Text = "";
            this.materialTextBox3.TrailingIcon = null;
            this.materialTextBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialTextBox3_KeyPress);
            // 
            // materialTextBox2
            // 
            this.materialTextBox2.AnimateReadOnly = false;
            this.materialTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox2.Depth = 0;
            this.materialTextBox2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox2.LeadingIcon = null;
            this.materialTextBox2.Location = new System.Drawing.Point(305, 239);
            this.materialTextBox2.MaxLength = 50;
            this.materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox2.Multiline = false;
            this.materialTextBox2.Name = "materialTextBox2";
            this.materialTextBox2.Size = new System.Drawing.Size(151, 50);
            this.materialTextBox2.TabIndex = 2;
            this.materialTextBox2.Text = "";
            this.materialTextBox2.TrailingIcon = null;
            this.materialTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialTextBox2_KeyPress);
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel15.Location = new System.Drawing.Point(101, 260);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(89, 29);
            this.kryptonLabel15.TabIndex = 45;
            this.kryptonLabel15.Values.Text = "Payment";
            // 
            // materialButton8
            // 
            this.materialButton8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton8.Depth = 0;
            this.materialButton8.HighEmphasis = true;
            this.materialButton8.Icon = null;
            this.materialButton8.Location = new System.Drawing.Point(339, 374);
            this.materialButton8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton8.Name = "materialButton8";
            this.materialButton8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton8.Size = new System.Drawing.Size(64, 36);
            this.materialButton8.TabIndex = 50;
            this.materialButton8.Text = "Pay";
            this.materialButton8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton8.UseAccentColor = false;
            this.materialButton8.UseVisualStyleBackColor = true;
            this.materialButton8.Click += new System.EventHandler(this.materialButton8_Click);
            // 
            // due
            // 
            this.due.AutoSize = true;
            this.due.Depth = 0;
            this.due.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.due.Location = new System.Drawing.Point(275, 186);
            this.due.MouseState = MaterialSkin.MouseState.HOVER;
            this.due.Name = "due";
            this.due.Size = new System.Drawing.Size(1, 0);
            this.due.TabIndex = 52;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(101, 186);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(47, 29);
            this.kryptonLabel5.TabIndex = 51;
            this.kryptonLabel5.Values.Text = "Due";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(261, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 32);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel9.Location = new System.Drawing.Point(101, 12);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(72, 29);
            this.kryptonLabel9.TabIndex = 53;
            this.kryptonLabel9.Values.Text = "Course";
            // 
            // eSMSDataSet3
            // 
            this.eSMSDataSet3.DataSetName = "ESMSDataSet3";
            this.eSMSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // courcesBindingSource
            // 
            this.courcesBindingSource.DataMember = "cources";
            this.courcesBindingSource.DataSource = this.eSMSDataSet3;
            // 
            // courcesTableAdapter
            // 
            this.courcesTableAdapter.ClearBeforeFill = true;
            // 
            // pay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.kryptonLabel9);
            this.Controls.Add(this.due);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.materialButton8);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.materialTextBox3);
            this.Controls.Add(this.materialTextBox2);
            this.Controls.Add(this.kryptonLabel15);
            this.Controls.Add(this.paid);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.kryptonLabel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.pay_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pay_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.eSMSDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courcesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel fee;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private MaterialSkin.Controls.MaterialLabel paid;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox3;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private MaterialSkin.Controls.MaterialButton materialButton8;
        private MaterialSkin.Controls.MaterialLabel due;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.ComboBox comboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ESMSDataSet3 eSMSDataSet3;
        private System.Windows.Forms.BindingSource courcesBindingSource;
        private ESMSDataSet3TableAdapters.courcesTableAdapter courcesTableAdapter;
    }
}