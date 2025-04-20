using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public  class clsManageLocalDrivingApplications
    {
        private clsManageLocalDrivingApplications()
        {

        }
        public static DataTable GetAllLocalDrivingApplications()
        {
            return clsManageLocalDrivingApplicationsData.GetAllLocalDrivingApplications();
        }

        public static int GetApplicationIDFromLDLApplicationID(int LDLApplicationID)
        {
            return clsLocalDrivingLicenseApplication.
                Find(LDLApplicationID).ApplicationID; ;
        }

        public static int GetApplicantPersonIDFromLDLApplicationID(int LDLApplicationID)
        {
            int ApplicationID = GetApplicationIDFromLDLApplicationID(LDLApplicationID);

            return clsApplication.Find(ApplicationID).ApplicantPersonID;
        }

       
        public static DateTime GetApplicationDateFromLDLApplicationID(int LDLApplicationID)
        {
            int ApplicationID = GetApplicationIDFromLDLApplicationID(LDLApplicationID);
            return clsApplication.Find(ApplicationID).ApplicationDate;
        }

        public static  decimal GetApplicationFeesFromLDLApplicationID(int LDLApplicationID)
        {
            int ApplicationID = GetApplicationIDFromLDLApplicationID(LDLApplicationID);
            return clsApplication.Find(ApplicationID).PaidFees;
        }

        public static string GetCreatedByUserFromLDLApplicationID(int LDLApplicationID)
        {
            int ApplicationID = GetApplicationIDFromLDLApplicationID(LDLApplicationID);
            int UserID = clsApplication.Find(ApplicationID).CreatedByUserID;
            return clsUser.Find(UserID).UserName;
        }

        public static string GetLicenseClassNameFromLDLApplicationID(int LDLApplicationID)
        {
            int LicenseClassID= clsLocalDrivingLicenseApplication.
                Find(LDLApplicationID).LicenseClassID;
            return clsLicenseClasses.Find(LicenseClassID).ClassName;
        }

        public static string GetLicenseClassNameFromApplicationID(int applicationID)
        {
            return GetLicenseClassNameFromLDLApplicationID(
                clsLocalDrivingLicenseApplication.FindByApplicationID(applicationID).
                LocalDrivingLicenseApplicationID);
        }
    
        public static int CanAddNewLocalDrivingLicenseApplication(
            int ApplicantPersonID, int LicenseClassID)
        {
            int ApplicationID = 0;
            clsManageLocalDrivingApplicationsData
            .CanAddNewLocalDrivingLicenseApplication(ApplicantPersonID, LicenseClassID
            , ref ApplicationID);
            return ApplicationID;


        }

        public static int GetLDLApplicationIDFromApplicantPersonID(int ApplicantPersonID)
        {
            int applicationID=clsApplication.FindByPersonID(ApplicantPersonID).ApplicationID;
            return clsLocalDrivingLicenseApplication.FindByApplicationID
                (applicationID).LocalDrivingLicenseApplicationID;
        }

        public static bool CancelApplication(int LDLApplicationID)
        {
            int applicationID = GetApplicationIDFromLDLApplicationID(LDLApplicationID);
            return clsApplication.CancelApplication(applicationID);
        }

    }
}
