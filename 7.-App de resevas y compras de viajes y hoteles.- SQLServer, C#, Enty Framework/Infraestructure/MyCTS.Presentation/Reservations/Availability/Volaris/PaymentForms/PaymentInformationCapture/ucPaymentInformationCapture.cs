using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentInformationCapture;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucPaymentInformationCapture : CustomUserControl, IVolarisPaymentInformationCaptureView
    {
        bool flag = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ucPaymentInformationCapture"/> class.
        /// </summary>
        public ucPaymentInformationCapture()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the expiration date.
        /// </summary>
        private void LoadExpirationDate()
        {

            this.monthExpiration.Properties.Items.AddRange(new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });

            for (int year = DateTime.Now.Year; year < DateTime.Now.AddYears(10).Year; year++)
            {
                this.yearExpiration.Properties.Items.Add(year.ToString(CultureInfo.InvariantCulture));
            }

            this.monthExpiration.SelectedItem = DateTime.Now.ToString("MM");
            this.yearExpiration.SelectedItem = DateTime.Now.ToString("yyyy");


        }

        public decimal TotalToPay
        {
            get { return Convert.ToDecimal(this.totalToPay.Text); }
            set { totalToPay.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        private void LoadCreditCards()
        {
            var americanExpress = new VolarisCreditCard
                                      {
                                          Type = VolarisCreditCardType.AmericanExpress,
                                          Name = "American Express"
                                      };
            var visa = new VolarisCreditCard
                           {
                               Type = VolarisCreditCardType.Visa,
                               Name = "Visa"
                           };

            //var uatp = new VolarisCreditCard()
            //               {
            //                   Type = VolarisCreditCardType.UniversalTravelPlan,
            //                   Name = " Universal Travel Plan"
            //               };


            var masterCard = new VolarisCreditCard()
                         {
                             Type = VolarisCreditCardType.MasterCard,
                             Name = "Master Card"
                         };
            this.cardTypeComboBox.Properties.Items.Add(americanExpress);
            this.cardTypeComboBox.Properties.Items.Add(visa);
            //this.cardTypeComboBox.Properties.Items.Add(uatp);
            this.cardTypeComboBox.Properties.Items.Add(masterCard);
            this.cardTypeComboBox.SelectedIndex = 0;



        }

        /// <summary>
        /// Handles the Click event of the pictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var helpControl = new frmCreditCardSecurityCode();
            helpControl.StartPosition = FormStartPosition.CenterScreen;
            helpControl.Show(this);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the clientCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void clientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var clientCheckBox_ = sender as CheckEdit;
            if (clientCheckBox_ != null)
            {
                if (clientCheckBox_.Checked)
                {
                    ctsCheckBox.Checked = false;
                }

            }

        }

        /// <summary>
        /// Handles the CheckedChanged event of the ctsCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ctsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var ctsCheckBox_ = sender as CheckEdit;
            if (ctsCheckBox_ != null)
            {
                if (ctsCheckBox_.Checked)
                {
                    clientCheckBox.Checked = false;
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
                                ucFormPayment.C28 = string.Empty;
                                break;

                            }

                        }

                    }
                }
            }
        }

        public bool IsCTSCreditCard
        {
            get { return ctsCheckBox.Checked; }
        }

        public bool IsClientCreditCard
        { get { return clientCheckBox.Checked; } }

        private VolarisPaymentInformationCapturePresenter _presenter;
        /// <summary>
        /// Handles the Load event of the ucPaymentInformationCapture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucPaymentInformationCapture_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisPaymentInformationCapturePresenter()
                             {
                                 View = this,
                                 Repository = new VolarisPaymentInformationRepository()
                             };
            LoadExpirationDate();
            LoadCreditCards();
            var countries = this._presenter.Repository.GetCountries();
            this.countryComboBox.Properties.Items.AddRange(countries);
            var mexico = countries.FirstOrDefault(c => c.Id.Equals("MX"));
            this.countryComboBox.SelectedItem = mexico;
        }


        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _getStatesWorker;
        /// <summary>
        /// Starts the state worker.
        /// </summary>
        private void StartStateWorker()
        {
            _getStatesWorker = new BackgroundWorker();
            _getStatesWorker.DoWork += _GetStatesWorker_DoWork;
            _getStatesWorker.RunWorkerCompleted += _GetStatesWorker_RunWorkerCompleted;
            var selectedCountry = this.countryComboBox.SelectedItem as VolarisCountry;
            if (selectedCountry != null)
            {
                _getStatesWorker.RunWorkerAsync(selectedCountry.Id);
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _GetStatesWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void _GetStatesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.statePanel.Visible = true;
                this.miniLoading1.Visible = false;
                var states = (List<VolarisState>)e.Result;
                if (states.Any())
                {


                    this.stateComboBox.Properties.Items.AddRange(states);
                    if (states.Any(s => s.Id.Equals("MEX")))
                    {
                        var df = states.First(s => s.Id.Equals("MEX"));
                        this.stateComboBox.SelectedItem = df;
                    }

                    else
                    {
                        this.stateComboBox.SelectedIndex = 0;
                    }
                }


            }
            finally
            {
                _getStatesWorker.Dispose();
            }

        }

        void _GetStatesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1500);
            var countryId = (string)e.Argument;
            e.Result = _presenter.Repository.GetStateByContry(countryId);
        }
        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.statePanel.Visible = false;
            this.miniLoading1.Visible = true;
            this.stateComboBox.SelectedItem = null;
            this.stateComboBox.Properties.Items.Clear();
            StartStateWorker();

        }

        #region Miembros de IVolarisPaymentInformationCaptureView

        /// <summary>
        /// Gets or sets the credit card information.
        /// </summary>
        /// <value>
        /// The credit card information.
        /// </value>
        public VolarisCreditCardInformation CreditCardInformation
        {
            get
            {
                var volarisCreditCard = this.cardTypeComboBox.SelectedItem as VolarisCreditCard;
                if (volarisCreditCard != null)
                {
                    var creditCardInfo = new VolarisCreditCardInformation
                                             {
                                                 CreditCardNumber = this.creditCardTextBox.Text,
                                                 SecurityCode = this.securityCodeTextBox.Text,
                                                 IsFromClient = this.clientCheckBox.Checked,
                                                 IsFromCts = this.ctsCheckBox.Checked,
                                                 Type = volarisCreditCard.Type,
                                                 ExpirationDate = DateTime.Parse(string.Format("01-{0}-{1}", this.monthExpiration.SelectedItem, this.yearExpiration.SelectedItem)),
                                             };


                    return creditCardInfo;
                }
                return null;
            }
            set
            {
                //if (value != null)
                //{
                //    this.creditCardTextBox.Text = value.CreditCardNumber;
                //    this.securityCodeTextBox.Text = value.SecurityCode;
                //    this.clientCheckBox.Checked = value.IsFromClient;
                //    this.ctsCheckBox.Checked = value.IsFromCts;
                //    this.monthExpiration.SelectedItem = value.ExpirationDate.ToString("MM");
                //    this.yearExpiration.SelectedItem = value.ExpirationDate.ToString("yyyy");
                //}


            }
        }

        public VolarisCreditCardOwner Owner
        {
            get
            {

                var creditCardOwner = new VolarisCreditCardOwner()
                                          {
                                              Name = ownerNameTextBox.Text,
                                              LastName = ownerLastNameTextBox.Text,
                                              Email = mailTextBox.Text,
                                              Phone = ownerTelephoneTextBox.Text,
                                              AddresLine1 = ownerAdressLine1.Text,
                                              AddressLine2 = ownerAddresLine2.Text,
                                              Country = this.countryComboBox.EditValue as VolarisCountry,
                                              State = this.stateComboBox.EditValue as VolarisState,
                                              CityName = this.cityTextBox.Text,
                                              PostalCode = this.postalCodeTextBox.Text

                                          };
                return creditCardOwner;
            }
            set
            {
                ownerNameTextBox.Text = value.Name;
                ownerLastNameTextBox.Text = value.LastName;
                mailTextBox.Text = value.Email;
                ownerTelephoneTextBox.Text = value.Phone;
                countryComboBox.EditValue = value.Country;
                stateComboBox.EditValue = value.State;


            }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {
            IsValid = EmptyControlValidator.Validate();
        }

        public bool IsValid { get; set; }

        #endregion

        private void cardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var cardtypeCombo = sender as ComboBoxEdit;
            if (cardtypeCombo != null)
            {
                var creditCardSelected = cardtypeCombo.SelectedItem as VolarisCreditCard;
                if (creditCardSelected != null)
                {
                    if (CreditCardImageRepository.ContainsKey(creditCardSelected.Type))
                    {
                        this.pictureBox2.Image = CreditCardImageRepository[creditCardSelected.Type];
                    }

                }
            }

        }



        public void SetVolarisProfileCard(VolarisProfileCreditCard card)
        {
            this.creditCardTextBox.Text = card.CreditCardNumber;
            this.monthExpiration.SelectedItem = card.ExpirationDate.ToString("mm");
            this.yearExpiration.SelectedItem = card.ExpirationDate.ToString("yy");
            var cards = this.cardTypeComboBox.Properties.Items.OfType<VolarisCreditCard>();
            if (cards.Any())
            {
                var cardSelected = cards.FirstOrDefault(c => c.Type == card.Type);
                this.cardTypeComboBox.SelectedItem = cardSelected;
            }
        }




        private Dictionary<VolarisCreditCardType, Bitmap> _imageRepository;
        /// <summary>
        /// Gets the credit card image repository.
        /// </summary>
        private Dictionary<VolarisCreditCardType, Bitmap> CreditCardImageRepository
        {
            get
            {
                return _imageRepository ?? (_imageRepository = new Dictionary<VolarisCreditCardType, Bitmap>()
                                                                     {
                                                                         {VolarisCreditCardType.Visa, Properties.Resources._1327945295_visa },
                                                                         {VolarisCreditCardType.AmericanExpress,  Properties.Resources._1327945757_amex},
                                                                         {VolarisCreditCardType.UniversalTravelPlan,Properties.Resources._32x24_uatpSmall},
                                                                         {VolarisCreditCardType.MasterCard, Properties.Resources._1327945807_mastercard}
                                                                     });
            }
        }


        public EventHandler OnShowProfileCardsEvent { get; set; }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (OnShowProfileCardsEvent != null)
            {
                OnShowProfileCardsEvent(sender, e);
            }
        }


        private void RemoveWarning(TextEdit textEdit)
        {

            if (textEdit != null)
            {
                this.EmptyControlValidator.RemoveControlError(textEdit);
            }
        }

        private void creditCardTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void securityCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void ownerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void mailTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void ownerAdressLine1_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void cityTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void postalCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void creditCardTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string sNumberCardCTS = creditCardTextBox.EditValue.ToString();
                if (!string.IsNullOrEmpty(sNumberCardCTS))
                {
                    WsMyCTS wsServ = new WsMyCTS();
                    string creditCard = wsServ.GetCreditCardNumberCTS(sNumberCardCTS);

                    if (ctsCheckBox.Checked == true)
                    {
                        if (string.IsNullOrEmpty(creditCard))
                        {
                            this.Focus();
                            MessageBox.Show("Debes ingresar un número de tarjeta perteneciente a CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            creditCardTextBox.EditValue = string.Empty;
                        }
                    }
                    else if (clientCheckBox.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(creditCard))
                        {

                            MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(creditCardTextBox.Text, ucFirstValidations.dk);

                            if (clientCreditCard.CreditCardNumber != null)
                            {
                                if (clientCreditCard.CreditCardNumber != creditCardTextBox.Text && clientCreditCard.Client != ucFirstValidations.dk)
                                {
                                    MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    creditCardTextBox.Focus();
                                }
                                else if (ValidateCreditCardNumber)
                                {

                                }
                            }
                            else
                            {
                                this.Focus();
                                MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                creditCardTextBox.EditValue = string.Empty;


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Focus();
                MessageBox.Show("Error al validar tarjeta. Reintente"); creditCardTextBox.EditValue = string.Empty;
            }
        }

        /// <summary>
        /// Valida si la tarjeta es de tipo AMEX, AIR, UATP, etc.
        /// </summary>
        private bool ValidateCreditCardNumber
        {
            get
            {
                bool status = false;
                if (ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS
                    && (cardTypeComboBox.Text.Equals("American Express") || cardTypeComboBox.Text.Equals("TP")))
                {
                    WsMyCTS wsServ = new WsMyCTS();
                    string typeCard = cardTypeComboBox.Text.Equals("American Express") ? "AMEX" : "AIR";
                    MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.dk);

                    if (!string.IsNullOrEmpty(infoCreditCard.CreditCardNumber) && !infoCreditCard.CreditCardNumber.Equals(creditCardTextBox.Text))
                    {
                        string numberCardShow = infoCreditCard.CreditCardNumber.Substring(infoCreditCard.CreditCardNumber.Length - 4, 4).PadLeft(infoCreditCard.CreditCardNumber.Length, 'X');
                        if (typeCard.Equals("AMEX"))
                        {
                            typeCard = "EBTA";
                            DialogResult yesNo = MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typeCard +
                            " ligada al cliente DK: " + ucFirstValidations.dk + ".\nEl número de tarjeta correcto para la forma de pago " + typeCard +
                            " es: (" + numberCardShow + ").\n\n¿Desea continuar con la emisión?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (yesNo.Equals(DialogResult.Yes))
                            {
                                status = true;
                            }
                        }
                        else
                        {
                            typeCard = "AIRPLUS";
                            MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typeCard +
                                " ligada al cliente DK: " + ucFirstValidations.dk + ".\nEl número de tarjeta correcto para la forma de pago " + typeCard +
                                " es: (" + numberCardShow + ").", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                        status = true;
                }
                else
                    status = true;
                return status;
            }

        }
    }
}
