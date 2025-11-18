using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsApplicationData
    {


        public static bool GetAllApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicantTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {

            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = "SELECT * From Applications WHERE ApplicationID = @ApplicationID";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


                    try
                    {


                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {

                                isFound = true;

                                ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicantTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = (decimal)reader["PaidFees"];
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


        public static int AddApplication(int ApplicationPesronsID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {

            int newApplicationID = -1;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"INSERT INTO Applications(ApplicantPersonID , ApplicationDate , ApplicationTypeID , ApplicationStatus , LastStatusDate , PaidFees , CreatedByUserID)
                                VALUES(@ApplicantPersonID , @ApplicationDate , @ApplicationTypeID , @ApplicationStatus , @LastStatusDate , @PaidFees , @CreatedByUserID );
                                select SCOPE_IDENTITY();";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPesronsID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();



                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {

                            newApplicationID = insertedId;

                        }
                        else
                        {
                            newApplicationID = -1;
                        }


                    }
                    catch (Exception ex)
                    {


                    }
                }

            }


            return newApplicationID;
        }


        public static bool Delete(int ApplicationID)
        {


            int RowAffection = 0;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Delete From Application Where ApplicationID = @ApplicationID";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


                    try
                    {

                        connection.Open();


                        RowAffection = command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {


                    }


                }

            }

            return RowAffection > 0;


        }


        public static bool UpdateApplication(int ApplicationID, int ApplicantPeronID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreateByUser)
        {

            int RowAffection = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"Update Applications 
                                Set ApplicantPersonID = @ApplicantPersonID,
                                    ApplicationDate = @ApplicationDate,
                                    ApplicationTypeID = @ApplicationTypeID ,
                                    ApplicationStatus = @ApplicationStatus,
                                    LastStatusDate = @LastStatusDate,
                                    PaidFees = @PaidFees,
                                    CreatedByUserID = @CreatedByUserID
                                    Where ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPeronID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreateByUser);
                    try
                    {
                        connection.Open();
                        RowAffection = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {


                    }
                }
            }

            return RowAffection > 0;

        }


        public static bool isApplicationExists(int ApplicationID)
        {

            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select Found = 1 From Applications where ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            isExists = reader.HasRows;


                        }

                    }
                    
                    catch (Exception ex)
                    {
                        isExists = false; 
                    }
                }
            }

            return isExists;

        }

        public static int GetActiveApplication(int PersonID, int ApplicatipnTypeID)
        {

            int ActiveApplication = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select ActiveApplication = ApplicationID From Applications Where ApplicantPersonID = @ApplicantPersonID And ApplicationTypeID = @ApplicationTypeID and ApplicationStatus = 1";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicatipnTypeID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int applicationID))
                        {
                            ActiveApplication = applicationID;
                        }
                        else
                        {
                            ActiveApplication = -1;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return ActiveApplication;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        return ActiveApplicationID;
                    }
                }
            }

            return ActiveApplicationID;
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID , int ApplicationTypeID)
        {

            return (GetActiveApplication(PersonID, ApplicationTypeID) != -1);
        }

        public static bool UpdateApplucationStatus(int ApplicationID , short NewStatus)
        {
            int RowAffection = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Applications 
                                Set ApplicationStatus = @ApplicationStatus,
                                    LastStatusDate = @LastStatusDate
                                    Where ApplicationID = @ApplicationID";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicationStatus", NewStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                    try
                    {
                        connection.Open();
                        RowAffection = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return RowAffection > 0;
        }

      
    }
}
