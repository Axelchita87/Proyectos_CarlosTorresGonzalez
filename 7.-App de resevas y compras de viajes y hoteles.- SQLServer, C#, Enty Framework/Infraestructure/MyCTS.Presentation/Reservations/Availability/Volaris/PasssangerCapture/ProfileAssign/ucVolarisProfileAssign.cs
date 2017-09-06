using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.EventArguments;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.ContextSolver;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments;
using DevExpress.XtraEditors;

namespace MyCTS.Presentation
{
    public partial class ucVolarisProfileAssign : CustomUserControl, IVolarisProfileAssignView
    {
        public ucVolarisProfileAssign()
        {
            InitializeComponent();
        }



        #region Miembros de IVolarisProfileAssignView

        public string FristLevelProfile
        {
            get { return this.firstLevelProfile.Text; }
            set { this.firstLevelProfile.Text = value; }
        }

        /// <summary>
        /// Gets or sets the secon level profile.
        /// </summary>
        /// <value>
        /// The secon level profile.
        /// </value>
        public string SeconLevelProfile
        {
            get { return this.secondLevelProfileTextBox.Text; }
            set { this.secondLevelProfileTextBox.Text = value; }
        }

        /// <summary>
        /// Gets or sets the passanger list.
        /// </summary>
        /// <value>
        /// The passanger list.
        /// </value>
        public List<VolarisAdultPassanger> PassangerList
        {
            get
            {
                return (
                    from object item in passangers.Properties.Items
                    select
                    item as VolarisAdultPassanger).ToList();
            }
            set
            {
                if (value.Any())
                {
                    passangers.Properties.Items.AddRange(value);
                    passangers.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {
            if (!HasProfile)
            {
                ErrorProvider.SetError(this.firstLevelProfile, "Por favor asigne un perfil antes de continuar con el proceso.".ToUpper());
            }
            IsValid = profileInputValidator.Validate() && HasProfile;
        }

        public bool IsValid { get; set; }

        #endregion


        public EventHandler<OnRemoveProfileEventArgs> OnRemoveProfile { get; set; }
        /// <summary>
        /// Gets or sets the on click search profile.
        /// </summary>
        /// <value>
        /// The on click search profile.
        /// </value>
        public EventHandler<SearchProfileEventArgument> OnClickSearchProfile { get; set; }
        /// <summary>
        /// Gets or sets the on searching profile completed.
        /// </summary>
        /// <value>
        /// The on searching profile completed.
        /// </value>
        public EventHandler<OnSearchingProfileCompletedEventArgs> OnSearchingProfileCompleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private VolarisProfileAssignPresenter _presenter;
        /// <summary>
        /// Handles the Click event of the searchProfileButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void searchProfileButton_Click(object sender, EventArgs e)
        {

            if (profileInputValidator.Validate())
            {
                if (OnClickSearchProfile != null)
                {
                    var eventArguments = new SearchProfileEventArgument
                                             {
                                                 FristLevelProfile = this.firstLevelProfile.Text,
                                                 SecondLevelProfile = this.secondLevelProfileTextBox.Text,
                                                 Passanger = this.passangers.EditValue as VolarisAdultPassanger

                                             };
                    OnClickSearchProfile(sender, eventArguments);
                    this.EnableControls(false);
                    _presenter.SearchProfile(eventArguments);

                }
            }
        }

        private void ucVolarisProfileAssign_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisProfileAssignPresenter()
                             {
                                 View = this,
                                 Repository = new VolarisProfileAssignRepository(),
                                 Context = new VolarisProfileManagerWinForm()
                                               {
                                                   OnSearchingProfileCompleted = OnSearchingProfileCompletedSender
                                               }

                             };

        }


        public void EnableControls(bool enabled)
        {

            this.firstLevelProfile.Properties.ReadOnly = !enabled;
            this.secondLevelProfileTextBox.Properties.ReadOnly = !enabled;
            this.passangers.Properties.ReadOnly = !enabled;
            this.searchProfileButton.Enabled = enabled;
        }

        public void EnableUnAssignProfileButton(bool enabled)
        {
            this.removeProfile.Visible = enabled;
        }



        private void OnSearchingProfileCompletedSender(object sender, OnSearchingProfileCompletedEventArgs e)
        {
            if (OnSearchingProfileCompleted != null)
            {
                OnSearchingProfileCompleted(sender, e);
            }

            if (e.Found)
            {
                Profile = e.Profile;
                this.EnableUnAssignProfileButton(true);
            }
            else
            {
                ErrorProvider.SetError(this.firstLevelProfile, "No se encontro el perfil indicado por favor,verifique la información.".ToUpper());
                this.EnableControls(true);
                Profile = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the removeProfile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void removeProfile_Click(object sender, EventArgs e)
        {
            this.EnableControls(true);
            this.EnableUnAssignProfileButton(false);
            ClearControls();


            if (OnRemoveProfile != null)
            {
                OnRemoveProfile(sender, new OnRemoveProfileEventArgs
                                            {
                                                Passanger = this.passangers.SelectedItem as VolarisAdultPassanger,


                                            });

            }
            Profile = null;
        }

        private void ClearControls()
        {
            this.FristLevelProfile = "";
            this.SeconLevelProfile = "";

        }

        private void firstLevelProfile_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextEdit;
            ErrorProvider.SetError(textbox, "");
            profileInputValidator.RemoveControlError(textbox);
            if (textbox != null)
            {
                if (!string.IsNullOrEmpty(textbox.Text))
                {
                    this.SuspendLayout();
                    fristLevelProfilePredictive.BringToFront();
                    Common.SetListBoxStarsFirstLevel(textbox, this.fristLevelProfilePredictive, textbox.Text);
                    this.ResumeLayout();
                }
            }
        }

        private void secondLevelProfileTextBox_TextChanged(object sender, EventArgs e)
        {

            var textbox = sender as TextEdit;
            ErrorProvider.SetError(textbox, "");
            profileInputValidator.RemoveControlError(textbox);

            if (!string.IsNullOrEmpty(this.FristLevelProfile))
            {
                var textBoxSecondLevelProfile = sender as TextEdit;

                if (textBoxSecondLevelProfile != null)
                {
                    this.SuspendLayout();
                    Common.SetListBoxStarsSecondLevel(textBoxSecondLevelProfile, this.secondLevelProfilePredictive,
                                                      textBoxSecondLevelProfile.Text, Login.PCC, FristLevelProfile);
                    this.ResumeLayout();

                }

            }

        }

        #region Miembros de IVolarisProfileAssignView

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        public VolarisProfile Profile { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has profile.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has profile; otherwise, <c>false</c>.
        /// </value>
        public bool HasProfile
        {
            get { return Profile != null; }

        }

        #endregion

        /// <summary>
        /// Handles the KeyDown event of the firstLevelProfile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void firstLevelProfile_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePredective(fristLevelProfilePredictive, e);
        }

        /// <summary>
        /// Handles the predective.
        /// </summary>
        /// <param name="predective">The predective.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void HandlePredective(ListBox predective, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                predective.Visible = false;
                if (predective.Items.Count > 0)
                {
                    predective.Items.Clear();
                }

            }

            if (e.KeyCode == Keys.Down)
            {
                if (predective.Items.Count > 0)
                {
                    predective.Visible = true;
                    predective.Focus();
                    predective.SelectedIndex = 0;
                }
            }

            if (e.KeyCode == Keys.Tab)
            {
                if (predective.Items.Count > 0)
                {
                    predective.Items.Clear();

                }
                predective.Visible = false;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the secondLevelProfileTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void secondLevelProfileTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePredective(secondLevelProfilePredictive, e);
        }

        /// <summary>
        /// Handles the KeyDown event of the fristLevelProfilePredictive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void fristLevelProfilePredictive_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePredictiveEvent(fristLevelProfilePredictive, firstLevelProfile, e);
        }


        /// <summary>
        /// Sets the selection on predective.
        /// </summary>
        /// <param name="predictive">The predictive.</param>
        /// <param name="profileTextBox">The profile text box.</param>
        private void SetSelectionOnPredective(ListBox predictive, TextEdit profileTextBox)
        {
            var selectedItem = predictive.SelectedItem as ListItem;
            if (selectedItem != null)
            {
                profileTextBox.Text = selectedItem.Value;
                predictive.Visible = false;
                if (predictive.Items.Count > 0)
                {
                    predictive.Items.Clear();

                }
                profileTextBox.Focus();
            }
        }
        /// <summary>
        /// Handles the predictive event.
        /// </summary>
        /// <param name="predictive">The predictive.</param>
        /// <param name="profileTextBox">The profile text box.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void HandlePredictiveEvent(ListBox predictive, TextEdit profileTextBox, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SetSelectionOnPredective(predictive, profileTextBox);
            }

            if (e.KeyCode == Keys.Tab)
            {
                SetSelectionOnPredective(predictive, profileTextBox);
            }

        }

        /// <summary>
        /// Handles the KeyDown event of the secondLevelProfilePredictive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void secondLevelProfilePredictive_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePredictiveEvent(secondLevelProfilePredictive, secondLevelProfileTextBox, e);
        }

        /// <summary>
        /// Handles the MouseClick event of the fristLevelProfilePredictive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void fristLevelProfilePredictive_MouseClick(object sender, MouseEventArgs e)
        {
            SetSelectionOnPredective(fristLevelProfilePredictive, firstLevelProfile);
        }

        /// <summary>
        /// Handles the MouseClick event of the secondLevelProfilePredictive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void secondLevelProfilePredictive_MouseClick(object sender, MouseEventArgs e)
        {
            SetSelectionOnPredective(secondLevelProfilePredictive, secondLevelProfileTextBox);
        }


    }
}
