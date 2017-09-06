using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Flights
    {

        private readonly List<IFlight> _departureFlights;
        private readonly List<IFlight> _returningFlights;


        /// <summary>
        /// Initializes a new instance of the <see cref="Flights"/> class.
        /// </summary>
        public Flights()
        {

            _departureFlights = new List<IFlight>();
            _returningFlights = new List<IFlight>();
        }

        /// <summary>
        /// Adds the specified flights to add.
        /// </summary>
        /// <param name="flightsToAdd">The flights to add.</param>
        public void AddDeparture(List<IFlight> flightsToAdd)
        {

            _departureFlights.AddRange(flightsToAdd);
        }

        /// <summary>
        /// Adds the specified flights to add.
        /// </summary>
        /// <param name="flightsToAdd">The flights to add.</param>
        public void AddReturning(List<IFlight> flightsToAdd)
        {

            _returningFlights.AddRange(flightsToAdd);
        }

        public List<IFlight> GetDepartures()
        {
            return _departureFlights;
        }


        public List<IFlight> GetReturning()
        {
            return _returningFlights;
        }



        /// <summary>
        /// Adds the specified flight to add.
        /// </summary>
        /// <param name="flightToAdd">The flight to add.</param>
        public void AddReturning(IFlight flightToAdd)
        {

            AddReturning(new List<IFlight> { flightToAdd });
        }

        /// <summary>
        /// Removes the specified flights to remove.
        /// </summary>
        /// <param name="flightsToRemove">The flights to remove.</param>
        public void RemoveDeparture(List<IFlight> flightsToRemove)
        {
            var setToRemove = new HashSet<IFlight>(flightsToRemove);
            _departureFlights.RemoveAll(setToRemove.Contains);

        }

        /// <summary>
        /// Removes the specified flights to remove.
        /// </summary>
        /// <param name="flightsToRemove">The flights to remove.</param>
        public void RemoveReturning(List<IFlight> flightsToRemove)
        {
            var setToRemove = new HashSet<IFlight>(flightsToRemove);
            _returningFlights.RemoveAll(setToRemove.Contains);

        }

        /// <summary>
        /// Removes the specified flight to remove.
        /// </summary>
        /// <param name="flightToRemove">The flight to remove.</param>
        public void RemoveDeparture(IFlight flightToRemove)
        {
            RemoveDeparture(new List<IFlight> { flightToRemove });

        }



    }
}
