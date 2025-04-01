namespace FrontEnd.Forms
{
    partial class frmMain
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDrivingLicensesServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocalLincense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReplacementForLostorDamagedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReleaseDetainedDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocalDrivingLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInternationalLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageDetainedLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDetainLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageApplicationsTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 72);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDrivingLicensesServices,
            this.tsmManageApplications,
            this.tsmDetainLicenses,
            this.tsmManageApplicationsTypes,
            this.tsmManageTestTypes});
            this.applicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.Applications_64;
            this.applicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(217, 68);
            this.applicationToolStripMenuItem.Text = "Application";
            this.applicationToolStripMenuItem.Click += new System.EventHandler(this.applicationToolStripMenuItem_Click);
            // 
            // tsmDrivingLicensesServices
            // 
            this.tsmDrivingLicensesServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewDrivingLicense,
            this.tsmRenewDrivingLicense,
            this.toolStripSeparator1,
            this.tsmReplacementForLostorDamagedLicense,
            this.toolStripSeparator2,
            this.tsmReleaseDetainedDrivingLicense,
            this.tsmRetakeTest});
            this.tsmDrivingLicensesServices.Image = global::FrontEnd.Properties.Resources.Driver_License_48;
            this.tsmDrivingLicensesServices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDrivingLicensesServices.Name = "tsmDrivingLicensesServices";
            this.tsmDrivingLicensesServices.Size = new System.Drawing.Size(440, 70);
            this.tsmDrivingLicensesServices.Text = "Driving Licenses Services";
            // 
            // tsmNewDrivingLicense
            // 
            this.tsmNewDrivingLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLocalLincense,
            this.tsmInternationalLicense});
            this.tsmNewDrivingLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmNewDrivingLicense.Image = global::FrontEnd.Properties.Resources.New_Driving_License_32;
            this.tsmNewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmNewDrivingLicense.Name = "tsmNewDrivingLicense";
            this.tsmNewDrivingLicense.Size = new System.Drawing.Size(513, 38);
            this.tsmNewDrivingLicense.Text = "New Driving License";
            // 
            // tsmLocalLincense
            // 
            this.tsmLocalLincense.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmLocalLincense.Image = global::FrontEnd.Properties.Resources.Local_32;
            this.tsmLocalLincense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmLocalLincense.Name = "tsmLocalLincense";
            this.tsmLocalLincense.Size = new System.Drawing.Size(273, 38);
            this.tsmLocalLincense.Text = "Local Lincense";
            // 
            // tsmInternationalLicense
            // 
            this.tsmInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmInternationalLicense.Image = global::FrontEnd.Properties.Resources.International_32;
            this.tsmInternationalLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmInternationalLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmInternationalLicense.Name = "tsmInternationalLicense";
            this.tsmInternationalLicense.Size = new System.Drawing.Size(273, 38);
            this.tsmInternationalLicense.Text = "International License";
            // 
            // tsmRenewDrivingLicense
            // 
            this.tsmRenewDrivingLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmRenewDrivingLicense.Image = global::FrontEnd.Properties.Resources.Renew_Driving_License_32;
            this.tsmRenewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmRenewDrivingLicense.Name = "tsmRenewDrivingLicense";
            this.tsmRenewDrivingLicense.Size = new System.Drawing.Size(513, 38);
            this.tsmRenewDrivingLicense.Text = "Renew Driving License";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(510, 6);
            // 
            // tsmReplacementForLostorDamagedLicense
            // 
            this.tsmReplacementForLostorDamagedLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmReplacementForLostorDamagedLicense.Image = global::FrontEnd.Properties.Resources.Damaged_Driving_License_32;
            this.tsmReplacementForLostorDamagedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmReplacementForLostorDamagedLicense.Name = "tsmReplacementForLostorDamagedLicense";
            this.tsmReplacementForLostorDamagedLicense.Size = new System.Drawing.Size(513, 38);
            this.tsmReplacementForLostorDamagedLicense.Text = "Replacement For Lost or Damaged License";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(510, 6);
            // 
            // tsmReleaseDetainedDrivingLicense
            // 
            this.tsmReleaseDetainedDrivingLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmReleaseDetainedDrivingLicense.Image = global::FrontEnd.Properties.Resources.Detained_Driving_License_32;
            this.tsmReleaseDetainedDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmReleaseDetainedDrivingLicense.Name = "tsmReleaseDetainedDrivingLicense";
            this.tsmReleaseDetainedDrivingLicense.Size = new System.Drawing.Size(513, 38);
            this.tsmReleaseDetainedDrivingLicense.Text = "Release Detained Driving License";
            // 
            // tsmRetakeTest
            // 
            this.tsmRetakeTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmRetakeTest.Image = global::FrontEnd.Properties.Resources.Retake_Test_32;
            this.tsmRetakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmRetakeTest.Name = "tsmRetakeTest";
            this.tsmRetakeTest.Size = new System.Drawing.Size(513, 38);
            this.tsmRetakeTest.Text = "Retake Test";
            // 
            // tsmManageApplications
            // 
            this.tsmManageApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLocalDrivingLicenseApplication,
            this.tsmInternationalLicenseApplication});
            this.tsmManageApplications.Image = global::FrontEnd.Properties.Resources.Manage_Applications_64;
            this.tsmManageApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageApplications.Name = "tsmManageApplications";
            this.tsmManageApplications.Size = new System.Drawing.Size(440, 70);
            this.tsmManageApplications.Text = "Manage Applications";
            // 
            // tsmLocalDrivingLicenseApplication
            // 
            this.tsmLocalDrivingLicenseApplication.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmLocalDrivingLicenseApplication.Image = global::FrontEnd.Properties.Resources.LocalDriving_License;
            this.tsmLocalDrivingLicenseApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmLocalDrivingLicenseApplication.Name = "tsmLocalDrivingLicenseApplication";
            this.tsmLocalDrivingLicenseApplication.Size = new System.Drawing.Size(427, 38);
            this.tsmLocalDrivingLicenseApplication.Text = "Local Driving License Application";
            // 
            // tsmInternationalLicenseApplication
            // 
            this.tsmInternationalLicenseApplication.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmInternationalLicenseApplication.Image = global::FrontEnd.Properties.Resources.International_32;
            this.tsmInternationalLicenseApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmInternationalLicenseApplication.Name = "tsmInternationalLicenseApplication";
            this.tsmInternationalLicenseApplication.Size = new System.Drawing.Size(427, 38);
            this.tsmInternationalLicenseApplication.Text = "International License Application";
            // 
            // tsmDetainLicenses
            // 
            this.tsmDetainLicenses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmManageDetainedLicenses,
            this.tsmDetainLicense,
            this.tsmReleaseDetainedLicense});
            this.tsmDetainLicenses.Image = global::FrontEnd.Properties.Resources.Detain_64;
            this.tsmDetainLicenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDetainLicenses.Name = "tsmDetainLicenses";
            this.tsmDetainLicenses.Size = new System.Drawing.Size(440, 70);
            this.tsmDetainLicenses.Text = "Detain Licenses";
            // 
            // tsmManageDetainedLicenses
            // 
            this.tsmManageDetainedLicenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmManageDetainedLicenses.Image = global::FrontEnd.Properties.Resources.Detain_32;
            this.tsmManageDetainedLicenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageDetainedLicenses.Name = "tsmManageDetainedLicenses";
            this.tsmManageDetainedLicenses.Size = new System.Drawing.Size(365, 38);
            this.tsmManageDetainedLicenses.Text = "Manage Detained Licenses";
            // 
            // tsmDetainLicense
            // 
            this.tsmDetainLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDetainLicense.Image = global::FrontEnd.Properties.Resources.Detain_32;
            this.tsmDetainLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDetainLicense.Name = "tsmDetainLicense";
            this.tsmDetainLicense.Size = new System.Drawing.Size(365, 38);
            this.tsmDetainLicense.Text = "Detain License";
            // 
            // tsmReleaseDetainedLicense
            // 
            this.tsmReleaseDetainedLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmReleaseDetainedLicense.Image = global::FrontEnd.Properties.Resources.Release_Detained_License_32;
            this.tsmReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmReleaseDetainedLicense.Name = "tsmReleaseDetainedLicense";
            this.tsmReleaseDetainedLicense.RightToLeftAutoMirrorImage = true;
            this.tsmReleaseDetainedLicense.Size = new System.Drawing.Size(365, 38);
            this.tsmReleaseDetainedLicense.Text = "Release Detained License";
            // 
            // tsmManageApplicationsTypes
            // 
            this.tsmManageApplicationsTypes.Image = global::FrontEnd.Properties.Resources.Application_Types_64;
            this.tsmManageApplicationsTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageApplicationsTypes.Name = "tsmManageApplicationsTypes";
            this.tsmManageApplicationsTypes.Size = new System.Drawing.Size(440, 70);
            this.tsmManageApplicationsTypes.Text = "Manage Applications Types";
            // 
            // tsmManageTestTypes
            // 
            this.tsmManageTestTypes.Image = global::FrontEnd.Properties.Resources.Test_Type_64;
            this.tsmManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageTestTypes.Name = "tsmManageTestTypes";
            this.tsmManageTestTypes.Size = new System.Drawing.Size(440, 70);
            this.tsmManageTestTypes.Text = "Manage Test Types";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(164, 68);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.Drivers_64;
            this.driversToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(168, 68);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.Users_2_64;
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(150, 68);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCurrentUserInfo,
            this.tsmChangePassword,
            this.tsmSignOut});
            this.accountSettingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSettingToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.account_settings_64;
            this.accountSettingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(265, 68);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            // 
            // tsmCurrentUserInfo
            // 
            this.tsmCurrentUserInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmCurrentUserInfo.Image = global::FrontEnd.Properties.Resources.User_32__2;
            this.tsmCurrentUserInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCurrentUserInfo.Name = "tsmCurrentUserInfo";
            this.tsmCurrentUserInfo.Size = new System.Drawing.Size(277, 38);
            this.tsmCurrentUserInfo.Text = "Current User Info";
            // 
            // tsmChangePassword
            // 
            this.tsmChangePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmChangePassword.Image = global::FrontEnd.Properties.Resources.Password_32;
            this.tsmChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmChangePassword.Name = "tsmChangePassword";
            this.tsmChangePassword.Size = new System.Drawing.Size(277, 38);
            this.tsmChangePassword.Text = "Change Password";
            // 
            // tsmSignOut
            // 
            this.tsmSignOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmSignOut.Image = global::FrontEnd.Properties.Resources.sign_out_32__2;
            this.tsmSignOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmSignOut.Name = "tsmSignOut";
            this.tsmSignOut.Size = new System.Drawing.Size(277, 38);
            this.tsmSignOut.Text = "Sign Out ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 825);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDrivingLicensesServices;
        private System.Windows.Forms.ToolStripMenuItem tsmManageApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmDetainLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmManageApplicationsTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmNewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmRenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmReplacementForLostorDamagedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmReleaseDetainedDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmRetakeTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmLocalLincense;
        private System.Windows.Forms.ToolStripMenuItem tsmInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmInternationalLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmManageDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmDetainLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmCurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmSignOut;
    }
}