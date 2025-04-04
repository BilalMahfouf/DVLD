namespace FrontEnd.Forms
{
    partial class frmAddOrEditPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.addOrEditPersonControllers1 = new FrontEnd.Controllers.AddOrEditPersonControllers();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "PersonID:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FrontEnd.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(166, 80);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(223, 80);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(64, 32);
            this.lblPersonID.TabIndex = 40;
            this.lblPersonID.Text = "N/A";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.SystemColors.Control;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMode.Location = new System.Drawing.Point(526, 14);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(387, 54);
            this.lblMode.TabIndex = 41;
            this.lblMode.Text = "Add New Person";
            // 
            // addOrEditPersonControllers1
            // 
            this.addOrEditPersonControllers1.Location = new System.Drawing.Point(0, 113);
            this.addOrEditPersonControllers1.Name = "addOrEditPersonControllers1";
            this.addOrEditPersonControllers1.Size = new System.Drawing.Size(1169, 435);
            this.addOrEditPersonControllers1.TabIndex = 0;
            this.addOrEditPersonControllers1.OnCloseRequested += new System.Action(this.addOrEditPersonControllers1_OnCloseRequested);
            this.addOrEditPersonControllers1.OnSaveRequested += new System.Action<int>(this.addOrEditPersonControllers1_OnSaveRequested);
            this.addOrEditPersonControllers1.Load += new System.EventHandler(this.addOrEditPersonControllers1_Load);
            // 
            // frmAddOrEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 573);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addOrEditPersonControllers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddOrEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add\\Edit Person";
            this.Load += new System.EventHandler(this.frmAddOrEditPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.AddOrEditPersonControllers addOrEditPersonControllers1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblMode;
    }
}