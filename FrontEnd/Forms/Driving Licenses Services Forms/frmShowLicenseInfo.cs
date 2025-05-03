using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms.TestTypes_Forms
{
    public partial class frmShowLicenseInfo : Form
    {
        public frmShowLicenseInfo(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }
        private int _LicenseID;
        private void _LoadDriverInfo()
        {
            licenseInfoController1.LicenseID = _LicenseID;
            licenseInfoController1.LoadDriverLicenseInfo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadDriverInfo();
        }
    }
}
