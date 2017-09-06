using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ItineraryFlowVolaris
    {
        public  string PNR { get; set; }
        public  string Origen { get; set; }
        public  string Destino { get; set; }
        public  DateTime FechaInicio { get; set; }
        public  DateTime FechaLlegada { get; set; }
        public  string CodigoMoneda { get; set; }
        public  TiposVolaris.FlightTypes TipoVuelo { get; set; }
        public  List<TiposVolaris.PassengerType> ListaTipoPassenger { get; set; }
        public  string NumeroVuelo { get; set; }
        public  string Itinerary { get; set; }

        public decimal IVAAdult { get; set; }
        public decimal TUAAdult { get; set; }
        public decimal OtrosImpuestosAdult { get; set; }
        public decimal DiscountAdult { get; set; }

        public decimal IVAChild { get; set; }
        public decimal TUAChild { get; set; }
        public decimal OtrosImpuestosChild { get; set; }
        public decimal DiscountChild { get; set; }

        public  decimal PrecioBaseAdult { get; set; }
        public  decimal PrecioTotalAdult { get; set; }
        public decimal TaxAdult { get; set; }

        public decimal PrecioBaseChild { get; set; }
        public decimal PrecioTotalChild { get; set; }
        public decimal TaxChild { get; set; }
        public List<BookingServiceCharge> BookingData { get; set; }
        public List<SegmentTaxes> SegmentTaxes { get; set; }
      
        public void Clear()
        {
            PNR = string.Empty;
            Origen = string.Empty;
            Destino = string.Empty;
            FechaInicio = new DateTime();
            FechaLlegada = new DateTime();
            CodigoMoneda = string.Empty;
            TipoVuelo = new TiposVolaris.FlightTypes();
            ListaTipoPassenger = new List<TiposVolaris.PassengerType>();
        }
    }
}
