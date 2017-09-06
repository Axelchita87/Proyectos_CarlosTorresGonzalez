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
    public partial class ucInterJetFlightConfirmationUserControl : CustomUserControl
    {
        private InterJetFlightConfirmationUserControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetFlightConfirmationUserControlHandler Handler
        {
            get
            {
                if (this._handler == null)
                {
                    this._handler = new InterJetFlightConfirmationUserControlHandler
                    {
                        UserControl = this

                    };
                }
                return this._handler;

            }
        }


        public ucInterJetFlightConfirmationUserControl()
        {
            InitializeComponent();
        }

        public void SetFlight(InterJetFlight flight)
        {
            this.Handler.SetFlight(flight);
        }


      



    }
}
