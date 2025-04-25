namespace FrontEnd.Forms.Tests_forms
{
    partial class frmAddNewTestAppointment
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
            this.scheduleTestController1 = new FrontEnd.Controllers.TestControllers.ScheduleTestController();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(198, 736);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // scheduleTestController1
            // 
            this.scheduleTestController1.LDLAppID = 0;
            this.scheduleTestController1.Location = new System.Drawing.Point(12, 12);
            this.scheduleTestController1.Name = "scheduleTestController1";
            this.scheduleTestController1.Size = new System.Drawing.Size(621, 718);
            this.scheduleTestController1.TabIndex = 0;
            this.scheduleTestController1.TestAppointmentID = 0;
            this.scheduleTestController1.TestTypeID = 0;
            this.scheduleTestController1.OnSaveRequested += new System.Action(this.scheduleTestController1_OnSaveRequested);
            this.scheduleTestController1.Load += new System.EventHandler(this.scheduleTestController1_Load);
            // 
            // frmAddNewTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 785);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.scheduleTestController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddNewTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Test Appointment";
            this.Load += new System.EventHandler(this.frmAddNewTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.TestControllers.ScheduleTestController scheduleTestController1;
        private System.Windows.Forms.Button btnClose;
    }
}