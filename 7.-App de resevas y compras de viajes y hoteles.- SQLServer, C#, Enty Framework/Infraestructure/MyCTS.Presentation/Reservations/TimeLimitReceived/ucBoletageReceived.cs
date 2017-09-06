using System;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    /// <summary>
    /// Descripcion: Permite asignar el nombre del Solicitante y Agente 
    ///              para la reservación,pertenece a Reservaciones
    /// Creación:    Diciembre 08 -Marzo 09 , Modificación:*
    /// Cambio:      Continue el flujo de Cierra Record    , Solicito Guillermo
    /// Autor:       Jessica Gutierrez 
    /// </summary>
    public partial class ucBoletageReceived : CustomUserControl
    {
        public static bool boletageReceived;
        public static bool errorER;
        private string send = string.Empty;
        private string result = string.Empty;
        private string optionSelected;
        private bool ok;
        OTATravelItinerary.OTATravelItineraryObject myObject = null;
        TextBox txt;
        public static string param6Received;
        private InterJetProcessObserver _processObserver;
        private InterJetBoletageReceivedHandler _handler;
        private LogInterJetBL _service;
        private InterJetCommandBuilder _commandBuilder;

        private InterJetBoletageReceivedHandler Handler
        {
            get
            {

                return _handler ?? (_handler = new InterJetBoletageReceivedHandler
                {
                    CurrentUserControl = this,
                    Timer = this.timer1,
                    ProgressBar = progressBar,
                    LoadingLabel = this.cerrandoLabel,
                    MainPanel = this.MainPanel,
                    ReservationEndPicture = this.pictureBoxReservation,
                    Loading = this.loadingPictureBox

                });
            }
        }

        private LogInterJetBL InterJetServiceLog
        {
            get { return _service ?? (_service = new LogInterJetBL()); }
        }

        private InterJetCommandBuilder CommandBuilder
        {
            get
            {
                return _commandBuilder ?? (_commandBuilder = new InterJetAddDINCommand
                {
                    Ticket = InterJetHelper.Ticket
                });
            }
        }

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

        public ucBoletageReceived()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSolicitorName;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Solo se pone el foco en el textbox de Nombre del Solicitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBoletageReceived_Load(object sender, EventArgs e)
        {
            if (this.Parameters == null && !ucMenuReservations.closeGroup && !ucManualRateGroup.manualRateGroup && !ucDKClient.DkClient)
            {
                ShowInformation(true);
                lbPCC.BringToFront();
            }
            else if (this.Parameters != null && ucEndReservation.EndReservation)
            {
                optionSelected = this.Parameters[0];
                ShowInformation(false);
            }
            else if (ucMenuReservations.closeGroup | ucManualRateGroup.manualRateGroup)
                ShowInformation(false);
            else if (ucDKClient.DkClient)
            {
                ucDKClient.DkClient = false;
                CommandsER();
            }
            txtSolicitorName.Focus();
        }

        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            ok = false;
            if (IsValidateBusinessRules)
                CommandsSend();
            if (ucSplitRecord.IsSplitRecord)
            {
                ucSplitRecord.IsSplitRecord = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_SPLIT_CONFIRMATION);
                return;
            }
            if (this.Parameters != null && ucEndReservation.EndReservation)
            {
                boletageReceived = true;
                param6Received = txtSolicitorName.Text;
                string[] sendInfo = new string[] { optionSelected };
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
            }
            else if (ok && !ucMenuReservations.closeGroup && !ucManualRateGroup.manualRateGroup)
            {
                param6Received = txtSolicitorName.Text;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if (ucMenuReservations.closeGroup | ucManualRateGroup.manualRateGroup)
            {
                ucMenuReservations.closeGroup = false;
                ucManualRateGroup.manualRateGroup = false;
                CommandsER();
            }

            if (ucAvailability.IsInterJetProcess)
            {
                this.Handler.CloseAndInvoicedReservation();
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
            if (ProcessObserver.HandleEvent(ref msg, keyData))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            if (this.Parameters == null || ucEndReservation.EndReservation)
            {
                if (e.KeyData == Keys.Escape)
                {
                    ucSplitRecord.IsSplitRecord = false;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbPCC.Items.Count > 0)
                {
                    lbPCC.SelectedIndex = 0;
                    lbPCC.Focus();
                }
            }
        }

        /// <summary>
        /// Es el cambio de foco entre controles como tiene el mismo 
        /// Length se hizo un ciclo para el cambio entre cada uno de 
        /// los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSolicitorName_TextChanged(object sender, EventArgs e)
        {
            if (txtSolicitorName.Text.Length > 34)
                txtPCC.Focus();
        }
        private void txtGroups_TextChanged(object sender, EventArgs e)
        {
            if (txtGroups.Text.Length > 34)
                btnAccept.Focus();
        }

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }

        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtPCC;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbPCC.Visible = false;
                txt.Focus();
            }
        }

        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtPCC;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (!string.IsNullOrEmpty(txtSolicitorName.Text) &&
                    !string.IsNullOrEmpty(txtPCC.Text) ||
                    !string.IsNullOrEmpty(txtGroups.Text) &&
                    !string.IsNullOrEmpty(txtSolicitorName.Text) ||
                    !string.IsNullOrEmpty(txtGroups.Text) &&
                    !string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESAR_SOLO_UN_DATO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSolicitorName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtSolicitorName.Text) &&
                         string.IsNullOrEmpty(txtPCC.Text) &&
                         string.IsNullOrEmpty(txtGroups.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_NOMBRE_SOLICITANTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSolicitorName.Focus();
                    return false;
                }
                else if (!string.IsNullOrEmpty(txtPCC.Text) && txtPCC.Text.Length < 4)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                    return false;
                }
                else
                {
                    ok = true;
                    return true;
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
                agent = item.Agent;
            if ((!string.IsNullOrEmpty(txtSolicitorName.Text)))
            {
                send = string.Concat(Resources.Constants.COMMANDS_6_NAME,
                    txtSolicitorName.Text + Resources.Constants.SLASH + agent);
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
            else if ((!string.IsNullOrEmpty(txtPCC.Text)))
            {
                string extract;
                string send;
                extract = txtPCC.Text;
                extract = extract.Substring(0, 4);
                send = string.Concat(Resources.Constants.COMMANDS_6CHANGE_TA_SLASH,
                    extract + Resources.Constants.INDENT + agent);
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
            else if (!string.IsNullOrEmpty(txtGroups.Text))
            {
                send = string.Concat(Resources.Constants.COMMANDS_6_NAME,
                    txtGroups.Text);
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
        }

        private void ShowInformation(bool show)
        {
            lblyieldRecord.Visible = show;
            txtPCC.Visible = show;
            lblGroups.Visible = show;
            txtGroups.Visible = show;
        }

        private void APIResponseER()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_ConcludeReservation.err_concludereservation(result);
                if (ERR_ConcludeReservation.Status)
                {
                    if (!string.IsNullOrEmpty(ERR_ConcludeReservation.CustomUserMsg))
                    {
                        errorER = true;
                        MessageBox.Show(ERR_ConcludeReservation.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                else if (ERR_ConcludeReservation.StatusDKNull)
                {
                    errorER = true;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDKCLIENT);
                }
                else if (ERR_ConcludeReservation.Command)
                {
                    errorER = false;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive(Resources.Constants.COMMANDS_N_AST_NM, 0, 1);
                    }
                    send = Resources.Constants.COMMANDS_ER;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive(send);
                    }
                    string resultAux = result.Replace("‡", "\n");
                    string[] sabreAnswerInfo = resultAux.Split(new char[] { '\n' });
                    if (sabreAnswerInfo.Length > 0 && sabreAnswerInfo[0].Length == 6 && ValidateRegularExpression.ValidatePNR(sabreAnswerInfo[0]))
                        GetValuesWebServices(sabreAnswerInfo[0]);
                }
                else if (ERR_ConcludeReservation.CommandF)
                {
                    errorER = false;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_F);
                        objCommand.SendReceive(Resources.Constants.COMMANDS_ER);
                    }
                }
                else
                    errorER = false;
            }
        }

        private void CommandsER()
        {
            send = Resources.Constants.COMMANDS_ER;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            string resultAux = result.Replace("‡", "\n");
            string[] sabreAnswerInfo = resultAux.Split(new char[] { '\n' });
            if (sabreAnswerInfo.Length > 0 && sabreAnswerInfo[0].Length == 6 && ValidateRegularExpression.ValidatePNR(sabreAnswerInfo[0]))
                GetValuesWebServices(sabreAnswerInfo[0]);
            APIResponseER();
            if (!errorER)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(Resources.Constants.COMMANDS_AST_P6);
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Llamado al servicio web que va extraer los datos del
        /// record localizador del cual se este emitiendo un boleto
        /// </summary>
        public void GetValuesWebServices(string recLoc)
        {
            try
            {
                CommandsAPI2.send_MessageToEmulator("DOCUMENTANDO RESERVA, FAVOR DE ESPERAR..........");
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
                if (myObject.PassengerTypeList.Count >= 1)
                {
                    for (int i = 0; i < myObject.PaxNumberList.Count; i++)
                        for (int j = 0; j < myObject.DepartureAirportList.Count; j++)
                        {
                            SetDetailsPNRBL.AddDetailsPNR(recLoc, myObject.DepartureAirportList[j], myObject.ArrivalAirportList[j],
                                myObject.DepartureDateTimeList[j], myObject.ArrivalDateTimeList[j], myObject.MarketingAirlineList[j], myObject.FlightNumberList[j],
                                Convert.ToDateTime(myObject.DepartureDateList[j]), myObject.AirlineRefList[j], myObject.DepartureDateList[0], myObject.Location_DK, Convert.ToDecimal(myObject.PaxNumberList[i]),
                                myObject.PassengerTypeList[i], myObject.GivenNameList[i], myObject.SurnameList[i],
                                myObject.SegmentType, myObject.FareBasis, myObject.PCC, myObject.IDGroup, ucInsertDataPassenger.MasterPNR);
                        }
                }
                else
                {
                    for (int j = 0; j < myObject.DepartureAirportList.Count; j++)
                    {
                        SetDetailsPNRBL.AddDetailsPNR(recLoc, myObject.DepartureAirportList[j], myObject.ArrivalAirportList[j],
                        myObject.DepartureDateTimeList[j], myObject.ArrivalDateTimeList[j], myObject.MarketingAirlineList[j], myObject.FlightNumberList[j],
                        Convert.ToDateTime(myObject.DepartureDateList[j]), myObject.AirlineRefList[j], myObject.DepartureDateList[0], myObject.Location_DK, Convert.ToDecimal(1.1),
                        null, null, null,
                        myObject.SegmentType, myObject.FareBasis, myObject.PCC, myObject.IDGroup, ucInsertDataPassenger.MasterPNR);
                    }
                }
                ucInsertDataPassenger.MasterPNR = string.Empty;
            }
            catch { }
        }
    }
}
