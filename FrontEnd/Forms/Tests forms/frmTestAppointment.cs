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
    }
}
