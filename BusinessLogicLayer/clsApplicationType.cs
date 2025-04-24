using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; private set; }
        public string ApplicationTitle { get;  set; }
        public decimal ApplicationFee { get; set; }

        private clsApplicationType(int applicationTypeID, string applicationTitle
            , decimal applicationFee)
        {
           this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTitle = applicationTitle;
            this.ApplicationFee = applicationFee;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        private bool _Update()
        {
            return clsApplicationTypesData.Update(this.ApplicationTypeID, this.ApplicationTitle
                , this.ApplicationFee);
        }

        public bool Save()
        {
            return _Update();
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle=string.Empty;
            decimal ApplicationFee = 0;
            if(clsApplicationTypesData.Find(ApplicationTypeID,ref ApplicationTypeTitle
                ,ref ApplicationFee))
            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFee);
            }
            return null;
        }

        public static clsApplicationType Find(string ApplicationTypeTitle)
        {
            int ApplicationTypeID = 0;
            decimal ApplicationFee = 0;
            if (clsApplicationTypesData.Find(ref ApplicationTypeID,  ApplicationTypeTitle
                , ref ApplicationFee))
            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFee);
            }
            return null;
        }

        public static string GetApplicationTypeName(int ApplicationTypeID)
        {
            return clsApplicationType.Find(ApplicationTypeID).ApplicationTitle;
        }

        public static decimal GetApplicationFee(int ApplicationTypeID)
        {
            return Find(ApplicationTypeID).ApplicationFee;
        }



    }
}
