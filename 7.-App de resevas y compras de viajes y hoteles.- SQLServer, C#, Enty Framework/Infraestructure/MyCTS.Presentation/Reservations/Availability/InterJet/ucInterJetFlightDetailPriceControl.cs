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
    public partial class ucInterJetFlightDetailPriceControl : CustomUserControl
    {


        private InterJetFlightDetailPriceUserControlHandler _handler;

        private InterJetFlightDetailPriceUserControlHandler Handler
        {
            get
            {
                if (this._handler == null)
                {
                    this._handler = new InterJetFlightDetailPriceUserControlHandler
                    {

                        UserControl = this
                    };
                }
                return this._handler;
            }
        }




        public ucInterJetFlightDetailPriceControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                   ControlStyles.UserPaint |
                   ControlStyles.DoubleBuffer, true);
        }

        public void SetInformation(InterJetTicket ticket, InterJetFlight flight)
        {
            this.Handler.SetInformation(ticket, flight);
            this.Handler.SetTotal();
        }

        private void groupBoxContainer_Enter(object sender, EventArgs e)
        {

        }


    }
}
