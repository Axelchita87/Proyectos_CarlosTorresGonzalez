using System;
using System.Linq;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContextSolver;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.EventArguments;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.Volaris.ProfileCreditCardSelector;
using MyCTS.Services.Contracts.Volaris.EventArguments;

namespace MyCTS.Presentation
{
    public partial class ucVolarisPassangerCapture : CustomUserControl, IVolarisPassangerCaptureView
    {

        /// <summary>
        /// 
        /// </summary>
        private VolarisPassangerCapturePresenter _presenter;
        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPassangerCapture"/> class.
        /// </summary>
        public ucVolarisPassangerCapture()
        {
            InitializeComponent();

        }



        /// <summary>
        /// Handles the Load event of the ucVolarisPassangerCapture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void ucVolarisPassangerCapture_Load(object sender, EventArgs args)
        {

            continueButton.Click += continueButton_Click;
            _presenter = new VolarisPassangerCapturePresenter()
                             {

                                 Context = new DynamicPassangerCaptureWinFormControlBuilder()
                                               {
                                                   OnWorkCompleted = OnWorkCompleted
                                               },
                                 Repository = new VolarisPassangerCaptureRepository(),
                                 View = this,
                                 OnWebServiceCallStart = OnWebServiceCallStart,
                                 OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                 OnReservationCreatedComplete = OnReservationCreatedComplete
                             };
            ucVolarisErrorRecovery1.Cancel += new EventHandler(ucVolarisErrorRecovery1_Cancel);
            ucVolarisErrorRecovery1.Retry += new EventHandler(ucVolarisErrorRecovery1_Retry);
            _presenter.BuildDynamicControls();
            LogProductivity.LogTransaction(Login.Agent, "3-Desplego Captura de pasajeros de volaris.--Volaris");

        }

        void ucVolarisErrorRecovery1_Retry(object sender, EventArgs e)
        {
            this.container.Visible = true;
            this.buttonPanel.Visible = true;
            this.ucVolarisErrorRecovery1.Error = "";
            this.ucVolarisErrorRecovery1.Visible = false;
        }

        void ucVolarisErrorRecovery1_Cancel(object sender, EventArgs e)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucAvailability", null, null);
        }

