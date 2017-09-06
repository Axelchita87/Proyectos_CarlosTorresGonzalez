using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucInterJetPassangerConfirmationUserControl : CustomUserControl
    {

        private InterJetPassangerConfirmationUserControlHandler _handler;
        private InterJetPassangerConfirmationUserControlHandler Handler
        {
            get
            {

                if (this._handler == null)
                {
                    this._handler = new InterJetPassangerConfirmationUserControlHandler
                    {

                        UserControl = this
                    };
                }
                return this._handler;
            }
        }


        public ucInterJetPassangerConfirmationUserControl()
        {
            InitializeComponent();
        }

        public void SetPassanger(InterJetPassanger pax)
        {
            this.Handler.SetPassanger(pax);
        }
    }
}
