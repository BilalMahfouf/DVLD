using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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
            }
            return false;

        }

        public static bool IsExist(int applicantPersonID)
        {
            return clsApplicationsData.isExist(applicantPersonID);
        }

    }
}
