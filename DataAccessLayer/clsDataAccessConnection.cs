using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DataAccessLayer
{
    public class clsDataAccessConnection
    {

        static public string Connectionstring
        {

            get
            {
                return ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            }
        }

    }
}
