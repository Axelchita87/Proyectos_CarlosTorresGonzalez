using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Services;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucTicketEmissionConfirmation : CustomUserControl
    {
        //Declaracion de Variables
        private bool validatebusinessrules = true;

        private static string authCode;
        public static string AuthCode
        {
            get { return authCode; }
            set { authCode = value; }
        }

        // Constructor
        public ucTicketEmissionConfirmation()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            InitialControlFocus = btnReturn;
            LastControlFocus = btnTicketEmission;
        }

        #region =====Eventos=====
        // Evento Load, muestra una plantilla con las reglas de negocios aplicables a la emision de boleto actual
        private void ucTicketEmissionConfirmation_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            btnReturn.Focus();
            validateBusinessRules();
            authCode = string.Empty;
        }

        //Evento click del Boton btnReturn
        private void btnReturn_Click(object sender, EventArgs e)
        {            
            //Regresando al paso 3
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
        }

        private bool UsuarioValidoCargosPorServicio()
        {
            bool Status = ChargesPerService.ValidateTestingUsers(ChargesPerService.OrigenTipoCargo.FlujoAereo);
            return Status;
        } 

        //Evento click del Boton btnTicketEmission
        private void btnTicketEmission_Click(object sender, EventArgs e)
        {          
            bool validAuthCode = true;
            string sabreAnswer = string.Empty;                    
            bool UsuarioValidoParaCargosPorServicio = false;
            // Validamos usuario para generar remark en el caso de las versiones anteriores
            UsuarioValidoParaCargosPorServicio = UsuarioValidoCargosPorServicio();

            if (!UsuarioValidoParaCargosPorServicio)
            {
                for (int i = 0; i < ucServicesFeePayApply.lstDatosTarjeta.Count; i++)
                {
                    if (ucServicesFeePayApply.lstDatosTarjeta[i].MontoCargo != 0)
                    {
                        string sError = string.Empty;
                        ChargesPerService.BuilCommandToSendOld(ucServicesFeePayApply.lstDatosTarjeta[i].PaxNumber, ucServicesFeePayApply.lstDatosTarjeta[i]);
                    }
                }
            }
           
            if (string.IsNullOrEmpty(ucTicketsEmissionInstructions.CodeAuth.Code))
            {
                if (!string.IsNullOrEmpty(ucFormPayment.CommandGetAuthorizationCode))
                {
                    if (!string.IsNullOrEmpty(ucPromo.PromoCode))
                        ucFormPayment.CommandGetAuthorizationCode = string.Concat(ucFormPayment.CommandGetAuthorizationCode, "*", ucPromo.PromoCode, "/*C", ucFormPayment.SecurityCode);
                    else
                        ucFormPayment.CommandGetAuthorizationCode = string.Concat(ucFormPayment.CommandGetAuthorizationCode, "/*C", ucFormPayment.SecurityCode);

                    using (CommandsAPI2 objCommand = new CommandsAPI2())
                    {
                        sabreAnswer = objCommand.SendReceive(ucFormPayment.CommandGetAuthorizationCode, 0, 0, 4000);
                    }
                    
                    ucPromo.PromoCode = string.Empty;

                    if (sabreAnswer.Contains(Resources.TicketEmission.Constants.OK))
                    {
                        string[] sabreArray = sabreAnswer.Replace("\n", "-").Split('-');
                        for (int i = 0; i < sabreArray.Length; i++)
                        {
                            int row = 0; int col = 0;
                            CommandsQik.searchResponse(sabreArray[i], Resources.TicketEmission.Constants.OK, ref row, ref col, 1, 2);
                            if (row != 0 || col != 0)
                            {
                                CommandsQik.CopyResponse(sabreArray[i], ref authCode, 1, 4, 6);
                            }
                        }
                        if (!string.IsNullOrEmpty(authCode))
                        {
                            if (ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)
                            {
                                ucFormPayment.FormPayment = string.Concat(ucFormPayment.FormPayment, Resources.TicketEmission.Constants.COMMANDS_AST_Z,
                                    authCode, Resources.TicketEmission.Constants.SLASH, ucFormPayment.Amount);
                            }
                            else
                                ucFormPayment.FormPayment = string.Concat(ucFormPayment.FormPayment, Resources.TicketEmission.Constants.COMMANDS_AST_Z, authCode);
                        }

                    }
                    else if (sabreAnswer.Contains(Resources.TicketEmission.Constants.INVALID))
                    {
                        MessageBox.Show("TARJETA RECHAZADA \n" + sabreAnswer, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validAuthCode = false;
                    }
                    else if (sabreAnswer.Contains(Resources.TicketEmission.Constants.DECLINED))
                    {
                        MessageBox.Show("TARJETA RECHAZADA \n" + sabreAnswer, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validAuthCode = false;
                    }
                    else if (sabreAnswer.Contains(Resources.TicketEmission.Constants.INCORRECT_CARD))
                    {
                        MessageBox.Show("TARJETA RECHAZADA \n" + sabreAnswer, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validAuthCode = false;
                    }
                    else if (sabreAnswer.Contains(Resources.TicketEmission.Constants.PROCESSING_ERROR))
                    {
                        MessageBox.Show("TARJETA RECHAZADA \n" + sabreAnswer, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validAuthCode = false;
                    }
                    else if (sabreAnswer.Contains(Resources.TicketEmission.Constants.REFERRAL))
                    {
                        MessageBox.Show("TARJETA RECHAZADA \n" + sabreAnswer, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validAuthCode = false;
                    }

                    //Continua con el flujo de boleto, va al paso 8
                    if (!validAuthCode)
                    {
                        SetAuthCodeBL.SetErrorCK(ucFirstValidations.LocatorRecord, ucFormPayment.CardType, ucFormPayment.Amount, ucFormPayment.Bank, sabreAnswer, DateTime.Now, ucFormPayment.CommandGetAuthorizationCode);
                        ucFormPayment.CommandGetAuthorizationCode = string.Empty;
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                    }
                    else if (validatebusinessrules)
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ARMED_COMMANDS);
                    }
                }
                else
                {
                    if (validatebusinessrules)
                    {
                        // Aqui se actualizan los boletos en la tabla de log services fee
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ARMED_COMMANDS);
                    }
                }
            }
            else 
            {
                if (validatebusinessrules)
                {
                    AuthCode = ucTicketsEmissionInstructions.CodeAuth.Code;
                    
                    if (ucTicketsEmissionInstructions.wayPayment == Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)
                    {
                        ucFormPayment.FormPayment = string.Concat(ucFormPayment.FormPayment, Resources.TicketEmission.Constants.COMMANDS_AST_Z,
                            authCode, Resources.TicketEmission.Constants.SLASH, ucFormPayment.Amount);
                    }
                    else
                        ucFormPayment.FormPayment = string.Concat(ucFormPayment.FormPayment, Resources.TicketEmission.Constants.COMMANDS_AST_Z, authCode);
                    
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ARMED_COMMANDS);
                }
                else 
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                }
            }
        }



        //Evento KeyDown para teclas Esc y Enter
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            if (e.KeyData == Keys.Enter)
                btnTicketEmission_Click(sender, e);
        }

        #endregion

        #region =====Metodos=====

        /// <summary>
        /// Valida las reglas de negocio existentes en la emision de boleto actual y las muestra en la mascarilla
        /// </summary>
        private void validateBusinessRules()
        {
            validatebusinessrules = true;
            List<CatCreditCardsCodes> CatCreditCardsCodesList = CatCreditCardsCodesBL.GetCreditCardsCodes(ucFormPayment.creditCardName);
            if (CatCreditCardsCodesList.Count.Equals(0))
                lblCreditCardName.Text = string.Empty;
            else
                lblCreditCardName.Text = CatCreditCardsCodesList[0].CatCreCarCodName;
            if (ucTicketsEmissionInstructions.ticketType.Equals(Resources.TicketEmission.Constants.NORMAL_TICKET))
                lblTicketType.Text = Resources.TicketEmission.Constants.NORMAL;
            else if (ucTicketsEmissionInstructions.ticketType.Equals(Resources.TicketEmission.Constants.PHASE35375))
                lblTicketType.Text = Resources.TicketEmission.Constants.PHASE_35_OR_375;
            else if (ucTicketsEmissionInstructions.ticketType.Equals(Resources.TicketEmission.Constants.PHASEIV))
                lblTicketType.Text = Resources.TicketEmission.Constants.PHASE_IV;

            lblAirLine.Text = ucTicketsEmissionInstructions.AirlineName;
            try
            {
                lblComission.Text = string.Concat(ucTicketsEmissionInstructions.Commission.Substring(3, 2), Resources.TicketEmission.Constants.SPACE, Resources.TicketEmission.Constants.PERCENTAGE);
            }
            catch
            {
                lblComission.Text = string.Concat(ucTicketsEmissionInstructions.Commission.Substring(3, 1), Resources.TicketEmission.Constants.SPACE, Resources.TicketEmission.Constants.PERCENTAGE);

            }

            if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS))
            {
                lblPaymentForm.Text = Resources.TicketEmission.Constants.CREDIT_CARD_SYSTEM;
                lblCreditCardName.Visible = true;

            }
            else if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CREDITCARD))
            {
                lblPaymentForm.Text = Resources.TicketEmission.Constants.CREDIT_CARD_MANUAL;
                lblCreditCardName.Visible = true;
            }
            else if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CASH))
                lblPaymentForm.Text = Resources.TicketEmission.Constants.EFECTIVO;
            else if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT))
                lblPaymentForm.Text = Resources.TicketEmission.Constants.PAGO_MIXTO;
            else if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MISCELANEOUS))
                lblPaymentForm.Text = Resources.TicketEmission.Constants.MISCELANEA;

            lblTourCode.Text = ucTicketsEmissionInstructions.tourCode;
            lblNegotiatedFare.Text = ucTicketsEmissionInstructions.quaNegociated;
            lblCorporateID.Text = ucTicketsEmissionInstructions.corporateID;
            lblAccountCode.Text = ucTicketsEmissionInstructions.accountCode;
            if (ucTicketsEmissionInstructions.printItinerary.Equals(Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_DPB))
                lblItinerary.Text = Resources.TicketEmission.Constants.Yes;
            else
                lblItinerary.Text = Resources.TicketEmission.Constants.No;
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.OSI))
                lblOsiValue.Text = ucTicketsEmissionInstructions.OSI.Remove(0, 1);
            else
                lblOsiValue.Text = string.Empty;
        }

        /// <summary>
        /// envia los valores de los controles de la mascarilla actual para su registro
        /// </summary>
        private void SendParameters()
        {
            string[] sendInfo =
                new[]{
                               lblTicketType.Text,
                               lblAirLine.Text,
                               lblComission.Text,
                               lblPaymentForm.Text,
                               lblTourCode.Text,
                               lblNegotiatedFare.Text,
                               lblCorporateID.Text,
                               lblAccountCode.Text,
                               lblItinerary.Text
                            };
            userControlsPreviousValues.TicketEmissionConfirmation = sendInfo;
        }

        /// <summary>
        /// Establece los valores de los controles de la mascarilla actual con un registro previo
        /// </summary>
        private void ReceiveParameters()
        {
            if (userControlsPreviousValues.Taxes != null)
            {
                lblTicketType.Text = userControlsPreviousValues.Taxes[0];
                lblAirLine.Text = userControlsPreviousValues.Taxes[1];
                lblComission.Text = userControlsPreviousValues.Taxes[2];
                lblPaymentForm.Text = userControlsPreviousValues.Taxes[3];
                lblTourCode.Text = userControlsPreviousValues.Taxes[4];
                lblNegotiatedFare.Text = userControlsPreviousValues.Taxes[5];
                lblCorporateID.Text = userControlsPreviousValues.Taxes[6];
                lblAccountCode.Text = userControlsPreviousValues.Taxes[7];
                lblItinerary.Text = userControlsPreviousValues.Taxes[8];
                userControlsPreviousValues.TicketEmissionConfirmation = null;
            }
        }

        #endregion
    }
}
