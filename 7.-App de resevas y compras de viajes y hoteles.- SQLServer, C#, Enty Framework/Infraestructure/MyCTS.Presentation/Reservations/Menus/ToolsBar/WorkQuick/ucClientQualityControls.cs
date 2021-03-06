using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Linq;

namespace MyCTS.Presentation
{
    public partial class ucClientQualityControls : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar valores por parte del agente
        ///              para la creacion de remarks del cliente antes de cerrar la reservacion.
        /// Creación:    15 de abril 10, Modificación:
        /// Cambio:      
        /// Solicito:    
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private static string stringremarksclients;
        public static string stringRemarksClients
        {
            get { return stringremarksclients; }
            set { stringremarksclients = value; }
        }

        private static string clientlocation;
        public static string ClientLocation
        {
            get { return clientlocation; }
            set { clientlocation = value; }
        }

        private string remarksResult;
        private string remarksClient;
        private string messageToSend;
        private string sabreConcat;
        private string locationAnswer;
        private string location;
        private int qcNameX = 0;
        private int qcNameY = 0;
        private int qcInputX = 0;
        private int qcInputY = 0;
        private int tabIndex = 0;
        private int verticalPosition = 0;
        private bool statusParamReceived;
        private string[] labelRemarksCValues = new string[100];
        private TextBox txtSender;
        private List<QCControlsClients> dinamicQualityControlsList;
        private List<ListItem> ClientRemarkNumber = new List<ListItem>();
        private List<MyCTS.Services.ValidateDKsAndCreditCards.CatCorporativeQualityControls> CorporativeQualityControls;
        //private List<CatCorporativeQualityControls> CorporativeQualityControls;
        private List<string> DeleteRemarks = new List<string>();



