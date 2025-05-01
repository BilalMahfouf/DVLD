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
using FrontEnd.Forms.Drivers_Forms;

namespace FrontEnd.Forms.International_License_Forms
{
    public partial class frmManageInternationalLicenseApplication : Form
    {
        public frmManageInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private DataTable _InternationalApp;

        private void _LoadIApp()
        {
            _InternationalApp = clsInternationalLicense.GetAllLicenses();
            dgvApplications.DataSource = _InternationalApp;
            lblRecords1.Text = "Records:" + _InternationalApp.Rows.Count.ToString();
        }

        private void _SetdgvDesigned()
        {
            dgvApplications.Columns[0].Width = 150;
            dgvApplications.Columns[1].Width = 120;
            dgvApplications.Columns[2].Width = 120;
            dgvApplications.Columns[3].Width = 150;
            dgvApplications.Columns[4].Width = 200;
            dgvApplications.Columns[5].Width = 200;
            dgvApplications.Columns[6].Width = 115;
        }

        private void frmManageInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadIApp();
            _SetdgvDesigned();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbAddNewInternationalDrivingApplication_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalDrivingLicense addNewInternationalDrivingLicense
                = new frmAddNewInternationalDrivingLicense();
            addNewInternationalDrivingLicense.ShowDialog();
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            int DriverID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[2].Value);
            int PersonID = clsDriver.Find(DriverID).PersonID;
            frmPersonInfo ShowPersonInfo = new frmPersonInfo(PersonID);
            ShowPersonInfo.ShowDialog();
        }

        private void tsnShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int ILicenseID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
            frmShowInternationalLicenseInfo internationalLicenseInfo
                = new frmShowInternationalLicenseInfo(ILicenseID);
            internationalLicenseInfo.ShowDialog();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int DriverID = Convert.ToInt32(dgvApplications.CurrentRow.Cells[2].Value);
            frmDriverLicenseHistory driverLicenseHistory
                = new frmDriverLicenseHistory(DriverID);
            driverLicenseHistory.ShowDialog();
        }
    }
}
