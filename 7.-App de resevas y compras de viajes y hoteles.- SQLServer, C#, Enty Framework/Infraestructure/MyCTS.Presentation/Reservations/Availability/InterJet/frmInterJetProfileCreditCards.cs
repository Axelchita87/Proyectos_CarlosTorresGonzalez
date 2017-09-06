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
    public partial class frmInterJetProfileCreditCards : Form
    {


        /// <summary>
        /// 
        /// </summary>
        private InterJetProfileCreditCardsFormHandler _handler;
        /// <summary>
        /// Gets the handler.
        /// </summary>
        public InterJetProfileCreditCardsFormHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new InterJetProfileCreditCardsFormHandler
                                                   {

                                                       CurrentForm = this,
                                                       ButtonPanel = this.buttonPanel,
                                                       FristLevelGroupBox = this.groupFristLevel,
                                                       SecondLevelGroupBox = this.groupSecondLevel,
                                                       FristLevelComboBox = this.fristLevelCombo,
                                                       SecondLevelComboBox = this.secondLevelCombo,
                                                       FristLevelCheckBox = this.fristLevelCheckBox,
                                                       SecondLevelCheckBox = this.secondLevelCheckBox,
                                                       ConfirmButton = this.confirmButton,
                                                       DenyButton = this.denyButton

                                                   });
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmInterJetProfileCreditCards"/> class.
        /// </summary>
        public frmInterJetProfileCreditCards()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmInterJetProfileCreditCards control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void frmInterJetProfileCreditCards_Load(object sender, EventArgs args)
        {

            this.Handler.Intialize();

        }

        /// <summary>
        /// Sets the profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public void SetProfile(InterJetProfile profile)
        {
            this.Handler.SetProfile(profile);
        }

        /// <summary>
        /// Enables the options.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public void EnableOptions(InterJetProfile profile)
        {
            this.Handler.EnableOptions(profile);
        }

        /// <summary>
        /// Gets the selected credit card card.
        /// </summary>
        public InterJetProfileCreditCard SelectedCreditCardCard
        {
            get { return this.Handler.SelectedCreditCardCard; }
        }




    }
}
