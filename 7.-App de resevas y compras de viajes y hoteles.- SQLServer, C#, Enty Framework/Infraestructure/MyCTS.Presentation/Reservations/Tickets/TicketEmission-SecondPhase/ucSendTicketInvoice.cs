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
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucSendTicketInvoice : CustomUserControl, IProcessAsync
    {

        /// <summary>
        /// Descripción: User Control que permite enviar la factura de la emision del boleto 
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    10 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        public ucSendTicketInvoice()
        {
            InitializeComponent();
        }

        private List<string> listNewTickets = new List<string>();
        private string sabreAnswer = string.Empty;
        private string send = string.Empty;
        private string sabreConcat = string.Empty;
        private List<string> TktNumber = new List<string>();
        private List<string> PaxName = new List<string>();
        private List<string> LinkVT = new List<string>();

        //**********
        private string UC = string.Empty;
        //*********

        //Evento Load
        private void ucSendTicketInvoice_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtDocsNumber.Focus();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                //frmPreloading fr = new frmPreloading(this);
                //fr.Show();
                CommandsSend();
            }
        }

        void IProcessAsync.InitProcess()
        {
            CommandsSend();
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("sendTicketInvoice"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_SEND_TICKET_INVOICE);
            else if (UC.Equals("welcome"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        #region===== MethodsClass =====


        /// <summary>
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if ((!string.IsNullOrEmpty(txtPaxNumber1.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber1.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtRangePaxNumber1.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtRangePaxNumber1.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRangePaxNumber1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber2.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber2.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtRangePaxNumber2.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtRangePaxNumber2.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRangePaxNumber2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber3.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber3.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtRangePaxNumber3.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtRangePaxNumber3.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRangePaxNumber3.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }

        /// <summary>
        /// Envia el comando correspondiente a la descripción de servicios especiales a MySabre
        /// </summary>
        private void CommandsSend()
        {
            send = string.Empty;
            string countintgLines = string.Empty;
            string numberPax = string.Empty;
            string segments = string.Empty;


            //Comandos Lineas Contables
            if (!string.IsNullOrEmpty(txtLineNumber1.Text) ||
                !string.IsNullOrEmpty(txtLineNumber2.Text) ||
                !string.IsNullOrEmpty(txtLineNumber3.Text))
            {
                countintgLines = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_A;

                if (!string.IsNullOrEmpty(txtLineNumber1.Text))
                {
                    countintgLines = string.Concat(countintgLines,
                        txtLineNumber1.Text);

                    if (!string.IsNullOrEmpty(txtLineRange1.Text))
                        countintgLines = string.Concat(countintgLines,
                            Resources.TicketEmission.Constants.INDENT,
                            txtLineRange1.Text);

                    countintgLines = string.Concat(countintgLines,
                        Resources.TicketEmission.Constants.SLASH);
                }

                if (!string.IsNullOrEmpty(txtLineNumber2.Text))
                {
                    countintgLines = string.Concat(countintgLines,
                        txtLineNumber2.Text);

                    if (!string.IsNullOrEmpty(txtLineRange2.Text))
                        countintgLines = string.Concat(countintgLines,
                            Resources.TicketEmission.Constants.INDENT,
                            txtLineRange2.Text);

                    countintgLines = string.Concat(countintgLines,
                        Resources.TicketEmission.Constants.SLASH);
                }

                if (!string.IsNullOrEmpty(txtLineNumber3.Text))
                {
                    countintgLines = string.Concat(countintgLines,
                        txtLineNumber3.Text);

                    if (!string.IsNullOrEmpty(txtLineRange3.Text))
                        countintgLines = string.Concat(countintgLines,
                            Resources.TicketEmission.Constants.INDENT,
                            txtLineRange3.Text);

                    countintgLines = string.Concat(countintgLines,
                        Resources.TicketEmission.Constants.SLASH);
                }
            }

            //Comandos Numero de pasajeros

            if (!string.IsNullOrEmpty(txtPaxNumber1.Text) ||
               !string.IsNullOrEmpty(txtPaxNumber2.Text) ||
               !string.IsNullOrEmpty(txtPaxNumber3.Text))
            {
                numberPax = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_N;

                if (!string.IsNullOrEmpty(txtPaxNumber1.Text))
                {
                    numberPax = string.Concat(numberPax,
                        txtPaxNumber1.Text);

                    if (!string.IsNullOrEmpty(txtRangePaxNumber1.Text))
                        numberPax = string.Concat(numberPax,
                            Resources.TicketEmission.Constants.INDENT,
                            txtRangePaxNumber1.Text);

                    numberPax = string.Concat(numberPax,
                        Resources.TicketEmission.Constants.SLASH);
                }

                if (!string.IsNullOrEmpty(txtPaxNumber2.Text))
                {
                    numberPax = string.Concat(numberPax,
                        txtPaxNumber2.Text);

                    if (!string.IsNullOrEmpty(txtRangePaxNumber2.Text))
                        numberPax = string.Concat(numberPax,
                            Resources.TicketEmission.Constants.INDENT,
                            txtRangePaxNumber2.Text);

                    numberPax = string.Concat(numberPax,
                        Resources.TicketEmission.Constants.SLASH);
                }

                if (!string.IsNullOrEmpty(txtPaxNumber3.Text))
                {
                    numberPax = string.Concat(numberPax,
                        txtPaxNumber3.Text);

                    if (!string.IsNullOrEmpty(txtRangePaxNumber3.Text))
                        numberPax = string.Concat(numberPax,
                            Resources.TicketEmission.Constants.INDENT,
                            txtRangePaxNumber3.Text);

                    numberPax = string.Concat(numberPax,
                        Resources.TicketEmission.Constants.SLASH);
                }
            }


            //Comandos segmentos

            if (!string.IsNullOrEmpty(txtSegment1.Text) ||
               !string.IsNullOrEmpty(txtSegment2.Text) ||
               !string.IsNullOrEmpty(txtSegment3.Text))
            {
                segments = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_S;

                if (!string.IsNullOrEmpty(txtSegment1.Text))
                {
                    segments = string.Concat(segments,
                        txtSegment1.Text);

                    if (!string.IsNullOrEmpty(txtRangeSegment2.Text))
                        segments = string.Concat(segments,
                            Resources.TicketEmission.Constants.INDENT,
                            txtSegment1.Text);

                    segments = string.Concat(segments,
                        Resources.TicketEmission.Constants.SLASH);
                }

                if (!string.IsNullOrEmpty(txtSegment2.Text))
                {
                    segments = string.Concat(segments,
                        txtSegment2.Text);

                    if (!string.IsNullOrEmpty(txtRangeSegment2.Text))
                        segments = string.Concat(segments,
                            Resources.TicketEmission.Constants.INDENT,
                            txtRangeSegment2.Text);

                    segments = string.Concat(segments,
                        Resources.TicketEmission.Constants.SLASH);
                }

                if (!string.IsNullOrEmpty(txtSegment3.Text))
                {
                    segments = string.Concat(segments,
                        txtSegment3.Text);

                    if (!string.IsNullOrEmpty(txtRangeSegment3.Text))
                        segments = string.Concat(segments,
                            Resources.TicketEmission.Constants.INDENT,
                            txtRangeSegment3.Text);

                }
            }

            if (!string.IsNullOrEmpty(countintgLines))
                countintgLines = countintgLines.TrimEnd(new char[] { '/' });
            if (!string.IsNullOrEmpty(numberPax))
                numberPax = numberPax.TrimEnd(new char[] { '/' });
            if (!string.IsNullOrEmpty(segments))
                segments = segments.TrimEnd(new char[] { '/' });

            send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_DIN,
                countintgLines,
                numberPax,
                segments);



            send = string.Concat(send,
                Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_DPB);

            if (!string.IsNullOrEmpty(txtDocsNumber.Text))
                send = string.Concat(send,
                    txtDocsNumber.Text);



            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            APIResponseDIN();
        }



        /// <summary>
        /// Valida la respuesta de mySabre cuando aparece la respuesta *PAC
        /// </summary>
        private void APIResponseDIN()
        {
            string result = string.Empty;
            string recordLocator = string.Empty;
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
                        //CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_ISSUE);

                        AddRecordsContainerBL.AddRecordsContainer(recordLocator, Login.Agent, true);
                        send = string.Empty;
                        send = string.Concat(Resources.TicketEmission.Constants.AST,
                            recordLocator);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }
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
                    //Common.EndManualCommandsTransactions(); 
                    ExecEndCommandTransaction();
                    //System.Threading.Thread.Sleep(1000);
                    ClearValues();
                    if (ucTicketEmissionBuildCommand.emiting)
                    {
                        SetCSCLog();
                        ucTicketEmissionBuildCommand.emiting = false;
                    }

                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR AL IMPRIMIR FACTURA. VERIFIQUE RESPUESTAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (ucTicketEmissionBuildCommand.emiting)
                    {
                        SetCSCLog();
                        ucTicketEmissionBuildCommand.emiting = false;
                    }
                    //UC = "sendTicketInvoice";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_SEND_TICKET_INVOICE);
                }
            }
            else if (ERR_TicketsEmission.StatusSendCommand == true)
            {
                sabreAnswer = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }


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
                        //CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_ISSUE);

                        AddRecordsContainerBL.AddRecordsContainer(recordLocator, Login.Agent, true);
                        send = string.Empty;
                        send = string.Concat(Resources.TicketEmission.Constants.AST,
                            recordLocator);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }
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
                        if (ucTicketEmissionBuildCommand.emiting)
                        {
                            SetCSCLog();
                            ucTicketEmissionBuildCommand.emiting = false;
                        }
                    }
                    catch { }
                }
                //Common.EndManualCommandsTransactions();
                ExecEndCommandTransaction();
                //System.Threading.Thread.Sleep(1000);
                ClearValues();
            }
            else
            {
                MessageBox.Show("OCURRIO UN ERROR AL IMPRIMIR FACTURA. VERIFIQUE RESPUESTAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (ucTicketEmissionBuildCommand.emiting)
                {
                    SetCSCLog();
                    ucTicketEmissionBuildCommand.emiting = false;
                }
                //UC = "sendTicketInvoice";//
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_SEND_TICKET_INVOICE);
               
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
        /// Envia comando para desplegar los numeros de boletos generados
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
                if (tkt.Length > 30
                    && ValidateRegularExpression.ValidateThirteenNumbers(tkt.Substring(7, 13))
                    && tkt.Substring(4, 2) != "TV")
                {
                    emitedPCC = recoverEmitedPCC(tkt);
                    TktNumber.Add(tkt.Substring(7, 13));
                    if (tkt.Substring(20, 1) == "/")
                        PaxName.Add(tkt.Substring(27, 7).Trim());
                    else
                        PaxName.Add(tkt.Substring(24, 7).Trim());
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

                LinkVT.Add(string.Concat("https://services.tripcase.com/new/eticketPrint.html?pnr=", recordLocalizator, "&hostID=1W&ETTOT=1&ETNBR1=", TktNumber[i],"&pcc=",emitedPCC , "&action=printEticket"));
                AddDetailsTktsLinksBL.AddDetailsTktsLinks(Login.Agent, recordLocalizator, TktNumber[i].Substring(3, 10), PaxName[i], LinkVT[i], DateTime.Now);
            }
            //***********************************************
            if (Convert.ToBoolean(activateTicketPrinter.Values))
                GetInfoTicketDelegate(listNewTickets);
            //***********************************************
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
            ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.FlujoAereo;
            ucServicesFeePayApply pago = new ucServicesFeePayApply();
            pago.PayServiceFee();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCSERVICESFEEPAYAPPLY);
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


        private string recoverEmitedPCC(string tktInfo)
        {
            string pcc = string.Empty;
            if (tktInfo.Contains("*"))
            {
                pcc = tktInfo.Substring(tktInfo.IndexOf("*") - 4, 4);
            }
            return pcc;
        }

        #endregion//End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }

        }

        #endregion//End Change focus When a Textbox is Full


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// instrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyData.Equals(Keys.Escape))
            //    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }


        }

        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

    }
}
