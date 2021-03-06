using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class ucFormPayment : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite borrar las líneas contables,pertenece a Emitir Boleto
        /// Creación:    8/Junio/09 , Modificación:7/Julio/09
        /// Cambio:      Predictivo , Solicito Eduardo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ======= Static Variable ======

        private bool statusValidCreditCardCode;

        private static string formPayment;
        public static string FormPayment
        {
            get { return formPayment; }
            set { formPayment = value; }
        }

        private static string creditcardname;
        public static string creditCardName
        {
            get { return creditcardname; }
            set { creditcardname = value; }
        }

        private static string c28;
        public static string C28
        {
            get { return c28; }
            set { c28 = value; }
        }

        private static string numberCard;
        public static string NumberCard
        {
            get { return numberCard; }
            set { numberCard = value; }
        }

        private static string dateExpired;
        public static string DateExpired
        {
            get { return dateExpired; }
            set { dateExpired = value; }
        }

        private static string amount;
        public static string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private static string commandGetAuthorizationCode;
        public static string CommandGetAuthorizationCode
        {
            get { return commandGetAuthorizationCode; }
            set { commandGetAuthorizationCode = value; }
        }

        private static string securityCode;
        public static string SecurityCode
        {
            get { return securityCode; }
            set { securityCode = value; }
        }

        private static string baseFare;
        public static string BaseFare
        {
            get { return baseFare; }
            set { baseFare = value; }
        }

        private static string total;
        public static string Total
        {
            get { return total; }
            set { total = value; }
        }


        private static Promo promo;
        public static Promo Promo
        {
            get { return promo; }
            set { promo = value; }
        }

        private static string bank;
        public static string Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        private static string cardType;
        public static string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        private static string sendCommandWP;
        public static string SendCommandWP
        {
            get { return sendCommandWP; }
            set { sendCommandWP = value; }
        }

        //Cambio Lufthansa
        private static double lhfeeamount;
        public static double LHFeeAmount
        {
            get { return lhfeeamount; }
            set { lhfeeamount = value; }
        }

        public static string secondLevel = string.Empty;
        public static bool ReturnForMisc = false;
        private bool applyPromo = true;
        private bool validPromo = true;

        #endregion

        #region ======= Declaration of Variables ======

        string commandSegment = string.Empty;
        string[] segments1;
        string[] airlines;
        string[] flightClasses;
        string[] datesFlights;
        int lengSeg = 0;
        private bool isValidPromo = true;
        string authorizationCode = string.Empty;
        string cardAmount = string.Empty;
        string months = string.Empty;
        bool americanexpress = false;
        bool miscelaneous = false;
        bool mixpayment = false;
        bool statusValidAirline = false;
        bool flag = false;
        bool flags = false;
        private TextBox txt;
        WsMyCTS wsServ = new WsMyCTS();
        public static int cmbFecMes = 0;

        #endregion

        public ucFormPayment()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = chkClient;
            this.LastControlFocus = btnAccept;
        }

        //Load User Control
        /// <summary>
        /// De acuedo a la forma de Pago que se eligio son los contoles que
        /// se habilidan o inhabilitan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFormPayment_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtCardAmount.Text = string.Empty;
            BaseFare = string.Empty;
            CommandGetAuthorizationCode = string.Empty;
            SecurityCode = string.Empty;
            Amount = string.Empty;
            cardType = string.Empty;
            formPayment = string.Empty;
            Total = string.Empty;
            chkClient.Focus();
            lbTypeCard.BringToFront();
            GetBanks();
            LoadFormPaymentCodes();
            lbTypeCard.Visible = false;
            lblBank.Visible = false;
            cmbBank.Visible = false;
            txtNumberCard.Focus();
            c28 = string.Empty;
            toolTip1.SetToolTip(btnShow, "Para mostrar las tarjetas de crédito");
            //if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS) ||
            //    ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))
            if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))
            {
                enabledCTSFormPaymentControls(true);
            }
            GetBaseFare();
            if (!ReturnForMisc)
            {
                if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.CodeAuth.Amount))
                {
                    if (!System.Convert.ToInt32(ucTicketsEmissionInstructions.CodeAuth.Amount).Equals(System.Convert.ToInt32(Total)))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.AVISO_PAGO_MIXTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnForMisc = true;
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                    }

                }

            }
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.CodeAuth.Amount))
            {
                if ((System.Convert.ToInt32(ucTicketsEmissionInstructions.CodeAuth.Amount).Equals(System.Convert.ToInt32(Total)))
                           && ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.AVISO_TOTAL_IGUALADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnForMisc = false;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                }
            }

            #region ======== Comparative Payment =========

            txtSecurityCode.Visible = false;
            lblSecurityCode.Visible = false;

            if (ucTicketsEmissionInstructions.wayPayment ==
                Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS)
            {
                HideTextBox();
                americanexpress = true;
                ShowCreditCard(0);
                lbSystem.Visible = false;
                chkExtendetPayment.Visible = true;
                lbTypeCard.Visible = false;
                if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.CodeAuth.Amount))
                {
                    txtCardAmount.Text = ucTicketsEmissionInstructions.CodeAuth.Amount;
                    txtCardAmount.Enabled = false;
                }
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                Resources.TicketEmission.Constants.PAYMENT_CREDITCARD)
            {
                HideTextBox();
                ShowCreditCard(0);
                txtAuthorizationCode.Visible = true;
                lblAuthorizationCode.Visible = true;
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)
            {
                HideTextBox();
                ShowCreditCard(0);
                txtAuthorizationCode.Visible = true;
                lblAuthorizationCode.Visible = true;
                txtCardAmount.Visible = true;
                lblCardAmount.Visible = true;
                if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.CodeAuth.Amount))
                {
                    txtCardAmount.Text = ucTicketsEmissionInstructions.CodeAuth.Amount;
                    txtCardAmount.Enabled = false;
                }
                mixpayment = true;
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS)
            {
                HideTextBox();
                txtYear.Visible = true;
                miscelaneous = true;
            }

            #endregion
            if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CREDITCARD))
            {
                txtAuthorizationCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
                txtSecurityCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            }
        }

        private void ShowCreditCard(int indexControlSelector)
        {
            if (ucFirstValidations.CreditCardsSecondLevel.Count<= 0)
            {
                MyCTS.Entities.InterJetProfile profile = ProfileService.GetProfile(secondLevel, ucFirstValidations.DK);

                if (profile != null)
                {
                    if (profile.CreditCards != null && profile.CreditCards.HasCreditCardsInSecondLevel)
                    {
                        foreach (MyCTS.Entities.InterJetProfileCreditCard a in profile.CreditCards.GetCards())
                        {
                            if (a.Level == MyCTS.Entities.InterJetProfileCrediCardLevelType.Second)
                            {
                                string month =string.Empty;
                                if (a.ExpirationDate.Month.ToString().Length < 2)
                                    month = "0" + a.ExpirationDate.Month;
                                else
                                    month = a.ExpirationDate.Month.ToString();

                                string card = a.FullProtectedCard.Substring(0, 3) + a.CreditCardNumber + " " + month + "/" + a.ExpirationDate.Year.ToString().Substring(2, 2) + "^" + a.CVV + "^" + a.titular;
                                ucFirstValidations.CreditCardsSecondLevel.Add(card);
                            }
                        }

                    }
                }
            }

            secondLevel = string.Empty;

            if (ucFirstValidations.CreditCardsFirstLevel.Count > 0 || ucFirstValidations.CreditCardsSecondLevel.Count > 0)
            {
                frmProfilesCreditCards frm = new frmProfilesCreditCards(ucFirstValidations.CreditCardsFirstLevel, ucFirstValidations.CreditCardsSecondLevel, this.Controls, indexControlSelector);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetProfileBL _serviceProfile;

        /// <summary>
        /// Gets the profile service.
        /// </summary>
        private InterJetProfileBL ProfileService
        {
            get { return _serviceProfile ?? (_serviceProfile = new InterJetProfileBL()); }
        }

       
        /// <summary>
        /// Gets the banks.
        /// </summary>
        private void GetBanks()
        {
            List<Bank> banksList = GetAllBanksBL.GetAllBanks();
            foreach (Bank item in banksList)
            {
                cmbBank.Items.Add(item.BankName);
            }
        }




        //Button Accept
        /// <summary>
        /// Se verifica que la tarjeta de credito seleccionada este dentro de la 
        /// Base de Datos y despues se hacen las validaciones y se envian los commandos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Antes de verificar la tarjeta de credito, se valida que la fecha sean las correctas.
            int cmboFecYear = Convert.ToInt32(DateTime.Now.Year);
            int cmboFecMes = Convert.ToInt32(DateTime.Now.Month);
            int cmbFecYear = Convert.ToInt32(txtYear.Text);
            cmbFecYear = cmbFecYear + 2000;
            int cmbFecMes = Convert.ToInt32(txtMonth.Text);
            if (cmbFecYear < cmboFecYear)
            {
                MessageBox.Show("¡Fecha invalida, el año no debe ser menor al año actual!.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtYear.Focus();
            }
            else if (cmbFecMes < cmboFecMes & cmboFecYear == cmbFecYear)
            {
                MessageBox.Show("¡Fecha invalida, el mes no debe ser menor al mes actual!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonth.Focus();
            }
            else
            {
                Promo = GetPromoBL.GetPromo(ucTicketsEmissionInstructions.Airline, txtTypeCard.Text, cmbBank.Text);

                if (ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS)
                {
                    statusValidCreditCardCode = false;
                    List<ListItem> airLinesList = CatPAirlinesFareBL.GetAirLinesFare(txtTypeCard.Text);
                    if (airLinesList.Count.Equals(0))
                        statusValidAirline = true;
                    else
                        statusValidAirline = false;
                }
                else
                {
                    List<CatCreditCardsCodes> CreditCardsCodes = CatCreditCardsCodesBL.GetCreditCardsCodes(txtTypeCard.Text);
                    if (CreditCardsCodes.Count.Equals(0))
                        statusValidCreditCardCode = true;
                    else
                        statusValidCreditCardCode = false;
                }
                if (IsValidateBusinessRules)
                {
                    validPromo = ValidatePromoRules;

                    if (chkClient.Checked)
                    {
                        flags = true;
                    }
                    else
                    {
                        flags = false;
                    }

                    if (flags == true)
                    {
                        CompareCreditCardNumber();
                    }
                    else
                    {
                        ValidaTarjetaFoPaCTS();
                        if (flags == true)
                        {
                            CompareCreditCardNumber();
                        }
                    }
                }
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
                    && (txtTypeCard.Text.Equals("AX") || txtTypeCard.Text.Equals("TP")))
                {
                    WsMyCTS wsServ = new WsMyCTS();
                    string typeCard = txtTypeCard.Text.Equals("AX") ? "AMEX" : "AIR";
                    MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.dk);

                    //MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard data = new MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard();
                    //data = wsServ.GetCreditCardNumberATT(ucFirstValidations.DK, typeCard, Login.OrgId);
                    //string numberCode = data.CreditCardNumber;

                    if (!string.IsNullOrEmpty(infoCreditCard.CreditCardNumber) && !infoCreditCard.CreditCardNumber.Equals(txtNumberCard.Text))
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
                                flag = true;
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


        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// KeyDown se manda el foco al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                ReturnForMisc = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            }
            //{
            //    if (!string.IsNullOrEmpty(ucAllQualityControls.tempChargeService) && ucAllQualityControls.counter < 10 && ucCalculateServiceCharge.statusCharge == false)
            //        Loader.AddToPanel(Loader.Zone.Middle, this, "ucCalculateServiceCharge");
            //    else
            //        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            //}
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbTypeCard.Items.Count > 0)
                {
                    lbTypeCard.SelectedIndex = 0;
                    lbTypeCard.Focus();
                }
                if (americanexpress)
                {
                    lbSystem.SelectedIndex = 0;
                    lbSystem.Focus();
                }
            }
        }

        //PreviewKeyDown
        private void txtTypeCard_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                lbTypeCard.Visible = false;
        }

        //Mouse Click
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtTypeCard;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbTypeCard.Visible = false;
            txt.Focus();
        }

        /// <summary>
        /// Esta función se encarga de mandar el foco hacia la opción
        /// deseada y al elegir se oculata el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTypeCard_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtTypeCard;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbTypeCard.Visible = false;
                txt.Focus();
            }
        }

        //Muestra los controles para las tarjetas de tipo VISA y Mastercard
        private void ShowVICAControls()
        {
            chkExtendetPayment.Visible = true;
            txtCardAmount.Visible = true;
            lblCardAmount.Visible = true;
            //if (!string.IsNullOrEmpty(Total))
            //{
            //    if (!mixpayment)
            //    txtCardAmount.Text = Total;
            //}
            if (!string.IsNullOrEmpty(Total))
            {
                if (!mixpayment)
                {
                    txtCardAmount.Text = Total;
                    if (lhfeeamount > 0)
                    {
                        double grandTotal = Convert.ToDouble(Total) + lhfeeamount;
                        txtCardAmount.Text = grandTotal.ToString();
                        lblAmount.Text = string.Format("TOTAL({0}) + OB FEE({1})", total, lhfeeamount.ToString());
                        lblAmount.Visible = true;
                        lblMessage.Visible = true;
                        lblMessageLink.Visible = true;
                        lnLHInfo.Visible = true;

                    }
                }
            }
            txtSecurityCode.Visible = true;
            lblSecurityCode.Visible = true;
            lblAuthorizationCode.Visible = false;
            txtAuthorizationCode.Visible = false;
            lblBank.Visible = true;
            cmbBank.Visible = true;
        }

        //Oculta los controles para las tarjetas de tipo VISA y Mastercard
        private void HideVICAControls()
        {
            chkExtendetPayment.Visible = true;
            if (americanexpress)
            {
                txtCardAmount.Visible = false;
                lblCardAmount.Visible = false;
                lblAuthorizationCode.Visible = false;
                txtAuthorizationCode.Visible = false;
            }
            else
            {
                lblAuthorizationCode.Visible = true;
                txtAuthorizationCode.Visible = true;
            }
            txtSecurityCode.Visible = false;
            lblSecurityCode.Visible = false;
            lblBank.Visible = false;
            cmbBank.Visible = false;
            lblAmount.Text = string.Empty;
            lblAmount.Visible = false;
            lblMessage.Visible = false;
            lblMessageLink.Visible = false;
            lnLHInfo.Visible = false;
            txtSecurityCode.Visible = false;
            lblSecurityCode.Visible = false;

        }

        /// <summary>
        /// Esta función se encarga de mandar el foco hacia la opción
        /// deseada y al elegir se oculata el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbSystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string txt;
                txt = lbSystem.Text;
                txtTypeCard.Text = txt.Substring(0, 2);
                lbSystem.Visible = false;
                if ((txtTypeCard.Text == "CA" || txtTypeCard.Text == "VI"))
                    if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS) && ucTicketsEmissionInstructions.Airlinefare.OpManual)
                    {
                        ShowVICAControls();
                    }
                    else
                    {
                        MessageBox.Show("La Aerolinea no participa para cargos en línea a Tarjetas Visa y MasterCrad a traves de Sabre, debes elegir en Forma de Pago:\nTarjeta de Crédito (Aut. Manual)", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                    }
                else
                    HideVICAControls();
                txtTypeCard.Focus();
            }
        }

        /// <summary>
        /// Si el pago es con tarjeta manual se muestra un listBox
        /// si es otro tipo de pago entonces se muestra no se muestra el
        /// listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTypeCard_TextChanged(object sender, EventArgs e)
      {
            txt = (TextBox)sender;
            if (americanexpress)
            {
                if (!string.IsNullOrEmpty(txtTypeCard.Text) &&
                    (txtTypeCard.Text.Length < 3))
                {
                    lbSystem.Visible = true;
                    lbSystem.BringToFront();
                    if ((txtTypeCard.Text == "CA" || txtTypeCard.Text == "VI"))
                        if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS) && ucTicketsEmissionInstructions.Airlinefare.OpManual)
                        {
                            ShowVICAControls();

                            ShowMonths(false);

                            chkExtendetPayment.Checked = false;

                            //if (chkExtendetPayment.Checked)
                            //{
                            //    ShowMonthsVICA(true);
                            //}

                           

                            

                        }
                        else
                        {
                            MessageBox.Show("La Aerolinea no participa para cargos en línea a Tarjetas Visa y MasterCard a traves de Sabre, debes elegir en Forma de Pago:\nTarjeta de Crédito (Aut. Manual)", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                        }
                    else
                        HideVICAControls();
                    ShowMonthsVICA(false);
                    chkExtendetPayment.Checked = false;
                }
                else
                    lbSystem.Visible = false;
            }
            else if (miscelaneous)
                Common.SetListBoxPAirlines(txt, lbTypeCard);
            else if (mixpayment)
            {
                Common.SetListBoxCreditCards(txt, lbTypeCard);
                if (!string.IsNullOrEmpty(txtTypeCard.Text) &&
                    (txtTypeCard.Text.Length < 3))
                {
                    if ((txtTypeCard.Text == "CA" || txtTypeCard.Text == "VI"))
                        if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS) && ucTicketsEmissionInstructions.Airlinefare.OpManual)
                        {
                            ShowVICAControls();
                        }
                        else
                        {
                            MessageBox.Show("La Aerolinea no participa para cargos en línea a Tarjetas Visa y MasterCrad a traves de Sabre, debes elegir en Forma de Pago:\nTarjeta de Crédito (Aut. Manual)", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                        }
                    else
                        HideVICAControls();
                }
            }
            //else if ((txtTypeCard.Text == "CA" || txtTypeCard.Text == "VI") && ucTicketsEmissionInstructions.wayPayment ==
            //    Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS)
            //{
            //    ShowVICAControls();
            //}
            else
            {
                Common.SetListBoxCreditCards(txt, lbTypeCard);
            }

            // SetListBox();
            
        }

        #region ======= Change Index =======

        private void txtNumberCard_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberCard.Text.Length > 15)
                txtMonth.Focus();
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length > 1)
                txtYear.Focus();
        }

        private void txtSecurityCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSecurityCode.Text.Length > 2)
                txtCardAmount.Focus();
        }

        public void validaFecha()
        {
            int fechaActual = DateTime.Now.Year;
            int fechaIng = Convert.ToInt32(txtYear.Text);
            fechaIng = fechaIng + 2000;
            if (fechaIng < fechaActual)
            {
                MessageBox.Show("¡Fecha de expiración invalida! La fecha ingresada debe ser mayor a la fecha actual...");
            }
            txtYear.Text = string.Empty;
            txtYear.Focus();
            flag = false;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length > 1)
                if (chkExtendetPayment.Visible)
                        chkExtendetPayment.Focus();
                else if (txtSecurityCode.Visible)
                    txtSecurityCode.Focus();
                else
                    txtAuthorizationCode.Focus();
        }

        private void txtAuthorizationCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorizationCode.Text.Length > 5)
                if (txtCardAmount.Visible)
                    txtCardAmount.Focus();
                else
                    btnAccept.Focus();
        }

        private void cmbMonths_TextChanged(object sender, EventArgs e)
        {
            if (cmbMonths.Text.Length > 1)
                btnAccept.Focus();
        }

        private void txtCardAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCardAmount.Text.Length > 7)
                cmbBank.Focus();
        }

        

        private void chkExtendetPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTypeCard.Text)) 
            {
                if (chkExtendetPayment.Checked)
                {
                    ShowMonthsVICA(false);
                    ShowMonths(false);
                }

            }
            else if (txtTypeCard.Text.Contains("VI") || txtTypeCard.Text.Contains("CA"))
            {
                if (chkExtendetPayment.Checked)
                    ShowMonthsVICA(true);

                else
                    ShowMonthsVICA(false);
            }
            else 
            {
                if (chkExtendetPayment.Checked)
                    ShowMonths(true);

                else
                    ShowMonths(false);
            }
           
           
        }

        private void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClient.Checked)
            {
                chkCTS.Checked = false;
                chkClient.Focus();
                //if (!(ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS) ||
                //ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)))
                if (!ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))
                {
                    enabledCTSFormPaymentControls(false);
                }
            }
            else
            {
                chkCTS.Checked = true;
            }
        }

        private void chkCTS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCTS.Checked)
            {
                chkClient.Checked = false;
                chkCTS.Focus();
                //if (!(ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS) ||
                //ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)))
                if (!ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))
                {
                    enabledCTSFormPaymentControls(true);
                }
            }
            else
            {
                chkClient.Checked = true;
            }
        }

        private void enabledCTSFormPaymentControls(bool status)
        {
            lblFormaPagoCTS.Visible = status;
            lblCardTypeCTS.Visible = status;
            lblCardNumberCTS.Visible = status;
            cmbTypeCard.Visible = status;
            txtNumberCardCTS.Visible = status;
            btnShowCTS.Visible = status;
            if (!status)
            {
                cmbTypeCard.SelectedIndex = 0;
                txtNumberCardCTS.Text = string.Empty;
            }
        }

        #endregion

        #region ======== Mouse Click ========

        private void lbSystem_MouseClick(object sender, MouseEventArgs e)
        {
            string txt;
            txt = lbSystem.Text;
            txtTypeCard.Text = txt.Substring(0, 2);
            lbSystem.Visible = false;
            if ((txtTypeCard.Text == "CA" || txtTypeCard.Text == "VI"))
                if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS) && ucTicketsEmissionInstructions.Airlinefare.OpManual)
                {
                    ShowVICAControls();
                }
                else
                {
                    MessageBox.Show("La Aerolinea no participa para cargos en línea a Tarjetas Visa y MasterCrad a traves de Sabre, debes elegir en Forma de Pago:\nTarjeta de Crédito (Aut. Manual)", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                }
            else
                HideVICAControls();
            txtTypeCard.Focus();
        }

        private void lbTypeCard_MouseClick(object sender, MouseEventArgs e)
        {

            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtTypeCard;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbTypeCard.Visible = false;
            txt.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtTypeCard.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_TIPO_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                    return false;
                }
                else if (statusValidCreditCardCode)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.TIPO_TARJETA_NO_VÁLIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtTypeCard.Text)) && (txtTypeCard.Text.Length > 2))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.SOLO_PERMITEN_2_LETRAS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNumberCard.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_NUMERO_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                    return false;
                }
                else if (txtNumberCard.Text.Length < 15)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_NUMERO_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                    return false;
                }
                else if ((txtTypeCard.Text.Equals("VI") || txtTypeCard.Text.Equals("CA"))&&(chkExtendetPayment.Checked) && (string.IsNullOrEmpty(cmbMonths.Text)))
                {
                    //if ((chkExtendetPayment.Checked) && (string.IsNullOrEmpty(cmbMonths.Text)))
                    //{
                        MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_MESES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMonths.Focus();

                    //}
                    return false;
                }
                else if ((txtTypeCard.Text.Equals("XA")) && (chkExtendetPayment.Checked) && (string.IsNullOrEmpty(txtMonths.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_MESES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonths.Focus();
                    return false;
                }               
                else if (txtNumberCard.Text == Resources.TicketEmission.Constants.Zero)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_INGRESAR_NUMERO_TARJETA_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                    return false;
                }



                else if (txtMonth.Visible && string.IsNullOrEmpty(txtMonth.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_MES_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonth.Focus();
                    return false;
                }
                else if (!string.IsNullOrEmpty(txtMonth.Text) && Convert.ToInt32(txtMonth.Text) >= 13)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_MES_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonth.Focus();
                    return false;
                }
                else if (chkClient.Checked && chkCTS.Checked)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.ELIGE_SOLO_UN_TIPO_CLIENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkClient.Focus();
                    return false;
                }
                else if (!chkClient.Checked && !chkCTS.Checked)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.ELIGE_SOLO_UN_TIPO_CLIENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkClient.Focus();
                    return false;
                }
                else if (ucTicketsEmissionInstructions.wayPayment ==
                    Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS &&
                    !string.IsNullOrEmpty(txtTypeCard.Text) &&
                    (!txtTypeCard.Text.Equals("AX")) &&
                    (!txtTypeCard.Text.Equals("TP")) &&
                    (!txtTypeCard.Text.Equals("DC")) &&
                    (!txtTypeCard.Text.Equals("VI")) &&
                    (!txtTypeCard.Text.Equals("CA")))
                {

                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_TIPO_TARJETA_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                    return false;
                }
                else if (statusValidAirline)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_AEROLINEA_CORRECTA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                    statusValidAirline = false;
                    return false;
                }
                else if (txtSecurityCode.Visible && string.IsNullOrEmpty(txtSecurityCode.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_CODIGO_SEGURIDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSecurityCode.Focus();
                    return false;
                }
                else if (txtCardAmount.Visible && string.IsNullOrEmpty(txtCardAmount.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_MONTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCardAmount.Focus();
                    return false;
                }
                else if (cmbBank.Visible && string.IsNullOrEmpty(cmbBank.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_SELECCIONAR_BANCO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBank.Focus();
                    return false;
                }
                //else if ((chkCTS.Checked  || (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS) ||
                //ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))) && cmbTypeCard.SelectedIndex.Equals(0))
                else if ((chkCTS.Checked || ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)) && cmbTypeCard.SelectedIndex.Equals(0))
                {
                    MessageBox.Show("Requiere ingresar forma de pago del cliente a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTypeCard.Focus();
                    return false;
                }
                //else if ((chkCTS.Checked || (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS) ||
                //ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))) && string.IsNullOrEmpty(txtNumberCardCTS.Text) 
                //    && !((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CA"))
                else if ((chkCTS.Checked || ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)) && string.IsNullOrEmpty(txtNumberCardCTS.Text)
                    && !((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CA"))
                {
                    MessageBox.Show("Requiere ingresar número de tarjeta o cuenta del cliente a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    return false;
                }
                else if (lblAuthorizationCode.Visible && string.IsNullOrEmpty(txtAuthorizationCode.Text))
                {
                    MessageBox.Show("Requiere ingresar Código de Autorización", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuthorizationCode.Focus();
                    return false;
                }
                else
                    return true;
                //else if (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtCardAmount.Text))
                //{
                //    MessageBox.Show("Formato de Monto invalido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }

        }

        /// <summary>
        /// Solo se le asignan variables a los datos que contiene
        /// los TextBox
        /// </summary>
        private void CommandsSend()
        {
            creditcardname = txtTypeCard.Text;
            cardType = txtTypeCard.Text;
            numberCard = txtNumberCard.Text;
            dateExpired = txtMonth.Text + txtYear.Text;
            authorizationCode = txtAuthorizationCode.Text;
            cardAmount = txtCardAmount.Text;
            if (txtTypeCard.Text.Equals("AX")) 
            { months = txtMonths.Text; 
            } else
            {
              months = cmbMonths.Text;
            }
            amount = cardAmount;
            securityCode = txtSecurityCode.Text;


            if (txtTypeCard.Text.Equals("CA") || txtTypeCard.Text.Equals("VI"))
            {

                if (!string.IsNullOrEmpty(SecurityCode))


                    if (!string.IsNullOrEmpty(months))

                    CommandGetAuthorizationCode = string.Concat("CK*", cardType, NumberCard, "/", DateExpired, "/MXN", Amount, "/", ucTicketsEmissionInstructions.Airline, "*EP", months);
                    
                    else
                        CommandGetAuthorizationCode = string.Concat("CK*", cardType, NumberCard, "/", DateExpired, "/MXN", Amount, "/", ucTicketsEmissionInstructions.Airline);
            }       
            //           CK*CA5419222222222287/1212/MXN50           /   AM*EP06/*C999



            ArmedCommands();
        }

        /// <summary>
        /// De acuerdo a los datos ingresados se arma el comando que va 
        /// a ser asignado a una variable
        /// </summary>
        private void ArmedCommands()
        {
            FormPayment = string.Empty;

            if (ucTicketsEmissionInstructions.WithCharge)
                FormPayment = string.Concat(FormPayment, "¥FA/CCC");
            else
                FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.COMMANDS_CROSLORAINE_F);

            if (ucTicketsEmissionInstructions.wayPayment ==
                Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS)
            {
                if (ucTicketsEmissionInstructions.WithCharge)
                    FormPayment = string.Concat(FormPayment, cardType, numberCard,
                        Resources.TicketEmission.Constants.SLASH, dateExpired);
                else
                    FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.AST,
                        cardType, numberCard, Resources.TicketEmission.Constants.SLASH,
                        dateExpired);
                if (chkExtendetPayment.Checked)
                {
                    FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.COMMANDS_AST_E,
                        months);
                }
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                    Resources.TicketEmission.Constants.PAYMENT_CREDITCARD)
            {
                if (ucTicketsEmissionInstructions.WithCharge)
                    FormPayment = string.Concat(FormPayment, cardType, numberCard,
                    Resources.TicketEmission.Constants.SLASH, dateExpired,
                    Resources.TicketEmission.Constants.COMMANDS_AST_Z, authorizationCode);
                else
                    FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.AST,
                       cardType, numberCard, Resources.TicketEmission.Constants.SLASH,
                       dateExpired, Resources.TicketEmission.Constants.COMMANDS_AST_Z,
                       authorizationCode);
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                    Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT && string.IsNullOrEmpty(securityCode))
            {
                FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.COMMANDS_MPCA_AST,
                    cardType, numberCard, Resources.TicketEmission.Constants.SLASH,
                    dateExpired, Resources.TicketEmission.Constants.COMMANDS_AST_Z,
                    authorizationCode, Resources.TicketEmission.Constants.SLASH, cardAmount);
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                    Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT && !string.IsNullOrEmpty(securityCode))
            {
                FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.COMMANDS_MPCA_AST,
                    cardType, numberCard, Resources.TicketEmission.Constants.SLASH, dateExpired);
            }
            else if (ucTicketsEmissionInstructions.wayPayment ==
                    Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS)
            {
                FormPayment = string.Concat(FormPayment, Resources.TicketEmission.Constants.COMMANDS_MS,
                    cardType, numberCard);
            }

            //if (chkClient.Checked && !(ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS) ||
            //    ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)))
            if (chkClient.Checked && !(ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)))
            {
                c28 = Resources.TicketEmission.ValitationLabels.CLIENT;
            }
            else if (cmbTypeCard.SelectedIndex > 0)
            {
                if (((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CA"))
                {
                    c28 = string.Format("{0}-{1}", Resources.TicketEmission.ValitationLabels.CTS,
                       ((ListItem)cmbTypeCard.SelectedItem).Text2);
                }
                else
                {
                    c28 = string.Format("{0}-{1}-{2}", Resources.TicketEmission.ValitationLabels.CTS,
                        ((ListItem)cmbTypeCard.SelectedItem).Text2,
                        txtNumberCardCTS.Text);
                }
            }
        }

        /// <summary>
        /// Oculta los controles 
        /// </summary>
        private void HideTextBox()
        {
            txtAuthorizationCode.Visible = false;
            lblAuthorizationCode.Visible = false;
            txtCardAmount.Visible = false;
            lblCardAmount.Visible = false;
            chkExtendetPayment.Visible = false;
            lblMonths.Visible = false;
            lblMonths1.Visible = false;
            cmbMonths.Visible = false;
            lbTypeCard.Visible = false;
            lblAX.Visible = false;
        }



        /// <summary>
        /// Muestra controles
        /// </summary>
        /// <param name="show"></param>
        private void ShowMonthsVICA(bool show)
        {
             //lblMonths.Visible = show;
             lblMonths1.Visible = show;
            cmbMonths.Visible = show;
            //lblAX.Visible = show;
        }


        /// <summary>
        /// Muestra controles
        /// </summary>
        /// <param name="show"></param>
        private void ShowMonths(bool show)
        {
            lblMonths.Visible = show;
            lblMonths1.Visible = show;
            txtMonths.Visible = show;
            lblAX.Visible = show;
        }

        /// <summary>
        /// Se carga el User Control con los valores anteriormente 
        /// ingresados
        /// </summary>
        private void Previousvalues()
        {
            // bool statusParamReceived=true;
            if (userControlsPreviousValues.FormPaymentParameters != null)
            {
                //statusParamReceived = true;
                txtTypeCard.Text = userControlsPreviousValues.FormPaymentParameters[0];
                txtNumberCard.Text = userControlsPreviousValues.FormPaymentParameters[1];
                txtMonth.Text = userControlsPreviousValues.FormPaymentParameters[2];
                txtYear.Text = userControlsPreviousValues.FormPaymentParameters[3];
                txtAuthorizationCode.Text = userControlsPreviousValues.FormPaymentParameters[4];
                txtCardAmount.Text = userControlsPreviousValues.FormPaymentParameters[5];
                chkExtendetPayment.Checked = (userControlsPreviousValues.FormPaymentParameters[6].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                cmbMonths.Text = userControlsPreviousValues.FormPaymentParameters[7];
                userControlsPreviousValues.FormPaymentParameters = null;
                // statusParamReceived = false;
            }
        }

        /// <summary>
        /// Se guardan los valores ingresados en los TextBox
        /// </summary>
        private void LoadParametersValues()
        {
            string[] sendInfo = new string[] {txtTypeCard.Text,txtNumberCard.Text,
                txtMonth.Text,txtYear.Text,txtAuthorizationCode.Text,txtCardAmount.Text,
                chkExtendetPayment.Checked.ToString(), cmbMonths.Text};
            userControlsPreviousValues.FormPaymentParameters = sendInfo;
        }

        //Evalúa las opciones de las tarjetas de crédito en INTEGRA
        private void CompareCreditCardNumber()
        {
            string creditCard = string.Empty;
            string typeCard = txtTypeCard.Text;
            string compTypeCard = string.Empty;
            bank = cmbBank.Text;
            typeCard = txtTypeCard.Text;

            if (chkCTS.Checked)
            {
                if (ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS)
                {
                    ///Valida que la tarjeta ingresada corresponda a las tarjetas de CTS...
                    WsMyCTS wsServ = new WsMyCTS();
                    creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCard.Text);

                    //creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCard.Text);

                    if (string.IsNullOrEmpty(creditCard))
                    {
                        MessageBox.Show("El numero de tarjeta capturado no corresponde a ninguna tarjeta de CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCard.Focus();
                    }
                    else
                    {
                        CommandsSend();

                        if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                        else
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                    }
                }

                else if ((ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_CREDITCARD ||
                    ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS) &&
                    (typeCard == "AX" || typeCard == "TP" || typeCard == "DC" || typeCard == "CA" || typeCard == "VI"))
                {
                    ///Se crea un objeto del servicio WsMyCTS para poder utilizar los métodos disponibles...
                    ///En este caso se utiliza el método GetCreditCardNumberCTS para validar que la tarjeta ingresada
                    /// pertenezca a CTS...
                    WsMyCTS wsServ = new WsMyCTS();
                    creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCard.Text);
                    if (string.IsNullOrEmpty(creditCard))
                    {
                        MessageBox.Show("El numero de tarjeta capturado no corresponde a ninguna tarjeta de CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCard.Focus();
                    }
                    else
                    {
                        CommandsSend();

                        if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                        else
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                    }
                }
                else
                {
                    //Valida que el numero de tarjeta exista para seguir con el proceso...
                    creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCard.Text);
                    //  creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCard.Text);

                    if (string.IsNullOrEmpty(creditCard))
                    {
                        MessageBox.Show("El numero de tarjeta capturado no corresponde a ninguna tarjeta de CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCard.Focus();
                    }
                    else
                    {
                        CommandsSend();

                        if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                        else
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                    }
                }

            }

            if (chkClient.Checked)
            {
                if ((ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_CREDITCARD ||
                    ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS)
                    && (typeCard == "AX" || typeCard == "TP"))
                {
                    if (typeCard == "AX")
                        compTypeCard = "AMEX";
                    else if (typeCard == "TP")
                        compTypeCard = "AIR";

                    //Valida si existe la tarjeta de credito, para validar que pertenece a CTS
                    creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCard.Text); //Busca si la tarjeta pertenece a cts
                    //creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCard.Text);

                    if (string.IsNullOrEmpty(creditCard))
                    {
                        ///Obtiene el nuero de tarjeta ingresado validando el numero de tarjeta y el DK...
                        MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(txtNumberCard.Text, ucFirstValidations.dk);
                        ///Aqui valida si el numero de tarjeta tiene un dk diferente
                        //ClientCreditCard clientCreditCard = GetClientCreditCardNumberBL.GetClientCreditCardNumber(txtNumberCard.Text, ucFirstValidations.DK);

                        if (clientCreditCard.CreditCardNumber != null)
                        {
                            if (clientCreditCard.CreditCardNumber == txtNumberCard.Text && clientCreditCard.Client != ucFirstValidations.dk)
                            {
                                MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNumberCard.Focus();
                            }

                            else if (ValidateCreditCardNumber)
                            {
                                if (clientCreditCard.CreditCardNumber == txtNumberCard.Text && (clientCreditCard.Client == ucFirstValidations.DK && clientCreditCard.Type == compTypeCard))
                                {
                                    CommandsSend();
                                    if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                                    else
                                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                                }
                                else if (clientCreditCard.CreditCardNumber == txtNumberCard.Text && (clientCreditCard.Client == ucFirstValidations.DK && clientCreditCard.Type != compTypeCard))
                                {
                                    MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typeCard +
                                    " ligada al cliente DK: " + ucFirstValidations.DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }
                        else
                        {
                            //Obtiene el numero de tarjeta ingresado, si la obtiene 
                            //mandara el mensaje de que la tarjeta pertenece a otro cliente...
                            string clientCreditCardNumber = wsServ.GetClientCreditCardNumberATT(txtNumberCard.Text);
                            //string clientCreditCardNumber = GetClientCreditCardNumberBL.GetClientCreditCardNumber(txtNumberCard.Text);

                            if (string.IsNullOrEmpty(clientCreditCardNumber))
                            {
                                if (ValidateCreditCardNumber)
                                {
                                    if (!flag)
                                    {
                                        //Obtiene la tarjeta por medio del DK para validar que no exista,
                                        //si existe validara el tipo de tarjeta, si no seguira con el proceso...
                                        MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.dk);
                                        //ClientCreditCard infoCreditCard = GetClientCreditCardNumberBL.GetClientCreditCardNumberByClient(ucFirstValidations.DK);
                                        if (infoCreditCard.Client != null)
                                        {
                                            if (infoCreditCard.Type == "AIR")
                                            {
                                                infoCreditCard.Type = "AIRPLUS";
                                            }
                                            else if (infoCreditCard.Type == "AMEX")
                                            {
                                                infoCreditCard.Type = "EBTA";
                                            }

                                            DialogResult yesNo = MessageBox.Show("La forma de pago no corresponde al tipo " + infoCreditCard.Type +
                                            " ligada al cliente DK: " + ucFirstValidations.DK + "\n¿Desea continuar con la emisión?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (yesNo.Equals(DialogResult.Yes))
                                            {
                                                CommandsSend();
                                                if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                                                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                                                else
                                                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                                            }
                                        }
                                        else
                                        {
                                            CommandsSend();
                                            if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                                            else
                                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                                        }
                                    }
                                    else
                                    {
                                        CommandsSend();
                                        if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                                        else
                                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNumberCard.Focus();
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("El número de tarjeta ingresado pertenece a CTS. Corrige el número de tarjeta del cliente o indica que pertenece a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCard.Focus();
                    }
                }

                else
                {
                    //Obtine la tarjeta para validar que no exista
                    WsMyCTS wsServ = new WsMyCTS();
                    creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCard.Text);
                    //creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCard.Text);

                    if (string.IsNullOrEmpty(creditCard))
                    {
                        CommandsSend();
                        if ((validPromo && applyPromo) && !string.IsNullOrEmpty(Promo.Airline))
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PROMO);
                        else
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                    }
                    else
                    {
                        MessageBox.Show("El número de tarjeta ingresado pertenece a CTS. Corrige el número de tarjeta del cliente o indica que pertenece a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCard.Focus();
                    }
                }
            }
        }


        /// <summary>
        /// Obtinen el monto de los boletos que se van a emitir de acuerdo al
        /// numero de segmentos, aerolínea con que se emite y otros aspectos; 
        /// esto se hace via API
        /// </summary>
        private void GetBaseFare()
        {
            int Taxes_OBFEE = 0;
            int Taxes_ADT = 0;
            int Taxes_CNN = 0;
            int Taxes_INF = 0;
            int Taxes_fee = 0;
            string[] END_OF_SCROLL_T;
            string END_OF_SCROLL_P = string.Empty;
            string OBFCA_CC_VAL = string.Empty;
            string OBFCA_FEE_VAL = string.Empty;
            string passenger_ADT = string.Empty;
            string passenger_CNN = string.Empty;
            string passenger_INF = string.Empty;
            string feetaxes = string.Empty;
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            string sabreAnswer2 = string.Empty;
            string sabreAnswer_OBFEE = string.Empty;
            string sabreAnswer_OBFEE_MD = string.Empty;
            string tarifa = string.Empty;
            string tourCode = string.Empty;
            string phase35375 = string.Empty;
            string[] rows;
            if (ucTicketsEmissionInstructions.ticketType == "rdoPhase35375")
                phase35375 = ucPhase35375Tickets.Phase35375;
            else
                phase35375 = string.Empty;
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.quaNegociated))
                tarifa = string.Concat(Resources.Constants.CROSSLORAINE, "P", ucTicketsEmissionInstructions.quaNegociated);
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.corporateID))
                tarifa = string.Concat(Resources.Constants.CROSSLORAINE, "I", ucTicketsEmissionInstructions.corporateID);
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.accountCode))
                tarifa = string.Concat(Resources.Constants.CROSSLORAINE, "AC*", ucTicketsEmissionInstructions.accountCode);
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.tourCodeAgreements))
                tourCode = string.Concat(Resources.Constants.CROSSLORAINE, ucTicketsEmissionInstructions.tourCodeAgreements, ucTicketsEmissionInstructions.tourCode);
            if (string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments) && string.IsNullOrEmpty(ucTicketsEmissionInstructions.byNames)
                && (string.IsNullOrEmpty(tarifa) && string.IsNullOrEmpty(phase35375) && string.IsNullOrEmpty(tourCode)))
                sendCommandWP = string.Concat(Resources.Constants.COMMANDS_WP, "A", ucTicketsEmissionInstructions.Airline,
               tarifa, tourCode, ucTicketsEmissionInstructions.byNames, ucTicketsEmissionInstructions.bySegments,
               ucTicketsEmissionInstructions.quarrelType, phase35375);

            else
                sendCommandWP = string.Concat(Resources.Constants.COMMANDS_WP, "A", ucTicketsEmissionInstructions.Airline,
                tarifa, tourCode, ucTicketsEmissionInstructions.byNames, ucTicketsEmissionInstructions.bySegments,
                ucTicketsEmissionInstructions.quarrelType, phase35375);


            int row = 0;
            int col = 0;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {

                    sabreAnswer = objCommand.SendReceive(sendCommandWP);
                    sabreAnswer2 = sabreAnswer;
                }
            }
            catch { }
            //busca pasajeros Adultos
            if ((ucTicketsEmissionInstructions.Airline == "LH"))
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.PAX_ADT, ref row, ref col);

                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(sabreAnswer, ref passenger_ADT, row, 5, 4);
                    passenger_ADT = passenger_ADT.Trim();
                }

                else
                {
                    passenger_ADT = null;
                }
                //Busca los pasajeros menores

                CommandsQik.searchResponse(sabreAnswer2, Resources.TicketEmission.ValitationLabels.PAX_CNN, ref row, ref col);
                CommandsQik.CopyResponse(sabreAnswer, ref passenger_CNN, row, 1, 4);
                passenger_CNN = passenger_CNN.Trim();

                if (passenger_CNN == Resources.TicketEmission.ValitationLabels.PAX_CNN)
                {
                    if (row != 0 || col != 0)
                    {
                        CommandsQik.CopyResponse(sabreAnswer, ref passenger_CNN, row, 5, 4);
                        passenger_CNN = passenger_CNN.Trim();
                    }
                }
                else
                {
                    passenger_CNN = null;
                }

                //Busca los pasajeros infantes
                CommandsQik.searchResponse(sabreAnswer2, Resources.TicketEmission.ValitationLabels.PAX_INF, ref row, ref col);
                CommandsQik.CopyResponse(sabreAnswer, ref passenger_INF, row, 1, 4);
                passenger_INF = passenger_INF.Trim();
                if (passenger_INF == Resources.TicketEmission.ValitationLabels.PAX_INF)
                {
                    if (row != 0 || col != 0)
                    {
                        CommandsQik.CopyResponse(sabreAnswer, ref passenger_INF, row, 5, 4);
                        passenger_INF = passenger_INF.Trim();
                    }
                }
                else
                {
                    passenger_INF = null;
                }



                send = Resources.TicketEmission.Constants.COMMANDS_MD;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer_OBFEE = objCommand.SendReceive(send);
                }
                // Evaluas
                // Si esta no termina en End_Of_Scroll mandas MD (MoveDown ) hasta obtenerlo

                CommandsQik.searchResponse(sabreAnswer_OBFEE, Resources.TicketEmission.ValitationLabels.END_OF_SCROLL, ref row, ref col);
                // Al finalizar mandas el end of scroll
                if (row != 0 || col != 0)
                {
                    int t = 0;

                    rows = sabreAnswer_OBFEE.Split('\n');
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (rows[i].Contains("END OF SCROLL"))
                        {
                            CommandsQik.searchResponse(sabreAnswer_OBFEE, Resources.TicketEmission.ValitationLabels.END_OF_SCROLL, ref row, ref col);
                            CommandsQik.CopyResponse(sabreAnswer_OBFEE, ref END_OF_SCROLL_P, row, 2, 13);
                            END_OF_SCROLL_P = END_OF_SCROLL_P.Trim();
                            rows = END_OF_SCROLL_P.Split('\n');

                            //END_OF_SCROLL_P = rows[i].Substring(15, rows[i].Length - 15);

                        }
                        if (string.IsNullOrEmpty(END_OF_SCROLL_P))
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                sabreAnswer_OBFEE_MD = objCommand.SendReceive(send);
                            }



                            CommandsQik.searchResponse(sabreAnswer_OBFEE_MD, Resources.TicketEmission.ValitationLabels.END_OF_SCROLL, ref row, ref col);
                            CommandsQik.CopyResponse(sabreAnswer_OBFEE_MD, ref END_OF_SCROLL_P, row, 2, 13);
                            END_OF_SCROLL_P = END_OF_SCROLL_P.Trim();
                            rows = END_OF_SCROLL_P.Split('\n');
                        }

                    }

                    //if (rows == Resources.TicketEmission.ValitationLabels.END_OF_SCROLL) { }               
                }



                //if (Resources.TicketEmission.ValitationLabels.OBFCA_FEE== OBFCA_FEE_VAL  )
                //{
                if (Resources.TicketEmission.ValitationLabels.END_OF_SCROLL == END_OF_SCROLL_P)
                {
                    if (sabreAnswer.Contains("OBFCA - ANY CC"))
                    {
                        OBFCA_FEE_VAL = "OBFCA - ANY CC";
                    }
                    if (OBFCA_FEE_VAL == Resources.TicketEmission.ValitationLabels.OBFCA_FEE)
                    {
                        CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.OBFCA_FEE, ref row, ref col);
                        CommandsQik.CopyResponse(sabreAnswer, ref feetaxes, row, 37, 36);
                        feetaxes = feetaxes.Trim();
                    }
                    else
                    {
                        CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.OBFCA_CC, ref row, ref col);
                        CommandsQik.CopyResponse(sabreAnswer, ref OBFCA_CC_VAL, row, 2, 15);
                        OBFCA_CC_VAL = OBFCA_CC_VAL.Trim();


                        if (OBFCA_CC_VAL == Resources.TicketEmission.ValitationLabels.OBFCA_CC)
                        {
                            CommandsQik.CopyResponse(sabreAnswer, ref feetaxes, row, 37, 36);
                            feetaxes = feetaxes.Trim();
                        }
                    }

                    // CommandsQik.searchResponse(sabreAnswer_OBFEE, Resources.TicketEmission.ValitationLabels.OBFCA_FEE, ref row, ref col);
                    END_OF_SCROLL_T = sabreAnswer_OBFEE.Split('\n');

                    if (!END_OF_SCROLL_T[0].Contains("END OF SCROLL") && !END_OF_SCROLL_T[0].Contains("AIR EXTRAS AVAILABLE - SEE WP*AE."))
                    {
                        //CommandsQik.CopyResponse(END_OF_SCROLL_T[3], ref OBFCA_FEE_VAL, row, 1, 16);
                        //OBFCA_FEE_VAL = OBFCA_FEE_VAL.Trim();

                        if (sabreAnswer_OBFEE.Contains("OBFCA - ANY CC"))
                        {
                            OBFCA_FEE_VAL = "OBFCA - ANY CC";
                        }
                        if (OBFCA_FEE_VAL == Resources.TicketEmission.ValitationLabels.OBFCA_FEE)
                        {
                            CommandsQik.searchResponse(sabreAnswer_OBFEE, Resources.TicketEmission.ValitationLabels.OBFCA_FEE, ref row, ref col);
                            CommandsQik.CopyResponse(sabreAnswer_OBFEE, ref feetaxes, row, 37, 36);
                            feetaxes = feetaxes.Trim();
                        }
                        else
                        {
                            //CommandsQik.CopyResponse(END_OF_SCROLL_T[4], ref OBFCA_FEE_VAL, row, 1, 16);
                            //OBFCA_FEE_VAL = OBFCA_FEE_VAL.Trim();

                            if (sabreAnswer_OBFEE.Contains("OBFCA - CC NBR"))
                            {
                                OBFCA_FEE_VAL = "OBFCA - CC NBR";
                            }

                            if (OBFCA_FEE_VAL == Resources.TicketEmission.ValitationLabels.OBFCA_CC)
                            {
                                Taxes_fee = 0;
                                feetaxes = (Convert.ToString(Taxes_fee));
                            }
                        }
                    }
                }


                // Evalua y multiplica las tarifas para pasajeros
                if ((Convert.ToInt32(feetaxes) >= 0) & (Convert.ToInt32(passenger_ADT) >= 0))
                {
                    Taxes_ADT = Convert.ToInt32(feetaxes) * Convert.ToInt32(passenger_ADT);
                }

                if ((Convert.ToInt32(feetaxes) >= 0) & (Convert.ToInt32(passenger_CNN) >= 0))
                {
                    Taxes_CNN = Convert.ToInt32(feetaxes) * Convert.ToInt32(passenger_CNN);
                }
                if ((Convert.ToInt32(feetaxes) >= 0) & (Convert.ToInt32(passenger_INF) >= 0))
                {
                    Taxes_INF = Convert.ToInt32(feetaxes) * Convert.ToInt32(passenger_INF);
                }

                if ((Convert.ToInt32(Taxes_CNN) >= 0) & (Convert.ToInt32(Taxes_ADT) >= 0) & (Convert.ToInt32(Taxes_INF) >= 0))
                {
                    Taxes_OBFEE = Convert.ToInt32(Taxes_CNN) + Convert.ToInt32(Taxes_ADT) + Convert.ToInt32(Taxes_INF);
                }
                else if ((Convert.ToInt32(Taxes_CNN) >= 0) & (Convert.ToInt32(Taxes_ADT) >= 0))
                {
                    Taxes_OBFEE = Convert.ToInt32(Taxes_CNN) + Convert.ToInt32(Taxes_ADT);
                }
                else if ((Convert.ToInt32(Taxes_ADT) >= 0))
                {
                    Taxes_OBFEE = Taxes_ADT;
                }
                else if ((Convert.ToInt32(Taxes_CNN) >= 0))
                {
                    Taxes_OBFEE = Taxes_CNN;
                }
                //calculo del total para LH
            }
                MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                    if (row != 0 || col != 0)
                    {
                        int t = 0;
                        string temp_total = string.Empty;
                        rows = sabreAnswer.Split('\n');
                        for (int i = 0; i < rows.Length; i++)
                        {
                            if (rows[i].Contains("TTL"))
                            {
                                temp_total = rows[i].Substring(50, rows[i].Length - 50);

                            }
                        }

                        temp_total = temp_total.Replace("TTL", Resources.TicketEmission.Constants.SPACE);
                        temp_total = temp_total.Trim();
                        Total = temp_total;



                    }
                }
            //}

            row = 0; col = 0;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 5, 14);
                    baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                }
                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col, 1, 4, 15, 40);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    baseFare = string.Empty;
                    CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 19, 14);
                    baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();

                }
                else
                {
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        baseFare = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 5, 14);
                        baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                    }
                }
            }

            if (!sabreAnswer.Contains("TTL"))
            {
                txtCardAmount.Text = string.Empty;
                applyPromo = false;
                BaseFare = string.Empty;
                Total = string.Empty;
            }
            lhfeeamount = 0;
            lhfeeamount = Taxes_OBFEE;

        }


        private bool ValidatePromoRules
        {
            get
            {
                if (!string.IsNullOrEmpty(Promo.Airline))
                {
                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.Amount))
                    {
                        if (Convert.ToInt32(ucFormPayment.Promo.Amount) > Convert.ToInt32(txtCardAmount.Text))
                        {
                            MessageBox.Show("Monto de pago es menor al necesario para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                            isValidPromo = true;
                    }


                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.Origen))
                    {
                        GetSegments();
                        if (ucFormPayment.Promo.Origen.Contains(segments1[0]))
                        {
                            isValidPromo = true;
                        }
                        else
                        {
                            MessageBox.Show("No se cumple la condición de Origen, para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }


                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.Destination))
                    {
                        if (segments1 == null)
                            GetSegments();

                        if (ucFormPayment.Promo.Destination.Contains(segments1[lengSeg - 1]))
                        {
                            isValidPromo = true;
                        }
                        else
                        {
                            MessageBox.Show("No se cumple la condición de Ciudad de Destino, para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }


                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.OrigenZone))
                    {
                        if (segments1 == null)
                            GetSegments();

                        string zoneOrigen = GetZoneByCityBL.GetZoneByCuty(segments1[0]);

                        if (!string.IsNullOrEmpty(zoneOrigen))
                        {
                            if (ucFormPayment.Promo.OrigenZone.Contains(zoneOrigen))
                            {
                                isValidPromo = true;
                            }
                            else
                            {
                                MessageBox.Show("No se cumple la condición de la Zona de Origen, para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se cumple la condición de la Zona de Origen, para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.DestinationZone))
                    {
                        if (segments1 == null)
                            GetSegments();

                        string zoneDestination = GetZoneByCityBL.GetZoneByCuty(segments1[lengSeg - 1]);
                        if (!string.IsNullOrEmpty(zoneDestination))
                        {
                            if (ucFormPayment.Promo.DestinationZone.Contains(zoneDestination))
                            {
                                isValidPromo = true;
                            }
                            else
                            {
                                MessageBox.Show("No se cumple la condición de Zona de Destino, para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se cumple la condición de Zona de Destino, para aplicar la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    if (!ucFormPayment.Promo.SharedFlight)
                    {
                        string seg = string.Empty;
                        string res = string.Empty;

                        seg = string.Concat("*I");
                        using (CommandsAPI2 objCommand = new CommandsAPI2())
                        {
                            res = objCommand.SendReceive(seg, 0, 0);
                        }
                        if (res.Contains("OPERATED"))
                        {
                            MessageBox.Show("La promoción no permite vuelos compartidos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    if (ucFormPayment.Promo.ApplyDatePromoFlight)
                    {

                        if (segments1 == null)
                            GetSegments();

                        for (int i = 0; i < datesFlights.Length; i++)
                        {
                            if (Convert.ToDateTime(datesFlights[i]) > ucFormPayment.Promo.DatePromoBegin && Convert.ToDateTime(datesFlights[i]) < ucFormPayment.Promo.DatePromoEnd)
                            {
                                isValidPromo = true;
                            }
                            else
                            {
                                MessageBox.Show("El vuelo está fuera de las fechas de promoción.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }

                        if (DateTime.Today < ucFormPayment.Promo.DatePromoBegin || DateTime.Today > ucFormPayment.Promo.DatePromoEnd)
                        {
                            MessageBox.Show("La fecha de emisión está fuera de las fechas de promoción.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.IncludedClasses))
                    {
                        for (int i = 0; i < flightClasses.Length; i++)
                        {
                            if (ucFormPayment.Promo.IncludedClasses.Contains(flightClasses[i]))
                            {
                                isValidPromo = true;
                            }
                            else
                            {
                                MessageBox.Show("El vuelo está fuera de las fechas de promoción.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(ucFormPayment.Promo.ExcludedClasses))
                    {
                        if (segments1 == null)
                            GetSegments();

                        for (int i = 0; i < flightClasses.Length; i++)
                        {
                            if (ucFormPayment.Promo.ExcludedClasses.Contains(flightClasses[i]))
                            {
                                MessageBox.Show("El vuelo está fuera de las fechas de promoción.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                isValidPromo = true;
                            }
                        }
                    }

                    if (segments1 == null)
                        GetSegments();


                    for (int i = 0; i < airlines.Length; i++)
                    {
                        if (ucTicketsEmissionInstructions.Airline != airlines[i])
                        {
                            MessageBox.Show("El viaje no se realiza con la aerolínea de la promoción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {
                            isValidPromo = true;
                        }
                    }
                    return isValidPromo;
                }
                else
                {
                    return false;
                }
            }
        }


        private void GetSegments()
        {
            int row = 0, col = 0;
            string seg = string.Empty;
            string bysegment = string.Empty;
            string res = string.Empty;
            string itinerary = string.Empty;
            int aux = 0;
            string airlinesSegment = string.Empty;
            string airlineItin = string.Empty;
            string classesSegment = string.Empty;
            string classesItin = string.Empty;
            string datesSegment = string.Empty;
            string datesItin = string.Empty;

            if (string.IsNullOrEmpty(commandSegment))
            {
                if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments) ||
                                    !string.IsNullOrEmpty(ucPhase35375Tickets.segment))
                {
                    string konnect = string.Empty;
                    int lenght = 0;
                    int resplenght = 0;
                    int lenghtcommand = 0;
                    int row1 = 0;
                    int col1 = 0;
                    int i = 0;
                    int j = 0;

                    if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments))
                        bysegment = ucTicketsEmissionInstructions.bySegments.Replace("‡S", " ").Trim();
                    else if (!string.IsNullOrEmpty(ucPhase35375Tickets.segment))
                        bysegment = ucPhase35375Tickets.segment;

                    seg = string.Concat("*IA");
                    using (CommandsAPI2 objCommand = new CommandsAPI2())
                    {
                        res = objCommand.SendReceive(seg, 0, 0);
                    }

                    segments1 = bysegment.Split(new char[] { '/' });



                    for (int a = 0; a < segments1.Length; a++)
                    {
                        col = 0; row = 0;
                        CommandsQik.searchResponse(segments1[a], "-", ref row, ref col);
                        if (col != 0 || row != 0)
                        {
                            int num1 = 0;
                            int num2 = 0;

                            string[] seg1 = segments1[a].Split(new char[] { '-' });
                            string replace = string.Empty;
                            string bysegment2 = string.Empty;

                            num1 = Convert.ToInt32(seg1[0]);
                            num2 = Convert.ToInt32(seg1[1]);

                            for (int f = num1; f <= num2; f++)
                            {
                                bysegment2 = string.Concat(bysegment2, f.ToString(), "/");
                            }
                            bysegment2 = bysegment2.Remove(bysegment2.Length - 1, 1);
                            replace = string.Concat(num1.ToString(), "-", num2.ToString());
                            bysegment = bysegment.Replace(replace, bysegment2);
                        }
                    }

                    string[] segments = bysegment.Split(new char[] { '/' });
                    lenght = segments.Length - 1;


                    string[] resp = res.Split(new char[] { '\n' });
                    resplenght = resp.Length;


                    for (i = 0; i <= lenght; i++)
                    {

                        for (j = 1; j <= resplenght; j++)
                        {
                            j = aux + 1;
                            if (!string.IsNullOrEmpty(resp[j]))
                            {
                                col = 0; row = 0; col1 = 0; row1 = 0;
                                CommandsQik.searchResponse(resp[j], "ARNK", ref row, ref col);
                                if (row == 0 || col == 0)
                                {
                                    col = 0; row = 0; col1 = 0; row1 = 0;
                                    CommandsQik.searchResponse(resp[j], segments[i], ref row, ref col, 1, 3, 1, 3);
                                    if (row != 0 || col != 0)
                                    {
                                        CommandsQik.CopyResponse(resp[j], ref itinerary, row, 19, 8);
                                        itinerary = itinerary.Replace("*", "").Trim();
                                        commandSegment = string.Concat(commandSegment, itinerary.Substring(0, 3), ".",
                                            itinerary.Substring(3, 3), ".");

                                        CommandsQik.CopyResponse(resp[j], ref airlineItin, row, 4, 2);
                                        airlinesSegment = string.Concat(airlinesSegment, airlineItin, '.');

                                        CommandsQik.CopyResponse(resp[j], ref datesItin, row, 12, 5);
                                        datesItin = string.Concat(datesItin, DateTime.Today.Year);
                                        datesSegment = string.Concat(datesSegment, datesItin, '.');

                                        CommandsQik.CopyResponse(resp[j], ref classesItin, row, 10, 1);
                                        classesSegment = string.Concat(classesSegment, classesItin, '.');

                                        aux = j;
                                        break;
                                    }
                                }
                            }
                            aux = j;
                        }
                    }


                    commandSegment = commandSegment.Remove(commandSegment.Length - 1);
                    segments1 = commandSegment.Split('.');
                    lengSeg = segments1.Length;

                    airlinesSegment = airlinesSegment.Remove(airlinesSegment.Length - 1);
                    airlines = airlinesSegment.Split('.');

                    datesSegment = datesSegment.Remove(datesSegment.Length - 1);
                    datesFlights = datesSegment.Split('.');

                    classesSegment = classesSegment.Remove(classesSegment.Length - 1);
                    flightClasses = classesSegment.Split('.');




                }
                else
                {
                    seg = string.Concat("*IAB");
                    using (CommandsAPI2 objCommand = new CommandsAPI2())
                    {
                        res = objCommand.SendReceive(seg, 0, 0);
                    }

                    bysegment = res;
                    segments1 = bysegment.Split(new char[] { '\n' });
                    for (int i = 1; i < segments1.Length; i++)
                        for (int j = 1; j < segments1.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(segments1[j]))
                            {
                                col = 0; row = 0;
                                CommandsQik.searchResponse(segments1[j], "ARNK", ref row, ref col);
                                if (row == 0 || col == 0)
                                {
                                    col = 0; row = 0;
                                    CommandsQik.searchResponse(segments1[j], i.ToString(), ref row, ref col, 1, 3, 1, 3);
                                    if (row != 0 || col != 0)
                                    {
                                        CommandsQik.CopyResponse(segments1[j], ref itinerary, row, 19, 8);
                                        itinerary = itinerary.Replace("*", "").Trim();
                                        commandSegment = string.Concat(commandSegment, itinerary.Substring(0, 3), ".",
                                            itinerary.Substring(3, 3), ".");

                                        CommandsQik.CopyResponse(segments1[j], ref airlineItin, row, 4, 2);
                                        airlinesSegment = string.Concat(airlinesSegment, airlineItin, '.');

                                        CommandsQik.CopyResponse(segments1[j], ref datesItin, row, 12, 5);
                                        datesItin = string.Concat(datesItin, DateTime.Today.Year);
                                        datesSegment = string.Concat(datesSegment, datesItin, '.');

                                        CommandsQik.CopyResponse(segments1[j], ref classesItin, row, 10, 1);
                                        classesSegment = string.Concat(classesSegment, classesItin, '.');

                                        break;
                                    }
                                }
                            }
                        }
                    commandSegment = commandSegment.Replace('.', ' ').TrimEnd();
                    commandSegment = commandSegment.Replace(' ', '.');

                    segments1 = commandSegment.Split('.');
                    lengSeg = segments1.Length;

                    airlinesSegment = airlinesSegment.Replace('.', ' ').TrimEnd();
                    airlinesSegment = airlinesSegment.Replace(' ', '.');
                    airlines = airlinesSegment.Split('.');

                    datesSegment = datesSegment.Replace('.', ' ').TrimEnd();
                    datesSegment = datesSegment.Replace(' ', '.');
                    datesFlights = datesSegment.Split('.');

                    classesSegment = classesSegment.Replace('.', ' ').TrimEnd();
                    classesSegment = classesSegment.Replace(' ', '.');
                    flightClasses = classesSegment.Split('.');
                }
            }
        }

        /// <summary>
        /// Gets the lufthansa airline fee.
        /// </summary>
        /// <param name="sabreAnswer">The sabre answer to analyse </param>
        /// <returns></returns>
        private double GetLufthansaFee(string sabreAnswer)
        {
            double feeAmount = 0;
            try
            {
                int row = 0, col = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.FORM_PAYMENT_FEE_APPLY, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = 0;
                    col = 0;
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.ANY_CC_LH_FEE, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        string strFeeAmount = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswer, ref strFeeAmount, row, 20, 40);
                        if (!string.IsNullOrEmpty(strFeeAmount))
                        {
                            strFeeAmount = strFeeAmount.Trim();
                            feeAmount = Convert.ToDouble(strFeeAmount);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al validar cargo lufthansa. Comunicarse con sistemas.");
            }
            return feeAmount;
        }

        #endregion

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowCreditCard(0);
            //btnShow.Visible = false;
        }

        private void lnLHInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lnLHInfo.Text);
        }

        private void btnShowCTS_Click(object sender, EventArgs e)
        {
            ShowCreditCard(1);
            //btnShowCTS.Visible = false;
        }

        private void cmbTypeCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeCard.SelectedIndex > 0)
            {
                ListItem item = (ListItem)cmbTypeCard.SelectedItem;
                if (item.Value.Equals("CASH"))
                {
                    txtNumberCardCTS.Text = string.Empty;
                    txtNumberCardCTS.Visible = false;
                    lblCardNumberCTS.Visible = false;
                    btnShowCTS.Visible = false;
                }
                else if (item.Value.Equals("TR") || item.Value.Equals("CH"))
                {
                    btnShowCTS.Visible = false;
                    txtNumberCardCTS.MaxLength = 4;
                    lblCardNumberCTS.Text = "Número de cuenta";
                    lblCardNumberCTS.Visible = true;
                    WsMyCTS wsServ = new WsMyCTS();
                    MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber data = new MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber();
                    data = wsServ.GetTranferCheckNumberMyCTS(ucFirstValidations.dk);
                    txtNumberCardCTS.Text = data.ct_banc_cbr;
                    //OracleConnection oracle = new OracleConnection();
                    //txtNumberCardCTS.Text = oracle.GetTranferCheckNumber(ucFirstValidations.dk);
                    txtNumberCardCTS.Visible = true;
                }
                else
                {
                    btnShowCTS.Visible = true;
                    lblCardNumberCTS.Text = "Número de tarjeta";
                    lblCardNumberCTS.Visible = true;
                    txtNumberCardCTS.Visible = true;
                    txtNumberCardCTS.MaxLength = 16;
                }
            }
        }

        private void LoadFormPaymentCodes()
        {
            List<ListItem> listFOP = CatCreditCardsCodesBL.GetFOPCTSListSinFoPTP();

            foreach (ListItem FOPItem in listFOP)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    FOPItem.Value,
                    FOPItem.Text);
                litem.Value = FOPItem.Value;
                litem.Text2 = FOPItem.Text2;
                cmbTypeCard.Items.Add(litem);

            }
            cmbTypeCard.SelectedIndex = 0;
        }

        private void cmbTypeCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            else if (e.KeyData == Keys.Escape)
            {
                ReturnForMisc = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            }
            if (e.KeyData == Keys.Escape)
            {
                ReturnForMisc = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            }
        }

        //private void txtCardNumberCTS_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(txtNumberCardCTS.Text))
        //        {
        //            string creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCardCTS.Text);
        //            if (!string.IsNullOrEmpty(creditCard))
        //            {
        //                MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                txtNumberCardCTS.Text = string.Empty;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al validar tarjeta. Reintente");
        //        txtNumberCardCTS.Text = string.Empty;
        //    }
        //}

        public void ValidaTarjetaFoPaCTS()
        {
            //#region Codigo correcto
            string creditCard = string.Empty;
            string typeCard = cmbTypeCard.Text;
            string compTypeCard = string.Empty;
            bank = cmbBank.Text;
            typeCard = cmbTypeCard.Text;
            string creditCard2 = string.Empty;
            string tipsTarjeta = string.Empty;

            ///Se valida si la FoP es en EFECTIVO, si es asi regresa true para que entre al metodo CompareCreditCardNumber.
            if (cmbTypeCard.Text != "CASH - EFECTIVO")
            {
                ///Se valida si la FoP es en CHEQUE si es asi regresa true para que entre al método CompareCreditCardNumber.
                if (cmbTypeCard.Text != "CH - CHEQUE")
                {
                    ///Se valida si la FoP es en TRANSFERENCIA si es asi regresa true para que entre al método CompareCreditCardNumber.
                    if (cmbTypeCard.Text != "TR - TRANSFERENCIA")
                    {
                        ///Se valida la FoP 
                        if ((ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_CREDITCARD ||
                                ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS)
                                && (typeCard == "AX - TC AMEX" || typeCard == "TP - TC UATP"))
                        {
                            if (typeCard == "AX - TC AMEX")
                            {
                                compTypeCard = "AMEX";
                            }
                            else if (typeCard == "TP - TC UATP")
                            {
                                compTypeCard = "AIR";
                            }

                            ///Valida si existe la tarjeta de credito, para validar que pertenece a CTS
                            creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCardCTS.Text); //Busca si la tarjeta pertenece a cts

                            if (string.IsNullOrEmpty(creditCard))
                            {
                                ///Obtiene el numero de tarjeta ingresado validando el numero de tarjeta y el DK...
                                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(txtNumberCardCTS.Text, ucFirstValidations.DK);

                                ///Aqui valida si el numero de tarjeta tiene un dk diferente
                                if (clientCreditCard.CreditCardNumber != null)
                                {
                                    if (clientCreditCard.CreditCardNumber == txtNumberCardCTS.Text && clientCreditCard.Client != ucFirstValidations.DK)
                                    {
                                        MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtNumberCardCTS.Text = string.Empty;
                                        txtNumberCardCTS.Focus();
                                        flags = false;
                                    }
                                    ///Valida que la forma de pago corresponda con la tarjeta ingresada...
                                    else if (ValidateCreditCardNumberFoPCTS)
                                    {
                                        if (clientCreditCard.CreditCardNumber == txtNumberCardCTS.Text && (clientCreditCard.Client == ucFirstValidations.DK && clientCreditCard.Type == compTypeCard))
                                        {
                                            flags = true;
                                        }
                                        else if (clientCreditCard.CreditCardNumber == txtNumberCardCTS.Text && (clientCreditCard.Client == ucFirstValidations.DK && clientCreditCard.Type != compTypeCard))
                                        {
                                            if (clientCreditCard.Type == "AIR")
                                            {
                                                tipsTarjeta = "AIR PLUS";
                                            }

                                            MessageBox.Show("El número de tarjeta corresponde a una tarjeta de tipo " + tipsTarjeta +
                                            " cuando haz indicado que la forma de pago es de tipo " + typeCard + ".\n\nEl DK: " + ucFirstValidations.DK + " tiene asociada una tarjeta de tipo "
                                            + tipsTarjeta + " y no es aceptada como forma de pago para CTS." + "\n\nIngresa un número de tarjeta valido para el DK:"
                                            + ucFirstValidations.DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            txtNumberCardCTS.Text = string.Empty;
                                            txtNumberCardCTS.Focus();
                                            flags = false;
                                        }

                                    }
                                }
                                else
                                {
                                    ///Obtiene el numero de tarjeta ingresado, si la obtiene 
                                    ///mandara el mensaje de que la tarjeta pertenece a otro cliente...
                                    string clientCreditCardNumber = wsServ.GetClientCreditCardNumberATT(txtNumberCardCTS.Text);

                                    if (string.IsNullOrEmpty(clientCreditCardNumber))
                                    {
                                        if (ValidateCreditCardNumberFoPCTS)
                                        {
                                            if (!flag)
                                            {
                                                ///Obtiene la tarjeta por medio del DK para validar que no exista,
                                                ///si existe validara el tipo de tarjeta, si no seguira con el proceso...
                                                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetCreditCardNumberMyCTS(txtNumberCardCTS.Text);
                                                if (infoCreditCard.Client != null)
                                                {
                                                    if (infoCreditCard.Type == "AIR")
                                                    {
                                                        infoCreditCard.Type = "AIRPLUS";
                                                    }
                                                    else if (infoCreditCard.Type == "AMEX")
                                                    {
                                                        infoCreditCard.Type = "EBTA";
                                                    }

                                                    MessageBox.Show("La forma de pago del Cliente a CTS del tipo " + infoCreditCard.Type +
                                                    " no es valida ingrese una forma de pago y numero de tarjeta valido: " + ucFirstValidations.DK + "\n", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                    txtNumberCardCTS.Text = string.Empty;
                                                    txtNumberCardCTS.Focus();
                                                    flags = false;
                                                }
                                            }
                                            else
                                            {
                                                flags = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtNumberCardCTS.Text = string.Empty;
                                        txtNumberCardCTS.Focus();
                                        flags = false;
                                    }
                                }


                            }
                            else
                            {
                                MessageBox.Show("Debe ingresar un número de tarjeta diferente a una de CTS. Reingrese. ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNumberCardCTS.Text = string.Empty;
                                txtNumberCardCTS.Focus();
                                flags = false;
                            }
                        }
                        else
                        {
                            ///Obtine la tarjeta para validar que no exista y si existe manda mensaje..
                            WsMyCTS wsServ = new WsMyCTS();
                            creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCardCTS.Text);

                            if (string.IsNullOrEmpty(creditCard))
                            {
                                flags = true;
                            }
                            else
                            {
                                MessageBox.Show("El número de tarjeta ingresado pertenece a CTS. Corrige el número de tarjeta del cliente o indica que pertenece a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNumberCardCTS.Text = string.Empty;
                                txtNumberCardCTS.Focus();
                                flags = false;
                            }
                        }


                    }
                    else if (cmbTypeCard.Text == "TR - TRANSFERENCIA" && txtNumberCardCTS.Text.Length != 4)
                    {
                        MessageBox.Show("El número de la tarjeta debe ser de 4 digitos. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCardCTS.Focus();
                        flag = false;
                    }
                    else
                    {
                        flags = true;
                    }
                }
                else if (cmbTypeCard.Text == "CH - CHEQUE" && txtNumberCardCTS.Text.Length != 4)
                {
                    MessageBox.Show("El número de la tarjeta debe ser de 4 digitos. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    flag= false;
                }
                else
                {
                    flags = true;
                }
            }
            else
            {
                flags = true;
            }
        }


        /// <summary>
        /// Valida el tipo de tarjeta si es amex, air, tp, etc.
        /// </summary>
        private bool ValidateCreditCardNumberFoPCTS
        {
            get
            {
                bool status = false;
                if (ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS
                    && (cmbTypeCard.Text.Equals("AX - TC AMEX") || cmbTypeCard.Text.Equals("TP - TC UATP")))
                {
                    WsMyCTS wsServ = new WsMyCTS();
                    string tipoCard = string.Empty;
                    if (cmbTypeCard.Text == "AX - TC AMEX")
                    {
                        tipoCard = "AMEX";
                    }
                    if (cmbTypeCard.Text == "TP - TC UATP")
                    {
                        tipoCard = "TP";
                    }

                    string typeCard = cmbTypeCard.Text.Equals("AX - TC AMEX") ? "AMEX" : "AIR";
                    MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard data = new MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard();
                    data = wsServ.GetCreditCardNumberATT(ucFirstValidations.DK, tipoCard, Login.OrgId);
                    string numberCode = data.CreditCardNumber;

                    if (!string.IsNullOrEmpty(numberCode) && !numberCode.Equals(txtNumberCardCTS.Text))
                    {
                        string numberCardShow = numberCode.Substring(numberCode.Length - 4, 4).PadLeft(numberCode.Length, 'X');
                        if (cmbTypeCard.Text.Equals("AX - TC AMEX") || cmbTypeCard.Text.Trim().Equals("VI - TC VISA") || cmbTypeCard.Text.Trim().Equals("VI - TD VISA") || cmbTypeCard.Text.Equals("CA - TC MASTERCARD") || cmbTypeCard.Text.Equals("CA - TD MASTERCARD"))
                        {
                            typeCard = "EBTA";
                            DialogResult yesNo = MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typeCard +
                            " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + typeCard +
                            " es: (" + numberCardShow + ").\n\n¿Desea continuar con la emisión?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (yesNo.Equals(DialogResult.Yes))
                            {
                                status = true;
                                flags = true;
                            }
                            else
                            {
                                flags = false;
                                txtNumberCardCTS.Text = string.Empty;
                                txtNumberCardCTS.Focus();
                            }
                        }
                        else
                        {
                            typeCard = "AIRPLUS";
                            DialogResult yesNo = MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typeCard +
                                " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + typeCard +
                                " es: (" + numberCardShow + ").", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (yesNo.Equals(DialogResult.Yes))
                            {
                                status = true;
                                flags = true;
                            }
                            else
                            {
                                txtNumberCardCTS.Text = string.Empty;
                                txtNumberCardCTS.Focus();
                                flags = false;
                            }
                        }
                    }
                    else
                    {
                        flags = true;
                    }

                }
                return flags;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                ReturnForMisc = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                txtNumberCard.Focus();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
