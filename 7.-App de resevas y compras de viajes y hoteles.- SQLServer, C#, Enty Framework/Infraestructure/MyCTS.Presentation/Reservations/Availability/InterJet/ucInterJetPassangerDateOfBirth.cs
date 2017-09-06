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

namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    public partial class ucInterJetPassangerDateOfBirth : CustomUserControl
    {

        private InterJetPassangerDateOfBirthUserControlHandler _handler;
        private InterJetPassangerDateOfBirthUserControlHandler Handler
        {
            get
            {
                if (this._handler == null)
                {
                    this._handler = new InterJetPassangerDateOfBirthUserControlHandler
                    {
                        UserControl = this

                    };

                }
                return this._handler;

            }
        }
        public void Clear()
        {
            this.Handler.Clear();

        }


        public ucInterJetPassangerDateOfBirth()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
        }

        private void ucInterJetPassangerDateOfBirth_Load(object sender, EventArgs e)
        {
            this.Handler.Initialize();
        }
        public DateTime DateOfBirth
        {

            get
            {

                return this.Handler.GetDateOfBirth;
            }
            set
            {
                this.Handler.SetDateOfBirth(value);
            }
        }

        public bool IsForInfant
        {
            get
            {

                return this.Handler.IsForInfant;
            }
            set
            {

                this.Handler.IsForInfant = value;
            }
        }

        private void daysCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.monthsCombo.Focus();
            }
        }

        private void monthsCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.yearsCombo.Focus();
            }
        }
    }
}
