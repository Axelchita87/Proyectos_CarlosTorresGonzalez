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
    public partial class ucInterJetPassangerConfirmationContainerControl : CustomUserControl
    {

        private InterJetPassangerConfirmationContainerUserControlHandler _handler;
        private InterJetPassangerConfirmationContainerUserControlHandler Handler
        {
            get
            {

                if (this._handler == null)
                {
                    this._handler = new InterJetPassangerConfirmationContainerUserControlHandler
                    {
                        UserControl = this

                    };
                }
                return this._handler;
            }
        }


        public ucInterJetPassangerConfirmationContainerControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        }


        public void SetPassanger(InterJetPassangers passangers)
        {

            this.Handler.SetPassangers(passangers);
        }


    }
}
