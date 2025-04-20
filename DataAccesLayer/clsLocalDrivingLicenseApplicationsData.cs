using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsLocalDrivingLicenseApplicationsData
    {

        public static int AddNewLDLA(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"INSERT INTO LocalDrivingLicenseApplications
                                 (ApplicationID,LicenseClassID)
                                   VALUES
                                 (@ApplicationID,@LicenseClassID)
                    
                                    select SCOPE_IDENTITY() ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(),out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return LocalDrivingLicenseApplicationID;

        }

        public static bool isExist(int ApplicationID, int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select isfound=1 from LocalDrivingLicenseApplications
                            where ApplicationID=@ApplicationID and LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
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

        public static bool Update(int LocalDrivingLicenseApplicationID
            , int LicenseClassID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"UPDATE LocalDrivingLicenseApplications
                            SET LicenseClassID= @LicenseClassID
 WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {  connection.Close(); }
            return rowAffected > 0;

        }

        public static bool Find(int LocalDrivingLicenseApplicationID, ref int ApplicationID
            ,ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from LocalDrivingLicenseApplications 
                                where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
               SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally {  connection.Close(); }
            return isFound;
        }

        public static bool FindByApplicationID(ref int LocalDrivingLicenseApplicationID,  int ApplicationID
           , ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from LocalDrivingLicenseApplications 
                                where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID",ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }
    }
            

    
}
