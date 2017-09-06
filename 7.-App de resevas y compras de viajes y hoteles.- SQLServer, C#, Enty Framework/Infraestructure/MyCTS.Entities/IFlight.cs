using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public interface IFlight
    {

        /// <summary>
        /// Gets or sets the segments.
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        Segments Segments { get; set; }
        /// <summary>
        /// Gets or sets the owner company.
        /// </summary>
        /// <value>
        /// The owner company.
        /// </value>
        string OwnerCompany { get; set; }
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
        /// Gets or sets the arrival station.
        /// </summary>
        /// <value>
        /// The arrival station.
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
        /// Gets or sets the base price.
        /// </summary>
        /// <value>
        /// The base price.
        /// </value>
        decimal BasePrice { get; set; }

        decimal TotalPrice { get; set; }

        bool IsSelected { get; set; }

        decimal Tax { get; set; }

        void Validate();

        bool IsSingleTrip { get; set; }

        string Class { get; set; }


    }
}
