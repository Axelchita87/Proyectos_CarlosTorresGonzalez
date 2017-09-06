using System;
using System.Drawing;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Builder;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.ContextSolver;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucVolarisPreviousPricing : CustomUserControl, VolarisPreviousPrincingView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPreviousPricing"/> class.
        /// </summary>
        public ucVolarisPreviousPricing()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Validates the input.
        /// </summary>
        public void ValidateInput()
        {
            var itinerary = Parameter as Itinerary;
            IsValid = false;
            if (itinerary != null)
            {
                IsValid = true;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private VolarisPreviousPrincingPresenter _presenter;
        /// <summary>
        /// Handles the Load event of the ucVolarisPreviousPricing control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucVolarisPreviousPricing_Load(object sender, EventArgs args)
        {

            _presenter = new VolarisPreviousPrincingPresenter()
                             {
                                 View = this,
                                 Repository = new VolarisPreviousPrincingRespository(),
                                 Context = new DynamicPreviousPrincingWinFormControlBuilder
                                               {
                                                   OnWorkCompleted = WorkCompleted,
                                                   ReportOnCreatingControls = OnCreatingControls

                                               }

                             };
            LogProductivity.LogTransaction(Login.Agent, "2-Desplego Cotización previa de volaris.--Volaris");
            _presenter.Initialize();
            _presenter.BuildDynamicControls();

        }
        private void OnCreatingControls(object sender, EventArgs args)
        {
            this.loadingControl.Visible = false;
            this.waitingForControls1.Visible = true;
        }

        /// <summary>
        /// Works the completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WorkCompleted(object sender, EventArgs args)
        {
            var tableLayout = (TableLayoutPanel)sender;
            buttonPanel.Dock = DockStyle.Right;
            tableLayout.Controls.Add(buttonPanel);
            mainContainer.Controls.Add(tableLayout);
            //Apaga la animación
            waitingForControls1.Visible = false;
            //Muestra los botones.
            this.volarisBanner1.Visible = true;
            mainContainer.Visible = true;
            buttonPanel.Visible = true;



        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets the reservation.
        /// </summary>
        public VolarisReservation Reservation
        {
            get { return GetReservation(); }
        }


        /// <summary>
        /// Gets the reservation.
        /// </summary>
        /// <returns></returns>
        private VolarisReservation GetReservation()
        {
            var itinerary = Parameter as Itinerary;
            if (itinerary != null)
            {
                var volarisReservation = new VolarisReservation();
                volarisReservation.Itinerary.Departure = itinerary.Departure as VolarisFlight;
                volarisReservation.Itinerary.Type = itinerary.Type;
                volarisReservation.Passangers = GetPassanger(itinerary);
                volarisReservation.Agent.Email = Login.Mail;
                volarisReservation.Agent.Firm = Login.Firm;
                volarisReservation.Agent.Pcc = Login.PCC;
                volarisReservation.Agent.Queue = Login.Queue;
                volarisReservation.Agent.FullName = Login.NombreCompleto;
                volarisReservation.Agent.ID = Login.Agent;


                if (itinerary.Type == ItineraryType.RoundTrip)
                {
                    volarisReservation.Itinerary.Return = itinerary.Return as VolarisFlight;
                }

                return volarisReservation;
            }
            return null;
        }

        private Dictionary<VolarisPassangerType, Func<IVolarisPassanger>> _passangerCreator;

        /// <summary>
        /// Gets the passanger creater.
        /// </summary>
        private Dictionary<VolarisPassangerType, Func<IVolarisPassanger>> PassangerCreator
        {

            get
            {
                return _passangerCreator ??
                       (_passangerCreator = new Dictionary<VolarisPassangerType, Func<IVolarisPassanger>>
                                                {
                                                    {VolarisPassangerType.Adult,() => new VolarisAdultPassanger()},
                                                    {VolarisPassangerType.Child,() => new VolarisChildPassanger()},
                                                    {VolarisPassangerType.Infant,() => new VolarisInfantPassanger()}


                                                });
            }
        }

        /// <summary>
        /// Gets the passanger.
        /// </summary>
        /// <param name="itinerary">The itinerary.</param>
        /// <returns></returns>
        private VolarisPassangers GetPassanger(Itinerary itinerary)
        {
            var flight = itinerary.Departure as VolarisFlight;
            var passangers = new VolarisPassangers();
            if (flight != null)
            {
                var passangerFares = flight.PassangerFares.GetPassangerFares();
                foreach (var passangerFare in passangerFares)
                {
                    if (PassangerCreator.ContainsKey(passangerFare.PassangerType))
                    {
                        for (var passangerCount = 0; passangerCount < passangerFare.Count; passangerCount++)
                        {
                            var passanger = PassangerCreator[passangerFare.PassangerType]();
                            passangers.Add(passanger);
                        }
                    }

                }

            }
            return passangers;
        }

        /// <summary>
        /// Handles the Click event of the continueButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void continueButton_Click(object sender, EventArgs e)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisPassangerCapture", Reservation, null);
        }

        /// <summary>
        /// Handles the Click event of the backButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void backButton_Click(object sender, EventArgs e)
        {

        }



        #region Miembros de VolarisPreviousPrincingView


        public void GoToNextStep()
        {

        }

        public void GoBack()
        {

        }

        #endregion
    }
}
