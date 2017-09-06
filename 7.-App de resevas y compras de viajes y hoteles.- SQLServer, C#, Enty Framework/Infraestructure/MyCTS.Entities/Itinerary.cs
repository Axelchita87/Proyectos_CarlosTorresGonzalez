using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Itinerary
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Itinerary"/> class.
        /// </summary>
        public Itinerary()
        {
            BecomeSingleTrip();

        }
        /// <summary>
        /// Gets or sets the departure.
        /// </summary>
        /// <value>
        /// The departure.
        /// </value>
        public IFlight Departure { get; set; }

        /// <summary>
        /// Gets or sets the return.
        /// </summary>
        /// <value>
        /// The return.
        /// </value>
        public IFlight Return { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private ItineraryType _type;

        public ItineraryType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Becomes the single trip.
        /// </summary>
        public void BecomeSingleTrip()
        {
            _type = ItineraryType.SingleTrip;

        }

        /// <summary>
        /// Becomes the round trip.
        /// </summary>
        public void BecomeRoundTrip()
        {
            _type = ItineraryType.RoundTrip;

        }
    }
}
