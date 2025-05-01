using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer
{
    public class clsApplication
    {
        public int ApplicationID { get; private set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }

        private clsApplication(int applicationID, int applicantPersonID
            , DateTime applicationDate, int applicationTypeID, 
            byte applicationStatus, DateTime lastStatusDate, decimal paidFees, 
            int createdByUserID)
        {
           this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.Mode = enMode.Update;
        }
        public clsApplication()
        {
            this.ApplicationID = 0;
            this.ApplicantPersonID = 0;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = 0;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.Mode = enMode.AddNew;
        }

        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationsData
                .AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate
                , this.PaidFees, this.CreatedByUserID);
            return this.ApplicationID > 0;
        }

        private bool _Update()
        {
            return clsApplicationsData.Update(this.ApplicationID, this.ApplicationStatus
                , this.LastStatusDate);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
            
            case enMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                    case enMode.Update:
                    {
                        return _Update();
                    }
            }
            return false;

        }

        public static bool IsExist(int applicantPersonID)
        {
            return clsApplicationsData.isExist(applicantPersonID);
        }

        public static clsApplication FindByPersonID(int ApplicantPersonID)
        {
            int applicationID=0;
            DateTime applicationDate=new DateTime(), lastStatusDate= new DateTime();
            int applicationTypeID=0 ;
            byte applicationStatus=0;
            decimal paidFees=0;
            int createdByUserID=0;
            if(clsApplicationsData.Find(ref applicationID, ApplicantPersonID,
                ref applicationDate,ref applicationTypeID, ref applicationStatus
                ,ref lastStatusDate,ref paidFees,ref createdByUserID))
            {
                return new clsApplication(applicationID, ApplicantPersonID,
                applicationDate, applicationTypeID, applicationStatus
                , lastStatusDate, paidFees, createdByUserID);
            }
            return null;
        }

        public static clsApplication Find(int applicationID)
        {
            int ApplicantPersonID = 0;
            DateTime applicationDate = new DateTime(), lastStatusDate = new DateTime();
            int applicationTypeID = 0;
            byte applicationStatus = 0;
            decimal paidFees = 0;
            int createdByUserID = 0;
            if (clsApplicationsData.Find(applicationID, ref ApplicantPersonID,
                ref applicationDate, ref applicationTypeID, ref applicationStatus
                , ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplication(applicationID, ApplicantPersonID,
                applicationDate, applicationTypeID, applicationStatus
                , lastStatusDate, paidFees, createdByUserID);
            }
            return null;
        }

        public static int GetApplicationIDFromApplicantPersonID(int ApplicantPersonID)
        {
            return FindByPersonID(ApplicantPersonID).ApplicationID;
        }

        public static bool CancelApplication(int ApplicationID)
        {
           clsApplication Application = Find(ApplicationID);
            if (Application != null)
            {
                Application.ApplicationStatus = 2;
                return Application.Save();
            }
            return false;
        }

        public static string GetStatusName(byte ApplicationStatus)
        {
                switch (ApplicationStatus)
                {
                        case 1:
                        return "New";
                        case 2:
                        return "Cancelled";
                        case 3:
                        return "Completed";
                }
                return string.Empty;          
        }

        public static int AddNewRetakeTestApplication(int ApplicantPersonID, DateTime
             ApplicationDate, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,
             int CreatedByUserID)
        {
            clsApplication newRetakeTestApplication = new clsApplication();
            newRetakeTestApplication.ApplicantPersonID = ApplicantPersonID;
            newRetakeTestApplication.ApplicationDate = ApplicationDate;
            newRetakeTestApplication.ApplicationStatus = ApplicationStatus;
            newRetakeTestApplication.LastStatusDate = LastStatusDate;
            newRetakeTestApplication.PaidFees = PaidFees;
            newRetakeTestApplication.CreatedByUserID = CreatedByUserID;
            // 7 is the ApplicationTypeID for Retaketestapp
            newRetakeTestApplication.ApplicationTypeID = 7;
            if (newRetakeTestApplication.Save())
            {
                return newRetakeTestApplication.ApplicationID;
            }
            return 0;
        }

        public static bool CompleteApplication(int ApplicationID)
        {
            // 3 is application status completed
            return clsApplicationsData.Update(ApplicationID, 3, DateTime.Now);
        }

        public static int AddNewInternationalLicenseApplication(int ApplicantPersonID,
            DateTime ApplicationDate, byte ApplicationStatus, DateTime LastStatusDate,
             int CreatedByUserID)
        {
            // 6 is the ApplicationTypeID for International License
            int ApplicationType = 6;
            clsApplication newInternationalLicenseApplication = new clsApplication();
            newInternationalLicenseApplication.ApplicantPersonID = ApplicantPersonID;
            newInternationalLicenseApplication.ApplicationDate = ApplicationDate;
            newInternationalLicenseApplication.ApplicationStatus = ApplicationStatus;
            newInternationalLicenseApplication.LastStatusDate = LastStatusDate;
            newInternationalLicenseApplication.PaidFees = clsApplicationType.GetApplicationFee(ApplicationType);
            newInternationalLicenseApplication.CreatedByUserID = CreatedByUserID;

            newInternationalLicenseApplication.ApplicationTypeID = ApplicationType;
            if (newInternationalLicenseApplication.Save())
            {
                return newInternationalLicenseApplication.ApplicationID;
            }
            return 0;
        }   


    }
}
