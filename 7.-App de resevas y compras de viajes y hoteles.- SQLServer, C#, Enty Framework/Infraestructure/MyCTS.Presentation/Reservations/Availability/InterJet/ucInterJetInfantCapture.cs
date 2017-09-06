using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    public partial class ucInterJetInfantCapture : CustomUserControl
    {
        public ucInterJetInfantCapture()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
        }


        private InterJetInfantCaptureUserControlHandler _handler;
        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetInfantCaptureUserControlHandler Handler
        {

            get
            {
                return this._handler ?? (this._handler = new InterJetInfantCaptureUserControlHandler
                                                             {
                                                                 UserControl = this,
                                                                 InfantAgeLabel = this.fechaNacimientoLabel
                                                             });
            }
        }

        /// <summary>
        /// Handles the Load event of the InterJetInfantCaptureUserControlHandler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void InterJetInfantCaptureUserControlHandler_Load(object sender, EventArgs e)
        {
            this.Handler.Initialize();
            this.DateOfBirth.IsForInfant = true;
        }



        public InterJetPassangerInfant Infant
        {
            get
            {
                return this.Handler.Infant;
            }
            set
            {
                this.Handler.Infant = value;
            }
        }

        /// <summary>
        /// Gets or sets the infant date of birth.
        /// </summary>
        /// <value>
        /// The infant date of birth.
        /// </value>
        public DateTime InfantDateOfBirth
        {
            get
            {
                return this.DateOfBirth.DateOfBirth;
            }
            set
            {
                this.DateOfBirth.DateOfBirth = value;
            }
        }

        public ucInterJetPassangerDateOfBirth DateOfBirthControl
        {
            get { return this.DateOfBirth; }
        }


        public void WarnAboutPassangerSelected(string msg)
        {

            this.Handler.ErrorProvider.SetError(this.TravelWith, msg.ToUpper());

        }


        public KeyEventHandler KeyEventHandler
        {
            set
            {
                this.TravelWith.KeyDown += value;
                this.Name_.KeyDown += value;
                this.LastName.KeyDown += value;
                this.Title.KeyDown += value;
                this.Nationality.KeyDown += value;
                this.Gender.KeyDown += value;
                this.DateOfBirth.KeyDown += value;
            }
        }




        public string GroupBoxTitle
        {
            get
            {

                return this.infant.Text;
            }
            set
            {

                this.infant.Text = value;
            }

        }

        private void TravelWith_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {


                this.Title.Focus();
            }
        }

        private void Title_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.Name_.Focus();
            }

        }

        private void Name__KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.LastName.Focus();
            }
        }

        private void LastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.Nationality.Focus();
            }
        }

        private void Nationality_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.Gender.Focus();
            }
        }

        private void Gender_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.DateOfBirth.Focus();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {


                if (this.TravelWith.Focused)
                {
                    this.Title.Focus();
                    return true;
                }

                if (this.Title.Focused)
                {
                    this.Name_.Focus();
                    return true;
                }

                if (this.Name_.Focused)
                {
                    this.LastName.Focus();
                    return true;
                }

                if (this.LastName.Focused)
                {
                    this.Nationality.Focus();
                    return true;
                }

                if (this.Nationality.Focused)
                {

                    this.Gender.Focus();
                    return true;
                }
                if (this.Gender.Focused)
                {
                    this.DateOfBirth.Focus();
                    return true;
                }
            }
            return false;
        }

        private void TravelWith_SelectedValueChanged(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {

                this.Handler.ErrorProvider.SetError(control, "");
            }
        }

        private void DateOfBirth_Click(object sender, EventArgs e)
        {
            this.Handler.ErrorProvider.SetError(this.fechaNacimientoLabel, "");
        }

        private void DateOfBirth_Leave(object sender, EventArgs e)
        {
            DateOfBirth_Click(sender, e);
        }

        private void Name__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Name_.Text))
            {
                Name_.Text = Name_.Text.Trim();
                Name_.Text = Name_.Text.Replace(" ", string.Empty);
            }
        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LastName.Text))
            {
                LastName.Text = LastName.Text.Trim();
                LastName.Text = LastName.Text.Replace(" ", string.Empty);
            }
        }
    }
}
