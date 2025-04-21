using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class clsUser
    {
        public int UserID { get; private set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public enum enMode {AddNew,Update}
        public enMode Mode { get; private set; }

        private clsUser (int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.Mode=enMode.Update;

        }
        public clsUser()
        {
            this.UserID = 0;
            this.PersonID = 0;
            this.UserName = null;
            this.Password = null;
            this.IsActive = false;
            this.Mode = enMode.AddNew;
        }

        public static clsUser Find(int UserID)
        {
            string UserName=string .Empty, Password=string .Empty;
            int PersonID = 0;
            bool IsActive = false;
            if(clsUsersData.Find(UserID, ref PersonID,ref UserName,ref Password,ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
            
        }
        public static clsUser Find(string UserName,string Password)

        {

            int PersonID = 0, UserID = 0;
            bool IsActive = false;
            if (clsUsersData.Find(ref UserID, ref PersonID, UserName, Password, ref IsActive)) 
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;

        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
        
        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return this.UserID > 0;
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password
                , this.IsActive);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                    case enMode.Update:
                    {
                        return _UpdateUser();
                    }
            }
            return false;

        }

        public static DataTable GetAllUsersWithFullName()
        {
            return clsUsersData.GetAllUsersWithFullName();
        }

        public static bool IsExist(int PersonID)
        {
            return clsUsersData.IsExist(PersonID);
        }

        public static  string GetUserName(int UserID)
        {
            return clsUser.Find(UserID).UserName;
        }
    }
}
