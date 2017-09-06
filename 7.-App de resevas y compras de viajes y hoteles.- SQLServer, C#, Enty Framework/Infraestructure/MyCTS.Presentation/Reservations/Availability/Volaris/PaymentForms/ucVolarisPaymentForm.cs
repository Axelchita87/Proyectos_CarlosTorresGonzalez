using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms;
using MyCTS.Entities;
using System.Threading;
using MyCTS.Presentation.Reservations.Availability.Volaris.ProfileCreditCardSelector;
using MyCTS.Services.Contracts.Volaris.EventArguments;
using MyCTS.Presentation.Reservations.Availability.Volaris.ReservationPreviewExpander;
using MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder;

namespace MyCTS.Presentation
{
    public partial class ucVolarisPaymentForm : CustomUserControl, IVolarisPaymentFormView
    {

        /// <summary>
        /// 
        /// </summary>
        private VolarisPaymentFormPresenter _presenter;
        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPaymentForm"/> class.
        /// </summary>
        public ucVolarisPaymentForm()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Handles the Load event of the ucVolarisPaymentForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucVolarisPaymentForm_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisPaymentFormPresenter()
                             {
                                 Repository = new VolarisPaymentFormRepository(),
                                 View = this,
                                 OnWebServiceCallStartDelegate = OnWebServiceCallStartDelegate,
                                 OnWebServiceCallCompletedDelegate = OnWebServiceCallCompletedDelegate,
                                 OnReservationCompleted = OnReservationCompleted,
                                 OnPaymentComplete = OnPaymentComplete
                             };
            ucVolarisErrorRecovery1.Cancel += UcVolarisErrorRecovery1OnCancel;
            ucVolarisErrorRecovery1.Retry += UcVolarisErrorRecovery1OnRetry;
            StartLoadingWorker();
            ucFirstValidations.NameProfile = Reservation.Profile.SecondLevelProfile;
            ucFirstValidations.DK = Reservation.CustomerDk.Value;
            ucFirstValidations.GetCreditCards();

            LogProductivity.LogTransaction(Login.Agent, "4-Desplego la forma de pago.--Volaris");

        }

        private void UcVolarisErrorRecovery1OnRetry(object sender, EventArgs eventArgs)
        {
            waitingForControls1.Visible = false;
            ucVolarisErrorRecovery1.Visible = false;
            loadingControl.Visible = false;
            this.mainContainer.Visible = true;
        }