        public ucClientQualityControls()
        {
            InitializeComponent();
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Establecimiento de valores iniciales para la creacion de remarks del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucClientQualityControls_Load(object sender, EventArgs e)
        {
            if (ValidateLocation)
            {
                if (SetQualityControls)
                {
                    TitleByCorporativeId();
                    ActiveQualityControls();
                    SetOptionalQualityControls();
                    LoadComboboxValues();
                    ComboBoxInitialValue();
                    AssignInitialControl();
                    InitialControlBackcolor();
                    ControlEventsAssing();
                    LoadPredictiveLists();
                    RecoverClientRemarksValues();
                }
            }
        }

        /// <summary>
        /// Reglas de negocio y asignación de valores para la creacion de remarks del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                ClientRemarksValues();
                LoadXMLClientsValues();
                string[] sendInfo = new string[] { ucConcludeReservation.optionSelected, location };
               
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
            }
        }

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



        #region===== MethodsClass =====

        /// <summary>
        /// Manda comando de despliegue de Location a MySabre
        /// </summary>
        private bool ValidateLocation
        {
            get
            {
                stringremarksclients = string.Empty;
                clientlocation = string.Empty;
                bool isValid = true;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    locationAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_PDK);
                }
                if ((!string.IsNullOrEmpty(locationAnswer)))
                {
                    ERR_ConcludeReservation.err_concludereservation(locationAnswer);

                    if (ERR_ConcludeReservation.Customer)
                    {
                        location = ERR_ConcludeReservation.CustomerNumber;
                    }
                    else if (ERR_ConcludeReservation.StatusDKNull)
                    {
                        isValid = false;
                        string[] sendInfo = new string[] { ucConcludeReservation.optionSelected };
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCDKCLIENT, sendInfo);
                    }
                }
                return isValid;
            }
        }

        private bool SetQualityControls
        {
            get 
            {
                bool IsValid = true;
                WsMyCTS wsServ = new WsMyCTS();
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;
                MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 Attribute1 = null;          


                //SetQCByAttribute1 Attribute1 = null;
                if (!string.IsNullOrEmpty(location))
                {
                    clientlocation = location;
                    try
                    {
                        try
                        {
                            integraAttribute = wsServ.GetAttribute(location, Login.OrgId);
                        }
                        catch
                        {
                            integraAttribute = wsServ.GetAttribute(location, Login.OrgId);
                        }
                    }
                    catch
                    {
                        IsValid = LocationValidationBackup();
                    }                    
                }
                if (integraAttribute != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) && (integraAttribute.Attribute1.Contains("NO EXISTE LOCATION")))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) && integraAttribute.Attribute1.Contains("INACTIVO"))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else
                    {
                        CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_QUALITY_CONTROL_VALIDATION);
                        Attribute1 = wsServ.SetQCGetAttribute(integraAttribute.Location, integraAttribute.Status, integraAttribute.Status_Site);
                        CorporativeQualityControls = wsServ.GetCorporativeQualityControls(Attribute1.Attribute1).ToList();
                    }
                }
                if (integraAttribute1 != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) && (integraAttribute.Attribute1.Contains("NO EXISTE LOCATION")))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) && integraAttribute.Attribute1.Contains("INACTIVO"))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else
                    {
                        CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_QUALITY_CONTROL_VALIDATION);
                        Attribute1 = wsServ.SetQCGetAttribute(integraAttribute1.Location, integraAttribute1.Status, integraAttribute1.Status_Site);
                        CorporativeQualityControls = wsServ.GetCorporativeQualityControls(Attribute1.Attribute1).ToList();

                    }

                }
                else if (integraAttribute == null && integraAttribute1 == null)
                {
                    IsValid = LocationValidationBackup();
                }
                if (CorporativeQualityControls.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CorporativeQualityControls[0].ReservationSendQCClient)
                        && CorporativeQualityControls[0].ReservationSendQCClient.Equals(Resources.TicketEmission.Constants.INACTIVE)
                        && IsValid)
                    {
                        IsValid = false;
                        string[] sendInfo = new string[] { ucConcludeReservation.optionSelected, location };
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                    }
                }
                return IsValid;
            }
        }


        /// <summary>
        /// Valida el location si el procediemiento de validacion principal falla
        /// </summary>
        private bool LocationValidationBackup()
        {
            bool IsValid = true;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 AttributeBackup = wsServ.GetAttribute(location, Login.OrgId);

            if (AttributeBackup.Attribute1 != null)
            {
                CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_QUALITY_CONTROL_VALIDATION);
                CorporativeQualityControls = wsServ.GetCorporativeQualityControls(AttributeBackup.Attribute1).ToList();
                if (CorporativeQualityControls.Count.Equals(0))
                {
                    if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) && (AttributeBackup.Attribute1.Contains("NO EXISTE LOCATION")))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) && (AttributeBackup.Attribute1.Contains("INACTIVO")))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                }
            }
            else
            {
                CommandsAPI2.send_MessageToEmulator("VALIDACIÓN DE LOCATION NO SATISFACTORIA");
                string[] sendInfo = new string[] { ucConcludeReservation.optionSelected, location };
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                IsValid = false;
            }
            return IsValid;

        }

        /// <summary>
        /// Establece el nombre del corporativo en el titulo de la mascarilla 
        /// </summary>
        private void TitleByCorporativeId()
        {       
            lblTitle.Text = string.Format("{0} {1} ",
                Resources.TicketEmission.Constants.LABEL_TITLE_TEXT,
                CorporativeQualityControls[0].Attribute1);
            lblQualityControls.Text = "Ingrese la Información Requerida";
        }

        /// <summary>
        /// Crea los controles necesarios dependiendo de los quality controls activos
        /// </summary>
        private void ActiveQualityControls()
        {
            qcNameX = 2;
            qcNameY = 53;
            qcInputX = 140;
            qcInputY = 50;
            tabIndex = 1;
            verticalPosition = 46;
            dinamicQualityControlsList = QCControlsClientsBL.GetQCControls(CorporativeQualityControls[0].Attribute1, Login.Firm, Login.PCC, Login.Agent);
            if (dinamicQualityControlsList.Count > 0)
            {
                if (!string.IsNullOrEmpty(dinamicQualityControlsList[28].CtrlDescription) &&
                   dinamicQualityControlsList[28].CtrlDescription != Login.Mail)
                    dinamicQualityControlsList[28].CtrlDescription = Login.Mail;
                foreach (QCControlsClients qualityControls in dinamicQualityControlsList)
                {
                    string[] QCValue = qualityControls.ActiveQCClient.Split(new char[] {'|'});
                    int index = 0;
                    if (QCValue.Length > 1)
                        index = 1;
                    if (!QCValue[index].Equals(Resources.TicketEmission.Constants.INACTIVE))
                    {
                        ListItem item = new ListItem();
                        item .Value = QCValue[0];
                        item.Text = qualityControls.CtrlName;
                        item.Text2 = qualityControls.ReservationCtrlType;
                        ClientRemarkNumber.Add(item);
                        if (!string.IsNullOrEmpty(qualityControls.ReservationCtrlType))
                        {
                            BuildControls(qualityControls.QCDescription, qcNameX, qcNameY, Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL, qualityControls.CtrlLen);
                            BuildControls(qualityControls.CtrlName, qcInputX, qcInputY, qualityControls.ReservationCtrlType, qualityControls.CtrlLen);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Establece que opciones son opcionales
        /// </summary>
        private void SetOptionalQualityControls()
        {
            if (dinamicQualityControlsList.Count > 0)
            {
                foreach (QCControlsClients qualityControls in dinamicQualityControlsList)
                {
                    string[] QCValue = qualityControls.ActiveQCClient.Split(new char[] { '|' });
                    int index = 0;
                    if (QCValue.Length > 1)
                        index = 1;
                    if (QCValue[index].Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
                    {
                        foreach (Control qcName in this.Controls)
                        {
                            if (qcName is Label)
                            {
                                if (qcName.Text.Equals(qualityControls.QCDescription))
                                {
                                    qcName.ForeColor = Color.DarkCyan;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asigna el foco y control de tabulación inicial
        /// </summary>
        private void AssignInitialControl()
        {
            int index = 0;
            bool getFocus = false;
            btnAccept.TabIndex = tabIndex + 1;
            index = btnAccept.TabIndex;
            for (int i = 1; i <= index; i++)
            {
                foreach (Control ctrl in this.Controls)
                {


                    if (ctrl.TabIndex == i && ctrl.Enabled)
                    {
                        this.InitialControlFocus = ctrl;
                        ctrl.Focus();
                        getFocus = true;
                        break;
                    }

                }
                if (getFocus)
                    break;
            }

        }

        /// <summary>
        ///Establece color de fondo del primer control en caso de que sea un Textbox
        /// </summary>
        private void InitialControlBackcolor()
        {
            if (this.InitialControlFocus is TextBox)
                this.InitialControlFocus.BackColor = Color.PaleGoldenrod;
        }


        /// <summary>
        /// Crea los controles deacuerdo al tipo establecido en la base de datos por
        /// quality control
        /// </summary>
        /// <param name="controlName">Nombre del control a crear</param>
        /// <param name="x">Posición x del control a crear dentro del user control</param>
        /// <param name="y">Posición y del control a crear dentro del user control</param>
        /// <param name="controlType">Tipo de control a crear</param>
        private void BuildControls(string controlName, int x, int y, string controlType, int lenght)
        {

            if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_COMBOBOX))
            {
                ComboBox generic = new ComboBox();
                generic.Name = controlName;
                generic.Items.Add(Resources.TicketEmission.Constants.COMBOBOX_FIRST_ITEM_TEXT);
                generic.Location = new Point(x, y);
                generic.DropDownStyle = ComboBoxStyle.DropDown;
                generic.TabIndex = tabIndex;
                generic.Width = 250;
                generic.AutoCompleteSource = AutoCompleteSource.ListItems;
                generic.AutoCompleteMode = AutoCompleteMode.Suggest;

                this.Controls.Add(generic);
                qcInputY = y + 30;
                tabIndex++;
            }

            else if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL))
            {
                Label generic = new Label();
                generic.Name = Resources.TicketEmission.Constants.LABEL_GENERIC_NAME;
                generic.TabIndex = 0;
                generic.Text = controlName;
                generic.Location = new Point(x, y);
                generic.Width = 126;
                this.Controls.Add(generic);
                qcNameY = y + 30;

                btnAccept.Location = new Point(288, verticalPosition);
                verticalPosition = qcNameY + 50;
                if (verticalPosition > this.Height)
                {
                    this.Height = this.Height + 50;
                }

            }
            else if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_TEXTBOX))
            {
                SmartTextBox generic = new SmartTextBox();
                generic.Name = controlName;
                generic.Text = string.Empty;
                generic.Location = new Point(x, y);
                generic.Height = 23;
                generic.Width = 200;
                generic.MaxLength = (!lenght.Equals(null)) ? lenght : 20;
                generic.TabIndex = tabIndex;
                generic.AllowBlankSpaces = true;
                this.Controls.Add(generic);
                qcInputY = y + 30;
                tabIndex++;
            }

            else if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_CHECKBOX))
            {
                CheckBox generic = new CheckBox();
                generic.Name = controlName;
                generic.Text = controlName;
                generic.Location = new Point(x, y);
                generic.Width = 200;
                generic.TabIndex = tabIndex;
                this.Controls.Add(generic);
                qcInputY = y + 30;
                tabIndex++;
            }
        }

        /// <summary>
        /// Carga valores iniciales en controles tipo combobox
        /// </summary>
        private void LoadComboboxValues()
        {
            if (dinamicQualityControlsList.Count > 0)
            {
                foreach (QCControlsClients qualityControl in dinamicQualityControlsList)
                {
                    foreach (Control cmbcontrol in this.Controls)
                    {
                        if (cmbcontrol is ComboBox)
                        {
                            if (qualityControl.CtrlName.Equals(cmbcontrol.Name))
                            {
                                if (!string.IsNullOrEmpty(qualityControl.CtrlCatalogues))
                                {
                                        LoadComboBoxCatalog((ComboBox)cmbcontrol, qualityControl.QCId);                                    
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Establece el valor inicial de cada combobox creado
        /// </summary>
        private void ComboBoxInitialValue()
        {
            foreach (Control cmbcontrol in this.Controls)
            {
                if (cmbcontrol is ComboBox)
                    ((ComboBox)cmbcontrol).SelectedIndex = 0;
            }
        }


        /// <summary>
        /// Asigna los eventos necesarios para cada control dinamico
        /// </summary>
        private void ControlEventsAssing()
        {

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    foreach (QCControlsClients qualityControl in dinamicQualityControlsList)
                    {
                        if (control.Name.Equals(qualityControl.CtrlName) && control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_THREE))
                        {
                            control.KeyDown += new KeyEventHandler(BackEnterUserControlPredictive_KeyDown);
                            control.TextChanged += new EventHandler(txtchargePerService_TextChanged);
                            control.Enter += new EventHandler(txtControl_Enter);
                            control.Leave += new EventHandler(txtControl_Leave);
                        }
                        else if (control.Name.Equals(qualityControl.CtrlName) && !string.IsNullOrEmpty(qualityControl.CtrlCatalogues))
                        {
                            control.KeyDown += new KeyEventHandler(BackEnterUserControlPredictive_KeyDown);
                            control.TextChanged += new EventHandler(txtClientsCatalogs_TextChanged);
                            control.Enter += new EventHandler(txtControl_Enter);
                            control.Leave += new EventHandler(txtControl_Leave);
                        }
                        else if (control.Name.Equals(qualityControl.CtrlName) && string.IsNullOrEmpty(qualityControl.CtrlCatalogues))
                        {
                            control.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                            control.Enter += new EventHandler(txtControl_Enter);
                            control.Leave += new EventHandler(txtControl_Leave);
                        }
                    }
                }

                else if (control is ComboBox)
                {
                    control.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                    control.Enter += new EventHandler(control_Enter);
                }

                else if (control is CheckBox)
                {
                    control.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                    control.Enter += new EventHandler(control_Enter);
                }
            }
        }

        /// <summary>
        /// Recupera los valores 
        /// </summary>
        private void RecoverClientRemarksValues()
        {
            remarksResult = string.Empty;
            string command = "*P5";
            remarksClient = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                remarksResult = objCommand.SendReceive(command);
            }

            if (!remarksResult.Contains("NO PSGR DATA"))
            {
                SearchEndScroll();
                RecoverRemarksValues();
            }
        }



        /// <summary>
        /// Valida el fin del despliegue de remarks contables en MySabre
        /// </summary>
        /// <returns></returns>
        private void SearchEndScroll()
        {
            int row = 0;
            int col = 0;
            string command = "MD";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                remarksClient = objCommand.SendReceive(command);
            }
            CommandsQik.searchResponse(remarksClient, "SCROLL‡", ref row, ref col);
            if (row != 0 && col >= 0)
            {
            }
            else
            {
                remarksResult = string.Concat(remarksResult,
                    "\n",
                    remarksClient);
                SearchEndScroll();
            }
         
        }


        private void RecoverRemarksValues()
        {
            if (ClientRemarkNumber.Count > 0)
            {
                statusParamReceived = true;
                List<string> foundRemarks = new List<string>();
                QCCustomRemarks customRemark = QCCustomRemarksBL.GetQCustomRemarks(CorporativeQualityControls[0].Attribute1);
                remarksResult = remarksResult.Replace("‡ ", "\n");
                string[] AnswerByLines = remarksResult.Split(new char[] { '\n' });
                foreach (ListItem remarkNum in ClientRemarkNumber)
                {
                    foreach (string line in AnswerByLines)
                    {
                        string value = string.Empty;
                        string temp = (!string.IsNullOrEmpty(customRemark.RmrkPaxIdentyfier))? customRemark.RmrkPaxIdentyfier : customRemark.RmrkValueIdentyfier;
                        string remark = string.Concat(".",
                            customRemark.RmrkInitialLabel,
                            customRemark.RmrkIdentyfier,
                            remarkNum.Value,
                            temp);
                            
                        int row = 0;
                        int col = 0;
                        CommandsQik.searchResponse(line, remark, ref row, ref col, 1, 1, 1, 20);
                        if (row > 0)
                        {

                            CommandsQik.CopyResponse(line, ref value, 1, 1, line.Length);
                            FillClientInformation(line, remarkNum.Text, customRemark.RmrkValueIdentyfier, customRemark.RmrkFinalLabel);
                            break;
                        }

                    }
                }
                DeleteRemarksNumbers();
                statusParamReceived = false;
            }
        }

        private void FillClientInformation(string remark, string controlName, string valueIdentyfier, string endLabel)
        {
            if (!string.IsNullOrEmpty(remark))
            {
                string remarkNumber = string.Empty;
                try
                {
                    remarkNumber = remark.Substring(0, 4);
                    remarkNumber = remarkNumber.Trim(new char[] { '.', ' ' });
                    DeleteRemarks.Add(remarkNumber);
                }
                catch
                {}

                string value = string.Empty;
                if (!string.IsNullOrEmpty(valueIdentyfier))
                {
                    remark = remark.Replace(valueIdentyfier, "|");
                    string[] values = remark.Split(new char[] { '|' });
                    if (values.Length > 2)
                    {
                        for (int i = 1; i < values.Length; i++)
                        {
                            value = string.Concat(value,
                                values[i]);
                        }
                    }
                    else if (values.Length == 2)
                    {
                        value = values[1];
                    }

                    if (!string.IsNullOrEmpty(value))
                    {
                        value = (!string.IsNullOrEmpty(endLabel)) ? value.Replace(endLabel, "") : value;
                        foreach (Control control in this.Controls)
                        {
                            if (control is TextBox)
                            {
                                if (control.Name.Equals(controlName))
                                {
                                    if (value.Contains(Resources.Constants.CROSSLORAINE))
                                        value = value.Replace(Resources.Constants.CROSSLORAINE, "@");
                                    control.Text = value;
                                }
                            }
                            else if (control is ComboBox)
                            {
                                bool exitingItem = false;
                                if (control.Name.Equals(controlName))
                                {
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        for (int i = 1; i <= ((ComboBox)control).Items.Count - 1; i++)
                                        {
                                            if (((ListItem)((ComboBox)control).Items[i]).Value.Equals(value))
                                            {
                                                exitingItem = true;
                                                ((ComboBox)control).SelectedIndex = i;
                                                break;
                                            }
                                        }
                                        if (!exitingItem)
                                        {
                                            ((ComboBox)control).Items.Add(value);
                                            ((ComboBox)control).SelectedIndex = ((ComboBox)control).Items.Count - 1;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                
            }
        }




        private void DeleteRemarksNumbers()
        {
            if (DeleteRemarks.Count > 0)
            {
                string send = string.Empty;
                List<int> TempNumber = new List<int>();
                foreach (string number in DeleteRemarks)
                {
                    try
                    {
                        TempNumber.Add(Convert.ToInt32(number));
                    }
                    catch { }
                }
                TempNumber.Sort();
                TempNumber.Reverse();
                foreach (int number in TempNumber)
                {
                    send = send + "5" + number.ToString().Trim() + "@Σ";
                }

                if (!string.IsNullOrEmpty(send))
                {
                    send = send.TrimEnd(new char[] { 'Σ' });
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                    }

                }
            }
        }
        /// <summary>
        /// Reglas de negocio aplicables para esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = false;
                bool existingItem = false;
                if (dinamicQualityControlsList.Count > 0)
                {
                    foreach (QCControlsClients QCcontrols in dinamicQualityControlsList)
                    {
                        string[] QCValue = QCcontrols.ActiveQCClient.Split(new char[] { '|' });
                        int index = 0;
                        if (QCValue.Length > 1)
                        index = 1;
                        if (QCValue[index].Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) &&
                            QCcontrols.CtrlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_TEXTBOX))
                        {
                            foreach (Control txtcontrol in this.Controls)
                            {
                                if (txtcontrol is TextBox)
                                {
                                    if (!isValid && QCcontrols.CtrlName.Equals(txtcontrol.Name) && string.IsNullOrEmpty(txtcontrol.Text))
                                    {
                                        string message = string.Format(Resources.TicketEmission.Constants.QC_MESSAGE_VALIDATION,
                                            QCcontrols.QCDescription.ToUpper());
                                        MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtcontrol.Focus();
                                        isValid = true;

                                    }
                                    else if (!isValid && txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_NINE) &&
                                    !string.IsNullOrEmpty(txtcontrol.Text) && !ValidateRegularExpression.ValidateEmailFormat(txtcontrol.Text))
                                    {

                                        MessageBox.Show("EL CORREO ELECTRÓNICO NO TIENE EL FORMATO CORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtcontrol.Focus();
                                        isValid = true;
                                    }


                                }
                            }
                        }
                        else if (QCValue[index].Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL) &&
                        QCcontrols.CtrlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_TEXTBOX))
                        {
                            foreach (Control txtcontrol in this.Controls)
                            {
                                if (txtcontrol is TextBox)
                                {
                                    if (!isValid && txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_THREE) &&
                                    !string.IsNullOrEmpty(txtcontrol.Text) && !ValidateRegularExpression.ValidateCharPerService(txtcontrol.Text))
                                    {

                                        MessageBox.Show("LA CANTIDAD DE CARGO POR SERVICIO DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtcontrol.Focus();
                                        isValid = true;
                                    }

                                }
                            }
                        }
                        else if (QCValue[index].Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) &&
                            QCcontrols.CtrlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_COMBOBOX))
                        {
                            foreach (Control cmbcontrol in this.Controls)
                            {
                                existingItem = false;
                                if (cmbcontrol is ComboBox)
                                {
                                    if ((!isValid && QCcontrols.CtrlName.Equals(cmbcontrol.Name) && ((ComboBox)cmbcontrol).SelectedIndex.Equals(0)))
                                    {
                                        if (cmbcontrol.Enabled)
                                        {
                                            string message = string.Format(Resources.TicketEmission.Constants.QC_MESSAGE_VALIDATION,
                                                    QCcontrols.QCDescription.ToUpper());
                                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbcontrol.Focus();
                                            isValid = true;
                                            break;
                                        }
                                    }
                                    else if ((!isValid && QCcontrols.CtrlName.Equals(cmbcontrol.Name) && string.IsNullOrEmpty(cmbcontrol.Text)))
                                    {

                                        string message = string.Format(Resources.TicketEmission.Constants.QC_MESSAGE_VALIDATION,
                                                QCcontrols.QCDescription.ToUpper());
                                        MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cmbcontrol.Focus();
                                        isValid = true;
                                        break;

                                    }
                                    else if (!isValid &&
                                        QCcontrols.CtrlName.Equals(cmbcontrol.Name) &&
                                        QCcontrols.CtrlName.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TEN) &&
                                        ((ComboBox)cmbcontrol).SelectedIndex < 0)
                                    {
                                        if (cmbcontrol.Enabled)
                                        {
                                            for (int i = 1; i <= ((ComboBox)cmbcontrol).Items.Count - 1; i++)
                                            {

                                                if (((ListItem)((ComboBox)cmbcontrol).Items[i]).Text.StartsWith(cmbcontrol.Text))
                                                {
                                                    existingItem = true;
                                                    ((ComboBox)cmbcontrol).SelectedIndex = i;
                                                    break;
                                                }
                                            }
                                            if (!existingItem)
                                            {
                                                string message = string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_QC_VALIDO,
                                                       QCcontrols.QCDescription.ToUpper());
                                                MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                cmbcontrol.Focus();
                                                isValid = true;
                                                break;
                                            }

                                        }
                                    }
                                    else if (!isValid &&
                                        QCcontrols.CtrlName.Equals(cmbcontrol.Name) &&
                                        QCcontrols.CtrlName.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_ONE) &&
                                        ((ComboBox)cmbcontrol).SelectedIndex < 0)
                                    {
                                        for (int i = 1; i <= ((ComboBox)cmbcontrol).Items.Count - 1; i++)
                                        {

                                            if (((ListItem)((ComboBox)cmbcontrol).Items[i]).Value.Equals(cmbcontrol.Text))
                                            {
                                                existingItem = true;
                                                ((ComboBox)cmbcontrol).SelectedIndex = i;
                                                break;
                                            }
                                        }
                                        if (!existingItem)
                                        {
                                            string message = string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_QC_VALIDO,
                                                   QCcontrols.QCDescription.ToUpper());
                                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbcontrol.Focus();
                                            isValid = true;
                                            break;
                                        }
                                    }
                                    else if (!isValid &&
                               QCcontrols.CtrlName.Equals(cmbcontrol.Name) &&
                                         QCcontrols.CtrlName.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_TWO) &&
                                    ((ComboBox)cmbcontrol).SelectedIndex < 0)
                                    {
                                        for (int i = 1; i <= ((ComboBox)cmbcontrol).Items.Count - 1; i++)
                                        {

                                            if (((ListItem)((ComboBox)cmbcontrol).Items[i]).Value.Equals(cmbcontrol.Text))
                                            {
                                                existingItem = true;
                                                ((ComboBox)cmbcontrol).SelectedIndex = i;
                                                break;
                                            }
                                        }
                                        if (!existingItem)
                                        {
                                            string message = string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_QC_VALIDO,
                                                   QCcontrols.QCDescription.ToUpper());
                                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbcontrol.Focus();
                                            isValid = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (isValid)
                            break;
                    }
                }

                return isValid;
            }


        }


        /// <summary>
        /// Carga de valores en variables para la creacion de remarks del cliente
        /// </summary>
        private void ClientRemarksValues()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    for (int i = 0; i < labelRemarksCValues.Length; i++)
                    {
                        if (control.Name.Equals("txtC" + Convert.ToString(i + 1)))
                        {

                            if (!string.IsNullOrEmpty(control.Text))
                            {
                                labelRemarksCValues[i] = control.Text.ToUpper();
                                InsertNewValues(control);
                            }
                            else
                                labelRemarksCValues[i] = string.Empty;                            
                        }

                    }
                }

                else if (control is ComboBox)
                {
                    if (control.Enabled)
                    {
                        for (int i = 0; i < labelRemarksCValues.Length; i++)
                        {
                            if (control.Name.Equals("cmbC" + Convert.ToString(i + 1)))
                            {
                                if (((ComboBox)control).SelectedIndex > 0 || !string.IsNullOrEmpty(((ComboBox)control).Text))
                                {
                                    string[] codevalue = ((ComboBox)control).Text.ToUpper().Split(new char[] { '-' });
                                    labelRemarksCValues[i] = codevalue[0];
                                    InsertNewValues(control);
                                }
                                else
                                {
                                    labelRemarksCValues[i] = string.Empty;
                                }                                
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(labelRemarksCValues[22]))
            {

                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(labelRemarksCValues[22]);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    labelRemarksCValues[22] = chargePerServiceList[0].Import;
                    labelRemarksCValues[22] = labelRemarksCValues[22].Replace("$", "");
                }
                else
                {
                    if (!string.IsNullOrEmpty(labelRemarksCValues[22]))
                    {
                        labelRemarksCValues[22] = labelRemarksCValues[22].Replace("$", "");
                    }
                    else
                    {
                        labelRemarksCValues[22] = string.Empty;
                    }
                }

            }
            else
            {
                labelRemarksCValues[22] = string.Empty;
            }

            if (!string.IsNullOrEmpty(labelRemarksCValues[28]))
            {
                string c29 = string.Empty;
                if (!string.IsNullOrEmpty(labelRemarksCValues[28]) &&
                    labelRemarksCValues[28] == Login.Mail)
                    c29 = labelRemarksCValues[28];
                else if (!string.IsNullOrEmpty(labelRemarksCValues[28]))
                    c29 = Login.Mail;

                c29 = c29.Replace("@", "¥");
                c29 = c29.ToUpper();
                c29 = c29.ToUpper();
                labelRemarksCValues[28] = c29;

            }
            else
            {
                labelRemarksCValues[28] = string.Empty;
            }
        }
        

        /// <summary>
        /// Crea las etiquetas customizadas por cliente para ser ingresadas posteriormente al record
        /// </summary>
        private void LoadXMLClientsValues()
        {
            if (!string.IsNullOrEmpty(CorporativeQualityControls[0].ReservationSendQCClient)
            && CorporativeQualityControls[0].ReservationSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                List<CatValuesXMLQualityControlsClients> xmlQualityControlsClients = CatValuesXMLQualityControlsClientsBL.GetValuesXMLQualityControls(
                        CorporativeQualityControls[0].Attribute1,
                        string.Empty,
                        labelRemarksCValues[0],
                        labelRemarksCValues[1],
                        labelRemarksCValues[2],
                        labelRemarksCValues[3],
                        labelRemarksCValues[4],
                        labelRemarksCValues[5],
                        labelRemarksCValues[6],
                        labelRemarksCValues[7],
                        labelRemarksCValues[8],
                        labelRemarksCValues[9],
                        labelRemarksCValues[10],
                        labelRemarksCValues[11],
                        labelRemarksCValues[12],
                        labelRemarksCValues[13],
                        labelRemarksCValues[14],
                        labelRemarksCValues[15],
                        labelRemarksCValues[16],
                        labelRemarksCValues[17],
                        labelRemarksCValues[18],
                        labelRemarksCValues[19],
                        labelRemarksCValues[20],
                        labelRemarksCValues[21],
                        labelRemarksCValues[22],
                        labelRemarksCValues[23],
                        labelRemarksCValues[24],
                        labelRemarksCValues[25],
                        labelRemarksCValues[26],
                        labelRemarksCValues[27],
                        labelRemarksCValues[28],
                        labelRemarksCValues[29],
                        labelRemarksCValues[30],
                        labelRemarksCValues[31],
                        labelRemarksCValues[32],
                        labelRemarksCValues[33],
                        labelRemarksCValues[34],
                        labelRemarksCValues[35],
                        labelRemarksCValues[36],
                        labelRemarksCValues[37],
                        labelRemarksCValues[38],
                        labelRemarksCValues[39],
                        labelRemarksCValues[40],
                        labelRemarksCValues[41],
                        labelRemarksCValues[42],
                        labelRemarksCValues[43],
                        labelRemarksCValues[44],
                        labelRemarksCValues[45],
                        labelRemarksCValues[46],
                        labelRemarksCValues[47],
                        labelRemarksCValues[48],
                        labelRemarksCValues[49],
                        labelRemarksCValues[50],
                        labelRemarksCValues[51],
                        labelRemarksCValues[52],
                        labelRemarksCValues[53],
                        labelRemarksCValues[54],
                        labelRemarksCValues[55],
                        labelRemarksCValues[56],
                        labelRemarksCValues[57],
                        labelRemarksCValues[58],
                        labelRemarksCValues[59],
                        labelRemarksCValues[60],
                        labelRemarksCValues[61],
                        labelRemarksCValues[62],
                        labelRemarksCValues[63],
                        labelRemarksCValues[64],
                        labelRemarksCValues[65],
                        labelRemarksCValues[66],
                        labelRemarksCValues[67],
                        labelRemarksCValues[68],
                        labelRemarksCValues[69],
                        labelRemarksCValues[70],
                        labelRemarksCValues[71],
                        labelRemarksCValues[72],
                        labelRemarksCValues[73],
                        labelRemarksCValues[74],
                        labelRemarksCValues[75],
                        labelRemarksCValues[76],
                        labelRemarksCValues[77],
                        labelRemarksCValues[78],
                        labelRemarksCValues[79],
                        labelRemarksCValues[80],
                        labelRemarksCValues[81],
                        labelRemarksCValues[82],
                        labelRemarksCValues[83],
                        labelRemarksCValues[84],
                        labelRemarksCValues[85],
                        labelRemarksCValues[86],
                        labelRemarksCValues[87],
                        labelRemarksCValues[88],
                        labelRemarksCValues[89],
                        labelRemarksCValues[90],
                        labelRemarksCValues[91],
                        labelRemarksCValues[92],
                        labelRemarksCValues[93],
                        labelRemarksCValues[94],
                        labelRemarksCValues[95],
                        labelRemarksCValues[96],
                        labelRemarksCValues[97],
                        labelRemarksCValues[98],
                        labelRemarksCValues[99]);


                if (xmlQualityControlsClients != null)
                {
                    if (!xmlQualityControlsClients.Count.Equals(0))
                    {
                        stringRemarksClients = string.Concat(xmlQualityControlsClients[0].C1,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C2,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C3,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C4,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C5,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C6,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C7,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C8,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C9,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C10,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C11,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C12,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C13,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C14,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C15,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C16,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C17,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C18,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C19,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C20,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C21,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C22,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C23,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C24,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C25,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C26,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C27,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C28,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C29,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C30,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C31,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C32,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C33,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C34,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C35,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C36,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C37,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C38,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C39,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C40,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C41,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C42,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C43,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C44,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C45,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C46,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C47,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C48,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C49,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C50,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C51,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C52,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C53,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C54,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C55,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C56,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C57,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C58,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C59,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C60,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C61,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C62,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C63,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C64,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C65,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C66,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C67,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C68,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C69,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C70,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C71,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C72,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C73,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C74,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C75,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C76,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C77,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C78,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C79,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C80,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C81,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C82,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C83,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C84,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C85,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C86,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C87,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C88,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C89,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C90,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C91,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C92,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C93,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C94,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C95,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C96,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C97,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C98,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C99,
                            Resources.TicketEmission.Constants.PLUS,
                            xmlQualityControlsClients[0].C100);
                    }
                }
            }
        }


        /// <summary>
        /// LLama el modal auxiliar para inserción de nuevos datos por quality control
        /// </summary>
        /// <param name="control">Control de origen</param>
        /// <param name="index">indice de la posicion del arreglo del quality control
        /// respectivo</param>
        private void CallModalInsert(Control control, int index)
        {
            frmQualityControls frm = new frmQualityControls();
            frm.formPrompt = string.Concat("INGRESA LA DESCRIPCIÓN DEL ",
                dinamicQualityControlsList[index].QCDescription.ToUpper(),
                "\n",
                "PARA EL CORPORATIVO ",
                CorporativeQualityControls[0].Attribute1);
            frm.client = CorporativeQualityControls[0].Attribute1;
            frm.remarkLabelID = string.Concat("C", Convert.ToString(index + 1));
            frm.code = control.Text;
            frm.ShowDialog();
        }
        
        /// <summary>
        /// Carga el catalogo general de valores para los quality controls aplicables por
        /// corporativo
        /// </summary>
        private void LoadPredictiveLists()
        {
            CatClientsCatalogsBL.ListClientsCatalogs = CatClientsCatalogsBL.GetCatalog_ClientsCatalogs(CorporativeQualityControls[0].Attribute1, string.Empty);
        }

        /// <summary>
        /// Inserta nuevos valores de catalogos por Quality Control
        /// </summary>
        /// <param name="control">Control de origen de la petición</param>
        private void InsertNewValues(Control control)
        {
            int remark = 0;
            try
            {
                remark = Convert.ToInt32(control.Name.Substring(4, 2));
            }
            catch
            {
                remark = Convert.ToInt32(control.Name.Substring(4, 1));
            }

            if (dinamicQualityControlsList[remark - 1].AllowInsertvalues)
            {
                string[] value = control.Text.Split(new char[] { '-' });
                string valueCode = value[0].Trim();
                List<SearchClientsCatalogs> existInList = SearchClientsCatalogsBL.GetSearchClientsCatalogs(CorporativeQualityControls[0].Attribute1, dinamicQualityControlsList[remark - 1].QCId, valueCode);
                if (!existInList.Count.Equals(0))
                {
                    if (existInList[0].Result.Equals(Resources.TicketEmission.Constants.MINUS_ONE))
                    {
                        messageToSend = string.Format(Resources.TicketEmission.Tickets.AGREGAR_NUEVO,
                            dinamicQualityControlsList[remark - 1].QCDescription,
                            "\n");
                        DialogResult yesNo = MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (yesNo.Equals(DialogResult.Yes))
                        {
                            CallModalInsert(control, remark - 1);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Carga los datos para el catalogo de ComboBox dependiendo de que quality control 
        /// esta activo
        /// </summary>
        /// <param name="cmbcontrol">control ComboBox a signar</param>
        /// <param name="QCId">etiqueta de quality control</param>
        private void LoadComboBoxCatalog(ComboBox cmbcontrol, string QCId)
        {
            List<ListItem> ClientCatalogsList = CatClientsCatalogsBL.GetCatalog_ClientsCatalogs(CorporativeQualityControls[0].Attribute1, QCId);
            bindingSource1.DataSource = ClientCatalogsList;

            cmbcontrol.DisplayMember = Resources.Constants.TEXT;
            cmbcontrol.ValueMember = Resources.Constants.VALUE;

            foreach (ListItem ClientCatalogsItem in ClientCatalogsList)
            {
                ListItem litem = new ListItem();
                if (!string.IsNullOrEmpty(ClientCatalogsItem.Text))
                {
                    litem.Text = string.Format("{0} - {1}",
                        ClientCatalogsItem.Value,
                        ClientCatalogsItem.Text2);
                }
                else
                {
                    litem.Text = ClientCatalogsItem.Value;
                }
                litem.Value = ClientCatalogsItem.Value;
                cmbcontrol.Items.Add(litem);
            }
        }

        //Busca el final del despliegue del comando *‡
        private void SearchDocumentEnd()
        {
            string result = SendMoveDownCommand();
            if (!EndScrollValidation(result))
            {
                sabreConcat = string.Concat(sabreConcat,
                    "\n",
                    result);
                SearchDocumentEnd();
            }
        }


        //Despliega mas informacion sobre MySabre
        private string SendMoveDownCommand()
        {
            string sabreAnswer = string.Empty;
            string send = Resources.TicketEmission.Constants.COMMANDS_MD;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send, 0, 0);
            }

            return sabreAnswer;
        }


        //Busca la etiqueta que indica el final del despliegue en MySabre
        private bool EndScrollValidation(string sabreAnswer)
        {
            int row = 0;
            int col = 0;
            bool IsEndScroll = false;
            CommandsQik.searchResponse(sabreAnswer, "SCROLL‡", ref row, ref col);
            if (row > 0)
            {
                IsEndScroll = true;
            }

            return IsEndScroll;
        }


        #endregion//End MethodsClass


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Regreso a mascarilla anterior al presionar la tecla ESC
        /// o continua con el flujo de emision de boleto al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {
                string[] sendInfo = new string[] { ucConcludeReservation.optionSelected, location };
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

        /// <summary>
        /// seleccion de predictivo al presionar la tecla DOWN
        /// Oculta el predictivo al presionar la tecla ESC o ingresa codigo de opcion 
        ///  seleccionada al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControlPredictive_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {
                string[] sendInfo = new string[] { ucConcludeReservation.optionSelected, location };
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

            if (e.KeyCode == Keys.Down)
            {

                if (lbPredictives.Items.Count > 0)
                {

                    lbPredictives.SelectedIndex = 0;
                    lbPredictives.Focus();
                    lbPredictives.Visible = true;
                    lbPredictives.Focus();
                }
            }
        }

        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown


        #region ====== Predictives=======


        //Evento txtCostCenter_TextChanged
        private void txtchargePerService_TextChanged(object sender, EventArgs e)
        {
            //if (!statusParamReceived)
            //{
            //    lbPredictives.Items.Clear();
            //    TextBox txt = (TextBox)sender;
            //    txtSender = txt;
            //    Common.SetListBoxPax(txt, lbPredictives);
            //}
        }



        //Evento txtClientsCatalogs_TextChanged
        private void txtClientsCatalogs_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                bool IsCatalogExist = false;
                string label = string.Empty;

                lbPredictives.Items.Clear();
                TextBox txt = (TextBox)sender;
                txtSender = txt;

                try
                {
                    label = txt.Name.Substring(3, 3);
                }
                catch
                {
                    label = txt.Name.Substring(3, 2);
                }


                foreach (ListItem item in CatClientsCatalogsBL.ListClientsCatalogs)
                {
                    if (item.Text3.Equals(label))
                    {
                        IsCatalogExist = true;
                        break;
                    }
                    else
                        IsCatalogExist = false;
                }


                if (IsCatalogExist)
                    Common.SetListClientCatalogs(txt, lbPredictives, CorporativeQualityControls[0].Attribute1, label);
                else if (label.Equals("C3"))
                    Common.SetListCostCenter(txt, lbPredictives);
            }
        }


        #endregion//End Predictive CostCenter


        #region===== Listbox Events =====

        //MouseClick LbCostCenter
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = txtSender;
            ListBox listBox = (ListBox)sender;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPredictives.Visible = false;
            lbPredictives.Items.Clear();
            txt.Focus();
        }


        //KeyDown lbCostCenter
        private void lbPredictives_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = txtSender;
            ListBox listBox = (ListBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)listBox.SelectedItem;
                txt.Text = li.Value;
                lbPredictives.Visible = false;
                txt.Focus();
                lbPredictives.Items.Clear();

            }

            if (e.KeyCode == Keys.Escape)
            {
                lbPredictives.Hide();
                lbPredictives.Items.Clear();
            }

        }



        private void hidePredictive(object sender, EventArgs e)
        {
            lbPredictives.Hide();
        }


        #endregion//End Listbox Events


        #region===== Leave and Enter Textbox Events =====

        private void txtControl_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;

        }

        private void txtControl_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.PaleGoldenrod;
            lbPredictives.Hide();

        }

        private void control_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = Color.PaleGoldenrod;
            lbPredictives.Hide();

        }

        #endregion//End Leave and Enter Textbox Events
    }

}
