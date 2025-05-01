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
using FrontEnd.Forms.ApplicationTypes_Forms;
using FrontEnd.Forms.Drivers_Forms;
using FrontEnd.Forms.Driving_Licenses_Services_Forms;
using FrontEnd.Forms.International_License_Forms;
using FrontEnd.Forms.Renew_Driving_License_Forms;
using FrontEnd.Forms.TestTypes_Forms;
using FrontEnd.Forms.User_Forms;

namespace FrontEnd.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void tsmCurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmUserInformation frmUserInformation = new frmUserInformation(clsCurrentUser.UserID);
            frmUserInformation.ShowDialog();
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsCurrentUser.UserID);
            frmChangePassword.ShowDialog();
        }

        private void tsmSignOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tsmManageApplicationsTypes_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frmManageApplicationTypes = new frmManageApplicationTypes();  
            frmManageApplicationTypes.ShowDialog();
        }

        private void tsmManageTestTypes_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frmManageTestTypes = new frmManageTestTypes();
            frmManageTestTypes.ShowDialog();
        }

        private void tsmLocalLincense_Click(object sender, EventArgs e)
        {
            frmNewOrEditDrivingLicense_Local frmNewDrivingLicense_Local=
                new frmNewOrEditDrivingLicense_Local(-1);
            frmNewDrivingLicense_Local .ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void tsmLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivers frmDrivers = new frmDrivers();
            frmDrivers.ShowDialog();
        }

        private void tsmInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseApplication internationalLicenseApplication
                = new frmManageInternationalLicenseApplication();
            internationalLicenseApplication.ShowDialog();
        }

        private void tsmInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalDrivingLicense newInternationalDrivingLicense
                =new frmAddNewInternationalDrivingLicense();
            newInternationalDrivingLicense.ShowDialog();
        }

        private void tsmRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense renewDrivingLicense
                = new frmRenewDrivingLicense();
            renewDrivingLicense.ShowDialog();
        }
    }
}
