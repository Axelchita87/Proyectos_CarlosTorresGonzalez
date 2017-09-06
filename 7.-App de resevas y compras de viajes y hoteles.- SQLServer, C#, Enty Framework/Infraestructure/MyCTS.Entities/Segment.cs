using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Segment
    {
        public List<Fare> Fares { get; set; }

        public Segment()
        {
            Fares = new List<Fare>();
        }

        public Segment(List<Fare> fares)
        {
            Fares = fares;
        }
    }
}
