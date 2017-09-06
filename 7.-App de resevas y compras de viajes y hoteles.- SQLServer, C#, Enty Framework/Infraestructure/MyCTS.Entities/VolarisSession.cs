using System;
using System.Collections.Generic;

namespace MyCTS.Entities
{
    public static class VolarisSession
    {
        public static bool IsVolarisProcess { get; set; }
        public static bool Profile { get; set; }
        public static bool IsValidPNR { get; set; }
        public static string StoredUserFeeCommand { get; set; }
        public static string ItineraryCommand { get; set; }
        public static List<VolarisFlight> VolarisFlight { get; set; }
        public static VolarisReservationStatus ReservationStatus { get; set; }
        public static string DepartureRoute { get; set; }
        public static string ArrivalRoute { get; set; }

        public static InterJetProfile InterJetProfile { get; set; }
        public static string Mensaje { get; set; }
        public static string PNR { get; set; }
        public static string PNRSabre { get; set; }
        public static bool Status { get; set; }
        public static List<InterJetPassanger> InterJetPassangers { get; set; }
        public static bool BackServicesExtras { get; set; }
        public static decimal PagoTotal { get; set; }
        public static decimal BasePriceTotal { get; set; }
        public static decimal TaxesTotal { get; set; }

        public static MetodoPagoVolaris PagoVolaris { get; set; }
        public static List<ItineraryFlowVolaris> ItinerarioVolaris { get; set; }
        public static VueloDisponibleMyCTS VueloDisponible { get; set; }
        public static List<VueloDisponibleMyCTS> VuelosDisponibles { get; set; }

        public static VueloDisponibleMyCTS VueloIda { get; set; }
        public static VueloDisponibleMyCTS VueloIdaConexion { get; set; }
        public static VueloDisponibleMyCTS VueloRegreso { get; set; }
        public static VueloDisponibleMyCTS VueloRegresoConexion { get; set; }

        public static string Signature { get; set; }
        public static List<TiposVolaris.PassengerType> ListaTipoPassenger { get; set; }
        public static List<SegmentoDeVuelo> ListaSegmentos { get; set; }
        public static int ContAdult { get; set; }
        public static int ContChild { get; set; }
        public static int ContInfant { get; set; }
        public static int ContPax { get; set; }

        public static int contAdult { get; set; }
        public static int contChild { get; set; }
        public static int contInfant { get; set; }

        public static List<DatosPasajerosVolaris> AddPassengerComplete { get; set; }
        public static List<VolarisServicesExtras> ExtrasServices { get; set; }
        public static List<ExtrasViajeVolaris> VolarisExtras { get; set; }
        public static string DK { get; set; }
        public static VolarisRemarks Remarks { get; set; }
        public static bool Infant { get; set; }
        public static decimal CantidadExtras { get; set; }

        public static string PrimerNivel { get; set; }
        public static string SegundoNivel { get; set; }
        public static string Nacionalidad { get; set; }

        public static string TipoTarjeta { get; set; }
        public static string TarjetaCredito { get; set; }
        public static int NumeroTarjeta { get; set; }
        public static int NumeroSeguridad { get; set; }
        public static string FechaVencimiento { get; set; }
        public static string NombreTajetaViente { get; set; }
        public static bool ReturnShowInformation { get; set; }

        public static decimal Venta { get; set; }
        public static decimal Extra { get; set; }
        public static int TotalSegments { get; set; }

        //estos solo se ocupan para lineas contables
        public static decimal BaseTotalPayAdult { get; set; }
        public static decimal IVATotalPayAdult { get; set; }
        public static decimal TUATotalPayAdult { get; set; }
        public static decimal OtrosTotalPayAdult { get; set; }
        public static decimal DiscountTotalPayAdult { get; set; }

        public static decimal baseTotalPayAdult { get; set; }
        public static decimal ivaTotalPayAdult { get; set; }
        public static decimal tuaTotalPayAdult { get; set; }
        public static decimal otrosTotalPayAdult { get; set; }
        public static decimal discountTotalPayAdult { get; set; }

        public static decimal BaseTotalPayChild { get; set; }
        public static decimal IVATotalPayChild { get; set; }
        public static decimal TUATotalPayChild { get; set; }
        public static decimal OtrosTotalPayChild { get; set; }
        public static decimal DiscountTotalPayChild { get; set; }

        public static decimal baseTotalPayChild { get; set; }
        public static decimal ivaTotalPayChild { get; set; }
        public static decimal tuaTotalPayChild { get; set; }
        public static decimal otrosTotalPayChild { get; set; }
        public static decimal discountTotalPayChild { get; set; }

        public static string TypeFly { get; set; }
        public static ContactVolaris Contacto { get; set; }

