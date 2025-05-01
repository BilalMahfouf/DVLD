using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace FrontEnd.Controllers.LicenseControllers
{
    public partial class LicenseInfoController : UserControl
    {
        public LicenseInfoController()
        {
            InitializeComponent();
        }
        public int LicenseID { get; set; }
        private void _LoadDriverLicenseInfo()
        {
            clsLicense License = clsLicense.Find(LicenseID);
            if (License != null)
            {
                lblClass.Text = clsLicenseClasses.GetLicenseClassName(License.LicenseClassID);
                int PersonID=clsManageLocalDrivingApplications.GetPersonIDFromLicenseID(License.LicenseID);
                lblName.Text = clsPerson.GetPersonFullName(PersonID);
                lblLicenseID.Text=License.LicenseID.ToString();
                clsPerson Person = clsPerson.Find(PersonID);
                lblGender.Text = Person.Gender == 0 ? "Male" : "Female";
                lblNantionalNo.Text = Person.NationalNo;
                lblIssueDate.Text=License.IssueDate.ToString("dd/MM/yyyy");
                lblIssueReason.Text = clsApplicationType.GetApplicationTypeName(License.IssueReason);
                if (License.Notes=="")
                {
                    lblNotes.Text = "No Notes";
                }
                else
                {
                    lblNotes.Text = License.Notes;
                }
                lblIsActive.Text = License.IsActive == true ? "Yes" : "No";
                lblDateOfBirth.Text=Person.DateOfBirth.ToString("dd/MM/yyyy");
                lblDriverID.Text = License.DriverID.ToString();
                lblExpirationDate.Text = License.ExpirationDate.ToString("dd/MM/yyyy");
                lblIsDetained.Text = "No";// implement this later
                if(File.Exists(Person.ImagePath))
                {
                    pbPersonPicture.Image = Image.FromFile(Person.ImagePath);
                }
                else
                {
                    if(Person.Gender==0)
                    {
                        pbPersonPicture.Image = Properties.Resources.Male_512;
                    }
                    else
                    {
                        pbPersonPicture.Image = Properties.Resources.Female_512;
                    }
                }
            }
        }
        public void LoadDriverLicenseInfo()
        {
            _LoadDriverLicenseInfo();
        }
        private void LicenseInfoController_Load(object sender, EventArgs e)
        {
            
        }
    }
}
