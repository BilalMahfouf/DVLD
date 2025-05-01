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
using System.IO;

namespace FrontEnd.Controllers.LicenseControllers
{
    public partial class InternationalLicenseInfoController : UserControl
    {
        public InternationalLicenseInfoController()
        {
            InitializeComponent();
        }

        public int InternationalLicenseID { get; set; }

        private void _LoadInfo()
        {
            clsInternationalLicense ILicense = clsInternationalLicense.Find(InternationalLicenseID);

            if (ILicense != null)
            {
                int PersonID = clsDriver.Find(ILicense.DriverID).PersonID;
                lblName.Text = clsPerson.GetPersonFullName(PersonID);
                clsPerson person = clsPerson.Find(PersonID);
                lblNantionalNo.Text = person.NationalNo;
                lblGender.Text = person.Gender == 0 ? "Male" : "Female";
                lblDateOfBirth.Text = person.DateOfBirth.ToString("dd/MM/yyyy");
                lblInternationalLicenseID.Text = ILicense.InternationalLicenseID.ToString();
                lblLicenseID.Text = ILicense.LocalLicenseID.ToString();
                lblIssueDate.Text = ILicense.IssueDate.ToString("dd/MM/yyyy");
                lblApplicationID.Text = ILicense.ApplicationID.ToString();
                lblIsActive.Text = ILicense.IsActive ? "Yes" : "No";
                lblDriverID.Text = ILicense.DriverID.ToString();
                lblExpirationDate.Text = ILicense.ExpirationDate.ToString("dd/MM/yyyy");
                if (File.Exists(person.ImagePath))
                {
                    pbPersonPicture.Image = Image.FromFile(person.ImagePath);
                }
                else
                {
                    if (person.Gender == 0)
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
        public void LoadInfo()
        {
            _LoadInfo();
        }

        private void InternationalLicenseInfoController_Load(object sender, EventArgs e)
        {

        }
    }
}
