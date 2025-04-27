using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class clsLicenseClasses
    {

        
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassMoney { get; set; }
        private clsLicenseClasses(int LicenseClassID,string ClassName, string ClassDescription ,
            byte MinimumAllowedAge, byte DefaultValidityLength ,decimal ClassMoney)

        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassMoney = ClassMoney;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        public static clsLicenseClasses Find(string ClassName)
        {
            int LicenseClassID = 0;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassMoney = 0;
            if(clsLicenseClassesData.Find(ref LicenseClassID,ClassName, ref ClassDescription
                , ref MinimumAllowedAge,ref DefaultValidityLength, ref ClassMoney))
            {
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription
                    , MinimumAllowedAge, DefaultValidityLength, ClassMoney);
            }
            return null;
    }

        public static clsLicenseClasses Find(int ClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassMoney = 0;
            if (clsLicenseClassesData.Find( ClassID, ref ClassName, ref ClassDescription
                , ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassMoney))
            {
                return new clsLicenseClasses(ClassID, ClassName, ClassDescription
                    , MinimumAllowedAge, DefaultValidityLength, ClassMoney);
            }
            return null;
        }

        public static int GetLicenseClassID(string ClassName)
        {
            return Find(ClassName).LicenseClassID;
        }

        public static string GetLicenseClassName(int licenseClassID)
        {
            return clsLicenseClasses.Find(licenseClassID).ClassName;
        }

        public static decimal GetLicenseClassFees(int LicenseClassID)
        {
            return clsLicenseClasses.Find(LicenseClassID).ClassMoney;
        }

        

    }
}
