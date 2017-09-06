using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetBoletageReceivedHandler : InterJetFormHandler
    {
        public PictureBox Loading { get; set; }

        /// <summary>
        /// Closes the and invoiced reservation.
        /// </summary>
        public void CloseAndInvoicedReservation()
        {

            StartBackGroundWorker();

        }

        public PictureBox ReservationEndPicture { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private readonly BackgroundWorker _closeReservationWorker = new BackgroundWorker();

        private BackgroundWorker CloseReservationWorker
        {

            get { return _closeReservationWorker; }
        }

        private void StartBackGroundWorker()
        {
            this.MainPanel.Visible = false;
            this.StartAnimation(true);
            CloseReservationWorker.DoWork += new DoWorkEventHandler(CloseReservationWorker_DoWork);
            CloseReservationWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CloseReservationWorker_RunWorkerCompleted);
            //Timer.Tick += new EventHandler(Timer_Tick);
            //Timer.Interval = 100;
            //Timer.Enabled = true;
            //Timer.Start();
            CloseReservationWorker.RunWorkerAsync();

        }

        /// <summary>
        /// Stops the back ground woker.
        /// </summary>
        private void StopBackGroundWoker()
        {
            CloseReservationWorker.DoWork -= new DoWorkEventHandler(CloseReservationWorker_DoWork);
            CloseReservationWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(CloseReservationWorker_RunWorkerCompleted);
            //Timer.Enabled = false;
            ////Timer.Stop();
            //Timer.Tick -= new EventHandler(Timer_Tick);
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        private void StartAnimation(bool visible)
        {

            this.Loading.Visible = visible;
            this.LoadingLabel.Visible = visible;
            this.ReservationEndPicture.Visible = visible;

        }

        /// <summary>
        /// Gets or sets the loading label.
        /// </summary>
        /// <value>
        /// The loading label.
        /// </value>
        public Label LoadingLabel { get; set; }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Timer_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(this.ProgressBar.Percentage);
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the CloseReservationWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void CloseReservationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.StopBackGroundWoker();

            }
            finally
            {
                ClearAll();
                this.CloseReservationWorker.Dispose();
                this.ProgressBar.Dispose();
                this.Timer.Dispose();
            }
        }

        /// <summary>
        /// Handles the DoWork event of the CloseReservationWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void CloseReservationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CommandBuilder.Build();
        }


        /// <summary>
        /// Clears all.
        /// </summary>
        private void ClearAll()
        {

            ucAvailability.IsInterJetProcess = false;

            ucMenuReservations.EnabledMenu = true;
            ucAllQualityControls.globalPaxNumber = 0;

            ucAllQualityControls.counter = 0;
            ucAllQualityControls.chargePerService.Clear();
            ucAllQualityControls.remarksIntegra.Clear();
            ucAllQualityControls.passengerPositionValues.Clear();
            ucAllQualityControls.Origin = string.Empty;
            ucAllQualityControls.BusinessUnit = string.Empty;
            ucAllQualityControls.TicketsJustifications = string.Empty;
            ucAllQualityControls.workerNumberArray.Clear();
            ucTicketEmissionBuildCommand.commandSent = false;
            ucTicketsEmissionInstructions.OSI = string.Empty;
            userControlsPreviousValues.TicketsEmissionInstructionsParameters = null;
            ucQualitiesByPax.Passengers = string.Empty;
            ucQualitiesByPax.sabreConcat = string.Empty;
            ucFirstValidations.Attribute1 = null;
            ucFirstValidations.DK = null;
            ucInterJetPaymentForm.IsClientCard = false;
            ucInterJetPaymentForm.IsCTSCard = false;

        }



        private InterJetCommandBuilder _commandBuilder;

        //<summary>
        //Gets the command builder.
        //</summary>
        private InterJetCommandBuilder CommandBuilder
        {
            get
            {
                return _commandBuilder ?? (_commandBuilder = new InterJetAddDINCommand
                {
                    Ticket = InterJetHelper.Ticket
                });
            }
        }






        public System.Windows.Forms.Timer Timer
        {
            get;
            set;
        }

        public GradProg.GradProg ProgressBar
        {
            get;
            set;
        }

        public Panel MainPanel
        {
            get;
            set;

        }

        public override void RecoverFromError()
        {

        }
    }
}
