using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Globalization;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddItineraryCommand : InterJetCommandBuilder
    {

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            var commands = this.GetSabreCommand();

            foreach (var command in commands)
            {
                string response = this.Comunicator.SendCommand(command);
                if (response != null)
                {

                }
            }
            Success = true;
            return "";
        }


        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetSabreCommand()
        {
            var cultureInfo = new CultureInfo("en-US");
            List<string> formato = new List<string>();
            string comando = string.Empty;
            if (VolarisSession.IsVolarisProcess)
            {
                for (int i = 0; i < VolarisSession.ItinerarioVolaris.Count; i++)
                {
                    comando = string.Format(@"0Y4{0}{6}{1}{2}{3}YK{4}*{5}",
                     VolarisSession.ItinerarioVolaris[i].NumeroVuelo.Trim(),
                     VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("ddMMM", cultureInfo),
                     VolarisSession.ItinerarioVolaris[i].Origen,
                     VolarisSession.ItinerarioVolaris[i].Destino,
                     VolarisSession.ItinerarioVolaris[i].ListaTipoPassenger.Count(),
                     VolarisSession.PNR,
                     "W");
                    //ver k trae flight.Information.ClassOfService "W" Extraer tipo de clase de vuelo
                    formato.Add(comando);
                }
                return formato;
            }
            else
            {
                if (ListTaxesInterjet.Conexion)
                {
                    foreach (var flight in this.Ticket.Flights.GetFlights())
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            formato.Add(string.Format(@"04O{0}{6}{1}{2}{3}YK{4}*{5}",
                                            ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.FlightDesignator.FlightNumber,
                                            ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.Departure.ToString("ddMMM", cultureInfo),
                                            ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.DepartureStation,
                                            ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.ArrivalStation,
                                            this.Ticket.Passangers.Total,
                                            this.Ticket.RecordLocator,
                                            ((Entities.InterJetSegment)flight.Segments.GetAll()[i]).Information.ClassOfService));
                        }
                    }
                }
                else
                {
                    formato = this.Ticket.Flights.GetFlights().
                                             Select(flight => string.Format(@"04O{0}{6}{1}{2}{3}YK{4}*{5}",
                                                     flight.FlightNumber,
                                                     flight.DepartureTime.ToString("ddMMM", cultureInfo),
                                                     flight.DepartureStation,
                                                     flight.ArrivalStation,
                                                     this.Ticket.Passangers.Total,
                                                     this.Ticket.RecordLocator,
                                                     flight.Information.ClassOfService)).ToList();
                }
                return formato;
            }
        }
    }
}
