﻿using System;
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
using FrontEnd.Forms.Drivers_Forms;
using FrontEnd.Forms.Driving_Licenses_Services_Forms.TestTypes_Forms;
using FrontEnd.Forms.Tests_forms;

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private DataTable _ManageApplications;
        private void _Refresh()
        {
            _ManageApplications = clsManageLocalDrivingApplications.GetAllLocalDrivingApplications();
            dgvApplications.DataSource = _ManageApplications;
            lblRecords1.Text = "Records: " + dgvApplications.Rows.Count.ToString();
            _SetcbFilterByDesigned();


        }

        private void SetdgvDesigned()
        {
            dgvApplications.Columns[0].Width = 100;
            dgvApplications.Columns[0].Name = "L.D.L.AppID";
            dgvApplications.Columns[0].HeaderText = "L.D.L.AppID";

            dgvApplications.Columns[1].Width = 250;
            dgvApplications.Columns[1].Name = "Driving Class";
            dgvApplications.Columns[1].HeaderText = "Driving Class";

            dgvApplications.Columns[2].Width = 100;
            dgvApplications.Columns[3].Width = 250;
            dgvApplications.Columns[4].Width = 150;
            dgvApplications.Columns[5].Width = 100;
            dgvApplications.Columns[5].Name = "Passed Tests";
            dgvApplications.Columns[5].HeaderText = "Passed Tests";
            dgvApplications.Columns[6].Width = 105;

        }

        private void _SetcbFilterByDesigned()
        {
            cbfilterBy.SelectedIndex = 0;
        }



        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _Refresh();
            SetdgvDesigned();
            _SetcbFilterByDesigned();
        }

        private string _ReplaceString(string str)
        {
            if (str == "L.D.L.AppID")
            {
                return "LocalDrivingLicenseApplicationID";
            }
            return str;
        }
        private bool Search(string SearchOption, string SearchOn)
        {
            DataTable SearchResult = _ManageApplications.Clone();
            SearchOption=_ReplaceString(SearchOption);
            foreach (DataRow Row in _ManageApplications.Rows)
            {
                if (Row[SearchOption].ToString().ToUpper() == SearchOn.ToUpper())
                {
                    SearchResult.ImportRow(Row);
                }
            }
            if(SearchResult.Rows.Count > 0)
            {
                dgvApplications.DataSource = SearchResult;
                return true;
            }
            return false;

        }

        private void cbfilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbfilterBy.SelectedIndex > 0)
            {
                mtbSearch.Visible = true;
                if (cbfilterBy.SelectedItem != null && cbfilterBy.SelectedItem.ToString() == "L.D.L.AppID")
                {
                    // Allow only 10-digit numeric input
                    mtbSearch.Mask = "0000000000";
                }
                else
                {
                    mtbSearch.Mask = string.Empty;
                }
            }

            else
            {
                mtbSearch.Visible = false;
                _Refresh();
            }
        }

        private void mtbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!Search(cbfilterBy.Text, mtbSearch.Text))
            {
                DataTable temp = _ManageApplications.Clone();
                temp.Rows.Clear();
                dgvApplications.DataSource= temp;
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbAddNewLocalDrivingApplication_Click(object sender, EventArgs e)
        {
            frmNewOrEditDrivingLicense_Local frm = new frmNewOrEditDrivingLicense_Local(-1);
            frm.ShowDialog();
            _Refresh();
        }



        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int LDLApplication = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmNewOrEditDrivingLicense_Local frm = new frmNewOrEditDrivingLicense_Local(LDLApplication);
            frm.ShowDialog();
            _Refresh();
        }

        private void tsmCancel_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Are you sure to cancel this application", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (result == DialogResult.OK)
            {
                int LDLApplicationID = Convert.ToInt32
                    (dgvApplications.CurrentRow.Cells[0].Value);
                if(clsManageLocalDrivingApplications.CancelApplication(LDLApplicationID))
                {
                    MessageBox.Show("Application canceled successfully", "Cancel",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Can't perform this application", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            
            
        }

        private void tsmScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmTestAppointment frmVisionTest = new frmTestAppointment(LDLApplicationID
                , 1);
            frmVisionTest.ShowDialog();
            _Refresh();
        }

        private void _SetTestType()
        {
            int TestType= Convert.ToInt32(dgvApplications.CurrentRow.Cells[5].Value);
            string Status = dgvApplications.CurrentRow.Cells[6].Value.ToString();
            if(Status == "Completed" || Status == "Cancelled")
            {
                tsmSechduleTests.Enabled = false;
                return;
            }
            switch (TestType)
            {
                case 0:
                    {
                        tsmSechduleTests.Enabled = true;
                            tsmScheduleVisionTest.Enabled = true;
                        tsmScheduleWrittenTest.Enabled = false;
                        tsmScheduleStreetTest.Enabled = false;


                        break;
                    }
                    case 1:
                    {
                        tsmSechduleTests.Enabled = true;
                        tsmScheduleVisionTest.Enabled = false;
                        tsmScheduleWrittenTest.Enabled = true;
                        tsmScheduleStreetTest.Enabled = false;
                        break;
                    }
                    case 2:
                    {
                        tsmSechduleTests.Enabled = true;
                        tsmScheduleVisionTest.Enabled = false;
                        tsmScheduleWrittenTest.Enabled = false;
                        tsmScheduleStreetTest.Enabled = true;
                        break;
                    }
                case 3:
                    tsmSechduleTests.Enabled = false;
                    break;

            }


        }

        private void _SetcmtForCancelledAndCompletedApp()
        {
            string ApplicationStatus = dgvApplications.CurrentRow.Cells[6].Value.ToString();
            if (ApplicationStatus == "Cancelled" || ApplicationStatus=="Completed")
            {
                tsmCancel.Enabled = false;
                tsmEdit.Enabled = false;
                tsmDelete.Enabled = false;
                tsmIssueDrivingLicenseFirstTime.Enabled = false;
                
            }
            else
            {
                tsmCancel.Enabled = true;
                tsmEdit.Enabled = true;
                tsmDelete.Enabled = true;
                
            }
        }

        private void SetcmtForIssueDrivingLicense()
        {
            int LDLAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            int ApplicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(LDLAppID);
            int LicenseClassID = clsLicenseClasses.GetLicenseClassID
                (dgvApplications.CurrentRow.Cells[1].Value.ToString());
            if (clsLicense.IsExistByApplicationIDAndLicenseClassID(ApplicationID, LicenseClassID))
            {
                tsmIssueDrivingLicenseFirstTime.Enabled=false;
             
            }
            if (Convert.ToInt32(dgvApplications.CurrentRow.Cells[5].Value)==3)
            {
                tsmIssueDrivingLicenseFirstTime.Enabled = true;
            }
            else tsmIssueDrivingLicenseFirstTime.Enabled = false;
        }

        private void SetcmtForShowDrivingLicense()
        {
            int LDLAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            int ApplicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(LDLAppID);
            int LicenseClassID = clsLicenseClasses.GetLicenseClassID
                (dgvApplications.CurrentRow.Cells[1].Value.ToString());
            if (clsLicense.IsExistByApplicationIDAndLicenseClassID(ApplicationID, LicenseClassID))
            {
                tsmShowDrivingLicense.Enabled=true;
                return;
            }
            tsmShowDrivingLicense.Enabled = false;
        }

        private void SetcmtForShowDrivingLicenseHistory()
        {
            int LDLAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            int ApplicationID = clsManageLocalDrivingApplications.
                GetApplicationIDFromLDLApplicationID(LDLAppID);
            var License= clsLicense.FindByApplicationID(ApplicationID);
            if (License!=null)

            {
                tsmShowPersonLicenseHistory.Enabled=true;
                _DriverID = License.DriverID;
                return;
            }
            tsmShowPersonLicenseHistory.Enabled = false;
        }

        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _SetTestType();
            SetcmtForIssueDrivingLicense();
            _SetcmtForCancelledAndCompletedApp();
            SetcmtForShowDrivingLicense();
            SetcmtForShowDrivingLicenseHistory();
        }

        
        

        private void tsmScheduleWrittenTest_Click(object sender, EventArgs e)
        {
             int LDLApplicationID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmTestAppointment frmWrittenTest = new frmTestAppointment(LDLApplicationID
                , 2);
            frmWrittenTest.ShowDialog();
            _Refresh();


        }

        private void tsmScheduleStreetTest_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmTestAppointment frmStreetTest = new frmTestAppointment(LDLApplicationID
                , 3);
            frmStreetTest.ShowDialog();
            _Refresh();
        }

        private void tsmShowApplicationDetails_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmShowApplicationDetails showApplicationDetails =
                new frmShowApplicationDetails(LDLAppID);
            showApplicationDetails.ShowDialog();
        }

        private void tsmIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmIssueDriverLicenseForFirstTime issueDriverLicenseForFirstTime=
                new frmIssueDriverLicenseForFirstTime(LDLAppID);
            issueDriverLicenseForFirstTime.ShowDialog();
            _Refresh();
        }

        private void tsmShowDrivingLicense_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            int ApplicationID=clsManageLocalDrivingApplications.GetApplicationIDFromLDLApplicationID(LDLAppID);
            int LicenseID=clsLicense.GetLicenseIDByApplicationID(ApplicationID);
            frmShowLicenseInfo showLicenseInfo =
                new frmShowLicenseInfo(LicenseID);
            showLicenseInfo.ShowDialog();
        }

        private int _DriverID = 0;
        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Not Implemented Yet", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if(_DriverID > 0)
            {
                frmDriverLicenseHistory frmDriverLicenseHistory =
                    new frmDriverLicenseHistory(_DriverID);
                frmDriverLicenseHistory.ShowDialog();
            }
            

        }
    }
}
