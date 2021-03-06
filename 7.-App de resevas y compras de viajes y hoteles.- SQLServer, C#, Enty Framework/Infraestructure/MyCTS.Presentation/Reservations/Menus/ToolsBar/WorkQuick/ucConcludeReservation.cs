using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation
{
    public partial class ucConcludeReservation : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite hacer el cierre del record presente,pertenece
        ///              al flujo de Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:14/Julio/09
        /// Cambio:      Ingresar nuevo Error,Manually PQ    , Solicito Guillermo
        /// Autor:       Jessica Gutierrez, Marcos Ramirez
        /// </summary>

        public static string sendPlaceQueue;
        public string send;
        private string result;
        public static string optionSelected;
        public static bool firtsValidation;
        public static bool newpnr = false;
        private string PNR;
        private string serchSegmHotels;
        private string mail = string.Empty;
        private string sixReceived;
        private string agente;

        public ucConcludeReservation()
        {

            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            InitialControlFocus = rdoCloseRecover;
            LastControlFocus = btnAccept;
        }

        private InterJetProcessObserver _processObserver;

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
            if (ProcessObserver.HandleEvent(ref msg, keyData))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        ///Si no contiene parametos primero se verifica si existe segmento de protección y se extrae el DK
        /// se le asigan el foco a Cerrar y reuperar
        /// Despues si contiene regresa conparametros se verifica las opciones a realizar
        /// deacuerdo al Coorporativo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucConcludeReservation_Load(object sender, EventArgs e)
        {
            firtsValidation = true;
            ucFirstValidations.LocatorRecord = string.Empty;
            Previousvalues();
            rdoCloseRecover.Focus();
            userControlsPreviousValues.Conlcudreservation = null;
        }
        
        /// <summary>
        /// Deacuerdo a la opcion que eligio se guarda el nombre de cada uno 
        /// de los radios esto con la finalidad de cuando regrese de otro user control
        /// se mantengan los datos anteriormente seleccionados.
        /// Despues se hace el control de calidad para todas las opciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ucRemoveRemarks.qcCTSValues = null;
                if (ucAvailability.IsInterJetProcess)
                {
                    var fromLoading = new frmPreloading(this);
                    fromLoading.Show();
                }

                string send = Resources.Constants.COMMANDS_QSORT_AST;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(send);
                }

                if (result.Contains(Resources.Constants.NONE))
                {
                    send = string.Concat(Resources.Constants.COMMANDS_QSORT_SLASH, Login.Queue);

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive(send);
                    }
                }

                PNR = RecordLocalizer.GetRecordLocalizer();
                if (string.IsNullOrEmpty(PNR))
                    newpnr = true;
                else
                    newpnr = false;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_IO);
                    APIResponseSegment();
                }

                bool validationQueue = false;

                if (rdoCloseRecover.Checked)
                    optionSelected = rdoCloseRecover.Name;
                else if (rdoClosecopyitinerary.Checked)
                    optionSelected = rdoClosecopyitinerary.Name;
                else if (rdoPlaceQueue.Checked)
                {
                    if (IsValidBusinessRules)
                    {
                        LoadParametersValues();
                        CommandsSend();
                        optionSelected = rdoPlaceQueue.Name;
                    }
                    else
                        validationQueue = true;
                }
                else if (rdoCloseSendMail.Checked)
                    optionSelected = rdoCloseSendMail.Name;
                else if (rdoCloseUpgradeRecord.Checked)
                    optionSelected = rdoCloseUpgradeRecord.Name;
                else if (rdoCloseSendMailBlackBerry.Checked)
                    optionSelected = rdoCloseSendMailBlackBerry.Name;

                if (!validationQueue)
                {
                    if (!string.IsNullOrEmpty(ucBoletageReceived.param6Received))
                        sixReceived = ucBoletageReceived.param6Received;

                    agente = Login.Firm;
                    mail = Login.Mail;
                    serchSegmHotels = string.Empty;
                    TempHotel.SearchSegmHotels = serchSegmHotels;
                    TempHotel.PNR = PNR;
                    TempHotel.Agent = agente;
                    TempHotel.Mail = mail;
                    Loader.AddToPanel(Loader.Zone.Middle, this, "ucClientQualityControls");
                }
            }
            catch (Exception err)
            {

            }
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
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        private void rdoPlaceQueue_CheckedChanged(object sender, EventArgs e)
        {
            ShowLine();
        }

        private void HideTextBox_CheckedChanged(object sender, EventArgs e)
        {
            HideLine();
        }

        #region====== Change focus all controls ======

        /// <summary>
        /// En todos estos hace el cambio entre cada uno de los controles
        /// para ir pasando el foco de acuerdo al length que se determina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQueue1_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue1.Text.Length > 2)
                txtPic1.Focus();
        }

        private void txtQueue2_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue2.Text.Length > 2)
                txtPic2.Focus();
        }

        private void txtQueue3_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue3.Text.Length > 2)
                txtPic3.Focus();
        }

        private void txtPic1_TextChanged(object sender, EventArgs e)
        {
            if (txtPic1.Text.Length > 2)
                txtPCC1.Focus();
        }

        private void txtPic2_TextChanged(object sender, EventArgs e)
        {
            if (txtPic2.Text.Length > 2)
                txtPCC2.Focus();
        }

        private void txtPic3_TextChanged(object sender, EventArgs e)
        {
            if (txtPic3.Text.Length > 2)
                txtPCC3.Focus();
        }

        private void txtPCC1_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC1.Text.Length > 3)
                txtQueue2.Focus();
        }

        private void txtPCC2_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC2.Text.Length > 3)
                txtQueue3.Focus();
        }

        private void txtPCC3_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC3.Text.Length > 3)
                btnAccept.Focus();
        }

        #endregion

        #region====== Change Tab ======

        /// <summary>
        /// Este es para que se puediera cambiar con el tab entre los
        /// controles, ya que si no se le asigna este no toma encuenta 
        /// el tab para el cambio de tabulación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoCloseRecover_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                rdoClosecopyitinerary.TabStop = true;
                rdoClosecopyitinerary.Checked = true;
            }
        }

        private void rdoClosecopyitinerary_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                rdoCloseSendMail.TabStop = true;
                rdoCloseSendMail.Checked = true;
            }
        }

        private void rdoCloseSendMail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                rdoCloseSendMail.TabStop = true;
                rdoCloseSendMail.Checked = true;
            }
        }

        private void chkShipmentOption_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                rdoCloseSendMailBlackBerry.TabStop = true;
                rdoCloseSendMailBlackBerry.Checked = true;
            }
        }

        private void rdoCloseSendMailBlackBerry_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                rdoCloseUpgradeRecord.TabStop = true;
                rdoCloseUpgradeRecord.Checked = true;
            }
        }

        private void rdoCloseUpgradeRecord_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
               rdoPlaceQueue.TabStop = true;
               rdoPlaceQueue.Checked = true;
               rdoPlaceQueue.Focus();
            }
        }

        private void rdoPlaceQueue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtQueue1.Focus();
        }

        private void btnAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                rdoCloseRecover.TabStop = true;
                rdoCloseRecover.Checked = true;
            }
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// En este se tiene que aumentar 300 dias a la fecha actual para mandar
        /// el comando con la nueva fecha y las instucciones para realizar el 
        /// segmento de protección
        /// </summary>
        private void SegmentProtection()
        {
            string datefinal = string.Empty;
            DateTime lastDate = DateTime.Now.AddDays(300);

            datefinal = lastDate.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            send = string.Format(Resources.Constants.COMMANDS_SEGMENT_PROTECTION,
                    datefinal);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_0A);
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se validan las reglas de negocio de acuerdo a las opciones
        /// seleccionadas y a los campos mandatorios.
        /// </summary>
        private bool IsValidBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtQueue1.Text) &&
                    string.IsNullOrEmpty(txtPic1.Text) &&
                    string.IsNullOrEmpty(txtQueue2.Text) &&
                    string.IsNullOrEmpty(txtPic2.Text) &&
                    string.IsNullOrEmpty(txtQueue3.Text) &&
                    string.IsNullOrEmpty(txtPic3.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_NUM_QUEUE_PIC_COD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue1.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtQueue1.Text)) &&
                                string.IsNullOrEmpty(txtPic1.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_PIC_COD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPic1.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtQueue1.Text) &&
                        (!string.IsNullOrEmpty(txtPic1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_NUM_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue1.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtQueue2.Text)) &&
                           string.IsNullOrEmpty(txtPic2.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_PIC_COD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPic2.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtQueue2.Text) &&
                        (!string.IsNullOrEmpty(txtPic2.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_NUM_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue2.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtQueue3.Text)) &&
                           string.IsNullOrEmpty(txtPic3.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_PIC_COD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPic3.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtQueue3.Text) &&
                   (!string.IsNullOrEmpty(txtPic3.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ING_NUM_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue3.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envia el comando cuando la opción elegida es 
        /// Coloar en Queue
        /// </summary>
        private void CommandsSend()
        {
            sendPlaceQueue = string.Empty;
            sendPlaceQueue=Resources.Constants.COMMANDS_QP_SLA;

            if (!string.IsNullOrEmpty(txtPCC1.Text))
                sendPlaceQueue =string.Concat(sendPlaceQueue, txtPCC1.Text);

            if (!string.IsNullOrEmpty(txtQueue1.Text) &&
               !string.IsNullOrEmpty(txtPic1.Text))
                sendPlaceQueue = string.Concat(sendPlaceQueue, txtQueue1.Text, 
                    Resources.Constants.SLASH, txtPic1.Text);

            if(!string.IsNullOrEmpty(txtPCC2.Text) ||
                !string.IsNullOrEmpty(txtQueue2.Text))
                sendPlaceQueue =string.Concat(sendPlaceQueue,Resources.Constants.CROSSLORAINE);

            if (!string.IsNullOrEmpty(txtPCC2.Text))
                sendPlaceQueue =string.Concat(sendPlaceQueue,txtPCC2.Text);

            if (!string.IsNullOrEmpty(txtQueue2.Text) &&
               !string.IsNullOrEmpty(txtPic2.Text))
                sendPlaceQueue = string.Concat(sendPlaceQueue, txtQueue2.Text,
                 Resources.Constants.SLASH, txtPic2.Text);
        }

        /// <summary>
        /// Se guardan los datos que fueron ingresados para Queues
        /// para mantener los datos al momento de regresar al user
        /// Control
        /// </summary>
        private void Previousvalues()
        {
            if (userControlsPreviousValues.Conlcudreservation != null)
            {
                txtQueue1.Text = userControlsPreviousValues.Conlcudreservation[0];
                txtPic1.Text = userControlsPreviousValues.Conlcudreservation[1];
                txtPCC1.Text = userControlsPreviousValues.Conlcudreservation[2];
                txtQueue2.Text = userControlsPreviousValues.Conlcudreservation[3];
                txtPic2.Text = userControlsPreviousValues.Conlcudreservation[4];
                txtPCC2.Text = userControlsPreviousValues.Conlcudreservation[5];
                txtQueue3.Text = userControlsPreviousValues.Conlcudreservation[6];
                txtPic3.Text = userControlsPreviousValues.Conlcudreservation[7];
                txtPCC3.Text = userControlsPreviousValues.Conlcudreservation[8];

                if (userControlsPreviousValues.Conlcudreservation[9].Equals(Resources.Constants.TRUE))
                    rdoCloseRecover.Checked = true;
                if (userControlsPreviousValues.Conlcudreservation[10].Equals(Resources.Constants.TRUE))
                    rdoClosecopyitinerary.Checked = true;
                if (userControlsPreviousValues.Conlcudreservation[11].Equals(Resources.Constants.TRUE))
                    rdoCloseSendMail.Checked = true;
                if (userControlsPreviousValues.Conlcudreservation[12].Equals(Resources.Constants.TRUE))
                    rdoCloseUpgradeRecord.Checked = true;
                if (userControlsPreviousValues.Conlcudreservation[13].Equals(Resources.Constants.TRUE))
                    rdoPlaceQueue.Checked = true;

                userControlsPreviousValues.Conlcudreservation = null;
            }
        }

        /// <summary>
        /// Se cargan los parametros que previamente fueron guardados
        /// en Queue
        /// </summary>
        private void LoadParametersValues()
        {
            string[] sendInfo = new[] {txtQueue1.Text,txtPic1.Text,
                txtPCC1.Text,txtQueue2.Text,txtPic2.Text,txtPCC2.Text,
                 txtQueue3.Text,txtPic3.Text,txtPCC3.Text,
                rdoCloseRecover.Checked.ToString(), rdoClosecopyitinerary.Checked.ToString(), 
                rdoCloseSendMail.Checked.ToString(), rdoCloseUpgradeRecord.Checked.ToString(),
                rdoPlaceQueue.Checked.ToString()};
            userControlsPreviousValues.Conlcudreservation = sendInfo;
        }

        /// <summary>
        /// Se busca si existe un Segmento de Protección
        /// </summary>
        private void APIResponseSegment()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_ConcludeReservation.err_concludereservation(result);
                if (!ERR_ConcludeReservation.Segment)
                    SegmentProtection();
            }
        }

        /// <summary>
        /// Se muestran los textbox correspondientes a 
        /// Colocar en  Queue
        /// </summary>
        private void ShowLine()
        {
            ShowLine(true);
            txtQueue1.Focus();
        }

        /// <summary>
        /// Ocualta los textbox correspondientes a
        /// Coloar en Queue
        /// </summary>
        private void HideLine()
        {
            ShowLine(false);
        }

        /// <summary>
        /// Oculta o muestra los textbox de acuerdo a
        /// la opción elegida
        /// </summary>
        /// <param name="show"></param>
        private void ShowLine(bool show)
        {
            txtQueue1.Visible = show;
            txtQueue2.Visible = show;
            txtPic1.Visible = show;
            txtPic2.Visible = show;
            txtPCC1.Visible = show;
            txtPCC2.Visible = show;
            lblQueue.Visible = show;
            lblPic.Visible = show;
            lblPCC.Visible = show;
            txtQueue1.Text = string.Empty;
            txtQueue2.Text = string.Empty;
            txtPic1.Text = string.Empty;
            txtPic2.Text = string.Empty;
            txtPCC1.Text = string.Empty;
            txtPCC2.Text = string.Empty;
        }
      
        #endregion
    }
}
