using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Services.Contracts;
using System.Net.Mail;
using MyCTS.Services.ValidateDKsAndCreditCards;


namespace MyCTS.Presentation
{
    public partial class ucCancelTicket : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite cancelar boletos seleccionando una linea,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:11/12/09 - 17-03-10
        /// Cambio:      Etiqueta</C30*1234567890/> - Aumentar otro error de PNR cedidos  , Solicito: Guillermo
        /// Autor:       Jessica Gutierrez 
        /// </summary>


        #region ======= Declaration of Variables =======

        public static bool CancelTicket;
        public static string recordLocator;
        private bool firstentrance;
        private bool existTKT;
        private bool cancelTKT;
        private bool cancelTicket;
        private bool invalidCommand;
        private string result;
        private string tktvoid;
        private string send;
        private string dk;
        private string xlmtktvoid;
        private string sendInfo = string.Empty;
        private string[] tickets = new string[100];
        private string Attribute1;
        private string sabreConcat;
        int countTicket = 1;

        int cont = 0;
        int row = 0;
        int col = 0;

        #endregion

        public ucCancelTicket()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberLine;
            this.LastControlFocus = btnAccept;

        }

        //User Control Load 
        /// <summary>
        /// Se coloca el foco en el textbox de Número de línea
        /// Se manda un comando para desplegar las lineas para ver 
        /// cual es la línea que se desea cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCancelTicket_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtNumberLine.Focus();
            SearchRemarks();
            BucleFindEndScroll();

        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!firstentrance)
            {
                if (IsValidateBusinessRules)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_T, 0, 0);
                    }

                    CopyTKTVoid();
                    CommandsSend();

                    if (!cancelTKT)
                        HideInformation();

                    cancelTKT = false;
                }
            }
            else
            {
                if (btnYes.ForeColor == Color.OrangeRed && btnYes.Visible)
                {
                    invalidCommand = true;
                    CommandsSend();
                    invalidCommand = false;
                    HideInformationOtherCancel();
                }
                else if (btnNo.ForeColor == Color.OrangeRed && btnNo.Visible)
                    HideInformationOtherCancel();
                else if (btnYesOther.ForeColor == Color.OrangeRed && btnYesOther.Visible)
                {
                    ShowInformation(false);
                    txtNumberLine.Visible = true;
                    txtNumberLine.Text = string.Empty;
                    lblNumberLine.Visible = true;
                    txtNumberLine.Focus();
                    firstentrance = false;
                }
                else if (btnNoOther.ForeColor == Color.OrangeRed && btnNoOther.Visible)
                {
                    if (!existTKT)
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    else
                    {
                        cancelTKT = true;
                        CancelAccountingLine();
                        //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED, sendInfo);
                        DialogBoxTickets dg = new DialogBoxTickets();
                        dg.ShowDialog();
                        ucCancelTicket.CancelTicket = false;
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
            }
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //{
            //    if (!existTKT)
            //        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            //    else
            //    {
            //        CancelAccountingLine();
            //        //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED, sendInfo);
            //        DialogBoxTickets dg = new DialogBoxTickets();
            //        dg.ShowDialog();
            //        ucCancelTicket.CancelTicket = false;
            //        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            //    }
            //}
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        //Change Focus all Controls
        /// <summary>
        /// Es el cambio de foco entre controles como tiene el mismo 
        /// Length se hizo un ciclo para el cambio entre cada uno de 
        /// los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberLine_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberLine.Text.Length > 1)
                btnAccept.Focus();
        }

        #region ===== Event Clic =====

        //Event Click Button Yes
        private void btnYes_Click(object sender, EventArgs e)
        {
            ChangeColorYes();
        }

        //Event Click Button No
        private void btnNo_Click(object sender, EventArgs e)
        {
            cont = cont - 1;
            ChangeColorNo();
        }

        //Event Click Button Yes
        private void btnYesOther_Click(object sender, EventArgs e)
        {
            ChangeColorYes();
        }

        //Event Clic Button No
        private void btnNoOther_Click(object sender, EventArgs e)
        {
            ChangeColorNo();
        }

        #endregion

        #region ====== Hide Information ======

        /// <summary>
        /// Oculta algunos controles
        /// </summary>
        private void HideInformation()
        {
            firstentrance = true;
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            txtNumberLine.Enabled = false;
            lblCancelTicket.Visible = true;
            btnNo.Visible = true;
            btnYes.Visible = true;
        }

        private void HideInformationOtherCancel()
        {
            btnYesOther.ForeColor = Color.OrangeRed;
            btnNoOther.ForeColor = Color.Black;
            btnNoOther.FlatAppearance.BorderColor = Color.White;
            txtNumberLine.Enabled = true;
            lblCancelTicket.Visible = false;
            btnNo.Visible = false;
            btnYes.Visible = false;
            btnNoOther.Visible = true;
            btnYesOther.Visible = true;
            lblOtherTkt.Visible = true;
            txtNumberLine.Visible = false;
            lblNumberLine.Visible = false;
        }

        private void ShowInformation(bool show)
        {
            btnNo.Visible = show;
            btnNoOther.Visible = show;
            btnYesOther.Visible = show;
            btnYes.Visible = show;
            lblOtherTkt.Visible = show;
        }

        #endregion

        #region ===== Change Tab =====

        /// <summary>
        /// El evento KeyUp se puso por que solo asi se logro controlar el 
        /// Tabindex de los botones y que pudieran hacer la opcion del enter
        /// para la función del boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ChangeColor();

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        private void btnNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ChangeColor();

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        /// <summary>
        /// Se le asigna el cambio del foco entre los controles
        /// de acuerdo a la condición especificada 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumberLine.Enabled == false)
                this.InitialControlFocus = btnYes;
            else
                this.InitialControlFocus = txtNumberLine;
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;

                if (string.IsNullOrEmpty(txtNumberLine.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLine.Focus();
                    return false;
                }
                else if (txtNumberLine.Text.Equals(zero) | txtNumberLine.Text.Equals(doublezero))
                {
                    MessageBox.Show(Resources.Reservations.NO_PERMITEN_CEROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLine.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Valida que existan boletos
        /// </summary>
        /// <returns></returns>
        private void SearchRemarks()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_T);
            }
            sabreConcat = string.Concat(result, "\n");
        }

        /// <summary>
        /// reinicializa el proceso de buscar remarks contables
        /// </summary>
        private void BucleFindEndScroll()
        {
            SendScrollCommand();
            if (!SearchEndScroll())
            {
                BucleFindEndScroll();
            }

        }

        /// <summary>
        /// Manda el comando para verificar si el record contiene mas remarks contables
        /// </summary>
        private void SendScrollCommand()
        {
            send = string.Empty;
            result = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Valida el fin del despliegue de remarks contables en MySabre
        /// </summary>
        /// <returns></returns>
        private bool SearchEndScroll()
        {
            bool endScroll = false;
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(result, "SCROLL‡", ref row, ref col);
            if (row != 0 && col >= 0)
            {
                endScroll = true;
            }
            else
            {
                sabreConcat = string.Concat(sabreConcat.Trim(),
                    "\n",
                    result,
                    "\n");
                endScroll = false;
            }
            sabreConcat = sabreConcat.Replace('‡', '\n');
            sabreConcat = sabreConcat.Trim();
            return endScroll;
        }


        /// <summary>
        /// Esta funcion se encarga de buscar y copiar el número de boleto que va a ser
        /// cancelado 
        /// </summary>
        private void CopyTKTVoid()
        {
            int lenght = 0;
            string[] sabreAnswerInfo = sabreConcat.Split(new char[] { '\n' });
            lenght = sabreAnswerInfo.Length - 1;

            for (int i = lenght; i >= 1; i--)
            {

                CommandsQik.searchResponse(sabreAnswerInfo[i], txtNumberLine.Text, ref row, ref col, 1, 1, 1, 4);
                if (row != 0 || col != 0)
                {
                    while (row != 0 || col != 0)
                    {
                        CommandsQik.CopyResponse(sabreAnswerInfo[i], ref tktvoid, row, 8, 13);
                        col = 0;
                        row = 0;
                        tickets[++cont] = tktvoid;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {

            send = Resources.Constants.COMMANDS_WV + txtNumberLine.Text;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, Resources.ErrorMessages.VOID_MSG_SENT_WITHIN_BSP_APPROVED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                cancelTicket = true;
                sendInfo = tktvoid;
                CancelTicket = true;

                if (!string.IsNullOrEmpty(tktvoid))
                    existTKT = true;

                row = 0;
                col = 0;
            }
            CommandsQik.searchResponse(result, Resources.ErrorMessages.VOID_MESSAGE_SENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                cancelTicket = true;
                sendInfo = tktvoid;
                CancelTicket = true;

                if (!string.IsNullOrEmpty(tktvoid))
                    existTKT = true;

                row = 0;
                col = 0;
            }
            CommandsQik.searchResponse(result, Resources.ErrorMessages.NUMBER_PREVIOUSLY_VOIDED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                cont = cont - 1;
                cancelTicket = true;
                MessageBox.Show(Resources.Reservations.BOLETO_CANCELADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cancelTKT = true;
                txtNumberLine.Text = string.Empty;
                txtNumberLine.Focus();
                row = 0;
                col = 0;
            }
            CommandsQik.searchResponse(result, Resources.ErrorMessages.REENT_IF, ref row, ref col);
            if (row != 0 || col != 0)
            {
                cancelTicket = true;
                if (ValidateVICACancelTicket())
                {
                    string body = Resources.BodyMailCancelTicketResources.BODY;
                    body = body.Replace("[*usuario*]", Login.NombreCompleto);
                    body = body.Replace("[*boleto*]", tickets[countTicket]);
                    countTicket++;
                    //SendEmail("adminmycts@ctsmex.com.mx", "mirera01", "MyCTS", Login.Mail, "", "Cancelación de Boleto", body, "", true);
                }
                row = 0;
                col = 0;
            }
            CommandsQik.searchResponse(result, Resources.ErrorMessages.VOID_EXCHANGE_RESTRICTED_BYCARRIER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.Reservations.BOLETO_NO_PUEDE_SER_CANCELADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                invalidCommand = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if (!cancelTicket)
            {
                cont = cont - 1;
                cancelTKT = true;
                MessageBox.Show(Resources.Reservations.OCURRIO_ERROR_CANCELAR_BOLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowInformation(false);
                txtNumberLine.Focus();
            }
            if (invalidCommand)
                CommandsAPI2.send_MessageToEmulator(string.Concat("CANCELADO"));

            cancelTicket = false;
        }


        /// <summary>
        /// Valida si el pago se realizó con tarjeta Visa o Mastercard
        /// </summary>
        /// <returns>True or False</returns>
        private bool ValidateVICACancelTicket()
        {
            string[] lines;
            send = Resources.Constants.COMMANDS_WETR_AST + txtNumberLine.Text;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            lines = result.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                row = 0; col = 0;
                CommandsQik.searchResponse(lines[i], "FOP", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = 0; col = 0;
                    CommandsQik.searchResponse(lines[i], "CASH", ref row, ref col);
                    if (row == 0 && col == 0)
                    {
                        CommandsQik.searchResponse(lines[i], "VI", ref row, ref col);
                        if (row != 0 || col != 0)
                        {
                            return true;

                        }
                        CommandsQik.searchResponse(lines[i], "CA", ref row, ref col);
                        if (row != 0 || col != 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Envía correo de notificación de cancelación
        /// </summary>
        public void SendEmail(string from, string password, string displayName, string to, string cc, string subject, string body, string document, bool isHTMLFormat)
        {
            MailMessage mail = new MailMessage();
            MailAddressCollection toSend = new MailAddressCollection();
            string[] toList = to.Split(new char[] { ';' });
            for (int j = 0; j < toList.Length; j++)
            {
                mail.To.Add(toList[j].Trim());
            }
            mail.From = new MailAddress(from, displayName);
            if (!string.IsNullOrEmpty(cc))
            {
                MailAddressCollection ccCopia = new MailAddressCollection();
                string[] ccList = cc.Split(new char[] { ';' });
                for (int i = 0; i < ccList.Length; i++)
                {
                    mail.CC.Add(ccList[i].Trim());
                }
            }
            if (!string.IsNullOrEmpty(document))
            {
                string[] documentList = document.Split(new char[] { ';' });
                Attachment documentToAdd = null;
                foreach (string doc in documentList)
                {
                    try
                    {
                        documentToAdd = new Attachment(doc);
                        mail.Attachments.Add(documentToAdd);
                    }
                    catch { }
                }
            }
            mail.Subject = subject;
            if (isHTMLFormat)
                mail.IsBodyHtml = true;
            mail.Body = body;
            try
            {
                SmtpClient smptMail = new SmtpClient("200.52.83.165");
                smptMail.Port = 25;
                int aux = from.LastIndexOf("@");
                string userName = from.Substring(0, aux);
                smptMail.Credentials = new System.Net.NetworkCredential(userName, password);
                smptMail.Send(mail);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                mail.Attachments.Dispose();
                mail.Dispose();
            }
        }

        /// <summary>
        /// Borra lineas contables
        /// </summary>
        private void CancelAccountingLine()
        {
            bool IsValid = false;
            int[] ordertickets = new int[cont + 1];

            DK();
            CommandsAPI2.send_MessageToEmulator(string.Concat("ESPERE POR FAVOR VALIDANDO DK"));
            string numTickets = string.Empty;
            List<string> sendxmltkvoidList = new List<string>();
            string ticketsSub = string.Empty;

            for (int k = 1; k <= cont; k++)
            {
                numTickets = "00";

                WsMyCTS wsServ = new WsMyCTS();
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;

                MyCTS.Entities.SetQCByAttribute1 Attribute1 = null;
                if (!string.IsNullOrEmpty(dk))
                {
                    try
                    {
                        try
                        {
                            integraAttribute = wsServ.GetAttribute(dk, Login.OrgId);
                        }
                        catch
                        {
                            integraAttribute = wsServ.GetAttribute(dk, Login.OrgId);
                        }
                    }
                    catch
                    {
                        IsValid = LocationValidationBackup();
                    }
                }
                if (integraAttribute != null)
                {
                    IsValid = true;

                    if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) &&
                        (integraAttribute.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_NO_EXISTE_LOCATION)))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) &&
                        integraAttribute.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_INACTIVE))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else
                    {
                        Attribute1 = SetQCByAttribute1BL.GetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                    }

                }

                if (integraAttribute1 != null)
                {
                    IsValid = true;

                    if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) &&
                        (integraAttribute1.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_NO_EXISTE_LOCATION)))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) &&
                        integraAttribute1.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_INACTIVE))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else
                    {
                        Attribute1 = SetQCByAttribute1BL.GetAttribute(integraAttribute1.Attribute1, integraAttribute1.Status, integraAttribute1.Status_Site);
                    }

                }

                if (IsValid)
                {
                    List<LabelXMLRemarks> listXMLRemarks =
                    LabelXMLRemarksBL.GetLabelXMLRemarks(integraAttribute.Attribute1.ToString(), "Cancellation", tickets[k]);

                    if (listXMLRemarks.Count > 0)
                    {
                        xlmtktvoid = listXMLRemarks[0].XMLFutureLabel;
                        while (!string.IsNullOrEmpty(xlmtktvoid))
                        {
                            sendxmltkvoidList.Add(xlmtktvoid);
                            break;
                        }
                    }
                }
            }

            foreach (string xmltkvoid in sendxmltkvoidList)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(xmltkvoid);
                }
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive("5H-.</TK CNL MYCTS/>");
            }
            countTicket = 1;
        }

        /// <summary>
        /// En esta funcion extrae el DK, primero se manda un comando
        /// despues se buscada una frase y si la encuentra copia el DK
        /// </summary>
        private void DK()
        {
            recordLocator = RecordLocalizer.GetRecordLocalizer();
            send = Resources.TicketEmission.Constants.COMMANDS_AST_PDK;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send, 0, 0);
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.CUSTOMER_NUMBER, ref row, ref col, 1, 2, 1, 64);
            if (row != 0 || col != 0)
            {
                dk = string.Empty;
                CommandsQik.CopyResponse(result, ref dk, row, 19, 6);
            }
        }

        /// <summary>
        /// Valida el location si el procediemiento de validacion principal falla
        /// </summary>
        private bool LocationValidationBackup()
        {
            bool IsValid = true;
            GetAndSetAttributeBackup AttributeBackup = GetAndSetAttributeBackupBL.GetAttribute(dk, Login.OrgId);
            if (AttributeBackup.Attribute1 != null)
            {
                if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                (AttributeBackup.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_NO_EXISTE_LOCATION)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }
                else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                AttributeBackup.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_INACTIVE))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }
            }
            else
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.ERROR_VALIDACION_LOCATION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                IsValid = false;
            }
            return IsValid;

        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColorYes()
        {
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;

            btnYesOther.ForeColor = Color.OrangeRed;
            btnNoOther.ForeColor = Color.Black;
            btnNoOther.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColorNo()
        {
            btnNo.ForeColor = Color.OrangeRed;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;

            btnNoOther.ForeColor = Color.OrangeRed;
            btnYesOther.ForeColor = Color.Black;
            btnYesOther.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColor()
        {
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;

            btnNoOther.ForeColor = Color.Black;
            btnNoOther.FlatAppearance.BorderColor = Color.White;
            btnYesOther.ForeColor = Color.Black;
            btnYesOther.FlatAppearance.BorderColor = Color.White;
        }

        #endregion



    }
}
