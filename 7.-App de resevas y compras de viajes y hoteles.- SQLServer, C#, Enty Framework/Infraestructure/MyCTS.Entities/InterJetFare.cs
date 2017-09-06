using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetFare
    {

        public string CarrierCode
        {
            get;
            set;

        }

        public string ClassOfService
        {
            get;
            set;
        }

        public string ClassType
        {
            get;
            set;

        }

        public string FareBasisCode
        {
            get;
            set;
        }

        public string FareClassOfService
        {
            get;
            set;
        }

        public short FareSequence
        {
            get;
            set;
        }
        public string RuleNumber
        {
            get;
            set;
        }

        public string RuleTariff
        {
            get;
            set;
        }
    }
}
