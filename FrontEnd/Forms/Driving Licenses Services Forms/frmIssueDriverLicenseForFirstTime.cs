using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using FrontEnd.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmIssueDriverLicenseForFirstTime : Form
    {
        public frmIssueDriverLicenseForFirstTime(int lDLAppID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
        }

        private int _LDLAppID;

        private void LoadDLAInfo()
        {
            drivingLicenseApplicationInfoCnotroller1.LDLAppID= _LDLAppID;
            drivingLicenseApplicationInfoCnotroller1.LoadDLApplicationInfo();
        }
        private void LoadApplicationBasicInfo()
        {
            int ApplicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(_LDLAppID);
            applicationBasicInfoController1.ApplicationID= ApplicationID;
            applicationBasicInfoController1.LoadApplicationInfo();
        }

        private void frmIssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            LoadDLAInfo();
            LoadApplicationBasicInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int GetDriverID(int PersonID)
        {
            if (!clsDriver.IsExist(PersonID))
            {
                return  clsDriver.AddNewDriver(PersonID, clsCurrentUser.UserID
                  , DateTime.Now);
            }
            else
            {
                 return clsDriver.GetDriverIDByPersonID(PersonID);
            }
        }
        private bool _IssueDrivingLicenseForFirstTime()
        {
            int ApplicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(_LDLAppID);
            clsApplication Application = clsApplication.Find(ApplicationID);
            if (Application != null)
            {
                int PersonID = Application.ApplicantPersonID;
                int DriverID = GetDriverID(PersonID);
                if(DriverID == 0)
                {
                    clsUIHelper.ShowErrorMessage();
                    return false;
                }
                int licesneClassID = clsLicenseClasses.GetLicenseClassID(
                    clsManageLocalDrivingApplications.
                    GetLicenseClassNameFromApplicationID(ApplicationID));
                
              decimal PaidFees=clsLicenseClasses.GetLicenseClassFees(licesneClassID);
                byte IssueReason = Convert.ToByte(Application.ApplicationTypeID);
                int LicenseID = clsLicense.AddNewLicense(ApplicationID, DriverID, licesneClassID,
                    DateTime.Now, DateTime.Now.AddYears(10), rtbNotes.Text,
                    PaidFees, true, IssueReason, clsCurrentUser.UserID);
                if (LicenseID>0)
                {
                    // complete the application
                    clsApplication.CompleteApplication(ApplicationID);
                    MessageBox.Show($"License Issued Successfully with LicenseID=" +
                        $" {LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
                else
                {
                    clsUIHelper.ShowErrorMessage();
                }
            }
            return false;

        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_IssueDrivingLicenseForFirstTime())
            {
                this.Close();
            }
        }
    }
}
