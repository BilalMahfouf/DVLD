using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer
{
    public  class clsLicense 
    {
        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enMode { AddNew,Update}
        public enMode Mode { get; private set; }

        private clsLicense(int licenseID, int applicationID, int driverID, 
            int licenseClassID, DateTime issueDate, DateTime expirationDate, 
            string notes, decimal paidFees, bool isActive, byte issueReason, 
            int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            this.Mode = enMode.Update;
        }

        clsLicense()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClassID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = 0;
            this.Mode = enMode.AddNew;
        }

        private bool _AddNew()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID, this.DriverID,
                this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.PaidFees
                , this.IsActive, this.IssueReason, this.CreatedByUserID, this.Notes);
            if(this.LicenseID>0)
            {
                return true;
            }
            return false;
        }

        private bool _Update()
        {
            return clsLicensesData.Update(this.LicenseID, this.IsActive);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.Update:
                    {
                        return _Update();
                    }
                case enMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            this.Mode=enMode.Update;
                            return true;
                        }
                        return false;
                    }
            }
            return false ;

        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = 0, LicenseClassID = 0, DriverID = 0;
             DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
             bool IsActive =false;
            byte IssueReason = 0;
            int CreatedByUserID = 0;
            if(clsLicensesData.Find(LicenseID,ref ApplicationID,ref DriverID,ref 
                LicenseClassID,ref IssueDate,ref ExpirationDate,ref PaidFees,ref 
                IsActive,ref IssueReason,ref CreatedByUserID,ref Notes))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate
                    , ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID); ;
            }
            return null;
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = 0, LicenseClassID = 0, DriverID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = 0;
            if (clsLicensesData.FindByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref
                LicenseClassID, ref IssueDate, ref ExpirationDate, ref PaidFees, ref
                IsActive, ref IssueReason, ref CreatedByUserID, ref Notes))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate
                    , ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID); ;
            }
            return null;
        }

        public static bool IsExistByApplicationIDAndLicenseClassID(int ApplicationID,int LicenseClassID)
        {
            return clsLicensesData.IsExistByApplicationIDAndLicenseClassID 
                (ApplicationID, LicenseClassID);
        }
        public static DataTable GetDriverAllLicenses(int DriverID)
        {
            return clsLicensesData.GetDriverAllLicenses (DriverID);
        }

        public static int AddNewLicense(int applicationID, int driverID,
            int licenseClassID, DateTime issueDate, DateTime expirationDate,
            string notes, decimal paidFees, bool isActive, byte issueReason,
            int createdByUserID)
        {
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = applicationID;
            NewLicense.DriverID = driverID;
            NewLicense.LicenseClassID = licenseClassID;
            NewLicense.IssueDate = issueDate;
            NewLicense.ExpirationDate = expirationDate;
            NewLicense.Notes = notes;
            NewLicense.PaidFees = paidFees;
            NewLicense.IsActive = isActive;
            NewLicense.IssueReason = issueReason;
            NewLicense.CreatedByUserID = createdByUserID;
            if(NewLicense.Save())
            {
                clsApplication.CompleteApplication(NewLicense.ApplicationID);
                return NewLicense.LicenseID;
            }
            return 0;
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return clsLicense.FindByApplicationID(ApplicationID).LicenseID;
        }

        public static DataTable GetDriverLicenseHistory(int DriverID)
        {
            return clsLicensesData.GetDriverLicenseHistory(DriverID);
        }

        public static bool IsLicenseExpired(int LicenseID)
        {
            var License= Find(LicenseID);
            if (License!=null)
            {
                return License.ExpirationDate <= DateTime.Now;
            }
            return false;
        }

        public static bool isActive(int LicenseID)
        {
            var License = Find(LicenseID);
            if (License != null)
            {
                return License.IsActive;
            }
            return false;
        }

        public static bool DesactivateLicense(int LicenseID)
        {
            var License = Find(LicenseID);
            if (License != null)
            {
                License.IsActive = false;
                return License.Save();
            }
            return false;
        }

    }
}
