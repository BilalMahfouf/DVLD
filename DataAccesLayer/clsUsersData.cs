using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static class clsUsersData
    {

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "select * from Users";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dtUsers.Load(reader);
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
            return dtUsers;
        }

        public static bool Find(int UserID,ref int PersonID,ref string UserName,
            ref string Password,ref bool isActive)
        {
            bool isFound=false;
            SqlConnection connection= new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool Find(ref int UserID, ref int PersonID,string UserName,
            string Password, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select * from Users where UserName=@UserName and Password=@Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["isActive"];
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

        public static int AddNewUser(int PersonID,string UserName,string Password,bool isActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query= @"INSERT INTO Users
                            (PersonID,UserName,Password,IsActive)
                            VALUES (@PersonID,@UserName,@Password,@IsActive)

                    SELECT SCOPE_IDENTITY();";

            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(),out int userid))
                {
                    UserID = userid;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return UserID;

        }

        public static bool UpdateUser(int UserID,int PersonID,string UserName,
            string Password,bool IsActive)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection( clsDataConnection.connection_string);
            string query = @"Update Users
                            Set PersonID=@PersonID,UserName=@UserName,Password=@Password,IsActive=@IsActive
                                    where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return rowAffected > 0;

        }

        public static bool DeleteUser(int UserID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"Delete from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return rowAffected > 0;

        }

       
        public static DataTable GetAllUsersWithFullName()
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"select Users.UserID,People.PersonID, 
         (People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName) as FullName,
        Users.UserName, Users.IsActive from Users Inner join People on Users.PersonID=People.PersonID
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    result.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }


    }
}
