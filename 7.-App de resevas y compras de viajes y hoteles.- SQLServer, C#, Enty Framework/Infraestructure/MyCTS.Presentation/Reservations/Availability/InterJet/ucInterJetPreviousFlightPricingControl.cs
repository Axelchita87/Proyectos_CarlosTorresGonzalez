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
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation
{
    public partial class ucInterJetPreviousFlightPricingControl : CustomUserControl
    {


        /// <summary>
        /// 
        /// </summary>
        private InterJetPreviousFlightPricingControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetPreviousFlightPricingControlHandler Handler
        {
            get { return _handler ?? (_handler = new InterJetPreviousFlightPricingControlHandler
                                                     {
                                                          UserControl = this,
                                                          MainContainer = this.flightsContainer,
                                                          ItineraryControl = ItineraryControl
                                                         


                                                     }); }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetPreviousFlightPricingControl"/> class.
        /// </summary>
        public ucInterJetPreviousFlightPricingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ucInterJetPreviousFlightPricingControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="arguments">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetPreviousFlightPricingControl_Load(object sender,EventArgs arguments)
        {

            Handler.Initialize();
            
        }

        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(InterJetFlight flight, int seg)
        {
            Handler.SetFlight(flight, seg);

        }

        /// <summary>
        /// Sets the itinerary flight.
        /// </summary>
        /// <value>
        /// The itinerary flight.
        /// </value>
        public string ItineraryFlight
        {
           set { this.flightsContainer.Text = string.Format("Vuelo: {0}", value); }
        }



    }
}
