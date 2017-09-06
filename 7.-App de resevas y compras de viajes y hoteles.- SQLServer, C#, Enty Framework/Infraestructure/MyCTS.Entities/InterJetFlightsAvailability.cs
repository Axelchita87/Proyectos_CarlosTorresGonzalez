using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Entities
{
    public class InterJetFlightsAvailability
    {
        /// <summary>
        /// 
        /// </summary>
        private List<InterJetFlight> departureFlights = new List<InterJetFlight>();
        /// <summary>
        /// 
        /// </summary>
        private List<InterJetFlight> DepartureFlights
        {
            get{
                return this.departureFlights;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private List<InterJetFlight> returningFlights = new List<InterJetFlight>();
        /// <summary>
        /// 
        /// </summary>
        private List<InterJetFlight> ReturningFlights
        {
            get
            {
                return this.returningFlights;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="departureFlight"></param>
        public void AddDepartureFlight(List<InterJetFlight> departureFlights)
        {
            this.DepartureFlights.AddRange(departureFlights);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departureFlight"></param>
        public void AddDepartureFlight(InterJetFlight departureFlight)
        {
            this.DepartureFlights.Add(departureFlight);
        }



        public void AddReturningFlight(InterJetFlight returningFlight)
        {
             this.ReturningFlights.Add(returningFlight);
        }

        public void AddReturningFlight(List<InterJetFlight> returningFlights)
        {
            this.ReturningFlights.AddRange(returningFlights);
        }

        public List<InterJetFlight>  GetDepartureFlights()
        {
            return this.DepartureFlights;
        }

        public List<InterJetFlight> GetReturningFlight()
        {
            return this.ReturningFlights;
        }

        public bool HasDepartureFlights
        {
            get
            {
                return this.DepartureFlights.Count > 0;
            }
        }
        public bool HasReturningFlights
        {
            get{
                return this.ReturningFlights.Count > 0;

            }
        }





    }
}
