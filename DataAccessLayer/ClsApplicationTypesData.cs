using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsApplicationTypesData
    {

        static public bool GetAllApplicationByID(int Id , ref string ApplicationType , ref decimal Fees)
        {

            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From ApplicationTypes where ApplicationTypeID = @ApplicationTypeID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeID", Id);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                ApplicationType = reader["ApplicationTypeTitle"].ToString();
                                Fees = Convert.ToDecimal(reader["ApplicationFees"]);
                            }
                        }

                    }catch(Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

            }

            return isFound;
        }

        static public bool UpdateApplication(int Id , string ApplicationType , decimal Fees)
        {

            int RowAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update ApplicationTypes Set 
                                 ApplicationTypeTitle = @ApplicationTypeTitle,
                                 ApplicationFees = @ApplicationFees
                                 Where ApplicationTypeID = @ApplicationTypeID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationType);
                    command.Parameters.AddWithValue("@ApplicationFees", Fees);
                    command.Parameters.AddWithValue("@ApplicationTypeID", Id);

                    try
                    {
                        connection.Open();

                        RowAffected = command.ExecuteNonQuery();
                    }catch(Exception ex)
                    {


                    }
                }
            }

            return (RowAffected > 0);
        }

       
        static public DataTable ListApplicationType()
        {

            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From ApplicationTypes";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }

                        }

                    }
                    catch(Exception ex)
                    {

                    }
                }
            }

            return dt;
        }

    }
}
