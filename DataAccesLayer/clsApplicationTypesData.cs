using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from ApplicationTypes";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
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

        public static bool Update(int ApplicationTypeID, string ApplicationTypeTitle
            , decimal ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"Update ApplicationTypes set ApplicationTypeTitle=@ApplicationTypeTitle
                            ,ApplicationFees=@ApplicationFees
                                 where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("ApplicationFees", ApplicationFees);

            int rowAffected = 0;
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

        public static bool Find(int ApplicationTypeID, ref string ApplicationTypeTitle
            , ref decimal ApplicationFees)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from ApplicationTypes 
                where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            bool isFound=false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];
                    isFound = true;
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

        public static bool Find(ref int ApplicationTypeID,  string ApplicationTypeTitle
            , ref decimal ApplicationFees)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from ApplicationTypes 
                where ApplicationTypeTitle=@ApplicationTypeTitle";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];
                    isFound = true;
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
