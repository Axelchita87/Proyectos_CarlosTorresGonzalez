using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucInterJetReservationConfirmationContainerControl : CustomUserControl
    {


        /// <summary>
        /// 
        /// </summary>
        private InterJetReservationConfirmationContainerUserControlHandler _handler;
        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetReservationConfirmationContainerUserControlHandler Handler
        {
            get
            {
                return this._handler ?? (this._handler = new InterJetReservationConfirmationContainerUserControlHandler
                                                             {
                                                                 UserControl = this,
                                                                 Timer = this.timer1,
                                                                 ProgressBar = this.progressBar,
                                                                 WaitingLabel = this.waitingLabel,
                                                                 ReservationPictureBox = this.pictureBoxReservation,
                                                                 Loading = this.loadingPictureBox,
                                                                 ContinueButton = this.ContinueWithDkButton

                                                             });
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




        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetReservationConfirmationContainerControl"/> class.
        /// </summary>
        public ucInterJetReservationConfirmationContainerControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ucInterJetReservationConfirmationContainerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void ucInterJetReservationConfirmationContainerControl_Load(object sender, EventArgs e)
        {
            //this.button1.Visible = false;
            this.Handler.Initialize();
            this.ContinueWithDkButton.Focus();


        }

        /// <summary>
        /// Handles the Click event of the backToPassangerControlButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void backToPassangerControlButton_Click(object sender, EventArgs e)
        {
            //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucSeatAllocation",
            //                                                    this.Parameter, null);
            this.Handler.ContinueWithDk();
            this.ContinueWithDkButton.Focus();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetReservationConfirmationContainerControl", this.Parameter, null);
        }

        /// <summary>
        /// Handles the KeyDown event of the ContinueWithDkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void ContinueWithDkButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.Handler.ContinueWithDk();
            }
        }
    }
}
