using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public  class clsTestAppointment
    {
        public int TestAppointmentID { get; private set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public enum enMode { AddNew,Update}
        public enMode Mode { get; private set; }

        private clsTestAppointment(int testAppointmentID, int testTypeID, 
            int localDrivingLicenseApplicationID, DateTime appointmentDate, 
            decimal paidFees,int CreatedByUserID, bool isLocked, int retakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;
            this.Mode = enMode.Update;
        }


        private bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(
                this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
            return this.TestAppointmentID > 0;
        }

        private bool _Update()
        {
            return clsTestAppointmentData.Update(this.TestAppointmentID
                , this.AppointmentDate);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            this.Mode= enMode.Update;
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

        public static bool CantAddNewTestAppointment(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentData.CantAddNewTestAppointment
                (LocalDrivingLicenseApplicationID);
        }
    
        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int testTypeID = 0, localDrivingLicenseApplicationID = 0;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = 0;
            int CreatedByUserID = 0, retakeTestApplicationID = 0;
            bool isLocked = false;
            if(clsTestAppointmentData.Find(TestAppointmentID,ref testTypeID,ref 
                localDrivingLicenseApplicationID,ref appointmentDate,ref paidFees,
                ref CreatedByUserID,ref isLocked,ref retakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, testTypeID, localDrivingLicenseApplicationID,
                appointmentDate, paidFees, CreatedByUserID, isLocked, retakeTestApplicationID);
            }
            return null;
        }

        //public static int GetTestTypeIDFromLDLAppID()

        public static int GetTestTrial(int LocalDrivingLicenseApplicationID,
            int TestType)
        {
            return clsTestAppointmentData.GetTestTrial(LocalDrivingLicenseApplicationID,
                TestType);
        }
    
    }


}
