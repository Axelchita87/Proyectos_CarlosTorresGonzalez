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

namespace MyCTS.Presentation
{
    public partial class ucInterJetBillEmission : CustomUserControl
    {

        private InterJetBillEmissionFormHandler _handler;

        private InterJetBillEmissionFormHandler Handler
        {
            get
            {
                this._handler = new InterJetBillEmissionFormHandler
                {
                    CurrentUserControl = this
                };
                return this._handler;
            }
        }


        public ucInterJetBillEmission()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.DoubleBuffer, true);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Handler.FinishReservation();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
