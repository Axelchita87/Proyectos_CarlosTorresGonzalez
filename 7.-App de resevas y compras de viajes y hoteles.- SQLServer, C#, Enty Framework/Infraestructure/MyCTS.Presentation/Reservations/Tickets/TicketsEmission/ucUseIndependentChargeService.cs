using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.PagosMIT;

namespace MyCTS.Presentation
{
    public partial class ucUseIndependentChargeService : CustomUserControl
    {
        public static string RemarkPax1 { get; set; }
        public static string RemarkPax2 { get; set; }
        public static string RemarkPax3 { get; set; }
        public static string RemarkPax4 { get; set; }
        public static string RemarkPax5 { get; set; }
        public static string RemarkPax6 { get; set; }
        public static string RemarkPax7 { get; set; }
        public static string RemarkPax8 { get; set; }
        public static string RemarkPax9 { get; set; }
        public static bool emissionTicket = false;
        private delegate void SenderCallBack();
        private delegate void StopControlsDelegate();
        private delegate void HideMessagesDelegate();
        private delegate void SendMessagesDelegate(string m);
        private delegate bool AplicarCargosDelegate();
        private string recLoc = ucFirstValidations.LocatorRecord;
        private string bysegments = string.Empty;
        private string fireType = string.Empty;
        private string ticketType = string.Empty;
        private string formOfPayment = string.Empty;
        private string ticketIssuingCarrierTarget = string.Empty;
        private string lastDateToPurcahse = string.Empty;
        private string baseFare = string.Empty;
        private string information = string.Empty;
        private static bool UsuarioValidoParaCargosPorServicio = false;
        private int indexImage = 0;
        int iCurrentPaxNumber = 1;
        int iCurrentPosicion = 1;
        private Parameter activateFormOfPaymentCS = null;
        private Parameter activateOldRemarkCS = null;
        private List<RuleAndPassenger> RuleAndPax = null;
        private List<GetCorporativeFeesRules> indexList = null;
        private List<BannerImage> imageList = null;
        public static List<CreditCardInfo> lstDatosTarjeta = null;
        OTATravelItinerary.OTATravelItineraryObject myObject = null;
        public static ChargesPerService.OrigenTipoCargo TipoCargo;

        public static string ChargePerService { get; set; }
        public static string C23 { get; set; }

        private class RuleAndPassenger
        {
            public int Rule { get; set; }
            public string PaxNumber { get; set; }
        }

        public ucUseIndependentChargeService()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            try
            {
                lstDatosTarjeta.Clear();
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }

            UsuarioValidoParaCargosPorServicio = UsuarioValidoCargosPorServicio();
           
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {

            string remarksCommand = Resources.TicketEmission.Constants.COMMANDS_5_DOT;
            string sendRemarks = string.Empty;
            string sendIntegra = string.Empty;
            int lenght = 0;

            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);

            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
        }

        private bool UsuarioValidoCargosPorServicio()
        {
            bool Status = ChargesPerService.ValidateTestingUsers(ChargesPerService.OrigenTipoCargo.FlujoAereo);
            return Status;
        }

        private void ucUseIndependentChargeService_Load(object sender, EventArgs e)
        {
            SenderCallBack scb = new SenderCallBack(LoadData);
            AsyncCallback callback = new AsyncCallback(OnCompleted);
            scb.BeginInvoke(callback, null);
        }

        private void LoadData()
        {
            try
            {
                GetValuesWebServices();
                GetLastDateToPurchase();
                if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CASH))
                    GetBaseFare();
                else
                    baseFare = ucFormPayment.BaseFare;

