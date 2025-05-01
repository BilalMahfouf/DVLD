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

namespace FrontEnd.Controllers.Application_Controllers
{
    public partial class ApplicationInfo_NewInternationalDLApplicationController : UserControl
    {
        public ApplicationInfo_NewInternationalDLApplicationController()
        {
            InitializeComponent();
        }
        public int LicenseID { get; set; }
        public int InternationalLicenseID { get; set; }
        private void _LoadApplicationInfo()
        {
            lblApplicationDate.Text = clsUIHelper.GetCurrentDate();
            lblIssueDate.Text = clsUIHelper.GetCurrentDate();
            // 6 is the AppTypeID for international Driving license app
            lblApplicationFees.Text = clsApplicationType.GetApplicationFee(6).ToString("F2");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/mm/yyyy");
            lblCreatedBy.Text = clsCurrentUser.UserName;
            if (LicenseID > 0)
            {
                lblLocalLicenseID.Text = LicenseID.ToString();
            }
            if(InternationalLicenseID>0)
            {
                lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
                lblILApplicationID.Text = clsInternationalLicense.Find(InternationalLicenseID).ApplicationID.ToString();
            }

        }
        public void LoadApplicationInfo()
        {
            _LoadApplicationInfo();
        }
        private void ApplicationInfo_NewInternationalDLApplicationController_Load(object sender, EventArgs e)
        {

        }
    }
}