        private void UcVolarisErrorRecovery1OnCancel(object sender, EventArgs eventArgs)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucAvailability",
                                     null, null);
        }

        /// <summary>
        /// Called when [payment complete].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnPaymentComplete(object sender, EventArgs eventArgs)
        {

            waitingForControls1.Visible = false;
            loadingControl.Visible = false;

            if (Reservation.Payment.Status == VolarisPaymentStatus.Approved)
            {
                var cardCaptureInformation = mainContainer.Controls.OfType<ucPaymentInformationCapture>();
                if (cardCaptureInformation != null && cardCaptureInformation.Any())
                {
                    var controlInformationCapture = cardCaptureInformation.FirstOrDefault();
                    const string cardType = "5.</C28*{0}/>";
                    //if (controlInformationCapture != null && controlInformationCapture.IsCTSCreditCard)
                    //{
                    //    Reservation.Remarks.Add(string.Format(cardType, "CTS"));
                    //}
                    if (controlInformationCapture != null && controlInformationCapture.IsClientCreditCard)
                    {
                        Reservation.Remarks.Add(string.Format(cardType, "CLIENTE"));
                    }

                }
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisBookingConfirmation",
                                                this.Reservation, null);
            }

        }


        /// <summary>
        /// Called when [reservation completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnReservationCompleted(object sender, EventArgs eventArgs)
        {
            waitingForControls1.Visible = true;
            loadingControl.Visible = false;
            StartLoadingWorker();
        }


        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _loadingWorker;

        /// <summary>
        /// Starts the loading worker.
        /// </summary>
        private void StartLoadingWorker()
        {

            _loadingWorker = new BackgroundWorker();
            _loadingWorker.DoWork += _loadingWorker_DoWork;
            _loadingWorker.RunWorkerCompleted += _loadingWorker_RunWorkerCompleted;
            _loadingWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _loadingWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void _loadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                waitingForControls1.Visible = false;
                CreateDynamicPanels();
                ShowProfileCards(false);


            }
            finally
            {
                _loadingWorker.Dispose();
            }

        }

        private void ShowProfileCards(bool showWindows)
        {
            if (Reservation.Profile.HasCreditCards)
            {

                using (var profileCards = new frmVolarisCreditCardsProfile { })
                {
                    profileCards.SetProfile(Reservation.Profile);
                    profileCards.ShowDialog();
                    if (profileCards.IsCardSelected)
                    {
                        SetProfileCard(profileCards.SelectedCreditCard);
                    }

                    else
                    {

                        if (showWindows)
                        {
                            MessageBox.Show(string.Format("El perfil {0} de segundo nivel no tiene tarjetas asociadas",
                                                          Reservation.Profile.SecondLevelProfile), "Perfil sin tarjetas", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }



        private void SetProfileCard(VolarisProfileCreditCard card)
        {

            var paymentInfo = mainContainer.Controls.OfType<ucPaymentInformationCapture>().FirstOrDefault();
            if (paymentInfo != null)
            {
                paymentInfo.SetVolarisProfileCard(card);
            }

        }

        private const int ColumnIndex = 0;


        /// <summary>
        /// Creates the dynamic panels.
        /// </summary>
        private void CreateDynamicPanels()
        {
            const int expanderRowIndex = 0;
            var expander = new ucVolarisReservationExpander
                               {
                                   CloseUpEventHandler = CloseUpEventHandler,
                                   PopupEventHandler = PopupEventHandler,

                               };
            var reservationResumeControl = new ucVolarisPreviousReservationResume
                                               {
                                                   ShowPassangersFullName = true
                                               };
            reservationResumeControl.SetReservation(Reservation);
            expander.ControlToDisplay = reservationResumeControl;


            mainContainer.Controls.Add(expander, ColumnIndex, expanderRowIndex);


            int paymentInfoRowIndex = AddRowToMainContainer();

            mainContainer.Controls.Add(new ucPaymentInformationCapture
                                           {
                                               TotalToPay = Reservation.Itinerary.TotalPrice,
                                               OnShowProfileCardsEvent = OnShowProfileCardsEvent
                                           }, ColumnIndex, paymentInfoRowIndex);

            int buttonPanelRowIndex = AddRowToMainContainer();
            buttonPanel.Visible = true;
            buttonPanel.Dock = DockStyle.Right;
            mainContainer.Controls.Add(this.buttonPanel, ColumnIndex, buttonPanelRowIndex);

            mainContainer.Visible = true;


        }

        private void OnShowProfileCardsEvent(object sender, EventArgs eventArgs)
        {
            ShowProfileCards(true);
        }

        private void PopupEventHandler(object sender, EventArgs eventArgs)
        {


        }

        private void CloseUpEventHandler(object sender, CloseUpEventArgs closeUpEventArgs)
        {

        }

        /// <summary>
        /// Adds the row to main container.
        /// </summary>
        /// <returns></returns>
        private int AddRowToMainContainer()
        {
            return mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        /// <summary>
        /// Handles the DoWork event of the _loadingWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void _loadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Called when [web service call completed delegate].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallCompletedDelegate(object sender, OnWebServiceCallCompletedEventArg e)
        {
            if (!e.Success)
            {

                if (!string.IsNullOrEmpty(e.ErrorMessage))
                {
                    ucVolarisErrorRecovery1.Error = e.ErrorMessage;
                    ucVolarisErrorRecovery1.Visible = true;
                }
            }
        }

        /// <summary>
        /// Called when [web service call start delegate].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnWebServiceCallStartDelegate(object sender, OnWebServiceCallStartEventArg e)
        {

            if (!string.IsNullOrEmpty(e.Message))
            {
                loadingControl.MessageToShow = e.Message;
            }
        }

        #region Miembros de IBaseView


        /// <summary>
        /// Validates the input.
        /// </summary>
        public void ValidateInput()
        {
            var controls = this.mainContainer.Controls.OfType<IBaseView>();

            if (controls.Any())
            {
                foreach (var control in controls)
                {
                    control.ValidateInput();
                }
            }
            IsValid = controls.All(c => c.IsValid);
        }

        public bool IsValid { get; set; }

        #endregion

        #region Miembros de IVolarisPaymentFormView

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
                    reservation.Payment.CreditCardInformation = this.CreditCardInformation;
                    reservation.Payment.Owner = this.CreditCardOwner;
                    return reservation;
                }

                return new VolarisReservation();
            }
            set { Parameter = value; }
        }

        /// <summary>
        /// Gets the credit card information.
        /// </summary>
        private VolarisCreditCardInformation CreditCardInformation
        {
            get
            {

                var paymentCaptureControl = PaymentCaptureControl;
                if (paymentCaptureControl != null)
                {
                    return paymentCaptureControl.CreditCardInformation;

                }
                return new VolarisCreditCardInformation();
            }
        }

        /// <summary>
        /// Gets the credit card owner.
        /// </summary>
        private VolarisCreditCardOwner CreditCardOwner
        {
            get
            {
                var paymentCaptureControl = PaymentCaptureControl;
                if (paymentCaptureControl != null)
                {
                    return paymentCaptureControl.Owner;

                }
                return new VolarisCreditCardOwner();

            }
        }

        private ucPaymentInformationCapture PaymentCaptureControl
        {
            get
            {
                return this.mainContainer.Controls.OfType<ucPaymentInformationCapture>().FirstOrDefault();
            }
        }

        #endregion

        private void buyButton_Click(object sender, EventArgs e)
        {

            this.ValidateInput();
            if (IsValid)
            {

                this.waitingForControls1.Visible = false;
                this.loadingControl.Visible = true;
                this.mainContainer.Visible = false;
                _presenter.MakePayment(Reservation);
                LogProductivity.LogTransaction(Login.Agent, string.Format("4-Click en el boton comprar reservación con una cantidad de {0}.--Volaris", Reservation.Itinerary.TotalFinalPrice));
            }
        }



    }
}
