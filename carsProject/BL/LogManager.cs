using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// this class take care of exceptions
    /// </summary>
    public class LogManager
    {
        /// <summary>
        /// write logs
        /// </summary>
        /// <param name="e"></param>
        public static void LogException(Exception e)
        {
            // File.AppendAllText("C:\\workspace\\logs.txt", GetInnerExceptionMessage(e));//our file in bin/debug folder
            using (EventLog eventLog = new EventLog())
            {
                eventLog.Source = "SchoolSchedule";
                string msg = GetInnerExceptionMessage(e);
                Console.WriteLine(msg);
                try
                {
                    eventLog.WriteEntry(msg, EventLogEntryType.Error);

                }
                catch (Exception)
                {
                    Console.WriteLine("cannot write to EventViewr");
                }
            }
        }
        /// <summary>
        /// find all the inner exception messages
        /// </summary>
        /// <param name="e"></param>
        /// <returns>all the inner exception messages</returns>
        public static string GetInnerExceptionMessage(Exception e)
        {
            if (e.InnerException != null)
            {
                return e.Message + "\n" + GetInnerExceptionMessage(e.InnerException);
            }
            return e.Message + "\n" + e.StackTrace + "\n*****************************************\n\n";
        }
    }
}

