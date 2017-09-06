using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetFlightsResumeFormHandler
    {


        public Form MainForm
        {
            get;
            set;
        }

        public InterJetTicket Ticket
        {
            get;
            set;
        }

        public Panel PanelToResize
        {
            get;
            set;
        }

        public Label TotalToPayLabel
        {
            get;
            set;
        }


        private InterJetControlFactory _controlFactory;
        private InterJetControlFactory ControlFactory
        {
            get{
                if(this._controlFactory == null)
                {
                    this._controlFactory = new InterJetControlFactory();
                }
                return this._controlFactory;


            }
        }


        public void Initialize()
        {
            this.ControlFactory.CreateDynamicFlightResumeControls(this.Ticket, this.MainForm);
            this.ResizePanel();
            this.TotalToPayLabel.Text = string.Format("Total a pagar :{0}", this.Ticket.BalanceToPay.ToString("c"));

        }

        private void ResizePanel()
        {

            int displacementBetweenGroupBoxes = 190;

            int displacementNeeded = this.Ticket.DetailsMessages.Count;
            
            for (int displacementIndex = 1; displacementIndex < displacementNeeded; displacementIndex++)
            {
                this.PanelToResize.Location = new System.Drawing.Point(PanelToResize.Location.X, displacementBetweenGroupBoxes + (displacementIndex * displacementBetweenGroupBoxes));

            }


        }

        public void CloseForm(object sender,EventArgs e)
        {
            if (!this.MainForm.IsDisposed)
            {
                this.MainForm.Dispose();
            }
        }
    }
}
