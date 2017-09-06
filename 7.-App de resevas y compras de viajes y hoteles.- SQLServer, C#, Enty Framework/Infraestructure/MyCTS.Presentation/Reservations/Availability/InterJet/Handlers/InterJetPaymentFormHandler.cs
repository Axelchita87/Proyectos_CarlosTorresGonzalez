using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using MyCTS.Presentation.Components;
using System.Collections;
using MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers;
using System.ComponentModel;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;
using System.Diagnostics;
using MyCTS.Business;
using MyCTS.Presentation.Reservations.Availability.InterJet.Exceptions;
using MyCTS.Presentation.Reservations.Availability.InterJet.Mailer;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.BookingManager;
#else
//using MyCTS.Services.BookingManagerTest;
using MyCTS.Services.BookingManager;
#endif
using MyCTS.Services.Contracts;
using Timer = System.Windows.Forms.Timer;
using MyCTS.Services.ValidateDKsAndCreditCards;
using MyCTS.Services.Contracts.Volaris;
using Exception = System.Exception;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetPaymentFormHandler : InterJetFormHandler
    {
        public static decimal amount;

        public Button ViewCreditCard { get; set; }
        public PictureBox PrincingPictureBox { get; set; }
        public PictureBox Loading { get; set; }
        public GroupBox MainGroupBox { get; set; }
        public Label StepLabel { get; set; }
        private const int TWO_MINUTES = 2;

        /// <summary>
        /// Gets or sets the form panel.
        /// </summary>
        /// <value>
        /// The form panel.
        /// </value>
        public Panel FormPanel{ get; set; }

        public static MyCTS.Entities.InterJetProfileCreditCard cardSelect;

        /// <summary>
        /// Shows the available cards.
        /// </summary>
        public void ShowAvailableCards()
        {
            if (HasProfile || VolarisSession.Profile)
            {
                if (InterJetProfile.CreditCards.HasCards)
                {
                    using (var form = new frmInterJetProfileCreditCards())
                    {
                        form.SetProfile(this.InterJetProfile);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.ShowDialog(this.CurrentUserControl);
                        SetSelectedCreditCardFromProfile(form.SelectedCreditCardCard);
                    }
                }
                else
                {
                    //ErrorProvider.SetError(ViewCreditCard, "El perfil no cuenta con tarjetas de credito para ser usadas.".ToUpper());
                    //ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                    //creditCardComboBox.SelectedValue = "VI";
                    //this.OnChangeSelectedTypeOfPayment(creditCardComboBox, null);
                    //throw new Exception("");
                }
            }
        }

        /// <summary>
        /// Gets or sets the panel to hide.
        /// </summary>
        /// <value>
        /// The panel to hide.
        /// </value>
        public Panel PanelToHide { get; set; }        
        public CheckBox CTSCheckBox { get; set; }
        public CheckBox ClientCheckBox { get; set; }
        public TextBox DkTextBox { get; set; }
        public TextBox CostCenter { get; set; }
        public TextBox EmployeeNumber { get; set; }


        /// <summary>
        /// Gets or sets the cotizando label.
        /// </summary>
        /// <value>
        /// The cotizando label.
        /// </value>
        public Label CotizandoLabel { get; set; }
        public Panel ButtonPanelToHide { get; set; }

        /// <summary>
        /// Gets or sets the current form.
        /// </summary>
        /// <value>
        /// The current form.
        /// </value>
        public CustomUserControl CurrentForm { get; set; }
        public Timer TimerProgressBar { get; set; }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                if (CurrentForm.Parameter != null)
                {
                    var session = (InterJetSession)this.CurrentForm.Parameter;
                    return session.Session;
                }
                else
                {//entro aqui
                    return new Hashtable();
                }
            }
        }

        private const string FIELD_NOT_FOUNDMESSAGE = "POR FAVOR CAPTURE EL CAMPO {0}.";
        public GradProg.GradProg ProgressBar { get; set; }
        public GroupBox GroupBoxToBox { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Func<InterJetPayment>> _paymentDispatcher;

        /// <summary>
        /// Gets the dispatch.
        /// </summary>
        private Dictionary<string, Func<InterJetPayment>> Dispatch
        {
            get
            {
                return _paymentDispatcher ?? (_paymentDispatcher = new Dictionary<string, Func<InterJetPayment>>
                                                                       {
                                                                           {
                                                                               "AMEX",
                                                                               () =>
                                                                               new InterJetAmericanExpressPayment()
                                                                               },
                                                                           {"VI", () => new InterJetVisaPayment()},
                                                                           {
                                                                               "TP",
                                                                               () =>
                                                                               new InterJetUniversalAirTravelPlanPayment
                                                                                   ()
                                                                               },
                                                                           {
                                                                               "MC",
                                                                               () => new InterJetMasterCardPayment()
                                                                               },
                                                                           {
                                                                               "A3",
                                                                               () =>
                                                                               new InterJetAmericanExpress3Months()
                                                                               },
                                                                               {
                                                                                   "AG",()=>new InterJetElectronicPursePayment()
                                                                               }
                                                                       });
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

        private string mensaje { get; set; }


        /// <summary>
        /// 
        /// </summary>
        private LogInterJetBL _businessLayer;

        /// <summary>
        /// Gets the bussiness layer.
        /// </summary>
        private LogInterJetBL BussinessLayer
        {
            get
            {
                return this._businessLayer ?? (this._businessLayer = new LogInterJetBL());
            }
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

        /// <summary>
        /// Obtiene el combobox de una forma
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ComboBox GetComboBox(string name)
        {
            return this.FormPanel.Controls.Find(name, true).FirstOrDefault() as ComboBox;
        }

        /// <summary>
        /// Obtiene el textobox que se encunetra en un panel.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private TextBox GetTextBox(string name)
        {
            return this.FormPanel.Controls.Find(name, true).FirstOrDefault() as TextBox;
        }

        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _backGroundWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the back ground worker.
        /// </summary>
        private BackgroundWorker PricingBackGroundWorker
        {
            get
            {
                return this._backGroundWorker;
            }
        }       

        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _buyingBackGroundWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the buying back ground worker.
        /// </summary>
        public BackgroundWorker BuyingBackGroundWorker
        {
            get
            {
                return this._buyingBackGroundWorker;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _bankResponseWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the bank response worker.
        /// </summary>
        private BackgroundWorker BankResponseWorker
        {
            get
            {
                return this._bankResponseWorker;
            }
        }

        /// <summary>
        /// Handles the DoWork event of the BankResponseWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void BankResponseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool IsPaymentAprooved = false;
            var ticket = (InterJetTicket)e.Argument;
            //var currentBooking = null;
            mensaje = string.Empty;

            var flights = (InterJetSelectedFlights)this.Session["SelectedFlights"];

            while (mensaje.Contains("Pending") || mensaje == string.Empty)
            {
                ImpuestosBajoCosto.continuePayment = false;
                mensaje = string.Empty;
               var currentBooking = this.InterJetServiceManager.GetBooking(ticket.RecordLocator, flights.GetFlights());

                mensaje = "<br/> SERVICIO GETBOOKING <br/>" + "BookingInfo  <br/>" + "PaidStatus: " + currentBooking.BookingInfo.PaidStatus.ToString() + "<br/>"+
                    "BookingStatus" + currentBooking.BookingInfo.BookingStatus.ToString() + "<br/>" +
                    "Payment <br/>" + "Status: " + currentBooking.Payments[0].Status.ToString() + "<br/>" +
                    "AuthorizationStatus: " + currentBooking.Payments[0].AuthorizationStatus.ToString() + "<br/>" +
                    "BookingSum <br/>" + "BalanceDue: " + currentBooking.BookingSum.BalanceDue.ToString() + "<br/>"+
                    "BookingQueueInfo<br/>" ;
                    for(int a=0; a <currentBooking.BookingQueueInfos.Count(); a++)
                    {
                        mensaje = mensaje + "Notes: " + currentBooking.BookingQueueInfos[a].Notes.ToString() + "<br/>" +
                        "QueueName: " + currentBooking.BookingQueueInfos[a].QueueName.ToString() + "<br/>";
                    }
            }

            if (!string.IsNullOrEmpty(mensaje) && System.Configuration.ConfigurationManager.AppSettings["Ambiente"] == "PRUEBAS")
            {
                mensaje = "Approved";
            }

            if (!string.IsNullOrEmpty(mensaje) && (mensaje.Contains( "Approved") || mensaje.Contains("Confirmed") || mensaje.Contains("PaidInFull")))
            {
                if (CostumerAccountInterJet.DepartureTime < DateTime.Now.AddHours(24))
                {
                    this.InterJetServiceManager.Confirmation(ticket.RecordLocator);
                }

                ticket.IsAprooved = true;
                IsPaymentAprooved = true;
                e.Result = ticket;
            }
            else 
            {
                ticket.IsAprooved = false;
                e.Result = null;
                throw new DeclinedCreditCardException("Tarjeta declinada");

            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly BackgroundWorker _waitingBackGroundWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the waiting back ground worker.
        /// </summary>
        private BackgroundWorker WaitingBackGroundWorker
        {
            get { return _waitingBackGroundWorker; }
        }

        /// <summary>
        /// Starts the waiting back ground worker.
        /// </summary>
        /// <param name="messageToShow">The message to show.</param>
        public void StartWaitingBackGroundWorker(string messageToShow)
        {
            this.StartAnimation(messageToShow);
            this.WaitingBackGroundWorker.DoWork += WaitingBackGroundWorker_DoWork;
            this.WaitingBackGroundWorker.RunWorkerCompleted += WaitingBackGroundWorker_RunWorkerCompleted;
            this.WaitingBackGroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Sets the passanger number record.
        /// </summary>
        private void SetPassangerNumberRecord()
        {
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the WaitingBackGroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void WaitingBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ucMenuReservations.EnabledMenu = false;
                this.BussinessLayer.ApproveRecord(this.CurrentTicket.RecordLocator);
                SetPassangerNumberRecord();
               // this.InterJetServiceManager.EndSession();
                if (this.ClientCheckBox.Checked)
                {
                    this.CurrentTicket.Remarks.Add("5.</C28*CLIENTE/>");
                }

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm,
                                                "ucInterJetReservationConfirmationContainerControl",
                                                this.CurrentForm.Parameter, null);

            }
            finally
            {
                this.StopWatingBackGround();
                this.BankResponseWorker.Dispose();
                this.PricingBackGroundWorker.Dispose();
                this.BuyingBackGroundWorker.Dispose();
                this.WaitingBackGroundWorker.Dispose();
            }
        }

        /// <summary>
        /// Handles the DoWork event of the WaitingBackGroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void WaitingBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(900);
        }

        /// <summary>
        /// Stops the wating back ground.
        /// </summary>
        public void StopWatingBackGround()
        {
            this.WaitingBackGroundWorker.DoWork -= WaitingBackGroundWorker_DoWork;
            this.WaitingBackGroundWorker.RunWorkerCompleted -= WaitingBackGroundWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetMailer _mailer;

        /// <summary>
        /// Gets the mailer.
        /// </summary>
        private InterJetMailer Mailer
        {
            get { return _mailer ?? (_mailer = new InterJetMailer()); }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the BankResponseWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void BankResponseWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                decimal Amount;
                Amount = amount;
                this.BussinessLayer.Insert(this.CurrentTicket, Login.Agent, Amount);
                if (e.Error == null)
                {
                    LogProductivity.LogTransaction(Login.Agent, "-Respuesta de Confirmación de Compra OK--InterJet");
                    this.StartWaitingBackGroundWorker("Tarjeta de Credito Aceptada...");
                }
                else
                {
                    //this.ClearBooking();
                    if (e.Error is DeclinedCreditCardException)
                    {
                        this.DisplayCreditCardRejected();
                    }

                    if (e.Error is TimeoutException)
                    {
                        LogProductivity.LogTransaction(Login.Agent, "-Respuesta de Confirmación de Compra TimeOut--InterJet");
                        this.RecoverFromError("TimeOut en la respuesta del banco-INTERJET ERROR", true);
                    }
                    Mailer.Ticket = this.CurrentTicket;
                    Mailer.SendErrorEmail(e.Error.Message + mensaje);
                }
            }
            finally
            {
                StopBankResponseWorker();
            }
        }

        /// <summary>
        /// Displays the credit card rejected.
        /// </summary>
        private void DisplayCreditCardRejected()
        {
            LogProductivity.LogTransaction(Login.Agent, "-Respuesta de Confirmación de Compra La tarjeta fue rechazada por el banco al cual pertenece--InterJet");
            DialogResult result = MessageBox.Show("La tarjeta fue rechazada por el banco al cual pertenece.\n".ToUpper() +
                                        "Por favor intente de nuevo o cancele la operación.\n".ToUpper() +
                                        "Favor de llamar a Interjet para verificar con la siguiente reserva ".ToUpper() + ImpuestosBajoCosto.PNRBajoCosto + "\n" +
                                        "¿Desea reintentar de nuevo?\n".ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (!ImpuestosBajoCosto.continuePayment)
                {
                    MessageBox.Show("El tiempo para la realizar la compra de la reserva se agoto, favor de realzar nuevamente la reserva");
                    this.RecoverFromError();
                }
                else
                {
                    ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                    this.OnChangeSelectedTypeOfPayment(creditCardComboBox, null);
                    this.StopAnimation();
                }
            }
            else
            {

                this.RecoverFromError();
            }
        }





        /// <summary>
        /// Realiza de forma asincrona el proceo de venta.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void BuyingBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var credential = (InterJetCreditCardFields)e.Argument;
                this.Pay(credential);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        /// <summary>
        /// Starts the bank response worker.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        private void StartBankResponseWorker(InterJetTicket ticket)
        {
            this.BankResponseWorker.DoWork += new DoWorkEventHandler(BankResponseWorker_DoWork); // Escucha hasta que se haya aprobado o rechazado la reservacion.
            this.BankResponseWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BankResponseWorker_RunWorkerCompleted);
            this.BankResponseWorker.RunWorkerAsync(this.CurrentTicket);
        }

        /// <summary>
        /// Stops the bank response worker.
        /// </summary>
        private void StopBankResponseWorker()
        {
            this.BankResponseWorker.DoWork -= new DoWorkEventHandler(BankResponseWorker_DoWork); // Escucha hasta que se haya aprobado o rechazado la reservacion.
            this.BankResponseWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BankResponseWorker_RunWorkerCompleted);
        }



        /// <summary>
        /// Se ejecuta cuand se termina de ejecutar el DoWork
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void BuyingBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    this.StartAnimation("Comprobando Tarjeta de Crédito...");
                    this.StartBankResponseWorker(this.CurrentTicket);
                }
                else
                {
                    if (e.Error is TimeoutException)
                    {
                        this.RecoverFromError("Timeout al realizar el commit de la reserva-INTERJET ERROR", true);

                    }
                    else
                    {
                        //this.ClearBooking();
                        ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                        this.OnChangeSelectedTypeOfPayment(creditCardComboBox, null);
                        LogProductivity.LogTransaction(Login.Agent, string.Format("-Respuesta de Confirmación de Compra {0}--InterJet", e.Error.Message.ToUpper()));
                        string error =
                            string.Format("Ocurrió el siguiente error al crear la reservación :\n{0}.\n".ToUpper() +
                                          "¿Desea reintentar de nuevo?\n".ToUpper(), e.Error.Message.ToUpper());
                        DialogResult errorMessage = MessageBox.Show(error, Resources.Constants.MYCTS,
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (DialogResult.Yes == errorMessage)
                        {

                            this.OnChangeSelectedTypeOfPayment(creditCardComboBox, null);
                            this.StopAnimation();
                        }
                        else
                        {
                            this.RecoverFromError();
                        }
                    }
                }
            }
            finally
            {
                StopBuyingBankGroundWorker();
            }
        }


        /// <summary>
        /// OBtiene el precio del intinerario.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void BackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var ticket = (InterJetTicket)e.Argument;
            decimal total = this.InterJetServiceManager.GetItineraryPriceTest(ticket);
            ticket.BalanceToPay = total;
            ListTaxesInterjet.TotalPay = total;
            e.Result = total;
        }
        /// <summary>
        /// Se ejecuta el cuando se termnina de realiar la peticios de intinerario.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void BackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error is TimeoutException)
                {
                    base.RecoverFromError("TimeOut en la cotización de la reserva-INTERJET ERROR.", true);
                }
                else if(!VolarisSession.IsVolarisProcess)
                {

                    if (e.Error == null)
                    {
                        TextBox textboxTotal = this.GetTextBox("totalToPayTextBox");
                        textboxTotal.Text = ((decimal)e.Result).ToString("0.00");
                        //this.StopAnimation();
                        this.ShowDetallesDeVuelo();

                    }
                    else
                    {
                        string error =
                            string.Format("Ocurrió el siguiente error al crear la reservación :\n{0}.\n".ToUpper() +
                                          "¿Desea reintentar de nuevo?\n".ToUpper(), e.Error.Message.ToUpper());
                        DialogResult errorMessage = MessageBox.Show(error, Resources.Constants.MYCTS,
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (errorMessage == DialogResult.Yes)
                        {

                            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl,
                                                            "ucInterJetPassangerCaptureForm",
                                                            this.CurrentUserControl.Parameter, null);

                        }
                        else
                        {
                            this.RecoverFromError();
                        }
                    }
                }
            }
            finally
            {
                this.StopPricingBackGroundWorker();
            }
        }

        /// <summary>
        /// Inicializa la forma de pago.
        /// </summary>
        public void Initialize()
        {
            BindEvents();
            SetToolTips();
            if (!this.IsAlreadyPriced)
            {
                ImpuestosBajoCosto.continuePayment = true;
                this.StepLabel.Text = "Paso 5/8 - Resumen antes de la compra";
                LoadDataSources();
                if (!VolarisSession.IsVolarisProcess)
                {
                    if (HasProfile)
                    {
                        this.StartProfileWorker();//aqui entra para pedir creditcard
                    }
                    else
                    {
                        this.StartPricingBackGroundWorker(this.CurrentTicket);
                    }
                }

            }
            else
            {
                var flights = (InterJetSelectedFlights)this.Session["SelectedFlights"];

                TextBox textboxTotal = this.GetTextBox("totalToPayTextBox");
                TextBox textboxTotalPay = this.GetTextBox("txtTotalPay");
                LoadDataSources();
                this.StartProfileVolaris();
                StopAnimation();
                if (VolarisSession.IsVolarisProcess)
                    textboxTotal.Text = TwoDecimal((VolarisSession.Venta + VolarisSession.Extra).ToString());
                else
                {
                    this.CurrentTicket.BalanceToPay = ListTaxesInterjet.TotalPay;
                    textboxTotal.Text = this.CurrentTicket.BalanceToPay.ToString("0.00");
                    textboxTotalPay.Text = this.CurrentTicket.BalanceToPay.ToString("0.00");
                }
                this.ShowAvailableCards();
                this.MainGroupBox.Visible = true;
            }
            ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
            this.OnChangeSelectedTypeOfPayment(creditCardComboBox, null);

            if (HasCredentials)
            {
                PopulateCredentials();

            }
            else
            {

            }
        }

        //Cambiar a dos decimales
        private string TwoDecimal(string cantidad)
        {
            string newCantidad = string.Empty;
            try
            {
                string[] decimales = cantidad.Split('.');
                newCantidad = decimales[0] + "." + decimales[1].Substring(0, 2);
                return newCantidad;
            }
            catch (Exception ex)
            {
                newCantidad = cantidad + ".00";
                return newCantidad;
            }
        }

        /// <summary>
        /// Binds the events.
        /// </summary>
        private void BindEvents()
        {//genera eventos
            this.CTSCheckBox.CheckedChanged += (CTSCheckBox_CheckedChanged);
            this.ClientCheckBox.CheckedChanged += (ClientCheckBox_CheckedChanged);

            TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");

            creditCardNumberTextBox.KeyDown += OnKeyDownHandler;
            TextBox securityCoce = this.GetTextBox("securityCodeTextBox");

            securityCoce.KeyDown += OnKeyDownHandler;
            if (!VolarisSession.IsVolarisProcess)
            {
                TextBox creditCardOwner = this.GetTextBox("creditCardOwnerNameTextBox");

                creditCardOwner.KeyDown += OnKeyDownHandler;

                TextBox creditCardOwnerAddressTextBox = this.GetTextBox("creditCardOwnerAddressTextBox");

                creditCardOwnerAddressTextBox.KeyDown += OnKeyDownHandler;
                TextBox ownerPostalCode = this.GetTextBox("ownerPostalCode");

                ownerPostalCode.KeyDown += OnKeyDownHandler;
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            var textBox = sender as TextBox;
            this.ErrorProvider.SetError(textBox, "");
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    CommitTransaction();

                }
                catch (Exception ex)
                {
                    try
                    {
                        StopAnimation();

                    }
                    catch (Exception exception)
                    {

                        RecoverFromError();
                    }
                    //ucInterJetPaymentForm.PricedTicket = null;
                }

            }


        }



        /// <summary>
        /// Sets the tool tips.
        /// </summary>
        private void SetToolTips()
        {//genera tooltips para los indicativos
            ToolTiper.SetToolTip(CTSCheckBox, "Seleccione sí desea indicar que la tarjeta es de CTS.".ToUpper());
            ToolTiper.SetToolTip(ClientCheckBox, "Seleccione sí desea indicar que la tarjeta es del cliente.".ToUpper());

            ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
            ToolTiper.SetToolTip(creditCardComboBox, "Seleccione el tipo de tarjeta con la que se hara el pago.".ToUpper());

            TextBox totalToPayTextBox = this.GetTextBox("totalToPayTextBox");
            ToolTiper.SetToolTip(totalToPayTextBox, "Cantidad total a pagar.".ToUpper());

            TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
            ToolTiper.SetToolTip(creditCardNumberTextBox, "Número de la tarjeta de credito.".ToUpper());

            TextBox securityCoce = this.GetTextBox("securityCodeTextBox");
            ToolTiper.SetToolTip(securityCoce, "Número de seguridad de la tarjeta de credito.".ToUpper());

            if (!VolarisSession.IsVolarisProcess)
            {
                ComboBox monthExpiration = this.GetComboBox("expirationMonthComboBox");
                ToolTiper.SetToolTip(monthExpiration, "Mes de vencimiento de la tarjeta de credito".ToUpper());


                ComboBox expirationYearComboBox = this.GetComboBox("expirationYearComboBox");
                ToolTiper.SetToolTip(expirationYearComboBox, "Año de vencimiento de la tarjeta de credito".ToUpper());


                TextBox creditCardOwner = this.GetTextBox("creditCardOwnerNameTextBox");

                ToolTiper.SetToolTip(creditCardOwner, "Nombre de la persona a quien pertenece la tarjeta.".ToUpper());


                TextBox creditCardOwnerAddressTextBox = this.GetTextBox("creditCardOwnerAddressTextBox");

                ToolTiper.SetToolTip(creditCardOwnerAddressTextBox, "Dirección de la persona a quien pertenece la tarjeta.".ToUpper());

                TextBox ownerPostalCode = this.GetTextBox("ownerPostalCode");

                ToolTiper.SetToolTip(ownerPostalCode, "Codigo postal de la dirección.".ToUpper());
            }

            ToolTiper.SetToolTip(BackToPassangerButton, "Regresar a la captura de pasajeros, no se perdera la información de los segmentos vendidos.".ToUpper());
            ToolTiper.SetToolTip(ShowFlightDetailButton, "Desplegar la cotización detallada de los vuelos.".ToUpper());
            ToolTiper.SetToolTip(CommitButton, "Realizar la compra de la reservación de interjet e iniciar la reservación de Sabre.".ToUpper());
            ToolTiper.SetToolTip(ShowFlightDetailButton, "Desplegar la lista de tarjetas disponibles para el perfil seleccionado.".ToUpper());

        }

        public int getIndex(int year)
        {
            int index = 0;

            for (int i = 2012; i < 30000; i++)
            {
                if (year == i)
                {
                    return index;
                }
                index++;
            }
            return index;
        }

        /// <summary>
        /// Sets the selected credit card from profile.
        /// </summary>
        /// <param name="card">The card.</param>
        private void SetSelectedCreditCardFromProfile(MyCTS.Entities.InterJetProfileCreditCard card)
        {
            if (card != null)
            {
                cardSelect = card;
                var creditCardComboBox = this.GetComboBox("creditCardComboBox");
                var creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
                var expirationMonthComboBox = this.GetComboBox("expirationMonthComboBox");
                var expirationYearComboBox = this.GetComboBox("expirationYearComboBox");

                if (card.Type == MyCTS.Entities.InterJetProfileCrediCardType.AmericanExpress)
                    creditCardComboBox.SelectedIndex = 3;

                if (card.Type == MyCTS.Entities.InterJetProfileCrediCardType.UniversalTravelPlan)
                    creditCardComboBox.SelectedIndex = 1;

                if (card.Type == MyCTS.Entities.InterJetProfileCrediCardType.Visa)
                    creditCardComboBox.SelectedIndex = 0;

                if (card.Type == MyCTS.Entities.InterJetProfileCrediCardType.MasterCard)
                    creditCardComboBox.SelectedIndex = 2;

                creditCardNumberTextBox.Text = card.CreditCardNumber;

                if (!VolarisSession.IsVolarisProcess)
                {
                    var profile = (MyCTS.Entities.InterJetProfile)this.Session["Profile"];
                    var cvvTextBox = this.GetTextBox("securityCodeTextBox");
                    var creditCardNameUser = this.GetTextBox("creditCardOwnerNameTextBox");
                    var codePtTextBox = this.GetTextBox("ownerPostalCode");
                    var addressTextBox = this.GetTextBox("creditCardOwnerAddressTextBox");
                    var monthComboBox = this.GetComboBox("expirationMonthComboBox");
                    var yearComboBox = this.GetComboBox("expirationYearComboBox");

                    try
                    {
                        int month = card.ExpirationDate.Month;
                        int year = card.ExpirationDate.Year;

                        yearComboBox.SelectedIndex = getIndex(year);
                        monthComboBox.SelectedIndex = month - 1;
                    }
                    catch (Exception Err)
                    {

                        yearComboBox.SelectedIndex = 0;
                        monthComboBox.SelectedIndex = 0;
                    }

                    if (card.Address != null) addressTextBox.Text = card.Address; else { addressTextBox.Text = ""; }
                    if (card.CP != null) codePtTextBox.Text = card.CP; else { codePtTextBox.Text = ""; }

                    if (profile != null && card.Level == MyCTS.Entities.InterJetProfileCrediCardLevelType.Second)
                        creditCardNameUser.Text = card.titular;
                    else
                        creditCardNameUser.Text = "";

                    try
                    {
                        cvvTextBox.Text = new string(Common.toDecrypt(card.CVV).Where(char.IsDigit).ToArray());
                        cvvTextBox.Enabled = false;
                    }
                    catch (Exception Err)
                    {
                        cvvTextBox.Text = "";
                        // MessageBox.Show("Error en el campo CVV.");
                    }
                    SetCredentialsToSession();
                }
                else if (VolarisSession.IsVolarisProcess)
                {
                    var txtNameTitular = this.GetTextBox("txtNameTitular");
                    var securityCodeTextBox = GetTextBox("securityCodeTextBox");
                    var txtLastNameTitular = GetTextBox("txtLastNameTitular");
                    var txtEmail = this.GetTextBox("txtEmail");
                    var txtPhone = this.GetTextBox("txtPhone");
                    var txtAddress = this.GetTextBox("txtAddress");
                    var txtPostCode = this.GetTextBox("txtPostCode");
                    var txtCity = this.GetTextBox("txtCity");
                    var txtCountry = this.GetTextBox("txtCountry");
                    var cmbStateorProvidence = this.GetComboBox("cmbStateorProvidence");

                    if (card.CP != null) txtPostCode.Text = card.CP; else txtPostCode.Text = "";
                    if (card.Address != null) txtAddress.Text = card.Address; else txtAddress.Text = "";;
                    if (card.City != null) txtCity.Text = card.City; else txtCity.Text = "";;

                    txtNameTitular.Text = "";
                    txtLastNameTitular.Text = "";
                    txtCountry.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";

                    if (card.Level == MyCTS.Entities.InterJetProfileCrediCardLevelType.Second)
                    {
                        if (VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal != null)
                        {
                            txtNameTitular.Text = VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal.Name;

                            txtLastNameTitular.Text = VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal.LastName;

                            if (VolarisPassangerCaptureFormHandler.PasajeroSession.Pais != null)
                                txtCountry.Text = VolarisPassangerCaptureFormHandler.PasajeroSession.Pais;

                            if (VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal.Email != null)
                                txtEmail.Text = VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal.Email;

                            if (VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal.Phone != null)
                                txtPhone.Text = VolarisPassangerCaptureFormHandler.PasajeroSessionPersonal.Phone;
                        }
                    }

                    cmbStateorProvidence.SelectedIndex = 0;

                    for (int i = 1; i < cmbStateorProvidence.Items.Count; i++)
                    {
                        ListItem lst = (ListItem)cmbStateorProvidence.Items[i];

                        if (lst.Text.Substring(5) == card.State)
                        {
                            cmbStateorProvidence.SelectedIndex = i;
                            break;
                        }
                        else if (lst.Text.Substring(6) == card.State)
                        {
                            cmbStateorProvidence.SelectedIndex = i;
                            break;
                        }
                    }

                    try
                    {
                        securityCodeTextBox.Text = new string(Common.toDecrypt(card.CVV).Where(char.IsDigit).ToArray());
                        securityCodeTextBox.Enabled = false;
                    }
                    catch (Exception Err)
                    {
                        MessageBox.Show("Error en el campo CVV.");
                    }

                }

                if (card.ExpirationDate > DateTime.Now)
                {
                    expirationMonthComboBox.SelectedItem = card.ExpirationDate.Month < 10
                                                                ? string.Format("0{0}", card.ExpirationDate.Month)
                                                                : card.ExpirationDate.Month.ToString(
                                                                    CultureInfo.InvariantCulture);

                    expirationYearComboBox.SelectedItem =
                        card.ExpirationDate.Year.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
        /// <summary>
        /// Handles the CheckedChanged event of the ClientCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ClientCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            this.ErrorProvider.SetError(CTSCheckBox, "");
            this.ErrorProvider.SetError(ClientCheckBox, "");
            if (ClientCheckBox.Checked)
            {
                if (this.CTSCheckBox.Checked)
                {

                    this.CTSCheckBox.Checked = false;
                }

            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CTSCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void CTSCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ErrorProvider.SetError(CTSCheckBox, "");
            this.ErrorProvider.SetError(ClientCheckBox, "");
            if (this.CTSCheckBox.Checked)
            {
                if (this.ClientCheckBox.Checked)
                {

                    this.ClientCheckBox.Checked = false;
                    var frm = new frmGenericFOPCTS(0, string.Empty);
                    while (string.IsNullOrEmpty(ucFormPayment.C28))
                    {

                        frm.ShowDialog();
                        if (string.IsNullOrEmpty(ucFormPayment.C28))
                        {

                            var result = MessageBox.Show("Se debe indicar la forma de pago del cliente a CTS. \n" +
                                                          "Sí deseas indicar que la tarjeta es del cliente da click en Cancelar.",
                                           Resources.Constants.MYCTS, MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Information);
                            if (result == DialogResult.Cancel)
                            {
                                this.ClientCheckBox.Checked = true;
                                this.CTSCheckBox.Checked = false;
                                ucFormPayment.C28 = string.Empty;
                                break;

                            }

                        }

                    }
                }


            }
            else
            {
                ucFormPayment.C28 = string.Empty;
            }
        }

        /// <summary>
        /// Starts the pricing back ground worker.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        private void StartPricingBackGroundWorker(InterJetTicket ticket)
        {
            this.StartAnimation("Solicitando impuestos espere por favor..");
            this.PricingBackGroundWorker.DoWork += new DoWorkEventHandler(BackGroundWorker_DoWork);
            this.PricingBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackGroundWorker_RunWorkerCompleted);
            PricingBackGroundWorker.RunWorkerAsync(ticket);
        }


        /// <summary>
        /// Stops the pricing back ground worker.
        /// </summary>
        private void StopPricingBackGroundWorker()
        {

            this.PricingBackGroundWorker.DoWork -= new DoWorkEventHandler(BackGroundWorker_DoWork);
            this.PricingBackGroundWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BackGroundWorker_RunWorkerCompleted);
        }



        /// <summary>
        /// Gets the current ticket.
        /// </summary>
        public InterJetTicket CurrentTicket
        {

            get
            {
                if (Session["CurrentTicket"] != null)
                {
                    return (InterJetTicket)this.Session["CurrentTicket"];
                }
                return new InterJetTicket();
            }
            set { Session["CurrentTicket"] = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is already priced.
        /// </summary>
        /// <value>
        ///       <c>true</c> if this instance is already priced; otherwise, <c>false</c>.
        /// </value>
        private bool IsAlreadyPriced
        {
            get
            {
                //obtiene si ya se tiene un precio
                bool result = this.Session["IsAlreadyPriced"] != null && (bool)this.Session["IsAlreadyPriced"];
                if(VolarisSession.IsVolarisProcess)
                    result= true;
                return result;
            }
        }


        /// <summary>
        /// Inicializa la animación de compra o venta.
        /// </summary>
        /// <param name="msg"></param>
        private void StartAnimation(string msg)
        {
            this.ShowPanels(false);
            //this.ProgressBar.Visible = true;
            //this.ProgressBar.Minimum = 0;
            //this.ProgressBar.Maximum = 100;
            //this.ProgressBar.Percentage = 20;
            this.Loading.Visible = true;
            this.CotizandoLabel.Visible = true;
            this.CotizandoLabel.Text = msg;
            this.PrincingPictureBox.Visible = true;
            //this.TimerProgressBar.Start();
            //this.TimerProgressBar.Enabled = true;
        }


        /// <summary>
        /// Muestra o oculta el panel de los campos iniciales.
        /// </summary>
        /// <param name="show"></param>
        private void ShowPanels(bool show)
        {
            //this.PanelToHide.Visible = show;
            this.ButtonPanelToHide.Visible = show;
            this.GroupBoxToBox.Visible = show;

        }

        /// <summary>
        /// Para la animación cuando se esta ejecutando un proceso.
        /// </summary>
        public void StopAnimation()
        {
            this.CotizandoLabel.Visible = false;
            this.PrincingPictureBox.Visible = false;
            this.Loading.Visible = false;
            this.ShowPanels(true);

        }


        /// <summary>
        /// Muestra los detalles de los vuelos.
        /// </summary>
        public void ShowDetallesDeVuelo()
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetFlightsPricesDetailsForm", this.CurrentUserControl.Parameter, null);
        }

        public void SetGoToPayment()
        {
            this.Session["GoToPayment"] = true;
        }


        /// <summary>
        /// Gets the credit card credentials with out validation.
        /// </summary>
        /// <returns></returns>
        private InterJetCreditCardFields GetCreditCardCredentialsWithOutValidation()
        {
            var creditCardFields = new InterJetCreditCardFields();

            ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
            TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
            TextBox securityCodeTextBox = this.GetTextBox("securityCodeTextBox");
            TextBox totalAmount = this.GetTextBox("totalToPayTextBox");
            ComboBox expirationMonthComboBox = this.GetComboBox("expirationMonthComboBox");
            ComboBox expirationYearComboBox = this.GetComboBox("expirationYearComboBox");
            TextBox ownerNameTextBox = this.GetTextBox("creditCardOwnerNameTextBox");
            TextBox ownerPostalCodeTextBox = this.GetTextBox("ownerPostalCode");
            TextBox ownerAddresTextBox = this.GetTextBox("creditCardOwnerAddressTextBox");

            creditCardFields.DK = "";
            creditCardFields.IsCTS = this.CTSCheckBox.Checked;
            creditCardFields.IsClient = this.ClientCheckBox.Checked;
            if (creditCardComboBox.SelectedValue != null)
            creditCardFields.CreditCardName = creditCardComboBox.SelectedValue.ToString();
            creditCardFields.CreditCardNumber = creditCardNumberTextBox.Text;
            creditCardFields.SecurityCodeNumber = securityCodeTextBox.Text;
            creditCardFields.TotalAmount = Convert.ToDecimal(totalAmount.Text);
            amount = creditCardFields.TotalAmount;
            creditCardFields.CreditCardNumber = creditCardNumberTextBox.Text;

            string expirationDateString = string.Format("01/{0}/{1}", expirationMonthComboBox.SelectedItem.ToString(), expirationYearComboBox.SelectedItem.ToString());
            creditCardFields.ExpirationDate = DateTime.Parse(expirationDateString);
            creditCardFields.OwnerName = ownerNameTextBox.Text;
            creditCardFields.OwnerAddress = ownerAddresTextBox.Text;
            creditCardFields.PostalCode = ownerPostalCodeTextBox.Text;

            return creditCardFields;
        }

        /// <summary>
        /// Sets the credentials.
        /// </summary>
        public void SetCredentialsToSession()
        {
            InterJetCreditCardFields credentials = this.GetCreditCardCredentialsWithOutValidation();

            if (credentials != null)
            {
                this.Session["Credentials"] = credentials;

            }

        }

        /// <summary>
        /// Populates the credentials.
        /// </summary>
        private void PopulateCredentials()
        {
            var credentials = (InterJetCreditCardFields)this.Session["Credentials"];

            if (credentials != null)
            {
                ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
                TextBox securityCodeTextBox = this.GetTextBox("securityCodeTextBox");
                TextBox totalAmount = this.GetTextBox("totalToPayTextBox");
                ComboBox expirationMonthComboBox = this.GetComboBox("expirationMonthComboBox");
                ComboBox expirationYearComboBox = this.GetComboBox("expirationYearComboBox");
                TextBox ownerNameTextBox = this.GetTextBox("creditCardOwnerNameTextBox");
                TextBox ownerPostalCodeTextBox = this.GetTextBox("ownerPostalCode");
                TextBox ownerAddresTextBox = this.GetTextBox("creditCardOwnerAddressTextBox");

                creditCardComboBox.SelectedValue = credentials.CreditCardName;
                creditCardNumberTextBox.Text = credentials.CreditCardNumber;
                securityCodeTextBox.Text = credentials.SecurityCodeNumber;

                expirationMonthComboBox.SelectedItem =
                    credentials.ExpirationDate.Month < 10 ?
                    string.Format("0{0}", credentials.ExpirationDate.Month)
                    : credentials.ExpirationDate.Month.ToString(CultureInfo.InvariantCulture);
                expirationYearComboBox.SelectedItem =
                    credentials.ExpirationDate.Year.ToString(CultureInfo.InvariantCulture);

                ownerNameTextBox.Text = credentials.OwnerName;

                ownerPostalCodeTextBox.Text = credentials.PostalCode;
                ownerAddresTextBox.Text = credentials.OwnerAddress;

                this.DkTextBox.Text = credentials.DK;
                this.CTSCheckBox.Checked = credentials.IsCTS;
                this.ClientCheckBox.Checked = credentials.IsClient;
            }
        }

        private bool HasCredentials
        {
            get { return this.Session["Credentials"] != null; }
        }

        /// <summary>
        /// Cargala información necesaria alos combo box.
        /// </summary>
        private void LoadDataSources()
        {
            ComboBox expirationMonthComboBox = this.GetComboBox("expirationMonthComboBox");
            if (expirationMonthComboBox != null)
            {
                expirationMonthComboBox.DataSource = new string[]
                                                         {
                                                             "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
                                                             "11", "12"
                                                         };
            }

           
            ComboBox expirationYearComboBox = this.GetComboBox("expirationYearComboBox");
            expirationYearComboBox.DataSource = new string[] { "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022" };
            expirationYearComboBox.SelectedItem = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            
            ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
            
            var paymentForms = new List<ListItem>();

            if (VolarisSession.IsVolarisProcess)
            {
                paymentForms.Add(new ListItem("VISA", "VI"));
                paymentForms.Add(new ListItem("UATP", "TP"));
                paymentForms.Add(new ListItem("MASTER CARD", "MC"));
                paymentForms.Add(new ListItem("AMERICAN EXPRESS", "AX"));
                //paymentForms.Add(new ListItem("AMEX 3", "A3"));
                //if() si se cumple se realizar monedero electronico
                //paymentForms.Add(new ListItem("Monedero Electrónico", "AG"));

            }
            else
            {
                paymentForms.Add(new ListItem("VISA", "VI"));
                paymentForms.Add(new ListItem("UATP", "TP"));
                paymentForms.Add(new ListItem("MASTER CARD", "MC"));
                paymentForms.Add(new ListItem("AMERICAN EXPRESS", "AMEX"));
                paymentForms.Add(new ListItem("AMEX 3", "A3"));
                if (!string.IsNullOrEmpty(CostumerAccountInterJet.NumberPurche))
                paymentForms.Add(new ListItem("Monedero Electrónico", "AG"));
            }

            creditCardComboBox.DataSource = paymentForms;
            creditCardComboBox.DisplayMember = "Text";
            creditCardComboBox.ValueMember = "Value";

        }


        /// <summary>
        /// Genera el ticket de interjet con la información recolectada hasta el momento.
        /// </summary>
        /// <returns></returns>
        private InterJetTicket GenerateTicket()
        {
            var ticketFromSession = (InterJetTicket)this.Session["CurrentTicket"];
            var ticket = new InterJetTicket
            {
                Flights = new InterJetFlights(),
                Passangers = (InterJetPassangers)this.Session["Passangers"],
                Contact = (InterJetContact)this.Session["Contact"],
                Agent = ticketFromSession.Agent,

            };
            ticket.Flights.AddFlights(((InterJetSelectedFlights)this.Session["SelectedFlights"]).GetFlights());
            return ticket;
        }

        /// <summary>
        /// REaliza el pago con tarjeta de credito.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public void Pay(InterJetCreditCardFields credentials)
        {
            //InterJetTicket ticket = this.GenerateTicket();
            if (this.CurrentTicket != null)
            {
                if (this.Dispatch.ContainsKey(this.PaymentMethod))
                {
                    InterJetPayment payment = this.Dispatch[this.PaymentMethod]();
                    if (this.PaymentMethod == "AG")
                    {
                        credentials = new InterJetCreditCardFields();
                        credentials.CreditCardNumber = CostumerAccountInterJet.NumberPurche;
                    }
                    payment.CreditCardsFields = credentials;
                    payment.Pay(CurrentTicket);
                }
            }
        }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        private string PaymentMethod
        {
            get;
            set;
        }


        /// <summary>
        /// Obtiene los campos necesarios para agregar a la forma de pago.
        /// </summary>
        /// <param name="validateOwnerAddressAndPostalCode"></param>
        /// <returns></returns>
        private InterJetCreditCardFields GetGreditCardFields(bool validateOwnerAddressAndPostalCode)
        {
            var creditCardFields = new InterJetCreditCardFields();

            ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
            TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
            TextBox securityCodeTextBox = this.GetTextBox("securityCodeTextBox");
            TextBox totalAmount = this.GetTextBox("totalToPayTextBox");
            ComboBox expirationMonthComboBox = this.GetComboBox("expirationMonthComboBox");
            ComboBox expirationYearComboBox = this.GetComboBox("expirationYearComboBox");
            TextBox ownerNameTextBox = this.GetTextBox("creditCardOwnerNameTextBox");

            this.ValidateComboBox(creditCardComboBox, "TARJETA DE CREDITO");
            this.ValidateTextBox(creditCardNumberTextBox, "NUMERO DE TARJETA");
            this.ValidateComboBox(expirationMonthComboBox, "MES DE VENCIMIENTO");
            if (!this.PaymentMethod.Equals("TP"))
            {
                this.ValidateTextBox(securityCodeTextBox, "CODIGO DE SEGURIDAD");
            }

            this.ValidateComboBox(expirationYearComboBox, "AÑO DE VENCIMIENTO");
            this.ValidateTextBox(ownerNameTextBox, "NOMBRE DEL TARJETAHABIENTE");


            creditCardFields.DK = "";
            creditCardFields.IsCTS = this.CTSCheckBox.Checked;
            creditCardFields.IsClient = this.ClientCheckBox.Checked;

            creditCardFields.CreditCardName = creditCardComboBox.SelectedItem.ToString();
            creditCardFields.CreditCardNumber = creditCardNumberTextBox.Text;
            creditCardFields.SecurityCodeNumber = securityCodeTextBox.Text;
            creditCardFields.TotalAmount = Convert.ToDecimal(totalAmount.Text);
            amount = creditCardFields.TotalAmount;
            creditCardFields.CreditCardNumber = creditCardNumberTextBox.Text;
            string expirationDateString = string.Format("01/{0}/{1}", expirationMonthComboBox.SelectedItem.ToString(), expirationYearComboBox.SelectedItem.ToString());
            creditCardFields.ExpirationDate = DateTime.Parse(expirationDateString);
            creditCardFields.OwnerName = ownerNameTextBox.Text;

            if (validateOwnerAddressAndPostalCode)
            {
                TextBox ownerAddresTextBox = this.GetTextBox("creditCardOwnerAddressTextBox");
                this.ValidateTextBox(ownerAddresTextBox, "DIRECCION DEL TARJETAHABIENTE");
                creditCardFields.OwnerAddress = ownerAddresTextBox.Text;


                TextBox ownerPostalCodeTextBox = this.GetTextBox("ownerPostalCode");
                this.ValidateTextBox(ownerPostalCodeTextBox, "CODIGO POSTAL");
                creditCardFields.PostalCode = ownerPostalCodeTextBox.Text;
            }

            return creditCardFields;
        }


        /// <summary>
        /// Valida el textbox.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="field"></param>
        private void ValidateTextBox(TextBox textBox, string field)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.ErrorProvider.SetError(textBox, string.Format(InterJetPaymentFormHandler.FIELD_NOT_FOUNDMESSAGE, field));
                throw new Exception(string.Format(InterJetPaymentFormHandler.FIELD_NOT_FOUNDMESSAGE, field));
            }
        }


        /// <summary>
        /// Valida los combobox
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="field"></param>
        private void ValidateComboBox(ComboBox comboBox, string field)
        {
            if (comboBox.SelectedItem == null)
            {
                this.ErrorProvider.SetError(comboBox, string.Format(InterJetPaymentFormHandler.FIELD_NOT_FOUNDMESSAGE, field));
                throw new Exception(string.Format(InterJetPaymentFormHandler.FIELD_NOT_FOUNDMESSAGE, field));
            }
        }

        /// <summary>
        /// Realiza un rollback de las transacciones hechas hasta el momento.
        /// </summary>
        public void ClearBooking()
        {
            InterJetServiceManager.ClearBooking();
        }

        public TextBox SecurityCodeCVV
        {

            get;
            set;
        }
        public void EnableCVVField(bool enabled)
        {
            SecurityCodeCVV.Enabled = enabled;

        }

        public PictureBox CreditCardTypePicture { get; set; }
        /// <summary>
        /// Handler del evento cuando se selecciona una fuente de pago.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void OnChangeSelectedTypeOfPayment(object sender, EventArgs e)
        {
            try
            {
                var typeOfPayment = (ComboBox)sender;
                this.EnableCVVField(true);
                if (!VolarisSession.IsVolarisProcess && typeOfPayment.SelectedValue != null)
                {
                    if (typeOfPayment.SelectedValue.ToString().Equals("AMEX"))
                    {
                        this.ShowPostalCodeAndAddress(true);
                        this.CreditCardTypePicture.Image =
                            global::MyCTS.Presentation.Properties.Resources._1327945757_amex;
                    }

                    if (typeOfPayment.SelectedValue.ToString().Equals("VI"))
                    {
                        this.ShowPostalCodeAndAddress(false);
                        this.CreditCardTypePicture.Image =
                            global::MyCTS.Presentation.Properties.Resources._1327945295_visa;
                    }

                    if (typeOfPayment.SelectedValue.ToString().Equals("TP"))
                    {
                        this.ShowPostalCodeAndAddress(false);
                        this.EnableCVVField(false);
                        this.CreditCardTypePicture.Image =
                            global::MyCTS.Presentation.Properties.Resources._1327945935_card_miles;
                    }
                    if (typeOfPayment.SelectedValue.ToString().Equals("MC"))
                    {
                        this.ShowPostalCodeAndAddress(false);
                        this.CreditCardTypePicture.Image =
                            global::MyCTS.Presentation.Properties.Resources._1327945807_mastercard;
                    }

                    if (typeOfPayment.SelectedValue.Equals("A3"))
                    {
                        this.ShowPostalCodeAndAddress(true);
                        this.CreditCardTypePicture.Image =
                            global::MyCTS.Presentation.Properties.Resources._1327945757_amex;
                    }
                    else if (VolarisSession.IsVolarisProcess && typeOfPayment.SelectedValue != null)
                    {
                        if (typeOfPayment.SelectedValue.ToString().Equals("AMEX"))
                        {
                            this.CreditCardTypePicture.Image =
                                global::MyCTS.Presentation.Properties.Resources._1327945757_amex;
                        }

                        if (typeOfPayment.SelectedValue.ToString().Equals("VI"))
                        {
                            this.CreditCardTypePicture.Image =
                                global::MyCTS.Presentation.Properties.Resources._1327945295_visa;
                        }

                        if (typeOfPayment.SelectedValue.ToString().Equals("TP"))
                        {
                            this.CreditCardTypePicture.Image =
                                global::MyCTS.Presentation.Properties.Resources._1327945935_card_miles;
                        }
                        if (typeOfPayment.SelectedValue.ToString().Equals("MC"))
                        {
                            this.CreditCardTypePicture.Image =
                                global::MyCTS.Presentation.Properties.Resources._1327945807_mastercard;
                        }

                        if (typeOfPayment.SelectedValue.Equals("A3"))
                        {
                            this.CreditCardTypePicture.Image =
                                global::MyCTS.Presentation.Properties.Resources._1327945757_amex;
                        }
                    }
                }
            }
            catch (NullReferenceException Err)
            {
                throw new NullReferenceException(Err.Message);
            }
        }

        public decimal GetAvailableCretid()
        {
            decimal credit=0;
            credit = InterJetServiceManager.SeeNumber();
            return credit;
        }
           

        /// <summary>
        /// Oculta o despliega el panel donde se encuentra botones ocultables.
        /// </summary>
        /// <param name="isVisible">if set to <c>true</c> [is visible].</param>
        private void ShowPostalCodeAndAddress(bool isVisible)
        {
            this.PanelToHide.Visible = isVisible;

        }

        /// <summary>
        /// Handles the timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void HandleTimerTick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(ProgressBar.Percentage);
        }



        /// <summary>
        /// Commete la trasnacción ala base de datos.
        /// </summary>
        public void CommitTransaction()
        {
            if (!VolarisSession.IsVolarisProcess)
            {
                LogProductivity.LogTransaction(Login.Agent, "7-Confirmo la compra del vuelo--InterJet");
                TextBox txtCostCenter = this.GetTextBox("txtCostCenter");
                InterJetCreditCardFields.CC = txtCostCenter.Text;
                TextBox txtEmployeeNumber = this.GetTextBox("txtEmployeeNumber");
                InterJetCreditCardFields.EmployeeNum = txtEmployeeNumber.Text;

                ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                this.ValidateComboBox(creditCardComboBox, "TARJETA DE CREDITO");
                string paymentMethod = creditCardComboBox.SelectedValue.ToString();
                this.PaymentMethod = paymentMethod;
                InterJetPayment payment = this.Dispatch[this.PaymentMethod]();
                InterJetCreditCardFields credentials = null;
                if (paymentMethod != "AG")
                {
                    credentials = this.GetGreditCardFields(payment.ValidateOwnerAddressAndPostalCode);
                SetCredentialsToSession();
                }
                if (this.IsAValidClient())
                {
                    this.StartAnimation("Realizando Transacción...");
                    this.StartBuyingBackGroundWorker(credentials);
                }
            }
            else
            {
                try
                {
                    LogProductivity.LogTransaction(Login.Agent, "7-Confirmo la compra del vuelo--Volaris");
                    if (this.IsAValidClient())
                    {
                        VolarisSession.IsValidCard = true;
                        this.StartAnimation("Realizando Transacción...");
                        VolarisServiceManager cliente = new VolarisServiceManager();
                        if (string.IsNullOrEmpty(VolarisSession.PNR))
                            VolarisSession.PNR = cliente.PagarReservacion(VolarisSession.PagoVolaris);
                        if (VolarisSession.PNR.Length == 6)
                        {
                            VolarisSession.IsValidPNR = true;
                            VolarisSession.Mensaje = string.Empty;
                            while (VolarisSession.Mensaje.Contains("Pending") || VolarisSession.Mensaje == string.Empty)
                            {
                                VolarisSession.Mensaje = string.Empty;
                                VolarisSession.Mensaje = cliente.ConfirmarReservacion(VolarisSession.PNR);
                            }
                        }
                        else
                            VolarisSession.IsValidPNR = false;
                    }
                    else
                    {
                        VolarisSession.IsValidCard = false;
                    }
                }
                catch (Exception ex)
                {
                    VolarisSession.Mensaje = ex.ToString();
                }

            }
        }

        public void CerrarReservacion()
        {
            VolarisServiceManager cliente = new VolarisServiceManager();
            cliente.CloseReservation();
        }

        /// <summary>
        /// Validates the DK and credit card.
        /// </summary>
        private bool IsAValidClient()
        
        {
            string dK = ucFirstValidations.DK;

            if (!CTSCheckBox.Checked && !ClientCheckBox.Checked)
            {
                this.ErrorProvider.SetError(CTSCheckBox, "Por favor indique el tipo de tarjeta.".ToUpper());
                this.ErrorProvider.SetError(ClientCheckBox, "Por favor indique el tipo de tarjeta.".ToUpper());
                throw new Exception("Por favor indique el tipo de tarjeta.".ToUpper());
            }
            if (!dK.EndsWith("990"))
            {
                ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
                //TODO: verificar
                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard creditCard;
                //ClientCreditCard creditCard;
                bool dkExists = true;
                if (dkExists)
                {
                    #region validacion cuando se seleccion tarjeta de CTS

                    if (this.CTSCheckBox.Checked)
                    {
                        WsMyCTS wsServ = new WsMyCTS();
                        var clientcreditCard = wsServ.GetCreditCardNumberCTS(creditCardNumberTextBox.Text);

                        ucInterJetPaymentForm.IsClientCard = false;
                        ucInterJetPaymentForm.IsCTSCard = true;
                        bool IsNotACardFromCTS = string.IsNullOrEmpty(clientcreditCard);
                        if (IsNotACardFromCTS)
                        {
                            ErrorProvider.SetError(creditCardNumberTextBox,
                                                   "El numero de tarjeta capturado no corresponde a ninguna tarjeta de CTS, por favor verifique los datos."
                                                       .ToUpper());
                            if (VolarisSession.IsVolarisProcess)
                            {
                                VolarisSession.ErrorMessage = (creditCardNumberTextBox.Text +
                                                   " El numero de tarjeta capturado no corresponde a ninguna tarjeta de CTS, por favor verifique los datos.")
                                                       .ToUpper();
                                MessageBox.Show(VolarisSession.ErrorMessage, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return false;

                        }
                        return true;

                    }

                    #endregion

                    #region validacion cuando se selecciona tarjeta de cliente

                    if (this.ClientCheckBox.Checked)
                    {
                        #region insidecliente
                        WsMyCTS wsServ = new WsMyCTS();
                        var clientcreditCard = wsServ.GetCreditCardNumberCTS(creditCardNumberTextBox.Text);

                        bool IsNotACardFromCTS = string.IsNullOrEmpty(clientcreditCard);
                        if (IsNotACardFromCTS)
                        {
                            if (VolarisSession.IsVolarisProcess)
                            {
                                ucVolarisPaymentFormFormulario.IsClientCard = true;
                                ucVolarisPaymentFormFormulario.IsCTSCard = false;
                            }
                            else
                            {
                                ucInterJetPaymentForm.IsClientCard = true;
                                ucInterJetPaymentForm.IsCTSCard = false;
                            }
                            if (creditCardComboBox.SelectedValue.ToString().Equals("A3") ||
                                creditCardComboBox.SelectedValue.ToString().Equals("AMEX") ||
                                creditCardComboBox.SelectedValue.ToString().Equals("AX"))
                            {

                                if (HasAValidCreditCard)
                                {
                                    return true;
                                }
                                return false;
                            }

                            if (creditCardComboBox.SelectedValue.ToString().Equals("TP"))
                            {
                                if (HasAValidCreditCard)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            string message =
                                "El número de tarjeta ingresado pertenece a CTS. Corrige el número de tarjeta del cliente o indica que pertenece a CTS".ToUpper();
                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ErrorProvider.SetError(creditCardNumberTextBox, message);
                            return false;
                        }
                        #endregion
                    }

                    #endregion
                }
            }
            else
            {
                TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");

                string sNumberCardCTS = creditCardNumberTextBox.Text;
                if (!string.IsNullOrEmpty(sNumberCardCTS))
                {
                    WsMyCTS wsServ = new WsMyCTS();
                    string creditCard = wsServ.GetCreditCardNumberCTS(sNumberCardCTS);

                    if (this.CTSCheckBox.Checked == true)
                    {
                        if (string.IsNullOrEmpty(creditCard))
                        {
                            MessageBox.Show("Debes ingresar un número de tarjeta perteneciente a CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    else if (this.ClientCheckBox.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(creditCard))
                        {
                            MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    return true;
                }
            }

            return true;
        }

        private string PaymentType
        {
            get
            {
                ComboBox creditCardComboBox = this.GetComboBox("creditCardComboBox");
                if (creditCardComboBox.SelectedValue.ToString().Equals("TP"))
                {
                    return "AIR";
                }

                if (creditCardComboBox.SelectedValue.ToString().Equals("AMEX") || 
                    creditCardComboBox.SelectedValue.ToString().Equals("A3") ||
                    creditCardComboBox.SelectedValue.ToString().Equals("AX"))
                {
                    return "AMEX";
                }


                return creditCardComboBox.SelectedValue.ToString();
            }
        }

        private string CreditCardNumber
        {
            get
            {
                TextBox creditCardNumberTextBox = this.GetTextBox("creditCardNumberTextBox");
                return creditCardNumberTextBox.Text;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is amex.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is amex; otherwise, <c>false</c>.
        /// </value>
        private bool IsAmex
        {
            get
            {
                if (this.PaymentType.Equals("AMEX") || PaymentType.Equals("A3") || PaymentType.Equals("AX"))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is UATP.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is UATP; otherwise, <c>false</c>.
        /// </value>
        private bool IsUATP
        {
            get { return this.PaymentType.Equals("AIR"); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has A valid credit card.
        /// </summary>
        /// <value>
        ///       <c>true</c> if this instance has A valid credit card; otherwise, <c>false</c>.
        /// </value>
        private bool HasAValidCreditCard
        {
            get
            {
                WsMyCTS wsServ = new WsMyCTS();

                string paymentType = PaymentType;
                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard data = new MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard();
                data = wsServ.GetCreditCardNumberATT(ucFirstValidations.DK, paymentType, Login.OrgId);
                string creditCardNumber = data.CreditCardNumber;


                if (!string.IsNullOrEmpty(creditCardNumber) && !CreditCardNumber.Equals(creditCardNumber))
                {
                    string protectedCreditCard = creditCardNumber.Substring(creditCardNumber.Length - 4, 4).PadLeft(creditCardNumber.Length, 'X');
                    MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCards = wsServ.GetClientCreditCardNumber(CreditCardNumber, ucFirstValidations.DK);
                    if (!string.IsNullOrEmpty(creditCardNumber) && !CreditCardNumber.Equals(creditCardNumber))
                    {
                        var clientCreditard = wsServ.GetClientCreditCardNumberATT(CreditCardNumber);
                        if (string.IsNullOrEmpty(clientCreditard))
                        {
                            if (IsAmex)
                            {
                                string message =
                                    string.Format("El número de tarjeta capturado no corresponde a la tarjeta de tipo EBTA " +

                                                  " ligada al cliente DK: {0}" +
                                                  ".\nEl número de tarjeta correcto para la forma de pago EBTA"
                                                  +
                                                  " es: ({1}).\n\n¿Desea continuar con la emisión?", ucFirstValidations.DK, protectedCreditCard);

                                DialogResult result = MessageBox.Show(message.ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (result == DialogResult.Yes)
                                {
                                    return true;
                                }
                                return false;
                            }

                            if (IsUATP)
                            {
                                string msg = string.Format("El número de tarjeta capturado no corresponde a la tarjeta de tipo AIRPLUS " +

                                " ligada al cliente DK: {0}" +
                                ".\nEl número de tarjeta correcto para la forma de pago AIRPLUS"
                                +
                                " es: ({1}).\n", ucFirstValidations.DK, protectedCreditCard);

                                DialogResult result = MessageBox.Show(msg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        else
                        {
                            if (creditCardNumber != CreditCardNumber && clientCreditCards.Client != ucFirstValidations.DK)
                            {
                                MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(creditCardNumber) && CreditCardNumber.Equals(creditCardNumber))
                    {
                        return true;
                    }
                    MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.DK);

                    //ClientCreditCard infoCreditCard = GetClientCreditCardNumberBL.GetClientCreditCardNumberByClient(ucFirstValidations.DK);

                    if (!string.IsNullOrEmpty(infoCreditCard.CreditCardNumber))
                    {
                        string mesage = "La forma de pago no corresponde al tipo " + infoCreditCard.Type +
                                        " ligada al cliente DK: " + ucFirstValidations.DK +
                                        "\n¿Desea continuar con la emisión?";
                        DialogResult result = MessageBox.Show(mesage.ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        string mesage = "La forma de pago no corresponde al tipo de forma de pago " +
                    "ligada al cliente DK: " + ucFirstValidations.DK +
                      "\n¿Desea continuar con la emisión?";
                        DialogResult result = MessageBox.Show(mesage.ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Starts the buying back ground worker.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        private void StartBuyingBackGroundWorker(InterJetCreditCardFields credentials)
        {
            this.BuyingBackGroundWorker.DoWork += new DoWorkEventHandler(BuyingBackGroundWorker_DoWork);
            this.BuyingBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BuyingBackGroundWorker_RunWorkerCompleted);
            this.BuyingBackGroundWorker.RunWorkerAsync(credentials);
        }

        /// <summary>
        /// Stops the buying bank ground worker.
        /// </summary>
        private void StopBuyingBankGroundWorker()
        {
            this.BuyingBackGroundWorker.DoWork -= new DoWorkEventHandler(BuyingBackGroundWorker_DoWork);
            this.BuyingBackGroundWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BuyingBackGroundWorker_RunWorkerCompleted);
        }

        /// <summary>
        /// Reliza un loggeo de errores.
        /// </summary>
        public void LogError()
        {
            this.LogError("InterJet- Error en forma de Pago");
        }

        /// <summary>
        /// se recupera del error y loguea una respuesta en el servidor.
        /// </summary>
        public override void RecoverFromError()
        {
            this.RecoverFromError("-INTERJET ERROR", false);
        }
        /// <summary>
        /// Gets or sets the back to passanger button.
        /// </summary>
        /// <value>
        /// The back to passanger button.
        /// </value>
        public Button BackToPassangerButton { get; set; }

        /// <summary>
        /// Gets or sets the show flight detail button.
        /// </summary>
        /// <value>
        /// The show flight detail button.
        /// </value>
        public Button ShowFlightDetailButton { get; set; }
        /// <summary>
        /// Gets or sets the commit button.
        /// </summary>
        /// <value>
        /// The commit button.
        /// </value>
        public Button CommitButton { get; set; }

        /// <summary>
        /// Backs to contacts or infants.
        /// </summary>
        public void BackToContactsOrInfants()
        {
            this.Session["IsAlreadyPriced"] = false;
            this.SetCredentialsToSession();
            if (HasProfile)
            {
                this.InterJetProfile.CreditCards.Clear();
            }
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetPassangerCaptureForm",
                                        this.CurrentUserControl.Parameter, null);
        }

        /// <summary>
        /// Gets a value indicating whether this instance has profile.
        /// </summary>
        /// <value>
        ///       <c>true</c> if this instance has profile; otherwise, <c>false</c>.
        /// </value>
        private bool HasProfile
        {
            get { return this.Session["Profile"] != null; }
            
        }

        /// <summary>
        /// Gets the inter jet profile.
        /// </summary>
        public MyCTS.Entities.InterJetProfile InterJetProfile
        {
            get
            {
                if (HasProfile)
                {
                    return (MyCTS.Entities.InterJetProfile)this.Session["Profile"];
                }
                if (VolarisSession.Profile)
                {
                    return VolarisSession.InterJetProfile;
                }
                return new MyCTS.Entities.InterJetProfile();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _profileWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the profile worker.
        /// </summary>
        private BackgroundWorker ProfileWorker
        {
            get { return _profileWorker; }
        }


        /// <summary>
        /// Starts the profile worker.
        /// </summary>
        private void StartProfileWorker()
        {
            this.StartAnimation("Cotizando espere porfavor...");
            this.ProfileWorker.DoWork += (ProfileWorker_DoWork);
            this.ProfileWorker.RunWorkerCompleted += (ProfileWorker_RunWorkerCompleted);
            this.ProfileWorker.RunWorkerAsync();
        }

        private void StartProfileVolaris()
        {
            try
            {
                var resultado = ServiceProfile.GetProfileCreditCard(this.InterJetProfile.FirstLevelProfile);
                if (VolarisSession.IsVolarisProcess)
                {
                    if (resultado != null)
                    {
                        InterJetProfile.CreditCards.Add((List<MyCTS.Entities.InterJetProfileCreditCard>)resultado);
                        this.Session["Profile"] = VolarisSession.InterJetProfile;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the ProfileWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void ProfileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.StopProfileWorker();//tomar en cuenta para detener el proceso
                if (e.Error == null && !VolarisSession.IsVolarisProcess)
                {
                    if (e.Result != null)
                    {
                    InterJetProfile.CreditCards.Add((List<MyCTS.Entities.InterJetProfileCreditCard>)e.Result);//en este momento es donde cambia
                    }
                    this.Session["Profile"] = InterJetProfile;
                    this.StartPricingBackGroundWorker(this.CurrentTicket);
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetProfileBL _service;
        /// <summary>
        /// Gets the service profile.
        /// </summary>
        private InterJetProfileBL ServiceProfile
        {
            get
            {
                return _service ?? (_service = new InterJetProfileBL());
            }
        }
        /// <summary>
        /// Handles the DoWork event of the ProfileWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void ProfileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ServiceProfile.GetProfileCreditCard(this.InterJetProfile.FirstLevelProfile);
        }

        

        /// <summary>
        /// Stops the profile worker.
        /// </summary>
        private void StopProfileWorker()
        {
            this.ProfileWorker.DoWork -= (ProfileWorker_DoWork);
            this.ProfileWorker.RunWorkerCompleted -= (ProfileWorker_RunWorkerCompleted);
        }
    }
}
