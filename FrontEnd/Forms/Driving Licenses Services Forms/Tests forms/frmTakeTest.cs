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
            _IsTestTaken_ScreenLoad();
        }

        private void _IsTestTaken_ScreenLoad()
        {
            if(clsTest.GetTestID(_TestAppointmentID)>0)
            {
                btnSave.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                rtbNotes.Enabled = false;
                lblPassedTest1.Text = "This person has already taken this test";
            }
            else
            {
                btnSave.Enabled = true;
                rbFail.Enabled = true;
                rbPass.Enabled = true;
                rtbNotes.Enabled = true;
                lblPassedTest1.Text = "";
            }
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
            DialogResult result = MessageBox.Show(@"Are you sure you want to pass this
test? after you put the result you can't change it", "Validation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.OK)
            {
                int TestID = clsTest.AddNewTest(_TestAppointmentID, TestResult,
                                clsCurrentUser.UserID, rtbNotes.Text);
                if (TestID > 0)
                {
                    clsTestAppointment Testappointment = clsTestAppointment.Find(_TestAppointmentID);
                    if (Testappointment != null)
                    {
                        Testappointment.IsLocked = true;
                        if (Testappointment.RetakeTestApplicationID > 0)
                        {
                            clsApplication.CompleteApplication(Testappointment.RetakeTestApplicationID);
                        }
                        return Testappointment.Save();
                    }
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
