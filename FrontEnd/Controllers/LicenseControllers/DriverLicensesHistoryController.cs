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
using FrontEnd.Forms.Driving_Licenses_Services_Forms.TestTypes_Forms;
using FrontEnd.Forms.International_License_Forms;

namespace FrontEnd.Controllers.LicenseControllers
{
    public partial class DriverLicensesHistoryController : UserControl
    {
        public DriverLicensesHistoryController()
        {
            InitializeComponent();
        }

        public int DriverID { get; set; }

        private void _LoadLocalLicensesHistory()
        {
            dgvLocalLicenses.DataSource = clsLicense.GetDriverLicenseHistory(DriverID);
            lblRecords.Text = "Records: " + dgvLocalLicenses.Rows.Count.ToString();
        }
        public void LoadLicensesHistory()
        {
            _LoadLocalLicensesHistory();
            _LoadInternationalLicensesHistory();
            _SetdgvLocalLicensesDesigned();
            _SetdgvInternationalLicensesDesigned();
        }
        private void _SetdgvLocalLicensesDesigned()
        {
            if(dgvLocalLicenses.Rows.Count>0)
            {
                dgvLocalLicenses.Columns[0].Width = 130;
                dgvLocalLicenses.Columns[0].HeaderText = "Lic.ID";

                dgvLocalLicenses.Columns[1].Width = 130;
                dgvLocalLicenses.Columns[1].HeaderText = "App.ID";

                dgvLocalLicenses.Columns[2].Width = 280;
                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";

                dgvLocalLicenses.Columns[3].Width = 180;
                dgvLocalLicenses.Columns[4].Width = 180;
                dgvLocalLicenses.Columns[5].Width = 110;
            }
        }
        private void _SetdgvInternationalLicensesDesigned()
        {
            if(dgvInternationalLicenses.Rows.Count>0)
            {
                dgvInternationalLicenses.Columns[0].Width = 130;
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.Lic.ID";
                dgvInternationalLicenses.Columns[1].Width = 130;
                dgvInternationalLicenses.Columns[1].HeaderText = "App.ID";
                dgvInternationalLicenses.Columns[2].Width = 280;
                dgvInternationalLicenses.Columns[2].HeaderText = "Local Lic.ID";
                dgvInternationalLicenses.Columns[3].Width = 180;
                dgvInternationalLicenses.Columns[4].Width = 180;
                dgvInternationalLicenses.Columns[5].Width = 110;
            }
            
        }

        private void _LoadInternationalLicensesHistory()
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicense.
                GetDriverInternationalLicenseHistory(DriverID);
            lblInternationalLicenseRecords.Text = "Records: " + dgvInternationalLicenses.Rows.Count.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tsmShowDrivingLicenseInfo_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frmShowLicenseInfo showLicenseInfo= new frmShowLicenseInfo(LicenseID);
            showLicenseInfo.ShowDialog();
        }

        private void tsmShowInternationalDrivingLicenseInfo_Click(object sender, EventArgs e)
        {
            int inernationalLicenseID = Convert.ToInt32(dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frmShowInternationalLicenseInfo showInternationalLicenseInfo = new frmShowInternationalLicenseInfo(inernationalLicenseID);
            showInternationalLicenseInfo.ShowDialog();
        }
    }
}
