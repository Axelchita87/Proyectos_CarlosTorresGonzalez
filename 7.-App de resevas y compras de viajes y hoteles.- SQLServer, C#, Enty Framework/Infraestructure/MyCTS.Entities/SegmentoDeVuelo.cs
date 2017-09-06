using System;

namespace MyCTS.Entities
{
    [Serializable]
    public class SegmentoDeVuelo
    {
        public string FlightNumber { get; set; }
        public string DepartureStation { get; set; }
        public string DepartureDateTime { get; set; }
        public string ArrivalStation { get; set; }
        public string ArrivalStationDateTime { get; set; }
    }
}
