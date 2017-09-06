using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Builder;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ContextSolvers;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ErrorHandlers;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ErrorManager;
using System.Collections;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ModifyFlightSearch;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Services;
using System.Threading;
using MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder;
using MyCTS.Services.APIVolaris;
using MyCTS.Services.Contracts.Volaris;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucLowFareAvailability : CustomUserControl, LowFareAvailabilityView
    {

        /// <summary>
        /// 
        /// </summary>
        private LowFareAvailabilityPresenter _presenter;
        private VolarisFlight getValores;
        private readonly BackgroundWorker _profileWorker;
        private bool addNewItinerary;
        private decimal venta = 0;
        private bool getVenta = false;
        private bool NotExistSale = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="ucLowFareAvailability"/> class.
        /// </summary>
        public ucLowFareAvailability()
        {                        
            _profileWorker = new BackgroundWorker();
            _profileWorker.DoWork += _profileWorker_DoWork;
            _profileWorker.RunWorkerCompleted += _profileWorker_RunWorkerCompleted;
            _profileWorker.RunWorkerAsync();
            InitializeComponent();
            Dispatcher = new Hashtable();        
            Dispatcher["InterJet"] = "ucInterJetPreviousPrincingContainerControl";
            Dispatcher["Volaris"] = "ucVolarisPreviousPricing";                                      
        }
      

        void _profileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                _profileWorker.DoWork -= _profileWorker_DoWork;
                _profileWorker.RunWorkerCompleted -= _profileWorker_RunWorkerCompleted;
            }
            finally
            {
                _profileWorker.Dispose();

            }
        }

        void _profileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CatStars2ndLevelBL.GetStars2ndLevel();            
        }        

        public Hashtable Dispatcher { get; set; }



        public bool IsInterJet
        {
            get { return (Itinerary.Departure is InterJetFlight); }
        }

        public InterJetSession ExtraData
        {

            get
            {
                //TODO: Crear una session de InterJet y poner los selectedFlights y los userInput.
                var interJetSession = new InterJetSession();
                var interJetSelectedFlights = new InterJetSelectedFlights();
                if (Itinerary.Departure is InterJetFlight)
                {
                    var flights = (InterJetFlight)Itinerary.Departure;
                    if (flights.Segments.GetAll().Any())
                    {
                        var flightsToAdd =
                            flights.Segments.GetAll().Cast<InterJetSegment>().Select(d => d.Flight).ToList();
                        interJetSelectedFlights.AddFlight(flightsToAdd[0]);
                    }
                }
                if (AvailabilityRequest.Type == AvailabilityRequestType.RoundTrip && Itinerary.Return is InterJetFlight)
                {
                    var flights = (InterJetFlight)Itinerary.Return;
                    if (flights.Segments.GetAll().Any())
                    {
                        var flightsToAdd =
                            flights.Segments.GetAll().Cast<InterJetSegment>().Select(d => d.Flight).ToList();
                        interJetSelectedFlights.AddFlight(flightsToAdd[0]);
                    }
                }
                interJetSession.Session["SelectedFlights"] = interJetSelectedFlights;
                interJetSession.Session["UserInput"] = new InterJetAvailabilityUserInput
                                                           {
                                                               DepartureStation = AvailabilityRequest.DepartureStation,
                                                               SeniorsPassangers = AvailabilityRequest.Pasengers.Senior.Count,
                                                               ArrivalStation = AvailabilityRequest.ArrivalStation,
                                                               AdultsPassangers = AvailabilityRequest.Pasengers.Adult.Count,
                                                               ChildsPassangers = AvailabilityRequest.Pasengers.Child.Count,
                                                               InfantsPassangers = AvailabilityRequest.Pasengers.Infant.Count,

                                                           };

                return interJetSession;
            }
        }

        #region Miembros de LowFareAvailabilityView

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }

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
                if (Parameter != null)
                {
                    var availabilityRequest = (AvailabilityRequest)Parameter;
                    return availabilityRequest;

                }
                return new AvailabilityRequest();
            }
            set
            {

            }
        }


        /// <summary>
        /// Gets or sets the itinerary.
        /// </summary>
        /// <value>
        /// The itinerary.
        /// </value>
        public Itinerary Itinerary
        {
            get
            {
                addNewItinerary = true;
                bool volaris= false;
                bool fly = false;
                var itinerary = new Itinerary();
                NotExistSale = false;

                var departureControl = GetContainer("salida");
                if (departureControl.IsValid)
                {
                    itinerary.Departure = departureControl.SelectedFlight;
                    CostumerAccountInterJet.DepartureTime = itinerary.Departure.DepartureTime;
                    ListTaxesInterjet.roud = false;
                    if (departureControl.SelectedFlight.OwnerCompany == "Volaris" && !getVenta)
                    {
                        if (itinerary.Departure.BasePrice > 0)
                        {
                            VolarisSession.VolarisFlight = new List<VolarisFlight>();
                            VolarisSession.IsVolarisProcess = true;
                            volaris = true;
                            ItineraryFlowVolaris itinerarioVolaris = new ItineraryFlowVolaris();
                            getValores = new VolarisFlight();
                            getValores = (VolarisFlight)itinerary.Departure;
                            VolarisSession.VolarisFlight.Add(getValores);

                            string valor = getValores.TotalPrice.ToString();
                            for (int i = 0; i < itinerary.Departure.Segments.GetAll().Count; i++)
                            {
                                itinerarioVolaris = TranslateFromIFlightToItineraryFlowVolaris(itinerary.Departure, i);
                                if (itinerary.Type.ToString() == "SingleTrip")
                                {
                                    itinerarioVolaris.TipoVuelo = TiposVolaris.FlightTypes.OnlyTrip;
                                }
                                VolarisSession.ItinerarioVolaris.Add(itinerarioVolaris);
                                if (!fly)
                                {
                                    foreach (VueloDisponibleMyCTS vuelo in VolarisSession.VuelosDisponibles)
                                    {
                                        bool Finish = false;
                                        for (int j = 0; j < vuelo.Segments.Count; j++)
                                        {
                                            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
                                            if (vuelo.Segments[j].FlightNumber.Substring(3, 4).Trim() == itinerarioVolaris.NumeroVuelo.Trim()
                                                 && vuelo.TypeFlight == TiposVolaris.FlightFullType.Outbound &&
                                                vuelo.Segments[j].DepartureDateTime.Substring(4, 16) == String.Format("{0:MM/dd/yyyy HH:mm}", itinerarioVolaris.FechaInicio) &&
                                                vuelo.Segments[j].ArrivalStationDateTime.Substring(4, 16) == String.Format("{0:MM/dd/yyyy HH:mm}", itinerarioVolaris.FechaLlegada))
                                            {
                                                VolarisSession.VueloIda = vuelo;
                                                Finish = true;
                                                fly = true;
                                            }
                                        }
                                        if (Finish)
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    else if(itinerary.Departure.BasePrice==0)
                    {
                        NotExistSale = true;
                    }
                 }
                var returningControl = GetContainer("regreso");
                if (returningControl.IsValid)
                {
                    addNewItinerary = true;
                    itinerary.Return = returningControl.SelectedFlight;
                    itinerary.BecomeRoundTrip();
                    ListTaxesInterjet.roud = true;
                    if (returningControl.SelectedFlight.OwnerCompany == "Volaris" && !getVenta)
                    {
                        if (itinerary.Return.BasePrice > 0)
                        {
                            volaris = true;
                            ItineraryFlowVolaris itinerarioVolaris = new ItineraryFlowVolaris();
                            getValores = new VolarisFlight();
                            getValores = (VolarisFlight)itinerary.Return;
                            VolarisSession.VolarisFlight.Add(getValores);
                            fly = false;
                            for (int i = 0; i < itinerary.Return.Segments.GetAll().Count; i++)
                            {
                                itinerarioVolaris = TranslateFromIFlightToItineraryFlowVolaris(itinerary.Return, i);
                                if (itinerary.Type.ToString() == "RoundTrip")
                                {
                                    itinerarioVolaris.TipoVuelo = TiposVolaris.FlightTypes.RoundTrip;
                                }
                                VolarisSession.ItinerarioVolaris.Add(itinerarioVolaris);
                                if (!fly)
                                {
                                    foreach (VueloDisponibleMyCTS vuelo in VolarisSession.VuelosDisponibles)
                                    {
                                        bool Finish = false;
                                        for (int j = 0; j < vuelo.Segments.Count; j++)
                                        {
                                            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
                                            if (vuelo.Segments[j].FlightNumber.Substring(3, 4).Trim() == itinerarioVolaris.NumeroVuelo.Trim() &&
                                                vuelo.TypeFlight == TiposVolaris.FlightFullType.Inbound &&
                                               vuelo.Segments[j].DepartureDateTime.Substring(4, 16) == String.Format("{0:MM/dd/yyyy HH:mm}", itinerarioVolaris.FechaInicio) &&
                                                   vuelo.Segments[j].ArrivalStationDateTime.Substring(4, 16) == String.Format("{0:MM/dd/yyyy HH:mm}", itinerarioVolaris.FechaLlegada))
                                            {
                                                VolarisSession.VueloRegreso = vuelo;
                                                Finish = true;
                                                fly = true;
                                            }
                                        }
                                        if (Finish)
                                            break;
                                    }
                                }
                            }
                        }
                        else if (itinerary.Return.BasePrice == 0)
                        {
                            NotExistSale = true;
                        }
                    }
                    
                }

                if(volaris)
                {
                    if (venta == 0)
                    {
                        getVenta = true;
                        VolarisServiceManager cliente = new VolarisServiceManager();
                        if (itinerary.Type.ToString() == "SingleTrip")
                           venta= cliente.ObtenerVenta(VolarisSession.VueloIda, null, VolarisSession.ListaTipoPassenger, TiposVolaris.FlightTypes.OnlyTrip);
                        if (itinerary.Type.ToString() == "RoundTrip")
                           venta= cliente.ObtenerVenta(VolarisSession.VueloIda, VolarisSession.VueloRegreso, VolarisSession.ListaTipoPassenger, TiposVolaris.FlightTypes.RoundTrip);
                    }
                }
                return itinerary;
            }
        }

        private ItineraryFlowVolaris TranslateFromIFlightToItineraryFlowVolaris(IFlight flight, int cont)
        {
            ItineraryFlowVolaris itinerarioVolaris = new ItineraryFlowVolaris();
            List<ISegment> listaSegment = flight.Segments.GetAll();
            itinerarioVolaris.Itinerary = listaSegment[cont].DepartureStation + "-" + listaSegment[cont].ArrivalStation;
            itinerarioVolaris.NumeroVuelo = listaSegment[cont].ID.Trim();
            itinerarioVolaris.Origen = listaSegment[cont].DepartureStation;
            itinerarioVolaris.Destino = listaSegment[cont].ArrivalStation;
            itinerarioVolaris.FechaInicio =listaSegment[cont].DepartureTime;
            itinerarioVolaris.FechaLlegada = listaSegment[cont].ArrivalTime;
            itinerarioVolaris.CodigoMoneda = "MXN";
            itinerarioVolaris.ListaTipoPassenger = new List<TiposVolaris.PassengerType>();
            itinerarioVolaris.ListaTipoPassenger = VolarisSession.ListaTipoPassenger;
            itinerarioVolaris.PrecioBaseAdult = (getValores.BasePrice * VolarisSession.ContAdult);
            VolarisSession.BaseTotalPayAdult = VolarisSession.BaseTotalPayAdult + getValores.BasePrice;
            itinerarioVolaris.PrecioTotalAdult = (getValores.TotalPrice * VolarisSession.ContAdult);
            itinerarioVolaris.TaxAdult = (getValores.Tax * VolarisSession.ContAdult);
            itinerarioVolaris.PrecioBaseChild = (getValores.BasePrice * VolarisSession.ContChild);
            VolarisSession.BaseTotalPayChild = VolarisSession.BaseTotalPayChild + getValores.BasePrice;
            itinerarioVolaris.PrecioTotalChild = (getValores.TotalPrice * VolarisSession.ContChild);
            itinerarioVolaris.TaxChild = (getValores.Tax * VolarisSession.ContChild);
            return itinerarioVolaris;
        }

        private DateTime GetFechaVolaris(string fechaOrigen)
        {
            string fecha = fechaOrigen.Split(' ')[0];
            string horaOrigen = fechaOrigen.Split(' ')[1];

            int mes = Convert.ToInt32(fecha.Split('/')[0]);
            int dia = Convert.ToInt32(fecha.Split('/')[1]);
            int anio = Convert.ToInt32(fecha.Split('/')[2]);

            int hora = Convert.ToInt32(horaOrigen.Split(':')[0]);
            int minuto = Convert.ToInt32(horaOrigen.Split(':')[1]);

            return new DateTime(anio, mes, dia, hora, minuto, 0);
        }

        private ucLowFareAvailabilityContainer GetContainer(string type)
        {
            var table = GetTable();
            var departureControl = table.Controls.OfType<ucLowFareAvailabilityContainer>().FirstOrDefault(c => c.TypeItinerary.Equals(type));
            if (departureControl != null)
            {
                return departureControl;
            }
            return new ucLowFareAvailabilityContainer() { IsValid = false };
        }


        private ErrorManager<Exception> _errorManager;
        /// <summary>
        /// Gets the error manager.
        /// </summary>
        private ErrorManager<Exception> ErrorManager
        {
            get
            {
                return _errorManager ?? (_errorManager = new LowFareAvailabilityWinFormErrorManager
                                                             {
                                                                 Handler = new NoSelectedDepartureFlightExceptionHandler
                                                                               {

                                                                                   Succesor = new NoSelectedReturningFlightExceptionHandler
                                                                                                  {
                                                                                                      Context = new NoSelectedReturningFlightWinFormProcessContext()
                                                                                                  },
                                                                                   Context = new NoSelectedDepartureFlightWinFormProcessContext()
                                                                               }
                                                             });
            }
        }


        #endregion

        public void ValidateInput()
        {
            ucLowFareAvailabilityContainer.Valid = false;
            var table = GetTable();
            var containers = table.Controls.OfType<ucLowFareAvailabilityContainer>();
            if (containers.Any())
            {
                foreach (var control in containers)
                {
                    control.ValidateInput();
                    if (ucLowFareAvailabilityContainer.Valid)
                        break;
                }

                if (!ucLowFareAvailabilityContainer.Valid)
                {
                    foreach (var control in containers)
                    {
                        if (AvailabilityRequest.Type == AvailabilityRequestType.RoundTrip)
                        {

                            if (control.SelectedFlight != null && containers.Any(c => !c.SelectedFlight.OwnerCompany.Equals(control.SelectedFlight.OwnerCompany)))
                            {
                                control.SetError("Por favor seleccione dos vuelos de la misma aerolinea.");
                            }
                        }
                    }
                }

                IsValid = containers.All(c => c.IsValid);

            }
            else
            {
                IsValid = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the continueButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void continueButton_Click(object sender, EventArgs e)
        {
            _presenter.NextStep();
        }

        /// <summary>
        /// Handles the Click event of the backButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            _presenter.GoBack();

            VolarisServiceManager cliente = new VolarisServiceManager();
            cliente.CloseReservation();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
        }



        /// <summary>
        /// Goes to next step.
        /// </summary>
        public void GoToNextStep()
        {

            VolarisSession.ItinerarioVolaris = new List<ItineraryFlowVolaris>();

            string companyName = Itinerary.Departure.OwnerCompany;

            

            if (Dispatcher.Contains(companyName))
            {
                string nextControlToLoad = Dispatcher[companyName].ToString();
                if (!IsInterJet)
                {
                    LogProductivity.LogTransaction(Login.Agent, "1-Seleccion vuelos de volaris para cotizar.--Volaris");
                    if (!NotExistSale)
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, "ucQuoteVolaris");
                    }
                    else
                    {
                        MessageBox.Show("Elegir un vuelo con Tarifa Base mayor a 0", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    VolarisSession.IsVolarisProcess = false;
                    LogProductivity.LogTransaction(Login.Agent, "Seleccion vuelos de InterJet para cotizar.--InterJet");
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, nextControlToLoad, ExtraData, null,
                                                null);
                }
            }


        }

        /// <summary>
        /// Goes the back.
        /// </summary>
        public void GoBack()
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucAvailability", null, null);
        }




        /// <summary>
        /// Handles the Load event of the ucLowFareAvailability control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucLowFareAvailability_Load(object sender, EventArgs e)
        {           
            _presenter = new LowFareAvailabilityPresenter()
                             {
                                 View = this,
                                 Repository = new LowFareAvailabilityRepository(),
                                 ServiceHandler = new LowFareWinFormServiceHandler
                                                      {
                                                          Request = AvailabilityRequest,
                                                          OnSearchingFlightsComplete = OnSearchingFlightsComplete,
                                                          OnNewServiceCall = OnNewServiceCall,
                                                      },

                             };
            ucMenuReservations.EnabledMenu = false;
            _presenter.InitializeView();
            _presenter.CallService();
                        
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            var processBlock = new ProcessBlocker();
            if (processBlock.HandleEvent(ref msg, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Called when [new service call].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments.OnNewServiceCalledEventArgs"/> instance containing the event data.</param>
        private void OnNewServiceCall(object sender, OnNewServiceCalledEventArgs e)
        {
            OnReportStatus(e.Company, e.MessageToSend);
        }


        private TableLayoutPanel GetTable()
        {

            return panelContainer.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
        }
        /// <summary>
        /// Called when [searching flights complete].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments.OnSearchingFlightsCompletedEventArgs"/> instance containing the event data.</param>
        private void OnSearchingFlightsComplete(object sender, OnSearchingFlightsCompletedEventArgs e)
        {

            animationPanel.Visible = false;

            waitingForControls1.Visible = true;
            var dynamicControlBuilder = new LowFareAvailabilityDynamicControlBuilder()
            {

                Flights = e.Flights,
                Request = this.AvailabilityRequest
            };

            var table = (TableLayoutPanel)dynamicControlBuilder.Build();

            var modifySearchFlight = table.Controls.OfType<ucVolairsModifyFlightSearch>().FirstOrDefault();
            if (modifySearchFlight != null)
            {
                modifySearchFlight.ContainerControl.OnSearchFlights += OnSearchFlights;
            }

            int rowIndex = table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            buttonPanel.Dock = DockStyle.Right;
            table.Controls.Add(buttonPanel, 0, rowIndex);
            ucMenuReservations.EnabledMenu = true;
            panelContainer.Controls.Add(table);
            var backTest = new BackgroundWorker();
            backTest.DoWork += backTest_DoWork;
            backTest.RunWorkerCompleted += backTest_RunWorkerCompleted;
            backTest.RunWorkerAsync();
        }

        private bool AllowShortCut { get; set; }

        /// <summary>
        /// Called when [search flights].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSearchFlights(object sender, EventArgs eventArgs)
        {
            var avialabilitControl = sender as LowFareAvailabilitySearch;
            if (avialabilitControl != null)
            {

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucLowFareAvailability", avialabilitControl.Request, null);
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the backTest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void backTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            animationPanel.Visible = false;
            waitingForControls1.Visible = false;
            buttonPanel.Visible = true;
            panelContainer.Visible = true;

        }

        /// <summary>
        /// Handles the DoWork event of the backTest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void backTest_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(600);
        }

        private readonly List<Exception> _departureErrors = new List<Exception>();
        private readonly List<Exception> _returningErrors = new List<Exception>();

        #region Miembros de LowFareAvailabilityView

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, Bitmap> _imageDispatcher = new Dictionary<string, Bitmap>()
                                                                  {
                                                                      {"InterJet",Properties.Resources.InterJetAvailability},
                                                                      {"Volaris",Properties.Resources.VolarisAvailability}

                                                                  };
        /// <summary>
        /// Called when [report status].
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="messageToShow">The message to show.</param>
        public void OnReportStatus(string company, string messageToShow)
        {

            if (_imageDispatcher.ContainsKey(company))
            {
                this.loadingControl1.ImageToShow = _imageDispatcher[company];
                this.loadingControl1.MessageToShow = messageToShow;
            }

        }

        #endregion



        #region Miembros de LowFareAvailabilityView

        public Flights Flights { get; set; }

        #endregion
        
    }
}
