using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsTestAppoitmentData
    {


        public static bool GetAllTestAppoitmentByID(int TestAppoitmentID , ref int TestTypeID ,ref int LocalDriningLicenseApplicationID , ref DateTime AppoitmentDate , ref float PaidFees ,ref int CreatedByUserId , ref bool IsLocked , ref int RetakeTestApplicationID)
        {
            bool isFound = false;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * TestAppointments where TestAppointmentID = @TestAppointmentID";

                using(SqlCommand command= new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppoitmentID);

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            isFound = true;

                            TestTypeID = (int)reader["TestTypeID"];
                            LocalDriningLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            AppoitmentDate = (DateTime)reader["AppointmentDate"];
                            PaidFees = (float)reader["PaidFees"];
                            CreatedByUserId = (int)reader["CreatedByUserID"];
                            IsLocked = (bool)reader["IsLocked"];
                            RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                        }
                    }catch(Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;


        }

        public static DataTable GetAllTestAppoitment()
        {

            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From TestAppointments_View order by AppointmentDate Desc";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }catch(Exception ex)
                    {

                        dt = null;
                    }

                }
            }

            return dt;
        }

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID , bool IsLcked  , int RetakeTestApplicationID)
        {

            int NewTestAppointmentID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Insert Into TestAppointments(TestTypeID , LocalDrivingLicenseApplicationID , AppointmentDate , PaidFees , CreatedByUserID , IsLocked , RetakeTestApplicationID)
                                 Values(@TestTypeID , @LocalDrivingLicenseApplicationID , @AppointmentDate , @PaidFees , @CreatedByUserID, @IsLocked , @RetakeTestApplicationID);
                                 Select Scope_Identity():";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLcked);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

                    try
                    {

                        connection.Open();

                        object Resulta = command.ExecuteScalar();

                        if (Resulta != null && int.TryParse(Resulta.ToString(), out int NewTestAppo))

                            NewTestAppointmentID = NewTestAppo;
                    }catch(Exception ex)
                    {
                        NewTestAppointmentID = -1;
                    }

                }
            }

            return NewTestAppointmentID;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID , int TestTypeID , int LocalDrivingLicenseApplicationID , DateTime AppointmentDate , float PaidFees , int CreatedByUserID , bool IsLocked , int RetakeTestApplicationsID)
        {

            int RowAffected = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update TestAppointments Set TestTypeID = @TestTypeID,
                                                             LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                                             AppointmentDate = @AppointmentDate,
                                                             PaidFees = @PaidFees,
                                                             CreatedByUserID = @CreatedByUserID,
                                                             IsLocked = @IsLocked,
                                                             RetakeTestApplicationID = @RetakeApplicationID
                                                             Where TestAppointmentID = @TestAppointmentID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {


                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationsID);

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

    }
}
