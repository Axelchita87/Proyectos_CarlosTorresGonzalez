using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume.FlightResume
{
    public partial class ucVolarisPreviousFlightResume : CustomUserControl, IVolarisPreviousFlightResumeView
    {
        private readonly VolarisPreviousFlightResumePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPreviousFlightResume"/> class.
        /// </summary>
        public ucVolarisPreviousFlightResume()
        {
            InitializeComponent();
            _presenter = new VolarisPreviousFlightResumePresenter
                             {
                                 View = this,
                                 Repository = new VolarisPreviousFlightResumeRepository()
                             };
        }

        #region Miembros de IVolarisPreviousFlightResumeView

        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(MyCTS.Entities.VolarisFlight flight)
        {
            _presenter.SetFlight(flight);
        }

        public string SegmentItinerary
        {
            get { return this.itinerary.Text; }
            set
            {

                this.itinerary.Text = value;
            }
        }

        public string DateOfFlight
        {
            get { return this.dateOfFlight.Text; }
            set { this.dateOfFlight.Text = value; }
        }

        public string TypeOfFlight
        {
            get { return this.typeOfFlight.Text; }
            set { this.typeOfFlight.Text = value; }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

    }
}