                GetValuesFromTicketEmissionInstructions();
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }
        }

        private void OnCompleted(IAsyncResult asyncResult)
        {
            AsyncResult result = (AsyncResult)asyncResult;
            SenderCallBack scb = (SenderCallBack)result.AsyncDelegate;
            scb.EndInvoke(asyncResult);
            ActivateCalculateChargeService();
        }

        public void GetValuesWebServices()
        {
            using (WSSessionSabre obj = new WSSessionSabre())
            {
                obj.OpenConnection();
                if (obj.IsConnected)
                {
                    myObject = new OTATravelItinerary().TravelItineraryMethod(obj.ConversationId, obj.IPcc, obj.SecurityToken, recLoc);
                    if (myObject != null)
                        if (myObject.Status)
                            InsertDetailsPNR();
                }
            }
        }

        private void InsertDetailsPNR()
        {
            for (int i = 0; i < myObject.PaxNumberList.Count; i++)
                for (int j = 0; j < myObject.DepartureAirportList.Count; j++)
                {
                    SetDetailsPNRBL.AddDetailsPNR(recLoc, myObject.DepartureAirportList[j], myObject.ArrivalAirportList[j],
                        myObject.DepartureDateTimeList[j], myObject.ArrivalDateTimeList[j], myObject.MarketingAirlineList[j], myObject.FlightNumberList[j],
                        Convert.ToDateTime(myObject.DepartureDateList[j]), myObject.AirlineRefList[j], myObject.DepartureDateList[0], myObject.Location_DK, Convert.ToDecimal(myObject.PaxNumberList[i]),
                        myObject.PassengerTypeList[i], myObject.GivenNameList[i], myObject.SurnameList[i],
                        myObject.SegmentType, myObject.FareBasis, myObject.PCC, myObject.IDGroup, null);
                }
        }

        private void GetLastDateToPurchase()
        {
            string sabreAnswer = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive("WPNCS", 0, 0);
            }
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, "LAST DAY TO PURCHASE", ref row, ref col);
            if (row > 0)
            {
                CommandsQik.CopyResponse(sabreAnswer, ref lastDateToPurcahse, row, 47, 5);
            }
        }

        private void GetBaseFare()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            string tarifa = string.Empty;
            string tourCode = string.Empty;
            string phase35375 = string.Empty;

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

            if (string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments) && string.IsNullOrEmpty(ucTicketsEmissionInstructions.byNames) && (string.IsNullOrEmpty(tarifa) && string.IsNullOrEmpty(phase35375) && string.IsNullOrEmpty(tourCode)))
                send = string.Concat(Resources.Constants.COMMANDS_WP, "A", ucTicketsEmissionInstructions.Airline, tarifa, tourCode, ucTicketsEmissionInstructions.byNames, ucTicketsEmissionInstructions.bySegments, ucTicketsEmissionInstructions.quarrelType, phase35375);
            else
                send = string.Concat(Resources.Constants.COMMANDS_WP, "A", ucTicketsEmissionInstructions.Airline, tarifa, tourCode, ucTicketsEmissionInstructions.byNames, ucTicketsEmissionInstructions.bySegments, ucTicketsEmissionInstructions.quarrelType, phase35375);

            int row = 0;
            int col = 0;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;

            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
            }
            catch { }

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
        }
        private void GetValuesFromTicketEmissionInstructions()
        {
            ticketType = ucTicketsEmissionInstructions.ticketType;
            formOfPayment = ucTicketsEmissionInstructions.wayPayment;
            fireType = ucTicketsEmissionInstructions.fareType;
            ticketIssuingCarrierTarget = ucTicketsEmissionInstructions.Airline;

            switch (ticketType)
            {
                case "rdoNormalTicket":
                    ticketType = "Boleto Normal";
                    break;
                case "rdoPhase35375":
                    ticketType = "Fase 3.5 y 3.75";
                    break;
                case "rdoPhaseIV":
                    ticketType = "Fase IV";
                    break;
            }

            switch (formOfPayment)
            {
                case "rdoAmericanExpress":
                    formOfPayment = "Tarjeta de crédito (Aut. Sistema).";
                    break;
                case "rdoCreditCard":
                    formOfPayment = "Tarjeta de crédito (Aut. Manual).";
                    break;
                case "rdoMixPayment":
                    formOfPayment = "Pago Mixto.";
                    break;
                case "rdoMiscelaneous":
                    formOfPayment = "Miscelaneo o Electrónico.";
                    break;
                case "rdoCash":
                    formOfPayment = "Efectivo.";
                    break;
            }

            bysegments = ucTicketsEmissionInstructions.bySegments;

            if (!string.IsNullOrEmpty(bysegments))
            {
                string[] aux = bysegments.Split(new char[] { '/' });
                string[] aux2 = aux[0].Split(new char[] { '-' });
                aux2[0] = aux2[0].Replace("‡S", "");
                int segment = 0;
                int totalSegment = 0;

                if (aux2.Length == 2)
                {
                    if (Convert.ToInt32(aux2[0]) > Convert.ToInt32(aux2[1]))
                    {
                        int auxiliar = Convert.ToInt32(aux2[0]);
                        aux2[0] = aux2[1];
                        aux2[1] = Convert.ToString(auxiliar);
                    }
                    segment = (Convert.ToInt32(aux2[1]) - Convert.ToInt32(aux2[0]) + 1);
                    segment = segment + aux.Length - 1;
                    totalSegment = segment;
                }
                else
                {
                    totalSegment = aux.Length;
                }

                bysegments = Convert.ToString(totalSegment);
            }
        }

        private void ActivateCalculateChargeService()
        {
            if (this.InvokeRequired)
            {
                SenderCallBack scb = new SenderCallBack(ActivateCalculateChargeService);
                this.Invoke(scb);
            }
            else
            {

                activateFormOfPaymentCS = ParameterBL.GetParameterValue("ActivateFormOfPaymentCS");
                activateOldRemarkCS = ParameterBL.GetParameterValue("ActivateOldRemarkCS");
                CalculateChargeService();
            }
        }
        private void CalculateChargeService()
        {
            string location_dk = ucFirstValidations.DK;
            string[] temp = ucQualitiesByPax.arraypassengers;
            string ticketIssuer = Login.Agent;
            string typePax = string.Empty;
            string dayTime = ucQualitiesByPax.DayTime.ToString("dd/MM/yyyy");
            string wekDay = Convert.ToString(ucQualitiesByPax.DayTime.DayOfWeek);

            switch (wekDay)
            {
                case "Sunday":
                    wekDay = "Domingo";
                    break;
                case "Monday":
                    wekDay = "Lunes";
                    break;
                case "Tuesday":
                    wekDay = "Martes";
                    break;
                case "Wednesday":
                    wekDay = "Miércoles";
                    break;
                case "Thursday":
                    wekDay = "Jueves";
                    break;
                case "Friday":
                    wekDay = "Viernes";
                    break;
                case "Saturday":
                    wekDay = "Sábado";
                    break;
            }

            string distributionChanel = string.Empty;
            string bussinesUnit = string.Empty;
            string advancedPurchase = string.Empty;
            string marketingAirline = string.Concat(ucTicketsEmissionInstructions.tourCode, " ", ucTicketsEmissionInstructions.tourCodeAgreements);

            try
            {
                if (myObject != null
                    && myObject.DepartureDateList != null
                    && myObject.DepartureDateList.Count > 0
                    && !string.IsNullOrEmpty(lastDateToPurcahse))
                    advancedPurchase = (Convert.ToString(Convert.ToDateTime(myObject.DepartureDateList[0]) - Convert.ToDateTime(lastDateToPurcahse)).Substring(0, 2)).TrimEnd(new char[] { '.' });
            }
            catch { }

            int count = 0;
            RuleAndPax = new List<RuleAndPassenger>();

            if (temp != null)
            {
                foreach (string tempcount in temp)
                {
                    if (temp[count].Length > 1)
                    {
                        temp[count] = tempcount.Substring(0, 2);
                        temp[count] = (temp[count].Trim(new char[] { '.' }));
                        count++;
                    }
                }
            }

            int i = 0;
            int sPoSicionPax = 0;

            if (ucAllQualityControls.paxNumberLabel.Count == ucAllQualityControls.globalPaxNumber)
            {
                if (ucAllQualityControls.paxNumberLabel.Count > 0)
                {
                    sPoSicionPax = ucAllQualityControls.paxNumberLabel.Count;
                }
            }
            else
            {
                sPoSicionPax = ucAllQualityControls.globalPaxNumber;             
            }

            for (int x = sPoSicionPax; x > 0; x--)
            {
                if (temp != null)
                    i = Convert.ToInt32(temp[x - 1]);
                else
                    i = x;

                try
                {
                    distributionChanel = ucAllQualityControls.originOfSale[x - 1];
                    bussinesUnit = ucAllQualityControls.ListBussinesUnit[x - 1];
                }
                catch (Exception ex)
                {
                    distributionChanel = ucAllQualityControls.originOfSale[ucAllQualityControls.originOfSale.Count - 1];
                    bussinesUnit = ucAllQualityControls.ListBussinesUnit[ucAllQualityControls.originOfSale.Count - 1];
                    string sError = ex.Message;
                }

                try
                {
                    if (myObject != null && myObject.PassengerTypeList != null && myObject.PassengerTypeList.Count > 0)
                        typePax = myObject.PassengerTypeList[i - 1];
                    else
                        typePax = string.Empty;
                }
                catch { typePax = string.Empty; }

                indexList = new List<GetCorporativeFeesRules>();

                if (!string.IsNullOrEmpty(baseFare))
                {
                    try
                    {
                        if (myObject != null)
                            indexList = GetCorporativeFeesRulesBL.GetCorporativeFeesRules(location_dk, ucFirstValidations.Attribute1, Convert.ToDouble(baseFare), (myObject.DepartureAirportList != null && myObject.DepartureAirportList.Count > 0) ? myObject.DepartureAirportList[0] : null, (myObject.ArrivalAirportList != null && myObject.ArrivalAirportList.Count > 0) ? myObject.ArrivalAirportList[0] : null, (myObject.DepartureAirportList != null && myObject.DepartureAirportList.Count > 0) ? Convert.ToDateTime(myObject.DepartureDateList[0]).ToString("dd/MM/yyyy") : null, location_dk, typePax, myObject.SegmentType, "SABRE", dayTime, advancedPurchase, wekDay, ticketType, ticketIssuer, distributionChanel, fireType, myObject.FareBasis, ticketIssuingCarrierTarget, baseFare, formOfPayment, (string.IsNullOrEmpty(bysegments)) ? myObject.SegmentCount : bysegments, marketingAirline, myObject.PCC, bussinesUnit);
                        else
                            indexList = GetCorporativeFeesRulesBL.GetCorporativeFeesRules(location_dk, ucFirstValidations.Attribute1, Convert.ToDouble(baseFare), null, null, null, location_dk, typePax, null, "SABRE", dayTime, advancedPurchase, wekDay, ticketType, ticketIssuer, distributionChanel, fireType, null, ticketIssuingCarrierTarget, baseFare, formOfPayment, bysegments, marketingAirline, Login.PCC, bussinesUnit);
                    }
                    catch { }
                }

            }
        }
    }
}
