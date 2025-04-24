using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static  class clsTestAppointmentData
    {
        public static  int AddNewTestAppointment(int TestTypeID,
            int LDLApplicationID,DateTime AppointmentDate,decimal PaidFees,int 
            CreatedByUserID,bool IsLocked,int RetakeTestApplicationID)
        {
            int TestAppointmentID = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"INSERT INTO TestAppointments
                                 (TestTypeID,
                                  LocalDrivingLicenseApplicationID,
                                  AppointmentDate,
                                  PaidFees,
                                  CreatedByUserID,
                                  IsLocked,
                                  RetakeTestApplicationID)
                                   VALUES
                                 (@TestTypeID,
                                  @LDLApplicationID,
                                  @AppointmentDate,
                                  @PaidFees,
                                  @CreatedByUserID,
                                  @IsLocked,
                                  @RetakeTestApplicationID);
                                        select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if(RetakeTestApplicationID==0)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }


                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        TestAppointmentID = insertedID;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            return TestAppointmentID;
        }

        public static bool Update(int TestAppointmentID,DateTime AppointmentDate,
            bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"UPDATE TestAppointments
                            SET 
                           AppointmentDate = @AppointmentDate
                           ,IsLocked=@IsLocked
                           WHERE TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

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
            {  connection.Close(); }
            return rowAffected > 0;

        }

        public static bool CantAddNewTestAppointment(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select isFound=1 from TestAppointments
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                                and IsLocked=0";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);
                    
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
            finally { connection.Close(); }
            return isFound;
        }

        public static bool Find(int TestAppointmentID, ref int TestType,
           ref  int LocalDrivingLicenseApplicationID,ref  DateTime AppointmentDate,
           ref  decimal PaidFees,ref int CreatedByUserID, ref bool IsLocked,
           ref  int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from TestAppointments
                                where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestType = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if(reader["RetakeTestApplicationID"]==null)
                    {
                        RetakeTestApplicationID = 0;
                    }
                    else
                    {
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    }
                       
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }

        public static int GetTestTrial(int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            int TestTrial = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select count(*) as Trial 
                                    from TestAppointments
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID 
                                and TestTypeID=@TestTypeID and IsLocked=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTrial = (int)reader["Trial"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return TestTrial;
        }

        public static DataTable GetAllTestAppointment(int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointments
where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dataTable;
        }

    }
}
