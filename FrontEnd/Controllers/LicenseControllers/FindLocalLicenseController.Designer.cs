namespace FrontEnd.Controllers.LicenseControllers
{
    partial class FindLocalLicenseController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mtbLicenseID = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.licenseInfoController1 = new FrontEnd.Controllers.LicenseControllers.LicenseInfoController();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.mtbLicenseID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::FrontEnd.Properties.Resources.License_View_32;
            this.btnSearch.Location = new System.Drawing.Point(632, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 55);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // mtbLicenseID
            // 
            this.mtbLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbLicenseID.Location = new System.Drawing.Point(184, 40);
            this.mtbLicenseID.Mask = "00000000000000000000000000000000000000000000000";
            this.mtbLicenseID.Name = "mtbLicenseID";
            this.mtbLicenseID.Size = new System.Drawing.Size(420, 27);
            this.mtbLicenseID.TabIndex = 2;
            this.mtbLicenseID.TextChanged += new System.EventHandler(this.mtbLicenseID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // licenseInfoController1
            // 
            this.licenseInfoController1.LicenseID = 0;
            this.licenseInfoController1.Location = new System.Drawing.Point(0, 121);
            this.licenseInfoController1.Name = "licenseInfoController1";
            this.licenseInfoController1.Size = new System.Drawing.Size(1238, 404);
            this.licenseInfoController1.TabIndex = 2;
            // 
            // FindLocalLicenseController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.licenseInfoController1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FindLocalLicenseController";
            this.Size = new System.Drawing.Size(1239, 520);
            this.Load += new System.EventHandler(this.FindLocalLicenseController_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox mtbLicenseID;
        private System.Windows.Forms.Label label1;
        private LicenseInfoController licenseInfoController1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
