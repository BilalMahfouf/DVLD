using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public  class clsManageLocalDrivingApplications
    {
        private clsManageLocalDrivingApplications()
        {

        }
        public static DataTable GetAllLocalDrivingApplications()
        {
            return clsManageLocalDrivingApplicationsData.GetAllLocalDrivingApplications();
        }
    }
}
