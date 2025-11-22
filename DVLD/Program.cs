using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.controlls;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Users.Users());
            //Application.Run(new Users.())
            Application.Run(new Login());
            //Application.Run(new TestForm());
            //Application.Run(new LocalLicenseDriver.LocalDrivingLicenseApp());
            //Application.Run(new main("Mohamed"));
            //Application.Run(new Pepole.Pepole());
        }
    }
}
