using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class AirLines
    {
        private string airlinealfaid;
        public string AirlineAlfaID
        {
            get { return airlinealfaid; }
            set { airlinealfaid = value; }
        }

        private string airlinename;
        public string AirlineName
        {
            get { return airlinename; }
            set { airlinename = value; }
        }
    }
}
