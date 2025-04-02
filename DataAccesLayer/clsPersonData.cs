using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
   static public class clsPersonData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "select * from People";
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
        // to do later Validation of input
        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName,
            string ThirdName,string LastName,DateTime DateOfBirth, byte Gender,string Address,
            string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            SqlConnection connection=new SqlConnection(clsDataConnection.connection_string);
            string query = @"INSERT INTO People
                            (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender
                             ,Address,Phone,Email,NationalityCountryID,ImagePath)
                VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address
                    ,@Phone,@Email,@NationalityCountryID,@ImagePath)

                    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            int PersonID = -1;
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedId))
                {
                    PersonID = insertedId;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowAffected = -1;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "DELETE FROM People WHERE PersonID=@PersonID";
            SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address,
            string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"UPDATE People
        SET NationalNo =@NationalNo
      ,FirstName =@FirstName
      ,SecondName = @SecondName
      ,ThirdName = @ThirdName
      ,LastName = @LastName
      ,DateOfBirth = @DateOfBirth
      ,Gender = @Gender
      ,Address = @Address
      ,Phone = @Phone
      ,Email = @Email
      ,NationalityCountryID= @NationalityCountryID
      ,ImagePath = @ImagePath
        WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static bool Find(int PersonID,ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender,
            ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID,
            ref string ImagePath)

        {
            bool isFound=false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "Select * from People where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = string.Empty; 
                    }
                    LastName = (string)reader["LastName"];
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"]!=DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = string.Empty;
                    }
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }




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

        public static bool Find(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName,
           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender,
           ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID,
           ref string ImagePath)

        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "Select * from People where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = string.Empty;
                    }
                    LastName = (string)reader["LastName"];
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = string.Empty;
                    }
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }




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

        public static bool isExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "Select isFound=1 from People where PersonID=@PersonID";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool isExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = "Select isFound=1 from People where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
        
        public static DataTable GetAllPeopleWithCountryName()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataConnection.connection_string);
            string query = @"SELECT 
    People.PersonID,
    People.NationalNo,
    People.FirstName,
    People.SecondName,
    People.ThirdName,
    People.LastName,
    CASE 
        WHEN People.Gender = 0 THEN 'Male'
        WHEN People.Gender = 1 THEN 'Female'
        ELSE 'Unknown'  -- Handle unexpected values
    END AS Gender,
    People.DateOfBirth,
    Countries.CountryName,
    People.Phone,
    People.Email,
    People.ImagePath
FROM People
INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID;

";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    dt.Columns["CountryName"].ColumnName = "Nationality";
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

     

    }
}