        public static List<AdditionalAccountingLine> AdditionalAdult { get; set; }
        public static List<AdditionalAccountingLine> AdditionalChild { get; set; }

        public static List<AdditionalAccountingLine> additionalAdult { get; set; }
        public static List<AdditionalAccountingLine> additionalChild { get; set; }

        public static bool IsInternational { get; set; }
        public static bool ErrorPay { get; set; }
        public static string Boleto { get; set; }
        public static bool IsClientCard { get; set; }
        public static bool IsCTSCard { get; set; }
        public static VolarisPaymentStatus StatusPaymnet { get; set; }
        public static string Agent { get; set; }
        public static string EmailAgent { get; set; }
        public static bool IsValidCard { get; set; }
        public static string ErrorMessage { get; set; }

        public static InterJetPassanger GetAndRemove(int indice)
        {
            return new InterJetPassanger
            {
                Name = VolarisSession.AddPassengerComplete[indice].AddPassenger.Nombres,
                LastName = VolarisSession.AddPassengerComplete[indice].AddPassenger.Apellidos,
                DateOfBirth = VolarisSession.AddPassengerComplete[indice].BirthDay,
                Title = VolarisSession.AddPassengerComplete[indice].AddPassenger.Titulo.ToString()
            };
        }

        public static void Clean()
        {
            Extra = 0;
            StatusPaymnet = new VolarisPaymentStatus();
            Mensaje = string.Empty;
            IsClientCard = false;
            IsCTSCard = false;
            IsVolarisProcess = false;
            Profile = false;
            IsValidPNR = false;
            StoredUserFeeCommand = string.Empty;
            ItineraryCommand = string.Empty;
            ReservationStatus = new VolarisReservationStatus();
            DepartureRoute = string.Empty;
            ArrivalRoute = string.Empty;
            PNR = string.Empty;
            PNRSabre = string.Empty;
            Status = false;
            BackServicesExtras = false;
            PagoTotal = 0;
            BasePriceTotal = 0;
            TaxesTotal = 0;
            PagoVolaris = new MetodoPagoVolaris();
            ItinerarioVolaris = new List<ItineraryFlowVolaris>();
            VueloDisponible = new VueloDisponibleMyCTS();
            VuelosDisponibles = new List<VueloDisponibleMyCTS>();
            VueloIda = new VueloDisponibleMyCTS();
            VueloIdaConexion = new VueloDisponibleMyCTS();
            VueloRegreso = new VueloDisponibleMyCTS();
            VueloRegresoConexion = new VueloDisponibleMyCTS();
            Signature = string.Empty;
            ListaTipoPassenger = new List<TiposVolaris.PassengerType>();
            ListaSegmentos = new List<SegmentoDeVuelo>();
            ContAdult = 0;
            ContChild = 0;
            ContInfant = 0;
            ContPax = 0;
            AddPassengerComplete = new List<DatosPasajerosVolaris>();
            ExtrasServices = new List<VolarisServicesExtras>();
            VolarisExtras = new List<ExtrasViajeVolaris>();
            DK = string.Empty;
            Remarks = new VolarisRemarks();
            Infant = false;
            CantidadExtras = 0;
            PrimerNivel = string.Empty;
            SegundoNivel = string.Empty;
            Nacionalidad = string.Empty;
            TipoTarjeta = string.Empty;
            TarjetaCredito = string.Empty;
            NumeroTarjeta = 0;
            NumeroSeguridad = 0;
            FechaVencimiento = string.Empty;
            NombreTajetaViente = string.Empty;
            ReturnShowInformation = false;
            Venta = 0;
            BaseTotalPayAdult = 0;
            IVATotalPayAdult = 0;
            TUATotalPayAdult = 0;
            OtrosTotalPayAdult = 0;
            BaseTotalPayChild = 0;
            IVATotalPayChild = 0;
            TUATotalPayChild = 0;
            OtrosTotalPayChild = 0;
            DiscountTotalPayAdult = 0;
            DiscountTotalPayChild = 0;
            baseTotalPayAdult = 0;
            ivaTotalPayAdult = 0;
            tuaTotalPayAdult = 0;
            otrosTotalPayAdult = 0;
            baseTotalPayChild = 0;
            ivaTotalPayChild = 0;
            tuaTotalPayChild = 0;
            otrosTotalPayChild = 0;
            discountTotalPayAdult = 0;
            discountTotalPayChild = 0;
            TypeFly = string.Empty;
            Contacto = new ContactVolaris();
            AdditionalAdult = new List<AdditionalAccountingLine>();
            AdditionalChild = new List<AdditionalAccountingLine>();
            additionalAdult = new List<AdditionalAccountingLine>();
            additionalChild = new List<AdditionalAccountingLine>();
            IsInternational = false;
            ErrorPay = false;
            IsValidCard = false;
        }
    }
}
