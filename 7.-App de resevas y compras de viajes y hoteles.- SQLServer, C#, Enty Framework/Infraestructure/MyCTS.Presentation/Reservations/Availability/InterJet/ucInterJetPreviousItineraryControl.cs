using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucInterJetPreviousItineraryControl : CustomUserControl
    {

        /// <summary>
        /// 
        /// </summary>
        private InterJetPreviousItineraryControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetPreviousItineraryControlHandler Handler
        {
            get { return _handler ?? (_handler = new InterJetPreviousItineraryControlHandler
                                                     {
                                                         
                                                         UserControl = this
                                                     }); }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetPreviousItineraryControl"/> class.
        /// </summary>
        public ucInterJetPreviousItineraryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(InterJetFlight flight, int seg)
        {
            this.Handler.SetFlight(flight, seg);
        }



    }
}
