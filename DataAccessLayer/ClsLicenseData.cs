using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsLicenseData
    {


        public static bool GetLicenseInfoByID(int LicensesID ,ref int ApplicationID , ref int DriverID , ref int LicenseClass ,
          ref DateTime IssueDate , ref DateTime ExpirationDate , ref string Notes , ref float PaidFees , ref bool IsActive , ref byte issueReason , ref int CreatedByUser)
        {
            bool isFound = false;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = "Select * From Licenses Where LicenseID = @LicenseID";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", LicensesID);


                    try
                    {

                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if(reader.Read())
                            {

                                isFound = true;

                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                if (reader["Notes"] == DBNull.Value)
                                {
                                    Notes = "";

                                }
                                else
                                {

                                    Notes = (string)reader["Notes"];
                                }
                                PaidFees = (float)reader["PaidFess"];
                                IsActive = (bool)reader["IsActive"];
                                issueReason = (byte)reader["IssueReason"];
                                CreatedByUser = (int)reader["CreatedByUserID"];


                            }
                            else
                            {

                                isFound = false;
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

        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = "Select * From Licenses";

                using(SqlCommand command = new SqlCommand(Query , connection))
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

                    }catch(Exception ex)
                    {
                        dt = null;
                    }

                }

            }

            return dt;

        }

        public static DataTable GetDriverLicense(int Driver)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc ";


                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@DriverID", Driver);

                    try{

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {

                                dt.Load(reader);
                            }
                            else
                            {

                                dt = null;
                            }

                        }




                    }catch(Exception ex)
                    {

                    }

                }

            }

            return dt;

        }


        public static int AddNewLicense(int ApplicationID , int DriverID , int LicenseClass , DateTime IssueDate , DateTime ExpirationDate , string Notes , float PaidFees , bool IsActive , byte issueReason , int CreatedByUser)
        {

            int LicenseID = -1;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"Insert Into Licenses (ApplicationID , DriverID, LicenseClass , IssueDate , ExpirationDate,Notes, PaidFees, IsActive, IssueReason, CreatedByUserID )
                                                       Values(@ApplicationID , @DriverID , @LicenseClass , @IssueDate ,@ExpirationDate,@PaidFees , @IsActive , @CreatedByUserID );
                                                        Select Scope_Identity();";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicensClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    if (Notes == "") {
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Notes", Notes);
                    }
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", issueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUser);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            LicenseID = insertedID;
                        }
                    }catch(Exception ex)
                    {

                    }



                }

            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID , int ApplicationID , int DriverID , int LicenseClass , DateTime IssueDate , DateTime ExpritionDate , string Notes , float PaidFees , bool IsActive , byte issueReason , int CreatedByUserID)
        {

            int RowsAffected = 0;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update Licenses Set 
                                 ApplicationID = @ApplicationID ,
                                 DriveID = @DriveID,
                                 LicenseClass = @LicenseClass,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 Notes = @Notes ,
                                 PaidFees = @PaidFees,
                                 ISActive = @IsActive,
                                 issueReason = @issueReason,
                                 CreatedByUserID = @CreatedByUserID

                                 Where LicenseID = @LicenseID ";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {


                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpritionDate);
                    if (Notes == "")
                    {
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Notes", Notes);
                    }
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@issueReason", issueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static int GetActiveLicenseIdByPerson(int PersonID , int LicenseClass)
        {

            int LicenseID = -1;


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"SELECT Licenses.LicenseID
                                  FROM Licenses INNER JOIN
                                  Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                              Licenses.LicenseClass = @LicenseClass
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1";

                using(SqlCommand command = new SqlCommand(Query , connection))
                {

                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@PersonID", PersonID);


                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            LicenseID = insertedID;
                        }


                    }
                    catch(Exception ex)
                    {

                    }

                }
            }


            return LicenseID;

        }

        public static bool DesactiveLicense(int LicenseID)
        {


            int RowAffection = 0;


            using (SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {

                string Query = @"Update License Set 
                                               IsActive = 0 
                                               Where LicenseID =@LicenseID ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {

                        connection.Open();

                        RowAffection = command.ExecuteNonQuery();

                    }catch(Exception ex)
                    {

                    }

                }


            }

            return (RowAffection > 0);

        }

    }
}
