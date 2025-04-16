using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccesLayer
{
    // to do later delete function that don't be used in the program 4/16/2025
    public static  class clsApplicationsData
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate
            ,int ApplicationTypeID,byte ApplicationStatus,DateTime LastStatusDate,
                decimal PaidFees,int CreatedByUserID)
        {
            int ApplicationID = 0;
           SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"INSERT INTO Applications
                (ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                 ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                VALUES
                (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID,
                 @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID)

                        select SCOPE_IDENTITY() ";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(),out int insertedID))
                {
                    ApplicationID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ApplicationID;

        }

        public static bool isExist(int ApplicantPersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select isfound=1 from Applications 
                            where ApplicantPersonID=@ApplicantPersonID";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            
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


        public static bool Find(ref int ApplicationID, int ApplicantPersonID,
                ref DateTime ApplicationDate,ref int ApplicationType,ref byte 
            ApplicationStatus,ref DateTime LastStatusDate,ref decimal PaidFees,
                ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Applications 
                            where ApplicantPersonID=@ApplicantPersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationType = (int)reader["ApplicationType"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (byte)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
