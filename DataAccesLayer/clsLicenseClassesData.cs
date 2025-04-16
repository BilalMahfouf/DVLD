using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsLicenseClassesData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "select * from LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dataTable.Load(reader);
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
            return dataTable;
        }

        public static bool Find(ref int LicenseClassID, string ClassName, ref string ClassDescription
            , ref byte MinimumAllowedAge, ref byte DefaultValidityLength,
            ref decimal ClassMoney)
        {
            bool isFound=false;
            SqlConnection connection= new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from LicenseClasses  where ClassName=@ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
                
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassMoney = (decimal)reader["ClassMoney"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
                finally
            {
                connection.Close();
            }
            return isFound;
        }


    }
}
