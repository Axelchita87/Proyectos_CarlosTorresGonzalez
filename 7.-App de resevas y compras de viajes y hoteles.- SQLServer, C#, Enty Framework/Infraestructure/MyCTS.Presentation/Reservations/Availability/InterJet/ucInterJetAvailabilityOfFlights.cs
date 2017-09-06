using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucInterJetAvailabilityOfFlights : CustomUserControl
    {




        #region Propierties

        private Label DepartureInformationLabel
        {
            get
            {
                return this.departureInformationLabel;

            }
        }






        private Label DepartureIntineraryInformationLabel
        {
            get
            {
                return this.departureIntineraryInformationLabel;
            }
        }


        private Label ReturningFlightInformation
        {
            get
            {
                return new Label();
            }
        }

        private Label ReturningIntineraryFlightInformation
        {
            get
            {
                return new Label();
            }
        }

        private Button CancelInterJetProcess
        {
            get
            {

                return this.cancelIntejerProcessButton;
            }
        }

        private Button ContinueInterJetProcessButton
        {
            get
            {
                return this.continueInterJetProcessButton;
            }
        }



        /// <summary>
        /// Obtiene el datagridview que almacena los vuelos de salida.
        /// </summary>
        private DataGridView DepartureFligthsDataGridView
        {
            get
            {
                return this.departureFlightsDataGrid;
            }

        }



        /// <summary>
        /// Obtiene el datagridview que almacena los vuelos de llegada
        /// </summary>
        private DataGridView ReturningFligthsDataGridView
        {
            get
            {
                return new DataGridView();
            }
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

        private GradProg.GradProg ProgressBar
        {
            get
            {
                return this.gradProg1;
            }
        }

        public System.Windows.Forms.Timer Timer
        {
            get
            {

                return this.timer1;
            }
        }


        private Panel DepartureFlightsPanel
        {
            get
            {
                return this.departureFlightsPanel;
            }
        }

        private Panel ReturningFlightsPanel
        {
            get { return new Panel(); }
        }
        private Panel InterJetProcessButtonPanel
        {
            get
            {

                return this.processButtonsPanel;
            }
        }

        private Label ProgressLabel
        {
            get
            {
                return this.progressLabel;

            }
        }

        private Label FareRuleLabel
        {
            get
            {
                return this.fareRuleTitleLabel;
            }
        }

        private RichTextBox FareTextBox
        {
            get
            {

                return this.richTextBox1;
            }
        }

        #endregion
        /// <summary>
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (this.InterJetAvailabilityOfFlightsHandler.IsWebServiceRuning)
            {
                if (ProcessObserver.HandleEvent(ref msg, keyData))
                {
                    return true;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
        /// 
        /// </summary>
        private InterJetAvailabilityOfFlightsHandler _interJetAvailabilityOfFlightsHandler;
        /// <summary>
        /// Gets the inter jet availability of flights handler.
        /// </summary>
        private InterJetAvailabilityOfFlightsHandler InterJetAvailabilityOfFlightsHandler
        {
            get
            {
                if (_interJetAvailabilityOfFlightsHandler == null)
                {
                    _interJetAvailabilityOfFlightsHandler = new InterJetAvailabilityOfFlightsHandler
                    {
                        ShoopingCart = this.pictureBox1,
                        DepartureFligthsDataGridView = this.DepartureFligthsDataGridView,
                        DepartureIntineraryInformationLabel = this.DepartureIntineraryInformationLabel,
                        DepartureInformationLabel = this.DepartureInformationLabel,
                        ReturningFlightInformation = this.ReturningFlightInformation,
                        ReturningIntineraryFlightInformation = this.ReturningIntineraryFlightInformation,
                        ReturningFligthsDataGridView = this.ReturningFligthsDataGridView,
                        ProgressBar = this.gradProg1,
                        Timer = this.timer1,
                        DepartureFlightsPanel = this.DepartureFlightsPanel,
                        ReturningFlightsPanel = this.ReturningFlightsPanel,
                        InterJetProcessButtonPanel = this.InterJetProcessButtonPanel,
                        ProgressLabel = this.ProgressLabel,
                        FareRuleLabel = this.FareRuleLabel,
                        MainGroupBox = this.MainGroupBox,
                        FareRuleTitleLabel = this.fareRuleTitleLabel,
                        CurrentUserControl = this,
                        FareTextBox = this.FareTextBox,
                        SegmentSelledCount = this.selledSegmentsCount,
                        SegmentSelledLabel = this.segmentSelled,
                        PictureBox = this.avionInterJetPictureBox,
                        CancelInterJetProcessButton = this.cancelIntejerProcessButton,
                        ContinueWithPricing = this.continueInterJetProcessButton,
                        NewAvailabilityButton = this.newAvailabilityButton,
                        AirPlanePictureBoxOnLoading = this.airPlaneLoadingPicture,
                        Loading = this.loadingPictureBox


                    };

                }
                return _interJetAvailabilityOfFlightsHandler;

            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetAvailabilityOfFlights"/> class.
        /// </summary>
        public ucInterJetAvailabilityOfFlights()
        {
            try
            {

                InitializeComponent();
                this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

                InterJetAvailabilityOfFlightsHandler.InitializeBackGround();
                InterJetAvailabilityOfFlightsHandler.Initialize();

            }
            catch (Exception exception)
            {
                InterJetAvailabilityOfFlightsHandler.RecoverFromError();
            }


        }


        /// <summary>
        /// Handles the Load event of the ucInterJetAvailabilityOfFlights control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetAvailabilityOfFlights_Load(Object sender, EventArgs e)
        {
            this.continueInterJetProcessButton.Focus();
        }
        /// <summary>
        /// Handles the CellContentClick event of the departureFlightsDataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void departureFlightsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InterJetAvailabilityOfFlightsHandler.OnSelectedDepartureFlight(sender, e);
        }
        /// <summary>
        /// Handles the CellContentClick event of the arrivalFlightsDataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void arrivalFlightsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                InterJetAvailabilityOfFlightsHandler.OnSelectedReturningFlight(sender, e);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void continueInterJetProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                InterJetAvailabilityOfFlightsHandler.LoadInterJetPassangerCaptureFormControl();
            }
            catch (Exception exception)
            {
                InterJetAvailabilityOfFlightsHandler.LogError("InterJet - Error en Disponibilidad de Vuelos - Boton Continuar.");
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelIntejerProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                InterJetAvailabilityOfFlightsHandler.CancelInterJetProcess();
            }
            catch (Exception exception)
            {
                InterJetAvailabilityOfFlightsHandler.LogError("InterJet - Error en Disponibilidad de Vuelos - Boton Cancelar.");
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(gradProg1.Percentage);
        }

        /// <summary>
        /// Handles the Click event of the newAvailabilityButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void newAvailabilityButton_Click(object sender, EventArgs e)
        {
            try
            {
                InterJetAvailabilityOfFlightsHandler.AddNewAvailability();
            }
            catch (Exception exception)
            {
                InterJetAvailabilityOfFlightsHandler.LogError("InterJet - Error en Disponibilidad de Vuelos - Boton Agregar nueva Disponibilidad.", false);
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the 1 event of the continueInterJetProcessButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void continueInterJetProcessButton_Click_1(object sender, EventArgs e)
        {

            try
            {
                InterJetAvailabilityOfFlightsHandler.LoadInterJetPassangerCaptureFormControl();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the cancelIntejerProcessButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void cancelIntejerProcessButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.cancelIntejerProcessButton_Click(sender, null);
            }
        }

        private void continueInterJetProcessButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.continueInterJetProcessButton_Click_1(sender, null);
            }
        }













    }
}
