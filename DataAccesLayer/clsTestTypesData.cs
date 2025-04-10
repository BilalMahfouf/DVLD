using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsTestTypesData
    {

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from TestTypes";
            SqlCommand command = new SqlCommand (query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
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
            return dt;
        }

        public static bool Find(int TestTypeID, ref string TestTypeTitle,
                        ref string TestTypeDescription, ref decimal TestTypeFee)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFee = (decimal)reader["TestTypeFees"];
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

        public static bool Update(int TestTypeID,  string TestTypeTitle,
                         string TestTypeDescription,  decimal TestTypeFees)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"Update TestTypes set TestTypeTitle=@TestTypeTitle
                            ,TestTypeDescription=@TestTypeDescription
                            ,TestTypeFees=@TestTypeFees
                                where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return rowAffected > 0;

        }
    }

}
