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
    public partial class ucInterJetTaxFlightDetail : CustomUserControl
    {

        private InterJetTaxFlightDetailUserControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetTaxFlightDetailUserControlHandler Handler
        {

            get
            {

                if (this._handler == null)
                {
                    this._handler = new InterJetTaxFlightDetailUserControlHandler
                    {
                        UserControl = this,
                         PassangerIcon = this.pictureBox1
                    };
                }
                return this._handler;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetTaxFlightDetail"/> class.
        /// </summary>
        public ucInterJetTaxFlightDetail()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.DoubleBuffer, true);
        }



        

        /// <summary>
        /// Sets the information.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        public void SetInformation(InterJetTicket ticket, InterJetFlight flight)
        {
            this.Handler.SetInformation(ticket, flight);

        }



        private InterJetPassangerType _paxType;
        /// <summary>
        /// Gets or sets the type of the passanger.
        /// </summary>
        /// <value>
        /// The type of the passanger.
        /// </value>
        public InterJetPassangerType PassangerType
        {
            set
            {
                this.Handler.SetPassangerType(value);
                this._paxType = value;
            }
            get
            {
                return this._paxType;
            }
        }

        /// <summary>
        /// Sets the passanger count.
        /// </summary>
        /// <value>
        /// The passanger count.
        /// </value>
        public int PassangerCount
        {
            set
            {
                this.Handler.SetPassangerCount(value);
            }
        }

        public decimal Total
        {
            get
            {

                return this.Handler.TotalPrice;
            }
        }









    }
}
