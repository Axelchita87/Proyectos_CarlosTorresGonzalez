using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public interface ISegment
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        string ID { get; set; }
        /// <summary>
        /// Gets or sets the departure station.
        /// </summary>
        /// <value>
        /// The departure station.
        /// </value>
        string DepartureStation { get; set; }
        /// <summary>
        /// Gets or sets the arrival statation.
        /// </summary>
        /// <value>
        /// The arrival statation.
        /// </value>
        string ArrivalStation { get; set; }
        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        /// <value>
        /// The departure time.
        /// </value>
        DateTime DepartureTime { get; set; }
        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        /// <value>
        /// The arrival time.
        /// </value>
        DateTime ArrivalTime { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        SegmentType Type { get; set; }

        void Validate();

    }


}
