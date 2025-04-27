namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    partial class frmIssueDriverLicenseForFirstTime
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
            this.drivingLicenseApplicationInfoCnotroller1 = new FrontEnd.Controllers.Application_Controllers.DrivingLicenseApplicationInfoCnotroller();
            this.applicationBasicInfoController1 = new FrontEnd.Controllers.Application_Controllers.ApplicationBasicInfoController();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // drivingLicenseApplicationInfoCnotroller1
            // 
            this.drivingLicenseApplicationInfoCnotroller1.LDLAppID = 0;
            this.drivingLicenseApplicationInfoCnotroller1.Location = new System.Drawing.Point(7, 0);
            this.drivingLicenseApplicationInfoCnotroller1.Name = "drivingLicenseApplicationInfoCnotroller1";
            this.drivingLicenseApplicationInfoCnotroller1.Size = new System.Drawing.Size(1332, 176);
            this.drivingLicenseApplicationInfoCnotroller1.TabIndex = 0;
            // 
            // applicationBasicInfoController1
            // 
            this.applicationBasicInfoController1.ApplicationID = 0;
            this.applicationBasicInfoController1.Location = new System.Drawing.Point(-6, 172);
            this.applicationBasicInfoController1.Name = "applicationBasicInfoController1";
            this.applicationBasicInfoController1.Size = new System.Drawing.Size(1332, 330);
            this.applicationBasicInfoController1.TabIndex = 1;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(137, 508);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(1172, 138);
            this.rtbNotes.TabIndex = 17;
            this.rtbNotes.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FrontEnd.Properties.Resources.Notes_32;
            this.pictureBox2.Location = new System.Drawing.Point(84, 508);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 15;
            this.label2.Text = "Notes:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1017, 652);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::FrontEnd.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(1166, 652);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(143, 44);
            this.btnIssue.TabIndex = 71;
            this.btnIssue.Text = "   Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // frmIssueDriverLicenseForFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 701);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.applicationBasicInfoController1);
            this.Controls.Add(this.drivingLicenseApplicationInfoCnotroller1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmIssueDriverLicenseForFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driver License For First Time";
            this.Load += new System.EventHandler(this.frmIssueDriverLicenseForFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.Application_Controllers.DrivingLicenseApplicationInfoCnotroller drivingLicenseApplicationInfoCnotroller1;
        private Controllers.Application_Controllers.ApplicationBasicInfoController applicationBasicInfoController1;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
    }
}