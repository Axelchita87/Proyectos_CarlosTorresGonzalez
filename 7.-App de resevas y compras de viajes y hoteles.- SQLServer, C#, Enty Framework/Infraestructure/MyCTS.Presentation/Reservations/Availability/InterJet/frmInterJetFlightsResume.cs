using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    public partial class frmInterJetFlightsResume : Form
    {
        public frmInterJetFlightsResume()
        {
            InitializeComponent();
            this.groupBoxContainer.Visible = false;

        }


        public InterJetTicket PricedTicket
        {
            get;
            set;
        }
        private InterJetFlightsResumeFormHandler _handler;

        private InterJetFlightsResumeFormHandler Handler
        {
            get
            {
                if (this._handler == null)
                {
                    this._handler = new InterJetFlightsResumeFormHandler
                    {
                        MainForm = this,
                        Ticket = PricedTicket,
                        PanelToResize = OkPanel,
                         TotalToPayLabel = this.totalBalanceToPay

                    };
                }
                return this._handler;
            }
        }


        private void frmInterJetFlightsResume_Load(object sender, EventArgs arguments)
        {
            this.Handler.Initialize();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.Handler.CloseForm(sender, e);
        }



    }
}
