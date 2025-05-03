using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccesLayer
{
    public static  class clsLicensesData 
    {
       public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass
          , DateTime IssueDate, DateTime ExpirationDate, decimal PaidFees, bool IsActive,
           byte IssueReason, int CreatedByUserID, string Notes = "")
        {
            int LicenseID = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string); ;
            string query = @"INSERT INTO [dbo].[Licenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@LicenseClass
           ,@IssueDate
           ,@ExpirationDate
           ,@Notes
           ,@PaidFees
           ,@IsActive
           ,@IssueReason
           ,@CreatedByUserID);

            select SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            if(Notes==string.Empty)
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null && int.TryParse(result.ToString(),out int InsertedID))
                {
                    LicenseID = InsertedID;
                }
            }
            catch  { }
            finally { connection.Close(); }
            return LicenseID;
        }

       public static bool  Find(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass
          , ref DateTime IssueDate, ref DateTime ExpirationDate, ref decimal PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID,
            ref string Notes)
        {
            bool isFound=false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Licenses where LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else Notes = "";
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }

        public static bool FindByApplicationID(ref int LicenseID,int ApplicationID, ref int DriverID, ref int LicenseClass
          , ref DateTime IssueDate, ref DateTime ExpirationDate, ref decimal PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID,
            ref string Notes)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Licenses where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if ((string)reader["Notes"] != null)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else Notes = "";
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }


       public static  DataTable GetDriverAllLicenses(int DriverID)
        {
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Licenses where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            DataTable dt=   new DataTable();
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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }

       public static bool IsExistByApplicationIDAndLicenseClassID(int ApplicationID,int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select isFound=1 from Licenses 
                                where ApplicationID=@ApplicationID 
                                and LicenseClass=@LicenseClassID";
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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isFound;
        }

        public static DataTable GetDriverLicenseHistory(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"
select Licenses.LicenseID,Licenses.ApplicationID,LicenseClasses.ClassName,Licenses.IssueDate,Licenses.ExpirationDate
,Licenses.IsActive from Licenses
inner join LicenseClasses on LicenseClasses.LicenseClassID=Licenses.LicenseClass
where Licenses.DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }

        public static bool Update(int LicesneID, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"update Licenses set IsActive=@IsActive where LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicesneID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                 rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }

    }
}
