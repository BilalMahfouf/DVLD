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
            lblCreatedBy.Text=clsCurrentUser.UserName;
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

        private bool _SaveApplication(clsApplication Application)
        {
            Application.ApplicantPersonID = personInfoController1.PersonID;
            Application.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            Application.ApplicationTypeID = 1;// 1 stand for new driving License
            Application.ApplicationStatus = 1;// one stand fot new
            Application.LastStatusDate = Convert.ToDateTime(lblApplicationDate.Text);
            Application.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            Application.CreatedByUserID = clsCurrentUser.UserID;
            return Application.Save();
        }

        private bool _Save()
        {
            if(clsApplication.IsExist(personInfoController1.PersonID))
            {
                MessageBox.Show(
            $@"Choose another License Class, the selected Person Already
            have an active application for the selected class with id={clsApplication.Find(personInfoController1.PersonID).ApplicationID}",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
                return false;
                
            }
            else
            {
                clsApplication Application = new clsApplication();
                if (_SaveApplication(Application))
                {
                    clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
                        = new clsLocalDrivingLicenseApplication();
                    LocalDrivingLicenseApplication.ApplicationID = Application.ApplicationID;
                    int LicenseClassID = clsLicenseClasses.Find(cbLicenseClass.Text).LicenseClassID;
                    LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
                    return LocalDrivingLicenseApplication.Save();

                }
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Save())
            {
                MessageBox.Show("Data saved successfully", "", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
        }
    }
}
