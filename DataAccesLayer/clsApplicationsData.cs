using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccesLayer
{
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
    }
}
