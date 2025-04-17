using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }
        private clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID
            , int applicationID, int licenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.ApplicationID = applicationID;
            this.LicenseClassID = licenseClassID;
            this.Mode = enMode.Update;
        }
        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = 0;
            this.ApplicationID = 0;
            this.LicenseClassID = 0;
            this.Mode = enMode.AddNew;
        }


        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationsData.AddNewLDLA(this.ApplicationID, this.LicenseClassID);
            return this.LocalDrivingLicenseApplicationID > 0;
        }

        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationsData.Update(
                this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
        }

        public bool Save()
        {
            switch(this.Mode)
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

        public static bool IsExist(int ApplicationID, int licenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsData.isExist(ApplicationID, licenseClassID);
        }

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID=0, licenseClassID=0;
            if(clsLocalDrivingLicenseApplicationsData.Find(LocalDrivingLicenseApplicationID,
                ref ApplicationID,ref licenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID,
                    ApplicationID, licenseClassID);
            }
            return null;
        }


    }
}
