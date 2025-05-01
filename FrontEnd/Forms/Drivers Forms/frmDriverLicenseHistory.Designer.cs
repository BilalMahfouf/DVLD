namespace FrontEnd.Forms.Drivers_Forms
{
    partial class frmDriverLicenseHistory
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
            this.personInfoController1 = new FrontEnd.Controllers.PersonInfoController();
            this.driverLicensesHistoryController1 = new FrontEnd.Controllers.LicenseControllers.DriverLicensesHistoryController();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // personInfoController1
            // 
            this.personInfoController1.Location = new System.Drawing.Point(314, 37);
            this.personInfoController1.Name = "personInfoController1";
            this.personInfoController1.Size = new System.Drawing.Size(1169, 370);
            this.personInfoController1.TabIndex = 0;
            // 
            // driverLicensesHistoryController1
            // 
            this.driverLicensesHistoryController1.DriverID = 0;
            this.driverLicensesHistoryController1.Location = new System.Drawing.Point(-1, 413);
            this.driverLicensesHistoryController1.Name = "driverLicensesHistoryController1";
            this.driverLicensesHistoryController1.Size = new System.Drawing.Size(1492, 413);
            this.driverLicensesHistoryController1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontEnd.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(12, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose1
            // 
            this.btnClose1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose1.Location = new System.Drawing.Point(1348, 832);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(143, 44);
            this.btnClose1.TabIndex = 18;
            this.btnClose1.Text = "   Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // frmDriverLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 883);
            this.Controls.Add(this.btnClose1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.driverLicensesHistoryController1);
            this.Controls.Add(this.personInfoController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmDriverLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver License History";
            this.Load += new System.EventHandler(this.frmDriverLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.PersonInfoController personInfoController1;
        private Controllers.LicenseControllers.DriverLicensesHistoryController driverLicensesHistoryController1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose1;
    }
}