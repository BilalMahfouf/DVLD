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

        public static  clsCountries Find(int CountryID)
        {
            string CountryName=string.Empty;
            if (clsCountriesData.Find(CountryID,ref CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;
        }

        public static clsCountries Find(string CountryName)
        {
            int CountryID = -1;
            if (clsCountriesData.Find(ref CountryID,  CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;
        }

    }
}
