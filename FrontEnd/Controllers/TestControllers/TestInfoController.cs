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

namespace FrontEnd.Controllers.TestControllers
{
    public partial class TestInfoController : UserControl
    {
        public TestInfoController()
        {
            InitializeComponent();
        }
        public  int TestAppointmentID { get;  set; }

       

        private void _LoadTestInfo()
        {
            clsTestAppointment TestAppointment= clsTestAppointment.Find(TestAppointmentID);
            if( TestAppointment != null )
            {
                clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication
                                .Find(TestAppointment.LocalDrivingLicenseApplicationID); ;
                if (LDLApp != null)
                {
                    lblDLAppID.Text = LDLApp.LocalDrivingLicenseApplicationID.ToString();
                    lblDClass.Text = clsLicenseClasses.GetLicenseClassName(LDLApp.LicenseClassID);
                    int PersonID = clsManageLocalDrivingApplications.GetApplicantPersonIDFromLDLApplicationID(LDLApp.LocalDrivingLicenseApplicationID);
                    lblFullName.Text = clsPerson.GetPersonFullName(PersonID);
                    lblTrial.Text = clsTestAppointment.GetTestTrial(LDLApp.LocalDrivingLicenseApplicationID, TestAppointment.TestTypeID).ToString();
                    lblDate.Text = clsTestAppointment.Find(TestAppointmentID).AppointmentDate.ToString();
                    lblFees.Text = clsTestType.GetTestFee(TestAppointment.TestTypeID).ToString("F2");

                }
            }
            
        }
        public void LoadTestInfo()
        {
            _LoadTestInfo();
        }
        private void TestInfoController_Load(object sender, EventArgs e)
        {
            _LoadTestInfo();
        }
    }
}
