using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetSegment : ISegment
    {
        #region Miembros de ISegment

        public string ID { get; set; }

        public string DepartureStation { get; set; }

        public string ArrivalStation { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public SegmentType Type { get; set; }

        public InterJetFlightInformation Information { get; set; }
        public InterJetFlight Flight { get; set; }
        public void Validate()
        {

        }

        #endregion
    }
}
