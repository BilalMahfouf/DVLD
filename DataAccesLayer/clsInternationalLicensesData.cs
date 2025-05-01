using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static class clsInternationalLicensesData
    {

        public static DataTable GetAllLicenses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select InternationalLicenseID ,ApplicationID,DriverID,IssuedUsingLocalLicenseID ,IssueDate,ExpirationDate,IsActive
                            from InternationalLicenses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dataTable;
        }

        public static bool Find(int InternationalLicenseID, ref int ApplicationID,
           ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate
            , ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select *from InternationalLicenses 
                            where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID",
                InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }

        public static DataTable GetInternationalLicenseDriverHistory(int DriverID)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string qeury = @"select InternationalLicenseID,ApplicationID,
                        IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive
                        from InternationalLicenses where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return table;
        }

        public static bool CanAddNewInternationalLicense(int LicenseID)
        {
            bool canAdd = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select isFound=1 from Licenses 
                            where LicenseID=@LicenseID and LicenseClass=3 and IsActive=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                canAdd = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return canAdd;
        }

        public static int IsExistByLocalLicenseID(int IssuedUsingLocalLicenseID)
        {
            int InternationalLicenseID = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select InternationalLicenseID from InternationalLicenses
						where IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return InternationalLicenseID;
        }

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate
            ,int CreatedByUserID)
        {
            int InternationalLicenseID = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"insert into InternationalLicenses(ApplicationID,DriverID,
                            IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                            values(@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,
                            @IssueDate,@ExpirationDate,1,@CreatedByUserID)

                            select SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(),out int InsertedID))
                {
                    InternationalLicenseID = InsertedID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return InternationalLicenseID;
        }
    }
}