using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Container
{
    public interface ILowFareAvailabilityViewContainer : IBaseView
    {
        #region Miembros de IBaseView

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool IsValid { get; set; }

        string TypeItinerary { get; set; }
        /// <summary>
        /// Gets or sets the itinerary.
        /// </summary>
        /// <value>
        /// The itinerary.
        /// </value>
        string Itinerary { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        string Date { get; set; }

        List<IFlight> Fligths { get; set; }

        IFlight SelectedFlight { get; set; }

        void FilterByCompanyName(string CompanyName);

        AvailabilityRequest AvailabilityRequest { get; set; }
        EventHandler OnSelectedFlight { get; set; }
        void SetError(Exception exception);
        void CleanError();


        #endregion
    }
}
