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
using System.IO;

namespace FrontEnd.Controllers
{
    public partial class PersonInfoController : UserControl
    {
        public  int PersonID;
        public PersonInfoController()
        {
            InitializeComponent();
            
        }

        private void _ShowPersonInfo()
        {
            clsPerson Person = clsPerson.Find(PersonID);
            if(Person!=null)
            {
                lblPersonID.Text = Person.PersonID.ToString();
                lblName.Text = Person.FirstName + " " + Person.SecondName
                    + " " + Person.ThirdName + " " + Person.LastName;
                lblNantionalNo.Text = Person.NationalNo.ToString();
                lblPersonID.Text = Person.PersonID.ToString();
                lblEmail.Text = Person.Email.ToString();
                lblAddress.Text = Person.Address.ToString();
                lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                lblPhone.Text = Person.Phone.ToString();
                lblCountry.Text = clsUIHelper.GetCountryName(Person.NationalityCountryID);
                if(Person.Gender==0)
                {
                    lblGender.Text = "Male";
                    pbPersonPicture.Image = Properties.Resources.Male_512;
                }
               else if (Person.Gender == 1)
                {
                    lblGender.Text = "Female";
                    pbPersonPicture.Image = Properties.Resources.Female_512;
                }

                //if (File.Exists(Person.ImagePath))
                //{
                //    pbPersonPicture.Image= Image.FromFile(Person.ImagePath);

                //}
            }
        }
        public void ShowPersonInfo()
        {
            _ShowPersonInfo();
        }

        private void PersonInfoController_Load(object sender, EventArgs e)
        {
            _ShowPersonInfo();
        }

        public event Action OnClicklinklblEditPerson;

        protected virtual void ClicklinklblEditPerson()
        {
            Action handler= OnClicklinklblEditPerson;
            if (handler != null)
            {
                handler();
            }
        }

        private void lbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(OnClicklinklblEditPerson != null)
            {
                ClicklinklblEditPerson();
            }
        }
    }
}
