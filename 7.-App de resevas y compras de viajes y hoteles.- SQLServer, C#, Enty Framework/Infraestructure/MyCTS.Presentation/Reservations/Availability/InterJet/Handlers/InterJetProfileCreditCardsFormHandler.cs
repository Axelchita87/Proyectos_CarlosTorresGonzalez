using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetProfileCreditCardsFormHandler : InterJetFormHandler
    {

        /// <summary>
        /// Gets or sets the frist level group box.
        /// </summary>
        /// <value>
        /// The frist level group box.
        /// </value>
        public GroupBox FristLevelGroupBox { get; set; }
        /// <summary>
        /// Gets or sets the second level group box.
        /// </summary>
        /// <value>
        /// The second level group box.
        /// </value>
        public GroupBox SecondLevelGroupBox { get; set; }
        /// <summary>
        /// Gets or sets the button panel.
        /// </summary>
        /// <value>
        /// The button panel.
        /// </value>
        public Panel ButtonPanel { get; set; }
        /// <summary>
        /// Gets or sets the frist level combo box.
        /// </summary>
        /// <value>
        /// The frist level combo box.
        /// </value>
        public ComboBox FristLevelComboBox { get; set; }
        /// <summary>
        /// Gets or sets the second level combo box.
        /// </summary>
        /// <value>
        /// The second level combo box.
        /// </value>
        public ComboBox SecondLevelComboBox { get; set; }
        /// <summary>
        /// Gets or sets the frist level check box.
        /// </summary>
        /// <value>
        /// The frist level check box.
        /// </value>
        public CheckBox FristLevelCheckBox { get; set; }
        /// <summary>
        /// Gets or sets the second level check box.
        /// </summary>
        /// <value>
        /// The second level check box.
        /// </value>
        public CheckBox SecondLevelCheckBox { get; set; }
        /// <summary>
        /// Gets or sets the confirm button.
        /// </summary>
        /// <value>
        /// The confirm button.
        /// </value>
        public Button ConfirmButton { get; set; }
        /// <summary>
        /// Gets or sets the deny button.
        /// </summary>
        /// <value>
        /// The deny button.
        /// </value>
        public Button DenyButton { get; set; }
        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        public InterJetProfile Profile { get; set; }
        /// <summary>
        /// Gets or sets the get selected card.
        /// </summary>
        /// <value>
        /// The get selected card.
        /// </value>
        public InterJetProfileCreditCard SelectedCreditCardCard { get; set; }
        /// <summary>
        /// Intializes this instance.
        /// </summary>
        public void Intialize()
        {
            if (this.Profile != null)
            {
                this.EnableOptions(this.Profile);
            }
            SetToolTips();
            BindEvents();
        }
        /// <summary>
        /// Binds the events.
        /// </summary>
        public void BindEvents()
        {

            this.SecondLevelCheckBox.CheckedChanged += (SecondLevelCheckBox_CheckedChanged);
            this.FristLevelCheckBox.CheckedChanged += (FristLevelCheckBox_CheckedChanged);
            this.ConfirmButton.Click += (ConfirmButton_Click);
            this.DenyButton.Click += new EventHandler(DenyButton_Click);

        }
        /// <summary>
        /// Handles the Click event of the DenyButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void DenyButton_Click(object sender, EventArgs e)
        {

            this.CurrentForm.Close();

        }
        /// <summary>
        /// Handles the Click event of the ConfirmButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateSelection())
            {
                SetSelectedCreditCard();
                this.CurrentForm.Close();
            }
        }
        /// <summary>
        /// Sets the selected credit card.
        /// </summary>
        private void SetSelectedCreditCard()
        {
            if (this.FristLevelCheckBox.Checked)
            {
                this.SelectedCreditCardCard = this.FristLevelComboBox.SelectedItem as InterJetProfileCreditCard;
            }

            if (this.SecondLevelCheckBox.Checked)
            {
                this.SelectedCreditCardCard = this.SecondLevelComboBox.SelectedItem as InterJetProfileCreditCard;
            }
        }

        /// <summary>
        /// Validates the selection.
        /// </summary>
        /// <returns></returns>
        private bool ValidateSelection()
        {
            if (!IsFristLevelSelected && !IsSecondLevelSelected)
            {
                if (Profile.CreditCards.HasCreditCardsInFristLevel)
                {
                    ErrorProvider.SetError(FristLevelComboBox, "Seleccione la tarjeta de primer nivel que desee usar.");
                    return false;
                }

                if (Profile.CreditCards.HasCreditCardsInSecondLevel)
                {
                    ErrorProvider.SetError(SecondLevelComboBox, "Seleccione la tarjeta de segundo nivel que desee usar.");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is second level selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is second level selected; otherwise, <c>false</c>.
        /// </value>
        private bool IsSecondLevelSelected
        {
            get { return this.SecondLevelCheckBox.Checked; }


        }

        /// <summary>
        /// Gets a value indicating whether this instance is frist level selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is frist level selected; otherwise, <c>false</c>.
        /// </value>
        private bool IsFristLevelSelected
        {
            get { return this.FristLevelCheckBox.Checked; }
        }
        /// <summary>
        /// Handles the CheckedChanged event of the FristLevelCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void FristLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            if (this.FristLevelCheckBox.Checked)
            {
                if (SecondLevelComboBox.Enabled)
                {
                    if (this.SecondLevelCheckBox.Checked)
                    {
                        SecondLevelCheckBox.Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the SecondLevelCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SecondLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            if (SecondLevelCheckBox.Checked)
            {
                if (FristLevelComboBox.Enabled)
                {
                    if (FristLevelCheckBox.Checked)
                    {
                        FristLevelCheckBox.Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the tool tips.
        /// </summary>
        private void SetToolTips()
        {

        }

        /// <summary>
        /// Sets the profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public void SetProfile(InterJetProfile profile)
        {
            this.CurrentForm.Text = string.Format("Tarjetas de primer y segundo nivel del perfil :{0}",
                                                  profile.SecondLevelProfile);
            this.Profile = profile;
            var creditCards = profile.CreditCards;
            if (creditCards.GetCards().Any())
            {
                if (creditCards.HasCreditCardsInFristLevel)
                {
                    this.EnableFristLevelOptions(true);
                    this.BindFristLevelCards(profile.CreditCards);
                }
                if (creditCards.HasCreditCardsInSecondLevel)
                {
                    this.EnableSecondLevelOptions(true);
                    this.BindSecondLevelCards(profile.CreditCards);
                }
            }
        }

        /// <summary>
        /// Enables the options.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public void EnableOptions(InterJetProfile profile)
        {


            var creditCards = profile.CreditCards;
            if (creditCards.GetCards().Any())
            {
                if (creditCards.HasCreditCardsInFristLevel)
                {
                    this.EnableFristLevelOptions(true);
                }
                else
                {
                    this.EnableFristLevelOptions(false);
                }

                if (creditCards.HasCreditCardsInSecondLevel)
                {
                    this.EnableSecondLevelOptions(true);
                }
                else
                {
                    this.EnableSecondLevelOptions(false);
                }
            }
        }

        /// <summary>
        /// Binds the cards.
        /// </summary>
        /// <param name="cards">The cards.</param>
        /// <param name="comboToBind">The combo to bind.</param>
        private void BindCards(IEnumerable<InterJetProfileCreditCard> cards, ComboBox comboToBind)
        {
            if (cards.Any())
            {
                comboToBind.DataSource = cards;
                comboToBind.DisplayMember = "FullProtectedCard";
            }
        }

        /// <summary>
        /// Binds the frist level cards.
        /// </summary>
        /// <param name="cards">The cards.</param>
        private void BindFristLevelCards(InterJetProfileCreditCards cards)
        {

            this.BindCards(cards.GetFirstLevelCards(), this.FristLevelComboBox);
        }

        /// <summary>
        /// Binds the second level cards.
        /// </summary>
        /// <param name="cards">The cards.</param>
        private void BindSecondLevelCards(InterJetProfileCreditCards cards)
        {
            this.BindCards(cards.GetSecondLevelCards(), this.SecondLevelComboBox);

        }

        /// <summary>
        /// Enables the frist level options.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private void EnableFristLevelOptions(bool enable)
        {

            this.FristLevelComboBox.Enabled = enable;
            this.FristLevelCheckBox.Enabled = enable;

        }

        /// <summary>
        /// Enables the second level options.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private void EnableSecondLevelOptions(bool enable)
        {

            this.SecondLevelComboBox.Enabled = enable;
            this.SecondLevelCheckBox.Enabled = enable;
        }

        /// Recovers from error.
        /// </summary>
        public override void RecoverFromError()
        {
            throw new NotImplementedException();
        }
    }
}
