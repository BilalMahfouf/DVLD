using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class clsCountries
    {

        public int CountryID { get; private set; }
        public string CountryName { get;  set; }

        private clsCountries(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

    }
}
