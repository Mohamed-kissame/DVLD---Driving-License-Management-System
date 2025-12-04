using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsTestData
    {

        public static bool GetAllTestsByID(int TestID, ref int TestAppointementID, ref bool TestResults, ref string Notes, ref int CreatedByUserID)
        {


            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Tests Where TestID = @TestID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
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

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PesronID, int LicenseClassID, int TestTypeID, ref int TestID, ref int TestAppointmentID, ref bool TestResult,
              ref string Notes, ref int CreatedByUserID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                            Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PesronID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = true;

                            TestID = (int)reader["TestID"];
                            TestAppointmentID = (int)reader["TestAppointmentID"];
                            TestResult = (bool)reader["TestResult"];
                            if (reader["Notes"] == DBNull.Value)

                                Notes = "";

                            else
                                Notes = (string)reader["Notes"];


                            CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Tests order by TestID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {

                        dt = null;
                    }

                }

            }

            return dt;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {


            int NewTest = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into Tests(TestAppointmentID , TestResult , Notes , CreatedByUserID) Values(@TestAppointmentID , @TestResult , @Notes , @CreatedByUserID);
                                                   Update TestAppointments set IsLocked = 1 Where TestAppointmentID = @TestAppointmentID;
                                                   select SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);

                    if (Notes != "" && Notes != null)
                        command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            NewTest = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        NewTest = -1;
                    }
                }

            }

            return NewTest;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
        {


            int RowAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"Update Tests Set TestAppointmentID = @TestAppointmentID,
                                                  TestResult = @TestResult,
                                                  Notes = @Notes ,
                                                  CreatedByUserID = @CreatedByUserID
                                                  Where TestID = @TestID";


                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@TestID", TestID);
                    command.Parameters.AddWithValue("@TestAppoitmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    if (Notes != "" && Notes != null)
                        command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
                    
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {

                        connection.Open();

                        RowAffected = command.ExecuteNonQuery();


                    }catch(Exception ex)
                    {

                        RowAffected = 0;
                    }


                }


            }

            return RowAffected > 0;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {

            byte PassedTestCount = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"Select PassedTestCount = Count(TestTypeID) From Tests join TestAppoitments On Tests.TestAppoitmentID = TestAppoitments.TestAppoitmentID
                                 Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";


                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                        {
                            PassedTestCount = ptCount;
                        }
                    }catch(Exception ex)
                    {
                        PassedTestCount = 0;
                    }

                }

            }

            return PassedTestCount;
        }
    }
}
