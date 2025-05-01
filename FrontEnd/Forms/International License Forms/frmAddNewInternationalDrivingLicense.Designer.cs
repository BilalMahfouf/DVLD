namespace FrontEnd.Forms.International_License_Forms
{
    partial class frmAddNewInternationalDrivingLicense
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
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.applicationInfo_NewInternationalDLApplicationController1 = new FrontEnd.Controllers.Application_Controllers.ApplicationInfo_NewInternationalDLApplicationController();
            this.findLocalLicenseController1 = new FrontEnd.Controllers.LicenseControllers.FindLocalLicenseController();
            this.linklblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.Enabled = false;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::FrontEnd.Properties.Resources.International_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(1085, 897);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(143, 44);
            this.btnIssue.TabIndex = 71;
            this.btnIssue.Text = "   Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(936, 897);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.BackColor = System.Drawing.SystemColors.Control;
            this.lblManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagePeople.ForeColor = System.Drawing.Color.Red;
            this.lblManagePeople.Location = new System.Drawing.Point(157, 9);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(727, 54);
            this.lblManagePeople.TabIndex = 72;
            this.lblManagePeople.Text = "International License Application";
            // 
            // applicationInfo_NewInternationalDLApplicationController1
            // 
            this.applicationInfo_NewInternationalDLApplicationController1.LicenseID = 0;
            this.applicationInfo_NewInternationalDLApplicationController1.Location = new System.Drawing.Point(3, 640);
            this.applicationInfo_NewInternationalDLApplicationController1.Name = "applicationInfo_NewInternationalDLApplicationController1";
            this.applicationInfo_NewInternationalDLApplicationController1.Size = new System.Drawing.Size(1238, 262);
            this.applicationInfo_NewInternationalDLApplicationController1.TabIndex = 1;
            // 
            // findLocalLicenseController1
            // 
            this.findLocalLicenseController1.Location = new System.Drawing.Point(2, 58);
            this.findLocalLicenseController1.Name = "findLocalLicenseController1";
            this.findLocalLicenseController1.Size = new System.Drawing.Size(1239, 584);
            this.findLocalLicenseController1.TabIndex = 0;
            this.findLocalLicenseController1.OnFindClick += new System.Action<int>(this.findLocalLicenseController1_OnFindClick);
            // 
            // linklblShowLicenseInfo
            // 
            this.linklblShowLicenseInfo.AutoSize = true;
            this.linklblShowLicenseInfo.Enabled = false;
            this.linklblShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowLicenseInfo.Location = new System.Drawing.Point(12, 911);
            this.linklblShowLicenseInfo.Name = "linklblShowLicenseInfo";
            this.linklblShowLicenseInfo.Size = new System.Drawing.Size(172, 25);
            this.linklblShowLicenseInfo.TabIndex = 75;
            this.linklblShowLicenseInfo.TabStop = true;
            this.linklblShowLicenseInfo.Text = "Show License Info";
            this.linklblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseInfo_LinkClicked);
            // 
            // frmAddNewInternationalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 945);
            this.Controls.Add(this.linklblShowLicenseInfo);
            this.Controls.Add(this.lblManagePeople);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.applicationInfo_NewInternationalDLApplicationController1);
            this.Controls.Add(this.findLocalLicenseController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddNewInternationalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewInternationalDrivingLicense";
            this.Load += new System.EventHandler(this.frmAddNewInternationalDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.LicenseControllers.FindLocalLicenseController findLocalLicenseController1;
        private Controllers.Application_Controllers.ApplicationInfo_NewInternationalDLApplicationController applicationInfo_NewInternationalDLApplicationController1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.LinkLabel linklblShowLicenseInfo;
    }
}