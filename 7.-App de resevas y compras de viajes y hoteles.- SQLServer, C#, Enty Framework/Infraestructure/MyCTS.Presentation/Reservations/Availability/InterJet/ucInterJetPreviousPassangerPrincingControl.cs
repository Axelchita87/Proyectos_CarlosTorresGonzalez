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
    public partial class ucInterJetPreviousPassangerPrincingControl : CustomUserControl
    {


        /// <summary>
        /// 
        /// </summary>
        private InterJetPreviousPassangerPricingControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetPreviousPassangerPricingControlHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new InterJetPreviousPassangerPricingControlHandler
                                                   {

                                                       UserControl = this,
                                                       PassangerIcon = this.passangerIcon

                                                   });
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetPreviousPassangerPrincingControl"/> class.
        /// </summary>
        public ucInterJetPreviousPassangerPrincingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ucInterJetPreviousPassangerPrincingControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="arg">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetPreviousPassangerPrincingControl_Load(object sender, EventArgs arg)
        {

            Handler.Initialize();

        }

        /// <summary>
        /// Sets the passanger previous pricing.
        /// </summary>
        /// <value>
        /// The passanger previous pricing.
        /// </value>
        public InterJetPassangerPreviousPricing PassangerPreviousPricing
        {
            set { this.Handler.PassangerPreviousPricing = value; }
        }




        /// <summary>
        /// Sets the type of the passanger.
        /// </summary>
        /// <value>
        /// The type of the passanger.
        /// </value>
        public InterJetPassangerType PassangerType
        {
            set { Handler.PassangerType = value; }
        }

        public void BindPassangerPricing()
        {
            
            this.Handler.BindPassanger();
        }






    }
}
