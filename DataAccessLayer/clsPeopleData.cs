using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DataAccessLayer
{
    public class clsPeopleData
    {


        static public bool GetAllPepolesByID(int ID, ref string NumberNationale, ref string FirstName, ref string SecondName, ref string ThiredName, ref string LastName
            , ref DateTime DateOfBirth, ref string Gender, ref string Address , ref string Phone , ref string Email, ref int Nationality, ref string ImagePath)
        {

            bool isFound = false;
           

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From People Where PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", ID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                NumberNationale = (string)reader["NationalNo"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThiredName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                bool genderBit = Convert.ToBoolean(reader["Gendor"]);  
                                Gender = Convert.ToString(genderBit ? "Female" : "Man");
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                                Nationality = Convert.ToInt32(reader["NationalityCountryID"]);
                                if (reader["ImagePath"] != DBNull.Value)
                                {

                                    ImagePath = (string)reader["ImagePath"];
                                }
                                else
                                {
                                    ImagePath = "";
                                }


                            }
                        }


                    }
                    catch (DataException ex)
                    {

                        Console.WriteLine(ex.Message);
                        
                       
                    }
                }

                
            }

            return isFound;

        }


        static public bool GetAllPepolesByNational(string NumberNationale , ref int ID, ref string FirstName, ref string SecondName, ref string ThiredName, ref string LastName
            , ref DateTime DateOfBirth, ref string Gender, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From People Where NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@NationalNo", NumberNationale);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                ID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThiredName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                bool genderBit = Convert.ToBoolean(reader["Gendor"]);
                                Gender = Convert.ToString(genderBit ? "Female" : "Male");
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                                Nationality = (int)reader["NationalityCountryID"];
                                if (reader["ImagePath"] != DBNull.Value)
                                {

                                    ImagePath = (string)reader["ImagePath"];
                                }
                                else
                                {
                                    ImagePath = "";
                                }
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


        static public int AddNewPerson(string NationalNo, string FirstName , string SecondName , string ThirdName , string LastName , DateTime DateOfBirth , string Gendor , string Address , string Phone 
            , string Email , int Nationality , string ImagePath)
        {

            int NewPersonID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into People (NationalNo , FirstName , SecondName , ThirdName , LastName , DateOfBirth , Gendor , Address 
                               , Phone , Email , NationalityCountryID , ImagePath) 
                                Values(@NationalNo , @FirstName , @SecondName , @ThirdName , @LastName , @DateOfBirth , @Gendor , @Address , @Phone , @Email , @NationalityCountryID , @ImagePath);
                                Select SCOPE_IDENTITY();";



                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Convert.ToBoolean(Gendor));
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", Nationality);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        

                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {

                            NewPersonID = insertedId;

                        }
                        else
                        {
                            NewPersonID = -1;
                        }


                    }
                    catch(Exception ex)
                    {

                        NewPersonID = -1;
                    }

                }
            }

            return NewPersonID;
        }

        static public bool DeletePersonById(int Id)
        {

            int RowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "DELETE FROM People Where PersonID = @PersonID";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", Id);

                    try
                    {

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();

                    }catch(Exception ex)
                    {

                       

                    }

                }


            }

            return (RowsAffected > 0);

        }

        static public bool UpdatePerson(int Id, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName
            , DateTime DateOfBirth, string Gender, string Address, string Phone, string Email , int Nationality, string ImagePath)
        {

            int RowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"UPDATE People 
                                  Set 
                                      NationalNo = @NationalNo,
                                      FirstName = @FirstName,
                                      SecondName = @SecondName,
                                      ThirdName = @ThirdName,
                                      LastName = @LastName,
                                      DateOfBirth = @DateOfBirth,
                                      Gendor = @Gendor,
                                      Address = @Address,
                                      Phone = @Phone,
                                      Email = @Email,
                                      NationalityCountryID = @NationalityCountryID,
                                      ImagePath = @ImagePath
                                      Where PersonID = @PersonID
                                      ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", Id);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Convert.ToBoolean(Gender));
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", Nationality);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);


                    try
                    {

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        return false;

                    }

                }


            }

            return (RowsAffected > 0);

        }

        static public DataTable ListAllPepole()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT PersonID , NationalNo , FirstName , LastName , CASE WHEN Gendor = 0 THEN 'Male' ELSE 'Female' END AS Gender , DateOfBirth , Countries.CountryName as Nationality , Phone , Email From People join Countries on People.NationalityCountryID = Countries.CountryID ";

                using(SqlCommand command = new SqlCommand(Query, connection))
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
                    }catch(DataException ex)
                    {
                        //dt = null;

                        Console.WriteLine(ex.Message);
                    }

                }
            }


            return dt;
        }

        static public bool IsExistsByID(int PesronID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select Found = Case When Exists(Select 1 From Pepole Where PersonID = @PersonID) Then 1 Else 0 END";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PesronID);

                    try
                    {

                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            isFound = reader.HasRows;


                        }
                    }catch(Exception ex)
                    {

                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        static public bool IsExistsInUser(int PesronID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select Found = 1 From Users Where PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PesronID);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            isFound = reader.HasRows;


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

        static public bool IsExistsByNationalNo(string NationalNo)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select Found = 1 From People Where NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            isFound = reader.HasRows;


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
