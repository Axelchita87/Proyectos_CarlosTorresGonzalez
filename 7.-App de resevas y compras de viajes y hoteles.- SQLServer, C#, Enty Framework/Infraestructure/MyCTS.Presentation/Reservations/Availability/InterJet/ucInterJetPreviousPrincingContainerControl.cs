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
using System.Collections;

namespace MyCTS.Presentation
{
    public partial class ucInterJetPreviousPrincingContainerControl : CustomUserControl
    {
        private InterJetAvailabilityUserInput UserInput
        {
            get
            {
                if (this.Session["UserInput"] != null)
                {
                    return (InterJetAvailabilityUserInput)this.Session["UserInput"];
                }
                return new InterJetAvailabilityUserInput();
            }
        }

        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {

                //TODO:InterJet Migration -- Remover cuando se terminen las pruebas piloto.
                if (this.Parameter != null || this.Data != null)
                {
                    if (this.Parameter is InterJetSession)
                    {

                        var session = (InterJetSession)this.Parameter;
                        return session.Session;
                    }

                    if (this.Data is InterJetSession)
                    {
                        var session = (InterJetSession)this.Data;
                        return session.Session;
                    }

                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetPreviousPrincingHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetPreviousPrincingHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new InterJetPreviousPrincingHandler
                                                   {
                                                       UserControl = this,
                                                       ProgressBar = progressbar,
                                                       CotizandoLabel = loadingLabel,
                                                       Timer = timer1,
                                                       MainPanel = mainPanel,
                                                       ButtonPanel = buttonsPanel,
                                                       BakToAvailibilityButton = this.goBackButton,
                                                       ContinueToPassangersButton = this.continueToPassangerControl,
                                                       PrincingPictureBoz = this.princingPictureBox,
                                                       Loading = this.loadingPictureBox,
                                                       TotalPricePanel = this.totalPricePanel,
                                                       TotalPriceLabel = this.totalPriceLabel




                                                   });
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetPreviousPrincingContainerControl"/> class.
        /// </summary>
        public ucInterJetPreviousPrincingContainerControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Load event of the ucInterJetPreviousPrincingContainerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="arguments">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void ucInterJetPreviousPrincingContainerControl_Load(object sender, EventArgs arguments)
        {
            Handler.Initialize();
            if (UserInput.HasInfantPassanger)
            {
                MessageBox.Show("En esta pantalla no se mostraran los impuestos del infante hasta la pantalla de los impuestos desglosados");
            }

            if (!string.IsNullOrEmpty(CostumerAccountInterJet.NumberPurche))
            {
                lblPurseElectronic.Text = (Handler.GetAvailableCretid()).ToString("#.00");
                ShowHide(true);
            }
            else
                ShowHide(false);

        }

        private void ShowHide(bool visible)
        {
            lblPurseElectronic.Visible = visible;
            lblPurseElectronicDisponible.Visible = visible;

        }

        /// <summary>
        /// Handles the Click event of the goBackButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Handler.BackToAvailability();
        }

        /// <summary>
        /// Handles the Click event of the continueToPassangerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void continueToPassangerControl_Click(object sender, EventArgs e)
        {
            ucInterJetPassangerCaptureForm.IsReturn = false;

            this.Handler.ContinueToPassanger();
        }

        /// <summary>
        /// Handles the KeyDown event of the continueToPassangerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void continueToPassangerControl_KeyDown(object sender, KeyEventArgs e)
        {
            this.Handler.HandleKeyEvent(sender, e);
        }

        private void goBackButton_KeyDown(object sender, KeyEventArgs e)
        {
            this.Handler.HandleKeyEvent(sender, e);
        }

    }
}
