using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUsersData
    {

        public static bool GetAllUsersByID(int Id , ref int PersonID , ref string UserName , ref string Password , ref bool isActive)
        {

            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT * From Users Where UserID = @UserID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@UserID", Id);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                isActive = (bool)reader["IsActive"];
                            }
                        }
                    }catch(Exception ex)
                    {

                    }

                }

            }

            return isFound;
        }

        public static bool GetAllUsersByUserName(string UserName ,ref int Id, ref int PersonID, ref string Password, ref bool isActive)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT * From Users Where UserName = @UserName";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                Id = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                isActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }

            return isFound;
        }

        public static int AddNewUser(int PersonID , string UserName , string PassWord , bool isActive)
        {

            int NewUser = -1;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into Users (PersonID , UserName , Password , IsActive) 
                                 Values(@PersonID , @UserName , @Password , @IsActive);
                                 Select SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", PassWord);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                       

                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {

                            NewUser = insertedId;

                        }
                        else
                        {
                            NewUser = -1;
                        }

                    }
                    catch (Exception ex){

                    }

                }
            }

            return NewUser;
        }

        public static bool DeleteUser(int UserID)
        {

            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "DELETE FROM Users Where UserID = @UserID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {

                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();

                    }
                    catch(Exception ex)
                    {

                    }
                }

            }

            return RowsAffected > 0;

        }

        public static bool UpdateUser(int UserID , string UserName , string Password , bool isActive)
        {

            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Users
                                Set 
                                UserName = @UserName,
                                Password = @Password,
                                IsActive = @IsActive
                                Where UserID = @UserID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable ListUsers()
        {

            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT UserID , Users.PersonID , Pepole.FirstName + ' ' + Pepole.LastName as FullName , UserName , IsActive From Users join Pepole On Users.PersonID = Pepole.PersonID";

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

        public static bool UserIsExists(string UserName , string Password)
        {

            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "SELECT FOUND = 1 From Users Where UserName = @UserName and Password = @Password";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

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

                    }
                }

            }

            return isFound;

        }


        public static bool ChangePassword(int UserId , string Password)
        {

            int RowAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Users 
                                  Set Password = @Password 
                                  Where UserID = @UserID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserId);
                    command.Parameters.AddWithValue("@Password", UserId);

                    try
                    {

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();

                    }catch(Exception ex)
    {
    }
}