        /// <summary>
        /// Called when [reservation created complete].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnReservationCreatedComplete(object sender, OnReservationCompletedEventArg e)
        {
            if (Reservation.Status == VolarisReservationStatus.Accepted)
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisCustomerDK", this.Reservation, null);
            }

        }

        /// <summary>
        /// Called when [web service call completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallCompleted(object sender, OnWebServiceCallCompletedEventArg e)
        {


            if (!e.Success)
            {
                this.container.Visible = false;
                this.buttonPanel.Visible = false;
                this.ucVolarisErrorRecovery1.Error = e.ErrorMessage;
                this.ucVolarisErrorRecovery1.Visible = true;
                this.loadingControl1.Visible = false;
                this.waitingForControls1.Visible = false;


            }
        }

        /// <summary>
        /// Called when [web service call start].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallStart(object sender, OnWebServiceCallStartEventArg e)
        {
            if (!string.IsNullOrEmpty(e.Message))
            {

                this.loadingControl1.MessageToShow = e.Message;
            }
        }

        /// <summary>
        /// Handles the Click event of the continueButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void continueButton_Click(object sender, EventArgs e)
        {
            if (ValidateAll())
            {
                this.loadingControl1.Visible = true;
                BuildReservation();
                this.container.Visible = false;
                this.buttonPanel.Visible = false;
                this.waitingForControls1.Visible = false;
                _presenter.CreateReservation(Reservation);
                //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisPaymentForm", this.Reservation, null);
            }

        }


        /// <summary>
        /// Builds the reservation.
        /// </summary>
        private void BuildReservation()
        {

            Reservation.Passangers.Clear();
            Reservation.Passangers = GetPassangers();
            Reservation.Contact = GetContactInformation();
        }

        /// <summary>
        /// Gets the contact information.
        /// </summary>
        /// <returns></returns>
        private VolarisContact GetContactInformation()
        {
            var contact = new VolarisContact();
            var table = GetTable();
            if (table != null)
            {
                var contactInformation = table.Controls.OfType<ucVolarisContactInformationCapture>().FirstOrDefault();
                if (contactInformation != null)
                {

                    contact = contactInformation.Contact;
                }


            }

            return contact;
        }

        /// <summary>
        /// Gets the passangers.
        /// </summary>
        /// <returns></returns>
        private VolarisPassangers GetPassangers()
        {
            var table = GetTable();
            if (table != null)
            {
                var passangers = new VolarisPassangers();
                var controls = table.Controls.OfType<ucVolarisPassangerCaptureForm>().ToList();
                if (controls.Any())
                {
                    foreach (var passangerControl in controls)
                    {
                        passangers.Add(passangerControl.Passanger);
                    }

                }
                return passangers;
            }
            return null;
        }



        /// <summary>
        /// Validates all.
        /// </summary>
        /// <returns></returns>
        private bool ValidateAll()
        {
            var table = GetTable();
            if (table != null)
            {
                var controls = table.Controls.OfType<IBaseView>().ToList();
                if (controls != null && controls.Any())
                    foreach (var control in controls)
                    {
                        control.ValidateInput();
                    }
                return controls.All(c => c.IsValid);
            }
            return false;
        }



        /// <summary>
        /// Called when [work completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnWorkCompleted(object sender, EventArgs args)
        {
            var panel = sender as Panel;
            if (panel != null)
            {
                panel.Visible = false;
                var table = panel.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                if (table != null)
                {
                    const int column = 0;
                    int newRowForButtonPanel = table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    buttonPanel.Dock = DockStyle.Right;
                    table.Controls.Add(this.buttonPanel, column, newRowForButtonPanel);

                    var profileControl = table.Controls.OfType<ucVolarisProfileAssign>().FirstOrDefault();

                    if (profileControl != null)
                    {

                        profileControl.OnClickSearchProfile += OnSearchProfileButtonClick;
                        profileControl.OnSearchingProfileCompleted += OnSearchingProfileCompleted;
                        profileControl.OnRemoveProfile += OnRemoveProfile;

                    }

                }
                this.container.Controls.Add(panel);
                this.waitingForControls1.Visible = false;
                panel.Visible = true;
                this.volarisBanner1.Visible = true;
                this.buttonPanel.Visible = true;

            }
        }



        /// <summary>
        /// Called when [remove profile].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments.OnRemoveProfileEventArgs"/> instance containing the event data.</param>
        private void OnRemoveProfile(object sender, OnRemoveProfileEventArgs e)
        {
            var table = GetTable();
            if (table != null)
            {
                var passangerControl =
                    table.Controls.OfType<ucVolarisPassangerCaptureForm>().FirstOrDefault(
                        c => c.Passanger.Number == e.Passanger.Number);

                if (passangerControl != null)
                {
                    passangerControl.RemoveProfile();
                }

            }
        }

        /// <summary>
        /// Called when [searching profile completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments.OnSearchingProfileCompletedEventArgs"/> instance containing the event data.</param>
        private void OnSearchingProfileCompleted(object sender, OnSearchingProfileCompletedEventArgs e)
        {


            var table = GetTable();
            var passangerControl =
                table.Controls.OfType<ucVolarisPassangerCaptureForm>().First(
                    c => c.Passanger.Number == e.Passanger.Number);

            if (passangerControl != null)
            {
                passangerControl.HideLoadingProfile();
            }
            if (e.Found)
            {
                if (passangerControl != null)
                {
                    passangerControl.SetProfile(e.Profile);
                    this.Reservation.Profile = e.Profile;
                }
            }


        }




        public void OnSearchProfileButtonClick(object sender, SearchProfileEventArgument e)
        {
            var table = GetTable();
            if (table != null)
            {
                var passangerControl =
                    table.Controls.OfType<ucVolarisPassangerCaptureForm>().FirstOrDefault(
                        c => c.Passanger.Number == e.Passanger.Number);

                if (passangerControl != null)
                {
                    passangerControl.ShowLoadingProfile();
                }
            }

        }

        private TableLayoutPanel GetTable()
        {
            var panel = container.Controls.OfType<Panel>().FirstOrDefault();
            if (panel != null)
            {
                var table = panel.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                return table;
            }
            return null;

        }

        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }



        #region Miembros de IVolarisPassangerCaptureView

        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        /// <value>
        /// The reservation.
        /// </value>
        public VolarisReservation Reservation
        {
            get
            {
                var reservation = Parameter as VolarisReservation;
                if (reservation != null)
                {
                    return reservation;
                }
                return new VolarisReservation();

            }
            set { Parameter = value; }
        }

        #endregion

 



    }
}
