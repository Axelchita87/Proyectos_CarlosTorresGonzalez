using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Fare
    {
        public List<PaxFare> PaxFares { get; set; }

        public Fare()
        {
            PaxFares = new List<PaxFare>();
        }

        public Fare(List<PaxFare> paxFare)
        {
            PaxFares = paxFare;
        }
    }
}
