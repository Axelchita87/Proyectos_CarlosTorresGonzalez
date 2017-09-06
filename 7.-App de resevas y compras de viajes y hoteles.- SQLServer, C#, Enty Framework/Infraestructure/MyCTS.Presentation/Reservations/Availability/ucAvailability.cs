using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Utils;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System.Collections;
using MyCTS.Presentation.Reservations.Availability;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder;
using MyCTS.Services.Contracts.Volaris;

using MyCTS.Presentation.Reservations.Availability.Volaris.VolarisFlow;


namespace MyCTS.Presentation
{
    public partial class ucAvailability : CustomUserControl, IAvailabilityView
    {
        /// <summary>
        /// Descripción: User Control que permite desplegar los vuelos disponibles
        ///              deacuerdo a una fecha, origen y destino con algunos parametros adicionales.
        ///              Pertenece al flujo de reservaciones de la aplicación.
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private string sabreAnswer;
        private string connections;
        private string hours;
        private string exitArrival;
        private string date;
        private string origin;
        private string destination;
        private string airline;
        private string send;
        private string classOfService;
        private string directFlights;
        private string ShortCuts;
        private bool statusShortCuts;
        private bool statusDate;
        private bool statusSameAirline;
        private bool statusParamReceived;
        private TextBox txt;
        public static bool IsInitial;

        public InterJetTicket Ticket
        {
            get;
            set;
        }

        private AvailabiltyPresenter _presenter;
        private AvailabiltyPresenter Presenter
        {
            get
            {
                return _presenter ?? (_presenter = new AvailabiltyPresenter
                                                       {
                                                           View = this,
                                                           Repository = new AvailabilityRepository()

                                                       });
            }
        }

        #region Propiedades Para InterJet

        /// <summary>
        /// Obtiene la referencia hacia el checkbox de interjet.
        /// Rodrigo Fernandez 14/Sep/2011
        /// </summary>
        private CheckBox InterJetCheckBox
        {
            get
            {

                return this.interjetCheckBox;
            }
        }
        /// <summary>
        /// Obtiene la referencia hacia el combox box que indica cuantos pasajeros adultos tendra la reservacion.
        /// Rodrigo Fernandez 14/Sep/2011
        /// </summary>
        private System.Windows.Forms.ComboBox AdultPassangerInterJetCombox
        {
            get
            {
                return new System.Windows.Forms.ComboBox();
            }
        }
        /// <summary>
        /// Obtiene la referencia hacia el combox box que indica cuantos pasajeros menores tendra la reservacion
        /// Rodrigo Fernández 14/Sep/2011
        /// </summary>
        private System.Windows.Forms.ComboBox ChildPassangersInterjetCombox
        {
            get
            {
                return new System.Windows.Forms.ComboBox();
            }

        }


        /// <summary>
        /// Obtiene la referencia hacia el combo box que indica cuantos pasajeros infantes tendra la reservacion.
        /// Rodrigo Fernández Novelo  14/sep/2011
        /// </summary>
        private System.Windows.Forms.ComboBox InFantPassangerInterJetComboBox
        {
            get
            {

                return new System.Windows.Forms.ComboBox();
            }
        }
        /// <summary>
        /// Obtiene la refeencia hacia el combo box que indica cuantos pasajeros adultos mayores tendra la reservacion.
        /// </summary>
        private System.Windows.Forms.ComboBox SeniorPassangersInterJetComboBox
        {
            get
            {
                return new System.Windows.Forms.ComboBox();

            }
        }

        /// <summary>
        /// Obtiene la refencia hacia el combox box que indica sí es un viaje sencillo.
        /// Rodrigo Fernández 14/sep/2011
        /// </summary>
        private RadioButton OneWayTripRadioButton
        {
            get
            {

                return new RadioButton();
            }
        }

        /// <summary>
        /// Obtiene una referencia hacia el combo box que indica sí es un viaje redondo.
        /// </summary>
        private RadioButton RoundTripRadionButton
        {
            get
            {

                return this.roundTripRadioButton;
            }
        }

        /// <summary>
        /// Obtiene una referencia hacia el smart text box que contiene la fecha de regreso.
        /// </summary>
        private SmartTextBox ReturnDateRoundTripSmartTextBox
        {
            get
            {
                return new SmartTextBox();
            }
        }

        /// <summary>
        /// Obtiene una referencia hacia el label indicando el texto de la fecha de regreso.
        /// </summary>
        private Label ReturnDateInterJetLabel
        {
            get
            {
                return new Label();

            }
        }
        /// <summary>
        /// Obtiene la referencia hacia el calendario seleccionado para la fecha de regreso.
        /// </summary>
        private MonthCalendar ReturnDateCalendarInterJet
        {
            get
            {
                return new MonthCalendar();

            }
        }

        /// <summary>
        /// Obtiene la referncia hacia la imagen del calendario para la fecha de regreso.
        /// </summary>
        private PictureBox ReturnCalendarInterJetPictureBox
        {
            get
            {
                return new PictureBox();
            }
        }

        /// <summary>
        /// Indica sí checkbox de interjet ha sido seleccionado.
        /// Rodrigo Fernández 14/Sep/2011
        /// </summary>
        private bool IsInterJetCheckBoxSelected
        {
            get
            {
                return this.InterJetCheckBox.Checked;

            }
        }


        /// <summary>
        /// Indica sí se selecciono un vuelo redondo.
        /// </summary>
        private bool IsARoundTripViaInterJet
        {
            get
            {

                return this.RoundTripRadionButton.Checked;

            }
        }

        private Hashtable Session
        {
            get
            {

                InterJetSession session = (InterJetSession)this.Parameter;
                if (session != null)
                {
                    return session.Session;
                }
                return new Hashtable();

            }
        }




        #endregion

        public ucAvailability()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = departureTime;
            this.LastControlFocus = btnAccept;

        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is inter jet process.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is inter jet process; otherwise, <c>false</c>.
        /// </value>
        public static bool IsInterJetProcess
        {
            get;
            set;
        }

