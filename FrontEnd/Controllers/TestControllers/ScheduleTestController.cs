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

namespace FrontEnd.Controllers.TestControllers
{
    public partial class ScheduleTestController : UserControl
    {
        public ScheduleTestController()
        {
            InitializeComponent();
        }
        public int TestAppointmentID {  get; set; }
        private  enum enMode { AddNew,Update}
        private enMode _Mode;
        public int LDLAppID { get; set; }
        public int TestTypeID { get; set; }
        private void ScheduleTestController_Load(object sender, EventArgs e)
        {
            _LoadTestInfo();
            _LoadRetakeTestInfo();
            dtpDate.CustomFormat = "dd/MM/yyyy";
        }
        public void LoadController()
        {
            _SetMode();
            _LoadTestInfo();
            _LoadRetakeTestInfo();
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
                lblTrial.Text = clsTestAppointment.GetTestTrial(LDLAppID,TestTypeID).ToString();
                dtpDate.Text = DateTime.Now.ToString();
                lblFees.Text = clsTestType.GetTestFee(TestTypeID).ToString("F2");

            }
        }

        private void _LoadRetakeTestInfo()
        {
            if(clsTestAppointment.GetTestTrial(LDLAppID, TestTypeID)>0)
            {
                gbRetakeTestInfo.Enabled = true;
                // 7 is the retake testappID
                lblRAppFees.Text=clsApplicationType.GetApplicationFee(7).ToString("F2");
                decimal TotalFees = Convert.ToDecimal(lblFees.Text) + Convert.ToDecimal(lblRAppFees.Text);
                lblTotalFees.Text = TotalFees.ToString("F2");
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
            }
        }

        private void _SetMode()
        {
            switch (TestTypeID)
            {
                case 1:
                    {
                        lblTestType.Text = "Vision Test";
                        pbTestTypePicture.Image = Properties.Resources.Vision_512;
                        break;
                    }
                case 2:
                    {
                        lblTestType.Text = "Written Test";
                        pbTestTypePicture.Image = Properties.Resources.Written_Test_512;
                        break;
                    }
                case 3:
                    {
                        lblTestType.Text = "Street Test";
                        pbTestTypePicture.Image = Properties.Resources.Street_Test_32;
                        break;
                    }

            }

            if (TestAppointmentID > 0) 
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private bool _AddNew()
        {
            int Trial = Convert.ToInt32(lblTrial.Text);
            int _RetakeTestApplicationID = 0;
            if (Trial > 0)
            {
                int PersonID = clsManageLocalDrivingApplications.
                    GetApplicantPersonIDFromLDLApplicationID(LDLAppID);
                decimal PaidFees = clsTestType.GetTestFee(TestTypeID);
                int CreatedbyUserID = clsCurrentUser.UserID;
                _RetakeTestApplicationID = clsApplication.
                   AddNewRetakeTestApplication(PersonID, DateTime.Now, 1, DateTime.Now,
                   PaidFees, CreatedbyUserID);
            }
            decimal TestPaidFees = Convert.ToDecimal(lblFees.Text);
            int CreatedbyUser = clsCurrentUser.UserID;
            bool isLocked = false;
            TestAppointmentID = clsTestAppointment.AddNewAppointment(LDLAppID, TestTypeID, DateTime.Now,
                TestPaidFees, CreatedbyUser, isLocked, _RetakeTestApplicationID);
            if (TestAppointmentID>0)
            {
                return true;
            }
            return false;
        }

        private bool _Update()
        {
            DateTime dateTime = Convert.ToDateTime(dtpDate.Text);
            return clsTestAppointment.UpdateAppointment(TestAppointmentID, dateTime);
        }
        private bool _Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                {
                if (_AddNew()) 
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                }
                    case enMode.Update:
                    return _Update();
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                MessageBox.Show("Data saved successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Can't perform this operation", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SaveRequested();
        }

        public event Action OnSaveRequested;
        protected virtual void SaveRequested()
        {
            Action handler = OnSaveRequested;
            if (handler != null)
            {
                handler(); // Invoke event
            }
        }

         
       

    }
}
