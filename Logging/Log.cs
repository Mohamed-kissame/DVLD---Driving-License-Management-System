using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Logging
{
    public class Log
    {


        private static readonly string SourceName = "DVLD";

        private static readonly string LogName = "Application";



        public static void WriteLogger(string msg , EventLogEntryType type)
        {


            try
            {

                if (!EventLog.SourceExists(SourceName))
                {

                    EventLog.CreateEventSource(SourceName, LogName);

                }


                using(EventLog eventlog = new EventLog())
                {
                    eventlog.Source = SourceName;
                    eventlog.WriteEntry(msg , type);

                }


            }catch
            {

                Trace.WriteLine(msg);

            }
        }




    }
}
