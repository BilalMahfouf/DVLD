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

namespace FrontEnd.Forms.Tests_forms
{
    public partial class frmAddNewTestAppointment : Form
    {
        public frmAddNewTestAppointment(int lDLAppID, int testTypeID, int appointmentID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
            TestTypeID = testTypeID;
            _AppointmentID = appointmentID;
        }
        int _LDLAppID;
        int TestTypeID;
        int _AppointmentID;
        private void _LoadScheduleTestController()
        {
            scheduleTestController1.LDLAppID= _LDLAppID;
            scheduleTestController1.TestTypeID= TestTypeID;
            scheduleTestController1.TestAppointmentID= _AppointmentID;
            scheduleTestController1.LoadController();
        }

        private void scheduleTestController1_Load(object sender, EventArgs e)
        {
            _LoadScheduleTestController();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewTestAppointment_Load(object sender, EventArgs e)
        {

        }

        private void scheduleTestController1_OnSaveRequested()
        {
            
            this.Close();
        }
    }
}
