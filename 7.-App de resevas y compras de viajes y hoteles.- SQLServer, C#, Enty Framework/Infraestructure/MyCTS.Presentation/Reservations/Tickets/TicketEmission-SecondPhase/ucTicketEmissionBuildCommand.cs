using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Components;
using MyCTS.Presentation.Components;
using System.ComponentModel;
using MyCTS.Services.ValidateDKsAndCreditCards;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation
{
    public partial class ucTicketEmissionBuildCommand : CustomUserControl, IProcessAsync
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar remarks contables de 
        ///              ICAAV, Remarks de INTEGRA y la emision y validación de un boleto
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    Mayo - Junio 09
        /// Modificación: 22/Diciembre/2009 por Angel Trejo
        /// Cambio:      Documentación de los links de boletos emitidos para factura
        ///              y virtually there 
        /// Solicito:    Guillermo Granados
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private static string recordLocator;
        public static string RecordLocator
        {
            get { return recordLocator; }
            set { recordLocator = value; }
        }
        private int row = 0;
        private int col = 0;
        private string sabreCommand;
        private string sabreAnswer;
        private string revisedpayment;
        private static int lenght;
        public static bool commandSent = false;
        private static string newlabel = string.Empty;
        private string sabreConcat = string.Empty;
        private List<string> TktNumber = new List<string>();
        private List<string> PaxName = new List<string>();
        private List<string> LinkVT = new List<string>();
        private List<string> listNewTickets = new List<string>();
        public static bool emiting = false;
        //******
        private string UC = string.Empty;
        //*******
        public ucTicketEmissionBuildCommand()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);

        }

        //user control load event
        private void ucTicketEmissionBuildCommand_Load(object sender, EventArgs e)
        {
            if (!ucEndReservation.isFlowHotel)
                Segment();

            recordLocator = string.Empty;
            if (!ucMenuReservations.qualityControls)
            {
                if (!commandSent)
                {
                    string dk = string.Empty;
                    dk = ucFirstValidations.DK;
                    dk = dk.Substring(3, 3);
                    if (dk.Equals(Resources.TicketEmission.ValitationLabels.NUMBER_990))
                    {
                        if (ucBillingAdressEmission.isRemarks)
                        {
                            if (ucBillingAdressEmission.SearchRemarks)
                            {
                                ucBillingAdressEmission.BucleFindEndScroll();
                                ucBillingAdressEmission.Remarks();
                                 if (!ucBillingAdressEmission.SendCommandsBuild())
                                 {
                                    MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                                    return;  
                                 }
                                ucBillingAdressEmission.commandsBuild();
                                ucBillingAdressEmission.sabreConcat = string.Empty;
                                ucBillingAdressEmission.isRemarks = false;
                            }
                        }
                        else
                        {
                            ucBillingAdressEmission.commandsBuild();
                            ucBillingAdressEmission.sabreConcat = string.Empty;
                        }
                    }
                    else
                    {
                        try
                        {
                            ExistAndLoadLocationInformation();
                        }
                        catch
                        {
                            ExistLoadLocationInfoBackup();
                        }

                        if (!string.IsNullOrEmpty(ucQualitiesByPax.extendDescription))
                        {
                            using (CommandsAPI2 objCommand = new CommandsAPI2())
                            {
                                objCommand.SendReceive(ucQualitiesByPax.extendDescription);
                            }
                        }
                    }

                    if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(1) ||
                        activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                    {
                        SendPreviousStepsValues();
                    }
                    if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(3) ||
                        activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                    {
                        SendClientsRemarks();


                        if (ValidSendIntegraRemarks())
                        {
                            ClearValues();
                            ucMenuReservations.qualityControls = false;
                        }
                        else
                        {
                            MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            return;
                        }
                    }
                }
                AddOSI();
                TicketEmissionBuildCommand();
                SabreCommandSend();
                APIResponse();
            }
            else
            {
                string dk = string.Empty;
                if (!ucEndReservation.isFlowHotel)
                {
                    dk = ucFirstValidations.DK;
                    dk = dk.Substring(3, 3);
                }
                else
                {
                    dk = ucEndReservation.dK;
                    dk = dk.Substring(3, 3);
                }
                if (dk.Equals(Resources.TicketEmission.ValitationLabels.NUMBER_990))
                {
                    if (!ucEndReservation.isFlowHotel)
                    {
                        if (ucBillingAdressEmission.isRemarks)
                        {
                            if (ucBillingAdressEmission.SearchRemarks)
                            {
                                ucBillingAdressEmission.BucleFindEndScroll();
                                ucBillingAdressEmission.Remarks();
                                ucBillingAdressEmission.commandsBuild();
                                ucBillingAdressEmission.sabreConcat = string.Empty;
                            }
                        }
                        else
                        {
                            ucBillingAdressEmission.commandsBuild();
                            ucBillingAdressEmission.sabreConcat = string.Empty;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(ucQualitiesByPax.extendDescription))
                    {
                        using (CommandsAPI2 objCommand = new CommandsAPI2())
                        {
                            objCommand.SendReceive(ucQualitiesByPax.extendDescription);
                        }
                    }
                }

                if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(1) ||
                        activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                {
                    SendPreviousStepsValues();
                }
                if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(3) ||
                    activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                {
                    if (!ucEndReservation.isFlowHotel)
                    {
                        SendClientsRemarks();

                        if (ValidSendIntegraRemarks())
                        {
                            ClearValues();
                            ucMenuReservations.qualityControls = false;
                        }
                        else
                        {
                            MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            return;
                        }

                    }
                }

                ucMenuReservations.qualityControls = false;
                if (!string.IsNullOrEmpty(ucQREX.CommandQREX))
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(ucQREX.CommandQREX);
                    }
                    ucQREX.CommandQREX = string.Empty;
                    ucQREX.Qrex = false;
                }
            }
            ClearValues();
        }

        /// <summary>
        /// Carga informacion a la mascarilla por Location
        /// </summary>
        private Boolean ExistAndLoadLocationInformation()
        {
            string location = ucFirstValidations.DK;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation = null;

            try
            {
                star1InfoByLocation = wsServ.GetProfileInfo(location);
            }
            catch { }

            if (star1InfoByLocation != null)
            {

                if (!string.IsNullOrEmpty(star1InfoByLocation.CustomerName))
                {
                    string customer = star1InfoByLocation.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    ucBillingAdressEmission.socialReason = customer;
                }

                if (!string.IsNullOrEmpty(star1InfoByLocation.Address1))
                    ucBillingAdressEmission.street = star1InfoByLocation.Address1.Replace(',', ' ');

                if (!string.IsNullOrEmpty(star1InfoByLocation.Address2))
                {
                    star1InfoByLocation.Address2 = star1InfoByLocation.Address2.Replace("#", "");
                    star1InfoByLocation.Address2 = star1InfoByLocation.Address2.TrimStart().Replace(',', ' '); ;
                    ucBillingAdressEmission.numberExt = star1InfoByLocation.Address2;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.Address3))
                {
                    star1InfoByLocation.Address3 = star1InfoByLocation.Address3.Replace("#", "");
                    star1InfoByLocation.Address3 = star1InfoByLocation.Address3.TrimStart().Replace(',', ' ');
                    ucBillingAdressEmission.numberInt = star1InfoByLocation.Address3;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.Address4))
                    ucBillingAdressEmission.colony = star1InfoByLocation.Address4;
                if (!string.IsNullOrEmpty(star1InfoByLocation.Municipality))
                {
                    ucBillingAdressEmission.delegation = star1InfoByLocation.Municipality.Replace(',', ' ');
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.PostalCode))
                {
                    ucBillingAdressEmission.cp = star1InfoByLocation.PostalCode;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.City))
                {
                    ucBillingAdressEmission.city = star1InfoByLocation.City.Replace(',', ' ');
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.State))
                {
                    ucBillingAdressEmission.state = star1InfoByLocation.State.Replace(',', ' ');
                }

                if (!string.IsNullOrEmpty(star1InfoByLocation.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(star1InfoByLocation.RFC);
                    if (IsRFC)
                    {
                        if (star1InfoByLocation.RFC.Length.Equals(13))
                        {
                            ucBillingAdressEmission.rfc1 = star1InfoByLocation.RFC.Substring(0, 4);
                            ucBillingAdressEmission.rfc2 = star1InfoByLocation.RFC.Substring(4, 6);
                            ucBillingAdressEmission.rfc3 = star1InfoByLocation.RFC.Substring(10, 3);
                        }


                        else if (star1InfoByLocation.RFC.Length.Equals(12))
                        {
                            ucBillingAdressEmission.rfc1 = star1InfoByLocation.RFC.Substring(0, 3);
                            ucBillingAdressEmission.rfc2 = star1InfoByLocation.RFC.Substring(3, 6);
                            ucBillingAdressEmission.rfc3 = star1InfoByLocation.RFC.Substring(9, 3);
                        }
                    }
                }
                ucBillingAdressEmission.country = string.Empty;

                return true;
            }

            return true;
        }

        /// <summary>
        /// Carga informacion a la mascarilla por Location si falla el metodo principal
        /// </summary>
        private Boolean ExistLoadLocationInfoBackup()
        {
            string location = ucFirstValidations.DK;
            MyCTS.Entities.Cat1stStarInfoByLocation starFirstInfoByLocation = Cat1stStarInfoByLocationBL.Get1stStarInfoByLocation(location);
            if (starFirstInfoByLocation != null)
            {
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.CustomerName))
                {
                    string customer = starFirstInfoByLocation.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    customer.Replace(',', ' ');
                    ucBillingAdressEmission.socialReason = customer;
                }

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address1))
                    ucBillingAdressEmission.street = starFirstInfoByLocation.Address1.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address2))
                {
                    starFirstInfoByLocation.Address2 = starFirstInfoByLocation.Address2.Replace("#", "");
                    starFirstInfoByLocation.Address2 = starFirstInfoByLocation.Address2.TrimStart();
                    ucBillingAdressEmission.numberExt = starFirstInfoByLocation.Address2.Replace(',', ' ');
                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address3))
                {
                    starFirstInfoByLocation.Address3 = starFirstInfoByLocation.Address3.Replace("#", "");
                    starFirstInfoByLocation.Address3 = starFirstInfoByLocation.Address3.TrimStart();
                    ucBillingAdressEmission.numberInt = starFirstInfoByLocation.Address3;
                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address4))
                    ucBillingAdressEmission.colony = starFirstInfoByLocation.Address4.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Municipality))
                    ucBillingAdressEmission.delegation = starFirstInfoByLocation.Municipality.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.PostalCode))
                    ucBillingAdressEmission.cp = starFirstInfoByLocation.PostalCode;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.City))
                    ucBillingAdressEmission.city = starFirstInfoByLocation.City.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.State))
                    ucBillingAdressEmission.state = starFirstInfoByLocation.State.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(starFirstInfoByLocation.RFC);
                    if (IsRFC)
                    {
                        if (starFirstInfoByLocation.RFC.Length.Equals(13))
                        {
                            ucBillingAdressEmission.rfc1 = starFirstInfoByLocation.RFC.Substring(0, 4);
                            ucBillingAdressEmission.rfc2 = starFirstInfoByLocation.RFC.Substring(4, 6);
                            ucBillingAdressEmission.rfc3 = starFirstInfoByLocation.RFC.Substring(10, 3);
                        }
                        else if (starFirstInfoByLocation.RFC.Length.Equals(12))
                        {
                            ucBillingAdressEmission.rfc1 = starFirstInfoByLocation.RFC.Substring(0, 3);
                            ucBillingAdressEmission.rfc2 = starFirstInfoByLocation.RFC.Substring(3, 6);
                            ucBillingAdressEmission.rfc3 = starFirstInfoByLocation.RFC.Substring(9, 3);
                        }
                    }
                }
                return true;
            }

            return true;
        }

        void IProcessAsync.InitProcess()
        {
            recordLocator = string.Empty;
            if (!ucMenuReservations.qualityControls)
            {

                if (!commandSent)
                {
                    string dk = string.Empty;
                    dk = ucFirstValidations.DK;
                    dk = dk.Substring(3, 3);
                    if (dk.Equals(Resources.TicketEmission.ValitationLabels.NUMBER_990))
                    {
                        if (!string.IsNullOrEmpty(ucBillingAdressEmission.sabreConcat))
                            ucBillingAdressEmission.Remarks();
                        ucBillingAdressEmission.commandsBuild();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ucQualitiesByPax.extendDescription))
                        {
                            using (CommandsAPI2 objCommand = new CommandsAPI2())
                            {
                                objCommand.SendReceive(ucQualitiesByPax.extendDescription);
                            }
                        }
                    }

                    if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(1) ||
                        activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                    {
                        SendPreviousStepsValues();
                    }
                    if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(3) ||
                        activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                    {
                        SendClientsRemarks();
                        if (ValidSendIntegraRemarks())
                        {
                            ClearValues();
                            ucMenuReservations.qualityControls = false;
                        }
                        else
                        {
                            MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            return;
                        }

                    }
                }
                AddOSI();
                TicketEmissionBuildCommand();
                SabreCommandSend();
                APIResponse();
            }
            else
            {
                string dk = string.Empty;
                dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                if (dk.Equals(Resources.TicketEmission.ValitationLabels.NUMBER_990))
                {
                    if (!string.IsNullOrEmpty(ucBillingAdressEmission.sabreConcat))
                        ucBillingAdressEmission.Remarks();
                    ucBillingAdressEmission.commandsBuild();
                }
                else
                {
                    if (!string.IsNullOrEmpty(ucQualitiesByPax.extendDescription))
                    {
                        using (CommandsAPI2 objCommand = new CommandsAPI2())
                        {
                            objCommand.SendReceive(ucQualitiesByPax.extendDescription);
                        }
                    }
                }

                if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(1) ||
                        activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                {
                    SendPreviousStepsValues();
                }
                if (activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(3) ||
                    activeStepsCorporativeQC.CorporativeQualityControls[0].Status.Equals(2))
                {

                    SendClientsRemarks();
                    if (ValidSendIntegraRemarks())
                    {
                        ClearValues();
                        ucMenuReservations.qualityControls = false;
                    }
                    else
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        return;

                    }

                }
            }
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("ticketEmmisionInstruction"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            else if (UC.Equals("sendTicketInvoice"))
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_SEND_TICKET_INVOICE, new string[] { ucFirstValidations.LocatorRecord });
            else if (UC.Equals("welcome"))
            {
                ApplyServicesFee();
            }
        }

        private void ApplyServicesFee()
        {
            ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.FlujoAereo;
            ucServicesFeePayApply pago = new ucServicesFeePayApply();
            pago.PayServiceFee();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCSERVICESFEEPAYAPPLY);
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Arma el comando de Emision de boleto
        /// </summary>
        private void TicketEmissionBuildCommand()
        {
            sabreCommand = string.Empty;
            sabreCommand = Resources.TicketEmission.Constants.COMMANDS_W;

            string ticketType = ucTicketsEmissionInstructions.ticketType;
            if (ticketType.Equals(Resources.TicketEmission.Constants.PHASE35375))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucPhase35375Tickets.Phase35375);
            }
            else if (ticketType.Equals(Resources.TicketEmission.Constants.PHASEIV))
            {
                sabreCommand = string.Concat(sabreCommand,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_T,
                    ucTicketsEmissionInstructions.phaseIVNumber);
            }
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.byNames))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTicketsEmissionInstructions.byNames);
            }
            if (!string.IsNullOrEmpty(ucArmedCommands.NegotiatedRate))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucArmedCommands.NegotiatedRate);

                if (ucTicketsEmissionInstructions.avoidMoreLowFare)
                {
                    sabreCommand = string.Concat(sabreCommand,
                        Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_XO);
                }
            }
            if (!string.IsNullOrEmpty(ucArmedCommands.Airline))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucArmedCommands.Airline);
            }
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.Commission))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTicketsEmissionInstructions.Commission);
            }
            if (!string.IsNullOrEmpty(ucFormPayment.FormPayment))
            {
                if (!ucTicketsEmissionInstructions.WithCharge)
                    sabreCommand = string.Concat(sabreCommand,
                        ucFormPayment.FormPayment);
                else
                    revisedpayment = ucFormPayment.FormPayment;

                ucFormPayment.FormPayment = string.Empty;
            }
            else
            {
                if (ucTicketsEmissionInstructions.WithCharge)
                    revisedpayment = string.Concat("¥FA/CCASH");
                else if (ucTicketsEmissionInstructions.WithoutCharge)
                    revisedpayment = string.Empty;
                else
                {
                    sabreCommand = string.Concat(sabreCommand,
                        Resources.TicketEmission.Constants.COMMANDS_CROSLORAINE_F,
                        Resources.TicketEmission.Constants.CASH);
                }
            }
            if (!string.IsNullOrEmpty(ucTourCode.TourCode))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTourCode.TourCode);
            }

            if (!string.IsNullOrEmpty(ucTourCode.Endorsement))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTourCode.Endorsement);
            }

            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTicketsEmissionInstructions.bySegments);
            }
            if (ucTicketsEmissionInstructions.xrCommand.Equals(true))
            {
                sabreCommand = string.Concat(sabreCommand,
                    "¥XR");
            }

            if (!string.IsNullOrEmpty(ucTaxes.Taxes17))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTaxes.Taxes17);
                ucTaxes.Taxes17 = string.Empty;
            }

            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.quarrelType))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTicketsEmissionInstructions.quarrelType);
            }

            if (!string.IsNullOrEmpty(ucRevisedCharge.revised) &&
                (ucTicketsEmissionInstructions.WithCharge ||
                ucTicketsEmissionInstructions.WithoutCharge))
            {
                sabreCommand = string.Concat(sabreCommand, revisedpayment,
                    ucRevisedCharge.revised);
            }

            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.printItinerary))
            {
                sabreCommand = string.Concat(sabreCommand,
                    ucTicketsEmissionInstructions.printItinerary);
            }
        }

        /// <summary>
        /// Envia el comando de emision de boleto a mySabre
        /// </summary>
        private void SabreCommandSend()
        {

            string send = string.Empty;
            sabreAnswer = string.Empty;
            string timeEmission = ParameterBL.GetParameterValue(Resources.TicketEmission.Constants.TKT_EMISSION_TIME).Values;
            send = sabreCommand;
            //MessageBox.Show(send);

            string securityToken1 = string.Empty;
            string pnr = string.Empty;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                pnr = objCommand.SendReceive("*A").Trim().Split('\n')[0];
            }

            using (CommandsAPI2 objCommand = new CommandsAPI2())
            {
                if (!string.IsNullOrEmpty(timeEmission))
                    sabreAnswer = objCommand.SendReceiveEmission(send, 1, 1, Convert.ToInt32(timeEmission));
                else
                    sabreAnswer = objCommand.SendReceiveEmission(send, 1, 1, 6000);
            }


            Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

            if (regex.IsMatch(pnr))
            {
                using (WSSessionSabre obj = new WSSessionSabre())
                {
                    obj.OpenConnection();

                    if (obj.IsConnected)
                    {
                        InsertSCDCBoletoBL insertboleto = new InsertSCDCBoletoBL();
                        OTATravelItineraryFlights getboleto = new OTATravelItineraryFlights();
                        foreach (SCDCBoleto boleto in getboleto.getBoleto(obj.ConversationId, obj.IPcc, securityToken1, pnr, Login.PCC))
                        {
                            insertboleto.InsertSCDCBoleto(boleto);
                        }
                    }
                }
            }

            commandSent = true;
        }

        /// <summary>
        /// Agrega un OSI (Other Special Information) de aereolinea
        /// </summary>
        private void AddOSI()
        {
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.OSI))
            {
                string send = ucTicketsEmissionInstructions.OSI;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Valida la emision de boleto correcta, envia record localizador a queue
        /// y redespliega el record
        /// </summary>
        private void APIResponse()
        {
            string result = string.Empty;

            string send = string.Empty;
            //sabreAnswer = "OK   15941.71\nUS INS INSPECTION FEE INCLUDED\nETR MESSAGE PROCESSED\nOK 6.6\nCTP EDITS IN PROGRESS....PLEASE WAIT....\nOK 1543 IRUDES TTY REQ PEND\nINVOICED\n- NUMBER 0437739\nREQUEST PRINTING - 1 INVOICE ;\n";
            //sabreAnswer = "OK    5900.39\nETR MESSAGE PROCESSED\nOK 6.6\nCTP EDITS IN PROGRESS....PLEASE WAIT....\nOK 1127 EAFGGX TTY REQ PEND\nINVOICED                   - NUMBER 0440877\nREQUEST PRINTING - 1 INVOICE";
            ERR_TicketsEmission.err_ticketsEmission(sabreAnswer);
            //ERR_TicketsEmission.StatusSendCommand = true;
            if (ERR_TicketsEmission.Status == false)
            {
                ERR_TicketsEmission.ok_ticketsEmission(sabreAnswer);
                if (ERR_TicketsEmission.StatusOk == true)
                {
                    int row = 0;
                    int col = 0;

                    if (sabreAnswer.Contains(Resources.TicketEmission.ValitationLabels.ETR_MESSAGE_PROCESSED) || sabreAnswer.Contains(Resources.TicketEmission.ValitationLabels.ETR_EXCHANGE_PROCESSED))
                        CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_ISSUE);

                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.INVOICED, ref row, ref col);
                    if (row != 0 || col != 0)
                    {

                        recordLocator = string.Empty;
                        int rowMessage = row - 2;
                        CommandsQik.CopyResponse(sabreAnswer, ref recordLocator, rowMessage + 1, 9, 6);

                    }

                    send = string.Empty;
                    Common.BeginManualCommandsTransactions();
                    try
                    {
                        if (!string.IsNullOrEmpty(recordLocator))
                        {
                            AddRecordsContainerBL.AddRecordsContainer(recordLocator, Login.Agent, true);
                        }
                        else
                        {
                            recordLocator = ucFirstValidations.DK;
                            AddRecordsContainerBL.AddRecordsContainer(recordLocator, Login.Agent, true);
                        }

                        //LogProductivity.PNR = recordLocator;
                        send = string.Concat(Resources.TicketEmission.Constants.AST,
                            recordLocator);

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }


                        BuildFareRemark();
                        QueueAgent();

                        send = string.Empty;
                        MyCTSAPI.SendReservationLog(Login.Firm, Login.PCC, recordLocator, 1);
                        send = string.Concat(Resources.TicketEmission.Constants.AST,
                            recordLocator);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }
                        SendValidationTicketCommand();
                        EMRSend();
                    }
                    catch { }

                    //Common.EndManualCommandsTransactions();
                    ExecEndCommandTransaction();
                    //System.Threading.Thread.Sleep(1000);
                    ApplyServicesFee();
                    ClearValues();
                }
                else
                {
                    MessageBox.Show(ERR_TicketsEmission.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SetCSCLog();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }

            }
            else if (ERR_TicketsEmission.StatusSendCommand == true)
            {
                BuildFareRemark();
                send = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_PAC;
                sabreAnswer = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
                emiting = true;

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_SEND_TICKET_INVOICE, new string[] { ucFirstValidations.LocatorRecord });
            }
            else if (ERR_TicketsEmission.statusShowUserControl == true)
            {
                MessageBox.Show(ERR_TicketsEmission.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetCSCLog();
                ApplyServicesFee();
            }
            else
            {
                MessageBox.Show(ERR_TicketsEmission.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetCSCLog();
                ClearValues();
            }
        }

        private delegate void EndCommandTransactionAsyn();
        private void ExecEndCommandTransaction()
        {
            EndCommandTransactionAsyn endcommandAsync = new EndCommandTransactionAsyn(ExecEndCommandTransactionAsync);
            endcommandAsync.BeginInvoke(null, null);
        }

        private void ExecEndCommandTransactionAsync()
        {
            Common.EndManualCommandsTransactions();
        }

        /// <summary>
        /// Valida la respuesta de mySabre cuando aparece la respuesta *PAC
        /// </summary>
        private void APIResponseDIN()
        {
            string result = string.Empty;

            string send = string.Empty;
            ERR_TicketsEmission.err_ticketsEmission(sabreAnswer);
            if (ERR_TicketsEmission.Status == false)
            {
                ERR_TicketsEmission.ok_ticketsEmission(sabreAnswer);
                if (ERR_TicketsEmission.StatusOk == true)
                {

                    int row = 0;
                    int col = 0;

                    if (sabreAnswer.Contains(Resources.TicketEmission.ValitationLabels.ETR_MESSAGE_PROCESSED) || sabreAnswer.Contains(Resources.TicketEmission.ValitationLabels.ETR_EXCHANGE_PROCESSED))
                        CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_ISSUE);

                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.INVOICED, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        int rowMessage = row - 2;
                        recordLocator = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswer, ref recordLocator, rowMessage + 1, 9, 6);
                    }
                    Common.BeginManualCommandsTransactions();

                    try
                    {
                        if (!string.IsNullOrEmpty(recordLocator))
                        {
                            AddRecordsContainerBL.AddRecordsContainer(recordLocator, Login.Agent, true);
                        }
                        else
                        {
                            recordLocator = ucFirstValidations.DK;
                            AddRecordsContainerBL.AddRecordsContainer(recordLocator, Login.Agent, true);
                        }
                        send = string.Empty;
                        send = string.Concat(Resources.TicketEmission.Constants.AST,
                            recordLocator);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }
                        BuildFareRemark();
                        QueueAgent();

                        send = string.Empty;
                        MyCTSAPI.SendReservationLog(Login.Firm, Login.PCC, recordLocator, 1);
                        send = string.Concat(Resources.TicketEmission.Constants.AST,
                            recordLocator);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }
                        SendValidationTicketCommand();

                    }
                    catch { }
                    ExecEndCommandTransaction();
                    ClearValues();
                }
            }
            else if (ERR_TicketsEmission.statusShowUserControl == true)
            {
                MessageBox.Show(ERR_TicketsEmission.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetCSCLog();
                ApplyServicesFee();
            }
            else
            {
                MessageBox.Show(ERR_TicketsEmission.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetCSCLog();
                ClearValues();
            }
        }


        /// <summary>
        /// Envia el record localizador a la Queue del agente
        /// </summary>
        private void QueueAgent()
        {
            string send = string.Empty;
            string queueAgent = string.Empty;
            string queueClient = string.Empty;
            string queueConsolid = string.Empty;
            string queue = string.Empty;
            string personalQueue = string.Empty;
            string remarkConsolid = string.Empty;
            bool haveQueue = false;

            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Queue))
            {
                queue = item.Queue;

                queueAgent = string.Format(Resources.Constants.COMMANDS_QP_SLA_AGENT_SLA_11,
                    queue);

                if (!string.IsNullOrEmpty(queue))
                    haveQueue = true;
                else
                    haveQueue = false;

            }

            List<DKTemp> listDKTemp = DKTempBL.GetDKTemp(ucFirstValidations.DK, true);
            if (!listDKTemp.Count.Equals(0))
            {
                if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.StartsWith(Resources.TicketEmission.Constants.CONSOLID))
                {
                    if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CASH) ||
                        ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS))
                    {
                        queueClient = listDKTemp[0].Queue;
                        personalQueue = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_CLIENT_SLA_11,
                            queueClient);

                        remarkConsolid = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkRobot;

                        if (!string.IsNullOrEmpty(remarkConsolid))
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                objCommand.SendReceive(remarkConsolid);
                            }
                        }
                    }
                    else if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CREDITCARD))
                    {
                        queueClient = listDKTemp[0].Queue2;
                        personalQueue = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_CLIENT_SLA_11,
                            queueClient);
                    }
                    else
                    {
                        personalQueue = string.Empty;
                    }

                }
                else
                {
                    queueClient = listDKTemp[0].Queue;
                    personalQueue = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_CLIENT_SLA_11,
                        queueClient);
                }
            }


            if (haveQueue)
            {
                if (!string.IsNullOrEmpty(queueAgent) && !string.IsNullOrEmpty(queueClient))
                {
                    send = string.Empty;
                    send = string.Concat(queueAgent,
                        personalQueue);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                    }
                }
                else if (!string.IsNullOrEmpty(queueAgent) && string.IsNullOrEmpty(queueClient))
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(queueAgent);
                    }
                }


            }
        }


        /// <summary>
        /// Limpia lista de datos previos y termina el flujo de emision de boleto
        /// </summary>
        private void ClearValues()
        {
            userControlsPreviousValues.TicketsEmissionInstructionsParameters = null;
            GC.Collect();
            //UC = "welcome";// 
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        /// <summary>
        /// Envia de comandos de mascarillas previas del flujo de emision de
        /// boleto
        /// </summary>
        private void SendPreviousStepsValues()
        {
            string dk = string.Empty;
            string send = string.Empty;

            CommandsAPI2.send_MessageToEmulator("AGREGANDO INFORMACIÓN AL RECORD... ESPERE POR FAVOR");

            if (!string.IsNullOrEmpty(ucAllQualityControls.TicketsJustifications))
            {
                send = string.Concat(send,
                    ucAllQualityControls.TicketsJustifications,
                    "Σ");
            }

            //foreach (string value in ucAllQualityControls.chargePerService)
            //{
            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        send = string.Concat(send,
            //        value,
            //        "Σ");
            //    }
            //}

            foreach (string value in ucAllQualityControls.workerNumberArray)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    send = string.Concat(send,
                    value,
                    "Σ");
                }
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                send = string.Concat(send,
                    ucAllQualityControls.BusinessUnit,
                    "Σ");

            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                send = string.Concat(send,
                    ucAllQualityControls.Origin,
                    "Σ");

            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCC))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCC,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCD))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCD,
                    "Σ");


            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCE))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCE,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCF))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCF,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCG))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCG,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCH))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCH,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(send))
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    send = string.Empty;
                }
            }





            ucTicketsJustifications.TicketsJustifications = string.Empty;
            ucChargeService.ChargePerService = string.Empty;
            ucCostCenter.CostCenterPrevious = string.Empty;
            ucCostCenter.CostCenter = string.Empty;
            ucBillingAdress.socialReason = string.Empty;
            ucBillingAdress.street = string.Empty;
            ucBillingAdress.numberExt = string.Empty;
            ucBillingAdress.numberInt = string.Empty;
            ucBillingAdress.delegation = string.Empty;
            ucBillingAdress.city = string.Empty;
            ucBillingAdress.colony = string.Empty;
            ucBillingAdress.state = string.Empty;
            ucBillingAdress.cp = string.Empty;
            ucBillingAdress.rfc1 = string.Empty;
            ucBillingAdress.rfc2 = string.Empty;
            ucBillingAdress.rfc3 = string.Empty;
            ucBillingAdress.description1 = string.Empty;
            ucBillingAdress.description2 = string.Empty;
            ucBusinessUnit.BusinessUnit = string.Empty;
            ucBusinessUnit.Origin = string.Empty;
            ucAllQualityControls.icaavRemarkCC = string.Empty;
            ucAllQualityControls.icaavRemarkCD = string.Empty;
            ucAllQualityControls.icaavRemarkCE = string.Empty;
            ucAllQualityControls.icaavRemarkCF = string.Empty;
            ucAllQualityControls.icaavRemarkCG = string.Empty;
            ucAllQualityControls.icaavRemarkCH = string.Empty;
        }


        public static bool IsVolaris { get; set; }
        public static bool IsInterJet { get; set; }
        public static List<string> RemarkVolaris { get; set; }
        public static List<string> RemarkInterJet { get; set; }

        public static void InitInterJetRemarks()
        {
            if (RemarkInterJet == null)
            {
                RemarkInterJet = new List<string>();
            }
        }

        public static void InitVolarisRemarks()
        {
            if (RemarkVolaris == null)
            {
                RemarkVolaris = new List<string>();
            }
        }

        /// <summary>
        ///Bool Anexa de Remarks INTEGRA al boleto
        /// </summary>
        private static bool ValidSendIntegraRemarks()
        {
            InitInterJetRemarks();
            InitVolarisRemarks();
            int row = 0; int col = 0;
            string sendIntegra = string.Empty;
            string remarksCommand = Resources.TicketEmission.Constants.COMMANDS_5_DOT;
            string sendRemarks = string.Empty;
            string remarkTP = string.Empty;
            string sabreAnswer = string.Empty;
            string pax = string.Empty;
            String Warning = string.Empty;
            string c80 = string.Empty;
            string c23 = string.Empty;
            string time = string.Empty;
            bool status = true;

            if (!ucEndReservation.isFlowHotel)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {


                    sabreAnswer = objCommand.SendReceive(Resources.TicketEmission.Constants.COMMAND_DC_USD_MXN);

                }
                CommandsQik.searchResponse(sabreAnswer, "RATE BSR", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(sabreAnswer, ref remarkTP, 1, 18, 6);
                }

                using (CommandsAPI objCommand = new CommandsAPI())
                {

                    sabreAnswer = objCommand.SendReceive("T*MEX");

                }

                CommandsQik.CopyResponse(sabreAnswer, ref time, 1, 3, 10);
            }

            if (!IsInterJet && !VolarisSession.IsVolarisProcess)
            {
                   ucBillingAdressEmission.Remarks();
                   ucBillingAdressEmission.commandsBuild();
            }
            // 

            //bucle remarks
            foreach (string value in ucAllQualityControls.remarksIntegra)
            {
                lenght = 0;
                sendRemarks = string.Empty;
                sendIntegra = string.Empty;
                sendIntegra = remarksCommand;
                string[] splitRemarks = value.Split(new Char[] { '+' });
                for (int i = 0; i <= splitRemarks.LongLength - 1; i++)
                {

                    if (!string.IsNullOrEmpty(splitRemarks[i]))
                    {
                        lenght = sendIntegra.Length + splitRemarks[i].Length;
                        if (lenght < 72)
                        {
                            sendIntegra = string.Concat(sendIntegra,
                                splitRemarks[i]);
                        }
                        else
                        {
                            sendRemarks = string.Concat(sendRemarks,
                                sendIntegra);

                            sendIntegra = string.Empty;
                            sendIntegra = string.Concat("Σ",
                                remarksCommand,
                                splitRemarks[i]);
                            // sendIntegra = string.Empty;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(sendIntegra))
                {

                    sendRemarks = string.Concat(sendRemarks,
                                                sendIntegra);
                    RemarkVolaris.Add(sendRemarks);
                    RemarkInterJet.Add(sendRemarks);

                }

                c80 = string.Empty;
                pax = string.Empty;
                pax = string.Concat(sendRemarks.Substring(1, 13));
                string[] pax1 = pax.Split(new char[] { '-' });
                pax = pax1[1].Substring(0, 2);
                pax = string.Concat("-", pax, "*");

                if (!string.IsNullOrEmpty(sendRemarks))
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        //TODO:InterJet Migration verificar que se ejectue cuando no sea de prueba.
                        if (!IsVolaris && !IsInterJet)
                        {
                            Warning = objCommand.SendReceiveEmission(sendRemarks);

                            CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES_AST, ref row, ref col, 2, 3, 1, 64);
                            string[] sabreAnswerWar = Warning.Split('\n');

                            if (sabreAnswerWar[0] == Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES_AST)
                            {
                                return false;
                            }

                            CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES, ref row, ref col, 2, 3, 1, 64);
                            string[] sabreAnswerWar1 = Warning.Split('\n');

                            if (sabreAnswerWar1[0] == Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES)
                            {
                                return false;
                            }

                            sendRemarks = string.Empty;
                        }

                    }

                }

                Parameter activeLabelC80 = ParameterBL.GetParameterValue("EtiquetaC80");
                if (Convert.ToBoolean(activeLabelC80.Values))
                {

                    if (!string.IsNullOrEmpty(newlabel))
                    {
                        c80 = newlabel.Replace("*", pax);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            sendRemarks = objCommand.SendReceiveEmission(c80);
                        }
                        newlabel = string.Empty;
                    }
                }

                if (!ucAvailability.IsInterJetProcess || !VolarisSession.IsVolarisProcess)
                {
                    if (!string.IsNullOrEmpty(ucChargeService.C23))
                    {
                        c23 = ucChargeService.C23.Replace('+', ' ').Trim();
                        c23 = string.Concat("5.", c23);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            sendRemarks = objCommand.SendReceiveEmission(c23);
                        }
                        ucChargeService.ChargePerService = string.Empty;
                        ucChargeService.C23 = string.Empty;
                        ucQREX.Qrex = false;
                    }
                }

                if (!string.IsNullOrEmpty(ucQREX.C80))
                {

                    c80 = ucQREX.C80.Replace("*", pax);

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        sendRemarks = objCommand.SendReceiveEmission(c80);
                    }
                    ucQREX.C80 = string.Empty;
                }

            }

            if (!ucAllQualityControls.QC28Value.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                string send = string.Empty;
                if (!string.IsNullOrEmpty(ucFormPayment.C28))
                {
                    send = string.Concat(remarksCommand,
                        "</C28*",
                        ucFormPayment.C28,
                        "/>");
                }
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    if (!IsVolaris && !IsInterJet)
                    {
                        Warning = objCommand.SendReceiveEmission(send);

                        CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES_AST, ref row, ref col, 2, 3, 1, 64);
                        string[] sabreAnswerWar1 = Warning.Split('\n');

                        if (sabreAnswerWar1[0] == Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES_AST)
                        {
                            return false;
                        }

                        CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES, ref row, ref col, 2, 3, 1, 64);
                        string[] sabreAnswerWar2 = Warning.Split('\n');

                        if (sabreAnswerWar2[0] == Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES)
                        {
                            return false;
                        }

                        sendIntegra = string.Empty;
                    }
                }

                if (VolarisSession.IsVolarisProcess)
                {
                    RemarkVolaris.Add(send);

                }

                if (IsInterJet)
                {
                    RemarkInterJet.Add(send);
                }

                ucFormPayment.C28 = string.Empty;
            }


            string LastRemark = string.Empty;

            if (!ucEndReservation.isFlowHotel)
            {
                LastRemark = string.Concat(LastRemark, "5.</TK ISSUE MYCTS/>Σ5H-.</TK ISSUE MYCTS/>Σ5H-</C00*", remarkTP, "* ", time, "/>");
                LastRemark = string.Concat(LastRemark, "Σ5.</C00*", remarkTP, "* ", time, "/>");
                if (VolarisSession.IsVolarisProcess)
                {
                    RemarkVolaris.Add(LastRemark);
                    RemarkInterJet.Add(LastRemark);
                }
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    if (!VolarisSession.IsVolarisProcess && !IsInterJet)
                    {

                        Warning = objCommand.SendReceiveEmission(LastRemark);

                        CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES_AST, ref row, ref col, 2, 3, 1, 64);
                        string[] sabreAnswerWar1 = Warning.Split('\n');

                        if (sabreAnswerWar1[0] == Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES_AST)
                        {
                            return false;
                        }
                        CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES, ref row, ref col, 2, 3, 1, 64);
                        string[] sabreAnswerWar2 = Warning.Split('\n');

                        if (sabreAnswerWar2[0] == Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES)
                        {
                            return false;
                        }
                        

                    }
                }
            }
            return status;
        }

        /// <summary>
        /// Anexa de Remarks INTEGRA al boleto
        /// </summary>
        private static void SendIntegraRemarks()
        {
            InitInterJetRemarks();
            InitVolarisRemarks();

            if (VolarisSession.IsVolarisProcess)
            {
                RemarkVolaris.Clear();
            }

            if (IsInterJet)
            {
                RemarkInterJet.Clear();
            }

            int row = 0; int col = 0;
            string sendIntegra = string.Empty;
            string remarksCommand = Resources.TicketEmission.Constants.COMMANDS_5_DOT;
            string sendRemarks = string.Empty;
            string remarkTP = string.Empty;
            string sabreAnswer = string.Empty;
            string pax = string.Empty;
            String Warning = string.Empty;
            string c80 = string.Empty;
            string c23 = string.Empty;
            string time = string.Empty;
            bool status = true;

            if (!ucEndReservation.isFlowHotel)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {


                    sabreAnswer = objCommand.SendReceive(Resources.TicketEmission.Constants.COMMAND_DC_USD_MXN);

                }
                CommandsQik.searchResponse(sabreAnswer, "RATE BSR", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(sabreAnswer, ref remarkTP, 1, 18, 6);
                }

                using (CommandsAPI objCommand = new CommandsAPI())
                {

                    sabreAnswer = objCommand.SendReceive("T*MEX");

                }

                CommandsQik.CopyResponse(sabreAnswer, ref time, 1, 3, 10);
            }

            //bucle remarks
            foreach (string value in ucAllQualityControls.remarksIntegra)
            {
                lenght = 0;
                sendRemarks = string.Empty;
                sendIntegra = string.Empty;
                sendIntegra = remarksCommand;
                string[] splitRemarks = value.Split(new Char[] { '+' },StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i <= splitRemarks.LongLength - 1; i++)
                {

                    if (!string.IsNullOrEmpty(splitRemarks[i]))
                    {
                        if(splitRemarks[i].Contains("SELECCIONE EL VALOR DESEADO:"))
                        {
                            splitRemarks[i]=string.Empty;
                        }
                        lenght = sendIntegra.Length + splitRemarks[i].Length;
                        if (lenght < 72)
                        {
                            sendIntegra = string.Concat(sendIntegra,
                                splitRemarks[i]);
                        }
                        else
                        {

                            sendRemarks = string.Concat(sendRemarks,
                                sendIntegra);

                            sendIntegra = string.Empty;
                            sendIntegra = string.Concat("Σ",
                                remarksCommand,
                                splitRemarks[i]);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(sendIntegra))
                {

                    sendRemarks = string.Concat(sendRemarks,
                                                sendIntegra);
                    RemarkVolaris.Add(sendRemarks);
                    //VolarisSession.Remarks.Add(sendRemarks);
                    RemarkInterJet.Add(sendRemarks);

                }

                c80 = string.Empty;
                pax = string.Empty;

                pax = string.Concat(sendRemarks.Substring(1, 13));
                string[] pax1 = pax.Split(new char[] { '-' });
                pax = pax1[1].Substring(0, 2);
                pax = string.Concat("-", pax, "*");

                if (!string.IsNullOrEmpty(sendRemarks))
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        //TODO:InterJet Migration verificar que se ejectue cuando no sea de prueba.
                        if (!VolarisSession.IsVolarisProcess && !IsInterJet)
                        {
                            objCommand.SendReceiveEmission(sendRemarks);
                            sendRemarks = string.Empty;
                        }
                    }
                }

                Parameter activeLabelC80 = ParameterBL.GetParameterValue("EtiquetaC80");
                if (Convert.ToBoolean(activeLabelC80.Values))
                {
                    if (!string.IsNullOrEmpty(newlabel))
                    {
                        c80 = newlabel.Replace("*", pax);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceiveEmission(c80);
                        }
                        newlabel = string.Empty;
                    }
                }

                if (!ucAvailability.IsInterJetProcess || !VolarisSession.IsVolarisProcess)
                {
                    if (!string.IsNullOrEmpty(ucChargeService.C23))
                    {
                        c23 = ucChargeService.C23.Replace('+', ' ').Trim();
                        c23 = string.Concat("5.", c23);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceiveEmission(c23);
                        }
                        ucChargeService.ChargePerService = string.Empty;
                        ucChargeService.C23 = string.Empty;
                        ucQREX.Qrex = false;
                    }
                }

                if (!string.IsNullOrEmpty(ucQREX.C80))
                {
                    c80 = ucQREX.C80.Replace("*", pax);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceiveEmission(c80);
                    }

                    ucQREX.C80 = string.Empty;
                }



            }

            if (!ucAllQualityControls.QC28Value.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                string send = string.Empty;
                if (!string.IsNullOrEmpty(ucFormPayment.C28))
                {
                    send = string.Concat(remarksCommand,
                        "</C28*",
                        ucFormPayment.C28,
                        "/>");
                }
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    if (!VolarisSession.IsVolarisProcess && !IsInterJet)
                    {
                        objCommand.SendReceiveEmission(send);
                        sendIntegra = string.Empty;

                    }


                }

                if (VolarisSession.IsVolarisProcess)
                {
                    RemarkVolaris.Add(send);
                    //VolarisSession.Remarks.Add(send);
                }

                if (IsInterJet)
                {
                    RemarkInterJet.Add(send);
                }
                ucFormPayment.C28 = string.Empty;
            }


            string LastRemark = string.Empty;

            if (!ucEndReservation.isFlowHotel)
            {
                LastRemark = string.Concat(LastRemark, "5.</TK ISSUE MYCTS/>Σ5H-.</TK ISSUE MYCTS/>Σ5H-</C00*", remarkTP, "* ", time, "/>");
                LastRemark = string.Concat(LastRemark, "Σ5.</C00*", remarkTP, "* ", time, "/>");
                if (VolarisSession.IsVolarisProcess)
                {
                    RemarkVolaris.Add(LastRemark);
                    //VolarisSession.Remarks.Add(LastRemark);
                    RemarkInterJet.Add(LastRemark);
                }
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    if (!VolarisSession.IsVolarisProcess && !IsInterJet)
                    {
                        objCommand.SendReceiveEmission(LastRemark);
                    }
                }
            }
        }

        /// <summary>
        /// Anexa de Remarks del cliente al boleto
        /// </summary>
        private static void SendClientsRemarks()
        {
            string sendRemarks = string.Empty;
            foreach (string value in ucAllQualityControls.remarksClients)
            {
                string[] splitRemarks = value.Split(new Char[] { '+' });
                for (int i = 0; i <= splitRemarks.LongLength - 1; i++)
                {
                    if (!string.IsNullOrEmpty(splitRemarks[i]))
                    {
                        sendRemarks = string.Concat(sendRemarks,
                            splitRemarks[i],
                            "Σ");
                    }
                }
                if (!string.IsNullOrEmpty(sendRemarks))
                {
                    sendRemarks = sendRemarks.TrimEnd('Σ');
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceiveEmission(sendRemarks);
                    }
                }
            }
        }

        public static void BuildRemarksForVolaris()
        {
            SendIntegraRemarks();
            ucAllQualityControls.remarksIntegra.Clear();
        }

        public static void BuildRemarksForInterJet()
        {

            SendIntegraRemarks();
            ucAllQualityControls.remarksIntegra.Clear();
        }

        /// <summary>
        /// Envia comando para desplegar los numeros de boletos emitidos y 
        /// generar los links correspondientes a la factura y a virtually there
        /// </summary>
        private void SendValidationTicketCommand()
        {
            TktNumber = new List<string>();
            PaxName = new List<string>();
            LinkVT = new List<string>();
            sabreAnswer = string.Empty;
            sabreConcat = string.Empty;
            string emitedPCC = string.Empty;
            string command = Resources.TicketEmission.Constants.COMMANDS_AST_T;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                sabreAnswer = objCommands.SendReceive(command);
            }
            //return;
            sabreConcat = sabreAnswer;
            SearchTKT();
            sabreConcat = sabreConcat.Replace('‡', '\n');
            string[] numbersOfTkt = sabreConcat.Split(new char[] { '\n' });
            foreach (string tkt in numbersOfTkt)
                //if (tkt.Length > 30
                //    && ValidateRegularExpression.ValidateThirteenNumbers(tkt.Substring(7, 13))
                //    && tkt.Substring(4, 2) != "TV")
                //{
                //    TktNumber.Add(tkt.Substring(7, 13));
                //    if (tkt.Substring(20, 1) == "/")
                //        PaxName.Add(tkt.Substring(27, 7).Trim());
                //    else
                //        PaxName.Add(tkt.Substring(24, 7).Trim());
                //}
                if (tkt.Length > 30
                    && tkt.Contains("TE"))
                {
                    emitedPCC = recoverEmitedPCC(tkt);
                    string[] dataResp = tkt.Split(new char[] { ' ' });
                    for (int i = 0; i < dataResp.Length - 1; i++)
                    {
                        if (dataResp[i].Contains("-"))
                        {
                            string fullData = dataResp[i].Trim();
                            string value = fullData.Substring(0, 13);
                            TktNumber.Add(value);
                            if (dataResp[i + 1].Contains("/"))
                            {
                                PaxName.Add(dataResp[i + 1].ToString());
                            }
                            else
                            {
                                PaxName.Add(string.Format("{0} {1}", dataResp[i + 1].ToString(), dataResp[i + 2].ToString()));
                            }

                            break;
                        }
                    }
                }
            sabreAnswer = string.Empty;
            sabreConcat = string.Empty;
            //**********************************************************************
            string recordLocalizator = ucFirstValidations.LocatorRecord;
            if (string.IsNullOrEmpty(recordLocalizator))
                recordLocalizator = ucTicketEmissionBuildCommand.RecordLocator;
            Parameter activateTicketPrinter = ParameterBL.GetParameterValue("ActivateTicketPrinter");

            if (Convert.ToBoolean(activateTicketPrinter.Values))
            {
                List<string> listTicketsByPNR = GetTicketsByPNRBL.GetTKTByPNR(recordLocalizator);

                for (int j = 0; j < TktNumber.Count; j++)
                {
                    if (!listTicketsByPNR.Contains(TktNumber[j].Substring(3, 10)))
                    {
                        listNewTickets.Add(TktNumber[j]);
                    }
                }
            }
            //**************************************************************************
            for (int i = 0; i < TktNumber.Count; i++)
            {
                string[] names = PaxName[i].Split(new char[] { '/' });
                LinkVT.Add(string.Concat("https://services.tripcase.com/new/eticketPrint.html?pnr=", recordLocalizator, "&hostID=1W&ETTOT=1&ETNBR1=", TktNumber[i], "&pcc=", emitedPCC, "&action=printEticket"));
                
                //LinkVT.Add(string.Concat("https://www.virtuallythere.com/new/eTicketReceiptPrint.html?pnr=", recordLocalizator, "&pcc=3L64&language=1&name=",
                //    names[0], "&host=1W&agent=AFM&ETNBR1=", TktNumber[i], "&ETNME1=", names[0], "/", names[1].Substring(0, 1), " &ETDTE1=4DEC&ETISS1=3L64*AJV&ETTOT=1"));

                AddDetailsTktsLinksBL.AddDetailsTktsLinks(Login.Agent, recordLocalizator, TktNumber[i].Substring(3, 10), PaxName[i], LinkVT[i], DateTime.Now);
            }
            //***********************************************
            if (Convert.ToBoolean(activateTicketPrinter.Values))
                GetInfoTicketDelegate(listNewTickets);
            //***********************************************

            SetCSCLog();
        }

        //***********************************************************
        private delegate void FunctionTicketDelegate(List<string> listTKT);
        private void GetInfoTicketDelegate(List<string> listTKT)
        {
            FunctionTicketDelegate tkt = new FunctionTicketDelegate(GetInfoTicketAndPNR);
            tkt.BeginInvoke(listTKT, null, null);
        }

        private void GetInfoTicketAndPNR(List<string> listTKT)
        {
            CreateFilePDFTicket.CreateFilesPDF(listTKT);
        }
        //************************************************************
        private void SearchTKT()
        {
            SendScrollCommand();
            if (!SearchEndScroll)
            {
                SearchTKT();
            }
        }
        private bool SearchEndScroll
        {
            get
            {
                bool endScroll = false;
                int row = 0;
                int col = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.SCROLL_CROSS_LORAINE, ref row, ref col);
                if (row != 0 && col >= 0)
                {
                    endScroll = true;
                }
                else
                {
                    sabreConcat = string.Concat(sabreConcat,
                        "\n",
                        sabreAnswer);
                    endScroll = false;
                }
                return endScroll;
            }
        }
        /// <summary>
        /// Función que envia el comando MD 
        /// </summary>
        private void SendScrollCommand()
        {
            string send = string.Empty;
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send, 0, 0);
            }
        }


        /// <summary>
        /// Ingresa remark historico que contiene la tarifa total vendida del boleto
        /// </summary>
        private void BuildFareRemark()
        {
            string fareRemark = string.Empty;
            string send = string.Empty;
            int row = 0;
            int col = 0;
            if (!string.IsNullOrEmpty(activeStepsCorporativeQC.CorporativeQualityControls[0].FareRemark))
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.OK, ref row, ref col);
                if (row > 0)
                {

                    CommandsQik.CopyResponse(sabreAnswer, ref fareRemark, row, 3, 12);

                    if (!string.IsNullOrEmpty(fareRemark))
                    {
                        send = string.Concat(activeStepsCorporativeQC.CorporativeQualityControls[0].FareRemark,
                            fareRemark.Trim());
                        using (CommandsAPI objCommands = new CommandsAPI())
                        {
                            objCommands.SendReceive(send);
                        }
                    }


                }
            }
        }

        private void SendError()
        {
            try
            {
                Common.LogApplicationItem.UserControlName = this.Name;
                Common.LogApplicationItem.ErrorDescription = "Error de respuesta en la emisión de boleto";
                Common.LogApplicationItem.StackTrace = "Solo para referencia de emisiones que no continuaron con el flujo";
                LogsApplicationBL.AddLogApplication(Common.LogApplicationItem);
            }
            catch { }

        }

        private void Segment()
        {
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments) ||
                !string.IsNullOrEmpty(ucPhase35375Tickets.segment))
            {
                string seg = string.Empty;
                string res = string.Empty;
                string itinerary = string.Empty;
                string bysegment = string.Empty;
                string commandSegment = string.Empty;
                string konnect = string.Empty;
                int lenght = 0;
                int resplenght = 0;
                int lenghtcommand = 0;
                int aux = 0;
                int row = 0;
                int col = 0;
                int row1 = 0;
                int col1 = 0;
                int i = 0;
                int j = 0;


                newlabel = string.Concat("5.</C80*");
                if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments))
                    bysegment = ucTicketsEmissionInstructions.bySegments.Replace("‡S", " ").Trim();
                else if (!string.IsNullOrEmpty(ucPhase35375Tickets.segment))
                    bysegment = ucPhase35375Tickets.segment;

                seg = string.Concat("*IA");
                using (CommandsAPI2 objCommand = new CommandsAPI2())
                {
                    res = objCommand.SendReceive(seg, 0, 0);
                }

                string[] segments1 = bysegment.Split(new char[] { '/' });



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
                                aux = j;
                                break;
                            }
                        }
                        aux = j;
                    }
                }


                commandSegment = commandSegment.Remove(commandSegment.Length - 1);
                if (commandSegment.Length > 7)
                {
                    string[] commands = commandSegment.Split(new char[] { '.' });
                    lenghtcommand = commands.Length - 1;
                    for (int z = 0; z <= lenghtcommand - 1; z++)
                    {
                        if (commands[z] == commands[z + 1])
                        {
                            commands[z] = string.Empty;
                        }
                    }

                    commandSegment = string.Empty;

                    for (int a = 0; a <= lenghtcommand; a++)
                    {
                        if (!string.IsNullOrEmpty(commands[a]))
                            commandSegment = string.Concat(commandSegment, commands[a].Trim(), ".");
                    }
                    commandSegment = commandSegment.Remove(commandSegment.Length - 1);
                }

                newlabel = string.Concat(newlabel, commandSegment, "/>");

            }
        }

        /// <summary>
        /// Agrega un regitro en base de datos con la información de la emisión y el código de autorización
        /// </summary>
        private void SetCSCLog()
        {
            if ((ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_AMERICANEXPRESS) || ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_MIXPAYMENT)) && (ucFormPayment.CardType.Equals("VI") || ucFormPayment.CardType.Equals("CA")))
            {
                string tickets = string.Empty;

                if (listNewTickets.Count > 0)
                {
                    for (int i = 0; i < listNewTickets.Count; i++)
                    {
                        tickets = string.Concat(tickets, listNewTickets[i], ",");
                    }

                    tickets = tickets.Remove(tickets.Length - 1);
                    UpdateAuthCodeBL.UpdateAuthCode(ucFirstValidations.LocatorRecord, ucTicketEmissionConfirmation.AuthCode, tickets);
                }
                else if (string.IsNullOrEmpty(ucTicketsEmissionInstructions.CodeAuth.PNR))
                    SetAuthCodeBL.SetAuthCode(ucFirstValidations.LocatorRecord, ucTicketEmissionConfirmation.AuthCode, ucFormPayment.CardType, ucFormPayment.Amount, ucFormPayment.Bank, null, DateTime.Now, ucFormPayment.SendCommandWP);
            }
            ucFormPayment.ReturnForMisc = false;
            ucTicketEmissionConfirmation.AuthCode = string.Empty;
            ucFormPayment.Bank = string.Empty;
            ucFormPayment.Amount = string.Empty;
            //listNewTickets.Clear();
        }

        private void EMRSend()
        {
            FindMailFrom();
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(string.Concat(Resources.Constants.COMMANDS_6_NAME, Login.NombreCompleto.ToUpper()), 0, 1);
                objCommand.SendReceive(Resources.Constants.COMMANDS_EMR, 0, 1);
            }
        }

        private void FindMailFrom()
        {
            string sabreAnswer = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_PE);
                if (!string.IsNullOrEmpty(sabreAnswer))
                {
                    int row = 0;
                    int col = 0;
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.FR_SLASH, ref row, ref col);
                    if (row.Equals(0) && col.Equals(0))
                    {
                        string name = string.Empty;
                        if (Login.NombreCompleto.ToUpper().Contains("("))
                        {
                            name = Login.NombreCompleto.ToUpper();
                            name = name.Substring(0, (name.IndexOf("(") - 1));
                        }
                        objCommand.SendReceiveProfile(string.Concat(Resources.Profiles.Constants.COMMAND_PE_CROSS_LORAINE,
                                        Login.Mail.ToUpper(),
                                        Resources.TicketEmission.ValitationLabels.CROSS_LORAINE_FR_SLASH,
                                        name
                                        ));
                    }
                }
            }
        }

        private string recoverEmitedPCC(string tktInfo)
        {
            string pcc = string.Empty;
            if (tktInfo.Contains("*"))
            {
                pcc = tktInfo.Substring(tktInfo.IndexOf("*") - 4, 4);
            }
            else
            {
                pcc = "3L64";
            }
            return pcc;
        }
        #endregion//MethodsClass

    }
}
