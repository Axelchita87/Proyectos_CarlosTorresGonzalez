using System;
using MyCTS.Presentation.Base;
using MyCTS.Entities;


namespace MyCTS.Presentation.Reservations.Availability
{
    /// <summary>
    /// Interface de la vista de disponibilidad.
    /// </summary>
    public interface IAvailabilityView: IBaseView
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is low fare.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is low fare; otherwise, <c>false</c>.
        /// </value>
        bool IsLowFare { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is single trip.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is single trip; otherwise, <c>false</c>.
        /// </value>
        bool IsSingleTrip { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is round trip.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is round trip; otherwise, <c>false</c>.
        /// </value>
        bool IsRoundTrip { get; set; }
        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        /// <value>
        /// The departure date.
        /// </value>
        DateTime DepartureDate { get; set; }
        /// <summary>
        /// Gets the returning date.
        /// </summary>
        DateTime? ReturningDate { get; set; }

        string DepartureStation { get; set; }

        /// <summary>
        /// Gets or sets the arrival station.
        /// </summary>
        /// <value>
        /// The arrival station.
        /// </value>
        string ArrivalStation { get; set; }
        /// <summary>
        /// Gets or sets the adults passangers.
        /// </summary>
        /// <value>
        /// The adults passangers.
        /// </value>
        int AdultsPassangers { get; set; }
        /// <summary>
        /// Gets or sets the seniors passangers.
        /// </summary>
        /// <value>
        /// The seniors passangers.
        /// </value>
        int SeniorsPassangers { get; set; }
        /// <summary>
        /// Gets or sets the children passangers.
        /// </summary>
        /// <value>
        /// The children passangers.
        /// </value>
        int ChildrenPassangers { get; set; }
        /// <summary>
        /// Gets or sets the infant passangers.
        /// </summary>
        /// <value>
        /// The infant passangers.
        /// </value>
        int InfantPassangers { get; set; }

        void GotToNexStep();

        AvailabilityRequest AvailabilityRequest { get; set; }


    }
}
