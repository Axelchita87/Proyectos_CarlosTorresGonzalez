using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.Collections;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;
using System.ComponentModel;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetBillEmissionFormHandler : InterJetFormHandler
    {


        public System.Windows.Forms.Timer Timer
        {
            get;
            set;
        }

        public PictureBox EndReservationPictureBox { get; set; }

        public PictureBox Loading { get; set; }
        public Panel MainPanel { get; set; }
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

        private BackgroundWorker _worker = new BackgroundWorker
                                               {

                                                   WorkerSupportsCancellation = true
                                               };
        private BackgroundWorker CommandWorker
        {
            get { return _worker; }
        }

        private void StartBackGroundWorker()
        {
            StartAnimation(true);
            //Timer.Interval = 100;
            //Timer.Tick += new EventHandler(Timer_Tick);
            //Timer.Enabled = true;
            //Timer.Start();
            CommandWorker.DoWork += new DoWorkEventHandler(CommandWorker_DoWork);
            CommandWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CommandWorker_RunWorkerCompleted);
            CommandWorker.RunWorkerAsync();
        }

        private void StopBackGroundWorker()
        {

            CommandWorker.DoWork -= new DoWorkEventHandler(CommandWorker_DoWork);
            CommandWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(CommandWorker_RunWorkerCompleted);
            //Timer.Tick -= new EventHandler(Timer_Tick);
            //Timer.Enabled = false;
            //Timer.Stop();

        }

        void Timer_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(this.ProgressBar.Percentage);
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the CommandWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void CommandWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.StopBackGroundWorker();

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucConcludeReservation", this.CurrentUserControl.Parameter, null);

            }
            finally
            {
                this.CommandWorker.Dispose();
                this.Timer.Dispose();
                this.ProgressBar.Dispose();
            }
        }

        /// <summary>
        /// Handles the DoWork event of the CommandWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void CommandWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendCommnad();
        }

        private void StartAnimation(bool Enabled)
        {
            //this.ProgressBar.Visible = Enabled;
            Loading.Visible = Enabled;
            EndReservationPictureBox.Visible = Enabled;
            this.WaitingLabel.Visible = Enabled;

        }




        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                if (this.CurrentUserControl.Parameter != null)
                {
                    var session = (InterJetSession)this.CurrentUserControl.Parameter;
                    return session.Session;
                }
                else
                {
                    return new Hashtable();
                }

            }
        }

        /// <summary>
        /// Gets the priced ticket.
        /// </summary>
        private InterJetTicket PricedTicket
        {
            get
            {

                return this.Session["CurrentTicket"] != null ? (InterJetTicket)this.Session["CurrentTicket"] : new InterJetTicket();

            }
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        private InterJetCommandBuilder Command
        {
            get;
            set;

        }

        public InterJetFactoryCommandBuilder Factory
        {
            get
            {
                return new InterJetFactoryCommandBuilder();
            }
        }

        public void Initialize()
        {

        }


        /// <summary>
        /// Sends the commnad.
        /// </summary>
        public void SendCommnad()
        {
            this.Command = this.Factory.CreateAddContactPhoneCommand();
            this.Command.Ticket = this.PricedTicket;
            this.Command.Build();


            this.Command = this.Factory.CreadAddQualityRemarkCommandBuilder();
            this.Command.Ticket = this.PricedTicket;
            this.Command.Build();

            this.Command = this.Factory.CreateAddAccountingLineCommandBuilder();
            this.Command.Ticket = this.PricedTicket;
            this.Command.Build();

            this.Command = this.Factory.CreateAddChargeOfServiceCommandBuilder();
            this.Command.Ticket = this.PricedTicket;
            this.Command.Build();
            if (this.PricedTicket.PassangerNumberRecord.NeedBillAddress)
            {
                this.Command = this.Factory.CreateAddBillingAddresCommandBuilder();
                this.Command.Ticket = this.PricedTicket;
                this.Command.Build();
            }

        }
        /// <summary>
        /// Finishes the reservation.
        /// </summary>
        public void FinishReservation()
        {
            this.MainPanel.Visible = false;
            StartBackGroundWorker();
        }


        public override void RecoverFromError()
        {

        }
    }
}
