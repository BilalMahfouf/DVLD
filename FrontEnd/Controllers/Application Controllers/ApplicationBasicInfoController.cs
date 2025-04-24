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
using FrontEnd.Forms;

namespace FrontEnd.Controllers.Application_Controllers
{
    public partial class ApplicationBasicInfoController : UserControl
    {
        public ApplicationBasicInfoController()
        {
            InitializeComponent();
        }
        public int ApplicationID { get; set; }
        private void ApplicationBasicInfoController_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }
        private void _LoadApplicationInfo()
        {
            clsApplication Application = clsApplication.Find(ApplicationID);
            if (Application != null)
            {
                lblApplicationID.Text=Application.ApplicationID.ToString();
                lblApplicationStatus.Text = clsApplication.GetStatusName(Application.ApplicationStatus);
                lblApplicationFees.Text=Application.PaidFees.ToString();
                lblApplicationType.Text = clsApplicationType.GetApplicationTypeName
                    (Application.ApplicationTypeID);
                lblApplicantFullName.Text = clsPerson.GetPersonFullName
                    (Application.ApplicantPersonID);
                lblDate.Text = Application.ApplicationDate.ToString();
                lblStatusDate.Text = Application.LastStatusDate.ToString();
                lblCreatedBy.Text= clsUser.GetUserName(Application.CreatedByUserID);
            }
        }

        public void LoadApplicationInfo()
        {
            _LoadApplicationInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linklblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = clsApplication.Find(ApplicationID).ApplicantPersonID;
            frmPersonInfo personInfo = new frmPersonInfo(PersonID);
            personInfo.ShowDialog();
        }
    }
}
