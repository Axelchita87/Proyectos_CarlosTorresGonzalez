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

namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    public partial class ucInterJetPassangerCapture : CustomUserControl
    {

        private InterJetPassangerCaptureUserControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private InterJetPassangerCaptureUserControlHandler Handler
        {
            get
            {
                return this._handler ?? (this._handler = new InterJetPassangerCaptureUserControlHandler
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

                this.Contact.KeyDown += value;
                this.LastName.KeyDown += value;
                this.Name_.KeyDown += value;
                this.Suffix.KeyDown += value;
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
                    this.contactLabel.Visible = false;
                    this.Contact.Visible = false;

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
        public ucInterJetPassangerCapture()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

        }


        /// <summary>
        /// Handles the Load event of the ucInterJetPassangerCapture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetPassangerCapture_Load(object sender, EventArgs e)
        {
            this.Handler.Initialize();
            this.dateOfBirthUserControl.IsForInfant = false;

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
                //this.passanger.ID = this.PassangerID;
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

        private void ClubInterJet_KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// Handles the KeyDown event of the Name_ control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
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
                this.Suffix.Focus();
            }
        }

        private void Suffix_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.Contact.Focus();
            }
        }

        private void Contact_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
                this.dateOfBirthUserControl.Focus();
            }

        }

        private void ClubInterJet_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                    this.Suffix.Focus();
                    return true;
                }
                if (this.Suffix.Focused && !preventFocus)
                {
                    this.Contact.Focus();
                    return true;
                }
                if (this.Contact.Focused && !preventFocus)
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
