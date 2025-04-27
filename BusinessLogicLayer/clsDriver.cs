using System;
using System.Data;
using System.Security.Principal;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public  class clsDriver
    {
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public enum enMode { AddNew,Update};
        public enMode Mode { get; private set; }

       private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Mode = enMode.Update;
        }
        public clsDriver()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew ;
        }

        private bool _AddNew()
        {
            this.DriverID = clsDriversData.AddNewDriver(this.PersonID,this.CreatedByUserID,
                this.CreatedDate);
            return this.DriverID > 0;
        }
        private bool _Update()
        {
            // not implemented yet 
            return false;
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
                        return false;
                    }
                    case enMode.Update:
                    return _Update();
            }
            return false;

        }

        public static clsDriver Find(int DriverID)
        {
            int PersonID=0, CreatedByUserID = 0;
            DateTime CreatedDate = DateTime.Now;
            if(clsDriversData.Find(DriverID,ref PersonID,ref CreatedByUserID,
                ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }

       public static bool IsExist(int PersonID)
        {
            return clsDriversData.IsExist(PersonID);
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = 0, CreatedByUserID = 0;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriversData.FindByPersonID(ref DriverID, PersonID, ref CreatedByUserID,
                ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return FindByPersonID(PersonID).DriverID;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }

        public static int AddNewDriver(int PersonID,int CreatedByUserID, DateTime 
            CreatedDate)
        {
            clsDriver NewDriver=new clsDriver();
            NewDriver.PersonID= PersonID;
            NewDriver.CreatedByUserID= CreatedByUserID;
            NewDriver.CreatedDate= CreatedDate;
            if(NewDriver.Save())
            {
                return NewDriver.DriverID;
            }
            return 0;
        }


    }
}
