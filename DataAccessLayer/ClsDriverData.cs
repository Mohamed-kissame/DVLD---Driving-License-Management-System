using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsDriverData
    {

        public static bool GetAllDriverByID(int DriverID , ref int PersonID , ref int CreatedByUserID , ref DateTime CreatedDate)
        {

            bool isFound = true;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Drivers Where DiverID = @DriverID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            isFound = true;

                            if (reader.Read())
                            {

                                PersonID = (int)reader["PesronID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];

                            }
                        }
                    }catch(Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool GetAllDriverByPersonID(int PesronID , ref int DriverID , ref int CreatedByUserID , ref DateTime CreatedDate)
        {

            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Drivers Where PersonID = @PersonID";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PesronID);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                DriverID = (int)reader["DriverID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
                            }

                        }
                    }catch(Exception ex)
                    {
                        isFound = false;
                    }

                }

                return isFound;

            }

        }

        public static DataTable GetAllDrivers()
        {


            DataTable dt = new DataTable();


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = "Select * From Drivers_View Order By FullName";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    try
                    {


                        connection.Open();

                        using(SqlDataReader Reader = command.ExecuteReader())
                        {

                            if (Reader.HasRows)
                            {

                                dt.Load(Reader);
                            }

                        }

                    }catch(Exception ex)
                    {


                    }
                
                }


            }

            return dt;


        }


        public static int AddNewDriver(int PersonID , int CreatedByUserID , DateTime CreatedDate)
        {

            int NewDriverID = -1;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into Drivers(PersonID , CreatedByUserID , CreatedDate) Values(@PersonID , @CreatedByUserID , @CreatedDate);
                                 Select Scope_Identity();";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {
                        connection.Open();

                        object Resulta = command.ExecuteScalar();

                        if(Resulta != null && int.TryParse(Resulta.ToString() , out int NewId))
                        {

                            NewDriverID = NewId;
                        }
                    }catch(Exception ex)
                    {

                        NewDriverID = -1;
                    }
                }

               

            }

            return NewDriverID;

        }

        public static bool UpdateDriver(int DriverID , int PersonID , int CreatedByUserID , DateTime CreatedDate)
        {

            int RowAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Drivers Set PersonID = @PersonID , CreatedByUserID = @CreatedByUserID , CreatedDate = @CreatedDate 
                                 Where DriverID = @DriverID";


                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {

                        RowAffected = command.ExecuteNonQuery();

                    }catch(Exception ex)
                    {
                        RowAffected = 0;
                    }
                }
            }

            return RowAffected > 0;

        }



    }
}