        /// <summary>
        /// Carga de la mascarilla de "Disponibilidad y venta Aérea"
        /// con sus valores iniciales
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucAvailability_Load(object sender, EventArgs e)
        {
            ListTaxesInterjet.TotalRound = 0;
            ListTaxesInterjet.TotalPay = 0;
            ListTaxesInterjet.ClearTaxIntejer();
            PriceTotalResponseInterjet.Clean();

            if (!string.IsNullOrEmpty(VolarisSession.Signature))
            {
                VolarisServiceManager cliente = new VolarisServiceManager();
                cliente.CloseReservation();
            }
            CostumerAccountInterJet.Clean();

            VolarisServiceManager.ciclo = false;
            VolarisServiceManager.dispVolaris = new List<Services.APIVolaris.VueloDisponible>();
            VolarisServiceManager.volarisVuelos = new List<VueloDisponibleMyCTS>();
            VolarisSession.Clean();
            ucRemoveRemarks.qcCTSValues = null;
            
            ErrorController.RegisterErrorWithControl(ErrorCode.TooMannyPassangers, adultComboBox);
            ErrorController.RegisterErrorWithControl(ErrorCode.TooManyInfants, infantComboBox);
            ErrorController.RegisterErrorWithControl(ErrorCode.NoPassangers, adultComboBox);
            ErrorController.RegisterErrorWithControl(ErrorCode.DepartureDateIsLessThanToday, departureTime);
            ErrorController.RegisterErrorWithControl(ErrorCode.ReturningDateIsBiggerThanReturningDate, returningDate);
            ErrorController.RegisterErrorWithControl(ErrorCode.IsRoundTripAndNoReturningDate, returningDate);
            ErrorController.RegisterErrorWithControl(ErrorCode.NoDepartureStation, txtOrigin);
            ErrorController.RegisterErrorWithControl(ErrorCode.NoArrivalStation, txtDestination);
            ErrorController.RegisterErrorWithControl(ErrorCode.IncorrecDepartureStation, txtOrigin);
            ErrorController.RegisterErrorWithControl(ErrorCode.IncorrectArrivalStation, txtDestination);
            ErrorController.RegisterErrorWithControl(ErrorCode.SameDepartureAndArrivalStation, txtOrigin);
            if (CatStars2ndLevelBL.ListStars2ndLevel.Any())
            {
                CatStars2ndLevelBL.ListStars2ndLevel.Clear();
            }
            ToolTipper.SetToolTip(InterJetCheckBox, "SELECCIONE PARA REALIZAR UNA BUSQUEDA SOBRE AEROLINEAS DE BAJO COSTO.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(singleTripRadioButton, "SELECCION SI DESEA BUSCAR VUELOS SENCILLOS.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(roundTripRadioButton, "seleccione sí desea buscar vuelos redondos.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(departureTime, "seleccione la fecha de salida.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(returningDate, "seleccione la fecha de regreso.", ToolTipIconType.Information);

            ToolTipper.SetToolTip(txtOrigin, "seleccione la cuidad de salida.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(txtDestination, "seleccione la cuidad de llegada.", ToolTipIconType.Information);

            ToolTipper.SetToolTip(adultComboBox, "seleccione el numero de los pasajeros adultos.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(infantComboBox, "seleccione el numero los pasajeros infantes", ToolTipIconType.Information);
            ToolTipper.SetToolTip(seniorComboBox, "seleccione el numero los pasajeros adultos mayores.", ToolTipIconType.Information);
            ToolTipper.SetToolTip(childComboBox, "seleccione el numero los pasajeros menores.", ToolTipIconType.Information);


            //TODO: InterJet Migration - Remover esta condicional cuando se acaben las pruebas piloto.
            if (!AgentCanSeeFullFunctionality)
            {
                roundTripRadioButton.Visible = false;
            }

            FillLowCostDropDown();

            SetToolTipForInterJet();
            CalendarStateBack();
            HideListboxControls();
            FillClassOfService();
            ParametersReceived();
            this.FillInterJetDropDownList();
            EnableLowCostAirline(false);
            this.DisableInterJetControls();
            IsInterJetProcess = false;
            if (this.Session["IsNewAvailability"] != null)
            {

                this.FillControlsWithCurrentAvailabilityOptions();
                EnableLowCostAirline(true);

            }
            else
            {
                ucAllQualityControls.globalPaxNumber = 0;
                ucQualitiesByPax.Pax = 0;
                InterJetHelper.DestroyTicket();
                ServiceManager.EndSession();
                ucAvailability.IsInterJetProcess = false;
                ucMenuReservations.EnabledMenu = true;
                ucAllQualityControls.globalPaxNumber = 0;
                ucAllQualityControls.counter = 0;
                ucAllQualityControls.chargePerService.Clear();
                ucAllQualityControls.remarksIntegra.Clear();
                ucAllQualityControls.passengerPositionValues.Clear();
                ucAllQualityControls.Origin = string.Empty;
                ucAllQualityControls.BusinessUnit = string.Empty;
                ucAllQualityControls.TicketsJustifications = string.Empty;
                ucAllQualityControls.workerNumberArray.Clear();
                ucTicketEmissionBuildCommand.commandSent = false;
                ucTicketsEmissionInstructions.OSI = string.Empty;
                userControlsPreviousValues.TicketsEmissionInstructionsParameters = null;
                ucQualitiesByPax.Passengers = string.Empty;
                ucQualitiesByPax.sabreConcat = string.Empty;
                ucFirstValidations.Attribute1 = null;
                ucFirstValidations.DK = null;
                ucInterJetPaymentForm.IsClientCard = false;
                ucInterJetPaymentForm.IsCTSCard = false;
                CleanucComparisonRates();
            }
            Parameter parameterExternalAva = ParameterBL.GetParameterValue("ExternalAva");
            if (parameterExternalAva.Values == "1")
            {
                kayakCheckBox.Checked = true;
                kayakCheckBox.Enabled = false;
            }
        }

        private void CleanucComparisonRates()
        {
            ucComparisonRates.rate_ConImp_Low_D = string.Empty;
            ucComparisonRates.rate_ConImp_Low_ND = string.Empty;
            ucComparisonRates.rate_ConImp_Busi = string.Empty;
            ucComparisonRates.rate_ConImp_Espe = string.Empty;
            ucComparisonRates.rate_ConImp_Stan = string.Empty;
            ucComparisonRates.rate_SinImp_Low_D = string.Empty;
            ucComparisonRates.rate_SinImp_Low_ND = string.Empty;
            ucComparisonRates.rate_SinImp_Busi = string.Empty;
            ucComparisonRates.rate_SinImp_Espe = string.Empty;
            ucComparisonRates.rate_SinImp_Stan = string.Empty;
        }

        private InterJetServiceManager _serviceManager;

        /// <summary>
        /// Gets the service manager.
        /// </summary>
        private InterJetServiceManager ServiceManager
        {

            get { return _serviceManager ?? (_serviceManager = new InterJetServiceManager()); }
        }

        private string DateSelected
        {
            get { return this.departureTime.DateTime.ToString("ddMMM", new CultureInfo("en-US")).ToUpper(); }
            set
            {
                this.departureTime.Text = value.ToUpper();
                departureTime.DateTime = DateTime.Parse(value);
            }
        }

        /// <summary>
        /// Fills the controls with current availability options.
        /// </summary>
        private void FillControlsWithCurrentAvailabilityOptions()
        {
            this.InterJetCheckBox.Checked = true;
            var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];
            if (userInput != null)
            {
                this.AdultsPassangers = userInput.AdultsPassangers;
                this.SeniorsPassangers = userInput.SeniorsPassangers;
                this.ChildrenPassangers = userInput.ChildsPassangers;
                this.InfantPassangers = userInput.InfantsPassangers;
                //this.DateSelected = userInput.BeginDate.ToString("ddMMM", new CultureInfo("en-US"));
                this.departureTime.DateTime = userInput.BeginDate;
                //this.monthCalendar1.SetDate(userInput.BeginDate);

            }

        }

        /// <summary>
        /// 
        /// </summary>
        private AvailabilityToolTipper _toolTipper;

        /// <summary>
        /// Gets the tool tipper.
        /// </summary>
        private AvailabilityToolTipper ToolTipper
        {
            get { return _toolTipper ?? (_toolTipper = new AvailabilityToolTipper()); }
        }

        /// <summary>
        /// 
        /// </summary>
        private AvailabilityErrorController _errorController;
        /// <summary>
        /// Gets the error controller.
        /// </summary>
        private AvailabilityErrorController ErrorController
        {
            get
            {
                return _errorController ?? (_errorController = new AvailabilityErrorController
                                                                   {

                                                                   });
            }
        }

        //private const string KayakUrl = "http://www.kayak.com/flights/{0}/{1}/";
        private const string KayakUrl = "https://www.google.com/flights/#search;f={0};t={1};d={2}|https://www.google.com/flights/#search;f={0};t={1};d={2};mc=p";
        /// <summary>
         /// 
        /// Funciones de la mascarilla "Disponibilidad y venta Aérea"
        /// al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        /// 
        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            if (kayakCheckBox.Checked)
            {
                //var selectedDate = departureTime.DateTime.ToString("yyyy-MM-dd");
                //var itinerary = string.Format("{0}-{1}", txtOrigin.Text, txtDestination.Text).ToUpper();
                //System.Diagnostics.Process.Start("IEXPLORE.EXE", string.Format(KayakUrl, itinerary, selectedDate));
                var selectedDate = departureTime.DateTime.ToString("yyyy-MM-dd");
                /*var itinerary = string.Format("{0}-{1}", txtOrigin.Text, txtDestination.Text).ToUpper();
                System.Diagnostics.Process.Start("IEXPLORE.EXE", string.Format(KayakUrl, itinerary, selectedDate));
                 **/
                if (KayakUrl.Contains("|"))
                {
                    string[] url = KayakUrl.Split(new char[] { '|' });
                    foreach (string linkUrl in url)
                    {
                        System.Diagnostics.Process.Start("IEXPLORE.EXE", string.Format(linkUrl, txtOrigin.Text, txtDestination.Text, selectedDate));

                    }
                }
                else
                {
                    System.Diagnostics.Process.Start("IEXPLORE.EXE", string.Format(KayakUrl, txtOrigin.Text, txtDestination.Text, selectedDate));
                }
            }
            if (InterJetCheckBox.Checked)
            {
                try
                {

                    LogProductivity.LogTransaction(Login.Agent, "Desplego disponibilidad para lineas de bajo costo.");
                    //TODO: InterJet Migration --Remover esto cuando se acaben las pruebas piloto.
                    
                    if (ValidateItata())
                    {
                        if (!string.IsNullOrEmpty(txtEmail.Text))
                        {
                            CostumerAccountInterJet.Email = txtEmail.Text;
                            CostumerAccountInterJet.Password = txtPassword.Text;
                            ClientUserInterjetBL.GetClientesUserInterjet(CostumerAccountInterJet.Email);
                            Continue();
                        }
                        else
                        {
                            Continue();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para realizar venta de vuelos de Bajo Costo, es necesario contar con una IATA dentro del PCC, de lo contrario emúlate a matriz con el formato AAA3L64 y llama de nuevo el proceso.");
                    }
                }
                catch (Exception exception)
                {
                    ErrorController.HandleError(exception);
                }
            }
            else
            {

                LaunchDefaultBehavior();
            }
        }


        private void Continue()
        {
            if (AgentCanSeeFullFunctionality)
            {
                Presenter.SearchFlights();
            }
            else
            {
                AvailabilityCommandsSend();
                IsInterJetProcess = true;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetAvailabilityOfFlights", this.GetUserInputInInterJetSession(), null);
            }
        }

        private bool ValidateItata()
        {
            bool validate = true;
            var comunnicator = new VolarisAPICommunicator();
            const string displayPCCCommand = "*S";
            string response = comunnicator.SendCommand(displayPCCCommand);
            string currentPcc = GetCurrentPCC(response);
            string TAcommand = string.Format("W/TA*{0}", currentPcc);
            comunnicator.SendCommand(TAcommand);
            const string lookForActivePccCommand = "MD/AUTO VAL";
            response = comunnicator.SendCommand(lookForActivePccCommand);
            if (response.Contains("AUTO VAL - OFF"))
            {
                validate = false;
            }
            return validate;
        }

        private string GetCurrentPCC(string response)
        {
            if (!string.IsNullOrEmpty(response))
            {

                return response.Substring(0, 4);
            }
            return string.Empty;

        }

        private void LaunchDefaultBehavior()
        {

            try
            {


                if (!IsValidBusinessRules)
                {
                    AvailabilityCommandsSend();
                    APIResponse();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Common.EndManualCommandsTransactions();
        }

        /// <summary>
        /// Selecciona hora por default al dar click en el combobox
        /// "horas"
        /// </summary>
        /// <param name="sender">cmbHours</param>
        /// <param name="e"></param>
        private void cmbHours_DropDown(object sender, EventArgs e)
        {
            cmbHours.SelectedIndex = 7;
        }

        #region ==== MethodsClass =====

        /// <summary>
        /// Escode el calendario grafico
        /// </summary>
        private void CalendarStateBack()
        {
            //monthCalendar1.BackColor = GetCalendarColor;
            //monthCalendar1.BackColor = GetCalendarColor;
            //monthCalendar1.Visible = false;
            //monthCalendar1.SendToBack();
        }


        /// <summary>
        /// No permite el despliegue de predictivo cuando se
        /// carga la mascarilla con parametros
        /// </summary>
        private void HideListboxControls()
        {
            statusParamReceived = false;
        }


        /// <summary>
        /// Llenado del combobox de clase de servicio
        /// con datos provenientes de la base de datos
        /// </summary>
        private void FillClassOfService()
        {
            List<AirLinesClass> listAirLinesClass = AirLinesClassBL.GetCatAirLinesClass();
            bindingSource1.DataSource = listAirLinesClass;

            foreach (AirLinesClass airelineclassItem in listAirLinesClass)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    airelineclassItem.CatAirLinClaID,
                    airelineclassItem.CatAirLinClaName);
                litem.Value = airelineclassItem.CatAirLinClaID;
                cmbClassOfService.Items.Add(litem);
            }
        }


        /// <summary>
        /// Asignacion de valores previos a la mascarilla provenientes
        /// de user controls posteriores cuando se presiona la tecla ESC en ellos
        /// </summary>
        private void ParametersReceived()
        {
            if (this.Parameters != null)
            {
                statusParamReceived = true;
                if (this.Parameters.Length > 2)
                {
                    txtOrigin.Text = this.Parameters[0];
                    txtDestination.Text = this.Parameters[1];
                    DateSelected = this.Parameters[2];
                    cmbHours.SelectedIndex = Convert.ToInt32(this.Parameters[3]);
                    cmbExitArrival.SelectedIndex = Convert.ToInt32(this.Parameters[4]);
                    txtAirLine1.Text = this.Parameters[5];
                    txtAirLine2.Text = this.Parameters[6];
                    txtAirLine3.Text = this.Parameters[7];
                    txtAirLine4.Text = this.Parameters[8];
                    txtAirLine5.Text = this.Parameters[9];
                    txtAirLine6.Text = this.Parameters[10];
                    if (this.Parameters[11].Equals(Resources.Constants.TRUE))
                        chkExclude.Checked = true;
                    else
                        chkExclude.Checked = false;
                    cmbClassOfService.SelectedIndex = Convert.ToInt32(this.Parameters[12]);
                    txtConection.Text = this.Parameters[13];
                    if (this.Parameters[14].Equals(Resources.Constants.TRUE))
                        chkDirectFlights.Checked = true;
                    else
                        chkDirectFlights.Checked = false;
                    if (this.Parameters[15].Equals(Resources.Constants.TRUE))
                        chkShortcuts.Checked = true;
                    else
                        chkShortcuts.Checked = false;
                }
                else
                {
                    txtDestination.Text = this.Parameters[0];
                    txtOrigin.Text = this.Parameters[1];
                }
            }
            statusParamReceived = false;
            txtOrigin.Focus();

        }


        /// <summary>
        /// Reglas de negocio correspondientes la pantalla de "Disponibilidad y venta aérea"
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                string messageToSend;
                bool isValid = true;
                bool airlinesCodeNotEquals;
                airlinesCodeNotEquals = true;
               
                if ((string.IsNullOrEmpty(DateSelected)) ||
                    (string.IsNullOrEmpty(txtOrigin.Text)) ||
                    (string.IsNullOrEmpty(txtDestination.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ORIGEN_FECHA_DEST, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(DateSelected))
                    {
                        departureTime.Focus();
                    }



                    else if (string.IsNullOrEmpty(txtOrigin.Text))
                        txtOrigin.Focus();
                    else if (string.IsNullOrEmpty(txtDestination.Text))
                        txtDestination.Focus();
                    airlinesCodeNotEquals = false;
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(DateSelected))
                {
                    messageToSend = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    airlinesCodeNotEquals = false;
                }
                else if (statusDate)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_SELEC_MENOR_ACTUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ;
                    airlinesCodeNotEquals = false;
                    statusDate = false;
                }
                else if ((!string.IsNullOrEmpty(txtOrigin.Text)) && (txtOrigin.Text.Length != 3))
                {
                    MessageBox.Show(Resources.Reservations.COD_CUIDAD_ORIGEN_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOrigin.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtDestination.Text)) && (txtDestination.Text.Length != 3))
                {
                    MessageBox.Show(Resources.Reservations.COD_CUIDAD_DESTINO_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDestination.Focus();
                }
                else if ((string.IsNullOrEmpty(cmbHours.Text)) &&
                        (!string.IsNullOrEmpty(cmbExitArrival.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_HORA_LLEGADA_SALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbHours.Focus();
                    airlinesCodeNotEquals = false;
                }
                else if ((cmbHours.SelectedIndex > 0) &&
               (!(cmbExitArrival.SelectedIndex > 0)))
                {
                    MessageBox.Show(Resources.Reservations.IND_HORA_SALIDA_LLEGADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbExitArrival.Focus();
                    airlinesCodeNotEquals = false;
                }
                else if (airlinesCodeNotEquals)
                {
                    AirlinesNotEquals();
                    if (statusSameAirline)
                    {
                        MessageBox.Show(Resources.Reservations.NO_PER_COD_AEREOLINEA_REPETIDOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        statusSameAirline = false;
                        if (!string.IsNullOrEmpty(txtAirLine1.Text))
                            txtAirLine1.Focus();
                        else if (!string.IsNullOrEmpty(txtAirLine2.Text))
                            txtAirLine2.Focus();
                        else if (!string.IsNullOrEmpty(txtAirLine3.Text))
                            txtAirLine3.Focus();
                        else if (!string.IsNullOrEmpty(txtAirLine4.Text))
                            txtAirLine4.Focus();
                        else if (!string.IsNullOrEmpty(txtAirLine5.Text))
                            txtAirLine5.Focus();
                        else if (!string.IsNullOrEmpty(txtAirLine6.Text))
                            txtAirLine6.Focus();
                    }
                    else if ((!string.IsNullOrEmpty(txtAirLine1.Text)) && (txtAirLine1.Text.Length != 2))
                    {
                        MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAirLine1.Focus();
                    }
                    else if ((!string.IsNullOrEmpty(txtAirLine2.Text)) && (txtAirLine2.Text.Length != 2))
                    {
                        MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAirLine2.Focus();
                    }
                    else if ((!string.IsNullOrEmpty(txtAirLine3.Text)) && (txtAirLine3.Text.Length != 2))
                    {
                        MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAirLine3.Focus();
                    }
                    else if ((!string.IsNullOrEmpty(txtAirLine4.Text)) && (txtAirLine4.Text.Length != 2))
                    {
                        MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAirLine4.Focus();
                    }
                    else if ((!string.IsNullOrEmpty(txtAirLine5.Text)) && (txtAirLine5.Text.Length != 2))
                    {
                        MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAirLine5.Focus();
                    }
                    else if ((!string.IsNullOrEmpty(txtAirLine6.Text)) && (txtAirLine6.Text.Length != 2))
                    {
                        MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAirLine6.Focus();
                    }
                    else
                    {
                        if (((cmbHours.SelectedIndex < 0) ||
                        (!cmbExitArrival.Text.Equals(Resources.Constants.SALIDA))) &&
                        (!string.IsNullOrEmpty(txtConection.Text)))
                        {
                            MessageBox.Show(Resources.Reservations.CONEXIONES_REQ_HORA_SALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (cmbHours.SelectedIndex < 0)
                                cmbHours.Focus();
                        }
                        else if ((!string.IsNullOrEmpty(txtConection.Text)) && (chkDirectFlights.Checked))
                        {
                            MessageBox.Show(Resources.Reservations.DEBES_SELEC_VUELOS_DIREC_O_CONEXIONES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkDirectFlights.Focus();
                        }
                        else if ((chkDirectFlights.Checked) && (chkShortcuts.Checked))
                        {
                            MessageBox.Show(Resources.Reservations.VUELOS_DIREC_NO_COM_ACCESO_DIRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkShortcuts.Focus();
                        }
                        else if ((string.IsNullOrEmpty(txtAirLine1.Text)) && (chkShortcuts.Checked))
                        {
                            MessageBox.Show(Resources.Reservations.ACCESO_DIRECTO_REQ_AEREOLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAirLine1.Focus();
                        }
                        else if ((!string.IsNullOrEmpty(txtConection.Text)) && (txtConection.Text.Length != 3))
                        {
                            MessageBox.Show(Resources.Reservations.COD_CUIDAD_CONEXION_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtConection.Focus();
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        /// <summary>
        /// Armado y envio de comando a MySabre
        /// </summary>
        private void AvailabilityCommandsSend()
        {

            date = DateSelected;
            origin = txtOrigin.Text;
            destination = txtDestination.Text;
            exitArrival = (cmbExitArrival.SelectedIndex == 2) ? Resources.Constants.SLASH : string.Empty;
            hours = string.Empty;
            if ((cmbHours.SelectedIndex > 0))
            {
                hours = cmbHours.Text;
                hours = Regex.Replace(hours, @"[^\w\.@¥-]", "");
            }

            airline = string.Empty;
            if ((!string.IsNullOrEmpty(txtAirLine1.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine2.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine3.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine4.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine5.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine6.Text)))
            {
                if (chkExclude.Checked)
                {
                    airline = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_AST,
                        txtAirLine1.Text,
                        txtAirLine2.Text,
                        txtAirLine3.Text,
                        txtAirLine4.Text,
                        txtAirLine5.Text,
                        txtAirLine6.Text);
                }
                else
                {
                    airline = string.Concat(Resources.Constants.CROSSLORAINE,
                        txtAirLine1.Text,
                        txtAirLine2.Text,
                        txtAirLine3.Text,
                        txtAirLine4.Text,
                        txtAirLine5.Text,
                        txtAirLine6.Text);
                }
                if (statusShortCuts)
                {
                    airline = txtAirLine1.Text;
                }
            }

            classOfService = (string.IsNullOrEmpty(cmbClassOfService.Text)) ? string.Empty : Resources.Constants.INDENT + ((ListItem)cmbClassOfService.SelectedItem).Value;
            connections = (!string.IsNullOrEmpty(txtConection.Text)) ? txtConection.Text : string.Empty;
            directFlights = (chkDirectFlights.Checked) ? Resources.Constants.COMMANDS_SLA_D : string.Empty;
            ShortCuts = (chkShortcuts.Checked) ? Resources.Constants.CHANGE : string.Empty;
            send = string.Concat(Resources.Constants.AVAILABILITY,
                date,
                origin,
                destination,
                exitArrival,
                hours,
                connections,
                classOfService,
                directFlights,
                ShortCuts,
                airline);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

        }


        /// <summary>
        /// Armado y envio de comando a MySabre
        /// </summary>
        /// <param name="_date">The _date.</param>
        /// <param name="_origin">The _origin.</param>
        /// <param name="_destination">The _destination.</param>
        private void AvailabilityCommandsSend(string _date, string _origin, string _destination)
        {

            date = _date.ToUpper();
            origin = _origin.ToUpper();
            destination = _destination.ToUpper();
            exitArrival = (cmbExitArrival.SelectedIndex == 2) ? Resources.Constants.SLASH : string.Empty;
            hours = string.Empty;
            if ((cmbHours.SelectedIndex > 0))
            {
                hours = cmbHours.Text;
                hours = Regex.Replace(hours, @"[^\w\.@¥-]", "");
            }

            airline = string.Empty;
            if ((!string.IsNullOrEmpty(txtAirLine1.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine2.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine3.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine4.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine5.Text)) ||
                (!string.IsNullOrEmpty(txtAirLine6.Text)))
            {
                if (chkExclude.Checked)
                {
                    airline = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_AST,
                        txtAirLine1.Text,
                        txtAirLine2.Text,
                        txtAirLine3.Text,
                        txtAirLine4.Text,
                        txtAirLine5.Text,
                        txtAirLine6.Text);
                }
                else
                {
                    airline = string.Concat(Resources.Constants.CROSSLORAINE,
                        txtAirLine1.Text,
                        txtAirLine2.Text,
                        txtAirLine3.Text,
                        txtAirLine4.Text,
                        txtAirLine5.Text,
                        txtAirLine6.Text);
                }
                if (statusShortCuts)
                {
                    airline = txtAirLine1.Text;
                }
            }

            classOfService = (string.IsNullOrEmpty(cmbClassOfService.Text)) ? string.Empty : Resources.Constants.INDENT + ((ListItem)cmbClassOfService.SelectedItem).Value;
            connections = (!string.IsNullOrEmpty(txtConection.Text)) ? txtConection.Text : string.Empty;
            directFlights = (chkDirectFlights.Checked) ? Resources.Constants.COMMANDS_SLA_D : string.Empty;
            ShortCuts = (chkShortcuts.Checked) ? Resources.Constants.CHANGE : string.Empty;
            send = string.Concat(Resources.Constants.AVAILABILITY,
                date,
                origin,
                destination,
                exitArrival,
                hours,
                connections,
                classOfService,
                directFlights,
                ShortCuts,
                airline);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

        }


        private void SetToolTipForInterJet()
        {

            //var tooltip = new ToolTip();
            //tooltip.SetToolTip(this.interjetCheckBox, "Seleccione la opción sí desea buscar vuelos de interjet".ToUpper());
            //tooltip.SetToolTip(this.AdultPassangerInterJetCombox, "Seleccione el numero de pasajeros adultos".ToUpper());
            //tooltip.SetToolTip(this.SeniorPassangersInterJetComboBox, "Seleccione el numero de pasajeros adultos mayores".ToUpper());

            //tooltip.SetToolTip(this.ChildPassangersInterjetCombox, "Seleccione el numero de pasajeros menores".ToUpper());
            //tooltip.SetToolTip(this.InFantPassangerInterJetComboBox, "Seleccione el numero de pasajeros infantes".ToUpper());

        }


        public static bool AgentCanSeeFullFunctionality
        {

            get
            {

                return true;


            }
        }


        /// <summary>
        /// Validación de posibles errores en la respuesta de MySabre
        /// </summary>
        private void APIResponse()
        {
            if (this.IsInterJetCheckBoxSelected)
            {

                //IsInterJetProcess = true;
                //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetAvailabilityOfFlights", this.GetUserInputInInterJetSession(), null);
            }
            else
            {

                ERR_Availavility.err_availability(sabreAnswer);
                if (ERR_Availavility.Status == false)
                {

                    string[] sendInfo = new string[]
                                                {
                                                    origin, destination, date, cmbHours.SelectedIndex.ToString(),
                                                    cmbExitArrival.SelectedIndex.ToString(), txtAirLine1.Text,
                                                    txtAirLine2.Text, txtAirLine3.Text,
                                                    txtAirLine4.Text, txtAirLine5.Text, txtAirLine6.Text,
                                                    chkExclude.Checked.ToString(),
                                                    cmbClassOfService.SelectedIndex.ToString(),
                                                    connections, chkDirectFlights.Checked.ToString(),
                                                    chkShortcuts.Checked.ToString()
                                                };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCSELL_AIR_SEGMENT,
                                                    sendInfo);

                }
                else
                {
                    MessageBox.Show(ERR_Availavility.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }


        /// <summary>
        /// Guarda en session el objeto que representa las entradas del usuario.
        /// </summary>
        private InterJetSession GetUserInputInInterJetSession()
        {

            if (this.Session["IsNewAvailability"] != null)
            {

                var currentSession = (InterJetSession)this.Parameter;
                currentSession.Session["UserInput"] = null;
                InterJetAvailabilityUserInput userInput = this.GetUserInput();
                currentSession.Session["UserInput"] = userInput;
                return currentSession;
            }
            else
            {

                InterJetAvailabilityUserInput userInput = this.GetUserInput();
                var session = new InterJetSession();
                session.Session["UserInput"] = null;
                session.Session["UserInput"] = userInput;
                return session;
            }

        }

        private InterJetAvailabilityUserInput GetUserInput()
        {

            var userInput = new InterJetAvailabilityUserInput();
            userInput.IsOneWayTrip = this.OneWayTripRadioButton.Checked;
            userInput.IsRoundTrip = this.RoundTripRadionButton.Checked;
            userInput.ArrivalStation = this.txtDestination.Text;
            userInput.DepartureStation = this.txtOrigin.Text;
            //userInput.AdultsPassangers = Convert.ToInt32(this.AdultPassangerInterJetCombox.SelectedValue);
            //userInput.SeniorsPassangers = Convert.ToInt32(this.SeniorPassangersInterJetComboBox.SelectedValue);
            //userInput.ChildsPassangers = Convert.ToInt32(this.ChildPassangersInterjetCombox.SelectedValue);
            //userInput.InfantsPassangers = Convert.ToInt32(this.InFantPassangerInterJetComboBox.SelectedValue);
            userInput.AdultsPassangers = Convert.ToInt32(this.AdultsPassangers);
            userInput.SeniorsPassangers = Convert.ToInt32(this.SeniorsPassangers);
            userInput.ChildsPassangers = Convert.ToInt32(this.ChildrenPassangers);
            userInput.InfantsPassangers = Convert.ToInt32(this.InfantPassangers);
            userInput.BeginDate = DateTime.Parse(this.DateSelected);
            userInput.Validate();
            return userInput;
        }


        /// <summary>
        /// Muestra el calendario grafico cuando es llamado
        /// </summary>
        private void CalendarStateFront()
        {
            //    monthCalendar1.Visible = true;
            //    monthCalendar1.BringToFront();
            //    monthCalendar1.Focus();
        }


        /// <summary>
        /// Validación de códigos de Aereolínea no repetidos
        /// ingresados en la mascarilla de "Disponibilidad y venta aérea"
        /// </summary>
        private void AirlinesNotEquals()
        {
            statusSameAirline = false;
            if (!string.IsNullOrEmpty(txtAirLine1.Text))
            {
                if ((txtAirLine1.Text.Equals(txtAirLine2.Text)) ||
                (txtAirLine1.Text.Equals(txtAirLine3.Text)) ||
                (txtAirLine1.Text.Equals(txtAirLine4.Text)) ||
                (txtAirLine1.Text.Equals(txtAirLine5.Text)) ||
                (txtAirLine1.Text.Equals(txtAirLine6.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirLine2.Text))
            {
                if ((txtAirLine2.Text.Equals(txtAirLine1.Text)) ||
                (txtAirLine2.Text.Equals(txtAirLine3.Text)) ||
                (txtAirLine2.Text.Equals(txtAirLine4.Text)) ||
                (txtAirLine2.Text.Equals(txtAirLine5.Text)) ||
                (txtAirLine2.Text.Equals(txtAirLine6.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirLine3.Text))
            {
                if ((txtAirLine3.Text.Equals(txtAirLine1.Text)) ||
                (txtAirLine3.Text.Equals(txtAirLine2.Text)) ||
                (txtAirLine3.Text.Equals(txtAirLine4.Text)) ||
                (txtAirLine3.Text.Equals(txtAirLine5.Text)) ||
                (txtAirLine3.Text.Equals(txtAirLine6.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirLine4.Text))
            {
                if ((txtAirLine4.Text.Equals(txtAirLine1.Text)) ||
                (txtAirLine4.Text.Equals(txtAirLine2.Text)) ||
                (txtAirLine4.Text.Equals(txtAirLine3.Text)) ||
                (txtAirLine4.Text.Equals(txtAirLine5.Text)) ||
                (txtAirLine4.Text.Equals(txtAirLine6.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirLine5.Text))
            {
                if ((txtAirLine5.Text.Equals(txtAirLine1.Text)) ||
                (txtAirLine5.Text.Equals(txtAirLine2.Text)) ||
                (txtAirLine5.Text.Equals(txtAirLine3.Text)) ||
                (txtAirLine5.Text.Equals(txtAirLine4.Text)) ||
                (txtAirLine5.Text.Equals(txtAirLine6.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirLine6.Text))
            {
                if ((txtAirLine6.Text.Equals(txtAirLine1.Text)) ||
                (txtAirLine6.Text.Equals(txtAirLine2.Text)) ||
                (txtAirLine6.Text.Equals(txtAirLine3.Text)) ||
                (txtAirLine6.Text.Equals(txtAirLine4.Text)) ||
                (txtAirLine6.Text.Equals(txtAirLine5.Text)))
                    statusSameAirline = true;
            }
        }


        #endregion//End MethodsClass

        #region=====Show MonthCalendar=====

        /// <summary>
        /// Ejecuta la función calendarStateFront() cuando se presiona el 
        /// picture box picCalendar
        /// </summary>
        /// <param name="sender">picCalendar</param>
        /// <param name="e"></param>
        private void picCalendar_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
        }
        #endregion//End Show MonthCalendar

        #region=====Hide MonthCalendar With Key Escape=====

        /// <summary>
        /// Esconde el calendario grafico al presionar la tecla ESC cuando
        /// este tiene el foco
        /// </summary>
        /// <param name="sender">monthCalendar1</param>
        /// <param name="e"></param>

        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (monthCalendar1.Focus())
            //{
            //    if (e.KeyData == Keys.Escape)
            //    {
            //        if (tblLayoutMain.Contains(monthCalendar1))
            //        {
            //            monthCalendar1.SendToBack();

            //        }
            //        monthCalendar1.Visible = false;

            //    }
            //}
        }

        #endregion//End Hide MonthCalendar With Key Escape

        #region=====Hide monthCalendar When the Focus Leave it=====

        /// <summary>
        /// Esconde el calendario grafico cuando este no tiene el foco
        /// </summary>
        /// <param name="sender">monthCalendar1</param>
        /// <param name="e"></param>
        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            //monthCalendar1.SendToBack();
            //monthCalendar1.Visible = false;
        }
        #endregion//End Hide monthCalendar When the Focus Leave it

        #region=====Select Date from MonthCalendar=====

        /// <summary>
        /// Selección de fecha por calendario grafico y validación de
        /// fecha no menor a la actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            statusDate = true;
            //DateTime dateSelected = monthCalendar1.SelectionStart;
            //if (DateTime.Compare(dateSelected, DateTime.Today) < 0)
            //    statusDate = true;
            //else
            //    statusDate = false;
            //string date = dateSelected.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            //txtDateSelected.Text = date;
            //if (tblLayoutMain.Contains(monthCalendar1))
            //{
            //    monthCalendar1.SendToBack();

            //}
            //monthCalendar1.Visible = false;

        }
        #endregion//End Select Date from MonthCalendar

        #region=====Disenable Controls When chkShortCuts Checked=====

        /// <summary>
        /// Habilita o deshabilita ciertos controles cuando la opcion
        /// "Acceso directo" esta seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShortcuts_CheckedChanged(object sender, EventArgs e)
        {
            statusShortCuts = chkShortcuts.Checked;
            if (statusShortCuts)
            {
                txtAirLine2.Text = string.Empty;
                txtAirLine2.Enabled = false;
                txtAirLine2.BackColor = SystemColors.Control;
                txtAirLine3.Text = string.Empty;
                txtAirLine3.Enabled = false;
                txtAirLine3.BackColor = SystemColors.Control;
                txtAirLine4.Text = string.Empty;
                txtAirLine4.Enabled = false;
                txtAirLine4.BackColor = SystemColors.Control;
                txtAirLine5.Text = string.Empty;
                txtAirLine5.Enabled = false;
                txtAirLine5.BackColor = SystemColors.Control;
                txtAirLine6.Text = string.Empty;
                txtAirLine6.Enabled = false;
                txtAirLine6.BackColor = SystemColors.Control;
            }
            else
            {
                txtAirLine2.Enabled = true;
                txtAirLine3.Enabled = true;
                txtAirLine4.Enabled = true;
                txtAirLine5.Enabled = true;
                txtAirLine6.Enabled = true;
                txtAirLine2.BackColor = Color.White;
                txtAirLine3.BackColor = Color.White;
                txtAirLine4.BackColor = Color.White;
                txtAirLine5.BackColor = Color.White;
                txtAirLine6.BackColor = Color.White;
            }
        }

        #endregion//End Disenable Controls When chkShortCuts Checked

        #region=====Textbox Controls Text Change Events=====

        /// <summary>
        /// Cambio de foco al siguiente control cuando txtDateSelected esta lleno
        /// </summary>
        /// <param name="sender">txtDateSelected</param>
        /// <param name="e"></param>
        private void txtDateSelected_TextChanged(object sender, EventArgs e)
        {
            //if (txtDateSelected.Text.Length > 4)
            //{
            //    txtOrigin.Focus();
            //}
        }


        /// <summary>
        /// Activación de predictivo de ciudad de origen, destino y conexiones
        /// al cambiar los datos ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrigin_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirports(txt, lbCities);
            }
        }

        /// <summary>
        /// Activación de predictivo de aereolíneas al cambiar los datos
        /// ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbAirlines);
            }
        }

        #endregion//End Change Focus When a Textbox is Full

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso enviando a la mascarilla de welcome
        /// al presionar la tecla ESC o ejecuta las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click_1(sender, e);
            }

        }



        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        #region===== listbox Controls Events=====


        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbCities tiene el foco
        /// </summary>
        /// <param name="sender">lbCities</param>
        /// <param name="e"></param>
        private void lbCities_KeyDown(object sender, KeyEventArgs e)
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
                lbCities.Visible = false;
                txt.Focus();
            }
        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando el txt origen, destino o conexiones tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void citiesActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click_1(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbCities.Items.Count > 0)
                {
                    lbCities.SelectedIndex = 0;
                    lbCities.Focus();
                    lbCities.Visible = true;
                    lbCities.Focus();
                }
            }

        }


        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirlines tiene el foco
        /// </summary>
        /// <param name="sender">lbAirlines</param>
        /// <param name="e"></param>
        private void lbAirlines_KeyDown(object sender, KeyEventArgs e)
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
                lbAirlines.Visible = false;
                txt.Focus();
            }

        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aereolínea tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirlinesActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click_1(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbAirlines.Items.Count > 0)
                {
                    lbAirlines.SelectedIndex = 0;
                    lbAirlines.Focus();
                    lbAirlines.Visible = true;
                    lbAirlines.Focus();
                }
            }

        }


        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        #endregion//End lbControls events

        #region Metodos Helpers de Interjet
        /// <summary>
        /// Habilita los controles de interjet.
        /// </summary>
        private void EnableInterJetControls()
        {
            this.EnableInterjetControls(true);
        }
        /// <summary>
        /// Deshabilita los controles de interjet
        /// </summary>
        private void DisableInterJetControls()
        {
            this.EnableInterjetControls(false);
            // this.ShowRoundTripInterJetControls(false);
        }
        /// <summary>
        /// Habilita o deshabilita los controles de interjet segun se indique.
        /// </summary>
        /// <param name="enabled"></param>
        private void EnableInterjetControls(bool enabled)
        {
            this.AdultPassangerInterJetCombox.Enabled = enabled;
            this.ChildPassangersInterjetCombox.Enabled = enabled;
            this.SeniorPassangersInterJetComboBox.Enabled = enabled;
            this.InFantPassangerInterJetComboBox.Enabled = enabled;
            this.OneWayTripRadioButton.Enabled = enabled;
            this.RoundTripRadionButton.Enabled = enabled;

        }

        /// <summary>
        /// Despliega los controles de interjet cuando se seleccion un viaje redondo.
        /// </summary>
        private void ShowRoundTripInterJetControls(bool isVisible)
        {
            this.ReturnDateRoundTripSmartTextBox.Visible = isVisible;
            this.ReturnDateInterJetLabel.Visible = isVisible;
            this.ShowReturnDateCalendarInterjet(false);
            this.ReturnCalendarInterJetPictureBox.Visible = isVisible;


        }

        /// <summary>
        /// Oculta o despliega el calendario para seleccionar una fecha de regreso.
        /// </summary>
        /// <param name="isVisible"></param>
        private void ShowReturnDateCalendarInterjet(bool isVisible)
        {
            this.ReturnDateCalendarInterJet.Visible = isVisible;
        }

        /// <summary>
        /// Llena los comboBox con el numero de pasajeros permitidos.
        /// </summary>
        private void FillInterJetDropDownList()
        {

            //this.AdultPassangerInterJetCombox.DataSource = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //this.ChildPassangersInterjetCombox.DataSource = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //this.SeniorPassangersInterJetComboBox.DataSource = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //this.InFantPassangerInterJetComboBox.DataSource = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            FillLowCostDropDown();
        }

        private void FillLowCostDropDown()
        {
            this.adultComboBox.Properties.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            this.adultComboBox.SelectedItem = "1";
            this.seniorComboBox.Properties.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            seniorComboBox.SelectedItem = "0";
            this.childComboBox.Properties.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            childComboBox.SelectedItem = "0";
            this.infantComboBox.Properties.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            infantComboBox.SelectedItem = "0";
        }

        private string Adult
        { get { return this.adultComboBox.SelectedItem.ToString(); } }

        private string Senior
        { get { return this.seniorComboBox.SelectedItem.ToString(); } }

        private string Child
        { get { return this.childComboBox.SelectedItem.ToString(); } }

        private string Infant
        { get { return this.infantComboBox.SelectedItem.ToString(); } }

        #endregion

        #region Eventos de InterJet




        /// <summary>
        /// Handler del evento checked cuando se selecciona la casilla de interjet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void interjetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Verificar sí se ha seleccionado la casilla de interjet

            if (this.IsInterJetCheckBoxSelected)
            {
                this.singleTripRadioButton.Checked = true;
                this.EnableInterJetControls();
                EnableLowCostAirline(true);
                //sí esta seleccionada habilitar controles de interjet.
            }
            else
            {
                //Sí no mantenerlos deshabilitados.
                this.DisableInterJetControls();
                EnableLowCostAirline(false);
            }
        }

        private void EnableLowCostAirline(bool enabled)
        {
            this.roundTripRadioButton.Enabled = enabled;
            this.singleTripRadioButton.Enabled = enabled;
            this.adultComboBox.Enabled = enabled;
            this.seniorComboBox.Enabled = enabled;
            this.childComboBox.Enabled = enabled;
            this.infantComboBox.Enabled = enabled;

            this.txtEmail.Visible = enabled;
            this.txtPassword.Visible = enabled;
            this.lblComment.Visible = enabled;
            this.lblEmail.Visible = enabled;
            this.lblPassword.Visible = enabled;
            this.txtEmail.Focus();

        }


        /// <summary>
        /// Handler del evento checked al momento de seleccionar un vuelo redondo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roundTripRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Verificar sí se tiene la casilla de vuelo redondo
            if (this.IsARoundTripViaInterJet)
            {
                //Sí se tiene seleccionada habilitarla
                //this.ShowRoundTripInterJetControls(true);
            }
            else
            { // Sí no se tiene seleccionado deshabilitar.
                //this.ShowRoundTripInterJetControls(false);
            }
        }

        /// <summary>
        /// Evento seleccionado al momento de seleccionar una fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arguments"></param>
        private void ReturnDateCalendarInterJet_DateSelected(object sender, DateRangeEventArgs arguments)
        {
            //Obtener fecha otorgada
            DateTime selectedReturningDate = arguments.Start;
            // validar que sea mayor o igual al dia seleccionado de salida
            if (selectedReturningDate >= DateTime.Today)
            {
                // Reducir a formato
                string selectedDate = selectedReturningDate.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                //Colocar en el formato correcto
                this.ReturnDateRoundTripSmartTextBox.Text = selectedDate;
                //Ocultar el calendario de seleccion
                this.ShowReturnDateCalendarInterjet(false);

            }
            else
            {

            }

        }

        /// <summary>
        /// Handler del evento click sobre la imagen del calendario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnCalendarInterJetPictureBox_Click(object sender, EventArgs e)
        {
            // sí no esta visible el calendario
            if (!this.ReturnDateCalendarInterJet.Visible)
            {
                //Desplegar el calendario
                this.ShowReturnDateCalendarInterjet(true);
            }
            else
            {
                //Ocultar el calendario debido a que esta visible y se requiere ocultar.
                this.ShowReturnDateCalendarInterjet(false);
            }
        }
        #endregion

        #region Miembros de IAvailabilityView

        public bool IsLowFare
        {
            get { return this.interjetCheckBox.Checked; }
            set { this.interjetCheckBox.Checked = value; }
        }

        public bool IsSingleTrip
        {
            get { return singleTripRadioButton.Checked; }
            set { singleTripRadioButton.Checked = value; }
        }

        public bool IsRoundTrip
        {
            get { return this.roundTripRadioButton.Checked; }
            set { this.roundTripRadioButton.Checked = value; }
        }

        public DateTime DepartureDate
        {
            get { return this.departureTime.DateTime; }
            set { this.departureTime.DateTime = value; }
        }

        public DateTime? ReturningDate
        {
            get { return this.returningDate.DateTime; }
            set
            {
                if (value.HasValue)
                {
                    this.returningDate.DateTime = value.Value;
                }
            }
        }


        public string DepartureStation
        {
            get { return this.txtOrigin.Text; }
            set { this.txtOrigin.Text = value; }
        }

        public string ArrivalStation
        {
            get { return this.txtDestination.Text; }
            set { this.txtDestination.Text = value; }
        }

        public int AdultsPassangers
        {
            get { return Convert.ToInt32(Adult); }
            set { this.adultComboBox.SelectedItem = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int SeniorsPassangers
        {
            get { return Convert.ToInt32(Senior); }
            set { this.seniorComboBox.SelectedItem = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int ChildrenPassangers
        {
            get { return Convert.ToInt32(Child); }
            set { this.childComboBox.SelectedItem = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int InfantPassangers
        {
            get { return Convert.ToInt32(Infant); }
            set { this.infantComboBox.SelectedItem = value.ToString(CultureInfo.InvariantCulture); }
        }

        public void HideRoundTripOption(bool hide)
        {
            this.returningDatePanel.Visible = hide;
        }

        #endregion

        #region Miembros de IAvailabilityView

        /// <summary>
        /// Gots to nex step.
        /// </summary>
        public void GotToNexStep()
        {


            this.AvailabilityCommandsSend(departureTime.DateTime.ToString("ddMMM", new CultureInfo("en-US")), txtOrigin.Text, txtDestination.Text);
            if (roundTripRadioButton.Checked)
            {
                this.AvailabilityCommandsSend(returningDate.DateTime.ToString("ddMMM", new CultureInfo("en-US")), txtDestination.Text, txtOrigin.Text);
            }
            //IsInterJetProcess = true;
            //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetAvailabilityOfFlights", this.GetUserInputInInterJetSession(), null);
            Parameter = AvailabilityRequest;
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucLowFareAvailability", Parameter, null);

        }

        /// <summary>
        /// Gets or sets the availability request.
        /// </summary>
        /// <value>
        /// The availability request.
        /// </value>
        public AvailabilityRequest AvailabilityRequest
        {
            get
            {

                var availabilityRequest = EntitieFactory.Create<AvailabilityRequest>();
                availabilityRequest.DepartureStation = this.DepartureStation;
                availabilityRequest.DepartureDateTime = this.DepartureDate;
                availabilityRequest.ArrivalStation = this.ArrivalStation;
                availabilityRequest.Pasengers.Adult.Count = this.AdultsPassangers;
                availabilityRequest.Pasengers.Senior.Count = this.SeniorsPassangers;
                availabilityRequest.Pasengers.Child.Count = this.ChildrenPassangers;
                availabilityRequest.Pasengers.Infant.Count = this.InfantPassangers;
                if (IsRoundTrip)
                {
                    availabilityRequest.BecomeRoundTrip();
                    availabilityRequest.ReturningDateTime = this.ReturningDate;
                }

                return availabilityRequest;

            }
            set
            {


            }
        }


        #endregion

        #region Miembros de IBaseView


        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <returns></returns>
        public void ValidateInput()
        {

            AvailabilityRequest.Validate();
            IsValid = true;

        }

        #endregion

        #region Miembros de IBaseView


        public bool IsValid { get; set; }

        #endregion

        /// <summary>
        /// Handles the 1 event of the roundTripRadioButton_CheckedChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void roundTripRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.roundTripRadioButton.Checked)
            {
                this.returningDatePanel.Visible = true;
            }
            else
            {
                this.returningDatePanel.Visible = false;

            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the singleTripRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void singleTripRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (singleTripRadioButton.Checked)
            {
                if (this.returningDatePanel.Visible)
                {
                    this.returningDatePanel.Visible = false;
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.departureTime.ShowPopup();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.returningDate.ShowPopup();
        }

       
    }
}