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

        clsTest()
        {
            TestID=0; TestAppointmentID=0;
            TestResult=false;
            Notes=string.Empty;
            CreatedByUserID = 0;
        }

        private bool _AddNew()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult,
                this.Notes, this.CreatedByUserID);
            return this.TestID > 0;
        }

        public bool Save()
        {
            return _AddNew();
        }

    }
}
