namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    partial class frmManageLocalDrivingLicenseApplications
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
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSechduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mtbSearch = new System.Windows.Forms.MaskedTextBox();
            this.cbfilterBy = new System.Windows.Forms.ComboBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.lblRecords1 = new System.Windows.Forms.Label();
            this.pbAddNewLocalDrivingApplication = new System.Windows.Forms.PictureBox();
            this.btnClose1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewLocalDrivingApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.BackColor = System.Drawing.SystemColors.Control;
            this.lblManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagePeople.ForeColor = System.Drawing.Color.Red;
            this.lblManagePeople.Location = new System.Drawing.Point(412, 243);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(754, 54);
            this.lblManagePeople.TabIndex = 6;
            this.lblManagePeople.Text = "Local Drivng License Applications";
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplications.Location = new System.Drawing.Point(12, 357);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersWidth = 51;
            this.dgvApplications.RowTemplate.Height = 24;
            this.dgvApplications.Size = new System.Drawing.Size(1481, 430);
            this.dgvApplications.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowApplicationDetails,
            this.toolStripSeparator1,
            this.tsmEdit,
            this.tsmDelete,
            this.tsmCancel,
            this.toolStripSeparator2,
            this.tsmSechduleTests,
            this.toolStripSeparator3,
            this.tsmIssueDrivingLicenseFirstTime,
            this.toolStripSeparator4,
            this.tsmShowDrivingLicense,
            this.toolStripSeparator5,
            this.tsmShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(309, 366);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmShowApplicationDetails
            // 
            this.tsmShowApplicationDetails.Image = global::FrontEnd.Properties.Resources.PersonDetails_32;
            this.tsmShowApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowApplicationDetails.Name = "tsmShowApplicationDetails";
            this.tsmShowApplicationDetails.Size = new System.Drawing.Size(308, 38);
            this.tsmShowApplicationDetails.Text = "Show Application Details";
            this.tsmShowApplicationDetails.Click += new System.EventHandler(this.tsmShowApplicationDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Image = global::FrontEnd.Properties.Resources.edit_32;
            this.tsmEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(308, 38);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::FrontEnd.Properties.Resources.Delete_32_2;
            this.tsmDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(308, 38);
            this.tsmDelete.Text = "Delete";
            // 
            // tsmCancel
            // 
            this.tsmCancel.Image = global::FrontEnd.Properties.Resources.Delete_32;
            this.tsmCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCancel.Name = "tsmCancel";
            this.tsmCancel.Size = new System.Drawing.Size(308, 38);
            this.tsmCancel.Text = "Cancel";
            this.tsmCancel.Click += new System.EventHandler(this.tsmCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmSechduleTests
            // 
            this.tsmSechduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmScheduleVisionTest,
            this.tsmScheduleWrittenTest,
            this.tsmScheduleStreetTest});
            this.tsmSechduleTests.Enabled = false;
            this.tsmSechduleTests.Image = global::FrontEnd.Properties.Resources.Schedule_Test_32;
            this.tsmSechduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmSechduleTests.Name = "tsmSechduleTests";
            this.tsmSechduleTests.Size = new System.Drawing.Size(308, 38);
            this.tsmSechduleTests.Text = "Sechdule Tests";
            // 
            // tsmScheduleVisionTest
            // 
            this.tsmScheduleVisionTest.Image = global::FrontEnd.Properties.Resources.Vision_Test_32;
            this.tsmScheduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleVisionTest.Name = "tsmScheduleVisionTest";
            this.tsmScheduleVisionTest.Size = new System.Drawing.Size(247, 38);
            this.tsmScheduleVisionTest.Text = "Schedule Vision Test";
            this.tsmScheduleVisionTest.Click += new System.EventHandler(this.tsmScheduleVisionTest_Click);
            // 
            // tsmScheduleWrittenTest
            // 
            this.tsmScheduleWrittenTest.Image = global::FrontEnd.Properties.Resources.Written_Test_32;
            this.tsmScheduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleWrittenTest.Name = "tsmScheduleWrittenTest";
            this.tsmScheduleWrittenTest.Size = new System.Drawing.Size(247, 38);
            this.tsmScheduleWrittenTest.Text = "Schedule Written Test";
            this.tsmScheduleWrittenTest.Click += new System.EventHandler(this.tsmScheduleWrittenTest_Click);
            // 
            // tsmScheduleStreetTest
            // 
            this.tsmScheduleStreetTest.Image = global::FrontEnd.Properties.Resources.Street_Test_32;
            this.tsmScheduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleStreetTest.Name = "tsmScheduleStreetTest";
            this.tsmScheduleStreetTest.Size = new System.Drawing.Size(247, 38);
            this.tsmScheduleStreetTest.Text = "Schedule Street Test";
            this.tsmScheduleStreetTest.Click += new System.EventHandler(this.tsmScheduleStreetTest_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmIssueDrivingLicenseFirstTime
            // 
            this.tsmIssueDrivingLicenseFirstTime.Image = global::FrontEnd.Properties.Resources.IssueDrivingLicense_32;
            this.tsmIssueDrivingLicenseFirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmIssueDrivingLicenseFirstTime.Name = "tsmIssueDrivingLicenseFirstTime";
            this.tsmIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(308, 38);
            this.tsmIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.tsmIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.tsmIssueDrivingLicenseFirstTime_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmShowDrivingLicense
            // 
            this.tsmShowDrivingLicense.Image = global::FrontEnd.Properties.Resources.License_View_32;
            this.tsmShowDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowDrivingLicense.Name = "tsmShowDrivingLicense";
            this.tsmShowDrivingLicense.Size = new System.Drawing.Size(308, 38);
            this.tsmShowDrivingLicense.Text = "Show Driving License";
            this.tsmShowDrivingLicense.Click += new System.EventHandler(this.tsmShowDrivingLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.Image = global::FrontEnd.Properties.Resources.PersonLicenseHistory_32;
            this.tsmShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(308, 38);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // mtbSearch
            // 
            this.mtbSearch.BeepOnError = true;
            this.mtbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbSearch.Location = new System.Drawing.Point(364, 313);
            this.mtbSearch.Name = "mtbSearch";
            this.mtbSearch.Size = new System.Drawing.Size(185, 38);
            this.mtbSearch.TabIndex = 14;
            this.mtbSearch.ValidatingType = typeof(System.DateTime);
            this.mtbSearch.Visible = false;
            this.mtbSearch.TextChanged += new System.EventHandler(this.mtbSearch_TextChanged);
            // 
            // cbfilterBy
            // 
            this.cbfilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbfilterBy.FormattingEnabled = true;
            this.cbfilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "NationalNo",
            "FullName",
            "Status"});
            this.cbfilterBy.Location = new System.Drawing.Point(148, 316);
            this.cbfilterBy.Name = "cbfilterBy";
            this.cbfilterBy.Size = new System.Drawing.Size(199, 37);
            this.cbfilterBy.TabIndex = 13;
            this.cbfilterBy.SelectedIndexChanged += new System.EventHandler(this.cbfilterBy_SelectedIndexChanged);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(6, 313);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(136, 32);
            this.lblFilterBy.TabIndex = 12;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // lblRecords1
            // 
            this.lblRecords1.AutoSize = true;
            this.lblRecords1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords1.Location = new System.Drawing.Point(10, 799);
            this.lblRecords1.Name = "lblRecords1";
            this.lblRecords1.Size = new System.Drawing.Size(132, 29);
            this.lblRecords1.TabIndex = 15;
            this.lblRecords1.Text = "#Records:";
            // 
            // pbAddNewLocalDrivingApplication
            // 
            this.pbAddNewLocalDrivingApplication.BackColor = System.Drawing.Color.White;
            this.pbAddNewLocalDrivingApplication.Image = global::FrontEnd.Properties.Resources.New_Application_64;
            this.pbAddNewLocalDrivingApplication.Location = new System.Drawing.Point(1400, 268);
            this.pbAddNewLocalDrivingApplication.Name = "pbAddNewLocalDrivingApplication";
            this.pbAddNewLocalDrivingApplication.Size = new System.Drawing.Size(93, 85);
            this.pbAddNewLocalDrivingApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAddNewLocalDrivingApplication.TabIndex = 17;
            this.pbAddNewLocalDrivingApplication.TabStop = false;
            this.pbAddNewLocalDrivingApplication.Click += new System.EventHandler(this.pbAddNewLocalDrivingApplication_Click);
            // 
            // btnClose1
            // 
            this.btnClose1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose1.Location = new System.Drawing.Point(1350, 799);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(143, 44);
            this.btnClose1.TabIndex = 16;
            this.btnClose1.Text = "   Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FrontEnd.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(880, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontEnd.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(641, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 854);
            this.Controls.Add(this.pbAddNewLocalDrivingApplication);
            this.Controls.Add(this.btnClose1);
            this.Controls.Add(this.lblRecords1);
            this.Controls.Add(this.mtbSearch);
            this.Controls.Add(this.cbfilterBy);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.dgvApplications);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblManagePeople);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManageLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewLocalDrivingApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.MaskedTextBox mtbSearch;
        private System.Windows.Forms.ComboBox cbfilterBy;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Label lblRecords1;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.PictureBox pbAddNewLocalDrivingApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleStreetTest;
    }
}