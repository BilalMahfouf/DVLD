namespace FrontEnd.Forms.Tests_forms
{
    partial class frmTestAppointment
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
            this.lblTestApppointment = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.drivingLicenseApplicationInfoCnotroller1 = new FrontEnd.Controllers.Application_Controllers.DrivingLicenseApplicationInfoCnotroller();
            this.applicationBasicInfoController1 = new FrontEnd.Controllers.Application_Controllers.ApplicationBasicInfoController();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestApppointment
            // 
            this.lblTestApppointment.AutoSize = true;
            this.lblTestApppointment.BackColor = System.Drawing.SystemColors.Control;
            this.lblTestApppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestApppointment.ForeColor = System.Drawing.Color.Red;
            this.lblTestApppointment.Location = new System.Drawing.Point(416, 9);
            this.lblTestApppointment.Name = "lblTestApppointment";
            this.lblTestApppointment.Size = new System.Drawing.Size(104, 54);
            this.lblTestApppointment.TabIndex = 7;
            this.lblTestApppointment.Text = "???";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(12, 800);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(132, 29);
            this.lblRecords.TabIndex = 16;
            this.lblRecords.Text = "#Records:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1189, 799);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 586);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1315, 210);
            this.dataGridView1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Appointments:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::FrontEnd.Properties.Resources.AddAppointment_32;
            this.button1.Location = new System.Drawing.Point(1272, 524);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 59);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // drivingLicenseApplicationInfoCnotroller1
            // 
            this.drivingLicenseApplicationInfoCnotroller1.LDLAppID = 0;
            this.drivingLicenseApplicationInfoCnotroller1.Location = new System.Drawing.Point(17, 55);
            this.drivingLicenseApplicationInfoCnotroller1.Name = "drivingLicenseApplicationInfoCnotroller1";
            this.drivingLicenseApplicationInfoCnotroller1.Size = new System.Drawing.Size(1332, 169);
            this.drivingLicenseApplicationInfoCnotroller1.TabIndex = 1;
            // 
            // applicationBasicInfoController1
            // 
            this.applicationBasicInfoController1.ApplicationID = 0;
            this.applicationBasicInfoController1.Location = new System.Drawing.Point(1, 211);
            this.applicationBasicInfoController1.Name = "applicationBasicInfoController1";
            this.applicationBasicInfoController1.Size = new System.Drawing.Size(1331, 320);
            this.applicationBasicInfoController1.TabIndex = 0;
            // 
            // frmTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 874);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblTestApppointment);
            this.Controls.Add(this.drivingLicenseApplicationInfoCnotroller1);
            this.Controls.Add(this.applicationBasicInfoController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestAppointment";
            this.Load += new System.EventHandler(this.frmTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.Application_Controllers.ApplicationBasicInfoController applicationBasicInfoController1;
        private Controllers.Application_Controllers.DrivingLicenseApplicationInfoCnotroller drivingLicenseApplicationInfoCnotroller1;
        private System.Windows.Forms.Label lblTestApppointment;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}