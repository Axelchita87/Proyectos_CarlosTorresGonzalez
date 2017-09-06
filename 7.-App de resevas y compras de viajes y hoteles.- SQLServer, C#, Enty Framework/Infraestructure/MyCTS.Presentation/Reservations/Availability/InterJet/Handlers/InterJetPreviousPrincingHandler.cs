using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;
using System.Drawing;


namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetPreviousPrincingHandler : InterJetUserControlHandler
    {
        
        public PictureBox PrincingPictureBoz { get; set; }
        public Button BakToAvailibilityButton { get; set; }
        public PictureBox Loading { get; set; }
        public Button ContinueToPassangersButton { get; set; }

        public Panel TotalPricePanel { get; set; }

        public Label TotalPriceLabel { get; set; }
        public static bool Conexion { get; set; }
        public static int Somite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private InterJetServiceManager _interJetServiceManager;

        /// <summary>
        /// Gets the inter jet service manager.
        /// </summary>
        public InterJetServiceManager InterJetServiceManager
        {
            get
            {
                InterJetServiceManager.AgentEmail = Login.Mail;
                return new InterJetServiceManager();
            }
        }

        /// <summary>
        /// Handles the key event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        public void HandleKeyEvent(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                object session = null;

                if (UserControl.Data is InterJetSession)
                {
                    session = UserControl.Data;
                }

                if (UserControl.Parameter is InterJetSession)
                {
                    session = UserControl.Parameter;
                }
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.UserControl, "ucInterJetPassangerCaptureForm", this.UserControl.Parameter, null);

            }
            if (e.KeyCode == Keys.Escape)
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.UserControl, "ucAvailability", null, null);

            }


        }

        /// <summary>
        /// Backs to availability.
        /// </summary>
        public void BackToAvailability()
        {

            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.UserControl, "ucAvailability", null, null);
        }



        public Panel ButtonPanel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _pricingWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the pricing worker.
        /// </summary>
        private BackgroundWorker PricingWorker
        {
            get { return this._pricingWorker; }
        }

        /// <summary>
        /// Starts the pricing worker.
        /// </summary>
        private void StartPricingWorker()
        {
            this.MainPanel.Visible = false;
            this.StartAnimation(true);
            Timer.Interval = 100;
            Timer.Tick += (Timer_Tick);
            Timer.Enabled = true;
            Timer.Start();
            PricingWorker.DoWork += (PricingWorkerDoWork);
            PricingWorker.RunWorkerCompleted += (PricingWorker_RunWorkerCompleted);
            PricingWorker.RunWorkerAsync();
        }

        private void StartAnimation(bool visible)
        {

            this.CotizandoLabel.Visible = visible;
            //this.ProgressBar.Visible = visible;
            this.PrincingPictureBoz.Visible = visible;
            this.Loading.Visible = visible;

        }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Timer_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(this.ProgressBar.Percentage);
        }

        public Panel MainPanel { get; set; }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the PricingWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void PricingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.StopPricingWorker();

                if (e.Error == null)
                {
                    LoadFlightDetails((List<InterJetFlight>)e.Result);
                }
                else
                {

                }
            }
            finally
            {
                PricingWorker.Dispose();
                Timer.Dispose();
                ProgressBar.Dispose();
            }
            this.ContinueToPassangersButton.Focus();
        }

        /// <summary>
        /// Loads the flight details.
        /// </summary>
        private void LoadFlightDetails(IEnumerable<InterJetFlight> flights)
        {
            const int xDefaultPosition = 0;
            const int yDefaultPosition = 0;
            int flightCounter = 0;
            Somite = 0;
            ListTaxesInterjet.Fligth = 0;

            foreach (var flight in flights)
            {
                ListTaxesInterjet.Fligth++;

                if (flight.Segments.GetAll().Count == 1)
                {
                    ListTaxesInterjet.Conexion = false;
                    Conexion = false;

                    var newFlightPricingControl = new ucInterJetPreviousFlightPricingControl();
                    newFlightPricingControl.ItineraryFlight = flight.DepartureTime.ToString("dd MMM yyyy",
                                                                                            new CultureInfo("es-mx")).
                        ToUpper();
                    if (flightCounter == 0)
                    {
                        newFlightPricingControl.Location = new Point(xDefaultPosition, yDefaultPosition);
                    }
                    else
                    {
                        newFlightPricingControl.Location = this.GetLastPoint();
                    }
                    newFlightPricingControl.SetFlight(flight,1);
                    MainPanel.Controls.Add(newFlightPricingControl);
                    flightCounter += 1;
                }
                else
                {
                    Somite = 0;

                    if (ListTaxesInterjet.Fligth == 1)
                    {
                        ListTaxesInterjet.turning = 0;
                    }
                    else
                    {
                        ListTaxesInterjet.turning = 1;
                    }

                    foreach (ISegment seg in flight.Segments.GetAll())
                    {
                        ListTaxesInterjet.Conexion = true;
                        Conexion = true;
                        var newFlightPricingControl = new ucInterJetPreviousFlightPricingControl();
                        newFlightPricingControl.ItineraryFlight = seg.DepartureTime.ToString("dd MMM yyyy",new CultureInfo("es-mx")).ToUpper();
                        if (flightCounter == 0)
                        {
                            newFlightPricingControl.Location = new Point(xDefaultPosition, yDefaultPosition);
                        }
                        else
                        {
                            newFlightPricingControl.Location = this.GetLastPoint();
                        }
                        newFlightPricingControl.SetFlight(flight,Somite);
                        MainPanel.Controls.Add(newFlightPricingControl);
                        flightCounter += 1;
                        Somite += 1;
                    }
                }
            }
            if (Somite==2 && ListTaxesInterjet.roud)
            {
                try
                {
                    this.TotalPriceLabel.Text = (ListTaxesInterjet.TotalRound / 2).ToString("c");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                this.TotalPriceLabel.Text = flights.Sum(f => f.PreviousPrincig.TotalToPay).ToString("c");
            }
            ResizeTotalPrice();
            ResizeButtonPanel();

        }

        /// <summary>
        /// Resizes the button panel.
        /// </summary>
        private void ResizeButtonPanel()
        {
            this.ButtonPanel.Location = GetLastLocation();

        }

        private void ResizeTotalPrice()
        {

            if (this.MainPanel.Controls.OfType<ucInterJetPreviousFlightPricingControl>().Any())
            {
                int x = 179;
                int y = this.MainPanel.Controls.OfType<ucInterJetPreviousFlightPricingControl>().Sum(c => c.Size.Height);
                int countControls = this.MainPanel.Controls.OfType<ucInterJetPreviousFlightPricingControl>().Count();
                int yDisplacement = 15 * countControls;
                this.TotalPricePanel.Location = new Point(x, y + yDisplacement);
            }


        }



        private Point GetLastLocation()
        {

            var panel = this.MainPanel.Controls.OfType<Panel>().FirstOrDefault(p => p.Name.Equals("totalPricePanel"));
            if (panel != null)
            {
                const int xPosition = 170;
                int y = panel.Location.Y;
                int yDisplacement = 38;
                return new Point(xPosition, y + yDisplacement);
            }
            return new Point();

        }


        /// <summary>
        /// Gets the last point.
        /// </summary>
        /// <returns></returns>
        private Point GetLastPoint()
        {
            var controls = MainPanel.Controls.OfType<ucInterJetPreviousFlightPricingControl>();
            int xDefaultPosition = 0;
            const int yDisplacement = 20;
            if (controls.Any())
            {
                int newYPosition = controls.Sum(control => control.Size.Height + yDisplacement);
                return new Point(xDefaultPosition, newYPosition);
            }

            return new Point();
        }


        /// <summary>
        /// Continues to passanger.
        /// </summary>
        public void ContinueToPassanger()
        {
            object session = null;

            if (UserControl.Data is InterJetSession)
            {
                session = UserControl.Data;
            }

            if (UserControl.Parameter is InterJetSession)
            {
                session = UserControl.Parameter;
            }

            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.UserControl, "ucInterJetPassangerCaptureForm", session, null);

        }


        /// <summary>
        /// Handles the DoWork event of the PricingWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void PricingWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            var interJetServiceManager = new InterJetServiceManager();
            e.Result = interJetServiceManager.GetItineraryPriceTest(UserInput, SelectedFligths);
            //TODO: Cambiar despues de pruebas.
            //e.Result = interJetServiceManager.GetItineraryPrice(UserInput, SelectedFligths);
        }

        /// <summary>
        /// Stops the pricing worker.
        /// </summary>
        private void StopPricingWorker()
        {
            Timer.Stop();
            Timer.Tick -= (Timer_Tick);
            Timer.Enabled = false;
            PricingWorker.DoWork -= (PricingWorkerDoWork);
            PricingWorker.RunWorkerCompleted -= (PricingWorker_RunWorkerCompleted);
            this.MainPanel.Visible = true;
            this.ButtonPanel.Visible = true;
            this.StartAnimation(false);

        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            LogProductivity.LogTransaction(Login.Agent, "2-Desplego Cotización previa a compra--InterJet");
            StartPricingWorker();
            SetToolTip();

        }

        public decimal GetAvailableCretid()
        {
            decimal credit = 0;
            credit = InterJetServiceManager.SeeNumber();
            return credit;
        }

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        public void SetToolTip()
        {
            this.ToolTiper.SetToolTip(this.BakToAvailibilityButton, "Regresar a disponibilidad de vuelos.".ToUpper());

            this.ToolTiper.SetToolTip(this.ContinueToPassangersButton, "Continuar con la captura de pasajeros.".ToUpper());
        }
        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        /// <value>
        /// The timer.
        /// </value>
        public Timer Timer { get; set; }
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {

                //TODO:InterJet Migration -- Remover cuando se terminen las pruebas piloto.
                if (this.UserControl.Parameter != null || this.UserControl.Data != null)
                {
                    if (this.UserControl.Parameter is InterJetSession)
                    {

                        var session = (InterJetSession)this.UserControl.Parameter;
                        return session.Session;
                    }

                    if (this.UserControl.Data is InterJetSession)
                    {
                        var session = (InterJetSession)this.UserControl.Data;
                        return session.Session;
                    }


                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// Gets the selected fligths.
        /// </summary>
        private InterJetSelectedFlights SelectedFligths
        {
            get
            {
                //TODO: Bajar el itinerario de session y crear los selectedFlights y agregarlos ala session.
                if (this.Session["SelectedFlights"] != null)
                {
                    return (InterJetSelectedFlights)Session["SelectedFlights"];

                }
                return new InterJetSelectedFlights();
            }
        }

        /// <summary>
        /// Gets the user input.
        /// </summary>
        private InterJetAvailabilityUserInput UserInput
        {
            get
            {
                if (this.Session["UserInput"] != null)
                {
                    return (InterJetAvailabilityUserInput)this.Session["UserInput"];
                }
                return new InterJetAvailabilityUserInput();
            }
        }


        /// <summary>
        /// Gets or sets the cotizando label.
        /// </summary>
        /// <value>
        /// The cotizando label.
        /// </value>
        public Label CotizandoLabel
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the progress bar.
        /// </summary>
        /// <value>
        /// The progress bar.
        /// </value>
        public GradProg.GradProg ProgressBar
        {
            get;
            set;
        }



    }
}
