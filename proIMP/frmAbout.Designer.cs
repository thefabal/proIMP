namespace proIMP {
    partial class frmAbout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblLicence = new System.Windows.Forms.Label();
            this.lblBuildTime = new System.Windows.Forms.Label();
            this.lblBuildTimeText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAboutHomePage = new System.Windows.Forms.Label();
            this.lblAboutAuthor = new System.Windows.Forms.Label();
            this.labelURL = new System.Windows.Forms.LinkLabel();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(306, 154);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblLicence
            // 
            this.lblLicence.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLicence.Location = new System.Drawing.Point(170, 105);
            this.lblLicence.Name = "lblLicence";
            this.lblLicence.Size = new System.Drawing.Size(211, 46);
            this.lblLicence.TabIndex = 19;
            this.lblLicence.Text = "Freely use for non-commercial purpose";
            this.lblLicence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBuildTime
            // 
            this.lblBuildTime.AutoSize = true;
            this.lblBuildTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBuildTime.Location = new System.Drawing.Point(252, 92);
            this.lblBuildTime.Name = "lblBuildTime";
            this.lblBuildTime.Size = new System.Drawing.Size(35, 13);
            this.lblBuildTime.TabIndex = 18;
            this.lblBuildTime.Text = "label5";
            // 
            // lblBuildTimeText
            // 
            this.lblBuildTimeText.AutoSize = true;
            this.lblBuildTimeText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBuildTimeText.Location = new System.Drawing.Point(167, 92);
            this.lblBuildTimeText.Name = "lblBuildTimeText";
            this.lblBuildTimeText.Size = new System.Drawing.Size(58, 13);
            this.lblBuildTimeText.TabIndex = 17;
            this.lblBuildTimeText.Text = "Build time :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(252, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "proGEDIA Team";
            // 
            // lblAboutHomePage
            // 
            this.lblAboutHomePage.AutoSize = true;
            this.lblAboutHomePage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAboutHomePage.Location = new System.Drawing.Point(167, 72);
            this.lblAboutHomePage.Name = "lblAboutHomePage";
            this.lblAboutHomePage.Size = new System.Drawing.Size(65, 13);
            this.lblAboutHomePage.TabIndex = 15;
            this.lblAboutHomePage.Text = "Homepage :";
            // 
            // lblAboutAuthor
            // 
            this.lblAboutAuthor.AutoSize = true;
            this.lblAboutAuthor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAboutAuthor.Location = new System.Drawing.Point(167, 52);
            this.lblAboutAuthor.Name = "lblAboutAuthor";
            this.lblAboutAuthor.Size = new System.Drawing.Size(47, 13);
            this.lblAboutAuthor.TabIndex = 14;
            this.lblAboutAuthor.Text = "Author : ";
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelURL.LinkColor = System.Drawing.Color.Blue;
            this.labelURL.Location = new System.Drawing.Point(252, 72);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(71, 13);
            this.labelURL.TabIndex = 13;
            this.labelURL.TabStop = true;
            this.labelURL.Tag = "progedia.com";
            this.labelURL.Text = "progedia.com";
            this.labelURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelURL.VisitedLinkColor = System.Drawing.Color.Blue;
            this.labelURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelURL_LinkClicked);
            // 
            // lblProgramName
            // 
            this.lblProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblProgramName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProgramName.Location = new System.Drawing.Point(167, 12);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(214, 20);
            this.lblProgramName.TabIndex = 12;
            this.lblProgramName.Text = "proGEDIA Inventory Manager";
            this.lblProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(393, 189);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLicence);
            this.Controls.Add(this.lblBuildTime);
            this.Controls.Add(this.lblBuildTimeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAboutHomePage);
            this.Controls.Add(this.lblAboutAuthor);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblLicence;
        private System.Windows.Forms.Label lblBuildTime;
        private System.Windows.Forms.Label lblBuildTimeText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAboutHomePage;
        private System.Windows.Forms.Label lblAboutAuthor;
        private System.Windows.Forms.LinkLabel labelURL;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}