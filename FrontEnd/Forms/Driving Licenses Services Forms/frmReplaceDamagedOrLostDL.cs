using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using FrontEnd.Classes;
using FrontEnd.Forms.Driving_Licenses_Services_Forms.TestTypes_Forms;

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmReplaceDamagedOrLostDL : Form
    {
        public frmReplaceDamagedOrLostDL()
        {
            InitializeComponent();
        }

       private int _OldLicenseID = 0;
        private int _ApplicationTypeID = 0;
        private int _NewLicenseID = 0;

        private void _LoadApplicationInfo()
        {
            lblApplicationDate.Text = clsUIHelper.GetCurrentDate();
            lblCreatedBy.Text = clsCurrentUser.UserName;
        }

        private void frmReplaceDamagedOrLostDL_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }

        private void _SetApplicationFees()
        {
            if(rbDamagedLicense.Checked)
            {
                _ApplicationTypeID = 4;
            }
            if(rbLostLicense.Checked)
            {
                _ApplicationTypeID = 3;
            }
            lblApplicationFees.Text = clsApplicationType.GetApplicationFee(_ApplicationTypeID).ToString("F2");
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _SetApplicationFees();
            lblMode.Text = "Replacement For Damaged License";
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _SetApplicationFees();
            lblMode.Text = "Replacement For Lost License";
        }

        private void findLocalLicenseController1_OnFindClick(int obj)
        {
            _OldLicenseID = obj;
            if(_OldLicenseID>0)
            {
                lblOldLicenseID.Text= _OldLicenseID.ToString();
            }
           if(!clsUIHelper.ShowErrorMessageForInActiveLicense(_OldLicenseID))
            {
                btnIssue.Enabled = true;
                return;
            }
            btnIssue.Enabled = false; 
        }

        private int IssueReplacement()
        {
            var OldLicense = clsLicense.Find(_OldLicenseID);
            int DriverID=OldLicense.DriverID;
            int PersonID= clsDriver.Find(DriverID).PersonID;
            if(clsLicense.DesactivateLicense(_OldLicenseID))
            {
                int ApplicationID = clsApplication.AddNewApplication(PersonID, DateTime.Now, 1,
                DateTime.Now, clsCurrentUser.UserID, _ApplicationTypeID);
                if (ApplicationID > 0)
                {
                    int LicenseAge = clsLicenseClasses.Find(OldLicense.LicenseClassID).DefaultValidityLength;
                    return clsLicense.AddNewLicense(ApplicationID, DriverID, OldLicense.LicenseClassID,
                        DateTime.Now, DateTime.Now.AddYears(LicenseAge), "", 0, true, (byte)_ApplicationTypeID,
                        clsCurrentUser.UserID);
                }
            }
            
            return 0;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            _NewLicenseID = IssueReplacement();
            if(_NewLicenseID>0)
            {
                MessageBox.Show($"License Replaced Successfully With LicenseID= {_NewLicenseID}",
                     "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                linklblShowLicenseInfo.Enabled = true;
                _LoadNewLicesneInfo();
            }
            else
            {
                clsUIHelper.ShowErrorMessageForFailOperation();
                linklblShowLicenseInfo.Enabled = false;
            }
        }
        private void _LoadNewLicesneInfo()
        {
            lblReplacementLicenseID.Text = _NewLicenseID.ToString();
            lblLRApplicationID.Text = clsLicense.Find(_NewLicenseID).ApplicationID.ToString();
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicenseID > 0)
            {
                frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(_NewLicenseID);
                showLicenseInfo.ShowDialog();
            }
        }
    }
}
