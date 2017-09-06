using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Windows.Forms;
using System.Drawing;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetReservationConfirmationFormHandler : InterJetFormHandler
    {



        public override void RecoverFromError()
        {
            
        }

        private InterJetControlFactory _controlFactory;
        /// <summary>
        /// Gets the control factory.
        /// </summary>
        private InterJetControlFactory ControlFactory
        {
            get
            {
                return this._controlFactory ?? (this._controlFactory = new InterJetControlFactory());
            }
        }

        private Panel MainPanel
        {
            get
            {

                return this.CurrentForm.Controls.Find("mainContainer", true).FirstOrDefault() as Panel;
            }
        }

        private GroupBox PassangerGroupBox
        {
            get
            {

                return this.MainPanel.Controls.Find("PassangerGroupBox", true).FirstOrDefault() as GroupBox;
            }
        }

        private Button AcceptButton
        {
            get
            {

                return this.MainPanel.Controls.Find("acceptButton", true).FirstOrDefault() as Button;
            }
        }
        private GroupBox SegmentsGroupBox
        {
            get
            {

                return this.MainPanel.Controls.Find("segmentsGroupBox", true).FirstOrDefault() as GroupBox;

            }
        }

        private Label EmissionTime
        {
            get
            {

                return this.MainPanel.Controls.Find("emissionTimeLabel", true).FirstOrDefault() as Label;
            }
        }

        private GroupBox FareGroupBox
        {
            get
            {

                return this.MainPanel.Controls.Find("fareGroupBox", true).FirstOrDefault() as GroupBox;

            }
        }

        public Timer Timer
        {
            get;
            set;
        }


        private Panel PaxPanel
        {
            get
            {

                return this.MainPanel.Controls.Find("paxPanel", true).FirstOrDefault() as Panel;
            }
        }

        private Panel FarePanel
        {
            get
            {

                return this.MainPanel.Controls.Find("farePanel", true).FirstOrDefault() as Panel;
            }
        }


        private Panel SegmentPanel
        {
            get
            {
                return this.MainPanel.Controls.Find("segmentPanel", true).FirstOrDefault() as Panel;
            }
        }


        /// <summary>
        /// Initializes the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        public void Initialize(InterJetTicket ticket)
        {
            if (this.MainPanel != null)
            {
                this.ControlFactory.CreateDynamicReservationResumeControls(MainPanel, ticket);
                this.ResizePanels(ticket);
                this.EmissionTime.Text = string.Format("Fecha:{0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
            }
        }

        /// <summary>
        /// Resizes the panels.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        private void ResizePanels(InterJetTicket ticket)
        {
            this.PassangerGroupBox.AutoSize = true;
            this.SegmentsGroupBox.AutoSize = true;
            this.FareGroupBox.AutoSize = true;

            this.PassangerGroupBox.PerformLayout();
            this.SegmentsGroupBox.PerformLayout();
            this.FareGroupBox.PerformLayout();

            int y_Displacement = this.PassangerGroupBox.Size.Height;
            this.SegmentsGroupBox.Location = new System.Drawing.Point(this.PassangerGroupBox.Location.X, this.PassangerGroupBox.Location.Y + y_Displacement);

            int yDisplacement = this.SegmentsGroupBox.Size.Height;
            this.FareGroupBox.Location = new System.Drawing.Point(this.PassangerGroupBox.Location.X, this.SegmentsGroupBox.Location.Y + yDisplacement);

            int y_ButtonDisplacement = this.FareGroupBox.Size.Height;
            this.AcceptButton.Location = new Point(this.AcceptButton.Location.X, this.FareGroupBox.Location.Y + y_ButtonDisplacement);

            this.PassangerGroupBox.PerformLayout();
            this.SegmentsGroupBox.PerformLayout();
            this.FareGroupBox.PerformLayout();

        }

        /// <summary>
        /// Handles the accept button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void HandleAcceptButtonClick(object sender, EventArgs e)
        {
            if (!this.CurrentForm.IsDisposed)
            {
                this.CurrentForm.Close();
                this.CurrentForm.Dispose();
            }
        }
    }
}
