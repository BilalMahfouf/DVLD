using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsManageLocalDrivingApplicationsData
    {

        public static DataTable GetAllLocalDrivingApplications()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from LocalDrivingLicenseApplications_View";
            SqlCommand command= new SqlCommand(query, connection);  

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    table.Load(reader);
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
            return table;
        }

        public static bool CanAddNewLocalDrivingLicenseApplication(int ApplicantPersonID,
            int LicenseClassID,ref int ApplicationID)
        
        {
            // this function check if the user can add new local driving license 
            // application and if the the user can't it will return LocalDrivingLicenseApplicationID

            bool isFound =false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select ApplicationID
                            from LocalDrivingLicenseFullApplications_View
                                where ApplicantPersonID=@ApplicantPersonID 
                                    and LicenseClassID=@LicenseClassID
                                    and ApplicationStatus!=2";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               if(reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
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

        public static bool GetPassedTestCount(int LDLAppID,ref int PassedTestCount)
        {
            bool isFound=false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select PassedTestCount from LocalDrivingLicenseApplications_View
                            where LocalDrivingLicenseApplicationID=@LDLAppID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound=true;
                    PassedTestCount = (int)reader["PassedTestCount"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally {  connection.Close(); }
            return isFound;
        }


    }
}
