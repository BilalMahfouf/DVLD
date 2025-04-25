namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    partial class frmShowApplicationDetails
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
            this.btnClose = new System.Windows.Forms.Button();
            this.applicationBasicInfoController1 = new FrontEnd.Controllers.Application_Controllers.ApplicationBasicInfoController();
            this.drivingLicenseApplicationInfoCnotroller1 = new FrontEnd.Controllers.Application_Controllers.DrivingLicenseApplicationInfoCnotroller();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1179, 510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // applicationBasicInfoController1
            // 
            this.applicationBasicInfoController1.ApplicationID = 0;
            this.applicationBasicInfoController1.Location = new System.Drawing.Point(0, 183);
            this.applicationBasicInfoController1.Name = "applicationBasicInfoController1";
            this.applicationBasicInfoController1.Size = new System.Drawing.Size(1332, 330);
            this.applicationBasicInfoController1.TabIndex = 1;
            // 
            // drivingLicenseApplicationInfoCnotroller1
            // 
            this.drivingLicenseApplicationInfoCnotroller1.LDLAppID = 0;
            this.drivingLicenseApplicationInfoCnotroller1.Location = new System.Drawing.Point(12, 1);
            this.drivingLicenseApplicationInfoCnotroller1.Name = "drivingLicenseApplicationInfoCnotroller1";
            this.drivingLicenseApplicationInfoCnotroller1.Size = new System.Drawing.Size(1332, 176);
            this.drivingLicenseApplicationInfoCnotroller1.TabIndex = 0;
            // 
            // frmShowApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 562);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.applicationBasicInfoController1);
            this.Controls.Add(this.drivingLicenseApplicationInfoCnotroller1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowApplicationDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Application Info";
            this.Load += new System.EventHandler(this.frmShowApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.Application_Controllers.DrivingLicenseApplicationInfoCnotroller drivingLicenseApplicationInfoCnotroller1;
        private Controllers.Application_Controllers.ApplicationBasicInfoController applicationBasicInfoController1;
        private System.Windows.Forms.Button btnClose;
    }
}