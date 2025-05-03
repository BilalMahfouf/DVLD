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
using FrontEnd.Forms.Driving_Licenses_Services_Forms.TestTypes_Forms;

namespace FrontEnd.Forms.Renew_Driving_License_Forms
{
    public partial class frmRenewDrivingLicense : Form
    {
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }
        private int _OldLicenseID = 0;
        private int _NewLicenseID = 0;

        private void _LoadApplicationNewLicenseInfo()
        {
            lblApplicationDate.Text = clsUIHelper.GetCurrentDate();
            lblIssueDate.Text = clsUIHelper.GetCurrentDate();
            // 2 is the ApplicationTypeID for renew license app
            lblApplicationFees.Text = clsApplicationType.GetApplicationFee(2).ToString("F2");
            lblCreatedBy.Text = clsCurrentUser.UserName;
            if (_OldLicenseID > 0)
            {
                lblOldLicenseID.Text = _OldLicenseID.ToString();
                clsLicense OldLicense = clsLicense.Find(_OldLicenseID);
                if (OldLicense != null)
                {
                    lblLicenseFees.Text = clsLicenseClasses.GetLicenseClassFees
                        (OldLicense.LicenseClassID).ToString("F2");
                    int ValidityYears = clsLicenseClasses.Find(OldLicense.LicenseClassID)
                        .DefaultValidityLength;
                    lblExpirationDate.Text = DateTime.Now.AddYears(ValidityYears).ToString("dd/MM/yyyy");
                    decimal TotalFees = Convert.ToDecimal(lblApplicationFees.Text) +
                        Convert.ToDecimal(lblLicenseFees.Text);
                    lblTotalFees.Text = TotalFees.ToString("F2");
                }
            }
            
        }



        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            clsUIHelper.SetFormFullScreenVerticalOnly(this);
            _LoadApplicationNewLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findLocalLicenseController1_OnFindClick(int obj)
        {
            _OldLicenseID = obj;
            _LoadApplicationNewLicenseInfo();
            IsLicenseExpired();
            _ShowErrorForInActiveLicense();
        }

        private void IsLicenseExpired()
        {
            if (_OldLicenseID > 0)
            {
                if (!clsLicense.IsLicenseExpired(_OldLicenseID))
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

        private void _ShowErrorForInActiveLicense()
        {
            if (_OldLicenseID > 0)
            {
                if (clsUIHelper.ShowErrorMessageForInActiveLicense(_OldLicenseID))
                {

                    btnRenew.Enabled = false;
                    return;
                }
            }
        }

        private int RenewLicense()
        {
            if (clsLicense.DesactivateLicense(_OldLicenseID))
            {
                int DriverID = clsLicense.Find(_OldLicenseID).DriverID;
                int PersonID = clsDriver.Find(DriverID).PersonID;
                // 2 is the ApplicationTypeID for renew license app
                int ApplicationID = clsApplication.AddNewApplication(PersonID, DateTime.Now,
                    1, DateTime.Now, clsCurrentUser.UserID, 2);
                if (ApplicationID > 0)
                {
                    int LicenseClassID = clsLicense.Find(_OldLicenseID).LicenseClassID;
                    int ValidityYears = clsLicenseClasses.Find(LicenseClassID).DefaultValidityLength;
                    decimal LicenseFees = clsLicenseClasses.GetLicenseClassFees(LicenseClassID);

                    return clsLicense.AddNewLicense(ApplicationID, DriverID,
                       LicenseClassID, DateTime.Now,
                        DateTime.Now.AddYears(ValidityYears), "", LicenseFees, true, 2
                        , clsCurrentUser.UserID);
                }
            }
            return 0;
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
             _NewLicenseID = RenewLicense();
            if (_NewLicenseID > 0)
            {
                MessageBox.Show($"License Renewed Successfully With LicenseID= {_NewLicenseID}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                linklblShowLicenseInfo.Enabled = true;
                _LoadNewLicesneInfo();
            }
            else
            {
                clsUIHelper.ShowErrorMessageForFailOperation();
            }
        }

        private void _LoadNewLicesneInfo()
        {
            if (_NewLicenseID > 0)
            {
                var NewLicense = clsLicense.Find(_NewLicenseID);
                if (NewLicense != null)
                {
                    lblRenewedLicenseID.Text = _NewLicenseID.ToString();
                    lblRLApplicationID.Text = NewLicense.ApplicationID.ToString();
                }
                
            }
        }
        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(_NewLicenseID);
            showLicenseInfo.ShowDialog();
        }
    }
}
