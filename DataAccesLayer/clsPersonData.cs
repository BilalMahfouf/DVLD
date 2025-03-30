using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
   static public class clsPeopleData
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

        public static int AddNewPerson(int NationalNo,string FirstName,string SecondName,
            string ThirdName,string LastName,DateTime DateOfBirth,int Gendor,string Address,
            string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            SqlConnection connection=new SqlConnection(clsDataConnection.connection_string);
            string query = @"INSERT INTO People
                            (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor
                             ,Address,Phone,Email,NationalityCountryID,ImagePath)
                VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address
                    ,@Phone,@Email,@NationalityCountryID,@ImagePath)

                    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
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

        public static bool UpdatePerson(int PersonID, int NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address,
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
      ,Gendor = @Gendor
      ,Address = @Address
      ,Phone = @Phone
      ,Email = @Email
      ,NationalityCountryID= @NationalityCountryID
      ,ImagePath = @ImagePath
        WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo)
        }
        

    }
}
