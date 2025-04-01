using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static class clsCountriesData
    {

        static public DataTable GetAllCountries()
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "select * from Countries";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    result.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return result;
        }


    }
}
