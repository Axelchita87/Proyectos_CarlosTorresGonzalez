using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucSendTicketPrinter : CustomUserControl
    {
        public ucSendTicketPrinter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberTicket;
            this.LastControlFocus = btnAccept;
        }
        private static string tempccmail;
        public static string TempCCMail
        {
            get { return tempccmail; }
            set { tempccmail = value; }
        }

        private static string dk;
        public static string DK
        {
            get { return dk; }
            set { dk = value; }
        }

        private string sabreAnswer = string.Empty;
        private string sabreConcat = string.Empty;
        private bool addTicketInBD = false;
        private void ucSendTicketPrinter_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtNumberTicket.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumberTicket.Text))
            {
                MessageBox.Show("INGRESE EL NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberTicket.Focus();
            }
            else if (!string.IsNullOrEmpty(txtNumberTicket.Text) && txtNumberTicket.TextLength != 13)
            {
                MessageBox.Show("EL NÚMERO DE BOLETO DEBE SER DE 13 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberTicket.Focus();
            }
            else if (!string.IsNullOrEmpty(txtCCMail.Text) && !ValidateRegularExpression.ValidateEmailFormat(txtCCMail.Text))
            {
                MessageBox.Show("EL FORMATO DE CORREO ELECTRÓNICO ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCMail.Focus();
            }
            else
            {
                List<GetLinkByTkt> ticketList = new List<GetLinkByTkt>();
                ticketList = GetLinkByTktBL.GetLinkByTkt(txtNumberTicket.Text.Substring(3, 10), Login.OrgId);
                if (ticketList.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ticketList[0].LinkPassengerReceipt) && !string.IsNullOrEmpty(ticketList[0].LinkTicketPrinter))
                    {
                        SendPDFDelgate(txtNumberTicket.Text, ticketList[0].LinkVirtuallyThere, txtCCMail.Text.ToLower());
                        MessageBox.Show("SU SOLICITUD FUE ENVIADA CON ÉXITO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                    else
                    {
                        addTicketInBD = false;
                        try
                        {
                            RegenarateInvoice();
                        }
                        catch
                        {
                            MessageBox.Show("HA OCURRIDO UN ERROR EN LA REGENERACIÓN DEL BOLETO, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        }
                    }
                }
                else
                {
                    addTicketInBD = true;
                    try
                    {
                        RegenarateInvoice();
                    }
                    catch
                    {
                        MessageBox.Show("HA OCURRIDO UN ERROR EN LA REGENERACIÓN DEL BOLETO, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
            }
        }

        #region ====== METHODS CLASS ======

        private delegate void SendPDF(string ticket, string url, string ccMail);
        private void SendPDFDelgate(string ticket, string url, string ccMail)
        {
            SendPDF send = new SendPDF(SendPDFDocuments);
            send.BeginInvoke(ticket, url, ccMail, null, null);
        }
        private void SendPDFDocuments(string ticketNumber, string urlVirtuallyThere, string ccMail)
        {
            CreateFilePDFTicket.ReSendPDFDocumnets(ticketNumber, urlVirtuallyThere, ccMail);
        }

        private void txtNumberTicket_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberTicket.TextLength == 13)
                txtCCMail.Focus();
        }

        /// <summary>
        /// Regenera el boleto cuando no fue encontrado en la BD
        /// </summary>
        private void RegenarateInvoice()
        {
            string ticket = string.Empty;
            string paxName = string.Empty;
            string linkVT = string.Empty;
            List<string> listNewTickets = null;
            string emitedPCC = string.Empty;
            sabreAnswer = string.Empty;
            sabreConcat = string.Empty;
            string command = string.Concat("*TKT", txtNumberTicket.Text.Substring(3, 10));
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                sabreAnswer = objCommands.SendReceive(command);
            }
            string[] sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, "UNABLE TO FIND TICKET NUMBER", ref row, ref col);
            if (row != 0 && col >= 0)
            {
                MessageBox.Show("EL NÚMERO DE BOLETO NO FUE ENCONTRADO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if (sabreAnswerInfo.Length > 0 && sabreAnswerInfo[0].Length == 6 && ValidateRegularExpression.ValidatePNR(sabreAnswerInfo[0]))
            {
                command = "*T";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    sabreAnswer = objCommands.SendReceive(command);
                }
                sabreConcat = sabreAnswer;
                SearchTKT();
                
                command = "*PDK";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    sabreAnswer = objCommands.SendReceive(command);
                }
                DK = sabreAnswer.Substring(18, 6);
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive("I");
                }
                sabreConcat = sabreConcat.Replace('‡', '\n');
                string[] numbersOfTkt = sabreConcat.Split(new char[] { '\n' });
                foreach (string tkt in numbersOfTkt)
                {
                    emitedPCC = recoverEmitedPCC(tkt);
                    int index = tkt.IndexOf(txtNumberTicket.Text);
                    if (index >= 0)
                    {
                        if (tkt.Length > 30
                            && ValidateRegularExpression.ValidateThirteenNumbers(tkt.Substring(index, 13))
                            && !tkt.Contains("TV")
                            )
                        //&& tkt.Substring(index, 13) == txtNumberTicket.Text)
                        {
                            ticket = tkt.Substring(index, 13);
                            string value = tkt.Substring(index, tkt.Length - index);
                            string[] data = value.Split(new char[] { ' ' });

                            if (data[1].Contains("/"))
                            {
                                paxName = data[1];
                                // else
                                //    paxName = tkt.Substring(24, 7).Trim();
                            }
                            else
                            {
                                paxName = string.Format("{0} {1}",data[1], data[2]);
                            }
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(ticket) && !string.IsNullOrEmpty(paxName))
                {
                    string airline = GetAirlineCodeByNumIDBL.GetAirlineCode(ticket.Substring(0, 3));
                    if (string.IsNullOrEmpty(airline) || airline.Equals("NOTHING"))
                    {
                        MessageBox.Show("ERROR EN CÓDIGO DE AEROLÍNEA, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                    else
                    {
                        string[] names = paxName.Split(new char[] { '/' });
                        linkVT = string.Concat("https://services.tripcase.com/new/eticketPrint.html?pnr=", sabreAnswerInfo[0], "&hostID=1W&ETTOT=1&ETNBR1=", ticket, "&pcc=", emitedPCC, "&action=printEticket");

                        //linkVT = string.Concat("https://www.virtuallythere.com/new/eTicketReceiptPrint.html?pnr=", sabreAnswerInfo[0], "&pcc=3L64&language=1&name=",
                        //    names[0], "&host=1W&agent=AFM&ETNBR1=", ticket, "&ETNME1=", names[0], "/", names[1].Substring(0, 1), " &ETDTE1=4DEC&ETISS1=3L64*AJV&ETTOT=1");
                        if (addTicketInBD)
                            AddDetailsTktsLinksBL.AddDetailsTktsLinks(Login.Agent, sabreAnswerInfo[0], ticket.Substring(3, 10), paxName, linkVT, DateTime.Now);
                        ucTicketsEmissionInstructions.Airline = airline;
                        listNewTickets = new List<string>();
                        listNewTickets.Add(txtNumberTicket.Text);
                        if (!string.IsNullOrEmpty(txtCCMail.Text))
                            tempccmail = txtCCMail.Text.ToLower();
                        GetInfoTicketDelegate(listNewTickets);
                        MessageBox.Show("SU SOLICITUD FUE ENVIADA CON ÉXITO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                else
                {
                    MessageBox.Show("EL BOLETO NO PUDO SER ENCONTRADO, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }

            }
            else
            {
                MessageBox.Show("NO SE PUEDE ACCESAR AL NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

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

        /// <summary>
        /// Busqueda de Boletos
        /// </summary>
        private void SearchTKT()
        {
            SendScrollCommand();
            if (!SearchEndScroll)
            {
                SearchTKT();
            }
        }

        /// <summary>
        /// Valiada si es fin de información
        /// </summary>
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

        #endregion //METHODS CLASS

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regresa al user cotrol welcome cuando se presiona ESC o ejecuta
        /// la acción del botón aceptar cuando se presiona Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }

        #endregion // Back to a Previous Usercontrol or Validate Enter KeyDown


    }
}
