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
using MyCTS.Services.Contracts;
using System.Collections;

namespace MyCTS.Presentation
{
    public partial class ucInterJetFlightsPricesDetailsForm : CustomUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private InterJetFlightsPricesDetailsUserControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetFlightsPricesDetailsUserControlHandler Handler
        {
            get
            {
                return this._handler ?? (
                    _handler = new InterJetFlightsPricesDetailsUserControlHandler
                                                             {
                                                                 UserControl = this,
                                                                 PassangerContainer = this.passangerContailerControl,
                                                                 ContinueButton = this.backToPassangerControlButton,
                                                                 ReturnButton = this.backToContactInformation
                                                             });
            }
        }

        private static Entities.InterJetTicket currentTicket = null;

        private InterJetServiceManager _interJetServiceManager;

        /// <summary>
        /// Gets the inter jet service manager.
        /// </summary>
        public InterJetServiceManager InterJetServiceManager
        {
            get
            {
                InterJetServiceManager.AgentEmail = Login.Mail;
                return new InterJetServiceManager();
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var interJetSession = (InterJetSession)(this.Parameter);
                if (interJetSession != null)
                {
                    return interJetSession.Session;
                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetFlightsPricesDetailsForm"/> class.
        /// </summary>
        public ucInterJetFlightsPricesDetailsForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint |
                           ControlStyles.DoubleBuffer, true);

        }


        /// <summary>
        /// Handles the Load event of the ucInterJetFlightsPricesDetailsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetFlightsPricesDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                Sell();
                this.Handler.Initialize();
                if (!string.IsNullOrEmpty(CostumerAccountInterJet.NumberPurche))
                {
                    lblPurseElectronic.Text = (Handler.GetAvailableCretid()).ToString("#.00");
                    ShowHide(true);
                }
                else
                    ShowHide(false);
                
                this.backToPassangerControlButton.Focus();

            }
            catch (Exception exception)
            {


            }
        }

        private void Sell()
        {
            currentTicket = null;
            currentTicket = (MyCTS.Entities.InterJetTicket)this.Session["CurrentTicket"];
            this.InterJetServiceManager.MakeReservation(currentTicket);
        }

        private void ShowHide(bool visible)
        {
            lblPurseElectronic.Visible = visible;
            lblPurseElectronicDisponible.Visible = visible;

        }

        /// <summary>
        /// Handles the Click event of the backToPaymentFormButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void backToPaymentFormButton_Click(object sender, EventArgs e)
        {
            this.Handler.BackToPaymentForm();
        }

        private void backToPassangerControlButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode || Keys.Escape == e.KeyCode || Keys.Enter == e.KeyCode)
            {
                this.Handler.BackToPaymentForm();
            }
        }

        private void backToContactInformation_Click(object sender, EventArgs e)
        {
            try
            {
                this.Handler.BackToContactOrInfant();
            }
            catch (Exception ex)
            {

            }


        }

      



    }
}
