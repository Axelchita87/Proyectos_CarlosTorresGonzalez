using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class LowFareAirLinesError
    {

        public string Agent { get; set; }
        public string ErrorMessage { get; set; }
        public string AirLine { get; set; }
        public DateTime Date { get; set; }
        public string ServiceName { get; set; }
    }
}
