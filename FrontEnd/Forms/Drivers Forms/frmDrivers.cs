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

namespace FrontEnd.Forms.Drivers_Forms
{
    public partial class frmDrivers : Form
    {
        public frmDrivers()
        {
            InitializeComponent();
        }

        private void LoadDrivers()
        {
            dgvDrivers.DataSource = clsManageDrivers.GetAllDrivers();
            lblRecords.Text="Records: "+dgvDrivers.Rows.Count;
        }

        

        private void _SetdgvDesigned()
        {
            dgvDrivers.Columns[3].Width = 300;
            dgvDrivers.Columns[4].Width = 235;
            dgvDrivers.Columns[5].Width = 200;

        }
        private void frmDrivers_Load(object sender, EventArgs e)
        {
            LoadDrivers();
            _SetdgvDesigned();
        }

        private void tsmShowPersonInfo_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvDrivers.CurrentRow.Cells[1].Value);
            frmPersonInfo personInfo = new frmPersonInfo(PersonID);
            personInfo.ShowDialog();
        }

        private void tsmIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            clsUIHelper.ShowNotImplementedYetMessage();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsUIHelper.ShowNotImplementedYetMessage();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
