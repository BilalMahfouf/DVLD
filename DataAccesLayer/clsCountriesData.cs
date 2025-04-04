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
                if(reader.HasRows)
                {
                    result.Load(reader);
                    
                }
                reader.Close();
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

        static public bool Find(int CountryID,ref string CountryName)
        {
            bool isFound=false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Countries where CountryID=@CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }

        static public bool Find(ref int CountryID,  string CountryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Countries where CountryName=@CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }


    }
}
