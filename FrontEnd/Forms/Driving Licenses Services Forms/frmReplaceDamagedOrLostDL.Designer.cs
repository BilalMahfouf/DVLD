namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    partial class frmReplaceDamagedOrLostDL
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
            this.findLocalLicenseController1 = new FrontEnd.Controllers.LicenseControllers.FindLocalLicenseController();
            this.lblMode = new System.Windows.Forms.Label();
            this.linklblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.gbApplicaiton = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblReplacementLicenseID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLRApplicationID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.gbApplicaiton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // findLocalLicenseController1
            // 
            this.findLocalLicenseController1.Location = new System.Drawing.Point(-9, 79);
            this.findLocalLicenseController1.Name = "findLocalLicenseController1";
            this.findLocalLicenseController1.Size = new System.Drawing.Size(1239, 520);
            this.findLocalLicenseController1.TabIndex = 0;
            this.findLocalLicenseController1.OnFindClick += new System.Action<int>(this.findLocalLicenseController1_OnFindClick);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.SystemColors.Control;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(248, 23);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(786, 54);
            this.lblMode.TabIndex = 76;
            this.lblMode.Text = "Replacement for Damaged License";
            // 
            // linklblShowLicenseInfo
            // 
            this.linklblShowLicenseInfo.AutoSize = true;
            this.linklblShowLicenseInfo.Enabled = false;
            this.linklblShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowLicenseInfo.Location = new System.Drawing.Point(15, 803);
            this.linklblShowLicenseInfo.Name = "linklblShowLicenseInfo";
            this.linklblShowLicenseInfo.Size = new System.Drawing.Size(172, 25);
            this.linklblShowLicenseInfo.TabIndex = 82;
            this.linklblShowLicenseInfo.TabStop = true;
            this.linklblShowLicenseInfo.Text = "Show License Info";
            this.linklblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseInfo_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.White;
            this.btnIssue.Enabled = false;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::FrontEnd.Properties.Resources.Renew_Driving_License_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(910, 793);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(306, 44);
            this.btnIssue.TabIndex = 81;
            this.btnIssue.Text = "   Issue Replacement";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // gbApplicaiton
            // 
            this.gbApplicaiton.Controls.Add(this.pictureBox1);
            this.gbApplicaiton.Controls.Add(this.pictureBox13);
            this.gbApplicaiton.Controls.Add(this.label13);
            this.gbApplicaiton.Controls.Add(this.lblCreatedBy);
            this.gbApplicaiton.Controls.Add(this.pictureBox10);
            this.gbApplicaiton.Controls.Add(this.label9);
            this.gbApplicaiton.Controls.Add(this.lblReplacementLicenseID);
            this.gbApplicaiton.Controls.Add(this.pictureBox8);
            this.gbApplicaiton.Controls.Add(this.label17);
            this.gbApplicaiton.Controls.Add(this.lblApplicationFees);
            this.gbApplicaiton.Controls.Add(this.pictureBox7);
            this.gbApplicaiton.Controls.Add(this.label7);
            this.gbApplicaiton.Controls.Add(this.lblOldLicenseID);
            this.gbApplicaiton.Controls.Add(this.label4);
            this.gbApplicaiton.Controls.Add(this.lblApplicationDate);
            this.gbApplicaiton.Controls.Add(this.pictureBox3);
            this.gbApplicaiton.Controls.Add(this.label3);
            this.gbApplicaiton.Controls.Add(this.lblLRApplicationID);
            this.gbApplicaiton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicaiton.Location = new System.Drawing.Point(7, 600);
            this.gbApplicaiton.Name = "gbApplicaiton";
            this.gbApplicaiton.Size = new System.Drawing.Size(1209, 185);
            this.gbApplicaiton.TabIndex = 79;
            this.gbApplicaiton.TabStop = false;
            this.gbApplicaiton.Text = "Application New License Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontEnd.Properties.Resources.Calendar_32;
            this.pictureBox1.Location = new System.Drawing.Point(216, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::FrontEnd.Properties.Resources.User_32__2;
            this.pictureBox13.Location = new System.Drawing.Point(865, 133);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(32, 32);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox13.TabIndex = 66;
            this.pictureBox13.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(655, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 25);
            this.label13.TabIndex = 65;
            this.label13.Text = "Created By:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(923, 140);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(45, 25);
            this.lblCreatedBy.TabIndex = 64;
            this.lblCreatedBy.Text = "???";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::FrontEnd.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox10.Location = new System.Drawing.Point(865, 37);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 57;
            this.pictureBox10.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(560, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 25);
            this.label9.TabIndex = 56;
            this.label9.Text = "Replacement Licesnse ID:";
            // 
            // lblReplacementLicenseID
            // 
            this.lblReplacementLicenseID.AutoSize = true;
            this.lblReplacementLicenseID.Location = new System.Drawing.Point(923, 44);
            this.lblReplacementLicenseID.Name = "lblReplacementLicenseID";
            this.lblReplacementLicenseID.Size = new System.Drawing.Size(45, 25);
            this.lblReplacementLicenseID.TabIndex = 55;
            this.lblReplacementLicenseID.Text = "???";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::FrontEnd.Properties.Resources.money_32;
            this.pictureBox8.Location = new System.Drawing.Point(216, 133);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 51;
            this.pictureBox8.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(180, 25);
            this.label17.TabIndex = 50;
            this.label17.Text = "Application Fees:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(261, 140);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(45, 25);
            this.lblApplicationFees.TabIndex = 49;
            this.lblApplicationFees.Text = "???";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::FrontEnd.Properties.Resources.LocalDriving_License;
            this.pictureBox7.Location = new System.Drawing.Point(865, 90);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 45;
            this.pictureBox7.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(640, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 25);
            this.label7.TabIndex = 44;
            this.label7.Text = "Old License ID:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(923, 97);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(45, 25);
            this.lblOldLicenseID.TabIndex = 43;
            this.lblOldLicenseID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 25);
            this.label4.TabIndex = 38;
            this.label4.Text = "Application Date:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(261, 91);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(45, 25);
            this.lblApplicationDate.TabIndex = 37;
            this.lblApplicationDate.Text = "???";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FrontEnd.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(216, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "L.R.Application ID:";
            // 
            // lblLRApplicationID
            // 
            this.lblLRApplicationID.AutoSize = true;
            this.lblLRApplicationID.Location = new System.Drawing.Point(261, 44);
            this.lblLRApplicationID.Name = "lblLRApplicationID";
            this.lblLRApplicationID.Size = new System.Drawing.Size(45, 25);
            this.lblLRApplicationID.TabIndex = 25;
            this.lblLRApplicationID.Text = "???";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(757, 793);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLostLicense);
            this.groupBox2.Controls.Add(this.rbDamagedLicense);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1016, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(15, 59);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(132, 26);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Checked = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(15, 27);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(175, 26);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // frmReplaceDamagedOrLostDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 843);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linklblShowLicenseInfo);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.gbApplicaiton);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.findLocalLicenseController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReplaceDamagedOrLostDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Damaged Or Lost Driving License";
            this.Load += new System.EventHandler(this.frmReplaceDamagedOrLostDL_Load);
            this.gbApplicaiton.ResumeLayout(false);
            this.gbApplicaiton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.LicenseControllers.FindLocalLicenseController findLocalLicenseController1;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.LinkLabel linklblShowLicenseInfo;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.GroupBox gbApplicaiton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblReplacementLicenseID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLRApplicationID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
    }
}