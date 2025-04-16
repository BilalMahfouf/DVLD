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

        //ref int LicenseClassID, string ClassName, ref string ClassDescription
        //    , ref byte MinimumAllowedAge, ref byte DefaultValidityLength,
        //    ref decimal ClassMoney

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

        public static clsLicenseClasses

    }
}
