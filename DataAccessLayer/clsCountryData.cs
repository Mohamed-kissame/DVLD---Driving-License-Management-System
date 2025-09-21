using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCountryData
    {

        public static bool GetCountryByID(int ID, ref string CountryName)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@CountryID", ID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader redaer = command.ExecuteReader())
                        {

                            if (redaer.Read())
                            {

                                isFound = true;

                                CountryName = (string)redaer["CountryName"];

                              
                            }
                            
                        }


                    }
                    catch (DataException ex)
                    {
                        Console.WriteLine("Error  : " + ex.Message);
                        
                    }
                }
            }


            return isFound;

        }

        public static bool GetCountryByName(string CountryName , ref int ID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@CountryName", CountryName);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader redaer = command.ExecuteReader())
                        {

                            if (redaer.Read())
                            {

                                isFound = true;

                                ID = (int)redaer["CountryID"];


                            }
                            else
                            {
                                isFound = false;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error  : " + ex.Message);
                        isFound = false;
                    }
                }
            }


            return isFound;

        }

        static public DataTable ListCountry()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                

                string Query = "SELECT * From countries";

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
                    }catch(Exception ex)
                    {

                       
                    }
                }
            }

            return dt;
        }

       
    }
}
