using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class clsManageDrivers
    {
        private clsManageDrivers() { }

        public static DataTable GetAllDrivers()
        {
            return clsManageDriversData.GetAllDrivers();
        }
    }
}
