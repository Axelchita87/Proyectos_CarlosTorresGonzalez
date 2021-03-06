using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.MyCTSGEAComunication;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation
{
    public partial class ucEndReservation : CustomUserControl
    {
        /// <summary>
        /// Descripción: Permite hacer el cierre del record presente,pertenece
        ///              al flujo de Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:10/Septiembre/09
        /// Cambio:      Poner tiempo en ER por que no esta controlado    , Solicito Guillermo
        ///              PLEASE WAIT
        /// Autor:       Jessica Gutiérrez, Marcos Rámirez
        /// </summary>

        public static bool isFlowHotel = false;
        private string send;
        private string result;
        private string justificationCode;
        private string returnOptionValue;
        private string commandOption;
        private string queueAgent = string.Empty;
        private bool remark;
        private bool resume;
        private readonly bool QueueAdd = false;
        public static bool EndReservation;
        public static bool interrupt;
        private static bool SendClientRemarks;
        public static string dK;
        public static string dkCompare;
        private string sabreResult;
        private string sabreConcat;
        OTATravelItinerary.OTATravelItineraryObject myObject = null;
        public static List<OTATravelItineraryObjectHotel> objItineraryHotel = null;
        private string[] sabreAnswerCollection;
        public static bool isConfirmationNumberNull = false;

        public ucEndReservation()
        {
            InitializeComponent();
        }

        private void ucEndReservation_Load(object sender, EventArgs e)
        {
            if (ucConcludeReservation.firtsValidation)
            {
                if (!string.IsNullOrEmpty(ucClientQualityControls.ClientLocation))
                {
                    dK = ucClientQualityControls.ClientLocation;
                    dkCompare = (dK.Substring(0, 3));
                    if (!interrupt)
                    {
                        QualityControl();
                        ucConcludeReservation.firtsValidation = false;
                    }
                }
            }
            if (!interrupt)
            {
                if (Parameters != null && Parameters[0].Equals(Resources.Reservations.CONTINUE_RADIUS))
                {
                    returnOptionValue = Parameters[1];
                    ConcludeFlow();
                }
                else if (Parameters != null && Parameters[0].Equals(Resources.Reservations.CONTINUE_SANTANDER))
                {
                    justificationCode = Parameters[1];
                    send = Resources.Constants.COMMANDS_NO_REMARK + justificationCode;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                    }
                    returnOptionValue = Parameters[2];
                    ConcludeFlow();
                }
                if ((Parameters != null && ucBoletageReceived.boletageReceived) || (Parameters != null && ucBoletageDate.boletageDate) || (Parameters != null && ucDKClient.DkClient) || (Parameters != null && ucBillingAdress.billingAdress) || (Parameters != null && ucSecureFlightPassengerData.secureFlightPassenger))
                {
                    returnOptionValue = Parameters[0];
                    ConcludeFlow();
                    ucBoletageReceived.boletageReceived = false;
                    ucBoletageDate.boletageDate = false;
                    ucDKClient.DkClient = false;
                    ucBillingAdress.billingAdress = false;
                    ucSecureFlightPassengerData.secureFlightPassenger = false;
                }
            }
            interrupt = false;
        }

        /// <summary>
        /// En este se verifica a que Coorporativo pertence el cliente
        /// y de acuerdo a ello se realizan ciertas instrucciones para hacer
        /// el control de calidad, esto solo aplica para MACAFEE, RADIUS
        /// Si no pertenece a ninguno de estos continua con el flujo normal
        /// </summary>
        private void QualityControl()
        {
            returnOptionValue = ucConcludeReservation.optionSelected;
            ConcludeFlow();
        }

        /// <summary>
        /// De acuerdo a la opción seleccionada desde un principio se 
        /// comianzan a mandar los commandos correspondientes a cada opción
        /// para finalizar ahora si el cierre del record
        /// </summary>
        private void ConcludeFlow()
        {

            if (returnOptionValue.Equals("rdoCloseRecover"))
            {
                SendClientsRemarks();
                send = Resources.Constants.COMMANDS_ER;
                commandOption = send;

                string securityToken = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    securityToken = objCommand.SendReceive("OIATH", 0, 0);
                }

                using (CommandsAPI2 objCommand = new CommandsAPI2())
                {
                    result = objCommand.SendReceive(send, 1, 1, 1500);
                }


                Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

                if (regex.IsMatch(result.Trim().Split('\n')[0]))
                {
                    using (WSSessionSabre obj = new WSSessionSabre())
                    {
                        obj.OpenConnection();

                        if (obj.IsConnected)
                        {
                            InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                            OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                            insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken, result.Trim().Split('\n')[0], Login.PCC));
                        }
                    }
                }
                APIResponse();
                if (!interrupt)
                {
                    FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;

                    string securityToken1 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {

                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }
                    APIResponse();

                    if (!interrupt)
                        FinishFlow();
                }
                if (resume && ERR_ConcludeReservation.RequestPending && !ERR_ConcludeReservation.CCError)
                {

                    while (resume && ERR_ConcludeReservation.RequestPending)
                    {
                        string securityToken1 = string.Empty;

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                        }


                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }

                        if (regex.IsMatch(result.Trim().Split('\n')[0]))
                        {

                            using (WSSessionSabre obj = new WSSessionSabre())
                            {
                                obj.OpenConnection();

                                if (obj.IsConnected)
                                {
                                    InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                    OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                    insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[0], Login.PCC));
                                }
                            }
                        }

                        APIResponse();

                        if (ERR_ConcludeReservation.CCError)
                        {
                            break;
                        }
                    }
                    if (!interrupt)
                        FinishFlow();
                }
            }
            else if (returnOptionValue.Equals("rdoClosecopyitinerary"))
            {
                send = Resources.Constants.COMMANDS_ER;
                commandOption = "EC";
                Common.BeginManualCommandsTransactions();
                try
                {
                    string securityToken1 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI2 objCommand = new CommandsAPI2())
                    {
                        result = objCommand.SendReceive(send, 1, 1, 1500);
                    }

                    Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }

                    APIResponse();
                    if (!interrupt)
                    {

                        FinishFlow();
                    }

                    if (resume && ERR_ConcludeReservation.Command)
                    {
                        resume = false;

                        string securityToken2 = string.Empty;

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                        }

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                            result = objCommand.SendReceive(send);
                        }

                        if (regex.IsMatch(result.Trim().Split('\n')[0]))
                        {
                            using (WSSessionSabre obj = new WSSessionSabre())
                            {
                                obj.OpenConnection();

                                if (obj.IsConnected)
                                {
                                    InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                    OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                    insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                                }
                            }
                        }

                        APIResponse();

                        if (!interrupt)
                            FinishFlow();
                    }

                    if (resume && ERR_ConcludeReservation.RequestPending)
                    {
                        while (resume && ERR_ConcludeReservation.RequestPending)
                        {
                            string securityToken2 = string.Empty;

                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                            }

                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                result = objCommand.SendReceive(send);
                            }

                            if (regex.IsMatch(result.Trim().Split('\n')[0]))
                            {
                                using (WSSessionSabre obj = new WSSessionSabre())
                                {
                                    obj.OpenConnection();

                                    if (obj.IsConnected)
                                    {
                                        InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                        OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                        insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                                    }
                                }
                            }

                            APIResponse();
                        }
                        if (!interrupt)
                            FinishFlow();
                    }
                }
                catch { }
            }
            else if (returnOptionValue.Equals("rdoPlaceQueue"))
            {
                Common.BeginManualCommandsTransactions();
                try
                {
                    using (CommandsAPI objcommand = new CommandsAPI())
                    {
                        result = objcommand.SendReceive("ER");
                    }

                    string securityToken1 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }

                    APIResponse();
                    if (!interrupt)
                        FinishFlow();

                    if (resume && ERR_ConcludeReservation.Command)
                    {
                        resume = false;

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                            result = objCommand.SendReceive(send);
                        }
                        APIResponse();

                        if (!interrupt)
                            FinishFlow();
                    }

                    if (resume && ERR_ConcludeReservation.RequestPending)
                    {
                        while (resume && ERR_ConcludeReservation.RequestPending)
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                result = objCommand.SendReceive(send);
                            }
                            APIResponse();
                        }
                        if (!interrupt)
                            FinishFlow();
                    }
                }
                catch { }
            }
            else if (returnOptionValue.Equals("rdoCloseSendMail"))
            {
                send = Resources.Constants.COMMANDS_EMR;
                commandOption = send;

                string securityToken1 = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                }

                using (CommandsAPI objcommand = new CommandsAPI())
                {
                    result = objcommand.SendReceive(send);
                }

                Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

                if (regex.IsMatch(result.Trim().Split('\n')[0]))
                {
                    using (WSSessionSabre obj = new WSSessionSabre())
                    {
                        obj.OpenConnection();

                        if (obj.IsConnected)
                        {
                            InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                            OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                            insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[0], Login.PCC));
                        }
                    }
                }

                APIResponse();
                if (!interrupt)
                    FinishFlow();

                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;

                    string securityToken2 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }

                    APIResponse();
                    if (!interrupt)
                        FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;

                    string securityToken2 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }

                    APIResponse();

                    if (!interrupt)
                        FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.RequestPending)
                {
                    while (resume && ERR_ConcludeReservation.RequestPending)
                    {
                        string securityToken2 = string.Empty;

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                        }

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }

                        if (regex.IsMatch(result.Trim().Split('\n')[0]))
                        {
                            using (WSSessionSabre obj = new WSSessionSabre())
                            {
                                obj.OpenConnection();

                                if (obj.IsConnected)
                                {
                                    InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                    OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                    insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                                }
                            }
                        }

                        APIResponse();
                    }
                    if (!interrupt)
                        FinishFlow();
                }
            }
            else if (returnOptionValue.Equals("rdoCloseUpgradeRecord"))
            {
                send = Resources.Constants.COMMANDS_EWR;
                commandOption = send;

                string securityToken1 = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                }

                using (CommandsAPI objcommand = new CommandsAPI())
                {
                    result = objcommand.SendReceive(send);
                }

                Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

                if (regex.IsMatch(result.Trim().Split('\n')[0]))
                {
                    using (WSSessionSabre obj = new WSSessionSabre())
                    {
                        obj.OpenConnection();

                        if (obj.IsConnected)
                        {
                            InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                            OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                            insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[0], Login.PCC));
                        }
                    }
                }

                APIResponse();

                if (!interrupt)
                    FinishFlow();
                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;

                    string securityToken2 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }

                    APIResponse();
                    if (!interrupt)
                        FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;

                    string securityToken2 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                            }
                        }
                    }

                    APIResponse();

                    if (!interrupt)
                        FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.RequestPending)
                {
                    while (resume && ERR_ConcludeReservation.RequestPending)
                    {
                        string securityToken2 = string.Empty;

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                        }

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }

                        if (regex.IsMatch(result.Trim().Split('\n')[0]))
                        {
                            using (WSSessionSabre obj = new WSSessionSabre())
                            {
                                obj.OpenConnection();

                                if (obj.IsConnected)
                                {
                                    InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                    OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                    insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[0], Login.PCC));
                                }
                            }
                        }

                        APIResponse();
                    }
                    if (!interrupt)
                        FinishFlow();
                }
            }
            else if (returnOptionValue.Equals("rdoCloseSendMailBlackBerry"))
            {
                send = Resources.Constants.COMMANDS_EMXR;
                commandOption = send;

                string securityToken1 = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
                }

                using (CommandsAPI objcommand = new CommandsAPI())
                {
                    result = objcommand.SendReceive(send);
                }

                Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

                if (regex.IsMatch(result.Trim().Split('\n')[0]))
                {
                    using (WSSessionSabre obj = new WSSessionSabre())
                    {
                        obj.OpenConnection();

                        if (obj.IsConnected)
                        {
                            InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                            OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                            insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[2], Login.PCC));
                        }
                    }
                }

                APIResponse();
                if (!interrupt)
                    FinishFlow();

                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;
                    string securityToken2 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[2], Login.PCC));
                            }
                        }
                    }

                    APIResponse();
                    if (!interrupt)
                        FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.Command)
                {
                    resume = false;

                    string securityToken2 = string.Empty;

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                    }

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ);
                        result = objCommand.SendReceive(send);
                    }

                    if (regex.IsMatch(result.Trim().Split('\n')[0]))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();

                            if (obj.IsConnected)
                            {
                                InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[2], Login.PCC));
                            }
                        }
                    }

                    APIResponse();

                    if (!interrupt)
                        FinishFlow();
                }

                if (resume && ERR_ConcludeReservation.RequestPending)
                {
                    while (resume && ERR_ConcludeReservation.RequestPending)
                    {
                        string securityToken2 = string.Empty;

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            securityToken2 = objCommand.SendReceive("OIATH", 0, 0);
                        }

                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }

                        if (regex.IsMatch(result.Trim().Split('\n')[0]))
                        {
                            using (WSSessionSabre obj = new WSSessionSabre())
                            {
                                obj.OpenConnection();

                                if (obj.IsConnected)
                                {
                                    InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                                    OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                                    insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken2, result.Trim().Split('\n')[2], Login.PCC));
                                }
                            }
                        }

                        APIResponse();
                    }
                    if (!interrupt)
                        FinishFlow();
                }
            }
        }

        /// <summary>
        /// Envio de comando para cierre de la reservación
        /// </summary>
        private void FinishFlow()
        {

            if (resume)
                return;

            EndReservation = true;
            string PNR = string.Empty;
            string res = string.Empty;
            SendClientRemarks = false;
            Common.BeginManualCommandsTransactions();

            //InsertSCDCResumenBL resumenSCDC = new InsertSCDCResumenBL();

            //SCDCResumen resumen = new SCDCResumen();


            try
            {
                PNR = RecordLocalizer.GetRecordLocalizer();

                if (!string.IsNullOrEmpty(PNR))
                {
                    if (ucConcludeReservation.newpnr)
                    {
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            CommandsAPI2.send_MessageToEmulator(string.Concat("NEWPNR"));
                        }
                    }
                    TempHotel.PNR = PNR;
                    GetDataRecord(res);
                }
                else
                {

                    if (ERR_ConcludeReservation.RequestPending)
                    {
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive("ER", false);
                        }

                        PNR = RecordLocalizer.GetRecordLocalizer();
                        if (!string.IsNullOrEmpty(PNR))
                        {
                            if (ucConcludeReservation.newpnr)
                            {
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    CommandsAPI2.send_MessageToEmulator(string.Concat("NEWPNR"));
                                }
                            }
                            TempHotel.PNR = PNR;
                            GetDataRecord(res);
                        }
                        else
                        {
                            MessageBox.Show("ERROR EN CLAVES DE CONFIRMACIÓN. FAVOR DE VALIDAR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isFlowHotel = false;
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        }
                    }

                }
            }
            catch
            {
                UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels(string.Concat(PNR, "%"), string.Empty, true, string.Empty);
                TempHotel.Clear();
            }
            ExecEndCommandTransaction();
            EndReservation = false;
            if (!string.IsNullOrEmpty(PNR) && !isConfirmationNumberNull)
            {

                ////
                ucQREX.C80 = string.Empty;
                ucQREX.CheckForIllegalCrossThreadCalls = false;
                ucQREX.CommandQREX = string.Empty;
                ucQREX.Qrex = false;

                ////

                GetValuesWS(PNR);
                if (!isFlowHotel)
                {
                    QueueAgent();
                    send = Resources.Constants.AST + PNR;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        res = objCommand.SendReceive(send);
                    }
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_QC_HOTELS);
                }
            }
            else if (isConfirmationNumberNull)
            {
                isFlowHotel = false;
                MessageBox.Show("SEGMENTOS SIN CLAVE DE CONFIRMACION, VERIFICA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Llamado al servicio web que va extraer los datos del
        /// record localizador del cual se este emitiendo un boleto
        /// </summary>
        private delegate void GetValuesWSAsync(string recLoc);
        private delegate void EndCommandTransactionAsyn();

        private void GetValuesWS(string recLoc)
        {
            if (string.IsNullOrEmpty(recLoc))
                return;

            GetValuesWSAsync ws = GetValuesWebServicesAsync;
            ws.BeginInvoke(recLoc, null, null);
        }

        private void ExecEndCommandTransaction()
        {
            return;
        }

        private void ExecEndCommandTransactionAsync()
        {
            Common.EndManualCommandsTransactions();
        }

        private void GetValuesWebServicesAsync(string recLoc)
        {
            try
            {
                using (WSSessionSabre obj = new WSSessionSabre())
                {
                    obj.OpenConnection();
                    if (obj.IsConnected)
                    {
                        myObject = new OTATravelItinerary().TravelItineraryMethod(obj.ConversationId, obj.IPcc, obj.SecurityToken, recLoc);
                        if (myObject != null && myObject.Status)
                            InsertDetailsPNR(recLoc);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Inserta en la tabla DetailsPNR los datos obtenidos por 
        /// el WEBSTERD
        /// </summary>
        private void InsertDetailsPNR(string recLoc)
        {
            try
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
            catch { }
        }

        /// <summary>
        /// Anexa de Remarks del cliente a la reservacion
        /// </summary>
        private void SendClientsRemarks()
        {
            if (!SendClientRemarks)
            {
                if (!string.IsNullOrEmpty(ucClientQualityControls.stringRemarksClients))
                {
                    string sendRemarks = string.Empty;
                    string[] splitRemarks = ucClientQualityControls.stringRemarksClients.Split(new[] { '+' });
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
                            objCommand.SendReceive(sendRemarks);
                        }
                    }
                    SendClientRemarks = true;
                }
            }
        }

        private void QueueSend()
        {
            EndReservation = true;
            using (CommandsAPI2 objCommand = new CommandsAPI2())
            {
                if (!resume)
                {
                    result = objCommand.SendReceive(ucConcludeReservation.sendPlaceQueue);
                }
            }
        }

        private void CommandsSend()
        {
            string ORCF = string.Empty;

            if (!string.IsNullOrEmpty(queueAgent))
            {
                queueAgent = string.Concat(queueAgent, Resources.Constants.CROSSLORAINE, ucConcludeReservation.sendPlaceQueue);

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(queueAgent);
                }
                string[] segPend = result.Split('\n');

                for (int i = 0; i < segPend.Length; i++)
                {
                    if (segPend[i].Contains("REQUEST PENDING-USE"))
                    {
                        string seg = segPend[i].Split(' ')[2];
                        if (!string.IsNullOrEmpty(seg))
                            using (CommandsAPI2 objCommand = new CommandsAPI2())
                            {
                                ORCF = objCommand.SendReceiveEmission(seg);
                            }
                    }
                }

            }
        }

        /// <summary>
        /// Validar DK y Segmento de Proteccion
        /// </summary>
        private void ValidateDKAndSegment()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_PDK);
                APIResponsePDK();
            }
        }

        /// <summary>
        /// Se hace la busqueda solo del DK y se extrae el mismo
        /// </summary>
        private void APIResponsePDK()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_ConcludeReservation.err_concludereservation(result);

                if (ERR_ConcludeReservation.Customer)
                {
                    dK = ERR_ConcludeReservation.CustomerNumber;
                    dkCompare = (dK.Substring(0, 3));
                }
                else if (ERR_ConcludeReservation.StatusDKNull)
                {
                    string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCDKCLIENT, sendInfo);
                    interrupt = true;
                }
            }
        }

        /// <summary>
        /// Se busca si existe numero de empleado, si no existe
        /// se va a otro user Control para perdir los datos necesarios
        /// para los controles de calidad
        /// </summary>
        private void APIResponseQualityControlMCFEE()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_ConcludeReservation.err_concludereservation(result);

                if (!ERR_ConcludeReservation.EmployesNumber)
                {
                    string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCACCOUNTINGINFORMATION, sendInfo);
                    interrupt = true;
                }
                else
                {
                    returnOptionValue = ucConcludeReservation.optionSelected;
                    ConcludeFlow();
                }
            }
        }

        /// <summary>
        /// En esta se aplica solo para Santander y se busca si 
        /// existen Remarks contables
        /// </summary>
        private void APIResponseQualityControlSantader()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_ConcludeReservation.err_concludereservation(result);
                if (ERR_ConcludeReservation.Remarks)
                    remark = true;
                else
                    remark = false;
            }
        }

        /// <summary>
        /// Se buscan las diversas respuesta que puede arrojar sabre
        /// cuando se va a hacer el cierre del record y pues de acuerdo
        /// a la respuesta es la acción que se realiza
        /// </summary>
        private void APIResponse()
        {
            resume = false;

            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_ConcludeReservation.err_concludereservation(result);

                if (!ERR_ConcludeReservation.Status && !ERR_ConcludeReservation.Showmask && !ERR_ConcludeReservation.Command && !ERR_ConcludeReservation.Otherwmask && !ERR_ConcludeReservation.EmployesNumber && !ERR_ConcludeReservation.Customer && !ERR_ConcludeReservation.PQ && !ERR_ConcludeReservation.allowClosedRecord && !ERR_ConcludeReservation.CommandF && !ERR_ConcludeReservation.Adreess && !ERR_ConcludeReservation.SecureFlight && !ERR_ConcludeReservation.RequestPending && !ERR_ConcludeReservation.ResendER)
                {
                    //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (ERR_ConcludeReservation.Otherwmask)
                {
                    resume = true;
                    EndReservation = true;
                    string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                    interrupt = true;
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED, sendInfo);
                }
                else if (ERR_ConcludeReservation.Showmask)
                {
                    resume = true;
                    EndReservation = true;
                    string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                    interrupt = true;
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_DATE, sendInfo);
                }
                else if (ERR_ConcludeReservation.Command)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive(Resources.Constants.COMMANDS_N_AST_NM, 0, 1);
                    }
                    resume = true;
                }
                else if (ERR_ConcludeReservation.PQ)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_WPRQ, 1, 1);
                        if (!string.IsNullOrEmpty(commandOption))
                            result = objCommand.SendReceive(commandOption);
                    }
                }
                else if (ERR_ConcludeReservation.Customer)
                {
                    resume = false;
                }
                else if (ERR_ConcludeReservation.allowClosedRecord)
                {
                    DialogResult yesNo = MessageBox.Show(ERR_ConcludeReservation.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (yesNo.Equals(DialogResult.Yes))
                    {
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(commandOption);
                        }
                        resume = false;
                    }
                    else
                    {
                        resume = true;
                    }
                }
                else if (ERR_ConcludeReservation.CommandF)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_F);
                        objCommand.SendReceive(Resources.Constants.COMMANDS_ER);
                    }
                    resume = false;
                }
                else if (ERR_ConcludeReservation.Adreess)
                {
                    resume = true;
                    EndReservation = true;
                    string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                    interrupt = true;
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCBILLINGADRESS, sendInfo);
                }
                else if (ERR_ConcludeReservation.SecureFlight)
                {
                    resume = true;
                    EndReservation = true;
                    string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                    interrupt = true;
                    ucTaxes.emissionTicket = false;
                    ucDefinitionTargetElements2.emissionTicket = false;
                    ucCalculateServiceCharge.emissionTicket = false;
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCSECUREPASSENGERFLIGHT, sendInfo);
                }
                else if (ERR_ConcludeReservation.RequestPending && !ERR_ConcludeReservation.CCError)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        string[] segPend = result.Split('\n');

                        for (int i = 0; i < segPend.Length; i++)
                        {
                            if (segPend[i].Contains("REQUEST PENDING-USE"))
                            {
                                string seg = segPend[i].Split(' ')[2];
                                if (!string.IsNullOrEmpty(seg))
                                {
                                    result = objCommand.SendReceive(seg, false);
                                }
                            }

                        }
                        using (CommandsAPI objcommand = new CommandsAPI())
                        {
                            result = objcommand.SendReceive("ER");
                        }

                    }
                }
                //ResendER();
                //string ORCF = string.Empty;
                //string[] segPend;
                //resume = true;

                    //segPend = result.Split(' ');
                //string seg = string.Empty;
                //seg = segPend[2];
                //int r;
                //if (!seg.Contains("RCF"))
                //{
                //    if (!int.TryParse(seg, out r))
                //    {
                //        //seg = segPend[7];
                //        seg = string.Empty;

                    //    }

                    //    //seg = string.Concat("0RCF", seg);
                //}
                //if (!string.IsNullOrEmpty(seg))
                //{
                //    using (CommandsAPI2 objCommand = new CommandsAPI2())
                //    {
                //        ORCF = objCommand.SendReceive(seg, 1, 1, 3000);
                //        result = ORCF;
                //        APIResponse();
                //    }
                //}
                else if (ERR_ConcludeReservation.RequestPending)
                {
                    MessageBox.Show("SEGMENTOS SIN CLAVE DE CONFIRMACION, VERIFICA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    interrupt = true;
                    resume = true;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

                }

                //else if (ERR_ConcludeReservation.Received)
                //{
                //    ResendER();
                //}
                else if (ERR_ConcludeReservation.ResendER)
                {
                    MessageBox.Show(" DEBES INGRESAR LOS DATOS PARA: \nEL PASSENGER SECURIY DATA REQUIRED", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    interrupt = true;
                    resume = true;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (ERR_ConcludeReservation.CCError)
                {
                    MessageBox.Show("DATOS DE TARJETA DE CREDITO INCORRECTOS, FAVOR DE VALIDAR.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    interrupt = true;
                    resume = true;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                {
                    MessageBox.Show(ERR_ConcludeReservation.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    interrupt = true;
                    resume = true;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
        }

        /// <summary>
        /// En esta función solo se extrae la Queue del Agente y si el Cliente
        /// tambien tiene Queue pues tambien se extrae la Queue del Cliente y
        /// se envia un comando para enviar el record a la Queue correspondiente
        /// </summary>
        private void QueueAgent()
        {
            string queueClient = string.Empty;
            string queue = string.Empty;
            string personalQueue = string.Empty;

            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Queue))
            {
                queue = item.Queue;
                if (!string.IsNullOrEmpty(queue))
                {
                    queueAgent = string.Format(Resources.Constants.COMMANDS_QP_SLA_AGENT_SLA_11, queue);
                }
            }

            List<DKTemp> listDKTemp = DKTempBL.GetDKTemp(dK, false);
            if (!listDKTemp.Count.Equals(0))
            {
                queueClient = listDKTemp[0].Queue;
                if (!string.IsNullOrEmpty(queueClient))
                    personalQueue = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_CLIENT_SLA_11, queueClient);
            }
            if (!QueueAdd)
            {
                string resp = string.Empty;
                if (!string.IsNullOrEmpty(queueAgent) && !string.IsNullOrEmpty(queueClient))
                {
                    if (ucConcludeReservation.optionSelected.Equals("rdoPlaceQueue"))
                    {
                        string CRQueuePlace = ucConcludeReservation.sendPlaceQueue;
                        CRQueuePlace = CRQueuePlace.Replace("QP/", Resources.Constants.CROSSLORAINE);
                        send = string.Concat(send, CRQueuePlace);
                    }
                    send = queueAgent + personalQueue;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        resp = objCommand.SendReceive(send);
                    }
                }
                else if (!string.IsNullOrEmpty(queueAgent) && string.IsNullOrEmpty(queueClient))
                {
                    if (ucConcludeReservation.optionSelected.Equals("rdoPlaceQueue"))
                    {
                        string CRQueuePlace = ucConcludeReservation.sendPlaceQueue;
                        CRQueuePlace = CRQueuePlace.Replace("QP/", Resources.Constants.CROSSLORAINE);
                        queueAgent = string.Concat(queueAgent, CRQueuePlace);
                    }
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        resp = objCommand.SendReceive(queueAgent);
                    }
                }
            }
        }

        private void AmAirlineValidation()
        {
            string sabreResult;
            int row = 0;
            int col = 0;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_IA);
            }
            CommandsQik.searchResponse(sabreResult, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col, 2, 3, 1, 64);
            if (row == 0)
            {
                string[] sabreAnswer = sabreResult.Split(new[] { '\n' });
                foreach (string airSegment in sabreAnswer)
                {
                    col = 0;
                    row = 0;
                    CommandsQik.searchResponse(airSegment, "ARNK", ref row, ref col);
                    if (row == 0)
                    {
                        string airline = string.Empty;
                        CommandsQik.CopyResponse(airSegment, ref airline, 1, 4, 2);
                        if (!string.IsNullOrEmpty(airline))
                        {
                            if (airline.Equals("MX"))
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SendInitialCommand()
        {
            send = string.Empty;
            result = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_POINT;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
        }

        private bool SearchRemarks()
        {
            bool exixtingRemarks = false;
            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, "REMARKS", ref row, ref col);
            if (row != 0 || col >= 0)
            {
                exixtingRemarks = true;
                sabreConcat = string.Concat(result, "\n", "?");
            }
            else
                exixtingRemarks = false;

            return exixtingRemarks;
        }

        private void BucleFindEndScroll()
        {
            SendScrollCommand();
            if (!SearchEndScroll())
                BucleFindEndScroll();
        }

        private bool SearchEndScroll()
        {
            bool endScroll = false;
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreResult, "SCROLL‡", ref row, ref col);
            if (row != 0 && col >= 0)
                endScroll = true;
            else
            {
                sabreConcat = string.Concat(sabreConcat, "REMARKS\n", sabreResult, "\n", "?");
                endScroll = false;
            }
            return endScroll;
        }

        private void SendScrollCommand()
        {
            send = string.Empty;
            sabreResult = string.Empty;
            send = "MD";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(send);
            }
        }

        private void DeleteRemarks()
        {
            sabreAnswerCollection = sabreConcat.Split(new char[] { '?' });
            sabreConcat = string.Empty;
            for (int i = sabreAnswerCollection.Length - 1; i >= 0; i--)
            {
                send = string.Empty;
                string[] sabreAnswerInfo = sabreAnswerCollection[i].Split(new char[] { '\n' });
                for (int j = sabreAnswerInfo.Length - 1; j >= 0; j--)
                {
                    result = string.Empty;
                    result = sabreAnswerInfo[j].ToString();
                    ERR_ConcludeReservation.Remarks = false;
                    ERR_ConcludeReservation.SMX = string.Empty;

                    APIResponseQualityControlSantader();
                    if (remark)
                    {
                        if (!string.IsNullOrEmpty(ERR_ConcludeReservation.SMX))
                        {
                            send = string.Empty;
                            send = string.Format(Resources.Constants.COMMANDS_REMARK,
                            ERR_ConcludeReservation.SMX);

                            if (!string.IsNullOrEmpty(sabreConcat))
                                sabreConcat = sabreConcat + "Σ";
                            sabreConcat = sabreConcat + send;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(sabreConcat))
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(sabreConcat);
                }
            }
        }

        //llena la tabla de detalles del itinerario de hotel
        public void GetHotelsItinerary(string serchSegmHotels, string serchDK, string PNR, string sixReceived, string agente, string mail, List<string> lstCommission)
        {
            serchSegmHotels = string.Empty;
            string searchSegmCars = string.Empty;
            string DKnineNinety = string.Empty;
            string[] serchRemarks = null;
            string serchRFC = string.Empty;
            string PNRDataHotel = string.Empty;
            string PNRDataCar = string.Empty;

            frmPreloading frm = new frmPreloading(this);
            frm.Show();

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                serchSegmHotels = objCommand.SendReceive(Resources.Constants.COMMANDS_ITIN_HOTEL, 0, 0);
                searchSegmCars = objCommand.SendReceive(Resources.Constants.COMMANDS_ITIN_CAR, 0, 0);

                if (serchSegmHotels == "‡NO ITIN‡\n" && searchSegmCars == "‡NO ITIN‡\n")
                {
                    ucEndReservation.isFlowHotel = false;
                }
                else
                {
                    ucEndReservation.isFlowHotel = true;
                }
                if (serchSegmHotels.Split('\n')[0] != Resources.Constants.COMMANDS_NOT_ITINERARY || searchSegmCars.Split('\n')[0] != Resources.Constants.COMMANDS_NOT_ITINERARY)
                {
                    serchDK = objCommand.SendReceive(Resources.Constants.COMMANDS_PDK, false);
                    if (serchDK != Resources.Constants.COMMANDS_NOTHING)
                    {
                        DKnineNinety = serchDK.Substring(serchDK.Length - 8).Trim();
                        if (!string.IsNullOrEmpty(DKnineNinety) && DKnineNinety == "990")
                        {
                            serchRemarks = objCommand.SendReceive("*/", false).Split('/');
                            if (!serchRemarks[0].Contains("NO PSGR DATA"))
                            {
                                serchRFC = serchRemarks[5].Trim().ToString();
                            }
                        }
                        else
                            serchRFC = string.Empty;
                    }

                    try
                    {
                        PNRDataHotel = string.Empty;
                        PNRDataCar = string.Empty;
                        GEAComunication serviceGea = new GEAComunication();
                        PNRDataHotel = serviceGea.ValidateInvoice(PNR, Login.OrgId, "H1");
                        PNRDataCar = serviceGea.ValidateInvoice(PNR, Login.OrgId, "AU");
                    }
                    catch
                    {
                        frm.Close();
                        MessageBox.Show("No se pudo validar factura Previa intente de nuevo.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        frm = new frmPreloading(this);
                        frm.Show();
                        PNRDataHotel = "Error";
                        PNRDataCar = "Error";

                    }
                }
            }
            int count = ValidateConcludedPNRBL.ValidateConcludedPNR(PNR, Login.OrgId);

            if ((string.IsNullOrEmpty(PNRDataHotel) || string.IsNullOrEmpty(PNRDataCar)) && isFlowHotel)
            {
                if (!string.IsNullOrEmpty(PNRDataHotel))
                {
                    string[] reservationHotel = PNRDataHotel.Split('|');
                    frm.Close();
                    MessageBox.Show("La reservación de hotel  ha sido facturada en la " + reservationHotel[1] + "\n y documentada en GEA  en la reservación No." + reservationHotel[0] + "\n\n Si la reservación de Hotel ha sido modificada debes solicitar la cancelación de la STE y facturar los cambios en GEA.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frm = new frmPreloading(this);
                    frm.Show();
                }
                else if (!string.IsNullOrEmpty(PNRDataCar))
                {
                    frm.Close();
                    string[] reservationCar = PNRDataCar.Split('|');
                    MessageBox.Show("La reservación de auto  ha sido facturada en la " + reservationCar[1] + "\n y documentada en GEA  en la reservación No." + reservationCar[0] + "\n\n Si la reservación de Hotel ha sido modificada debes solicitar la cancelación de la STE y facturar los cambios en GEA.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frm = new frmPreloading(this);
                    frm.Show();
                }


                if (count == 0)
                {
                    using (WSSessionSabre obj = new WSSessionSabre())
                    {
                        obj.OpenConnection();
                        if (obj.IsConnected)
                        {
                            OTATravelItineraryHotels itineraryHotels = new OTATravelItineraryHotels();
                            objItineraryHotel = itineraryHotels.getHotelValues(obj.ConversationId, obj.IPcc, obj.SecurityToken, PNR, sixReceived, agente, mail, serchRFC, lstCommission, PNRDataHotel, PNRDataCar);
                        }
                    }

                    if (!string.IsNullOrEmpty(objItineraryHotel.Count > 0 ? objItineraryHotel[0].errorWSSabre : string.Empty))
                    {
                        using (WSSessionSabre obj = new WSSessionSabre())
                        {
                            obj.OpenConnection();
                            if (obj.IsConnected)
                            {
                                OTATravelItineraryHotels itineraryHotelsBkp = new OTATravelItineraryHotels();
                                objItineraryHotel = itineraryHotelsBkp.getHotelValues(obj.ConversationId, obj.IPcc, obj.SecurityToken, PNR, sixReceived, agente, mail, serchRFC, lstCommission, PNRDataHotel, PNRDataCar);
                            }
                        }

                    }

                    string errorWSSabre = string.Empty;

                    foreach (OTATravelItineraryObjectHotel obj in objItineraryHotel ?? new List<OTATravelItineraryObjectHotel>())
                    {
                        if (!string.IsNullOrEmpty(obj.errorWSSabre))
                        {
                            if (!string.IsNullOrEmpty(errorWSSabre))
                            {
                                errorWSSabre = string.Concat(errorWSSabre, '\n');
                            }

                            errorWSSabre = string.Concat(errorWSSabre, obj.errorWSSabre);
                        }
                    }

                    if (string.IsNullOrEmpty(errorWSSabre))
                    {
                        string var = string.Empty;
                        string rescurrency;
                        string[] changeType = null;
                        string[] changeType2 = null;
                        string formatted = string.Empty;
                        if (objItineraryHotel != null)
                        {
                            if (objItineraryHotel.Count > 0)
                            {
                                bool haveHotels = false;
                                bool haveCars = false;

                                for (int item = 0; item < objItineraryHotel.Count; item++)
                                {

                                    if (string.IsNullOrEmpty(objItineraryHotel[item].Confirmation_Number))
                                    {
                                        isConfirmationNumberNull = true;
                                    }
                                    else
                                    {
                                        isConfirmationNumberNull = false;
                                    }
                                    changeType2 = null;
                                    objItineraryHotel[item].Currency = objItineraryHotel[item].Currency ?? "MXN";
                                    if (!objItineraryHotel[item].Currency.Equals("MXN") && !objItineraryHotel[item].Currency.Equals("USD"))
                                    {
                                        double countryChangeType = 0;
                                        var = objItineraryHotel[item].Currency;
                                        using (CommandsAPI objCommand = new CommandsAPI())
                                        {
                                            rescurrency = objCommand.SendReceive("DC" + "*" + var + "*", false);
                                        }
                                        if (rescurrency.Contains("COUNTRY"))
                                        {
                                            changeType = rescurrency.Split("\n".ToCharArray());

                                            for (int i = 0; i < changeType.Length; i++)
                                            {

                                                if (changeType[i].Contains("."))
                                                {
                                                    changeType2 = changeType[i].Split(' ');
                                                    objItineraryHotel[item].ChangeType = Convert.ToDouble(changeType2[changeType2.Length - 2]);
                                                    break;
                                                }
                                                //else
                                                //{
                                                //    changeType2 = changeType[i + 1].Split(' ');
                                                //    objItineraryHotel[item].ChangeType = Convert.ToDouble(changeType2[changeType2.Length - 2]);
                                                //}
                                            }
                                        }

                                        //objItineraryHotel[item].Currency = "USD";
                                        //formatted = string.Format("{0:0.00}", objItineraryHotel[item].Cost * countryChangeType);
                                        //objItineraryHotel[item].Cost = Convert.ToDouble(formatted);
                                        //formatted = string.Format("{0:0.00}", objItineraryHotel[item].Cost * objItineraryHotel[item].Number_Nights);
                                        //objItineraryHotel[item].Price = Convert.ToDouble(formatted);
                                    }
                                    else if (objItineraryHotel[item].Currency.Equals("USD"))
                                    {
                                        var = objItineraryHotel[item].Currency;
                                        using (CommandsAPI objCommand = new CommandsAPI())
                                        {
                                            rescurrency = objCommand.SendReceive("DC" + "*" + var + "*", false);
                                        }
                                        changeType = rescurrency.Split("\n".ToCharArray());

                                        for (int i = 0; i < changeType.Length; i++)
                                        {
                                            if (changeType[i].Contains("COUNTRY"))
                                            {
                                                changeType2 = changeType[i + 1].Split(' ');
                                                break;
                                            }
                                        }

                                        if (changeType2 != null)
                                        {
                                            objItineraryHotel[item].ChangeType =
                                                Convert.ToDouble(changeType2[changeType2.Length - 2]);
                                        }
                                    }
                                    else if (objItineraryHotel[item].Currency.Equals("MXN"))
                                    {
                                        objItineraryHotel[item].ChangeType = 1;
                                    }

                                    objItineraryHotel[item].OrgId = Login.OrgId;
                                    objItineraryHotel[item].Firm = Login.Firm;
                                    objItineraryHotel[item].Pcc = Login.PCC;
                                    objItineraryHotel[item].UserName = Login.NombreCompleto.ToUpper();

                                    if (objItineraryHotel[item].Time_Limit != null)
                                    {
                                        objItineraryHotel[item].Time_Limit = objItineraryHotel[item].Time_Limit.AddDays(1);
                                    }

                                    if (objItineraryHotel[item].Record.ToLower().Contains("|car") && !haveCars && objItineraryHotel[item].StatusSabre.ToUpper() == "HK")
                                    {
                                        haveCars = true;
                                    }
                                    else if (objItineraryHotel[item].Record.ToLower().Contains("|hotel") && !haveHotels && objItineraryHotel[item].StatusSabre.ToUpper() == "HK")
                                    {
                                        haveHotels = true;
                                    }

                                    OTATravelItineraryHotelsBL.InsertItineraryHotel(objItineraryHotel);

                                }

                                if (!haveCars)
                                {
                                    UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels(string.Concat(PNR, "|CAR"), string.Empty, true, string.Empty);
                                }
                                else if (!haveHotels)
                                {
                                    UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels(string.Concat(PNR, "|HOTEL"), string.Empty, true, string.Empty);
                                }

                                UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels(string.Concat(PNR, "%"), string.Empty, true, string.Empty);
                                TempHotel.Clear();
                                isFlowHotel = true;
                            }
                            else
                            {
                                UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels(string.Concat(PNR, "%"), string.Empty, true, string.Empty);
                                isFlowHotel = false;
                            }
                        }
                        else
                        {
                            UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels(string.Concat(PNR, "%"), string.Empty, true, string.Empty);
                            isFlowHotel = false;
                        }
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(objItineraryHotel[0].Confirmation_Number))
                        {
                            frm.Close();
                            MessageBox.Show("Error en la clave de confirmación, favor de reintentar", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            frm = new frmPreloading(this);
                            frm.Show();
                            isConfirmationNumberNull = true;
                        }

                        if (string.IsNullOrEmpty(objItineraryHotel[0].Record))
                        {
                            objItineraryHotel[0].Record = PNR;
                        }
                        objItineraryHotel[0].Hotel = "Error";
                        if (OTATravelItineraryHotelsBL.InsertItineraryHotel(objItineraryHotel))
                        {
                            LogProductivity.LogTransaction(Login.Agent, "Registro de error de Hotel Satifactorio en DetailsPNRHotel");
                        }
                        else
                        {
                            LogProductivity.LogTransaction(Login.Agent, string.Concat("Error al insertar Registro de Hoteles Temporal en DetailsPNRHotel Record: ", PNR));
                        }
                        PNR = string.Empty;
                    }
                }
                else
                {
                    frm.Close();
                    MessageBox.Show("Tu reservación está documentada en GEA, puedes realizar la búsqueda con la clave del PNR.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frm = new frmPreloading(this);
                    frm.Show();
                    isFlowHotel = false;
                }
            }
            else if (PNRDataHotel == "Error" && PNRDataCar == "Error")
            {
                isFlowHotel = false;
            }
            else if (!string.IsNullOrEmpty(PNRDataHotel) && !string.IsNullOrEmpty(PNRDataCar))
            {
                frm.Close();
                string[] reservationHotel = PNRDataHotel.Split('|');
                MessageBox.Show("La reservación de hotel  ha sido facturada en la " + reservationHotel[1] + "\n y documentada en GEA  en la reservación No." + reservationHotel[0] + "\n\n Si la reservación de Hotel ha sido modificada debes solicitar la cancelación de la STE y facturar los cambios en GEA.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string[] reservationCar = PNRDataCar.Split('|');
                MessageBox.Show("La reservación de auto  ha sido facturada en la " + reservationCar[1] + "\n y documentada en GEA  en la reservación No." + reservationCar[0] + "\n\n Si la reservación de Hotel ha sido modificada debes solicitar la cancelación de la STE y facturar los cambios en GEA.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isFlowHotel = false;
                frm = new frmPreloading(this);
                frm.Close();
            }
            else if (!string.IsNullOrEmpty(PNRDataHotel))
            {
                frm.Close();
                string[] reservationHotel = PNRDataHotel.Split('|');
                MessageBox.Show("La reservación de hotel  ha sido facturada en la " + reservationHotel[1] + "\n y documentada en GEA  en la reservación No." + reservationHotel[0] + "\n\n Si la reservación de Hotel ha sido modificada debes solicitar la cancelación de la STE y facturar los cambios en GEA.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isFlowHotel = false;
                frm = new frmPreloading(this);
                frm.Show();
            }
            else if (!string.IsNullOrEmpty(PNRDataCar))
            {
                frm.Close();
                string[] reservationCar = PNRDataCar.Split('|');
                MessageBox.Show("La reservación de auto  ha sido facturada en la " + reservationCar[1] + "\n y documentada en GEA  en la reservación No." + reservationCar[0] + "\n\n Si la reservación de Hotel ha sido modificada debes solicitar la cancelación de la STE y facturar los cambios en GEA.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frm = new frmPreloading(this);
                frm.Show();
                isFlowHotel = false;
            }
        }

        public void GetDataRecord(string res)
        {
            TempHotel.SixReceived = ucBoletageReceived.param6Received;
            TempHotel.SearchDK = ucEndReservation.dK;
            List<string> lstCommission = new List<string>();
            lstCommission = GetCommission(res);
            GetHotelsItinerary(TempHotel.SearchSegmHotels, TempHotel.SearchDK, TempHotel.PNR,
            TempHotel.SixReceived, TempHotel.Agent, TempHotel.Mail, lstCommission);
            TempHotel.Clear();
        }

        public List<string> GetCommission(string ResER)
        {
            string[] commission = null;
            string typeCurrency = string.Empty;
            var valueReceived = string.Empty;
            List<string> commissionHotel = null;
            string resChangeCurrency = string.Empty;
            string converValor;

            if (ResER.Contains("CMT"))
            {
                commission = ResER.Split('/');
                for (int r = 0; r < commission.Length; r++)
                {
                    if (commission[r].ToString().Contains("CMT"))
                    {
                        commissionHotel = new List<string>();
                        string res = string.Empty;
                        converValor = commission[r].Split('-')[1];
                        if (!string.IsNullOrEmpty(converValor))
                        {
                            List<int> lstRes = new List<int>();
                            int pos;
                            for (int t = 0; t < 9; t++)//busca si tiene un valor numerico
                            {
                                pos = converValor.IndexOf(t.ToString());
                                if (pos > 0)
                                    lstRes.Add(pos);
                            }
                            if (lstRes.Count > 0)
                                res = converValor.Substring(lstRes[lstRes.Count - 1], 2);
                        }
                        if (!string.IsNullOrEmpty(res))

                            commissionHotel.Add(res);
                        else
                            commissionHotel.Add("10");
                    }
                }
                if (commissionHotel.Count == 0)
                {
                    commissionHotel.Add("10");
                }
            }
            else
            {
                commissionHotel = new List<string>();
                commissionHotel.Add("10");
            }
            return commissionHotel;
        }

        private void ResendER()
        {
            send = string.Empty;
            if (returnOptionValue.Equals("rdoCloseRecover"))
            {
                send = Resources.Constants.COMMANDS_ER;
            }
            else if (returnOptionValue.Equals("rdoClosecopyitinerary"))
            {
                send = Resources.Constants.COMMANDS_ER;
            }
            else if (returnOptionValue.Equals("rdoPlaceQueue"))
            {
                send = Resources.Constants.COMMANDS_ER;
            }
            else if (returnOptionValue.Equals("rdoCloseSendMail"))
            {
                send = Resources.Constants.COMMANDS_EMR;
            }
            else if (returnOptionValue.Equals("rdoCloseUpgradeRecord"))
            {
                send = Resources.Constants.COMMANDS_EWR;

            }
            else if (returnOptionValue.Equals("rdoCloseSendMailBlackBerry"))
            {
                send = Resources.Constants.COMMANDS_EMXR;
            }

            string securityToken1 = string.Empty;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                securityToken1 = objCommand.SendReceive("OIATH", 0, 0);
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }

            Regex regex = new Regex(@"^([A-Z]|[a-z]){6}$");

            if (regex.IsMatch(result.Trim().Split('\n')[0]))
            {
                using (WSSessionSabre obj = new WSSessionSabre())
                {
                    obj.OpenConnection();

                    if (obj.IsConnected)
                    {
                        InsertSCDCResumenBL insertresumen = new InsertSCDCResumenBL();
                        OTATravelItineraryFlights getresumen = new OTATravelItineraryFlights();
                        insertresumen.InsertSDCResumen(getresumen.getResumen(obj.ConversationId, obj.IPcc, securityToken1, result.Trim().Split('\n')[send != Resources.Constants.COMMANDS_EMXR ? 0 : 2], Login.PCC));
                    }
                }
            }

            APIResponse();
        }

        private bool ValidarFacturaGenerada()
        {
            return false;
        }

        private bool ValidarCargoRealizado()
        {
            return false;
        }
    }
}
