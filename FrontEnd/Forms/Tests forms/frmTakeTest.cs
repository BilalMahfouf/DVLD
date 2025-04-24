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
using FrontEnd.Controllers.TestControllers;

namespace FrontEnd.Forms.Tests_forms
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(int testAppointment)
        {
            InitializeComponent();
            _TestAppointmentID = testAppointment;
        }
        private int _TestAppointmentID;
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            testInfoController1.TestAppointmentID = _TestAppointmentID;
            testInfoController1.LoadTestInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _Save()
        {
            bool TestResult = false;
            if(rbFail.Checked)
            {
                TestResult = false;
            }
            if(rbPass.Checked)
            {
                TestResult = true;
            }

            int TestID = clsTest.AddNewTest(_TestAppointmentID, TestResult,
                clsCurrentUser.UserID, rtbNotes.Text);
            if( TestID > 0)
            {
                clsTestAppointment Testappointment = clsTestAppointment.Find(_TestAppointmentID);
                if( Testappointment != null )
                {
                    Testappointment.IsLocked = true;
                    if(Testappointment.RetakeTestApplicationID>0)
                    {
                        clsApplication.CompleteApplication(Testappointment.RetakeTestApplicationID);
                    }
                    return Testappointment.Save();
                }
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                MessageBox.Show("Data saved successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();

            }
            else
            {
                MessageBox.Show("Can't perform this operation", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testInfoController1_Load(object sender, EventArgs e)
        {

        }
    }
}
