using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace FrontEnd.Classes
{
    internal static class clsUIHelper
    {
         

        public static string GetCountryName(int CountryID)
        {
            return clsCountries.Find(CountryID).CountryName;
        }

        
        



    }
}
