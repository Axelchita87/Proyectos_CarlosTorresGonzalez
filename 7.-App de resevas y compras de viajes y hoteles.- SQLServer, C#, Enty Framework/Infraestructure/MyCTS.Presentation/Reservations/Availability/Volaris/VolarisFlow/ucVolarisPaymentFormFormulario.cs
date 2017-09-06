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
using MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentInformationCapture;
using MyCTS.Business;
using MyCTS.Services.Contracts.Volaris;
using System.Net;
using MyCTS.Presentation.Reservations.Availability.Volaris.VolarisFlow;

namespace MyCTS.Presentation
{
    public partial class ucVolarisPaymentFormFormulario : CustomUserControl, IVolarisPaymentInformationCaptureView
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is client card.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is client card; otherwise, <c>false</c>.
        /// </value>
        public static bool IsClientCard { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is CTS card.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is CTS card; otherwise, <c>false</c>.
        /// </value>
        public static bool IsCTSCard { get; set; }
        private WebBrowser web = new WebBrowser();
        private TextBox txt;
        PruebaScript prueba = new PruebaScript();

        private InterJetPaymentFormHandler _interjetHandler;
        /// <summary>
        /// Gets the inter jet payment form handler.
        /// </summary>
        private InterJetPaymentFormHandler InterJetPaymentFormHandler
        {
            get
            {
                return this._interjetHandler ?? (this._interjetHandler = new InterJetPaymentFormHandler
                {
                    FormPanel = this.formPanel,
                    CurrentForm = this,
                    ProgressBar = this.gradProg1,
                    ButtonPanelToHide =
                        this.buttonsPanelToHide,
                    TimerProgressBar = this.TimerProgressBar,
                    CotizandoLabel = this.cotizandoLabel,
                    GroupBoxToBox =
                        this.crediCardFieldsGroupBox,
                    CurrentUserControl = this,
                    SecurityCodeCVV = this.securityCodeTextBox,

                    CTSCheckBox = this.ctsCheckBox,
                    ClientCheckBox = this.clientCheckBox,
                    ViewCreditCard = this.viewCreditCardsButtons,
                    BackToPassangerButton = this.backToContactsOrInfants,
                    ShowFlightDetailButton = this.showFlightDetails,
                    CommitButton = this.commitButton,
                    PrincingPictureBox = this.princingPictureBox,
                    CreditCardTypePicture = this.creditCardPictureBox,
                    MainGroupBox = this.crediCardFieldsGroupBox,
                    Loading = this.loadingPictureBox,
                    StepLabel = this.topLabel

                });
            }
        }


        public ucVolarisPaymentFormFormulario()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
        }

        private void ucVolarisPaymentFormFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                if (!VolarisSession.ErrorPay)
                {
                    this.lbPredictive.Visible = false;
                    FillCombo();
                    InterJetPaymentFormHandler.Initialize();
                    this.commitButton.Focus();
                    ucFirstValidations.NameProfile = VolarisSession.SegundoNivel;
                    ucFirstValidations.DK = VolarisSession.DK;
                    ucFirstValidations.GetCreditCards();
                    
 
                }
                else
                {
                    InterJetPaymentFormHandler.Initialize();
                    FillCombo();
                    txtLastNameTitular.Text = VolarisSession.PagoVolaris.Apellido;
                    txtCountry.Text = VolarisSession.PagoVolaris.CodigoPais;
                    txtPostCode.Text = VolarisSession.PagoVolaris.CodigoPostal;
                    securityCodeTextBox.Text = VolarisSession.PagoVolaris.CodigoSeguridad;
                    txtAddress.Text = VolarisSession.PagoVolaris.Direccion;
                    txtCity.Text = VolarisSession.PagoVolaris.Ciudad;
                    txtEmail.Text = VolarisSession.PagoVolaris.Email;
                    cmbStateorProvidence.Text = VolarisSession.PagoVolaris.EstadoProvincia;

                    string[] fecha = VolarisSession.PagoVolaris.FechaExpiracion.ToString().Split('/');
                    expirationMonthComboBox.Text = fecha[1];
                    expirationYearComboBox.Text = fecha[2];
                    creditCardComboBox.Text = VolarisSession.PagoVolaris.MetodoDePago;
                    totalToPayTextBox.Text = VolarisSession.PagoVolaris.Monto.ToString();
                    txtPhone.Text = VolarisSession.PagoVolaris.Telefono;
                    txtNameTitular.Text = VolarisSession.PagoVolaris.Titular;
                    creditCardNumberTextBox.Focus();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            //Cuando ya se pasa el pago
            try
            {
                if (IsValid)
                {

                    if (!VolarisSession.ErrorPay)
                    {
                        VolarisSession.PagoVolaris = new MetodoPagoVolaris();
                        prueba.Show();
                        
                        if (expirationMonthComboBox.Text == "02")
                        {
                            VolarisSession.PagoVolaris.FechaExpiracion = Convert.ToDateTime("28" + "/" + expirationMonthComboBox.Text + "/" + expirationYearComboBox.Text);
                        }
                        else
                            VolarisSession.PagoVolaris.FechaExpiracion = Convert.ToDateTime("30" + "/" + expirationMonthComboBox.Text + "/" + expirationYearComboBox.Text);
                        VolarisSession.PagoVolaris.MetodoDePago = ((ListItem)creditCardComboBox.SelectedItem).Value;
                        VolarisSession.PagoVolaris.NumeroTarjeta = creditCardNumberTextBox.Text;
                        VolarisSession.PagoVolaris.Moneda = "MXN";
                        VolarisSession.PagoVolaris.Monto = Convert.ToDecimal(totalToPayTextBox.Text);
                        VolarisSession.PagoVolaris.TipoMetodoPago = TiposVolaris.PaymentMethodType.ExternalAccount;
                        VolarisSession.PagoVolaris.NumeroAgencia = "ACCTNO";
                        VolarisSession.PagoVolaris.TipoTarjeta = creditCardComboBox.Text;
                        VolarisSession.PagoVolaris.IP = LocalIPAddress();


                        if (((ListItem)creditCardComboBox.SelectedItem).Value != "TP")
                        {
                            VolarisSession.PagoVolaris.Apellido = txtLastNameTitular.Text;
                            VolarisSession.PagoVolaris.CodigoPais = txtCountry.Text;
                            VolarisSession.PagoVolaris.CodigoPostal = txtPostCode.Text;
                            VolarisSession.PagoVolaris.CodigoSeguridad = securityCodeTextBox.Text;
                            VolarisSession.PagoVolaris.Direccion = txtAddress.Text;
                            VolarisSession.PagoVolaris.Ciudad = txtCity.Text;
                            //VolarisSession.PagoVolaris.Direccion = "Y " + txtAddress.Text;
                            //VolarisSession.PagoVolaris.Ciudad = "Y " + txtCity.Text;
                            VolarisSession.PagoVolaris.Email = txtEmail.Text;
                            VolarisSession.PagoVolaris.EstadoProvincia = ((ListItem)cmbStateorProvidence.SelectedItem).Value;
                            VolarisSession.PagoVolaris.Telefono = txtPhone.Text;
                            VolarisSession.PagoVolaris.Titular = txtNameTitular.Text;
                        }

                        if (ctsCheckBox.Checked)
                        {
                            VolarisSession.IsCTSCard = true;
                        }
                        else if (clientCheckBox.Checked)
                        {
                            VolarisSession.IsClientCard = true;
                        }
                    }
                    else
                    {
                        VolarisSession.PagoVolaris.NumeroTarjeta = creditCardNumberTextBox.Text;
                        VolarisSession.ErrorPay = false;
                    }

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(VolarisSession.PagoVolaris.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\VolarisPaymentReq " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, VolarisSession.PagoVolaris);
                    //file.Close();

                    InterJetPaymentFormHandler.CommitTransaction();
                    prueba.Hide();

                    if (VolarisSession.IsValidCard)
                    {
                        if (VolarisSession.IsValidPNR && System.Configuration.ConfigurationManager.AppSettings["Ambiente"] == "PRUEBAS")
                        {
                            InterJetPaymentFormHandler.CerrarReservacion();
                            double a = LogTicketsBL.RandomVolaris();
                            string[] array = a.ToString().Split('.');
                            VolarisSession.Boleto = array[1].Substring(0, 8);
                            VolarisSession.Agent = Login.Agent;
                            VolarisSession.EmailAgent = Login.Mail;
                            VolarisSession.StatusPaymnet = VolarisPaymentStatus.Approved;
                            VolarisLogger.InsertReservation();
                            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConfirmPurchase");
                        }
                        else if (VolarisSession.IsValidPNR && VolarisSession.Mensaje.Contains("Approved"))
                        {
                            InterJetPaymentFormHandler.CerrarReservacion();
                            double a = LogTicketsBL.RandomVolaris();
                            string[] array = a.ToString().Split('.');
                            VolarisSession.Boleto = array[1].Substring(0, 8);
                            VolarisSession.Agent = Login.Agent;
                            VolarisSession.EmailAgent = Login.Mail;
                            VolarisSession.StatusPaymnet = VolarisPaymentStatus.Approved;
                            VolarisLogger.InsertReservation();
                            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConfirmPurchase");
                        }
                        else
                        {
                            if (VolarisSession.PNR.Contains("Invalid account number"))
                            {
                                VolarisSession.ErrorPay = true;
                                VolarisSession.StatusPaymnet = VolarisPaymentStatus.Declined;
                                VolarisSession.Agent = Login.Agent;
                                VolarisSession.EmailAgent = Login.Mail;
                                VolarisLogger.InsertReservation();
                                VolarisSession.PNR = string.Empty;
                                MessageBox.Show("Número de Tarjeta de Crédito Invalida", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisPaymentFormFormulario");
                            }
                            else if (VolarisSession.Mensaje.Contains("Declined"))
                            {
                                MessageBox.Show("TU CARGO A SIDO DECLINDO LO PROBABLE ES QUE HAYAS INGRESADO LOS DATOS MAL " + "\n" +
                                    "POR POLITICAS DE VOLARIS ES NECESARIO VUELVAS A REHACER TU COMPRA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
                            }
                            else
                            {
                                VolarisSession.StatusPaymnet = VolarisPaymentStatus.Declined;
                                VolarisSession.Agent = Login.Agent;
                                VolarisSession.EmailAgent = Login.Mail;
                                VolarisLogger.InsertReservation();
                                MessageBox.Show(VolarisSession.Mensaje, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VolarisSession.PNR = string.Empty;
                                Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisPaymentFormFormulario");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    string msg = ex.Message;
                    InterJetPaymentFormHandler.StopAnimation();
                }
                catch (Exception exception)
                {
                    InterJetPaymentFormHandler.RecoverFromError();
                }
            }

        }

        private void backToContactsOrInfants_Click(object sender, EventArgs e)
        {
            VolarisServiceManager cliente = new VolarisServiceManager();
            cliente.CloseReservation();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAvailability");
        }

        private void showFlightDetails_Click(object sender, EventArgs e)
        {
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucSummaryVolarisFormulario");
        }

        public VolarisCreditCardInformation CreditCardInformation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public VolarisCreditCardOwner Owner
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void ValidateInput()
        {
            throw new NotImplementedException();
        }

        public bool IsValid
        {
            get
            {
                bool valid = false;
                if (((ListItem)creditCardComboBox.SelectedItem).Value != "TP")
                {
                    if (!ctsCheckBox.Checked && !clientCheckBox.Checked)
                    {
                        MessageBox.Show("Ingrese tipo de tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clientCheckBox.Focus();
                    }
                    else if (string.IsNullOrEmpty(creditCardNumberTextBox.Text))
                    {
                        MessageBox.Show("Ingrese numero de tarjeta de credito", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardNumberTextBox.Focus();
                    }
                    else if (creditCardNumberTextBox.TextLength < 15 && (((ListItem)creditCardComboBox.SelectedItem).Value == "AX" ||
                        ((ListItem)creditCardComboBox.SelectedItem).Value == "A3"))
                    {
                        MessageBox.Show("Ingrese numero de tarjeta de credito correcto", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardNumberTextBox.Focus();
                    }
                    else if (creditCardNumberTextBox.TextLength < 16 && (((ListItem)creditCardComboBox.SelectedItem).Value != "AX" &&
                        ((ListItem)creditCardComboBox.SelectedItem).Value != "A3"))
                    {
                        MessageBox.Show("Ingrese numero de tarjeta de credito correcto", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardNumberTextBox.Focus();
                    }
                    else if (string.IsNullOrEmpty(expirationMonthComboBox.Text))
                    {
                        MessageBox.Show("Ingrese fecha de expiración de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        expirationMonthComboBox.Focus();
                    }
                    else if (string.IsNullOrEmpty(expirationYearComboBox.Text))
                    {
                        MessageBox.Show("Ingrese fecha de expiración de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        expirationYearComboBox.Focus();
                    }
                    else if (string.IsNullOrEmpty(securityCodeTextBox.Text))
                    {
                        MessageBox.Show("Ingrese el codigo de seguridad de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        securityCodeTextBox.Focus();
                    }
                    else if (string.IsNullOrEmpty(totalToPayTextBox.Text))
                    {
                        MessageBox.Show("Ingrese la cantidad total a pagar", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        totalToPayTextBox.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtNameTitular.Text))
                    {
                        MessageBox.Show("Ingrese el nombre del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNameTitular.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtLastNameTitular.Text))
                    {
                        MessageBox.Show("Ingrese el apellido del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLastNameTitular.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        MessageBox.Show("Ingrese el correo del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Focus();
                    }
                    else if (!ValidateRegularExpression.ValidateEmailFormat(txtEmail.Text))
                    {
                        MessageBox.Show("El formato del correo es invalido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtPhone.Text))
                    {
                        MessageBox.Show("Ingrese el telefono del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPhone.Focus();
                    }
                    else if (!ValidateRegularExpression.ValidatePhoneNumber(txtPhone.Text))
                    {
                        MessageBox.Show("Ingrese los 10 digitos del numero telefonico del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPhone.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtAddress.Text))
                    {
                        MessageBox.Show("Ingrese la dirección del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAddress.Focus();
                    }
                    else if (string.IsNullOrEmpty(cmbStateorProvidence.Text))
                    {
                        MessageBox.Show("Ingrese el estado del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbStateorProvidence.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtPostCode.Text))
                    {
                        MessageBox.Show("Ingrese el codigo postal del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPostCode.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtCountry.Text))
                    {
                        MessageBox.Show("Ingrese el pais del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCountry.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtCity.Text))
                    {
                        MessageBox.Show("Ingrese el pais del titular de la tarjeta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCity.Focus();
                    }
                    else
                    {
                        valid = true;
                    }
                }
                else
                {
                    if (creditCardNumberTextBox.TextLength < 15 || creditCardNumberTextBox.TextLength>15)
                    {
                        MessageBox.Show("Ingrese numero de tarjeta de credito correcto", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardNumberTextBox.Focus();
                    }
                    else
                    {
                        valid = true;
                    }
                }
                return valid;
            }
        }

        bool Base.IBaseView.IsValid
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAirports(txt, lbPredictive);

        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxCountries(txt, lbPredictive);
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxStateVolaris(txt, lbPredictive);//verificar
        }

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbCities tiene el foco
        /// </summary>
        /// <param name="sender">lbCities</param>
        /// <param name="e"></param>
        private void lbPredictive_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbPredictive.Visible = false;
                txt.Focus();
            }
        }

        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando el txt origen, destino o conexiones tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generalActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbPredictive.Items.Count > 0)
                {
                    lbPredictive.SelectedIndex = 0;
                    lbPredictive.Focus();
                    lbPredictive.Visible = true;
                    lbPredictive.Focus();
                }
            }

        }

        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        private void creditCardNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((((ListItem)creditCardComboBox.SelectedItem).Value == "AX"
                || ((ListItem)creditCardComboBox.SelectedItem).Value == "A3"
                || (((ListItem)creditCardComboBox.SelectedItem).Value == "TP"))
                && creditCardNumberTextBox.TextLength == 15)
            {
                creditCardNumberTextBox.MaxLength = 15;
                securityCodeTextBox.MaxLength = 4;
            }
        }

        private void securityCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(creditCardComboBox.Text))
            {
                if ((((ListItem)creditCardComboBox.SelectedItem).Value != "AX" && ((ListItem)creditCardComboBox.SelectedItem).Value != "A3"
                    && securityCodeTextBox.TextLength == 3))
                {
                    securityCodeTextBox.MaxLength = 3;
                }
            }
            else
            {
                MessageBox.Show("Ingrese tipo de tarjeta de crédito", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                creditCardComboBox.Focus();
            }
        }

        private void viewCreditCardsButtons_Click(object sender, EventArgs e)
        {
            try
            {
                this.InterJetPaymentFormHandler.ShowAvailableCards();
            }
            catch (Exception ex)
            {
                var test = ex;
            }
        }
        
        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso enviando a la mascarilla de welcome
        /// al presionar la tecla ESC o ejecuta las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                commitButton_Click(sender, e);
            }
        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
       
        private void FillCombo()
        {
            List<VolarisState> listState = VolarisStateBL.GetAllState();
            bindingSource2.DataSource = listState;
            foreach (VolarisState stateItem in listState)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    stateItem.StateID,
                    stateItem.Name.TrimEnd());
                litem.Value = stateItem.StateID;
                cmbStateorProvidence.Items.Add(litem);
            }
        }

        private void creditCardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (((ListItem)creditCardComboBox.SelectedItem).Value == "TP")
            {
                EnableDisableControls(false, Color.LightGray);
            }
            else
            {
                EnableDisableControls(true, Color.White);
            }

            if ((((ListItem)creditCardComboBox.SelectedItem).Value == "AX"
                || ((ListItem)creditCardComboBox.SelectedItem).Value == "A3"
                || (((ListItem)creditCardComboBox.SelectedItem).Value == "TP")))
            {
                if (creditCardNumberTextBox.TextLength > 15 && !string.IsNullOrEmpty(creditCardNumberTextBox.Text))
                {
                    creditCardNumberTextBox.Text =  creditCardNumberTextBox.Text.Substring(0,15);
                    creditCardNumberTextBox.MaxLength = 15;
                    securityCodeTextBox.MaxLength = 4;
                }
            }
            else
            {

                creditCardNumberTextBox.MaxLength = 16;
                securityCodeTextBox.MaxLength = 3;
                if (securityCodeTextBox.TextLength > 3 && !string.IsNullOrEmpty(securityCodeTextBox.Text))
                {
                    securityCodeTextBox.Text = securityCodeTextBox.Text.Substring(0, 3);
                    securityCodeTextBox.MaxLength = 3;
                }
            }
        }

        private void EnableDisableControls(bool enable, Color color)
        {
            txtAddress.Enabled = enable;
            txtAddress.BackColor = color;
            txtNameTitular.Enabled = enable;
            txtNameTitular.BackColor = color;
            txtLastNameTitular.Enabled = enable;
            txtLastNameTitular.BackColor = color;
            txtEmail.Enabled = enable;
            txtEmail.BackColor = color;
            txtPhone.Enabled = enable;
            txtPhone.BackColor = color;
            txtPostCode.Enabled = enable;
            txtPostCode.BackColor = color;
            txtCity.Enabled = enable;
            txtCity.BackColor = color;
            txtCountry.Enabled = enable;
            txtCountry.BackColor = color;
            cmbStateorProvidence.Enabled = enable;
            cmbStateorProvidence.BackColor = color;
            securityCodeTextBox.Enabled = enable;
            securityCodeTextBox.BackColor = color;
        }

        
    }
}
