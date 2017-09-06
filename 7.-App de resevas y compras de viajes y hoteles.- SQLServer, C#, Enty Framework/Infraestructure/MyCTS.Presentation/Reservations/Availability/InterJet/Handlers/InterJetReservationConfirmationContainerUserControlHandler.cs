using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetReservationConfirmationContainerUserControlHandler : InterJetUserControlHandler
    {

        public PictureBox ReservationPictureBox { get; set; }
        public PictureBox Loading { get; set; }

        public Button ContinueButton { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            LogProductivity.LogTransaction(Login.Agent, "8-Desplego confirmación de compra--InterJet");
            this.SetInformation(this.Ticket);

            var currentTicket = (InterJetTicket)this.Session["CurrentTicket"];
            if (currentTicket.PassangerNumberRecord.NeedBillAddress)
            {
                this.ToolTiper.SetToolTip(ContinueButton, "Continuar con la captura de la dirección de facturación".ToUpper());
            }
            else
            {
                this.ToolTiper.SetToolTip(ContinueButton, "Continuar con la captura de los quality controls".ToUpper());
            }

        }
        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                if (this.UserControl.Parameter != null)
                {
                    var session = (InterJetSession)this.UserControl.Parameter;
                    return session.Session;
                }
                return new Hashtable();
            }
        }


        public Label WaitingLabel
        {
            get;
            set;

        }

        public GradProg.GradProg ProgressBar
        {
            get;
            set;
        }



        /// <summary>
        /// Gets the ticket.
        /// </summary>
        private InterJetTicket Ticket
        {
            get
            {
                if (this.Session.ContainsKey("CurrentTicket"))
                {
                    return (InterJetTicket)this.Session["CurrentTicket"];
                }
                return new InterJetTicket();
            }
        }

        private Panel MainContainer
        {
            get
            {
                return this.GetPanelByName("MainContainer");
            }
        }
        public System.Windows.Forms.Timer Timer
        {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        private Stack<Control> controlsStack;

        /// <summary>
        /// Gets the control stack.
        /// </summary>
        private Stack<Control> ControlStack
        {
            get
            {
                return this.controlsStack ?? (this.controlsStack = new Stack<Control>());
            }
        }

        /// <summary>
        /// Sets the information.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        private void SetInformation(InterJetTicket ticket)
        {
            SetRecord(ticket.RecordLocator);
            this.SetPassangers(ticket.Passangers);
            this.SetFlights(ticket.Flights);
            this.SetFare(ticket.Flights);
        }


        private void SetRecord(string record)
        {
            var warningControl = this.MainContainer.Controls.OfType<WarningMessage>().FirstOrDefault();
            if (warningControl != null)
            {
                warningControl.Record = record;
                ucChargeOfServiceAssign.sPNR = record;
            }
        }

        private void StartAnimation(bool enabled)
        {

            this.WaitingLabel.Visible = enabled;
            //this.ProgressBar.Visible = enabled;
            this.Loading.Visible = enabled;
        }

        /// <summary>
        /// Sets the passangers.
        /// </summary>
        /// <param name="passangers">The passangers.</param>
        private void SetPassangers(InterJetPassangers passangers)
        {

            var passangerContainerControl = new ucInterJetPassangerConfirmationContainerControl();
            passangerContainerControl.AutoSize = true;
            int xDefaultCoordinate = 3;
            int yDefaultCoordinate = 99;
            passangerContainerControl.Location = new Point(xDefaultCoordinate, yDefaultCoordinate);
            passangerContainerControl.SetPassanger(passangers);
            this.MainContainer.Controls.Add(passangerContainerControl);

        }

        /// <summary>
        /// Sets the flights.
        /// </summary>
        /// <param name="flights">The flights.</param>
        private void SetFlights(InterJetFlights flights)
        {

            var flightContainerControl = new ucInterJetFlightConfirmationContainerControl();
            flightContainerControl.AutoSize = true;
            flightContainerControl.SetFlights(flights);

            int xDefaultCoordinate = 3;
            int yDisplacement = 95;
            var passengerControl = this.MainContainer.Controls.OfType<ucInterJetPassangerConfirmationContainerControl>();
            if (passengerControl.Any())
            {
                var passangerControl = passengerControl.FirstOrDefault();
                if (passangerControl != null)
                {
                    flightContainerControl.Location = new Point(xDefaultCoordinate,
                                                                passangerControl.Size.Height + yDisplacement);
                }
                this.MainContainer.Controls.Add(flightContainerControl);
                this.ControlStack.Push(flightContainerControl);

            }


        }

        /// <summary>
        /// Sets the fare.
        /// </summary>
        /// <param name="flights">The flights.</param>
        private void SetFare(InterJetFlights flights)
        {
            var newFareContainer = new ucInterJetFareConfirmationContainerControl();
            newFareContainer.AutoSize = true;
            int yDisplacement = 90;
            newFareContainer.SetFlights(flights);
            var interJetFlightscontrol =
                this.MainContainer.Controls.OfType<ucInterJetFlightConfirmationContainerControl>().FirstOrDefault();
            var ucInterJetPassangerConfirmationContainerControl = this.MainContainer.Controls.OfType<ucInterJetPassangerConfirmationContainerControl>().FirstOrDefault();
            if (ucInterJetPassangerConfirmationContainerControl != null && interJetFlightscontrol != null)
            {
                int newSize = ucInterJetPassangerConfirmationContainerControl.Size.Height +
                              interJetFlightscontrol.Size.Height + yDisplacement;
                newFareContainer.Location = new Point(interJetFlightscontrol.Location.X, newSize);
            }
            this.MainContainer.Controls.Add(newFareContainer);
            this.ResizeButtonPanel();
        }

        private void ResizeButtonPanel()
        {
            var ucInterJetPassangerConfirmationContainerControl = this.MainContainer.Controls.OfType<ucInterJetPassangerConfirmationContainerControl>().FirstOrDefault();
            if (ucInterJetPassangerConfirmationContainerControl != null)
            {
                var ucInterJetFlightConfirmationContainerControl = this.MainContainer.Controls.OfType<ucInterJetFlightConfirmationContainerControl>().FirstOrDefault();
                if (ucInterJetFlightConfirmationContainerControl != null)
                {
                    var ucInterJetFareConfirmationContainerControl = this.MainContainer.Controls.OfType<ucInterJetFareConfirmationContainerControl>().FirstOrDefault();
                    if (ucInterJetFareConfirmationContainerControl != null)
                    {
                        int yDisplacementWild = 90;
                        int yDisplacement = ucInterJetPassangerConfirmationContainerControl.Size.Height +
                                            ucInterJetFlightConfirmationContainerControl.Size.Height +
                                            ucInterJetFareConfirmationContainerControl.Size.Height + yDisplacementWild;

                        int xLocation = 290;
                        this.ButtonPanel.Location = new Point(xLocation, yDisplacement);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the button panel.
        /// </summary>
        private Panel ButtonPanel
        {
            get
            {

                return this.GetPanelByName("buttonPanel");
            }
        }

        private InterJetApiComunicator _comunicator;

        /// <summary>
        /// Gets the comunicator.
        /// </summary>
        public InterJetApiComunicator Comunicator
        {
            get { return this._comunicator ?? (this._comunicator = new InterJetApiComunicator()); }
        }


        /// <summary>
        /// Continues the with dk.
        /// </summary>
        public void ContinueWithDk()
        {


            //TODO: InterJet Migration quitar condicional cuando se salga a produccion.
            if (ucAvailability.AgentCanSeeFullFunctionality)
            {
                ContinueProcess();
            }
            else
            {
                string responseFromApi = this.Comunicator.SendCommand("*A");
                if (responseFromApi.Contains("NO DATA"))
                {
                    this.StartBackGroundWorker();

                }
                else
                {
                    DialogResult result =
                        MessageBox.Show(
                            "Actualmente cuenta con una reservación abierta.\n¿Desea que el sistema ignore y continue con la emision de interjet?\n"
                                .ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.Comunicator.SendCommand("I");
                        this.StartBackGroundWorker();
                    }
                }
            }




        }

        /// <summary>
        /// Gets or sets the command builder.
        /// </summary>
        /// <value>
        /// The command builder.
        /// </value>
        private InterJetCommandBuilder CommandBuilder
        {
            get;
            set;
        }



        /// <summary>
        /// 
        /// </summary>
        private InterJetFactoryCommandBuilder _commandFactory;

        /// <summary>
        /// Gets the command factory.
        /// </summary>
        private InterJetFactoryCommandBuilder CommandFactory
        {
            get
            {
                return this._commandFactory ?? (this._commandFactory = new InterJetFactoryCommandBuilder());
            }
        }

        private BackgroundWorker _background = new BackgroundWorker
                                                   {

                                                       WorkerSupportsCancellation = true
                                                   };

        /// <summary>
        /// Gets the command sender worker.
        /// </summary>
        private BackgroundWorker CommandSenderWorker
        {

            get { return _background; }
        }


        private void ContinueProcess()
        {
            var currentTicket = (InterJetTicket)this.Session["CurrentTicket"];
            if (currentTicket != null)
            {
                if (currentTicket.PassangerNumberRecord.NeedBillAddress)
                {
                    //TODO: ucBillingAdressEmission Modificar cuando cae de una reserva de interjet en test y en proceso normal

                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.UserControl, "ucBillingAdressEmission",
                                                    this.UserControl.Parameter, null);
                }
                else
                {
                    //TODO: ucAllQualityControls Modificar cuando cae de una reserva de interjet en test y en proceso normal

                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, UserControl, "ucAllQualityControls", this.UserControl.Parameter,
                                                    null);
                }
            }
        }
        /// <summary>
        /// Handles the RunWorkerCompleted event of the _background control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void _background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                StopBackGroundWorker();
                ContinueProcess();

            }
            finally
            {
                this.CommandSenderWorker.Dispose();
                //this.Timer.Dispose();
                //this.ProgressBar.Dispose();



            }
        }


        /// <summary>
        /// Gets the ticket.
        /// </summary>
        /// <returns></returns>
        private InterJetTicket GetTicket()
        {
            var ticket = this.Session["CurrentTicket"] != null ? (InterJetTicket)this.Session["CurrentTicket"] : null;

            return ticket;

        }
        /// <summary>
        /// TODO: Al crear el Passanger Number Record Verificar que pasa si esta null.
        /// </summary>
        private void SetPassangerNumberRecord(string dk)
        {
            InterJetTicket currentTicket = this.GetTicket();
            if (currentTicket != null)
            {
                currentTicket.PassangerNumberRecord.DK = dk;
                currentTicket.PassangerNumberRecord.Passangers = currentTicket.Passangers;
                currentTicket.PassangerNumberRecord.Segments = currentTicket.Flights;
                this.Session["CurrentTicket"] = currentTicket;
            }

        }


        /// <summary>
        /// Gets a value indicating whether this instance has credentials.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has credentials; otherwise, <c>false</c>.
        /// </value>
        private bool HasCredentials
        {

            get { return this.Session["Credentials"] != null; }
        }

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        private InterJetCreditCardFields Credentials
        {

            get
            {
                if (HasCredentials)
                {

                    var credentials = (InterJetCreditCardFields)this.Session["Credentials"];

                    return credentials;
                }
                return new InterJetCreditCardFields();


            }
        }


        /// <summary>
        /// Gets the total passanger inter jet.
        /// </summary>
        private int TotalPassangerInterJet
        {
            get
            {

                if (this.Session.Count > 0)
                {
                    InterJetTicket ticket = this.Session["CurrentTicket"] != null ? (InterJetTicket)this.Session["CurrentTicket"] : new InterJetTicket();
                    return ticket.Passangers.Total;
                }
                else
                {
                    return 0;
                }

            }
        }


        /// <summary>
        /// Handles the DoWork event of the _background control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void _background_DoWork(object sender, DoWorkEventArgs e)
        {
            SendCommandsToSabre();
        }

        private void StartBackGroundWorker()
        {

            InterJetHelper.Ticket = Ticket;
            this.CommandSenderWorker.DoWork += _background_DoWork;
            this.CommandSenderWorker.RunWorkerCompleted += _background_RunWorkerCompleted;
            this.Timer.Interval = 100;
            this.Timer.Tick += new EventHandler(Timer_Tick);
            this.Timer.Enabled = true;
            this.Timer.Start();
            this.MainContainer.Visible = false;
            this.ReservationPictureBox.Visible = true;
            StartAnimation(true);
            this.CommandSenderWorker.RunWorkerAsync();


        }



        void Timer_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(this.ProgressBar.Percentage);
        }



        /// <summary>
        /// Stops the back ground worker.
        /// </summary>
        private void StopBackGroundWorker()
        {
            this.CommandSenderWorker.DoWork -= _background_DoWork;
            this.CommandSenderWorker.RunWorkerCompleted -= _background_RunWorkerCompleted;
            this.Timer.Tick -= new EventHandler(Timer_Tick);
            this.Timer.Enabled = false;
            this.Timer.Stop();


        }
        /// <summary>
        /// Envia los commandos al API de sabre.
        /// </summary>
        private void SendCommandsToSabre()
        {
            try
            {




                this.CommandBuilder = new InterJetCustomerCommand();
                this.CommandBuilder.Ticket = this.Ticket;
                this.CommandBuilder.Build();

                this.CommandBuilder = new InterJetPassangersCommands();
                this.CommandBuilder.Ticket = this.Ticket;
                this.CommandBuilder.Build();


                //TODO: InterJet Migration - Iniciar proceso solo cuando no esta test el control.
                //Agrega Nombres de Pasajeros
                //this.CommandBuilder = this.CommandFactory.CreateAddPassangerCommandBuilder();
                //this.CommandBuilder.Ticket = this.Ticket;
                //this.CommandBuilder.Build();

                //Agregar Intinerario
                this.CommandBuilder = this.CommandFactory.CreateAddItineraryCommandBuilder();
                this.CommandBuilder.Ticket = this.Ticket;
                this.CommandBuilder.Build();


                this.CommandBuilder = this.CommandFactory.CreateAddSSRCommandBuilder();
                this.CommandBuilder.Ticket = this.Ticket;
                this.CommandBuilder.Build();

                //Agregar tarifa manual
                this.CommandBuilder = this.CommandFactory.CreateAddStoredUserFeeCommandBuilder();
                this.CommandBuilder.Ticket = this.Ticket;
                this.CommandBuilder.Build();
                // Agregar Tiempo Limite.
                this.CommandBuilder = this.CommandFactory.CreateAddLimitTimeEntryCommandBuilder();
                this.CommandBuilder.Ticket = this.Ticket;
                this.CommandBuilder.Build();
            }
            catch (Exception excepton)
            {

            }
        }
    }
}
