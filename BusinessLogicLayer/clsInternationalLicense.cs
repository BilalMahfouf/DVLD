using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsInternationalLicense(int internationalLicenseID, int applicationID,
             int driverID, int localLicenseID, DateTime issueDate,
             DateTime expirationDate, bool IsActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LocalLicenseID = localLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            this.IsActive = IsActive;
            CreatedByUserID = createdByUserID;
            _Mode = enMode.Update;
        }
        public clsInternationalLicense()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LocalLicenseID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            CreatedByUserID = 0;
            _Mode = enMode.AddNew;
        }

        public static DataTable GetAllLicenses()
        {
            return clsInternationalLicensesData.GetAllLicenses();
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int applicationID = 0, createdByUserID = 0, driverID = 0, localLicenseID = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;
            if (clsInternationalLicensesData.Find(InternationalLicenseID,
                ref applicationID, ref driverID, ref localLicenseID, ref issueDate,
                ref expirationDate, ref isActive, ref createdByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, applicationID
           , driverID, localLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            return null;
        }

        public static DataTable GetDriverInternationalLicenseHistory(int DriverID)
        {
            return clsInternationalLicensesData.GetInternationalLicenseDriverHistory(DriverID);
        }

        public static bool CanAddNewInternationalLicense(int LicenseID)
        {
            return clsInternationalLicensesData.CanAddNewInternationalLicense(LicenseID);
        }

        public static int IsExistByLocalLicenseID(int LocalLicenseID)
        {
            return clsInternationalLicensesData.IsExistByLocalLicenseID(LocalLicenseID);
        }

        private bool _AddNew()
        {
            this.InternationalLicenseID = clsInternationalLicensesData.AddNewInternationalLicense(this.ApplicationID, this.DriverID,
              this.LocalLicenseID, this.IssueDate, DateTime.Now.AddYears(1),
              this.CreatedByUserID);
            return this.InternationalLicenseID > 0;
        }
        private bool _Update()
        {
            return false;
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        

        public static int AddNewInternationalLicense(int ApplicationID,int DriverID,int LocalLicenseID
            , DateTime IssueDate,DateTime ExpirationDate,int CreatedByUserID)
        {
            clsInternationalLicense NewInternationalLicense = new clsInternationalLicense();
            NewInternationalLicense.ApplicationID = ApplicationID;
            NewInternationalLicense.DriverID = DriverID;
            NewInternationalLicense.LocalLicenseID = LocalLicenseID;
            NewInternationalLicense.IssueDate = IssueDate;
            NewInternationalLicense.ExpirationDate = ExpirationDate;
            NewInternationalLicense.CreatedByUserID = CreatedByUserID;
            if (NewInternationalLicense.Save())
            {
                return NewInternationalLicense.InternationalLicenseID;
            }
            else
            {
                return 0;
            }
        }
    }
}