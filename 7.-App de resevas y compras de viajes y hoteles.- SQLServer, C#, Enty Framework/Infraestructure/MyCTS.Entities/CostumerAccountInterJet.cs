using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public static class CostumerAccountInterJet
    {
        public static string Email { get; set; }
        //public static string Password { get; set; }
        //public static string FareType { get; set; }
        public static DateTime DepartureTime { get; set; }
        public static string NumberPurche { get; set; }
        public static bool SpecialRate { get; set; }

        public static bool notSeatAssing { get; set; }

        public static string Password { get; set; }

        public static void Clean()
        {
            Email = string.Empty;
            DepartureTime = new DateTime();
            NumberPurche = string.Empty;
        }
    }
}
