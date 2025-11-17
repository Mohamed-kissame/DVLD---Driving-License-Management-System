using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsDriverData
    {

        public static DataTable GetAllDrivers()
        {


            DataTable dt = new DataTable();


            using(SqlConnection connection = new SqlConnection(clsDataAccessConnection.Connectionstring))
            {


                string Query = @"select Drivers.DriverID , Drivers.PersonID , People.NationalNo , People.FirstName + ' ' + People.LastName as FullName , Drivers.CreatedDate 
                                 , Licenses.IsActive From Licenses join Drivers On Licenses.DriverID = Drivers.DriverID join People On Drivers.PersonID = People.PersonID";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    try
                    {


                        connection.Open();

                        using(SqlDataReader Reader = command.ExecuteReader())
                        {

                            if (Reader.HasRows)
                            {

                                dt.Load(Reader);
                            }

                        }

                    }catch(Exception ex)
                    {


                    }
                
                }


            }

            return dt;


        }



    }
}
