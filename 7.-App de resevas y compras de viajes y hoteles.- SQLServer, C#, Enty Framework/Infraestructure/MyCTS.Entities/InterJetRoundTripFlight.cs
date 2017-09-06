using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetRoundTripFlight
    {
        public InterJetFlight DepartureFlight
        {

            get;
            set;
        }

        public InterJetFlight ArrivalFlight
        {
            get;
            set;
        }
        
        public bool Equals(InterJetRoundTripFlight roundTripToCompare)
        {
            bool IsValid = this.DepartureFlight.FareSellKey.Equals(roundTripToCompare.DepartureFlight.FareSellKey) ||
                           this.ArrivalFlight.FareSellKey.Equals(roundTripToCompare.DepartureFlight.FareSellKey) ||
                           this.DepartureFlight.FareSellKey.Equals(roundTripToCompare.ArrivalFlight.FareSellKey) ||
                           this.ArrivalFlight.FareSellKey.Equals(roundTripToCompare.ArrivalFlight.FareSellKey);
            return IsValid;



        }

    }
}
