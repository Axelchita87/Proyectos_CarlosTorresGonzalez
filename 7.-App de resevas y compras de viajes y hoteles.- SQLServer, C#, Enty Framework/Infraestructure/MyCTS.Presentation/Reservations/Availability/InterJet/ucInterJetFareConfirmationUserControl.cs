using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucInterJetFareConfirmationUserControl : CustomUserControl
    {

        /// <summary>
        /// 
        /// </summary>
        private InterJetFareConfirmationUserControlHandler _handler;
        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetFareConfirmationUserControlHandler Handler
        {
            get{
                if(this._handler == null)
                {
                    this._handler = new InterJetFareConfirmationUserControlHandler { 
                     UserControl = this

                    };
                }
                return this._handler;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetFareConfirmationUserControl"/> class.
        /// </summary>
        public ucInterJetFareConfirmationUserControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(InterJetFlight flight)
        {


            this.Handler.SetFlight(flight);
        }



    }
}
