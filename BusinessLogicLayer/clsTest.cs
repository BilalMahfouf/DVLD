using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public  class clsTest
    {
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enMode { AddNew,Update};
        public enMode Mode { get; set; }

        clsTest()
        {
            TestID=0; TestAppointmentID=0;
            TestResult=false;
            Notes=string.Empty;
            CreatedByUserID = 0;
            Mode = enMode.AddNew;
        }
        clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult,
                this.Notes, this.CreatedByUserID);
            return this.TestID > 0;
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        // at this stage we don't need update the test 
                        break;
                    }

            }
            return false;

        }
        public static int AddNewTest(int TestAppointment,bool TestResult,
            int CreatedByUserID, string Notes = "")
        {
            clsTest NewTest= new clsTest();
            NewTest.TestAppointmentID = TestAppointment;
            NewTest.TestResult = TestResult;
            NewTest.Notes = Notes;
            NewTest.CreatedByUserID = CreatedByUserID;
            if(NewTest.Save())
            {
                return NewTest.TestID;
            }
            return 0;
        }

        public static bool IsPassedTest(int TestAppointmentID)
        {
            return clsTestsData.IsPassedTest(TestAppointmentID);
        }

        public static clsTest Find(int TestAppointmentID)
        {
            int TestID = 0, CreatedByUserID = 0;
            string Notes = "";
            bool testResult=false;
            if (clsTestsData.Find(ref TestID, TestAppointmentID, ref testResult
                , ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID, TestAppointmentID, testResult, Notes, CreatedByUserID);
            }
            return null;

        }
        public static int GetTestID(int TestAppointmentID)
        {
            clsTest Test = Find(TestAppointmentID);
            if(Test!=null)
            {
                return Test.TestID;
            }
            return 0;
        }


    }
}
