using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetSelectedFlights
    {
        private List<InterJetFlight> _selectedFlights = new List<InterJetFlight>();

        private List<InterJetFlight> SelectedFlights
        {
            get
            {
                return this._selectedFlights;
            }
        }

        public void AddFlight(List<InterJetFlight> flightsToAdd)
        {
            //foreach (InterJetFlight flight in this.SelectedFlights)
            //{
            //    if (flightToAdd.Equals(flight))
            //    {
            //        throw new Exception(string.Format("EL VUELO {0} CON DESTINO {1} - {2} YA HA SIDO AGREGADO AL INTINERARIO, POR FAVOR SELECCION UNO DISTINTO.", flightToAdd.FlightNumber, flightToAdd.DepartureStation, flightToAdd.ArrivalStation));
            //    }

            //}

            int flightCounter = this.SelectedFlights.Count;

            foreach (var interJetFlight in flightsToAdd)
            {
                flightCounter +=1;
                int newId = flightCounter;
                interJetFlight.ID = string.Format("0{0}", newId);
            }

            if (flightsToAdd != null && flightsToAdd.Any())
            {
                this.SelectedFlights.AddRange(flightsToAdd);
            }


        }
        public void AddFlight(InterJetFlight flightToAdd)
        {
            this.AddFlight(new List<InterJetFlight>() { flightToAdd });
        }



        public List<InterJetFlight> GetFlights()
        {
            return this.SelectedFlights;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has international segments.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has international segments; otherwise, <c>false</c>.
        /// </value>
        public bool HasInternationalSegments
        {
            get
            {

                return this.SelectedFlights.Any(f => f.IsInternational);
            }
        }





    }
}
