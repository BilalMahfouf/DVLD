namespace FrontEnd.Forms.International_License_Forms
{
    partial class frmManageInternationalLicenseApplication
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
            this.btnClose1 = new System.Windows.Forms.Button();
            this.lblRecords1 = new System.Windows.Forms.Label();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.pbAddNewInternationalDrivingApplication = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewInternationalDrivingApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose1
            // 
            this.btnClose1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose1.Location = new System.Drawing.Point(1350, 800);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(143, 44);
            this.btnClose1.TabIndex = 19;
            this.btnClose1.Text = "   Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // lblRecords1
            // 
            this.lblRecords1.AutoSize = true;
            this.lblRecords1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords1.Location = new System.Drawing.Point(10, 800);
            this.lblRecords1.Name = "lblRecords1";
            this.lblRecords1.Size = new System.Drawing.Size(132, 29);
            this.lblRecords1.TabIndex = 18;
            this.lblRecords1.Text = "#Records:";
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplications.Location = new System.Drawing.Point(12, 358);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersWidth = 51;
            this.dgvApplications.RowTemplate.Height = 24;
            this.dgvApplications.Size = new System.Drawing.Size(1481, 430);
            this.dgvApplications.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowPersonDetails,
            this.tsmShowLicenseDetails,
            this.tsmShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(323, 118);
            // 
            // tsmShowPersonDetails
            // 
            this.tsmShowPersonDetails.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonDetails.Image = global::FrontEnd.Properties.Resources.PersonDetails_32;
            this.tsmShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonDetails.Name = "tsmShowPersonDetails";
            this.tsmShowPersonDetails.Size = new System.Drawing.Size(322, 38);
            this.tsmShowPersonDetails.Text = "Show Person Details";
            this.tsmShowPersonDetails.Click += new System.EventHandler(this.tsmShowPersonDetails_Click);
            // 
            // tsmShowLicenseDetails
            // 
            this.tsmShowLicenseDetails.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowLicenseDetails.Image = global::FrontEnd.Properties.Resources.License_View_32;
            this.tsmShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowLicenseDetails.Name = "tsmShowLicenseDetails";
            this.tsmShowLicenseDetails.Size = new System.Drawing.Size(322, 38);
            this.tsmShowLicenseDetails.Text = "Show License Details";
            this.tsmShowLicenseDetails.Click += new System.EventHandler(this.tsnShowLicenseDetails_Click);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonLicenseHistory.Image = global::FrontEnd.Properties.Resources.PersonLicenseHistory_32;
            this.tsmShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(322, 38);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // pbAddNewInternationalDrivingApplication
            // 
            this.pbAddNewInternationalDrivingApplication.BackColor = System.Drawing.Color.White;
            this.pbAddNewInternationalDrivingApplication.Image = global::FrontEnd.Properties.Resources.New_Application_64;
            this.pbAddNewInternationalDrivingApplication.Location = new System.Drawing.Point(1398, 268);
            this.pbAddNewInternationalDrivingApplication.Name = "pbAddNewInternationalDrivingApplication";
            this.pbAddNewInternationalDrivingApplication.Size = new System.Drawing.Size(93, 85);
            this.pbAddNewInternationalDrivingApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAddNewInternationalDrivingApplication.TabIndex = 25;
            this.pbAddNewInternationalDrivingApplication.TabStop = false;
            this.pbAddNewInternationalDrivingApplication.Click += new System.EventHandler(this.pbAddNewInternationalDrivingApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontEnd.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(648, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.BackColor = System.Drawing.SystemColors.Control;
            this.lblManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagePeople.ForeColor = System.Drawing.Color.Red;
            this.lblManagePeople.Location = new System.Drawing.Point(419, 243);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(752, 54);
            this.lblManagePeople.TabIndex = 20;
            this.lblManagePeople.Text = "International License Applications";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FrontEnd.Properties.Resources.International_32;
            this.pictureBox2.Location = new System.Drawing.Point(902, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // frmManageInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 854);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbAddNewInternationalDrivingApplication);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblManagePeople);
            this.Controls.Add(this.btnClose1);
            this.Controls.Add(this.lblRecords1);
            this.Controls.Add(this.dgvApplications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManageInternationalLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewInternationalDrivingApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.Label lblRecords1;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.PictureBox pbAddNewInternationalDrivingApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
    }
}