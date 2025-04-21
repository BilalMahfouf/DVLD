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
            this.applicationBasicInfoController1 = new FrontEnd.Controllers.Application_Controllers.ApplicationBasicInfoController();
            this.SuspendLayout();
            // 
            // applicationBasicInfoController1
            // 
            this.applicationBasicInfoController1.ApplicationID = 0;
            this.applicationBasicInfoController1.Location = new System.Drawing.Point(12, 72);
            this.applicationBasicInfoController1.Name = "applicationBasicInfoController1";
            this.applicationBasicInfoController1.Size = new System.Drawing.Size(1405, 330);
            this.applicationBasicInfoController1.TabIndex = 0;
            // 
            // frmTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 626);
            this.Controls.Add(this.applicationBasicInfoController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestAppointment";
            this.Load += new System.EventHandler(this.frmTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.Application_Controllers.ApplicationBasicInfoController applicationBasicInfoController1;
    }
}