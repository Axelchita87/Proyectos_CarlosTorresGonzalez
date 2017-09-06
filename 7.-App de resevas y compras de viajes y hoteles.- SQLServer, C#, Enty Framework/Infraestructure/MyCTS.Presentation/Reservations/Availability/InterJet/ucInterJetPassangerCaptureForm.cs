using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Presentation.Components;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucInterJetPassangerCaptureForm : CustomUserControl
    {

        #region Propierties

        private GroupBox PassangerGroupBox
        {
            get
            {
                return this.passangerGroupBox;
            }
        }

        private Panel PassangersPanel
        {
            get
            {
                return null;
                //return this.passangerPanel;
            }
        }

        private Panel AdultsPanel
        {
            get
            {
                //return adultsPanel;
                return null;
            }
        }

        private Panel ChildrenPanel
        {
            get
            {
                //return this.childrenPanel;
                return null;
            }
        }

        private Panel SeniorPanel
        {
            get
            {
                //   return this.seniorsPanel;
                return null;
            }
        }

        private Panel FlowButtonPanel
        {
            get
            {
                return this.buttonsPanel;
            }
        }

        public static string FristLevelProfile { get; set; }
        public static string SecondLevelProfile { get; set; }
        public static bool IsReturn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private InterJetPassangerCaptureFormHandler _interJetPassangerCaptureFormHandler;
        /// <summary>
        /// 
        /// </summary>
        private InterJetPassangerCaptureFormHandler InterJetPassangerCaptureFormHandler
        {
            get
            {

                if (this._interJetPassangerCaptureFormHandler == null)
                {

                    this._interJetPassangerCaptureFormHandler = new InterJetPassangerCaptureFormHandler
                    {
                        PassangersPanel = this.PassangersPanel,
                        AdultsPanel = AdultsPanel,
                        ChildrenPanel = ChildrenPanel,
                        SeniorPanel = SeniorPanel,
                        FlowButtonPanel = this.FlowButtonPanel,
                        CurrentForm = this,
                        PassangerGroupBox = this.PassangerGroupBox,
                        NationalityComboBox = this.nationalityComboBox,
                        FirstLevelProfileTextBox = this.fristLevelProfileTextBox,
                        SecondLevelProfileTextBox = this.seconLevelProfileTextBox,
                        ProgressBar = this.progressbar,
                        Timer = this.timer1,
                        WaitingLabel = this.waitingLabel,
                        LookUpProfile = this.pictureBox1,
                        SearchButton = this.searchButton,
                        ProfileIcon = this.profilePictureBox,
                        Loading = this.loadingPictureBox,
                        ContinueToCaptureContactButton = this.continueToPaymentButton,
                        BackToAvailabilityButton = this.backToAvailabilityButton,
                        NationalityPanel = this.passangerNationalityPanel,
                        FristLevelLabel = this.fristLevelLabel,
                        RedDot = this.redDot


                    };
                }
                return this._interJetPassangerCaptureFormHandler;
            }
        }

        private Panel AdultPanelClone
        {
            get
            {
                return null;
            }

        }

        #endregion

        public ucInterJetPassangerCaptureForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// Handles the Load event of the ucInterJetPassangerCaptureForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetPassangerCaptureForm_Load(object sender, EventArgs e)
        {
            this.InterJetPassangerCaptureFormHandler.Initialize();
            if (IsReturn)
                this.InterJetPassangerCaptureFormHandler.SearchProfile();


        }

        /// <summary>
        /// Handles the Click event of the backToAvailabilityButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void backToAvailabilityButton_Click(object sender, EventArgs e)
        {

            this.InterJetPassangerCaptureFormHandler.DisplayInterJetAvailabilityForm();
        }

        /// <summary>
        /// Handles the Click event of the captureContactButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void captureContactButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.InterJetPassangerCaptureFormHandler.DisplayContactPassangerForm();
            }
            catch (Exception exception)
            {

                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of the pictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {

                this.InterJetPassangerCaptureFormHandler.SearchProfile();
            }
            catch (Exception exception)
            {

                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of the searchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void searchButton_Click(object sender, EventArgs e)
        {

            try
            {

                this.InterJetPassangerCaptureFormHandler.SearchProfile();
            }
            catch (Exception exception)
            {

                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the fristLevelProfileTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void fristLevelProfileTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            var textbox = sender as TextBox;
            InterJetPassangerCaptureFormHandler.ErrorProvider.SetError(textbox, "");
            if (e.KeyCode == Keys.Enter)
            {
                this.profilePredictivList.Visible = false;
                if (profilePredictivList.Items.Count > 0)
                {
                    profilePredictivList.Items.Clear();
                }

            }

            if (e.KeyCode == Keys.Down)
            {
                if (profilePredictivList.Items.Count > 0)
                {
                    profilePredictivList.Visible = true;
                    profilePredictivList.Focus();
                    profilePredictivList.SelectedIndex = 0;


                }

            }

            if (e.KeyCode == Keys.Tab)
            {

                if (profilePredictivList.Items.Count > 0)
                {
                    profilePredictivList.Items.Clear();
                }
                profilePredictivList.Visible = false;
                this.seconLevelProfileTextBox.Focus();

            }


        }

        /// <summary>
        /// Handles the KeyDown event of the seconLevelProfileTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void seconLevelProfileTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox != null)
            {

                InterJetPassangerCaptureFormHandler.ErrorProvider.SetError(textbox, "");
            }
            if (e.KeyCode == Keys.Down)
            {


                if (secondLevelProfilePredictive.Items.Count > 0)
                {

                    secondLevelProfilePredictive.Visible = true;
                    secondLevelProfilePredictive.SelectedIndex = 0;
                    secondLevelProfilePredictive.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (secondLevelProfilePredictive.SelectedItem != null)
                {
                    var listItem = secondLevelProfilePredictive.SelectedItem as ListItem;
                    if (listItem != null)
                    {
                        seconLevelProfileTextBox.Text = listItem.Value;
                    }
                }

                if (secondLevelProfilePredictive.Items.Count > 0)
                {
                    secondLevelProfilePredictive.Items.Clear();

                }
                secondLevelProfilePredictive.Visible = false;
                searchButton_Click(this.searchButton, null);
            }

            if (e.KeyCode == Keys.Tab)
            {

                if (secondLevelProfilePredictive.Items.Count > 0)
                {
                    secondLevelProfilePredictive.Items.Clear();

                }
                secondLevelProfilePredictive.Visible = false;
                searchButton.Focus();

            }
        }

        /// <summary>
        /// Handles the KeyDown event of the continueToPaymentButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void continueToPaymentButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                captureContactButton_Click(sender, null);

            }

            if (e.KeyCode == Keys.Escape)
            {

                backToAvailabilityButton_Click(sender, null);

            }
        }

        /// <summary>
        /// Handles the KeyDown event of the backToAvailabilityButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void backToAvailabilityButton_KeyDown(object sender, KeyEventArgs e)
        {
            continueToPaymentButton_KeyDown(sender, e);
        }

        /// <summary>
        /// Handles the TextChanged event of the fristLevelProfileTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void fristLevelProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                profilePredictivList.Items.Clear();

                Common.SetListBoxStarsFirstLevel(textBox, this.profilePredictivList, textBox.Text);

                this.profilePredictivList.BringToFront();
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the profilePredictivList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void profilePredictivList_MouseClick(object sender, MouseEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox != null)
            {

                var listItem = listBox.SelectedItem as ListItem;

                if (listItem != null)
                {
                    this.fristLevelProfileTextBox.Text = listItem.Value;
                }
                listBox.Visible = false;
                listBox.Items.Clear();
                fristLevelProfileTextBox.Focus();

            }
        }

        private void profilePredictivList_KeyDown(object sender, KeyEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox != null)
            {

                if (e.KeyCode == Keys.Enter)
                {
                    var listItem = listBox.SelectedItem as ListItem;

                    if (listItem != null)
                    {
                        this.fristLevelProfileTextBox.Text = listItem.Value;
                    }
                    listBox.Visible = false;
                    listBox.Items.Clear();
                    this.fristLevelProfileTextBox.Focus();

                }


                if (e.KeyCode == Keys.Tab)
                {
                    var listItem = listBox.SelectedItem as ListItem;

                    if (listItem != null)
                    {
                        this.fristLevelProfileTextBox.Text = listItem.Value;
                    }
                    listBox.Visible = false;
                    listBox.Items.Clear();
                    this.seconLevelProfileTextBox.Focus();
                }
            }
        }

        private void seconLevelProfileTextBox_TextChanged(object sender, EventArgs e)
        {


            var textBox = sender as TextBox;

            if (textBox != null)
            {
                this.secondLevelProfilePredictive.Items.Clear();
                if (!string.IsNullOrEmpty(this.fristLevelProfileTextBox.Text))
                {
                    Common.SetListBoxStarsSecondLevel(textBox, this.secondLevelProfilePredictive, textBox.Text,
                                                      Login.PCC,
                                                      this.fristLevelProfileTextBox.Text);
                }

            }
        }

        private void secondLevelProfilePredictive_MouseClick(object sender, MouseEventArgs e)
        {
            var list = sender as ListBox;

            if (list != null)
            {

                var selectedItem = list.SelectedItem as ListItem;
                seconLevelProfileTextBox.Text = selectedItem.Value;
                list.Visible = false;
                if (list.Items.Count > 0)
                {
                    list.Items.Clear();

                }


            }
        }

        private void secondLevelProfilePredictive_KeyDown(object sender, KeyEventArgs e)
        {

            var listBox = sender as ListBox;
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox.Items.Count > 0)
                {
                    if (listBox.SelectedItem != null)
                    {
                        var listItem = listBox.SelectedItem as ListItem;
                        seconLevelProfileTextBox.Text = listItem.Value;
                        listBox.Visible = false;
                        listBox.Items.Clear();
                    }
                }


            }

            if (e.KeyCode == Keys.Tab)
            {
                if (listBox.Items.Count > 0)
                {

                    if (listBox.SelectedItem != null)
                    {
                        var listItem = listBox.SelectedItem as ListItem;
                        seconLevelProfileTextBox.Text = listItem.Value;
                        listBox.Visible = false;
                        listBox.Items.Clear();
                    }

                }

            }
        }
    }
}
