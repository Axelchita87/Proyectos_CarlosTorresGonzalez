using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucInterJetPaymentForm : CustomUserControl
    {

        private Timer TimerProgress
        {
            get
            {
                return this.TimerProgressBar;
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
                                                                                 PanelToHide = this.hiddenPanel,
                                                                                 ProgressBar = this.gradProg1,
                                                                                 ButtonPanelToHide =
                                                                                     this.buttonsPanelToHide,
                                                                                 TimerProgressBar = this.TimerProgress,
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
                                                                                 StepLabel = this.topLabel,
                                                                                 CostCenter= this.txtCostCenter,
                                                                                 EmployeeNumber= this.txtEmployeeNumber
                                                                             });
            }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetPaymentForm"/> class.
        /// </summary>
        public ucInterJetPaymentForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
        }


        /// <summary>
        /// TODO: Crear la relacion de contactos y fecha de nacimiento del contacto.
        /// TODO: Validar look and feel.
        /// TODO: Pedir el acceso al servidor de produccion
        /// TODO: MODIFICAR a TABS el proceso para persistir la informacion
        /// TODO: CERRAR SESSION al ocurrir.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void commitButton_Click(object sender, EventArgs e)
        {
            try
            {
                InterJetPaymentFormHandler.CommitTransaction();
                
            }
            catch (Exception ex)
            {
                try
                {
                    //string msg = ex.Message;
                    MessageBox.Show(ImpuestosBajoCosto.PNRBajoCosto + ListTaxesInterjet.Status, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    InterJetPaymentFormHandler.StopAnimation();
                }
                catch (Exception exception)
                {

                    InterJetPaymentFormHandler.RecoverFromError();
                }
                //TODO: InterJet Migration se commento para realizar pruebas y evitar datos staticos.
                //ucInterJetPaymentForm.PricedTicket = null;
            }

        }


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

        /// <summary>
        /// Handles the Load event of the ucInterJetPaymentForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetPaymentForm_Load(object sender, EventArgs e)
        {
            try
            {
                InterJetPaymentFormHandler.Initialize();
                if (!ImpuestosBajoCosto.continuePayment && !VolarisSession.IsVolarisProcess) 
                {
                    MessageBox.Show("El tiempo para la realizar la compra de la reserva se agoto, favor de realzar nuevamente la reserva");
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
                }
                else
                {
                    this.commitButton.Focus();
                    ucFirstValidations.NameProfile = InterJetPaymentFormHandler.InterJetProfile.SecondLevelProfile;
                    if (string.IsNullOrEmpty(ucFirstValidations.DK))
                        ucFirstValidations.DK = InterJetPaymentFormHandler.InterJetProfile.FirstLevelProfile;
                    //ucFirstValidations.GetCreditCards();
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            InterJetPaymentFormHandler.SetGoToPayment();
            InterJetPaymentFormHandler.SetCredentialsToSession();
            InterJetPaymentFormHandler.ShowDetallesDeVuelo();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the creditCardComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void creditCardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            InterJetPaymentFormHandler.OnChangeSelectedTypeOfPayment(sender, e);
            if (creditCardComboBox.SelectedValue.Equals("AG"))
            {
                HideShow(false);
                lblAmount.Text = (InterJetPaymentFormHandler.GetAvailableCretid()).ToString("#.00");
            }
            else
            {
                HideShow(true);
            }

            if (creditCardComboBox.SelectedValue.Equals("AMEX") ||
                creditCardComboBox.SelectedValue.Equals("A3") ||
                creditCardComboBox.SelectedValue.Equals("AX"))
            {
                ShowQualityControls(true);
            }
            else
            {
                ShowQualityControls(false);
            }

        }

        private void HideShow(bool value)
        {
            creditCardNumberTextBox.Visible = value;
            label3.Visible = value;
            label14.Visible = value;
            viewCreditCardsButtons.Visible = value;
            label4.Visible = value;
            label19.Visible = value;
            securityCodeTextBox.Visible = value;
            label5.Visible = value;
            label17.Visible = value;
            expirationMonthComboBox.Visible = value;
            expirationYearComboBox.Visible = value;
            label2.Visible = value;
            totalToPayTextBox.Visible = value;
            label6.Visible = value;
            creditCardOwnerNameTextBox.Visible = value;
            label16.Visible = value;
            if (value == false)
                pnlElectronicPurse.Visible = true;
            else
                pnlElectronicPurse.Visible = false;
        }

        private void ShowQualityControls(bool value)
        {
            lblCostCenter.Visible = value;
            txtCostCenter.Visible = value;
            lblEmployeeNumber.Visible = value;
            txtEmployeeNumber.Visible = value;
            lblEBTAAmex.Visible= value;
        }

        /// <summary>
        /// Handles the Tick event of the TimerProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TimerProgressBar_Tick(object sender, EventArgs e)
        {//pasa aqui para ir 
            this.InterJetPaymentFormHandler.HandleTimerTick(sender, e);
        }
        /// <summary>
        ///// Gets or sets the priced ticket.
        ///// </summary>
        ///// <value>
        ///// The priced ticket.
        ///// </value>
        //public static InterJetTicket PricedTicket
        //{
        //    get;
        //    set;
        //}


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (this.creditCardComboBox.Focused)
                {
                    this.creditCardNumberTextBox.Focus();
                    return true;

                }

                if (this.creditCardNumberTextBox.Focused)
                {
                    this.securityCodeTextBox.Focus();
                    return true;
                }

                if (this.securityCodeTextBox.Focused)
                {
                    this.expirationMonthComboBox.Focus();
                    return true;
                }

                if (this.expirationMonthComboBox.Focused)
                {
                    this.expirationYearComboBox.Focus();
                    return true;
                }
                if (expirationYearComboBox.Focused)
                {
                    this.creditCardOwnerNameTextBox.Focus();
                    return true;
                }

                if (creditCardOwnerNameTextBox.Focused)
                {
                    if (this.hiddenPanel.Visible)
                    {
                        this.creditCardOwnerAddressTextBox.Focus();
                    }
                    return true;


                }

                if (creditCardOwnerAddressTextBox.Focused)
                {

                    this.ownerPostalCode.Focus();
                    return true;
                }


            }

            return false;
        }

        /// <summary>
        /// Handles the Click event of the backToContactsOrInfants control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void backToContactsOrInfants_Click(object sender, EventArgs e)
        {
            try
            {

                this.InterJetPaymentFormHandler.BackToContactsOrInfants();

            }
            catch (Exception ex)
            {

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

        private void creditCardNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab)
            //{
            //    this.securityCodeTextBox.Focus();
            //}
        }

        private void securityCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.expirationMonthComboBox.Focus();
            }
        }

        private void expirationYearComboBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Tab)
            {
                this.expirationYearComboBox.Focus();
            }
        }

        private void creditCardOwnerNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Tab)
            {

                if (hiddenPanel.Visible)
                {
                    this.creditCardOwnerAddressTextBox.Focus();
                }
            }
        }

        private void creditCardOwnerAddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                if (hiddenPanel.Visible)
                {
                    this.ownerPostalCode.Focus();
                }
            }
        }

        private void creditCardNumberTextBox_Leave(object sender, EventArgs e)
        {

            string sNumberCardCTS = creditCardNumberTextBox.Text;
            if (!string.IsNullOrEmpty(sNumberCardCTS))
            {
                WsMyCTS wsServ = new WsMyCTS();
                string creditCard = wsServ.GetCreditCardNumberCTS(sNumberCardCTS);
                //string creditCard = GetCreditCardNumberBL.GetCreditCardNumber(sNumberCardCTS);

                if (ctsCheckBox.Checked == true)
                {
                    if (string.IsNullOrEmpty(creditCard))
                    {
                        this.Focus();
                        MessageBox.Show("Debes ingresar un número de tarjeta perteneciente a CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardNumberTextBox.Text = string.Empty;
                    }
                }
                else if (clientCheckBox.Checked == true)
                {
                    if (!string.IsNullOrEmpty(creditCard))
                    {
                        this.Focus();
                        MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        creditCardNumberTextBox.Text = string.Empty;
                    }
                }
            }
        }
    }
}
