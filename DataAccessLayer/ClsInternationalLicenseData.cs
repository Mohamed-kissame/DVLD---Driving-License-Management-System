using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsInternationalLicenseData
    {

        public static bool GetAllInternationalLicenseByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocaleLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool isActive, ref int CreatedByUserId)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;


                               
                                ApplicationID = (int)reader["ApplicationID"];
                                IssuedUsingLocaleLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                isActive = (bool)reader["IsActive"];
                                CreatedByUserId = (int)reader["CreatedByUserID"];


                            }

                        }


                    } catch (Exception ex)
                    {
                        isFound = false;
                    }

                }

            }

            return isFound;

        }

        public static DataTable GetAllInternationalLicenses()
        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From InternationalLicenses Order by ExpirationDate";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }

                    } catch (Exception ex)
                    {
                        dt = null;
                    }
                }
            }

            return dt;

        }

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool isActive, int CreatedByUserID)
        {

            int NewInternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into InternationalLicenses (ApplicationID , DriverID , IssuedUsingLoacalLicenseID , IssueDate , ExpirationDate , IsActive , CreatedByUserID)
                                                             Values(@ApplicationID , @DriverID , @IssuedUsingLocalLicenseID , @IssueDate , @ExpirationDate , @IsActive , @CreatedByUserID);
                                                             Select Scope_Identity();";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID ", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {

                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int NewId))
                        {

                            NewInternationalLicenseID = NewId;
                        }

                    }
                    catch (Exception ex)
                    {
                        NewInternationalLicenseID = -1;

                    }
                }

                return NewInternationalLicenseID;

            }
        }

        public static bool UpdateInternationalLicense(int InternationalLIcenseID, int ApplicationID, int DriverID ,int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool isActive, int CreatedByUserID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update InternationalLicenses Set ApplicationID = @ApplicationID , DriverID = @DriverID , IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID , IssueDate = @IssueDate , ExpirationDate = @ExpirationDate , IsActive = @IsActive , CreatedByUserID = @CreatedByUserID
                                 Where InternationalLicenseID = @InternationalLicenseID";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLIcenseID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@ApplicationID ", ApplicationID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;

                    }
                }
            }
            return rowsAffected > 0;
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select InternationalLicenseID , ApplicationID , IssuedUsingLocalLicenseID, IssueDate , ExpirationDate , IsActive From InternationalLicenses Where DriverID = @DriverID order by ExpirationDate Desc";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }

                        }


                    } catch (Exception ex)
                    {

                        dt = null;
                    }
                }
            }

            return dt;
        }

        public static int GetActiveInternationalLicenseID(int DriverID)
        {
            int InternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {
                string Query = @" SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc;";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int LicenseID))
                        {
                            InternationalLicenseID = LicenseID;
                        }

                    }catch(Exception ex)
                    {
                        InternationalLicenseID = -1;
                    }
                }
            }

            return InternationalLicenseID;
        }
    }
}
