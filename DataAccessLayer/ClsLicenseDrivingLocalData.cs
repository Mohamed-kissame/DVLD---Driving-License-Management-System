using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsLicenseDrivingLocalData
    {


        public static bool GetAllLicenseDrivingLocalByID(int LicenseDrivingLocalId, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LicenseDrivingLocalId);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                isFound = true;

                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];

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

        public static bool GetAllLicenseDrivingLocalByApplicationID(int ApplicationID, ref int LicenseDrivingLocalId, ref int LicenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {
                string Query = "Select * From LocalDrivingLicenseApplications Where ApplicationID = @ApplicationID ";
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
                                LicenseDrivingLocalId = (int)reader["LicenseDrivingLocalID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
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

        public static int AddNewLicenseDrivingLocal(int ApplicationID , int LicenseClassID)
        {

            int NewLicenseDrivingLocalID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into LocalDrivingLicenseApplications(ApplicationID , LicenseClassID)
                                Values(@ApplicationID , @LicenseClassID);
                                 Select SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();



                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {

                            NewLicenseDrivingLocalID = insertedId;

                        }
                        else
                        {
                            NewLicenseDrivingLocalID = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        NewLicenseDrivingLocalID = -1;

                    }


                }

            }

            return NewLicenseDrivingLocalID;
        }

        public static bool UpdateLicenseDrivingLocal(int LicenseDrivingLocalID , int ApplicationID , int LicenseClassID)
        {

            int RowAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update LocalDrivingLicenseApplications 
                                  Set ApplicationID = @ApplicationID,
                                      LicenseClassID = @LicenseClassID
                                Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LicenseDrivingLocalID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();

                    }
                    catch
                    {
                        RowAffected = 0;
                    }
                }
            }

            return RowAffected > 0;
        }

        public static bool DeleteLicenseDrivingLocal(int LicenseDrivingLocalID)
        {

            int RowAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {
                string Query = "Delete From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LicenseDrivingLocalID);

                    try
                    {
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                    catch
                    {
                        RowAffected = 0;
                    }
                }
            }

            return RowAffected > 0;
        }

        public static DataTable ListOfLicenseDriving()
        {

            DataTable dt = new DataTable();


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From LocalDrivingLicenseApplications_View order by ApplicationDate Desc";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {


                    try
                    {

                        connection.Open();

                        using(SqlDataReader Reade = command.ExecuteReader())
                        {

                            if (Reade.HasRows)

                                dt.Load(Reade);

                           
                        }
                    }catch(Exception ex)
                    {

                        dt = null;
                    }

                }


            }


            return dt;

        }


        public static bool DoesPassTestType(int LocalLicenseDrivingAppID , int TestType)
        {

            bool Result = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

                using(SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseDrivingAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestType);

                    try
                    {

                        connection.Open();

                       object result = command.ExecuteScalar();

                        if(result != null && bool.TryParse(result.ToString() , out bool Found))
                        {

                            Result = Found;
                        }
                    }catch(Exception Ex)
                    {

                        Result = false;
                      
                    }

                }

            }

            return Result;

        }

        public static bool DoesAttendTestType(int LocalLicenseDrivingAppID , int TestType)
        {

            bool isFound = false;

            using(SqlConnection connection = new SqlConnection (clsDataAccessConnection.Connectionstring))
            {

                string Query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseDrivingAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestType);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if(result != null)
                        {
                            isFound = true;
                        }
                        else
                        {
                            isFound = false;
                        }
                    }catch(Exception Ex)
                    {
                        isFound = false;
                    }

                }

            }

            return isFound;

        }

        public static byte TotalTrailsPerTest(int LocalLicenseDrivingAppID , int TestTypes)
        {

            byte TotalTrailsPerTest = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseDrivingAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypes);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString() , out byte TotalTrials))
                        {
                            TotalTrailsPerTest = TotalTrials;
                            
                        }
                    }catch(Exception Ex)
                    {


                    }

                }
            }

            return TotalTrailsPerTest;

        }

        public static bool IsThereAnActiveScheduledTest(int LocalLicenseDrivingAppID , int TestTypes)
        {

            bool Result = false;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseDrivingAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypes);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if(result != null)
                        {

                            Result = true;
                        }
                        else
                        {
                            Result = false;
                        }
                    }catch(Exception Ex)
                    {


                    }

                }

            }

            return Result;

        }


        

    }
}
