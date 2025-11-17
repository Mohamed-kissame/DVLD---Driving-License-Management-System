using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussniesDVLDLayer
{
    public class ClsDriver
    {


        public static DataTable GetAllDrivers()
        {

            return ClsDriverData.GetAllDrivers();


        }

    }
}
