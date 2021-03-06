using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucChargeService : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite ingresar el Cargo por el servicio que se le ofrece,pertenece a Emitir Boleto
        /// Creación:    5/Mayo/09 , Modificación:7/Julio/09
        /// Cambio:      Cambiar Predictivo , Solicito Eduardo
        /// Autor:       Jessica Gutierrez 
        /// </summary>


        #region ======== Declaration of variable =======



        private static string chargeperservice;
        public static string ChargePerService
        {
            get { return chargeperservice; }
            set { chargeperservice = value; }
        }
        private static string remarkpax1;
        public static string RemarkPax1
        {
            get { return remarkpax1; }
            set { remarkpax1 = value; }
        }
        private static string remarkpax2;
        public static string RemarkPax2
        {
            get { return remarkpax2; }
            set { remarkpax2 = value; }
        }
        private static string remarkpax3;
        public static string RemarkPax3
        {
            get { return remarkpax3; }
            set { remarkpax3 = value; }
        }
        private static string remarkpax4;
        public static string RemarkPax4
        {
            get { return remarkpax4; }
            set { remarkpax4 = value; }
        }
        private static string remarkpax5;
        public static string RemarkPax5
        {
            get { return remarkpax5; }
            set { remarkpax5 = value; }
        }
        private static string remarkpax6;
        public static string RemarkPax6
        {
            get { return remarkpax6; }
            set { remarkpax6 = value; }
        }
        private static string remarkpax7;
        public static string RemarkPax7
        {
            get { return remarkpax7; }
            set { remarkpax7 = value; }
        }
        private static string remarkpax8;
        public static string RemarkPax8
        {
            get { return remarkpax8; }
            set { remarkpax8 = value; }
        }
        private static string remarkpax9;
        public static string RemarkPax9
        {
            get { return remarkpax9; }
            set { remarkpax9 = value; }
        }
        private static string c23;
        public static string C23
        {
            get { return c23; }
            set { c23 = value; }
        }

        private TextBox txt = null;
        private string Passenger1;
        private string Passenger2;
        private string Passenger3;
        private string Passenger4;
        private string Passenger5;
        private string Passenger6;
        private string Passenger7;
        private string Passenger8;
        private string Passenger9;
        //private bool statusParamReceived;
        private Parameter activateFormOfPaymentCS = null;
        private Parameter activateOldRemarkCS = null;

        #endregion

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

            if (ProcessObserver.HandleEvent(ref msg, keyData))
            {
                return true;

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        public ucChargeService()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPax1;
            this.LastControlFocus = btnAccept;
        }

        //Load User Control
        /// <summary>
        /// Se busca en la base de datos si para el coorporativo esta Activa esta opción
        /// si no es asi se carga el siguiente user Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucChargeService_Load(object sender, EventArgs e)
        {
            LoadFormPaymentCodes();
            activateFormOfPaymentCS = ParameterBL.GetParameterValue("ActivateFormOfPaymentCS");
            activateOldRemarkCS = ParameterBL.GetParameterValue("ActivateOldRemarkCS");
            remarkpax1 = string.Empty;
            remarkpax2 = string.Empty;
            remarkpax3 = string.Empty;
            remarkpax4 = string.Empty;
            remarkpax5 = string.Empty;
            remarkpax6 = string.Empty;
            remarkpax7 = string.Empty;
            remarkpax8 = string.Empty;
            remarkpax9 = string.Empty;
            if (!ucMenuReservations.ChargeService)
            {
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    txtPax1.Focus();
                    hideListboxControls();
                }
                else if (ucQREX.Qrex)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);
                }
                else
                {
                    chargeperservice = string.Empty;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                }
                cleanValues();
            }
            else
            {
                txtPax1.Focus();
                hideListboxControls();
                cleanValues();
            }
        }

        private void LoadFormPaymentCodes()
        {
            List<ListItem> listFOP = CatCreditCardsCodesBL.GetFOPCTSList();

            foreach (ListItem FOPItem in listFOP)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    FOPItem.Value,
                    FOPItem.Text);
                litem.Value = FOPItem.Value;
                litem.Text2 = FOPItem.Text2;
                cmbTypeCard.Items.Add(litem);

            }
            cmbTypeCard.SelectedIndex = 0;
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
            string remarksCommand = Resources.TicketEmission.Constants.COMMANDS_5_DOT;
            string sendRemarks = string.Empty;
            string sendIntegra = string.Empty;
            int lenght = 0;

            if (!ucMenuReservations.ChargeService)
            {
                if (ucQREX.Qrex)
                {
                    if (!isValidBusinessRules())
                    {
                        commandsSend();
                        remarkIntegraValues();
                        if (!ucAvailability.IsInterJetProcess)
                        {
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);
                        }
                    }
                }
                else
                {
                    commandsSend();
                    remarkIntegraValues();
                    if (!ucAvailability.IsInterJetProcess)
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                    }
                }
            }
            else
            {
                if (!isValidBusinessRules())
                {
                    if (Convert.ToBoolean(activateFormOfPaymentCS.Values))
                    {
                        remarkIntegraValues();
                        if (!string.IsNullOrEmpty(chargeperservice))
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                if (!ucAvailability.IsInterJetProcess)
                                {
                                    objCommand.SendReceive(chargeperservice);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(c23))
                        {
                            string[] values = c23.Split(new char[] { '+' });
                            lenght = 0;
                            sendRemarks = string.Empty;
                            sendIntegra = string.Empty;
                            sendIntegra = remarksCommand;
                            string[] splitRemarks = c23.Split(new char[] { '+' });
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
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(sendIntegra))
                            {
                                sendRemarks = string.Concat(sendRemarks,
                                            sendIntegra);
                            }

                            if (!string.IsNullOrEmpty(sendRemarks))
                            {
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    if (!ucAvailability.IsInterJetProcess)
                                    {
                                        objCommand.SendReceive(sendRemarks);
                                        sendRemarks = string.Empty;
                                    }
                                }
                            }    

                        }
                    }
                    if (Convert.ToBoolean(activateOldRemarkCS.Values))
                    {
                        remarkpax1 = string.Empty;
                        remarkpax2 = string.Empty;
                        remarkpax3 = string.Empty;
                        remarkpax4 = string.Empty;
                        remarkpax5 = string.Empty;
                        remarkpax6 = string.Empty;
                        remarkpax7 = string.Empty;
                        remarkpax8 = string.Empty;
                        remarkpax9 = string.Empty;
                        remarkIntegraValues();

                        if (!string.IsNullOrEmpty(chargeperservice))
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {

                                if (!ucAvailability.IsInterJetProcess)
                                {
                                    objCommand.SendReceive(chargeperservice);
                                }

                            }
                        }
                        if (!string.IsNullOrEmpty(c23))
                        {
                            string[] values = c23.Split(new char[] { '+' });
                            lenght = 0;
                            sendRemarks = string.Empty;
                            sendIntegra = string.Empty;
                            sendIntegra = remarksCommand;
                            string[] splitRemarks = c23.Split(new char[] { '+' });
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
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(sendIntegra))
                            {
                                sendRemarks = string.Concat(sendRemarks,
                                            sendIntegra);
                            }

                            if (!string.IsNullOrEmpty(sendRemarks))
                            {
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    if (!ucAvailability.IsInterJetProcess)
                                    {
                                        objCommand.SendReceive(sendRemarks);
                                        sendRemarks = string.Empty;
                                    }

                                }
                            }

                        }


                        if (!ucAvailability.IsInterJetProcess)
                        {
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            ucMenuReservations.ChargeService = false;
                        }
                    }

                }

                if (ucAvailability.IsInterJetProcess)
                {
                    _remarks = sendRemarks;


                    try
                    {
                        //TODO: Charge of service para interjet es lo que se seguira en el flujo.
                        //var fromPreloading = new frmPreloading(this);
                        //fromPreloading.Show();
                        this.Handler.FinishReservation();

                    }
                    catch (Exception exception)
                    {

                    }
                }
                else 
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    ucMenuReservations.ChargeService = false;
                }
            }


        }





        /// <summary>
        /// 
        /// </summary>
        private InterJetBillEmissionFormHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetBillEmissionFormHandler Handler
        {
            get
            {
                this._handler = new InterJetBillEmissionFormHandler
                {
                    CurrentUserControl = this,
                    ProgressBar = gradProg1,
                    WaitingLabel = this.cotizandoLabel,
                    Timer = this.timer1,
                    MainPanel = this.panel1,
                    Loading = this.loadingPictureBox,
                    EndReservationPictureBox = this.pictureBoxReservation
                };
                return this._handler;
            }
        }

        private static string _remarks;
        public static string Remarks
        {
            get
            {
                return _remarks;
            }
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

        private InterJetTicket CurrentTicket
        {
            get
            {

                if (this.Session.Count > 0)
                {
                    InterJetTicket ticket = (InterJetTicket)this.Session["CurrentTicket"];
                    return ticket;
                }
                else
                {

                    return new InterJetTicket();
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

            if (e.KeyData == Keys.Escape)
            {
                remarkpax1 = string.Empty;
                remarkpax2 = string.Empty;
                remarkpax3 = string.Empty;
                remarkpax4 = string.Empty;
                remarkpax5 = string.Empty;
                remarkpax6 = string.Empty;
                remarkpax7 = string.Empty;
                remarkpax8 = string.Empty;
                remarkpax9 = string.Empty;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }

            if (e.KeyCode == Keys.Down)
            {

                if (!ucAvailability.IsInterJetProcess)
                {
                    if (lbPax.Items.Count > 0)
                    {
                        lbPax.SelectedIndex = 0;
                        lbPax.Focus();
                        lbPax.Visible = true;
                        lbPax.Focus();
                    }
                }
            }
        }

        #region ===== methodsClass =====

        /// <summary>
        /// Solo se limpian los TextBox
        /// </summary>
        private void cleanValues()
        {
            txtPax1.Text = string.Empty;
            txtPax2.Text = string.Empty;
            txtPax3.Text = string.Empty;
            txtPax4.Text = string.Empty;
            txtPax5.Text = string.Empty;
            txtPax6.Text = string.Empty;
            txtPax7.Text = string.Empty;
            txtPax8.Text = string.Empty;
            txtPax9.Text = string.Empty;
            c23 = string.Empty;
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        public void commandsSend()
        {
            string send = string.Empty;
            if (!string.IsNullOrEmpty(txtPax1.Text))
            {

                Passenger1 = Resources.TicketEmission.Constants.COMMANDS_5_CS01_INDENT + txtPax1.Text;
            }
            if (!string.IsNullOrEmpty(txtPax2.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text))
                {
                    Passenger2 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS02_INDENT + txtPax2.Text;
                }
                else
                {
                    Passenger2 = Resources.TicketEmission.Constants.COMMANDS_5_CS02_INDENT + txtPax2.Text;
                }

            }

            if (!string.IsNullOrEmpty(txtPax3.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text))
                {
                    Passenger3 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS03_INDENT + txtPax3.Text;
                }
                else
                {
                    Passenger3 = Resources.TicketEmission.Constants.COMMANDS_5_CS03_INDENT + txtPax3.Text;
                }

            }

            if (!string.IsNullOrEmpty(txtPax4.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text) |
                    !string.IsNullOrEmpty(txtPax3.Text))
                {
                    Passenger4 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS04_INDENT + txtPax4.Text;
                }
                else
                {
                    Passenger4 = Resources.TicketEmission.Constants.COMMANDS_5_CS04_INDENT + txtPax4.Text;
                }

            }


            if (!string.IsNullOrEmpty(txtPax5.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text) |
                    !string.IsNullOrEmpty(txtPax3.Text) |
                    !string.IsNullOrEmpty(txtPax4.Text))
                {
                    Passenger5 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS05_INDENT + txtPax5.Text;
                }
                else
                {
                    Passenger5 = Resources.TicketEmission.Constants.COMMANDS_5_CS05_INDENT + txtPax5.Text;
                }

            }


            if (!string.IsNullOrEmpty(txtPax6.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text) |
                    !string.IsNullOrEmpty(txtPax3.Text) |
                    !string.IsNullOrEmpty(txtPax4.Text) |
                    !string.IsNullOrEmpty(txtPax5.Text))
                {
                    Passenger6 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS06_INDENT + txtPax6.Text;
                }
                else
                {
                    Passenger6 = Resources.TicketEmission.Constants.COMMANDS_5_CS06_INDENT + txtPax6.Text;
                }

            }

            if (!string.IsNullOrEmpty(txtPax7.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text) |
                    !string.IsNullOrEmpty(txtPax3.Text) |
                    !string.IsNullOrEmpty(txtPax4.Text) |
                    !string.IsNullOrEmpty(txtPax5.Text) |
                   !string.IsNullOrEmpty(txtPax6.Text))
                {
                    Passenger7 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS07_INDENT + txtPax7.Text;
                }
                else
                {
                    Passenger7 = Resources.TicketEmission.Constants.COMMANDS_5_CS07_INDENT + txtPax7.Text;
                }

            }

            if (!string.IsNullOrEmpty(txtPax8.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text) |
                    !string.IsNullOrEmpty(txtPax3.Text) |
                    !string.IsNullOrEmpty(txtPax4.Text) |
                    !string.IsNullOrEmpty(txtPax5.Text) |
                    !string.IsNullOrEmpty(txtPax6.Text) |
                    !string.IsNullOrEmpty(txtPax7.Text))
                {
                    Passenger8 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS08_INDENT + txtPax8.Text;
                }
                else
                {
                    Passenger8 = Resources.TicketEmission.Constants.COMMANDS_5_CS08_INDENT + txtPax8.Text;
                }

            }


            if (!string.IsNullOrEmpty(txtPax9.Text))
            {
                if (!string.IsNullOrEmpty(txtPax1.Text) |
                    !string.IsNullOrEmpty(txtPax2.Text) |
                    !string.IsNullOrEmpty(txtPax3.Text) |
                    !string.IsNullOrEmpty(txtPax4.Text) |
                    !string.IsNullOrEmpty(txtPax5.Text) |
                    !string.IsNullOrEmpty(txtPax6.Text) |
                    !string.IsNullOrEmpty(txtPax7.Text) |
                    !string.IsNullOrEmpty(txtPax8.Text))
                {
                    Passenger9 = Resources.TicketEmission.Constants.END_ITEM + Resources.TicketEmission.Constants.COMMANDS_5_CS09_INDENT + txtPax9.Text;
                }
                else
                {
                    Passenger9 = Resources.TicketEmission.Constants.COMMANDS_5_CS09_INDENT + txtPax9.Text;
                }

            }



            send = Passenger1 + Passenger2 + Passenger3 + Passenger4 + Passenger5 + Passenger6 + Passenger7 + Passenger8 + Passenger9;
            send = send.Trim();
            if (!string.IsNullOrEmpty(send))
            {
                chargeperservice = send;
            }
            else
            {
                chargeperservice = string.Empty;
            }






        }

        /// <summary>
        /// Se manda el comando de acuerdo a los parametros ingresado y
        /// se concatena cada uno de los datos ingresados
        /// </summary>
        private void remarkIntegraValues()
        {
            string passenger1 = string.Empty;
            string passenger2 = string.Empty;
            string passenger3 = string.Empty;
            string passenger4 = string.Empty;
            string passenger5 = string.Empty;
            string passenger6 = string.Empty;
            string passenger7 = string.Empty;
            string passenger8 = string.Empty;
            string passenger9 = string.Empty;
            string remarkCTS = string.Empty;
            if (cmbTypeCard.SelectedIndex > 0)
            {
                if (((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CA"))
                {
                    remarkCTS = string.Format("-{0}",
                            ((ListItem)cmbTypeCard.SelectedItem).Text2);
                }
                else
                {
                    remarkCTS = string.Format("-{0}-{1}",
                            ((ListItem)cmbTypeCard.SelectedItem).Text2,
                            txtNumberCardCTS.Text);
                }
            }

            if (!string.IsNullOrEmpty(txtPax1.Text) && txtPax1.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax1.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger1 = string.Concat("</C23-01*", chargePerServiceList[0].Import, remarkpax1, "/>+");
                }
                else
                {
                    passenger1 = string.Concat("</C23-01*", txtPax1.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax2.Text) && txtPax2.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax2.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger2 = string.Concat("</C23-02*", chargePerServiceList[0].Import, remarkpax2, "/>+");
                }
                else
                {
                    passenger2 = string.Concat("</C23-02*", txtPax2.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax3.Text) && txtPax3.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax3.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger3 = string.Concat("</C23-03*", chargePerServiceList[0].Import, remarkpax3, "/>+");
                }
                else
                {
                    passenger3 = string.Concat("</C23-03*", txtPax3.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax4.Text) && txtPax4.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax4.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger4 = string.Concat("</C23-04*", chargePerServiceList[0].Import, remarkpax4, "/>+");
                }
                else
                {
                    passenger4 = string.Concat("</C23-04*", txtPax4.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax5.Text) && txtPax5.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax5.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger5 = string.Concat("</C23-05*", chargePerServiceList[0].Import, remarkpax5, "/>+");
                }
                else
                {
                    passenger5 = string.Concat("</C23-05*", txtPax5.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax6.Text) && txtPax6.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax6.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger6 = string.Concat("</C23-06*", chargePerServiceList[0].Import, remarkpax6, "/>+");
                }
                else
                {
                    passenger6 = string.Concat("</C23-06*", txtPax6.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax7.Text) && txtPax7.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax7.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger7 = string.Concat("</C23-07*", chargePerServiceList[0].Import, remarkpax7, "/>+");
                }
                else
                {
                    passenger7 = string.Concat("</C23-07*", txtPax7.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax8.Text) && txtPax8.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax8.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger8 = string.Concat("</C23-08*", chargePerServiceList[0].Import, remarkpax8, "/>+");
                }
                else
                {
                    passenger8 = string.Concat("</C23-08*", txtPax8.Text, remarkCTS, "/>+");
                }
            }

            if (!string.IsNullOrEmpty(txtPax9.Text) && txtPax9.Text.Length > 2)
            {
                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(txtPax9.Text);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    passenger9 = string.Concat("</C23-09*", chargePerServiceList[0].Import, remarkpax9, "/>+");
                }
                else
                {
                    passenger9 = string.Concat("</C23-09*", txtPax9.Text, remarkCTS, "/>+");
                }
            }

            c23 = string.Concat(passenger1,
                passenger2,
                passenger3,
                passenger4,
                passenger5,
                passenger6,
                passenger7,
                passenger8,
                passenger9);
            c23 = c23.Replace("$", "");
            remarkpax1 = string.Empty;
            remarkpax2 = string.Empty;
            remarkpax3 = string.Empty;
            remarkpax4 = string.Empty;
            remarkpax5 = string.Empty;
            remarkpax6 = string.Empty;
            remarkpax7 = string.Empty;
            remarkpax8 = string.Empty;
            remarkpax9 = string.Empty;
        }

        /// <summary>
        /// Reglas de negocio aplicables para esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool isValidBusinessRules()
        {
            bool isValid = false;

            foreach (Control txtcontrol in this.Controls)
            {
                if (txtcontrol is TextBox)
                {
                    if (!string.IsNullOrEmpty(txtcontrol.Text) &&
                        !ValidateRegularExpression.ValidateCharPerService(txtcontrol.Text))
                    {
                        MessageBox.Show("LA CANTIDAD DE CARGO POR SERVICIO DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcontrol.Focus();
                        return true;
                    }
                }                
                
            }
            if (cmbTypeCard.SelectedIndex.Equals(0) && (!string.IsNullOrEmpty(txtPax1.Text) ||
                    !string.IsNullOrEmpty(txtPax1.Text) ||
                    !string.IsNullOrEmpty(txtPax2.Text) ||
                    !string.IsNullOrEmpty(txtPax3.Text) ||
                    !string.IsNullOrEmpty(txtPax4.Text) ||
                    !string.IsNullOrEmpty(txtPax5.Text) ||
                    !string.IsNullOrEmpty(txtPax6.Text) ||
                    !string.IsNullOrEmpty(txtPax7.Text) ||
                    !string.IsNullOrEmpty(txtPax8.Text) ||
                    !string.IsNullOrEmpty(txtPax9.Text)
                    ))
            {
                MessageBox.Show("REQUIERE INGRESAR LA FORMA DE PAGO DEL CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTypeCard.Focus();
                isValid = true;
            }
            else if (!validateCardNumber())
            {
                isValid = true;
            }
            #region Comentarios anteriores
            //if (Convert.ToBoolean(activateFormOfPaymentCS.Values))
            //{
            //    if (!string.IsNullOrEmpty(txtPax1.Text) && string.IsNullOrEmpty(remarkpax1))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 1", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("1", "2");
            //        frm.Show();
            //        frm.BringToFront();

            //    }
            //    else if (!string.IsNullOrEmpty(txtPax2.Text) && string.IsNullOrEmpty(remarkpax2))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 2", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("2", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax3.Text) && string.IsNullOrEmpty(remarkpax3))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 3", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("3", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax4.Text) && string.IsNullOrEmpty(remarkpax4))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 4", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("4", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax5.Text) && string.IsNullOrEmpty(remarkpax5))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 5", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("5", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax6.Text) && string.IsNullOrEmpty(remarkpax6))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 6", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("6", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax7.Text) && string.IsNullOrEmpty(remarkpax7))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 7", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("7", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax8.Text) && string.IsNullOrEmpty(remarkpax8))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 8", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("8", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else if (!string.IsNullOrEmpty(txtPax9.Text) && string.IsNullOrEmpty(remarkpax9))
            //    {
            //        MessageBox.Show("DEBDE INDICAR LA FORMA DE PAGO DEL PASAJERO 9", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        frmFormOfPaypemt frm = new frmFormOfPaypemt("9", "2");
            //        frm.Show();
            //        frm.BringToFront();
            //    }
            //    else
            //        isValid = false;
            //}      
            #endregion
            return isValid;
        }

        private bool validateCardNumber()
        {
            if (string.IsNullOrEmpty(txtNumberCardCTS.Text)
                    && cmbTypeCard.SelectedIndex > 0)
            {
                if (!((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CA"))
                {
                    MessageBox.Show("REQUIERE INGRESAR EL NÚMERO DE TARJETA O CUENTA DEL CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    return false;
                }
                else if ((((ListItem)cmbTypeCard.SelectedItem).Value.Equals("TR") ||
                    ((ListItem)cmbTypeCard.SelectedItem).Value.Equals("CH")) && txtNumberCardCTS.Text.Length != 4)
                {
                    MessageBox.Show("El número de la tarjeta debe ser de 4 digitos. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return true;
            }
        }
        #endregion

        #region===== listbox Controls Events=====

        /// <summary>
        /// Carga la lista de Cargos por servicios si le dan enter 
        /// o si le dan Esc el ListBox desaparece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbPax_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (!ucAvailability.IsInterJetProcess)
                {
                    lbPax.Visible = false;
                    txt.Focus();
                }
            }
        }

        //txtPax Leave
        private void txtPax_Leave(object sender, EventArgs e)
        {
            if (!ucAvailability.IsInterJetProcess)
            {
                if (lbPax.Items.Count > 0)
                {
                    lbPax.Visible = true;
                }
            }
        }

        //Mouse Click
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!ucAvailability.IsInterJetProcess)
            {
                ListBox listBox = (ListBox) sender;
                ListItem li = (ListItem) listBox.SelectedItem;
                txt.Text = li.Value;
                lbPax.Visible = false;
                txt.Focus();
            }
        }

        //LbPax Leave
        private void lbPax_Leave(object sender, EventArgs e)
        {
            if (!ucAvailability.IsInterJetProcess)
            {
                lbPax.Visible = false;
            }
        }

        //Hide Listbox controls when ucAvailability is loaded
        private void hideListboxControls()
        {
            //statusParamReceived = false;
            if (!ucAvailability.IsInterJetProcess)
            {
                lbPax.BringToFront();
                lbPax.Visible = false;
            }
        }



        #endregion//End lbControls events

        private void txtPax1_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax1.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("1", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax2.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("2", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax3_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax3.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("3", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax4_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax4.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("4", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax5_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax5.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("5", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax6_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax6.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("6", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax7_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax7.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("7", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax8_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax8.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("8", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }

        private void txtPax9_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(activateFormOfPaymentCS.Values) && ValidateRegularExpression.ValidateTwoDecimalNumbers(txtPax9.Text))
            {
                //frmFormOfPaypemt frm = new frmFormOfPaypemt("9", "2");
                //frm.Show();
                //frm.BringToFront();
            }
        }


        public string ResultRemarkForInterJet
        {
            get
            {
                commandsSend();
                remarkIntegraValues();
                return C23;
            }
        }

        private void cmbTypeCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeCard.SelectedIndex > 0)
            {
                ListItem item = (ListItem)cmbTypeCard.SelectedItem;
                if (item.Value.Equals("CASH"))
                {
                    txtNumberCardCTS.Text = string.Empty;
                    txtNumberCardCTS.Visible = false;
                    lblCardNumberCTS.Visible = false;
                    btnShowCTS.Visible = false;
                }
                else if (item.Value.Equals("TR") || item.Value.Equals("CH"))
                {
                    btnShowCTS.Visible = false;
                    txtNumberCardCTS.MaxLength = 4;
                    lblCardNumberCTS.Text = "Número de cuenta";
                    lblCardNumberCTS.Visible = true;
                    OracleConnection oracle = new OracleConnection();
                    txtNumberCardCTS.Text = oracle.GetTranferCheckNumber(ucFirstValidations.dk);
                    txtNumberCardCTS.Visible = true;
                }
                else
                {
                    btnShowCTS.Visible = true;
                    lblCardNumberCTS.Text = "Número de tarjeta";
                    txtNumberCardCTS.Visible = true;
                    lblCardNumberCTS.Visible = true;
                    txtNumberCardCTS.MaxLength = 16;
                }
            }
        }

        private void cmbTypeCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            else if (e.KeyData == Keys.Escape)
            {
                remarkpax1 = string.Empty;
                remarkpax2 = string.Empty;
                remarkpax3 = string.Empty;
                remarkpax4 = string.Empty;
                remarkpax5 = string.Empty;
                remarkpax6 = string.Empty;
                remarkpax7 = string.Empty;
                remarkpax8 = string.Empty;
                remarkpax9 = string.Empty;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        private void txtCardNumberCTS_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNumberCardCTS.Text))
                {
                    string creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCardCTS.Text);
                    if (!string.IsNullOrEmpty(creditCard))
                    {
                        MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCardCTS.Text = string.Empty;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar tarjeta. Reintente");
                txtNumberCardCTS.Text = string.Empty;
            }
        }

        private void btnShowCTS_Click(object sender, EventArgs e)
        {
            ShowCreditCard(1);
            btnShowCTS.Visible = false;
        }

        private void ShowCreditCard(int indexControlSelector)
        {
            if (ucFirstValidations.CreditCardsFirstLevel.Count > 0 || ucFirstValidations.CreditCardsSecondLevel.Count > 0)
            {
                frmProfilesCreditCards frm = new frmProfilesCreditCards(ucFirstValidations.CreditCardsFirstLevel, ucFirstValidations.CreditCardsSecondLevel, this.Controls, indexControlSelector);
                frm.ShowDialog();
            }
        }

    }
}
