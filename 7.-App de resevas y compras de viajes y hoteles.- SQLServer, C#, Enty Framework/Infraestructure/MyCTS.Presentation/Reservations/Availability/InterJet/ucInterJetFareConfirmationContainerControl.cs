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
    public partial class ucInterJetFareConfirmationContainerControl : CustomUserControl
    {


        private InterJetFareConfirmationContainerUserControlHandler _handler;

        private InterJetFareConfirmationContainerUserControlHandler Handler
        {
            get
            {
                if (this._handler == null)
                {
                    this._handler = new InterJetFareConfirmationContainerUserControlHandler
                    {
                        UserControl = this
                    };
                }
                return this._handler;
            }
        }
        public ucInterJetFareConfirmationContainerControl()
        {
            InitializeComponent();
        }


        public void SetFlights(InterJetFlights flights)
        {

            this.Handler.SetFlights(flights);

        }
    }
}
