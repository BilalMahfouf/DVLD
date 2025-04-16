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

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmNewDrivingLicense_Local : Form
    {
        public frmNewDrivingLicense_Local()
        {
            InitializeComponent();
            findUserController1.SendPersonID += frmNewDrivingLicense_SendPersonID;
        }

       
        private void _SetcbLicenseClassesIndex()
        {
            cbLicenseClass.SelectedIndex = 0;
        }

        private void _SetApplicationInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            // 1 is the id of the new Local License
            lblApplicationFees.Text = clsApplicationType.Find(1).ApplicationFee.ToString();
            lblCreatedBy.Text=clsUserInfo.UserName;
        }

        private void frmNewDrivingLicense_Local_Load(object sender, EventArgs e)
        {
            _SetcbLicenseClassesIndex();
            _SetApplicationInfo();
        }

        private void frmNewDrivingLicense_SendPersonID(object sender,int PersonID)
        {
            if(PersonID > 0)
            {
                personInfoController1.PersonID = PersonID;
                personInfoController1.ShowPersonInfo();
                btnNext.Enabled = true;
            }
        }

        private void personInfoController1_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pApplicationInfo.Enabled = true;
            tabControl1.SelectedTab = tabPage2;
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
