using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using FrontEnd.Classes;

namespace FrontEnd.Forms.Renew_Driving_License_Forms
{
    public partial class frmRenewDrivingLicense : Form
    {
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }
        private int _OldLicenseID=0;
        private void _SetFormFullScreenVerticalOnly()
        {
            // this from chatgbt i don't know how it work
            this.Top = 0; // Move form to top of screen
            this.Height = Screen.PrimaryScreen.WorkingArea.Height; // Full vertical height

        }
        private void _LoadApplicationNewLicenseInfo()
        {
            lblApplicationDate.Text = clsUIHelper.GetCurrentDate();
            lblIssueDate.Text = clsUIHelper.GetCurrentDate();
            // 2 is the ApplicationTypeID for renew license app
            lblApplicationFees.Text= clsApplicationType.GetApplicationFee(2).ToString("F2");
            lblCreatedBy.Text=clsCurrentUser.UserName;
            if(_OldLicenseID>0)
            {
                lblOldLicenseID.Text = _OldLicenseID.ToString();
                clsLicense OldLicense= clsLicense.Find(_OldLicenseID);
                if(OldLicense!=null)
                {
                    lblLicenseFees.Text = clsLicenseClasses.GetLicenseClassFees
                        (OldLicense.LicenseClassID).ToString("F2");
                    lblExpirationDate.Text = OldLicense.ExpirationDate.ToString("dd/MM/yyyy");
                    decimal TotalFees=Convert.ToDecimal(lblApplicationFees.Text) +
                        Convert.ToDecimal(lblLicenseFees.Text);
                    lblTotalFees.Text = TotalFees.ToString("F2");
                }
            }
        }

        

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            _SetFormFullScreenVerticalOnly();
            _LoadApplicationNewLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findLocalLicenseController1_OnFindClick(int obj)
        {
            _OldLicenseID= obj;
            _LoadApplicationNewLicenseInfo();
            IsLicenseExpired();
        }

        private void IsLicenseExpired()
        {
            if(_OldLicenseID>0)
            {
                if(!clsLicense.IsLicenseExpired(_OldLicenseID))
                {
                    MessageBox.Show("Selected License is not expiared,it will expire on:" +
                        $" {clsLicense.Find(_OldLicenseID).ExpirationDate.ToString("dd/MM/yyyy")}",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRenew.Enabled = false;
                    return;
                }
                btnRenew.Enabled = true;

            }
        }
    }
}
