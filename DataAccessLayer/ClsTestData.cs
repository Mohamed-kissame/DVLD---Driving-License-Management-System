using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsTestData
    {

        public static bool GetAllTestsByID(int TestID , ref int TestAppointementID , ref bool TestResults , ref string Notes , ref int CreatedByUserID) {


            bool isFound = false;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Tests Where TestID = @TestID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;


                                TestAppointementID = (int)reader["TestAppointmentID"];
                                TestResults = (bool)reader["TestResult"];
                                Notes = (string)reader["Notes"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                            }
                            
                        }


                    }
                    catch (Exception ex)
                    {

                        isFound = false;

                    }
                  
                }

            }



            return isFound;

        }
    }
}
