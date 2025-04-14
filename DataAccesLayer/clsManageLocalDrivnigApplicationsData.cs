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



    }
}
