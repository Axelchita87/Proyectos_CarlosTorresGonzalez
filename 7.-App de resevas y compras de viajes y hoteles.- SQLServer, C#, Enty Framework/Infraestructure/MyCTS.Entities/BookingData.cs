using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class BookingData
    {
        public List<Journey> Journeys { get; set; }

        public BookingData()
        {
            Journeys = new List<Journey>();
        }

        public BookingData(List<Journey> journey)
        {
            Journeys = journey;
        }
    }
}
