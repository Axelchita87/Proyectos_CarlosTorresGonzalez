using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFlightManager
    {
        /// <summary>
        /// 
        /// </summary>
        private InterJetPointToPointBL _pointToPointService;

        /// <summary>
        /// Gets the service.
        /// </summary>
        private InterJetPointToPointBL Service
        {
            get
            {
                return this._pointToPointService ?? (this._pointToPointService = new InterJetPointToPointBL());
            }
        }



        private string CurrentDepartureStation
        {
            get;
            set;
        }
        private string CurrentArrivalStation
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether [is point to point] [the specified departure].
        /// </summary>
        /// <param name="departure">The departure.</param>
        /// <param name="arrival">The arrival.</param>
        /// <returns>
        ///   <c>true</c> if [is point to point] [the specified departure]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPointToPoint(string departure, string arrival)
        {
            this.CurrentDepartureStation = departure;
            this.CurrentArrivalStation = arrival;
            foreach (InterJetPointToPoint point in this.Service.GetPointToPointFlights())
            {
                bool foundPointPointDestination = (point.From.Equals(departure) && point.To.Equals(arrival)) ||
                                                  (point.To.Equals(departure) && point.From.Equals(arrival));

                if (foundPointPointDestination)
                {
                    return true;
                }

            }

            return false;
        }


        /// <summary>
        /// Gets a value indicating whether [availability exist].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [availability exist]; otherwise, <c>false</c>.
        /// </value>
        public bool AvailabilityExist
        {
            
            get
            {
                bool departureExist = this.Service.GetPointToPointFlights().Any(f => f.From.Equals(this.CurrentDepartureStation) ||
                     f.To.Equals(this.CurrentDepartureStation)
                    
                    );
                bool arrivalExist = this.Service.GetPointToPointFlights().Any(f => f.To.Equals(this.CurrentArrivalStation) ||

                    f.From.Equals(this.CurrentArrivalStation)
                    
                    );

                return departureExist && arrivalExist;
            }
        }

        /// <summary>
        /// Gets the suggested connections.
        /// </summary>
        /// <returns></returns>
        public string GetSuggestedConnections()
        {
            var destinations = this.Service.GetPointToPointFlights().Where(p => p.From.Equals(this.CurrentArrivalStation)).Select(p => p.To);

            var scales = (from flight in this.Service.GetPointToPointFlights()
                          from destination in destinations
                          where
                          flight.To.Equals(this.CurrentDepartureStation) && flight.From.Equals(destination)
                          ||
                          flight.To.Equals(destination) && flight.From.Equals(this.CurrentDepartureStation)

                          select
                          flight
                          );

            var options = (from scale in scales
                           where 
                           !this.CurrentDepartureStation.Equals(scale.To)
                           select new
                           {
                               Option = string.Format("{0}-{1}-{2}", this.CurrentDepartureStation, scale.To, this.CurrentArrivalStation)

                           }
                          );

            string optionsString = "";
            int counter = 1;
            foreach (var option in options)
            {
                string result = string.Format("Opcion {0}:\n\n" +
                                              "{1}\n\n", counter, option.Option
                                              );
                counter += 1;
                optionsString = string.Concat(optionsString, result);
            }


            return optionsString;
        }





    }
}
