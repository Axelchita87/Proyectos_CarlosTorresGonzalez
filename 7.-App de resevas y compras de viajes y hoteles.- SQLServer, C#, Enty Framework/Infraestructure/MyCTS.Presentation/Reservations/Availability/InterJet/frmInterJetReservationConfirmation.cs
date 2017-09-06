using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    public partial class frmInterJetReservationConfirmation : Form
    {

        private InterJetReservationConfirmationFormHandler _handler;
        private InterJetReservationConfirmationFormHandler Handler
        {
            get
            {

                if (this._handler == null)
                {
                    this._handler = new InterJetReservationConfirmationFormHandler
                    {
                         CurrentForm = this
                         

                    };
                }
                return this._handler;
            }
        }

        public InterJetTicket PricedTicket
        {
            get;
            set;
        }


        public frmInterJetReservationConfirmation()
        {
            InitializeComponent();
            this.groupBox1.Visible = false;
            this.passangerGroupBox.Visible = false;
            this.faresGroupBox.Visible = false;
            
        }

        public void frmInterJetReservationConfirmation_Load(object sender,EventArgs e)
        {
            this.Handler.Initialize(this.PricedTicket);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.Handler.HandleAcceptButtonClick(sender, e);
        }






    }
}
