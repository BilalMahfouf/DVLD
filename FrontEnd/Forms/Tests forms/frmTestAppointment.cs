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
        }
        private void LoadApplicationInfo()
        {
            int applicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(_LocalDrivingLicenseApplicationID);
        applicationBasicInfoController1.ApplicationID = applicationID;
            applicationBasicInfoController1.LoadApplicationInfo();
            
        
        }
    }
}
