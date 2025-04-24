using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

        public clsTestAppointment()
        {
            this.TestAppointmentID = 0;
            this.TestTypeID = 0;
            this.LocalDrivingLicenseApplicationID = 0;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = 0;
            this.IsLocked = false;
            this.RetakeTestApplicationID = 0;
            this.Mode = enMode.AddNew;
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
                , this.AppointmentDate, this.IsLocked);
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

        public static int GetTestTrial(int LocalDrivingLicenseApplicationID,
            int TestType)
        {
            return clsTestAppointmentData.GetTestTrial(LocalDrivingLicenseApplicationID,
                TestType);
        }

        public static int AddNewAppointment(int LDLAppID,int TestTypeID,DateTime AppointmentDate,
            decimal PaidFees,int CreatedByUserID, bool IsLocked,
            int RetakeTestApplicationID=0)
        {
           clsTestAppointment newTestAppointment= new clsTestAppointment();
            newTestAppointment.LocalDrivingLicenseApplicationID = LDLAppID;
            newTestAppointment.TestTypeID = TestTypeID;
            newTestAppointment.AppointmentDate = AppointmentDate;
            newTestAppointment.PaidFees = PaidFees;
            newTestAppointment.CreatedByUserID = CreatedByUserID;
            newTestAppointment.IsLocked = IsLocked;
            newTestAppointment.RetakeTestApplicationID = RetakeTestApplicationID;
            if( newTestAppointment.Save())
            {
                return newTestAppointment.TestAppointmentID;
            }
            return 0;
        }

        public static DataTable GetAllTestAppointment(int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            return clsTestAppointmentData.GetAllTestAppointment(LocalDrivingLicenseApplicationID
                , TestTypeID);
        }

        public static bool UpdateAppointment(int TestAppointmentID,DateTime AppointmentDate)
        {
            clsTestAppointment Test = Find(TestAppointmentID);
            if(Test != null)
            {
                Test.AppointmentDate = AppointmentDate;
                return Test.Save();
            }
            return false;
        }

    }


}
