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
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucVolarisContactPassangerCaptureFormulario : CustomUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private VolarisContactPassangerFormHandler _contactHandler;

        /// <summary>
        /// Gets the inter jet contact passanger form handler.
        /// </summary>
        private VolarisContactPassangerFormHandler InterJetContactPassangerFormHandler
        {
            get
            {

                if (this._contactHandler == null)
                {

                    this._contactHandler = new VolarisContactPassangerFormHandler
                    {
                        ContactPanel = this.ContactPanel,
                        ButtonPanel = this.buttonPanel,
                        ProgressBar = new GradProg.GradProg(),
                        LoadingLabel = this.loadingLabel,
                        SpecialServicePanel = this.SpecialServicePanel,
                        CurrentForm = this,
                        Timer = this.timer1,
                        MainGroupBox = this.contactGroupBox,
                        Loading = this.loadingPictureBox,
                        ContinueToSellButton = this.continueToSellButton,
                        BackToPassangerButton = this.backToPassangerControlButton


                    };
                }
                return this._contactHandler;
            }
        }



        /// <summary>
        /// Gets the contact panel.
        /// </summary>
        private Panel ContactPanel
        {
            get
            {
                return this.contactPanel;
            }
        }

        private Panel SpecialServicePanel
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ucInterJetContactPassangerCaptureForm"/> class.
        /// </summary>
        public ucVolarisContactPassangerCaptureFormulario()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);

        }


        /// <summary>
        /// Gets the countries.
        /// </summary>
        public static ListItem[] Countries
        {
            get
            {
                return VolarisContactPassangerFormHandler.Countries;
            }
        }


        /// <summary>
        /// Handles the Load event of the ucInterJetContactPassangerCaptureForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucInterJetContactPassangerCaptureForm_Load(object sender, EventArgs e)
        {
            FillCombo();
            InterJetContactPassangerFormHandler.Initialize();
            //contactStateComboBox.Focus();
        }

        private void FillCombo()
        {
            List<VolarisState> listState = VolarisStateBL.GetAllState();
            foreach (VolarisState stateItem in listState)
            {
                ListItem litem2 = new ListItem();
                litem2.Text = string.Format("{0} - {1}",
                    stateItem.StateID.ToString(),
                    stateItem.Name.ToString().TrimEnd());
                litem2.Value = stateItem.StateID.ToString();
                contactStateComboBox.Items.Add(litem2);
            }

            
            List<VolarisCountry> listCountries = VolarisCountriesBL.GetAllContries();
            foreach (VolarisCountry countryItem in listCountries)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    countryItem.Id,
                    countryItem.Name.TrimEnd());
                litem.Value = countryItem.Id;
                contactCountryComboBox.Items.Add(litem);
            }
        }

        private void backToPassangerControlButton_Click(object sender, EventArgs e)
        {
            this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
        }

        private void continueToSellButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactTitleComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as ComboBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactNameTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactLastNameTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void contactLastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactAddress1TextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactAddress1TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactAddress2TextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactAddress2TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactAddress3TextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactAddress3TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactCityTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactCityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    //this.contactStateComboBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactStateComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as ComboBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactCountryComboBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactCountryComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as ComboBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactPrimaryTelephoneTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactPrimaryTelephoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactAlternTelephoneTextbox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactAlternTelephoneTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactCellPhoneTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactCellPhoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void contactFaxTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactPostalCodeTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactPostalCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactEmailTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.contactEmailConfirmationTextBox.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();

                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contactEmailConfirmationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                InterJetContactPassangerFormHandler.ErrorProvider.SetError(textBox, "");
                if (Keys.Tab == e.KeyCode)
                {
                    this.continueToSellButton.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void continueToSellButton_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (Keys.Tab == e.KeyCode)
                {
                    this.continueToSellButton.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.ContinueWithSellProcessOrCaptureInfantInformation();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backToPassangerControlButton_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Keys.Tab == e.KeyCode)
                {
                    this.backToPassangerControlButton.Focus();
                }

                if (Keys.Enter == e.KeyCode)
                {
                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }

                if (Keys.Escape == e.KeyCode)
                {

                    this.InterJetContactPassangerFormHandler.LoadInterJetPassangerUserControl();
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {


                if (this.contactTitleComboBox.Focused)
                {
                    this.contactNameTextBox.Focus();
                    return true;
                }
                if (this.contactNameTextBox.Focused)
                {
                    this.contactLastNameTextBox.Focus();
                    return true;
                }
                if (this.contactLastNameTextBox.Focused)
                {
                    this.contactAddress1TextBox.Focus();
                    return true;
                }
                if (this.contactAddress1TextBox.Focused)
                {
                    this.contactAddress2TextBox.Focus();
                    return true;
                }

                if (this.contactAddress2TextBox.Focused)
                {

                    this.contactAddress3TextBox.Focus();
                    return true;

                }
                if (this.contactAddress3TextBox.Focused)
                {
                    this.contactCityTextBox.Focus();
                    return true;
                }

                if (this.contactCityTextBox.Focused)
                {
                    //this.contactStateComboBox.Focus();
                    return true;
                }

                //if (this.contactStateComboBox.Focused)
                //{
                //    this.contactCountryComboBox.Focus();
                //    return true;
                //}
                if (this.contactCountryComboBox.Focused)
                {
                    this.contactPrimaryTelephoneTextBox.Focus();
                    return true;
                }

                if (this.contactPrimaryTelephoneTextBox.Focused)
                {
                    this.contactAlternTelephoneTextbox.Focus();
                    return true;
                }
                if (this.contactAlternTelephoneTextbox.Focused)
                {
                    this.contactCellPhoneTextBox.Focus();
                    return true;
                }

                if (this.contactCellPhoneTextBox.Focused)
                {
                    this.contactFaxTextbox.Focus();
                    return true;
                }

                if (this.contactFaxTextbox.Focused)
                {
                    this.contactPostalCodeTextBox.Focus();
                    return true;
                }

                if (contactPostalCodeTextBox.Focused)
                {

                    this.contactEmailTextBox.Focus();
                    return true;
                }

                if (this.contactEmailTextBox.Focused)
                {
                    this.contactEmailConfirmationTextBox.Focus();
                    return true;
                }



            }

            return false;
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.InterJetContactPassangerFormHandler.HandleTimerTick();
        }

     

    }
}
