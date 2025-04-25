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

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmShowApplicationDetails : Form
    {
        public frmShowApplicationDetails(int lDLAppID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
        }
        int _LDLAppID;
        

        private void LoadApplicationBasicInfo()
        {
            int ApplicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(_LDLAppID);
            applicationBasicInfoController1.ApplicationID = ApplicationID;
            applicationBasicInfoController1.LoadApplicationInfo();
        }

        private void LoadDrivingLicenseApplicationInfo()
        {
            drivingLicenseApplicationInfoCnotroller1.LDLAppID = _LDLAppID;
            drivingLicenseApplicationInfoCnotroller1.LoadDLApplicationInfo();
        }
        private void frmShowApplicationDetails_Load(object sender, EventArgs e)
        {
            LoadApplicationBasicInfo();
            LoadDrivingLicenseApplicationInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
