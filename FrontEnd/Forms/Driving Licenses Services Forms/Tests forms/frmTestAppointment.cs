using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace FrontEnd.Forms.Tests_forms
{
    public partial class frmTestAppointment : Form
    {
        public frmTestAppointment(int localDrivingLicenseApplicationID, int testTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
        }
        private int _LocalDrivingLicenseApplicationID;
        private int _TestTypeID;
       
        private void frmTestAppointment_Load(object sender, EventArgs e)
        {
            LoadApplicationInfo();
            LoadDLApplicationInfo();
            _SetMode();
            _LoadTestAppointment();
            _SetdgvDesigned();
        }
        private void LoadApplicationInfo()
        {
            int applicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(_LocalDrivingLicenseApplicationID);
        applicationBasicInfoController1.ApplicationID = applicationID;
            applicationBasicInfoController1.LoadApplicationInfo();
            
        
        }

        private void _SetMode()
        {
            switch (_TestTypeID)
            {
            case 1:
                    {
                        lblTestApppointment.Text = "Vision Test Appointment";
                        break;
                    }
                case 2:
                    {
                        lblTestApppointment.Text = "Written Test Appointment";
                        break;
                    }
                    case 3:
                    {
                        lblTestApppointment.Text = "Street Test Appointment";
                        break;
                    }
            }

        }

        private void LoadDLApplicationInfo()
        {
            drivingLicenseApplicationInfoCnotroller1.LDLAppID = _LocalDrivingLicenseApplicationID;
            drivingLicenseApplicationInfoCnotroller1.LoadDLApplicationInfo();
        }

        private void _LoadTestAppointment()
        {
            DataTable dt = clsTestAppointment.GetAllTestAppointment(_LocalDrivingLicenseApplicationID,
               _TestTypeID);
            if(dt.Rows.Count>0)
            {
                dgvTestAppointments.DataSource = dt;
            }
        }

        private int GetLastRowAppointmentTestID()
        {
            if (dgvTestAppointments.Rows.Count > 0)
            {
                int lastDataRowIndex = dgvTestAppointments.Rows.GetLastRow(DataGridViewElementStates.Visible);
                // If you don't care about visibility, just use dgv.Rows.Count - 1
                DataGridViewRow lastDataRow = dgvTestAppointments.Rows[lastDataRowIndex];

                // Example: read a cell value
                int value = (int)lastDataRow.Cells[0].Value;
                return value;
            }
            return -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.CantAddNewTestAppointment(_LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("This Person already has a test appointment ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(clsTest.IsPassedTest(GetLastRowAppointmentTestID()))
            {
                MessageBox.Show("This Person already has passed this test ", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddNewTestAppointment frmAddNewTestAppointment = new frmAddNewTestAppointment
                (_LocalDrivingLicenseApplicationID,_TestTypeID,-1);
            frmAddNewTestAppointment.ShowDialog();
            _LoadTestAppointment();


        }
        private void _SetdgvDesigned()
        {
            if(dgvTestAppointments.Rows.Count>0)
            {
                dgvTestAppointments.Columns[0].Width = 150;
                dgvTestAppointments.Columns[1].Width = 250;
                dgvTestAppointments.Columns[2].Width = 150;
                dgvTestAppointments.Columns[3].Width = 100;

            }


        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int TestAppointment = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);
            
                frmAddNewTestAppointment frmUpdateTestAppointment = new frmAddNewTestAppointment
                               (_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointment);
                frmUpdateTestAppointment.ShowDialog();
            
            _LoadTestAppointment();
        }

        private bool CompleteApplication()
        {
            int ApplicationID = clsManageLocalDrivingApplications.
            GetApplicationIDFromLDLApplicationID(_LocalDrivingLicenseApplicationID);
            if(ApplicationID != 0)
            {
                return clsApplication.CompleteApplication(ApplicationID);
            }
            return false;
        }
        private void tsmTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = Convert.ToInt32(dgvTestAppointments.CurrentRow.Cells[0].Value);
            frmTakeTest TakeTest = new frmTakeTest(TestAppointmentID);
            TakeTest.ShowDialog();
            _LoadTestAppointment();

            // Don't complete the application until the the driving license is issued

            //if(_TestTypeID==3 && clsTest.IsPassedTest(TestAppointmentID))
            //{
            //    CompleteApplication();
            //}


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
