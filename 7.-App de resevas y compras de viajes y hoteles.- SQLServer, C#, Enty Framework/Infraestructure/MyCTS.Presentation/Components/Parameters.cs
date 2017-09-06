using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Presentation
{
    public class Parameters
    {

        private static string passwordMaualCommands;
        public static string PasswordManualCommands
        {
            get { return passwordMaualCommands; }
            set { passwordMaualCommands = value; }
        }

        private static string secondsLogs;
        public static string SecondsLogs
        {
            get { return secondsLogs; }
            set { secondsLogs = value; }
        }

        private static string numCommandsToInsertLogs;
        public static string NumCommandsToInsertLogs
        {
            get { return numCommandsToInsertLogs; }
            set { numCommandsToInsertLogs = value; }
        }

        private static string timerBanner;
        public static string TimerBanner
        {
            get { return timerBanner; }
            set { timerBanner = value; }
        }

        private static string currentTimeAPINormal;
        public static string CurrentTimeAPINormal
        {
            get;
            set;
        }
        
        public static string CurrentTimeAPIExtended
        {
            get;
            set;
        }

        public static bool TimeExtendedAPI
        {
            get;
            set;
        }

        public static DateTime ServerDateTime { get; set; }
        public static DateTime LocalDateTime { get; set; }

    }
}
