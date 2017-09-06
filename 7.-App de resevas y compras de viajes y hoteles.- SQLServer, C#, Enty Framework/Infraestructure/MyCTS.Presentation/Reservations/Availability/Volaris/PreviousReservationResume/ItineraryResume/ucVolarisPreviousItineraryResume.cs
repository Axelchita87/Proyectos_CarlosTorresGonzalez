using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume.FlightResume;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume
{
    public partial class ucVolarisPreviousItineraryResume : CustomUserControl, IVolarisPreviousItineraryResumeView
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly VolarisPreviousItineraryResumePresenter _presenter;
        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPreviousItineraryResume"/> class.
        /// </summary>
        public ucVolarisPreviousItineraryResume()
        {
            InitializeComponent();
            _presenter = new VolarisPreviousItineraryResumePresenter()
                             {
                                 View = this,
                                 Repository = new VolarisPreviousItineraryResumeRepository()
                             };
        }

        #region Miembros de IVolarisPreviousItineraryResumeView



        #endregion

        #region Miembros de IBaseView


        /// <summary>
        /// Validates the input.
        /// </summary>
        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        #region Miembros de IVolarisPreviousItineraryResumeView

        /// <summary>
        /// Sets the itinerary.
        /// </summary>
        /// <param name="itinerary">The itinerary.</param>
        public void SetItinerary(VolarisItinerary itinerary)
        {
            _presenter.SetItinerary(itinerary);
        }

        public VolarisFlight DepartureFlight
        {
            get { return new VolarisFlight(); }
            set
            {
                var departureResume = new ucVolarisPreviousFlightResume();
                departureResume.SetFlight(value);
                this.container.Controls.Add(departureResume, 0, 0);
            }
        }

        public VolarisFlight ReturningFlight
        {
            get
            {
                return new VolarisFlight();
            }
            set
            {
                var returnigResume = new ucVolarisPreviousFlightResume();
                returnigResume.SetFlight(value);
                this.container.Controls.Add(returnigResume, 1, 0);
            }
        }

        #endregion
    }
}
