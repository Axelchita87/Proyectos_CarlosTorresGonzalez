using MyCTS.Services.APIVolaris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PRUEBAVolaris
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            for (int a = 0; a < 100; a++)
            {
                DateTime tiempoInicio = DateTime.Now;

                IVolaris target = new VolarisClient();
                string origen = "MEX";
                string destino = "LAX";
                DateTime fechaInicio = DateTime.Now.Date.AddDays(20);
                DateTime fechaLlegada = DateTime.Now.Date.AddDays(23);
                string codigoMoneda = "MXN";
                MyCTS.Services.APIVolaris.TiposVolarisFlightTypes tipoVuelo = MyCTS.Services.APIVolaris.TiposVolarisFlightTypes.RoundTrip;
                List<TiposVolarisPassengerType> tipoPasajero = new List<TiposVolarisPassengerType>();
                //tipoPasajero.Add(TiposVolaris.PassengerType.Infant);
                tipoPasajero.Add(MyCTS.Services.APIVolaris.TiposVolarisPassengerType.Adult);
                //tipoPasajero.Add(TiposVolaris.PassengerType.Children);
                //tipoPasajero.Add(TiposVolaris.PassengerType.Adult);
                BookingData actual = new BookingData();
                List<VueloDisponible> objectFlightAvailable = new List<VueloDisponible>();
                VueloDisponible ida = new VueloDisponible();
                VueloDisponible vuelta = new VueloDisponible();
                string signature = target.AbrirConexion();
                objectFlightAvailable = target.ObtenerDisponibilidad(origen, destino, fechaInicio, fechaLlegada, codigoMoneda, tipoVuelo, tipoPasajero, signature);
                for (int i = 0; i < objectFlightAvailable.Count; i++)
                {
                    if (objectFlightAvailable[i].CountFaresk__BackingField != 0 && objectFlightAvailable[i].TypeFlightk__BackingField == TiposVolarisFlightFullType.Outbound)
                    {
                        ida = objectFlightAvailable[i];
                        break;
                    }
                }

                for (int i = 0; i < objectFlightAvailable.Count; i++)
                {
                    if (objectFlightAvailable[i].CountFaresk__BackingField != 0 && objectFlightAvailable[i].TypeFlightk__BackingField == TiposVolarisFlightFullType.Inbound)
                    {
                        vuelta = objectFlightAvailable[i];
                        break;
                    }
                }

                target.ObtenerVenta(ida, vuelta, tipoPasajero, tipoVuelo);

                List<PasajerosVolaris> pasajeros = new List<PasajerosVolaris>();
                PasajerosVolaris pasajero = new PasajerosVolaris();
                pasajero.Apellidos = "segura";
                pasajero.FechaNacimiento = Convert.ToDateTime("19/05/1972");
                pasajero.Genero = MyCTS.Services.APIVolaris.TiposVolarisGender.M;
                pasajero.Nacionalidad = "MX";
                pasajero.Nombres = "luis";
                pasajero.NumeroPasajero = 1;
                pasajero.Pais = "MX";
                pasajero.TipoPasajero = TiposVolarisPassengerType.Adult;
                pasajero.Titulo = TiposVolarisFirstTittle.MR;

                pasajeros.Add(pasajero);
                //pasajeros.Add(new PasajerosVolaris( (TiposVolaris.FirstTittle.MR, "luis", "segura", TiposVolaris.Gender.M, tipoPasajero[0], Convert.ToDateTime("19/05/1972"), "MX", "MX"));
                int c = target.AgregarPasajeros(pasajeros, signature);

                actual = target.GetBookingFromState(signature);

                DateTime tiempoFin = DateTime.Now;

                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(actual.GetType());
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\PruebaAplicacionBookingResponse " + tiempoInicio.ToString("yyyy_MM_dd_HH_mm_ss") + tiempoFin.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                writer.Serialize(file, actual);
                file.Close();
            }
        }
    }


    [Serializable]
    public class TiposVolaris
    {
        public enum PassengerType
        { Infant = 0, Children = 1, Adult = 2 }

        public enum FlightTypes
        { OnlyTrip = 1, RoundTrip = 2 }

        public enum FlightFullType
        { Inbound = 0, Outbound = 1 }

        public enum FirstTittle
        { MASTER = 0, MR = 1, MRS = 2, MS = 3, CHD = 4, INF = 5 }

        public enum Gender
        { M = 0, F = 1 }

        public enum PaymentType
        { AX = 0, MC = 1, VI = 2 }

        public enum CountryCode
        { MX = 0 }

        public enum PaymentMethodType
        {
            PrePaid = 0,
            ExternalAccount = 1,
            AgencyAccount = 2,
            CreditShell = 3,
            CreditFile = 4,
            Voucher = 5,
            Loyalty = 6,
            Unmapped = -1,
        }
    }    
}
