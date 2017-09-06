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
using MyCTS.Presentation.Reservations.Availability.Volaris.Handler;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.VolarisFlow
{
    public partial class ucVolarisPassengerOnly : CustomUserControl
    {
        private VolarisPassangerCaptureUserControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private VolarisPassangerCaptureUserControlHandler Handler
        {
            get
            {
                return this._handler ?? (this._handler = new VolarisPassangerCaptureUserControlHandler
                                                             {
                                                                 UserControl = this,
                                                                 
                                                             });
            }
        }


        public bool HasAProfile
        {
            set { this.Handler.HasAProfile = value; }
            get { return this.Handler.HasAProfile; }
        }

        /// <summary>
        /// Sets the key event handler.
        /// </summary>
        /// <value>
        /// The key event handler.
        /// </value>
        public KeyEventHandler KeyEventHandler
        {
            set
            {
                this.LastName.KeyDown += value;
                this.Name_.KeyDown += value;
                this.Title.KeyDown += value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetPassangerType _paxType;
        /// <summary>
        /// Gets or sets the type of the passanger.
        /// </summary>
        /// <value>
        /// The type of the passanger.
        /// </value>
        public InterJetPassangerType PassangerType
        {
            get
            {
                return this._paxType;
            }
            set
            {
                this._paxType = value;
                if (this._paxType == InterJetPassangerType.Child)
                {
                    this.IsAChild = true;
                }
            }
        }

        public bool IsAChild
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetPassangerCapture"/> class.
        /// </summary>
        public ucVolarisPassengerOnly()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

        }

        private void ucVolarisPassengerCapture_Load(object sender, EventArgs e)
        {
            this.Handler.Initialize();
            //this.dateOfBirthUserControl.IsForInfant = false;
            lblInfante.Visible = VolarisSession.Infant;
            lblAscInfate.Visible = VolarisSession.Infant;
            cmbTripInfant.Visible = VolarisSession.Infant;
        }

        /// <summary>
        /// Gets the error provider.
        /// </summary>
        public ErrorProvider ErrorProvider
        {
            get { return this.Handler.ErrorProvider; }
        }
        private InterJetPassanger passanger;
        /// <summary>
        /// Gets or sets the passanger.
        /// </summary>
        /// <value>
        /// The passanger.
        /// </value>
        public InterJetPassanger Passanger
        {
            get
            {
                this.passanger = this.Handler.GetPassanger();
                return this.passanger;
            }
            set
            {
                if (value != null)
                {
                    this.passanger = value;
                    this.Handler.SetInterJetPassanger(this.passanger);
                }
            }
        }

        public string PassangerID
        {
            get;
            set;
        }

        public string GroupBoxTitle
        {
            set
            {

                this.GroupBoxPassanger.Text = value;
            }
            get
            {
                return this.GroupBoxPassanger.Text;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {

                return this.dateOfBirthUserControl.DateOfBirth;
            }
            set
            {
                this.dateOfBirthUserControl.DateOfBirth = value;
            }
        }

        public void ResetDatOfBirth()
        {
            this.dateOfBirthUserControl.Clear();

        }
        /// <summary>
        /// Sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        public InterJetProfile Profile
        {
            set
            {
                this.Handler.SetProfile(value);
            }
        }

        public string GroupBoxTripInfant
        {
            set
            {
                this.cmbTripInfant.Text = value;
            }
            get
            {
                return this.cmbTripInfant.Text;
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
            var textbox = sender as TextBox;
            this.Handler.ErrorProvider.SetError(textbox, "");
            if (textbox != null)
            {
                if (Keys.Tab == e.KeyCode)
                {

                    LastName.Focus();
                }
            }
        }

        private void LastName_KeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;
            this.Handler.ErrorProvider.SetError(textbox, "");
            if (Keys.Tab == e.KeyCode)
            {
                this.dateOfBirthUserControl.Focus();
            }
        }

        private void cmbTripInfant_KeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;
            this.Handler.ErrorProvider.SetError(textbox, "");
            if (Keys.Tab == e.KeyCode)
            {
                this.Name_.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                bool preventFocus = false;
                if (this.Title.Focused && !preventFocus)
                {
                    this.Name_.Focus();
                    return true;
                }

                if (this.Name_.Focused && !preventFocus)
                {
                    this.LastName.Focus();
                    return true;
                }

                if (this.LastName.Focused && !preventFocus)
                {
                    this.dateOfBirthUserControl.Focus();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
