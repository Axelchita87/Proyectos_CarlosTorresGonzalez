using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.APIVolaris;

namespace PRUEBAVolaris
{
    public class VolarisServiceManagerPrueba
    {

        public void BookingRoundTripTest()
        {
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
}
