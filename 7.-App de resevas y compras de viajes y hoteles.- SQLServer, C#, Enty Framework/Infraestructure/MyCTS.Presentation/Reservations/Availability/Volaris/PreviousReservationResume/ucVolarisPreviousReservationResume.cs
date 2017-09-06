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
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PassangerResume;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PurchaseResume;


namespace MyCTS.Presentation
{
    public partial class ucVolarisPreviousReservationResume : CustomUserControl, IVolarisPreviousReservationResumeView
    {

        private readonly VolarisPreviousReservationResumePresenter _presenter;
        public ucVolarisPreviousReservationResume()
        {
            InitializeComponent();
            _presenter = new VolarisPreviousReservationResumePresenter()
                             {
                                 Repository = new VolarisPreviousReservationResumeRepository(),
                                 View = this
                             };
        }

        public bool ShowPassangersFullName { get; set; }

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        public void SetReservation(VolarisReservation reservation)
        {
           
            _presenter.SetReservation(reservation);
        }





        /// <summary>
        /// Sets the itinerary.
        /// </summary>
        /// <param name="itinerary">The itinerary.</param>
        public void SetItinerary(VolarisItinerary itinerary)
        {
            var itineraryControl = new ucVolarisPreviousItineraryResume();
            itineraryControl.SetItinerary(itinerary);
            container.Controls.Add(itineraryControl,0,1);

        }

        public void SetPassanger(VolarisPassangers passangers)
        {
            var passangerControl = new ucVolarisPreviousPassangersResume();
            passangerControl.SetPassanger(passangers, ShowPassangersFullName);
            container.Controls.Add(passangerControl,0,2);
        }

        public void SetReservationPrice(VolarisReservation reservation)
        {
            var priceControl = new ucVolarisPreviousPurchaseResume();
            priceControl.SetReservation(reservation);
            container.Controls.Add(priceControl,0,3);
        }
    }
}
