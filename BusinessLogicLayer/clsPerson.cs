using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataAccesLayer;


namespace BusinessLogicLayer
{
    public class clsPerson
    {
        public int PersonID { get;private set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public byte Gender {  get; set; }
        public string Address { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; } // to do need validation
        public string ImagePath { get;set; }

        public enum enMode { AddNew , Update};
        public enMode Mode { get; private set; }

       private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address,
            string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gender = 1;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryID = -1;
            this.ImagePath = string.Empty;
            this.Mode = enMode.AddNew;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
             this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address,
            this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return this.PersonID > -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName,
             this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address,
            this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
            
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdatePerson();
                    
                    
            }
            return false;

        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPerson()
        {
            return clsPersonData.GetAllPeople();
        }

        public static clsPerson Find(int PersonID)
        {
            int   NationalityCountryID = 0;
            byte Gendor = 0;
            DateTime DateOfBirth= DateTime.Now;
            string FirstName="", SecondName = "", ThirdName = "", LastName = "", Address = "";
            string Phone = "", Email = "", ImagePath = "", NationalNo = "";

           if(clsPersonData.Find(PersonID, ref NationalNo, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address,
           ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName,
             ThirdName, LastName, DateOfBirth, Gendor, Address,
             Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = 0,  NationalityCountryID = 0;
            DateTime DateOfBirth = DateTime.Now;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "";
            string Phone = "", Email = "", ImagePath = "";
            byte Gendor = 0;

            if (clsPersonData.Find(ref PersonID, NationalNo, ref FirstName, ref SecondName,
             ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address,
            ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName,
             ThirdName, LastName, DateOfBirth, Gendor, Address,
             Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool isExist(int PersonID)
        {
            return clsPersonData.isExist(PersonID);
        }
        public static bool isExist(string NationalNo)
        {
            return clsPersonData.isExist(NationalNo);
        }

        public static DataTable GetAllPeopleWithCountryName()
        {
            return clsPersonData.GetAllPeopleWithCountryName();
        }




    }
}
