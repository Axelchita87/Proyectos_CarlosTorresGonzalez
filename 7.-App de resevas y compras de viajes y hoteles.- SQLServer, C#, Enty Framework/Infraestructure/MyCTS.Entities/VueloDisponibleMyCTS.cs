using System;
using System.Collections.Generic;

namespace MyCTS.Entities
{
    [Serializable]
    public class VueloDisponibleMyCTS 
    {
        public TiposVolaris.FlightFullType TypeFlight { get; set; }
        public List<SegmentoDeVuelo> Segments { get; set; }
        public List<string> JourneySellKey { get; set; }
        public List<string> FareSellKey { get; set; }
        public int CountFares { get; set; }
        public string Signature { get; set; }
        public int ContractVersion { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }

        public VueloDisponibleMyCTS()
        {
            Segments = new List<SegmentoDeVuelo>();
            JourneySellKey = new List<string>();
            FareSellKey = new List<string>();
        }

        public VueloDisponibleMyCTS(string flightNumber, string departureStation, string departureDateTime, string arrivalStation, string arrivalStationlDateTime, decimal amount)
        {
            this.Amount = amount;
            Segments = new List<SegmentoDeVuelo>();
            JourneySellKey = new List<string>();
            FareSellKey = new List<string>();
        }
    }
}
