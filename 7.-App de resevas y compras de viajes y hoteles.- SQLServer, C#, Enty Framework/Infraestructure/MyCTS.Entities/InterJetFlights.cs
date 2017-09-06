using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetFlights 
    {
        private List<InterJetFlight> _flights;

        private List<InterJetFlight> Flights
        {
            get
            {
                if (this._flights == null)
                {
                    this._flights = new List<InterJetFlight>();
                }
                return this._flights;
            }
        }

        public void AddFlights(List<InterJetFlight> flightsToAdd)
        {
            this.Flights.AddRange(flightsToAdd);
        }

        public void AddFlight(InterJetFlight flightToAdd)
        {
            this.AddFlights(new List<InterJetFlight> { flightToAdd });
        }

        public List<InterJetFlight> GetFlights()
        {
            
            return this.Flights.Where(flight => !flight.IsRoundTrip).ToList();
        }

        public List<InterJetFlight> GetAllFlights()
        {
            return this.Flights;
        }
        public bool HasInternationalSegments
        {
            get{


                return this.Flights.Where(f => f.IsInternational).Count() > 0;
            }
        }



        public List<InterJetRoundTripFlight> GetRoundTripFlights()
        {
            List<InterJetRoundTripFlight> roundTrips = new List<InterJetRoundTripFlight>();
            foreach (InterJetFlight flightToCompare in this.Flights)
            {

                InterJetFlight departureFlight = this.Flights.Where(flight => flight.DepartureStation.Equals(flightToCompare.ArrivalStation) &&
                                                                     flight.ArrivalStation.Equals(flightToCompare.DepartureStation) &&
                                                                      flight.IvaTotal != flightToCompare.IvaTotal).FirstOrDefault();

                if (departureFlight != null)
                {
                    InterJetRoundTripFlight roundTrip = new InterJetRoundTripFlight { 

                        DepartureFlight = departureFlight,
                        ArrivalFlight = flightToCompare
                    };


                    bool roundTripExist = roundTrips.Where(r => r.Equals(roundTrip)).FirstOrDefault() != null;
                    if (!roundTripExist)
                    {
                        roundTrips.Add(roundTrip);
                    }
                    flightToCompare.IsRoundTrip = true;
                }

            }

            return roundTrips;

        }



    }
}
