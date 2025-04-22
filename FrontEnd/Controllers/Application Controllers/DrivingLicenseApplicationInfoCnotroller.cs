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

namespace FrontEnd.Controllers.Application_Controllers
{
    public partial class DrivingLicenseApplicationInfoCnotroller : UserControl
    {
        public DrivingLicenseApplicationInfoCnotroller()
        {
            InitializeComponent();
        }
        public int LDLAppID {  get; set; }

        private void _LoadDLApplicationInfo()
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication
                .Find(LDLAppID);
            if ( LDLApp != null )
            {
                lblDLAppID.Text = LDLApp.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseType.Text = clsLicenseClasses.GetLicenseClassName(LDLApp.LicenseClassID);
                lblPassedTests.Text = clsManageLocalDrivingApplications.
                    GetPassedTestCount(LDLApp.LocalDrivingLicenseApplicationID).ToString();           
            }
        }
        public void LoadDLApplicationInfo()
        {
            _LoadDLApplicationInfo();
        }
        private void DrivingLicenseApplicationInfoCnotroller_Load(object sender, EventArgs e)
        {
            _LoadDLApplicationInfo();
        }
    }
}
