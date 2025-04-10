using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class clsTestType
    {
        public int TestTypeID {  get; private set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees {  get; set; }

        private clsTestType(int testTypeID, string testTypeTitle, string testTypeDescription
            , decimal testTypeFees )
        {
            this.TestTypeID = testTypeID;
            this.TestTypeTitle = testTypeTitle;
            this.TestTypeDescription = testTypeDescription;
            this.TestTypeFees = testTypeFees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestType Find(int TestTypeID)
        {
            string testTypeTitle=string.Empty;
            string testTypeDescription = string.Empty;
            decimal testTypeFees = 0;
            if(clsTestTypesData.Find(TestTypeID,ref testTypeTitle,ref testTypeDescription
                ,ref testTypeFees))
            {
                return new clsTestType(TestTypeID, testTypeTitle, testTypeDescription, testTypeFees);
            }
            return null;

        }

        private bool _Update()
        {
            return clsTestTypesData.Update(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription
                , this.TestTypeFees);
        }

        public bool Save()
        {
            return _Update();
        }

    }
}
