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

namespace FrontEnd.Controllers.LicenseControllers
{
    public partial class FindLocalLicenseController : UserControl
    {
        public FindLocalLicenseController()
        {
            InitializeComponent();
        }

        private void mtbLicenseID_TextChanged(object sender, EventArgs e)
        {
            clsUIHelper.SetErrorProvider((Control)sender, errorProvider1);
        }

        public event Action<int> OnFindClick;
        protected virtual void FindClick(int LicenseID)
        {
            Action<int> handler = OnFindClick;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }



        private void btnFind_Click(object sender, EventArgs e)
        {
            clsLicense L = clsLicense.Find(Convert.ToInt32(mtbLicenseID.Text));
            if (L != null)
            {
                licenseInfoController1.LicenseID = L.LicenseID;
                licenseInfoController1.LoadDriverLicenseInfo();
                FindClick(L.LicenseID);
            }
            else
            {
                MessageBox.Show($"LicenseID {mtbLicenseID.Text} Don't Exist", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void internationalLicenseInfoController1_Load(object sender, EventArgs e)
        {

        }

        private void FindLocalLicenseController_Load(object sender, EventArgs e)
        {

        }
    }
}
