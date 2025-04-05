namespace FrontEnd.Forms.User_Forms
{
    partial class frmUserInformation
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
            this.loginInformationController1 = new FrontEnd.Controllers.LoginInformationController();
            this.personInfoController1 = new FrontEnd.Controllers.PersonInfoController();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::FrontEnd.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1036, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 44);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // loginInformationController1
            // 
            this.loginInformationController1.Location = new System.Drawing.Point(12, 381);
            this.loginInformationController1.Name = "loginInformationController1";
            this.loginInformationController1.Size = new System.Drawing.Size(1167, 94);
            this.loginInformationController1.TabIndex = 1;
            this.loginInformationController1.UserID = 0;
            // 
            // personInfoController1
            // 
            this.personInfoController1.Location = new System.Drawing.Point(12, 8);
            this.personInfoController1.Name = "personInfoController1";
            this.personInfoController1.Size = new System.Drawing.Size(1378, 370);
            this.personInfoController1.TabIndex = 0;
            // 
            // frmUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 529);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.loginInformationController1);
            this.Controls.Add(this.personInfoController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUserInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUserInformation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.PersonInfoController personInfoController1;
        private Controllers.LoginInformationController loginInformationController1;
        private System.Windows.Forms.Button btnClose;
    }
}