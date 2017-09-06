using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetDetailPriceMessage
    {
        public string MessageHeader
        {
            get;
            set;
        }

        public string AdultBodyMessage
        {
            get;
            set;
        }

        public string ChildBodyMessage
        {
            set;
            get;

        }

        public string SeniorBodyMessage
        {
            get;
            set;
        }
        public string TotalPrice
        {
            get;
            set;
        }

        public string DateTimeFlightString
        {
            get;
            set;
        }


    }
}
