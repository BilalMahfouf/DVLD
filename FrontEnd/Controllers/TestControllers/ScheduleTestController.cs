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

namespace FrontEnd.Controllers.TestControllers
{
    public partial class ScheduleTestController : UserControl
    {
        public ScheduleTestController()
        {
            InitializeComponent();
        }

        public int LDLAppID { get; set; }
        private void ScheduleTestController_Load(object sender, EventArgs e)
        {

        }
        private void _LoadTestInfo()
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication
                .Find(LDLAppID);
            if( LDLApp != null )
            {
                lblDLAppID.Text = LDLAppID.ToString();
                lblDClass.Text = clsLicenseClasses.GetLicenseClassName(LDLApp.LicenseClassID);
                int PersonID = clsManageLocalDrivingApplications.GetApplicantPersonIDFromLDLApplicationID(LDLAppID);
                lblFullName.Text=clsPerson.GetPersonFullName(PersonID);
                lblTrial.Text = clsTestAppointment.GetTestTrial(LDLAppID,LDLApp.).ToString();
            }
        }
    }
}
