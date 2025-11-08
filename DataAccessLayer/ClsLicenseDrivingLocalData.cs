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

                string Query = "Select * From LOcalDrivingLicenseApplications Where LicenseDrivingLocalId = @LicenseDrivingLocalId ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseDrivingLocalOID", LicenseDrivingLocalId);

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
                string Query = "Select * From LOcalDrivingLicenseApplications Where ApplicationID = @ApplicationID ";
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
                                LicenseDrivingLocalId = (int)reader["LicenseDrivingLocalId"];
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
                                Where LicenseDrivingLocalID = @LicenseDrivingLocalID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LicenseDrivingLocalID", LicenseDrivingLocalID);
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
                string Query = "Delete From LocalDrivingLicenseApplications Where LicenseDrivingLocalID = @LicenseDrivingLocalID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseDrivingLocalID", LicenseDrivingLocalID);

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

        

    }
}
