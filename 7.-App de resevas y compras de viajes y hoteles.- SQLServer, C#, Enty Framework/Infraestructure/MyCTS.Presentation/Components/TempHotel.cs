using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Components
{
    public class TempHotel
    {
        public static string SearchSegmHotels
        {
            get;
            set;
        }

        public static string SearchDK
        {
            get;
            set;
        }

        public static string PNR
        {
            get;
            set;
        }

        public static string Agent
        {
            get;
            set;
        }

        public static string SixReceived
        {
            get;
            set;
        }

        public static string Mail
        {
            get;
            set;
        }

        public static void Clear()
        {
            SearchSegmHotels = string.Empty;
            SearchDK = string.Empty;
            PNR = string.Empty;
            Agent = string.Empty;
            SixReceived = string.Empty;
            Mail = string.Empty;
        }
       
    }
}
