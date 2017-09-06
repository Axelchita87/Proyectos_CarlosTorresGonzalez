using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class PriceTotalResponseInterjet
    {
        public static decimal getItinearyPrice { get; set; }
        public static decimal sellResponse { get; set; }
        public static decimal commitResponse { get; set; }
        public static decimal totalPriceInfant { get; set; }
        public static bool isInfant { get; set; }

        public static void Clean()
        {
            getItinearyPrice = 0;
            sellResponse = 0;
            commitResponse = 0;
            isInfant = false;
        }
    }
}
