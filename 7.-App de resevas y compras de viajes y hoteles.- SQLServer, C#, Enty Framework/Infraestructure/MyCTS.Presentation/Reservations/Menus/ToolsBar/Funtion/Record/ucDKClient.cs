using System;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System.Collections;
using MyCTS.Services.ValidateDKsAndCreditCards;
using MyCTS.Services.Contracts.Volaris;

namespace MyCTS.Presentation
{
    public partial class ucDKClient : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite cambiar el DK del cliente,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:23-01-10
        /// Cambio:      Quitar el predictivio    , Solicito Memo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private bool statusNoExistDK;
        private bool statusInactive;
        private string optionSelected;
        //private TextBox txt;
        public static bool DkClient;
        private string Attribute1;
        public static string extendDescription = string.Empty;


        private InterJetProcessObserver _processObserver;

        /// <summary>
        /// Gets the process observer.
        /// </summary>
        private InterJetProcessObserver ProcessObserver
        {
            get
            {
                return _processObserver ?? (_processObserver = new InterJetProcessObserver
                {
                    UserControl = this

                });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public ucDKClient()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDK;
            this.LastControlFocus = btnAccept;
        }

        private Hashtable Session
        {
            get
            {
                if (this.Parameter != null)
                {
                    InterJetSession session = (InterJetSession)this.Parameter;
                    return session.Session;
                }
                else
                {
                    return new Hashtable();
                }


            }
        }

        private VolarisReservation Reservation
        {
            get
            {
                if (Parameter != null && Parameter is VolarisReservation)
                {
                    return (VolarisReservation)Parameter;
                }

                return null;
            }
        }

        private bool IsVolarisProcess
        {
            get { return Reservation != null; }
        }

        private int TotalPassangerInterJet
        {
            get
            {

                if (this.Session.Count > 0)
                {
                    InterJetTicket ticket = this.Session["CurrentTicket"] != null ? (InterJetTicket)this.Session["CurrentTicket"] : new InterJetTicket();
                    return ticket.Passangers.Total;
                }
                else
                {
                    return 0;
                }

            }
        }

        private int TotalPassangerInVolaris
        {

            get
            {
                if (Reservation != null)
                {
                    return Reservation.Passangers.GetTotalOfPassanger();
                }
                return 0;
            }
        }

        //User Control Load 
        /// <summary>
        /// Se coloca el foco en el textbox del DK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DKClient_Load(object sender, EventArgs e)
        {

            txtDK.Focus();
            if (this.Parameters != null)
                optionSelected = this.Parameters[0];

            if (VolarisSession.IsVolarisProcess)
            {
                this.lblNumberClientDK.Text = "Paso 6/8 - Captura del DK";
                this.backToFlightPriceDetails.Text = "<Regresar a Disponibilidad";
                if (!string.IsNullOrEmpty(VolarisSession.PrimerNivel))
                {
                    this.txtDK.Text = VolarisSession.PrimerNivel;
                }
                this.backToFlightPriceDetails.Visible = true;
            }
            else if (ucAvailability.IsInterJetProcess)
            {
                SetToolTips();
                this.lblNumberClientDK.Text = "Paso 6/8 - Captura del DK";
                if (!string.IsNullOrEmpty(ucFirstValidations.DK))
                {

                    this.txtDK.Text = ucFirstValidations.DK;
                }
                this.backToFlightPriceDetails.Visible = true;
            }
        }
        /// <summary>
        /// Sets the tool tips.
        /// </summary>
        private void SetToolTips()
        {
            var tooltip = new ToolTip();
            tooltip.SetToolTip(this.backToFlightPriceDetails, "Regresar al detalle de la cotización de vuelos".ToUpper());
            tooltip.SetToolTip(this.btnAccept, "Continuar con la captura de información de la forma de pago.".ToUpper());
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
            if (string.IsNullOrEmpty(txtDK.Text))
            {
                MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDK.Focus();
            }
            else if (txtDK.Text.Length != 6)
            {
                MessageBox.Show(Resources.Reservations.EL_DK_DEBE_SER_6_CARACTERES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDK.Focus();
            }
            else
            {
                CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.ESPERE_FAVOR_VALIDANDO_DK_INTEGRA));

                statusNoExistDK = false;
                statusInactive = false;

                WsMyCTS wsServ = new WsMyCTS();
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;

                try
                {
                    try
                    {
                        integraAttribute = wsServ.GetAttribute(txtDK.Text, Login.OrgId);
                    }
                    catch(Exception ex)
                    {
                        integraAttribute = wsServ.GetAttribute(txtDK.Text, Login.OrgId);
                    }
                }
                catch (Exception ex)
                {
                    MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 AttributeBackup = wsServ.GetAttribute(txtDK.Text, Login.OrgId);
                    if (AttributeBackup != null)
                    {
                        if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                           (AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_NO)))
                            statusNoExistDK = true;
                        else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                                AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_INACTIVO))
                            statusInactive = true;
                    }
                }
                if (integraAttribute != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute.Attribute1) && integraAttribute.Status.Contains("NO EXISTE LOCATION") || integraAttribute.Status_Site.Contains("NO EXISTE LOCATION"))
                        statusNoExistDK = true;
                    else if (!string.IsNullOrEmpty(integraAttribute.Attribute1) &&
                            integraAttribute.Status.Contains("INACTIVO") || integraAttribute.Status_Site.Contains("INACTIVO"))
                        statusInactive = true;
                    else
                    {
                        MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 tempAttribute = new MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1();
                        tempAttribute = wsServ.SetQCGetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                        Attribute1 = tempAttribute.Attribute1;
                    }
                }
                else if (integraAttribute1 != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute1.Attribute1) &&
                       (integraAttribute1.Status.Contains(Resources.Reservations.MESSAGE_NO)) || (integraAttribute1.Status_Site.Contains(Resources.Reservations.MESSAGE_NO)))
                        statusNoExistDK = true;
                    else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1) &&
                            integraAttribute1.Status.Contains("INACTIVO") || integraAttribute1.Status_Site.Contains("INACTIVO"))
                        statusInactive = true;
                    else
                    {
                        MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 tempAttribute = new MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1();
                        tempAttribute = wsServ.SetQCGetAttribute(integraAttribute1.Attribute1, integraAttribute1.Status, integraAttribute1.Status_Site);
                        Attribute1 = tempAttribute.Attribute1;
                    }
                }
                if (integraAttribute != null || integraAttribute1 != null)
                {
                    if (IsValidateBusinessRules)
                    {
                        if (ucAvailability.IsInterJetProcess || VolarisSession.IsVolarisProcess)
                        {
                            if (integraAttribute != null)
                            {
                                ucFirstValidations.Attribute1 = integraAttribute.Attribute1;

                            }
                            else
                            {

                            }

                            ChargesPerService.DKActualBajoCosto = txtDK.Text;
                            ucFirstValidations.DK = txtDK.Text;
                            activeStepsCorporativeQC.CorporativeQualityControls = null;
                            activeStepsCorporativeQC.loadQualityControlsList();
                            ucFirstValidations.CorporativeQualityControls =
                            activeStepsCorporativeQC.CorporativeQualityControls;

                            if (VolarisSession.IsVolarisProcess)
                            {
                                VolarisSession.DK = txtDK.Text;
                                if (!string.IsNullOrEmpty(Description1.Text))
                                {
                                    builtExtendedDescription();
                                }
                                Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisPaymentFormFormulario");
                            }
                            else if (ucAvailability.IsInterJetProcess)
                            {

                                ucAllQualityControls.globalPaxNumber = this.TotalPassangerInterJet;
                                ucQualitiesByPax.Pax = this.TotalPassangerInterJet;
                                LogProductivity.LogTransaction(Login.Agent, "6-Desplego Captura de DK--InterJet");

                                this.SetPassangerNumberRecord();
                                builtExtendedDescription();//verificar si se manda

                                //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPaymentForm",
                                //                                this.Parameter, null);
                                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucSeatAllocation",
                                                                this.Parameter, null);

                            }
                        }
                        else
                        {

                            CommandsSend();
                            if (this.Parameters == null && !ucBoletageReceived.errorER)
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            else if (ucBoletageReceived.errorER)
                            {
                                DkClient = true;
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED);
                            }
                            else
                            {
                                DkClient = true;
                                string[] sendInfo = new string[] { optionSelected };
                                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Resources.Reservations.NO_EXISTE_LOCATIONDK_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Gets the ticket.
        /// </summary>
        /// <returns></returns>
        private InterJetTicket GetTicket()
        {
            var ticket = this.Session["CurrentTicket"] != null ? (InterJetTicket)this.Session["CurrentTicket"] : null;

            return ticket;

        }
        /// <summary>
        /// TODO: Al crear el Passanger Number Record Verificar que pasa si esta null.
        /// </summary>
        private void SetPassangerNumberRecord()
        {
            InterJetTicket currentTicket = this.GetTicket();
            if (currentTicket != null)
            {
                currentTicket.PassangerNumberRecord.DK = this.txtDK.Text;
                currentTicket.PassangerNumberRecord.Passangers = currentTicket.Passangers;
                currentTicket.PassangerNumberRecord.Segments = currentTicket.Flights;
                this.Session["CurrentTicket"] = currentTicket;
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
                if (ucAvailability.IsInterJetProcess)
                {
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetFlightsPricesDetailsForm", this.Parameter, null);
                }
                else
                {
                    this.Parameters = null;
                    VolarisSession.Clean();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);

            if (e.KeyCode == Keys.Down)
            {
                if (lbDK.Items.Count > 0)
                {
                    lbDK.SelectedIndex = 0;
                    lbDK.Focus();
                }
            }
        }

        #region ===== old code =====

        ////Mouse Click
        ///// <summary>
        ///// Esta función es para permitir el Clic sobre el ListBox
        ///// para seleccional el item y oculata el listBox
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ListBox_MouseClick(object sender, MouseEventArgs e)
        //{
        //    ListBox listBox = (ListBox)sender;
        //    TextBox txt = (TextBox)txtDK;

        //    ListItem li = (ListItem)listBox.SelectedItem;
        //    txt.Text = li.Value;
        //    lbDK.Visible = false;
        //    txt.Focus();
        //}

        ////TextChange DK
        ///// <summary>
        ///// Esta función se encarga de hacer el llenado del ListBox
        ///// con la tabla de DK
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtDK_TextChanged(object sender, EventArgs e)
        //{
        //    //SetListBox();
        //    txt = (TextBox)sender;
        //    Common.SetListBoxConfirmDK(txt, lbDK);

        //}

        ///// <summary>
        ///// Esta función se encarga de mandar el foco hacia la opción
        ///// deseada y al elegir se oculata el ListBox
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void lbDK_KeyDown(object sender, KeyEventArgs e)
        //{
        //    ListBox ListBox = (ListBox)sender;
        //    TextBox txt = (TextBox)txtDK;

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        ListItem li = (ListItem)ListBox.SelectedItem;
        //        txt.Text = li.Value;
        //        lbDK.Visible = false;
        //        txt.Focus();
        //    }
        //}

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
                if (string.IsNullOrEmpty(txtDK.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDK.Focus();
                    return false;
                }
                if (statusNoExistDK)
                {
                    MessageBox.Show(Resources.Reservations.NO_EXISTE_LOCATIONDK_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDK.Focus();
                    return false;
                }
                else if (statusInactive)
                {
                    MessageBox.Show(Resources.Reservations.NUMERO_CLIENTE_LOCATIONDKINACTIVO_VERIFICAR_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDK.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
                //else if (statusValidDK)
                //{
                //    MessageBox.Show(Resources.Reservations.DK_NO_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    statusValidDK = false;
                //    txtDK.Focus();
                //    return false;
                //}
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send;
            send = Resources.Constants.COMMANDS_DK + txtDK.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #endregion

        private void customerDkTextBox_Properties_KeyDown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDK.Text))
            {
                if (txtDK.Text.EndsWith("990"))
                {
                    hideExtendedDescriptionFields(false);
                    Description1.Text = string.Empty;
                    Description2.Text = string.Empty;
                }
                else
                {
                    hideExtendedDescriptionFields(true);
                }
            }
        }

        private void builtExtendedDescription()
        {
            string description1 = Description1.Text;
            string description2 = Description2.Text;
            string send = string.Empty;
            if (!string.IsNullOrEmpty(description1) | (!string.IsNullOrEmpty(description2)))
            {

                send = Resources.TicketEmission.Constants.COMMANDS_FIVE_POINT;
                if (!string.IsNullOrEmpty(description1))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES01_IDENT,
                        description1);
                    if (!string.IsNullOrEmpty(description2))
                    {
                        send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ENDIT_5_DES02_INDENT,
                            description2);
                    }
                }

                else if (!string.IsNullOrEmpty(description2))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES02_INDENT,
                        description2);
                }

            }
            if (!string.IsNullOrEmpty(send))
            {
                if (VolarisSession.IsVolarisProcess)
                {
                    VolarisSession.Remarks = new VolarisRemarks();
                    VolarisSession.Remarks.Add(send);
                }
                else if (ucAvailability.IsInterJetProcess)
                {
                    extendDescription = send;
                }
            }
        }

        private void hideExtendedDescriptionFields(bool show)
        {
            container2.Visible = show;
        }

        private void backToFlightPriceDetails_Click(object sender, EventArgs e)
        {
            if (VolarisSession.IsVolarisProcess)
            {
                VolarisServiceManager cliente = new VolarisServiceManager();
                cliente.CloseReservation();
                Loader.AddToPanel(Loader.Zone.Middle, this, "ucAvailability");
            }
            else
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetFlightsPricesDetailsForm", this.Parameter, null);
            }
        }
    }
}
