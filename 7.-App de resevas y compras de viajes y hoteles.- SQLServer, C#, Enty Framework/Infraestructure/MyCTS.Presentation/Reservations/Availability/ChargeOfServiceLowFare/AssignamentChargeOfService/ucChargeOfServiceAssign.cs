using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.EventArguments;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Services.ValidateDKsAndCreditCards;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService
{
    public partial class ucChargeOfServiceAssign : UserControl, IViewChargeOfServiceLowFareAssign
    {
        WsMyCTS wsServ = new WsMyCTS();
        public ucChargeOfServiceAssign()
        {
            InitializeComponent();
            _presenter = new ChargOfServiceLowFareAssignPresenter();
        }

        #region Miembros de IViewChargeOfServiceLowFareAssign

        public List<IPassanger> Passangers
        {
            get { return passangersCombo.Properties.Items.OfType<IPassanger>().ToList(); }
            set
            {
                passangersCombo.Properties.Items.Add(new IVolarisPassanger
                {
                    IsNotAPassanger = true
                });
                passangersCombo.Properties.Items.AddRange(value);
                passangersCombo.SelectedIndex = 0;
            }
        }

        public List<FormOfPayment> CreditCards
        {
            get { return creditCardCombo.Properties.Items.OfType<FormOfPayment>().ToList(); }
            set { creditCardCombo.Properties.Items.AddRange(value); }
        }

        #endregion

        #region Miembros de IBaseView

        public void ValidateInput()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }

        #endregion

        public static object Parametros { set; get; }

        public static String sDK { set; get; }
        public static String sPNR { set; get; }

        private readonly ChargOfServiceLowFareAssignPresenter _presenter;

        private void ucChargeOfServiceAssign_Load(object sender, EventArgs e)
        {
            _presenter.View = this;
            _presenter.Repository = new ChargeOfServiceLowFareAssignRepository();
            _presenter.LoadData();

            this.mothCombo.Properties.Items.AddRange(new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            this.mothCombo.SelectedItem = DateTime.Today.ToString("MM");
            for (int year = DateTime.Now.Year; year < DateTime.Now.Year + 10; year++)
            {
                this.yearComboBox.Properties.Items.Add(year.ToString(CultureInfo.InvariantCulture));
            }
            yearComboBox.SelectedItem = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            creditCardCombo.SelectedIndex = 0;
            this.amountTextBox.Text = "0.00";
            creditCardTextBox.Focus();

             MyCTS.Entities.InterJetProfileCreditCard credentials = InterJetPaymentFormHandler.cardSelect;
             if (credentials != null)
             {
                 DialogResult dialogResult = MessageBox.Show("¿Deseas ingresar la misma forma de pago del boleto para el cargo por servicio?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                 if (dialogResult == DialogResult.Yes)
                 {

                     if (credentials.Type  == MyCTS.Entities.InterJetProfileCrediCardType.AmericanExpress)
                         creditCardCombo.SelectedIndex = 0;

                     if (credentials.Type == MyCTS.Entities.InterJetProfileCrediCardType.UniversalTravelPlan)
                         creditCardCombo.SelectedIndex = 2;

                     if (credentials.Type == MyCTS.Entities.InterJetProfileCrediCardType.Visa)
                         creditCardCombo.SelectedIndex = 1;

                     if (credentials.Type == MyCTS.Entities.InterJetProfileCrediCardType.MasterCard)
                         creditCardCombo.SelectedIndex = 6;

                     creditCardChargeRadioButton.Checked = true;
                     creditCardTextBox.Text = credentials.CreditCardNumber;
                     txtNombreTitular.Text = credentials.titular;
                     txtCodigoSeguridad.Text = new string( Components.Common.toDecrypt(credentials.CVV).Where(char.IsDigit).ToArray());

                     int month = credentials.ExpirationDate.Month;
                     int year = credentials.ExpirationDate.Year;

                     if ((year < DateTime.Now.Year) || (year <= DateTime.Now.Year && month < DateTime.Now.Month))
                     {
                         MessageBox.Show("La tarjeta ingresada ha caducado, favor de revisar la vigencia.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                     }

                     yearComboBox.SelectedIndex = getIndex(year);
                     mothCombo.SelectedIndex = month - 1;

                 }
             }
        }

        public int getIndex(int year)
        {
            int index = 0;

            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 10 ;i++)
            {
                if (year == i)
                {
                    return index;
                }
                index++;
            }
            return index;
        }

        public EventHandler<AssignChargeOfServiceEventArgs> OnAssignatePassanger { get; set; }

        private void searchProfileButton_Click(object sender, EventArgs e)
        {
            ValidateInput();
            if (IsValid)
            {
                if (OnAssignatePassanger != null)
                {
                    var arguments = GetArguments();
                    OnAssignatePassanger(this, arguments);
                }
            }
        }

        private AssignChargeOfServiceEventArgs GetArguments()
        {
            var arguments = new AssignChargeOfServiceEventArgs
                                {
                                    Passanger = passangersCombo.SelectedItem as IPassanger,
                                    Amount = Convert.ToDecimal(this.amountTextBox.Text),
                                    FormOfPayment = creditCardCombo.SelectedItem as FormOfPayment,
                                };
            if (arguments.FormOfPayment != null)
            {
                arguments.FormOfPayment.CrediCardNumber = this.creditCardTextBox.Text;
            }
            // falta agregar el DK
            bool volaris = true;
            bool interjet = true;
            String sValorPNR = String.Empty;
            if (volaris)
            {
                if (ucFirstValidations.dk == null || ucFirstValidations.dk == String.Empty)
                {
                    ucFirstValidations.dk = sDK;
                }

                sValorPNR = sPNR;
            }
            else if (interjet)
            {
                if (ucFirstValidations.dk == null || ucFirstValidations.dk == String.Empty)
                {
                    ucFirstValidations.dk = sDK;
                }

                sValorPNR = sPNR;
            }

            if (ChargesPerService.ValidateTestingUsers(ChargesPerService.OrigenTipoCargo.BajoCosto))
            {
                arguments.DatosTarjeta = new CreditCardInfo();
                arguments.DatosTarjeta.NumeroTarjeta = creditCardTextBox.Text;
                arguments.DatosTarjeta.MesVencimiento = mothCombo.SelectedItem.ToString();
                arguments.DatosTarjeta.AnioVencimiento = yearComboBox.SelectedItem.ToString().Substring(2,2);
                arguments.DatosTarjeta.NombreTitular = txtNombreTitular.Text;
                arguments.DatosTarjeta.CodigoSeguridad = txtCodigoSeguridad.Text;
                arguments.DatosTarjeta.MontoCargo = Convert.ToDecimal(this.amountTextBox.Text);
                string sFormaDePago= String.Empty;
                switch (creditCardCombo.SelectedItem.ToString().Trim())
                {
                    case "TC AMEX":
                        sFormaDePago = "CCAC";
                        break;
                    case "TC VISA":
                    case "TC MASTERCARD":
                        sFormaDePago = "CCPV";
                        break;
                    case "TD VISA":
                    case "TD MASTERCARD":
                        sFormaDePago = "CCTD";
                        break;
                    case "EFECTIVO":
                        sFormaDePago = "CA";
                        break;
                    case "CHEQUE":
                        sFormaDePago = "CH";
                        break;
                    case "TRANSFERENCIA":
                        sFormaDePago = "TR";
                        break;
                    case "TC UATP":
                        sFormaDePago = "TP";
                        break;
                }
                arguments.DatosTarjeta.TipoTarjeta = sFormaDePago;
                arguments.DatosTarjeta.PNR = sValorPNR; // Falta agregar el PNR
                ucChargeOfServiceLowFare.lstDatosTarjeta = new List<CreditCardInfo>();
                ucChargeOfServiceLowFare.lstDatosTarjeta.Add(arguments.DatosTarjeta);
            }

            return arguments;
        }

        private void EnabledCreditCardFieldsCash(bool enabled)
        {
            this.mothCombo.Enabled = enabled;
            this.yearComboBox.Enabled = enabled;
            this.creditCardTextBox.Enabled = enabled;
            this.creditCardTextBox.Properties.MaxLength = 16;
            txtCodigoSeguridad.Enabled = enabled;
            txtNombreTitular.Enabled = enabled;
        }

        private void EnabledCreditCardFieldsCheckAndTransfer(bool enabled)
        {
            this.mothCombo.Enabled = enabled;
            this.yearComboBox.Enabled = enabled;
            this.creditCardTextBox.Enabled = true;
            this.creditCardTextBox.Properties.MaxLength = 4;
            txtCodigoSeguridad.Enabled = enabled;
            txtNombreTitular.Enabled = enabled;
        }

        private void creditCardChargeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var creditCardRadioButton = (RadioButton)sender;
            if (creditCardRadioButton != null)
            {
                if (creditCardRadioButton.Checked)
                {
                    this.EnabledCreditCardFieldsCash(true);
                }
                else
                {
                    this.EnabledCreditCardFieldsCash(false);
                }
            }
        }

        private void cashRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var _cashRadioButton = (RadioButton)sender;
            if (_cashRadioButton != null)
            {
                if (_cashRadioButton.Checked)
                {
                    this.EnabledCreditCardFieldsCash(false);
                }
            }
        }

        private void creditCardCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormOfPayment form = creditCardCombo.SelectedItem as FormOfPayment;
            if (form != null)
            {

                Font nvaFuente = new Font("Tahoma", 8.25F);
                creditCardTextBox.Text = String.Empty;
                creditCardTextBox.Properties.PasswordChar = new char();
                creditCardTextBox.Font = nvaFuente;

                if (form.Type == GenericFormOfPayment.Cash)
                {
                    this.EnabledCreditCardFieldsCash(false);
                }
                else if (form.Type == GenericFormOfPayment.Transfer || form.Type == GenericFormOfPayment.Check)
                {
                    this.EnabledCreditCardFieldsCheckAndTransfer(false);
                    WsMyCTS wsServ = new WsMyCTS();
                    MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber data = new MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber();
                    data = wsServ.GetTranferCheckNumberMyCTS(ucFirstValidations.Attribute1);
                    creditCardTextBox.Text = data.ct_banc_cbr;
                    Font nvaFuentePassword = new Font("Symbol", 9F);
                    creditCardTextBox.Properties.PasswordChar = '·';
                    creditCardTextBox.Font = nvaFuentePassword;
                    creditCardTextBox.Focus();
                }
                else
                {
                    this.EnabledCreditCardFieldsCash(true);
                    Font nvaFuentePassword = new Font("Symbol", 9F);
                    creditCardTextBox.Properties.PasswordChar = '·';
                    creditCardTextBox.Font = nvaFuentePassword;
                }
                creditCardTextBox.Focus();
            }
        }

        private void creditCardTextBox_Leave(object sender, EventArgs e)
        {
            ValidacionTarjeta();
        }

        private void ValidacionTarjeta()
        {
            string textoCreditCardTextBoxText = creditCardTextBox.Text;
            string textoCodigoSeguridad = txtCodigoSeguridad.Text;
            string textoNombreTitular = txtNombreTitular.Text;
            string textoAmountTextBox = amountTextBox.Text;
            string textoCreditCardCombo = creditCardCombo.Text;

            double monto = 0;
            double.TryParse(textoAmountTextBox, out monto);

            if (!string.IsNullOrEmpty(textoAmountTextBox) && monto > 0)
            {
                switch (textoCreditCardCombo)
                {
                    case "TRANSFERENCIA":
                    case "CHEQUE":
                        if (textoCreditCardTextBoxText.Length != 4)
                        {
                            ErroresValidacionTarjeta("El número de la tarjeta debe ser de 4 digitos. Reingrese");
                        }
                        break;

                    case "EFECTIVO":
                        break;

                    default:

                        if (string.IsNullOrEmpty(textoCreditCardTextBoxText))
                        {
                            ErroresValidacionTarjeta("Debe ingresar el numero de tarjeta. Ingrese");
                            break;
                        }

                        string sNumberCardCTS = creditCardTextBox.EditValue.ToString();
                        MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(sNumberCardCTS, ucFirstValidations.DK);
                        if (!string.IsNullOrEmpty(sNumberCardCTS))
                        {
                            string creditCard = wsServ.GetCreditCardNumberCTS(sNumberCardCTS);
                            if (!string.IsNullOrEmpty(creditCard))
                            {
                                ErroresValidacionTarjeta("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese");
                                creditCardTextBox.Focus();

                            }
                            if (string.IsNullOrEmpty(creditCard))
                            {
                                string clientCreditCardNumber = wsServ.GetClientCreditCardNumberATT(textoCreditCardTextBoxText);

                                if (string.IsNullOrEmpty(clientCreditCardNumber))
                                {
                                    if (ValidateCreditCardNumber)
                                    {
                                        if (clientCreditCard.CreditCardNumber == textoCreditCardTextBoxText && (clientCreditCard.Client == ucFirstValidations.DK && clientCreditCard.Type != textoCreditCardCombo))
                                        {
                                            ErroresValidacionTarjeta("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + textoCreditCardCombo + " ligada al cliente DK: " + ucFirstValidations.DK);
                                            creditCardTextBox.Focus();
                                        }
                                    }
                                }
                                else
                                    if (clientCreditCard.CreditCardNumber != textoCreditCardTextBoxText)
                                    {
                                        ErroresValidacionTarjeta("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido");
                                        creditCardTextBox.Focus();
                                    }
                            }
                        }
                        break;
                }
            }
        }

        private void ErroresValidacionTarjeta(string mensajeError)
        {
            MessageBox.Show(mensajeError, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            creditCardTextBox.Text = string.Empty;
        }


        private void creditCardTextBox_EditValueChanged(object sender, EventArgs e)
        {
        }

        private bool ValidateCreditCardNumber
        {
            get
            {
                var typoCard = string.Empty;
                WsMyCTS wsServ = new WsMyCTS();
                if (creditCardCombo.Text == "TC AMEX" || creditCardCombo.Text == "TC UATP")
                {
                    typoCard = "AMEX";
                }
                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.dk);


                if (!string.IsNullOrEmpty(infoCreditCard.CreditCardNumber) && !infoCreditCard.CreditCardNumber.Equals(creditCardTextBox.Text))
                {
                    string numberCardShow = infoCreditCard.CreditCardNumber.Substring(infoCreditCard.CreditCardNumber.Length - 4, 4).PadLeft(infoCreditCard.CreditCardNumber.Length, 'X');
                    if (creditCardCombo.Text.Equals("TC AMEX") || creditCardCombo.Text.Equals("TC UATP"))
                    {
                        typoCard = "EBTA";
                        DialogResult yesNo = MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typoCard +
                        " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + typoCard +
                        " es: (" + numberCardShow + ").\n\n¿Desea continuar con la emisión?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (yesNo.Equals(DialogResult.Yes))
                        {
                            return true;
                        }
                        else
                        {
                            creditCardTextBox.Text = string.Empty;
                            creditCardTextBox.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        //creditCardCombo.Text = "TC UATP";
                        MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + creditCardCombo +
                            " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + creditCardCombo +
                            " es: (" + numberCardShow + ").", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardTextBox.Text = string.Empty;
                        //creditCardTextBox.Focus();
                        return false;
                    }
                    return true;
                }
                else
                    return true;
            }
        }

        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            ValidacionTarjeta();
        }

        private void txtNombreTarjetahabiente_Leave(object sender, EventArgs e)
        {
            //SaveCurrentPaxFormPayment();
        }
    }
}
