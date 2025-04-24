using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsTestsData
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes,
            int CreatedByUserID)
        {
            int TestID = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"INSERT INTO Tests
                         (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)

                       select SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes == string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(),out int insertedID))
                {
                    TestID = insertedID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); } 
            return TestID;
        }

        public static bool IsPassedTest(int TestAppointmentID)
        {
            bool isfound=false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select isFound=1 from Tests 
                        where TestAppointmentID=@TestAppointmentID and TestResult=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isfound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isfound;
        }



    }
}
