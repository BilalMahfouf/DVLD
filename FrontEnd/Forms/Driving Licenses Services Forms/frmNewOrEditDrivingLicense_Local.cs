using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using FrontEnd.Classes;
using FrontEnd.Controllers;
using static System.Net.Mime.MediaTypeNames;

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmNewOrEditDrivingLicense_Local : Form
    {
        public frmNewOrEditDrivingLicense_Local(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            findUserController1.SendPersonID += frmNewDrivingLicense_SendPersonID;
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
        }


        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID;
        private enum enMode { AddNew,Update};
        enMode _Mode;
        private void _LoadApplicationInfo()
        {
            _LocalDrivingLicenseApplication =
            clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            lblMode.Text = "Update Local Driving License ";
            personInfoController1.PersonID = clsManageLocalDrivingApplications.
                GetApplicantPersonIDFromLDLApplicationID(_LocalDrivingLicenseApplicationID);
            personInfoController1.ShowPersonInfo();

            lblDLApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsManageLocalDrivingApplications.
                GetApplicationDateFromLDLApplicationID(_LocalDrivingLicenseApplicationID).ToString();
            lblApplicationFees.Text = clsManageLocalDrivingApplications.
                GetApplicationFeesFromLDLApplicationID(_LocalDrivingLicenseApplicationID).ToString();
            lblCreatedBy.Text = clsManageLocalDrivingApplications.
                GetCreatedByUserFromLDLApplicationID(_LocalDrivingLicenseApplicationID);
            cbLicenseClass.Text = clsManageLocalDrivingApplications
                .GetLicenseClassNameFromLDLApplicationID(_LocalDrivingLicenseApplicationID);


            _Mode = enMode.Update;
        }
        private void _SetMode()
        {
            if (_LocalDrivingLicenseApplicationID > 0)
            {
                _LoadApplicationInfo();
                findUserController1.Enabled = false;
                pApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                btnNext.Enabled = true;
            }
            else
            {
                _LocalDrivingLicenseApplication = null;
                lblMode.Text = "New Local Driving License";
                _Mode = enMode.AddNew;
                findUserController1.Enabled = true;
            }
        }

        private void _SetcbLicenseClassesIndex()
        {
            cbLicenseClass.SelectedIndex = 2;
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
            _SetMode();
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

        private bool _AddNewApplication(clsApplication Application)
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

        private bool _AddNew()
        {
            int LicenseClassID = clsLicenseClasses.GetLicenseClassID(cbLicenseClass.Text);
            int ApplicantPersonID = personInfoController1.PersonID;
            int ApplicationID = clsManageLocalDrivingApplications.
                CanAddNewLocalDrivingLicenseApplication(ApplicantPersonID,
                LicenseClassID);
            if (ApplicationID>0)
            {
                
                
                    MessageBox.Show(
            $@"Choose another License Class, the selected Person Already
            have an active application for the selected class with id=
            {ApplicationID}",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
                    return false;
            }
            else
            {
               clsApplication Application = new clsApplication();
                if (_AddNewApplication(Application))
                {
                    clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
                        = new clsLocalDrivingLicenseApplication();
                    LocalDrivingLicenseApplication.ApplicationID = Application.ApplicationID;
                    LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
                    return LocalDrivingLicenseApplication.Save();

                }
            }

            return false;
        }

        private bool _UpdateApplication()
        {
            int applicationID= _LocalDrivingLicenseApplication.ApplicationID;
            clsApplication Application= clsApplication.Find(applicationID);
            if (Application != null)
            {
                Application.LastStatusDate = DateTime.Now;
                return Application.Save();
            }
            return false;
        }
        private bool _Update()
        {
            int ApplicantPersonID = personInfoController1.PersonID;
            int LicenseClassID = clsLicenseClasses.GetLicenseClassID(cbLicenseClass.Text);
            int ApplicationID = clsManageLocalDrivingApplications.
                CanAddNewLocalDrivingLicenseApplication(ApplicantPersonID, LicenseClassID);
            if (ApplicationID>0)
            {
                return false;
            }
            else
            {
                if (_UpdateApplication())
                {
                    _LocalDrivingLicenseApplication.LicenseClassID =
                    clsLicenseClasses.GetLicenseClassID(cbLicenseClass.Text);
                    return _LocalDrivingLicenseApplication.Save();
                }
            }
            
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode = enMode.Update;
                            MessageBox.Show("Data saved successfully", "", MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                        }
                        break;
                    }
                case enMode.Update:
                    {
                      if(_Update())
                        {
                            MessageBox.Show("Data saved successfully", "", MessageBoxButtons.OK
                                 , MessageBoxIcon.Information);
                        }
                      else
                        {
                            MessageBox.Show(@"Cant't perform this operation","Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
                        }
                            break;
                    }
               

            }

            _SetMode();

            }

            
        }

        
    }

