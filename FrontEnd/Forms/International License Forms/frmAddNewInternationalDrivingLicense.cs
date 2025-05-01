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
using FrontEnd.Controllers.Application_Controllers;

namespace FrontEnd.Forms.International_License_Forms
{
    public partial class frmAddNewInternationalDrivingLicense : Form
    {
        public frmAddNewInternationalDrivingLicense()
        {
            InitializeComponent();
        }
        private int _LocalLicenseID = 0;
        private int internationalLicenseID = 0;
        private void _SetFormFullScreenVerticalOnly()
        {
            // this from chatgbt i don't know how it work
            this.Top = 0; // Move form to top of screen
            this.Height = Screen.PrimaryScreen.WorkingArea.Height; // Full vertical height

        }
       
        private void frmAddNewInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            _SetFormFullScreenVerticalOnly();
            applicationInfo_NewInternationalDLApplicationController1.LoadApplicationInfo();

        }
        private void CanAddNewInternationalLicense(int LocalLicesneID)
        {
            if (clsInternationalLicense.CanAddNewInternationalLicense(LocalLicesneID))
            {
                btnIssue.Enabled = true;
            }
            else
            {
                btnIssue.Enabled = false;
                MessageBox.Show("To Add new international license you need to have a an active local license" +
                    " and a Class 3 - Ordinary driving license", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void findLocalLicenseController1_OnFindClick(int obj)
        {
            _LocalLicenseID = obj;
            applicationInfo_NewInternationalDLApplicationController1.LicenseID = _LocalLicenseID;
            applicationInfo_NewInternationalDLApplicationController1.LoadApplicationInfo();

            CanAddNewInternationalLicense(_LocalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int IssueInternationalLicense()
        {
            int InternationalLicenseID = 0;
            int DriverID = clsLicense.Find(_LocalLicenseID).DriverID;
            int PersonID = clsDriver.Find(DriverID).PersonID;

            int ApplicationID = clsApplication.AddNewInternationalLicenseApplication(PersonID, DateTime.Now,
                1, DateTime.Now, clsCurrentUser.UserID);
            if (ApplicationID>0)
            {
                 InternationalLicenseID = clsInternationalLicense.AddNewInternationalLicense(
                    ApplicationID, DriverID, _LocalLicenseID, DateTime.Now,
                    DateTime.Now.AddYears(1), clsCurrentUser.UserID);
                if(InternationalLicenseID>0)
                {
                    clsApplication.CompleteApplication(ApplicationID);

                    return InternationalLicenseID;
                }
            }
            return 0;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = clsInternationalLicense.IsExistByLocalLicenseID
                (_LocalLicenseID);
            if (InternationalLicenseID>0)
            {
                MessageBox.Show("This Driver already has a InternationalLicesne" +
                    $" with ILicID= {InternationalLicenseID}", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            else
            {
                InternationalLicenseID = IssueInternationalLicense();
                if (InternationalLicenseID > 0)
                {
                    MessageBox.Show("International License Issued Successfully" +
                        $" with ILicID= {InternationalLicenseID}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    applicationInfo_NewInternationalDLApplicationController1.
                        InternationalLicenseID = InternationalLicenseID;
                    applicationInfo_NewInternationalDLApplicationController1.
                        LoadApplicationInfo();
                    linklblShowLicenseInfo.Enabled = true;
                    internationalLicenseID = InternationalLicenseID;
                }
                else
                {
                    MessageBox.Show("Error in Issuing International License", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linklblShowLicenseInfo.Enabled = false;
                }
            }
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(internationalLicenseID>0)
            {
                frmShowInternationalLicenseInfo frmShowInternationalLicenseInfo =
               new frmShowInternationalLicenseInfo(internationalLicenseID);
                frmShowInternationalLicenseInfo.ShowDialog();
            }
            else linklblShowLicenseInfo.Enabled = false;

        }
    }
}
