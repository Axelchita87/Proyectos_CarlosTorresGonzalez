using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using System.Collections;
using MyCTS.Presentation.Reservations.Availability.InterJet.Exceptions;
using System.Threading;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAvailabilityOfFlightsHandler : InterJetFormHandler
    {
        #region Propierties


        public PictureBox ShoopingCart { get; set; }
        public PictureBox Loading { get; set; }
        public void CancelBackGroundWorker()
        {

            //this.BackgroundWorker.CancelAsync();

        }
        /// <summary>
        /// Gets or sets the air plane picture box on loading.
        /// </summary>
        /// <value>
        /// The air plane picture box on loading.
        /// </value>
        public PictureBox AirPlanePictureBoxOnLoading { get; set; }
        /// <summary>
        /// Gets or sets the new availability button.
        /// </summary>
        /// <value>
        /// The new availability button.
        /// </value>
        public Button NewAvailabilityButton { get; set; }
        /// <summary>
        /// Gets or sets the cancel inter jet process button.
        /// </summary>
        /// <value>
        /// The cancel inter jet process button.
        /// </value>
        public Button CancelInterJetProcessButton { get; set; }
        /// <summary>
        /// Gets or sets the continue with pricing.
        /// </summary>
        /// <value>
        /// The continue with pricing.
        /// </value>
        public Button ContinueWithPricing { get; set; }

        /// <summary>
        /// Gets or sets the segment selled label.
        /// </summary>
        /// <value>
        /// The segment selled label.
        /// </value>
        public Label SegmentSelledLabel
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets the segment selled count.
        /// </summary>
        /// <value>
        /// The segment selled count.
        /// </value>
        public Label SegmentSelledCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the departure information label.
        /// </summary>
        /// <value>
        /// The departure information label.
        /// </value>
        public Label DepartureInformationLabel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the departure intinerary information label.
        /// </summary>
        /// <value>
        /// The departure intinerary information label.
        /// </value>
        public Label DepartureIntineraryInformationLabel
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the returning flight information.
        /// </summary>
        /// <value>
        /// The returning flight information.
        /// </value>
        public Label ReturningFlightInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the returning intinerary flight information.
        /// </summary>
        /// <value>
        /// The returning intinerary flight information.
        /// </value>
        public Label ReturningIntineraryFlightInformation
        {
            get;
            set;
        }



        /// <summary>
        /// Obtiene el datagridview que almacena los vuelos de salida.
        /// </summary>
        public DataGridView DepartureFligthsDataGridView
        {
            get;
            set;

        }

        /// <summary>
        /// Obtiene el datagridview que almacena los vuelos de llegada
        /// </summary>
        public DataGridView ReturningFligthsDataGridView
        {
            get;
            set;
        }


        private int DepartureFlights
        {
            get;
            set;
        }
        private int ReturningFlights
        {
            get;
            set;
        }
        public GradProg.GradProg ProgressBar
        {
            get;
            set;
        }


        public System.Windows.Forms.Timer Timer
        {
            get;
            set;
        }


        public Panel DepartureFlightsPanel
        {
            get;
            set;


        }

        public Panel ReturningFlightsPanel
        {
            get;
            set;

        }
        public Panel InterJetProcessButtonPanel
        {
            get;
            set;

        }

        public Label ProgressLabel
        {
            get;
            set;
        }

        public Label FareRuleLabel
        {
            get;
            set;
        }

        public Label FareRuleTitleLabel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var interJetSession = (InterJetSession)(this.CurrentUserControl.Parameter);
                if (interJetSession != null)
                {
                    return interJetSession.Session;
                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// Gets or sets the main group box.
        /// </summary>
        /// <value>
        /// The main group box.
        /// </value>
        public GroupBox MainGroupBox
        {
            get;
            set;
        }


        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        private void SetToolTip()
        {

            this.ToolTiper.SetToolTip(this.CancelInterJetProcessButton, "Crear una nueva reservación.");
            this.ToolTiper.SetToolTip(this.ContinueWithPricing, "Continuar con la cotización de vuelos.");
            this.ToolTiper.SetToolTip(this.NewAvailabilityButton, "Agregar otro segmento en la reservación.");
        }


        /// <summary>
        /// Almacena una instancia del backgroundwork
        /// </summary>
        private BackgroundWorker backGroundWorker;
        /// <summary>
        /// Obtiene una instancia del backgroundworker que realiza la peticion de los vuelos asincronos
        /// 
        /// </summary>
        private BackgroundWorker BackgroundWorker
        {
            get
            {

                return this.backGroundWorker;
            }
            set { this.backGroundWorker = value; }
        }


        /// <summary>
        /// Starts the back ground worker.
        /// </summary>
        private void StartBackGroundWorker()
        {


            this.BackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Initializes the back ground.
        /// </summary>
        public void InitializeBackGround()
        {

            InitializeTriggerWorker();
            BackgroundWorker = new BackgroundWorker { };
            BackgroundWorker.DoWork += (backGroundWorker_DoWork);
            BackgroundWorker.RunWorkerCompleted +=
                (backGroundWorker_RunWorkerCompleted);
            TrigeerWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Stops the back ground worker.
        /// </summary>
        private void StopBackGroundWorker()
        {
            BackgroundWorker.DoWork -= backGroundWorker_DoWork;
            BackgroundWorker.RunWorkerCompleted -= backGroundWorker_RunWorkerCompleted;


        }


        private void test()
        {
            var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];
            var selectedFlights = (InterJetSelectedFlights)this.Session["SelectedFlights"];
            InterJetServiceManager.GetItineraryPrice(userInput, selectedFlights);
        }

        /// <summary>
        /// TODO: Verificar por que se queda colgado el user control y nunca se concluye.
        /// Se ejecuta cuando se termina de realizar la peticion asincrona.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //TODO: verificar.


                this.SegmentSelledCount.Text = this.SelledSegmentCount;
                this.StopBackGroundWorker();
                ucMenuReservations.EnabledMenu = true;
                IsWebServiceRuning = false;

                bool errorFound = e.Result is string;
                if (!errorFound)
                {
                    this.StopAnimationControls();
                    this.MainGroupBox.Visible = true;
                    this.FareRuleTitleLabel.Visible = false;
                    this.ProgressLabel.Visible = false;

                    this.DepartureFligthsDataGridView.DataSource = (List<InterJetFlight>)e.Result;
                }
                else
                {

                    if (e.Error is TimeoutException)
                    {

                        this.RecoverFromError();

                    }
                    else
                    {
                        string resultFromThread = (string)e.Result;
                        if (resultFromThread.Contains("LA RUTA INGRESADA NO CORRESPONDE"))
                        {

                            if (this.FlightManager.AvailabilityExist)
                            {
                                string message = string.Concat(e.Result.ToString(),
                                                               this.FlightManager.GetSuggestedConnections());
                                MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl,
                                                                "ucAvailability",
                                                                this.CurrentUserControl.Parameter, null);
                                this.CurrentUserControl.Dispose();
                            }
                            else
                            {
                                DialogResult result =
                                    MessageBox.Show(
                                        "La ruta no existe para interjet, por favor seleccione otra.\n".ToUpper() +
                                        "¿Desea mantener los segmentos vendidos previamente?\n".ToUpper(),
                                        Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information);
                                if (result == DialogResult.Yes)
                                {
                                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl,
                                                                    "ucAvailability",
                                                                    this.CurrentUserControl.Parameter, null);
                                    this.CurrentUserControl.Dispose();
                                }
                                else
                                {
                                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl,
                                                                    "ucAvailability",
                                                                    null, null);
                                    this.CurrentUserControl.Dispose();
                                }

                            }

                        }
                        else
                        {

                            DialogResult result = MessageBox.Show(e.Result.ToString(), Resources.Constants.MYCTS,
                                                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {

                                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl,
                                                                "ucAvailability",
                                                                this.CurrentUserControl.Parameter, null);
                            }
                        }
                    }

                }
            }
            catch
            {

                this.RecoverFromError();
            }
            finally
            {

                BackgroundWorker.Dispose();
                Timer.Dispose();
                ProgressBar.Dispose();
                GC.Collect();

            }


        }

        /// <summary>
        /// realiza el peticion de vuelos por media 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BindFlights(sender, e);
            CatStars2ndLevelBL.GetStars2ndLevel();


        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            LogProductivity.LogTransaction(Login.Agent, "1-Desplego Disponibilidad--InterJet");
            ucMenuReservations.EnabledMenu = false;
            //this.ShowPanels(false);
            //this.StartAnimationControls();
            //this.ProgressLabel.Visible = true;
            //this.FareRuleLabel.Visible = false;
            IsWebServiceRuning = true;
            ucAllQualityControls.globalPaxNumber = 0;
            ucAllQualityControls.counter = 0;
            this.SetToolTip();


        }

        public bool IsWebServiceRuning { get; set; }


        private BackgroundWorker _triggerWorker;

        private BackgroundWorker TrigeerWorker
        {

            get { return this._triggerWorker; }
            set { this._triggerWorker = value; }
        }

        /// <summary>
        /// Initializes the trigger worker.
        /// </summary>
        private void InitializeTriggerWorker()
        {
            TrigeerWorker = new BackgroundWorker();
            TrigeerWorker.DoWork += (TrigeerWorker_DoWork);
            TrigeerWorker.RunWorkerCompleted += (TrigeerWorker_RunWorkerCompleted);


        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the TrigeerWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void TrigeerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            }
            finally
            {
                this.StartBackGroundWorker();
                TrigeerWorker.DoWork -= (TrigeerWorker_DoWork);
                TrigeerWorker.RunWorkerCompleted -= (TrigeerWorker_RunWorkerCompleted);
                TrigeerWorker.Dispose();
            }
        }

        /// <summary>
        /// Handles the DoWork event of the TrigeerWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void TrigeerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2500);
        }


        /// <summary>
        /// Loads the inter jet passanger capture form control.
        /// </summary>
        public void LoadInterJetPassangerCaptureFormControl()
        {

            // Verificar sí existe una selección del vuelo en el datagridview
            InterJetFlight interJetselectedFlight = this.GetInterJetSelection();

            bool thereIsNoSelectedFlight = (interJetselectedFlight == null && this.Session["SelectedFlights"] == null);

            if (thereIsNoSelectedFlight)
            {
                throw new Exception("POR FAVOR SELECCIONE EL VUELO DESEADO ANTES DE CONTINUAR CON LA CAPTURA DE LA INFORMACIÓN.");
            }


            //Verificar sí existe en session vuelos previamente seleccionados
            if (this.Session["SelectedFlights"] != null)
            {
                // si existe bajar los vuelos previamente seleccionados 
                var selectedFlights = (InterJetSelectedFlights)this.Session["SelectedFlights"];
                // añadir en la lista de vuelos seleccionados
                selectedFlights.AddFlight(interJetselectedFlight);
                // actualizar session
                this.Session["SelectedFlights"] = selectedFlights;
            }
            else
            {
                var selectedFlights = new InterJetSelectedFlights();
                selectedFlights.AddFlight(interJetselectedFlight);
                this.Session["SelectedFlights"] = selectedFlights;

            }
            //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetPassangerCaptureForm", this.CurrentUserControl.Parameter, null);
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetPreviousPrincingContainerControl", this.CurrentUserControl.Parameter, null);
        }


        #endregion
        #region Constants

        private const int CHECKBOX_COLUMN = 0;
        #endregion

        #region Constructor

        public InterJetAvailabilityOfFlightsHandler()
        {


        }
        #endregion


        public RichTextBox FareTextBox
        {
            get;
            set;
        }
        public PictureBox PictureBox
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        private InterJetFlightManager _flightManager;

        /// <summary>
        /// Gets the flight manager.
        /// </summary>
        private InterJetFlightManager FlightManager
        {
            get
            {
                return this._flightManager ?? (this._flightManager = new InterJetFlightManager());
            }
        }
        #region Handlers de eventos
        /// <summary>
        /// Enlaza los datos datgridviews con su respectivo Datasources
        /// </summary>
        public void BindFlights(object sender, DoWorkEventArgs e)
        {


            var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];
            if (userInput != null)
            {

                if (this.FlightManager.IsPointToPoint(userInput.DepartureStation, userInput.ArrivalStation))
                {
                    InterJetFlightsAvailability interJetAvailability =
                        InterJetServiceManager.GetAvailability(userInput);
                    if (interJetAvailability != null)
                    {
                        if (interJetAvailability.HasDepartureFlights)
                        {
                            this.DepartureInformationLabel.Text = userInput.DepartureFlightInformation;
                            this.DepartureIntineraryInformationLabel.Text =
                                userInput.DepartureFlightIntineraryInformation;
                            e.Result = interJetAvailability.GetDepartureFlights();
                        }
                        else
                        {
                            e.Result = "NO SE ENCONTRARON VUELOS DISPONIBLES, POR FAVOR INTENTE EN OTRAS FECHAS.";
                            //throw new Exception("NO SE ENCONTRARON VUELOS DISPONIBLES, POR FAVOR INTENTE EN OTRAS FECHAS.");
                        }
                    }

                }
                else
                {
                    e.Result =
                        "LA RUTA INGRESADA NO CORRESPONDE A UN VUELO PUNTO A PUNTO; SOLICITE DISPONIBILIDAD VÍA LAS OPCIONES:\n\n";
                    // throw new DestinationNotFoundException("LA RUTA INGRESADA NO CORRESPONDE A UN VUELO PUNTO A PUNTO; SOLICITE DISPONIBILIDAD VÍA LAS OPCIONES:\n\n");



                }
            }
        }






        /// <summary>
        /// Enlaza los datos datgridviews con su respectivo Datasources
        /// </summary>
        public List<InterJetFlight> BindFlights()
        {


            var userInput = (InterJetAvailabilityUserInput)Session["UserInput"];
            if (userInput != null)
            {

                if (FlightManager.IsPointToPoint(userInput.DepartureStation, userInput.ArrivalStation))
                {
                    InterJetFlightsAvailability interJetAvailability =
                        InterJetServiceManager.GetAvailability(userInput);
                    if (interJetAvailability != null)
                    {
                        if (interJetAvailability.HasDepartureFlights)
                        {
                            this.DepartureInformationLabel.Text = userInput.DepartureFlightInformation;
                            this.DepartureIntineraryInformationLabel.Text =
                                userInput.DepartureFlightIntineraryInformation;
                            return interJetAvailability.GetDepartureFlights();
                        }
                        else
                        {
                            return new List<InterJetFlight>();
                        }
                    }

                }
                else
                {

                    //e.Result =
                    //    "LA RUTA INGRESADA NO CORRESPONDE A UN VUELO PUNTO A PUNTO; SOLICITE DISPONIBILIDAD VÍA LAS OPCIONES:\n\n";
                    // throw new DestinationNotFoundException("LA RUTA INGRESADA NO CORRESPONDE A UN VUELO PUNTO A PUNTO; SOLICITE DISPONIBILIDAD VÍA LAS OPCIONES:\n\n");

                }
            }
            return new List<InterJetFlight>();
        }
        /// <summary>
        /// Handler del evento de seleccion de un vuelo.s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSelectedDepartureFlight(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.SelectionIsValid(e))
                {
                    this.UncheckCheckBoxColumns(this.DepartureFligthsDataGridView);
                    var dataGridViewCheckBoxCell =
                        this.DepartureFligthsDataGridView[
                            InterJetAvailabilityOfFlightsHandler.CHECKBOX_COLUMN, e.RowIndex] as
                        DataGridViewCheckBoxCell;
                    if (dataGridViewCheckBoxCell != null)
                    {
                        dataGridViewCheckBoxCell.Value = true;
                    }

                    this.FareTextBox.Rtf = InterJetServiceManager.GetFareRule(this.GetInterJetSelection());
                    this.FareRuleTitleLabel.Visible = true;
                    this.FareTextBox.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                             System.Drawing.FontStyle.Strikeout,
                                                                             System.Drawing.GraphicsUnit.Point,
                                                                             ((byte)(0)));

                    if (this.Session["SelectedFlights"] != null)
                    {
                        // si existe bajar los vuelos previamente seleccionados 
                        var selectedFlights = (InterJetSelectedFlights)this.Session["SelectedFlights"];
                        this.SegmentSelledCount.Text = (selectedFlights.GetFlights().Count + 1).ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        this.SegmentSelledCount.Text = "1";
                    }


                }
            }
            catch (Exception exception)
            {
                if (exception is TimeoutException)
                {

                    this.RecoverFromError();
                }


            }
        }

        public void OnSelectedReturningFlight(object sender, DataGridViewCellEventArgs e)
        {



            if (this.SelectionIsValid(e))
            {
                this.UncheckCheckBoxColumns(this.ReturningFligthsDataGridView);
                var dataGridViewCheckBoxCell = this.ReturningFligthsDataGridView[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
                if (dataGridViewCheckBoxCell != null)
                {
                    dataGridViewCheckBoxCell.Value = true;
                }
            }
        }




        public void CancelInterJetProcess()
        {

            Loader.AddToPanel(Loader.Zone.Middle, this.CurrentUserControl, "ucAvailability");
        }


        private string SelledSegmentCount
        {
            get
            {
                if (this.Session["SelectedFlights"] != null)
                {

                    // si existe bajar los vuelos previamente seleccionados 
                    var selectedFlights = (InterJetSelectedFlights)this.Session["SelectedFlights"];
                    // añadir en la lista de vuelos seleccionados
                    return selectedFlights.GetFlights().Count.ToString(CultureInfo.InvariantCulture);
                }

                return "0";
            }

        }

        /// <summary>
        /// Adds the new availability.
        /// </summary>
        public void AddNewAvailability()
        {
            // Verificar sí existe una selección del vuelo en el datagridview
            InterJetFlight interJetselectedFlight = this.GetInterJetSelection();
            //Verificar sí existe en session vuelos previamente seleccionados
            if (interJetselectedFlight != null)
            {
                if (this.Session["SelectedFlights"] != null)
                {
                    // si existe bajar los vuelos previamente seleccionados 
                    var selectedFlights = (InterJetSelectedFlights)this.Session["SelectedFlights"];
                    // añadir en la lista de vuelos seleccionados
                    selectedFlights.AddFlight(interJetselectedFlight);
                    // actualizar session
                    this.Session["SelectedFlights"] = selectedFlights;
                }
                else
                {
                    var selectedFlights = new InterJetSelectedFlights();
                    selectedFlights.AddFlight(interJetselectedFlight);
                    this.Session["SelectedFlights"] = selectedFlights;
                }
                this.Session["IsNewAvailability"] = true;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucAvailability", this.CurrentUserControl.Parameter, null);
                this.CurrentUserControl.Dispose();
            }
            else
            {
                throw new Exception("NO SE HA SELECCIONADO ALGUN VUELO, POR FAVOR SELECCIONE UNO ANTES DE CONTINUAR.");
            }

        }

        /// <summary>
        /// Gets the inter jet selection.
        /// </summary>
        /// <returns></returns>
        private InterJetFlight GetInterJetSelection()
        {
            foreach (DataGridViewRow row in this.DepartureFligthsDataGridView.Rows)
            {
                bool rowIsSelected = Convert.ToBoolean(row.Cells[InterJetAvailabilityOfFlightsHandler.CHECKBOX_COLUMN].Value);
                if (rowIsSelected)
                {
                    var interJetFlight = (this.DepartureFligthsDataGridView[InterJetAvailabilityOfFlightsHandler.CHECKBOX_COLUMN, row.Index].OwningRow.DataBoundItem as InterJetFlight);
                    return interJetFlight;
                }
            }
            return null;
        }


        #endregion

        #region Helpers

        private bool SelectionIsValid(DataGridViewCellEventArgs arguments)
        {
            return arguments.RowIndex >= 0 && arguments.ColumnIndex >= 0;
        }


        private void UncheckCheckBoxColumns(DataGridView dataGrid)
        {
            for (int rowIndex = 0; rowIndex < dataGrid.Rows.Count; rowIndex++)
            {
                var dataGridViewCheckBoxCell = dataGrid[0, rowIndex] as DataGridViewCheckBoxCell;
                if (dataGridViewCheckBoxCell != null)
                    dataGridViewCheckBoxCell.Value = false;
            }
        }


        /// <summary>
        /// Shows the panels.
        /// </summary>
        /// <param name="isVisible">if set to <c>true</c> [is visible].</param>
        public void ShowPanels(bool isVisible)
        {


            this.DepartureFlightsPanel.Visible = isVisible;
            this.ReturningFlightsPanel.Visible = false;
            this.InterJetProcessButtonPanel.Visible = isVisible;
            this.FareTextBox.Visible = isVisible;
            this.SegmentSelledLabel.Visible = isVisible;
            this.SegmentSelledCount.Visible = isVisible;
            this.PictureBox.Visible = isVisible;
            this.ShoopingCart.Visible = isVisible;
        }

        /// <summary>
        /// Stops the animation controls.
        /// </summary>
        private void StopAnimationControls()
        {
            //this.Timer.Enabled = false;
            //this.Timer.Stop();
            //this.ProgressBar.Visible = false;
            this.ProgressLabel.Visible = false;
            this.Loading.Visible = false;
            this.AirPlanePictureBoxOnLoading.Visible = false;

        }

        private void StartAnimationControls()
        {
            this.ProgressBar.Visible = true;
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Maximum = 100;
            this.ProgressBar.Percentage = 20;
            this.AirPlanePictureBoxOnLoading.Visible = true;

        }
        #endregion

        public override void RecoverFromError()
        {
            string msg = "Time out en disponibilidad de vuelos de interjet.";
            base.RecoverFromError(msg);
        }

    }
}
