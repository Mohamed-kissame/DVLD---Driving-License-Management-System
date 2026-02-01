using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging;

namespace DataAccessLayer
{
    public class clsUsersData
    {

        public static bool GetAllUsersByID(int Id , ref int PersonID , ref string UserName , ref string Password  , ref string Salt, ref bool isActive)
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
                                Salt = (string)reader["Salt"];
                                isActive = (bool)reader["IsActive"];
                            }
                        }
                    }catch(Exception ex)
                    {
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }

            }

            return isFound;
        }

        public static bool GetAllUsersByUserName(string UserName ,ref int Id, ref int PersonID, ref string Password, ref string Salt ,ref bool isActive)
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
                                Salt = (string)reader["Salt"];
                                isActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }

            }

            return isFound;
        }

        public static bool GetUserInfoBuUsernameAndPassword(string UserNAme  , ref int UserID , ref int PersonID , ref string PasswoedHash , ref string Salt , ref bool IsActive)
        {

            bool isFound = false;

            using(SqlConnection coneection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Users Where UserName = @UserName";

                using(SqlCommand command = new SqlCommand(Query , coneection))
                {

                    command.Parameters.AddWithValue("@UserName", UserNAme);
                   

                    try
                    {

                        coneection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                PasswoedHash = (string)reader["Password"];

                                if (reader["Salt"] == DBNull.Value)
                                    Salt = "";
                                else
                                    Salt = (string)reader["Salt"];
                                
                                IsActive = (bool)reader["IsActive"];


                            }

                        }

                    }catch(Exception ex)
                    {
                        isFound = false;
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }

            }

            return isFound;
        }

        public static int AddNewUser(int PersonID , string UserName , string PassWord ,  string Salt , bool isActive)
        {

            int NewUser = -1;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into Users (PersonID , UserName , Password , Salt , IsActive) 
                                 Values(@PersonID , @UserName , @Password , @Salt, @IsActive);
                                 Select SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", PassWord);
                    command.Parameters.AddWithValue("@Salt", Salt);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                       

                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {

                            NewUser = insertedId;

                        }
                        
                    }
                    catch (Exception ex){

                        NewUser = -1;
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }

            }

            return RowsAffected > 0;

        }

        public static bool UpdateUser(int UserID , string UserName , string Password  , string salt , bool isActive)
        {

            int RowsAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Users
                                Set 
                                UserName = @UserName,
                                Password = @Password,
                                Salt = @Salt,
                                IsActive = @IsActive
                                Where UserID = @UserID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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

                string Query = "SELECT UserID , Users.PersonID , People.FirstName + ' ' + People.LastName as FullName , UserName , IsActive From Users join People On Users.PersonID = People.PersonID";

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
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
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
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }

            }

            return isFound;

        }


        public static bool ChangePassword(int UserId , string Password , string Salt)
        {

            int RowAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Users 
                                  Set Password = @Password ,
                                      Salt = @Salt
                                  Where UserID = @UserID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Salt", Salt);
                    command.Parameters.AddWithValue("@UserID", UserId);

                    try
                    {

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();

                    }catch(Exception ex)
                    {
                        Log.WriteLogger(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
                   
            }

            return RowAffected > 0;
        }

    }
}
