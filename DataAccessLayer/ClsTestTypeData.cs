using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsTestTypeData
    {


        public static bool GetAllTestByID(int Id , ref string TestTypeTitle , ref string TestTypeDescription , ref float TestTypeFees)
        {

            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From TestTypes Where TestTypeID = @TestTypeID";

                using(SqlCommand commned = new SqlCommand(Query , connection))
                {

                    commned.Parameters.AddWithValue("@TestTypeID", Id);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = commned.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                IsFound = true;

                                TestTypeTitle = Convert.ToString(reader["TestTypeTitle"]);
                                TestTypeDescription = Convert.ToString(reader["TestTypeDescription"]);
                                TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);

                            }
                        }
                    }
                    catch(Exception ex)
                    {

                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }


        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From TestTypes";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {


                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.HasRows)

                                dt.Load(reader);

                           

                        }
                    }
                    catch(Exception ex)
                    {

                    }


                }
            }

            return dt;
        }

        public static int AddNewTestType(string TestTypeTitle , string TestTypeDescription , float TestTypeFees)
        {

            int AddNewTest = -1;

            using(SqlConnection connection = new SqlConnection (clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into TestTypes(TestTypeTitle , TestTypeDescription , TestTypeFees) values(@TestTypeTitle , @TestTypeDescription , TestTypeFees);
                                 Select Scope_Identity();";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                    command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                    command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

                    try
                    {

                        connection.Open();

                        object resulta = command.ExecuteScalar();

                        if(resulta != null && int.TryParse(resulta.ToString() , out int NewType ))
                        {
                            AddNewTest = NewType;
                        }

                    }
                    catch(Exception ex)
                    {

                        AddNewTest = -1;

                    }
                }
                
            }

            return AddNewTest;
        }

        public static bool Update(int Id , string TestTypeTitle , string TestTypeDescription , float TestTypeFees)
        {

            int RowAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update TestTypes Set
                                TestTypeTitle = @TestTypeTitle,
                                TestTypeDescription = @TestTypeDescription,
                                TestTypeFees = @TestTypeFees
                                Where TestTypeID = @TestTypeID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {


                    command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                    command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                    command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
                    command.Parameters.AddWithValue("@TestTypeID", Id);


                    try
                    {

                        connection.Open();

                        RowAffected = command.ExecuteNonQuery();
                    }catch(Exception ex)
                    {


                    }

                }
            }

            return RowAffected > 0;
        }


    }
}
