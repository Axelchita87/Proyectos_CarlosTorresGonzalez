using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.Collections;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetPassangerCaptureUserControlHandler : InterJetUserControlHandler
    {

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<InterJetPassangerType, Func<InterJetPassanger>> _passangerFactory;

        /// <summary>
        /// Gets the passanger factory.
        /// </summary>
        private Dictionary<InterJetPassangerType, Func<InterJetPassanger>> PassangerFactory
        {
            get
            {
                if (this._passangerFactory == null)
                {
                    this._passangerFactory = new Dictionary<InterJetPassangerType, Func<InterJetPassanger>>();
                    this._passangerFactory.Add(InterJetPassangerType.Adult, () => new InterJetAdultPassanger());
                    this._passangerFactory.Add(InterJetPassangerType.Child, () => new InterJetChildPassanger());
                    this._passangerFactory.Add(InterJetPassangerType.Senior, () => new InterJetSeniorAdultPassanger());

                }
                return this._passangerFactory;

            }
        }

        /// <summary>
        /// Gets or sets the rese profile check box.
        /// </summary>
        /// <value>
        /// The rese profile check box.
        /// </value>
        public CheckBox ReseProfileCheckBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has A profile.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has A profile; otherwise, <c>false</c>.
        /// </value>
        public bool HasAProfile { get; set; }


        /// <summary>
        /// Sets the inter jet passanger.
        /// </summary>
        /// <param name="passanger">The passanger.</param>
        public void SetInterJetPassanger(InterJetPassanger passanger)
        {

            //TextBox clubInteJetTextBox = this.GetTextBoxByName("ClubInterJet");
            //clubInteJetTextBox.Text = passanger.InterJetClubCode;

            TextBox nameTextBox = this.GetTextBoxByName("Name_");
            nameTextBox.Text = passanger.Name;


            TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
            lastNameTextBox.Text = passanger.LastName;

            ComboBox titleComboBox = this.GetComboBoxByName("Title");
            titleComboBox.SelectedItem = passanger.Title;

            ComboBox suffixComboBox = this.GetComboBoxByName("Suffix");
            titleComboBox.SelectedItem = passanger.Suffix;

            CheckBox contactCheckBox = this.GetCheckBoxByName("Contact");
            contactCheckBox.Checked = passanger.IsTheContact;

            this.CurrentUserControl.DateOfBirth = passanger.DateOfBirth;


        }
        /// <summary>
        /// Sets the profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public void SetProfile(InterJetProfile profile)
        {

            if (profile != null)
            {


                TextBox nameTextBox = this.GetTextBoxByName("Name_");
                nameTextBox.Text = profile.Name;


                TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
                lastNameTextBox.Text = profile.LastName;

                this.CurrentUserControl.DateOfBirth = profile.BirthDay;


            }
        }


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            this.FillCombosBoxesWithData();
            BindEvents();
            SetTooltips();

        }

        /// <summary>
        /// Binds the events.
        /// </summary>
        private void BindEvents()
        {
            //this.ReseProfileCheckBox.CheckedChanged += new EventHandler(ReseProfileCheckBox_CheckedChanged);

        }

        /// <summary>
        /// Handles the CheckedChanged event of the ReseProfileCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ReseProfileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ReseProfileCheckBox.Checked)
            {

                this.HasAProfile = false;
                //TextBox clubInteJetTextBox = this.GetTextBoxByName("ClubInterJet");
                //clubInteJetTextBox.Text = "";

                TextBox nameTextBox = this.GetTextBoxByName("Name_");
                nameTextBox.Text = "";
                TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
                lastNameTextBox.Text = "";
                CheckBox contactCheckBox = this.GetCheckBoxByName("Contact");
                contactCheckBox.Checked = false;
                this.CurrentUserControl.ResetDatOfBirth();

            }
        }


        /// <summary>
        /// Sets the tooltips.
        /// </summary>
        private void SetTooltips()
        {

            //TextBox clubInteJetTextBox = this.GetTextBoxByName("ClubInterJet");
            //ToolTiper.SetToolTip(clubInteJetTextBox, "Cupon de InterJet.".ToUpper());

            TextBox nameTextBox = this.GetTextBoxByName("Name_");
            ToolTiper.SetToolTip(nameTextBox, "Nombre del Pasajero".ToUpper());



            TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
            ToolTiper.SetToolTip(lastNameTextBox, "Apellido del Pasajero".ToUpper());

            ComboBox titleComboBox = this.GetComboBoxByName("Title");
            ToolTiper.SetToolTip(titleComboBox, "Titulo del Pasajero".ToUpper());


            ComboBox suffixComboBox = this.GetComboBoxByName("Suffix");
            ToolTiper.SetToolTip(suffixComboBox, "Prefijo del Pasajero".ToUpper());
            CheckBox contactCheckBox = this.GetCheckBoxByName("Contact");
            ToolTiper.SetToolTip(contactCheckBox, "Seleccionar sí el pasajero sera el contacto".ToUpper());





        }

        /// <summary>
        /// Gets the passanger ID.
        /// </summary>
        private string PassangerID
        {
            get
            {
                return this.CurrentUserControl.PassangerID;
            }
        }

        /// <summary>
        /// OBtiene el pasajero y valida la selección.
        /// </summary>
        /// <returns></returns>
        public InterJetPassanger GetPassanger()
        {
            InterJetPassanger pax = this.PassangerFactory[this.CurrentUserControl.PassangerType]();

            //TextBox clubInteJetTextBox = this.GetTextBoxByName("ClubInterJet");
            //pax.InterJetClubCode = clubInteJetTextBox.Text;

            TextBox nameTextBox = this.GetTextBoxByName("Name_");
            this.ValidateTextBoxEmptyNess(nameTextBox, "NOMBRE", this.PassangerID);
            pax.Name = nameTextBox.Text;


            TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
            this.ValidateTextBoxEmptyNess(lastNameTextBox, "APELLIDO", this.PassangerID);
            pax.LastName = lastNameTextBox.Text;

            ComboBox titleComboBox = this.GetComboBoxByName("Title");
            this.ValidateComboBox(titleComboBox, "TITULO", this.PassangerID);

            pax.Title = titleComboBox.SelectedValue.ToString();

            ComboBox suffixComboBox = this.GetComboBoxByName("Suffix");
            pax.Suffix = suffixComboBox.SelectedItem.ToString();

            CheckBox contactCheckBox = this.GetCheckBoxByName("Contact"); // ClubInterJet
            pax.IsTheContact = contactCheckBox.Checked;

            //TextBox lclubInterJetTextBox = this.GetTextBoxByName("ClubInterJet");
            //pax.InterJetClubCode = lclubInterJetTextBox.Text;

            pax.DateOfBirth = this.CurrentUserControl.DateOfBirth;
            return pax;
        }



        /// <summary>
        /// Fills the combos boxes with data.
        /// </summary>
        private void FillCombosBoxesWithData()
        {

            ComboBox comboTitle = this.GetComboBoxByName("Title");
            comboTitle.DataSource = this.GetTitles();
            comboTitle.DisplayMember = "Text";
            comboTitle.ValueMember = "Value";
            ComboBox suffixCombo = this.GetComboBoxByName("Suffix");
            suffixCombo.DataSource = this.GetSuffix();

        }

        /// <summary>
        /// Gets the current user control.
        /// </summary>
        private ucInterJetPassangerCapture CurrentUserControl
        {
            get
            {

                return this.UserControl as ucInterJetPassangerCapture;
            }
        }

        /// <summary>
        /// Gets the suffix.
        /// </summary>
        /// <returns></returns>
        private string[] GetSuffix()
        {
            return new[] { "", "Jr" };
        }

        /// <summary>
        /// Validates the combo box.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="field">The field.</param>
        /// <param name="passangerID">The passanger ID.</param>
        private void ValidateComboBox(ComboBox comboBox, string field, string passangerID)
        {
            if (string.IsNullOrEmpty(comboBox.SelectedItem.ToString()))
            {
                comboBox.Focus();
                throw new Exception(string.Format("POR FAVOR CAPTURE EL CAMPO {0}, DEL PASAJERO {1}.", field, passangerID));
            }


        }

        /// <summary>
        /// Validates the text box empty ness.
        /// </summary>
        /// <param name="textBoxToValidate">The text box to validate.</param>
        /// <param name="field">The field.</param>
        /// <param name="passangerID">The passanger ID.</param>
        private void ValidateTextBoxEmptyNess(TextBox textBoxToValidate, string field, string passangerID)
        {
            if (string.IsNullOrEmpty(textBoxToValidate.Text))
            {

                ErrorProvider.SetError(textBoxToValidate, string.Format("POR FAVOR CAPTURE EL CAMPO {0}, DEL PASAJERO {1}.", field, passangerID));
                ErrorProvider.SetIconPadding(textBoxToValidate, 0);
                textBoxToValidate.Focus();
                throw new Exception(string.Format("POR FAVOR CAPTURE EL CAMPO {0}, DEL PASAJERO {1}.", field, passangerID));
            }


        }

        /// <summary>
        /// Gets the titles.
        /// </summary>
        /// <returns></returns>
        private ListItem[] GetTitles()
        {

            var titles = new List<ListItem>();

            titles.Add(new ListItem("Sr", "MR"));
            titles.Add(new ListItem("Sra", "MRS"));
            titles.Add(new ListItem("Srita", "MS"));
            titles.Add(new ListItem("Menor", "CHD"));
            return titles.ToArray();
        }

        public void ReturnToAvailability()
        {

            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.UserControl, "ucAvailability", this.UserControl.Parameter, null);

        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var session = (InterJetSession)this.CurrentUserControl.Parameter;
                if (session != null)
                {
                    return session.Session;
                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// Continues to payment.
        /// </summary>
        public void ContinueToPayment()
        {
            if (this.Session["UserInput"] != null)
            {
                var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];

                if (userInput.HasInfantPassanger)
                {
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetInfantCaptureForm", this.CurrentUserControl.Parameter, null);
                }
                else
                {
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetPaymentForm", this.CurrentUserControl.Parameter, null);
                }
            }


        }
    }
}
