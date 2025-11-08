using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsLicenseClassData
    {

        public static bool GetAllLicenseClassByID(int Id , ref string ClassName , ref string ClassDescription , ref int AllowedAge , ref int LengtValidation , ref decimal Fess)
        {

            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From LicenseClasses where LicenseClassID = @LicenseClassID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LicenseClassID", Id);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                ClassName = reader["ClassName"].ToString();
                                ClassDescription = reader["ClassDescription"].ToString();
                                AllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                                LengtValidation = Convert.ToInt32(reader["DefaultLengethValidation"]);
                                Fess = Convert.ToDecimal(reader["ClassFees"]);
                                
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

        public static bool GetAllLicenseClassByName(string ClassName, ref int Id, ref string ClassDescription, ref int AllowedAge, ref int LengtValidation, ref decimal Fess)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From LicenseClasses where ClassName = @ClassName";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                Id = Convert.ToInt32(reader["LicenseClassID"]);
                                ClassDescription = reader["ClassDescription"].ToString();
                                AllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                                LengtValidation = Convert.ToInt32(reader["DefaultLengethValidation"]);
                                Fess = Convert.ToDecimal(reader["ClassFees"]);

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

        public static DataTable ListofLisenseClass()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From LicenseClasses";

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
                        dt = null;
                    }
                }
            }

            return dt;
        }

    }
}
