using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.Handler
{
    public class VolarisContactPassangerFormHandler : InterJetUserControlHandler
    {

        private static InterJetServiceManager _interJetServiceManager;

        public Label LoadingLabel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the inter jet service manager.
        /// </summary>
        public InterJetServiceManager InterJetServiceManager
        {
            get { return _interJetServiceManager ?? (_interJetServiceManager = new InterJetServiceManager()); }
        }


        private InterJetControlFactory _interJetFactory;

        /// <summary>
        /// Gets the inter jet control factory.
        /// </summary>
        private InterJetControlFactory InterJetControlFactory
        {
            get { return this._interJetFactory ?? (this._interJetFactory = new InterJetControlFactory()); }
        }

        public PictureBox Loading { get; set; }


        private Hashtable Session
        {
            get
            {
                ucAvailability.IsInterJetProcess = true;
                if (CurrentForm.Parameter is InterJetSession)
                {
                    var session = (InterJetSession)this.CurrentForm.Parameter;

                    return session.Session;
                }
                return new Hashtable();
            }
        }

        public Panel ContactPanel
        {
            get;
            set;
        }

        public Panel SpecialServicePanel
        {
            get;
            set;
        }
        public CustomUserControl CurrentForm
        {
            get;
            set;
        }


        public Panel ButtonPanel
        {
            get;
            set;
        }

        private const string CONTACT_FIELD_FAUL = "POR FAVOR INDIQUE EL CAMPO {0} DEL CONTACTO.";

        /// <summary>
        /// Loads the inter jet passanger user control.
        /// </summary>
        public void LoadInterJetPassangerUserControl()
        {
            var sessionHash = this.Session;
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm, "ucVolarisPassangerCaptureFormulario", this.CurrentForm.Parameter, null);
        }


        /// <summary>
        /// Generates the ticket.
        /// </summary>
        /// <returns></returns>
        private InterJetTicket GenerateTicket()
        {
            var ticket = new InterJetTicket();
            //ticket.Flights = new InterJetFlights();
            ticket.Flights.AddFlights(((InterJetSelectedFlights)this.Session["SelectedFlights"]).GetFlights());
            ticket.Passangers = (InterJetPassangers)this.Session["Passangers"];
            ticket.Contact = (InterJetContact)this.Session["Contact"];
            ticket.Agent.Email = Login.Mail;
            ticket.Agent.Firm = Login.Firm;
            ticket.Agent.Pcc = Login.PCC;
            ticket.Agent.FullName = Login.NombreCompleto;
            ticket.Agent.ID = Login.Agent;
            ticket.Agent.Queue = Login.Queue;

            foreach (InterJetFlight flight in ticket.Flights.GetAllFlights())
            {

                flight.Ticket = ticket;
            }

            return ticket;
        }

        /// <summary>
        /// Continues the with sell process or capture infant information.
        /// </summary>
        public void ContinueWithSellProcessOrCaptureInfantInformation()
        {
            this.FillContactEntity();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm, "ucSummaryVolarisFormulario", this.CurrentForm.Parameter, null);
        }

        /// <summary>
        /// Gets the name of the smart text box by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private SmartTextBox GetSmartTextBoxByName(string name)
        {
            return this.GetControlByName(name) as SmartTextBox;
        }

        /// <summary>
        /// Gets the name of the combo box by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private ComboBox GetComboBoxByName(string name)
        {

            return this.GetControlByName(name) as ComboBox;

        }
        /// <summary>
        /// Gets the name of the button by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private Button GetButtonByName(string name)
        {
            return this.GetControlByName(name) as Button;
        }


        private Control GetControlByName(string name)
        {
            Control control = this.ContactPanel.Controls.Find(name, true).FirstOrDefault() as Control;
            if (control != null)
            {
                return control;
            }
            else
            {
                return new Control();
            }
        }

        /// <summary>
        /// Fills the contact entity.
        /// </summary>
        private void FillContactEntity()
        {
            var theContact = new InterJetContact();
            VolarisSession.Contacto = new ContactVolaris();

            ComboBox titleComboBox = this.GetComboBoxByName("contactTitleComboBox");
            this.ValidateComboBox(titleComboBox, "TITULO");
            theContact.Title = titleComboBox.SelectedValue.ToString();
            VolarisSession.Contacto.Title = theContact.Title;

            SmartTextBox nameTextBox = this.GetSmartTextBoxByName("contactNameTextBox");
            this.ValidateTextBox(nameTextBox, "NOMBRE");
            theContact.Name = nameTextBox.Text;
            VolarisSession.Contacto.FirstName = theContact.Name;

            SmartTextBox lastNameTextBox = this.GetSmartTextBoxByName("contactLastNameTextBox");
            this.ValidateTextBox(lastNameTextBox, "APELLIDO");
            theContact.LastName = lastNameTextBox.Text;
            VolarisSession.Contacto.LastName = theContact.LastName;

            SmartTextBox addres1TextBox = this.GetSmartTextBoxByName("contactAddress1TextBox");
            this.ValidateTextBox(addres1TextBox, "DIRECCION");
            theContact.Address1 = addres1TextBox.Text;
            VolarisSession.Contacto.Address = theContact.Address1;

            SmartTextBox addres2TextBox = this.GetSmartTextBoxByName("contactAddress2TextBox");
            theContact.Address2 = addres2TextBox.Text;
            VolarisSession.Contacto.Address = VolarisSession.Contacto.Address + " "+ theContact.Address2;

            SmartTextBox addres3TextBox = this.GetSmartTextBoxByName("contactAddress3TextBox");
            theContact.Address3 = addres3TextBox.Text;
            VolarisSession.Contacto.Address = VolarisSession.Contacto.Address + " " + theContact.Address3;

            SmartTextBox cityTextBox = this.GetSmartTextBoxByName("contactCityTextBox");
            this.ValidateTextBox(cityTextBox, "CUIDAD");
            theContact.City = cityTextBox.Text;
            VolarisSession.Contacto.City = theContact.City;

            ComboBox stateComboBox = this.GetComboBoxByName("contactStateComboBox");
            this.ValidateComboBox(stateComboBox, "ESTADO");
            theContact.State = stateComboBox.SelectedItem != null ? ((ListItem)stateComboBox.SelectedItem).Value : "";
            VolarisSession.Contacto.ProvinceState = theContact.State;

            SmartTextBox postalCodeTextBox = this.GetSmartTextBoxByName("contactPostalCodeTextBox");
            this.ValidateTextBox(postalCodeTextBox, "CODIGO POSTAL");
            theContact.PostalCode = postalCodeTextBox.Text;
            VolarisSession.Contacto.PostalCode = theContact.PostalCode;

            ComboBox countryTextComboBox = this.GetComboBoxByName("contactCountryComboBox");
            this.ValidateComboBox(countryTextComboBox, "PAIS");
            theContact.Country = countryTextComboBox.SelectedItem != null ? ((ListItem)countryTextComboBox.SelectedItem).Value : "";
            VolarisSession.Contacto.CountryCode = theContact.Country;

            SmartTextBox primaryTelephone = this.GetSmartTextBoxByName("contactPrimaryTelephoneTextBox");
            this.ValidateTextBox(primaryTelephone, "TELEFONO");
            theContact.PrimaryTelephone = primaryTelephone.Text;
            VolarisSession.Contacto.HomePhone = theContact.PrimaryTelephone;

            SmartTextBox alternTelephone = this.GetSmartTextBoxByName("contactAlternTelephoneTextbox");
            theContact.AlternTelephone = alternTelephone.Text;

            SmartTextBox cellPhoneTextBox = this.GetSmartTextBoxByName("contactCellPhoneTextBox");
            theContact.CellPhone = cellPhoneTextBox.Text;

            SmartTextBox faxTextBox = this.GetSmartTextBoxByName("contactFaxTextbox");
            theContact.Fax = faxTextBox.Text;

            SmartTextBox emailTextBox = this.GetSmartTextBoxByName("contactEmailTextBox");
            this.ValidateTextBox(emailTextBox, "EMAIL");
            this.ValidateEmailAddress(emailTextBox.Text, emailTextBox);
            theContact.Email = emailTextBox.Text.ToLower();
            VolarisSession.Contacto.Email = theContact.Email;

            SmartTextBox confirmationEmail = this.GetSmartTextBoxByName("contactEmailConfirmationTextBox");
            this.ValidateTextBox(confirmationEmail, "CONFIRMACION DE EMAIL");
            if (!theContact.Email.ToLower().Equals(confirmationEmail.Text.ToLower()))
            {
                confirmationEmail.Focus();
                ErrorProvider.SetError(confirmationEmail, "LA CONFIRMACION DEL EMAIL NO CONCUERDA CON EL EMAIL PROPORCIONADO.");
                throw new Exception("LA CONFIRMACION DEL EMAIL NO CONCUERDA CON EL EMAIL PROPORCIONADO.");
            }

            this.Session["Contact"] = theContact;
        }


        /// <summary>
        /// Validates the text box.
        /// </summary>
        /// <param name="theTextBox">The text box.</param>
        /// <param name="field">The field.</param>
        private void ValidateTextBox(TextBox theTextBox, string field)
        {
            if (string.IsNullOrEmpty(theTextBox.Text))
            {
                theTextBox.Focus();
                ErrorProvider.SetError(theTextBox, string.Format(VolarisContactPassangerFormHandler.CONTACT_FIELD_FAUL, field));
                throw new Exception(string.Format(VolarisContactPassangerFormHandler.CONTACT_FIELD_FAUL, field));
            }
        }

        /// <summary>
        /// Validates the email address.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="theTextBox">The text box.</param>
        private void ValidateEmailAddress(string email, TextBox theTextBox)
        {

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                  + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                  + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                  + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                  + @"[a-zA-Z]{2,}))$";
            var reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(email);
            if (!isStrictMatch)
            {
                theTextBox.Focus();
                ErrorProvider.SetError(theTextBox, "LA DIRECCIÓN DEL CORREO ELECTRONICO ES INCORRECTA, POR FAVOR VERIFIQUE");

                throw new Exception("LA DIRECCIÓN DEL CORREO ELECTRONICO ES INCORRECTA, POR FAVOR VERIFIQUE");

            }

        }

        /// <summary>
        /// Validates the combo box.
        /// </summary>
        /// <param name="theComboBox">The combo box.</param>
        /// <param name="field">The field.</param>
        private void ValidateComboBox(ComboBox theComboBox, string field)
        {
            if (string.IsNullOrEmpty(theComboBox.SelectedItem.ToString()))
            {
                theComboBox.Focus();
                throw new Exception(string.Format(VolarisContactPassangerFormHandler.CONTACT_FIELD_FAUL, field));
            }


        }

        /// <summary>
        /// 
        /// </summary>
        private CatCountriesBL _service;
        /// <summary>
        /// Gets the countries service.
        /// </summary>
        private CatCountriesBL CountriesService
        {
            get { return this._service ?? (this._service = new CatCountriesBL()); }
        }



        /// <summary>
        /// Gets the countrys.
        /// </summary>
        /// <returns></returns>
        private ListItem[] GetCountrys()
        {
            if (Countries == null)
            {
                Countries = this.CountriesService.GetCountries().ToArray();
            }
            return Countries;
        }

        public static ListItem[] Countries
        {
            get;
            set;
        }



        private CatInterJetStateBL _stateService;
        /// <summary>
        /// Gets the state service.
        /// </summary>
        private CatInterJetStateBL StateService
        {
            get { return this._stateService ?? (this._stateService = new CatInterJetStateBL()); }
        }


        private InterJetState[] GetStates()
        {
            return States ?? (States = this.StateService.GeStates().OrderBy(e => e.Name).ToArray());
        }


        public GradProg.GradProg ProgressBar
        {
            get;
            set;
        }

        public GroupBox MainGroupBox
        {
            get;
            set;
        }
        /// <summary>
        /// Stars the animation.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        public void StarAnimation(bool enabled)
        {


            this.MainGroupBox.Visible = !enabled;
            this.ButtonPanel.Visible = !enabled;
            //this.ProgressBar.Visible = enabled;
            this.Loading.Visible = enabled;
            this.LoadingLabel.Visible = enabled;
            //if (!enabled)
            //{

            //    this.Timer.Stop();
            //    this.Timer.Enabled = false;


            //}

        }

        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        /// <value>
        /// The timer.
        /// </value>
        public Timer Timer
        {
            get;
            set;
        }


        /// <summary>
        /// Handles the timer tick.
        /// </summary>
        public void HandleTimerTick()
        {

            //this.ProgressBar.Percentage = 10;
            //this.ProgressBar.SetProgComplete(ProgressBar.Percentage);
        }


        /// <summary>
        /// Gets or sets the countrys.
        /// </summary>
        /// <value>
        /// The countrys.
        /// </value>
        private ListItem[] Countrys
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>
        /// The states.
        /// </value>
        private InterJetState[] States
        {
            get;
            set;
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


        /// <summary>
        /// Pres the load.
        /// </summary>
        private void PreLoad(InterJetAgentContact agentContact)
        {
            //this.ProgressBar.Minimum = 0;
            //this.ProgressBar.Maximum = 100;
            //this.ProgressBar.Percentage = 20;

            ComboBox titleComboBox = this.ContactPanel.Controls.Find("contactTitleComboBox", true).FirstOrDefault() as ComboBox;
            if (titleComboBox != null)
            {

                titleComboBox.DataSource = this.GetTitles();
                titleComboBox.DisplayMember = "Text";
                titleComboBox.ValueMember = "Value";
            }

            //ComboBox countryComboBox = this.ContactPanel.Controls.Find("contactCountryComboBox", true).FirstOrDefault() as ComboBox;
            //if (countryComboBox != null)
            //{
            //    countryComboBox.DataSource = this.Countrys;
            //    countryComboBox.DisplayMember = "Text";
            //    countryComboBox.ValueMember = "Value";

            //    countryComboBox.SelectedValue = "MX";
            //}

            if (!HasAContact)
            {
                if (IsAnyPassangerIsContact)
                {
                    SetContactFromPassanger();
                }
                else
                {
                    SetAgentAsContact(agentContact);
                }
            }
            else
            {
                this.SetContact();
            }


        }

        /// <summary>
        /// Sets the agent as contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        private void SetAgentAsContact(InterJetAgentContact contact)
        {


            SmartTextBox nameTextBox = this.GetSmartTextBoxByName("contactNameTextBox");
            nameTextBox.Text = contact.Name;

            SmartTextBox lastNameTextBox = this.GetSmartTextBoxByName("contactLastNameTextBox");
            lastNameTextBox.Text = contact.LastName;

            SmartTextBox addres1TextBox = this.GetSmartTextBoxByName("contactAddress1TextBox");
            addres1TextBox.Text = contact.Address1;

            SmartTextBox addres2TextBox = this.GetSmartTextBoxByName("contactAddress2TextBox");
            addres2TextBox.Text = contact.Address2;

            SmartTextBox addres3TextBox = this.GetSmartTextBoxByName("contactAddress3TextBox");
            addres3TextBox.Text = contact.Address3;

            SmartTextBox cityTextBox = this.GetSmartTextBoxByName("contactCityTextBox");
            cityTextBox.Text = contact.City;

            //TODO : Estado from catlaogo?
            ComboBox stateComboBox = this.GetComboBoxByName("contactStateComboBox");
            stateComboBox.SelectedIndex= 8;

            SmartTextBox postalCodeTextBox = this.GetSmartTextBoxByName("contactPostalCodeTextBox");
            postalCodeTextBox.Text = contact.PostalCode;
            //TODO : country from catalogo?
            ComboBox countryTextComboBox = this.GetComboBoxByName("contactCountryComboBox");
            countryTextComboBox.SelectedIndex = 141;


            SmartTextBox primaryTelephone = this.GetSmartTextBoxByName("contactPrimaryTelephoneTextBox");
            primaryTelephone.Text = contact.PrimaryTelephone;

            SmartTextBox emailTextBox = this.GetSmartTextBoxByName("contactEmailTextBox");
            emailTextBox.Text = contact.Email;

            SmartTextBox confirmationEmail = this.GetSmartTextBoxByName("contactEmailConfirmationTextBox");
            confirmationEmail.Text = contact.Email;

        }

        /// <summary>
        /// Gets a value indicating whether this instance is any passanger is contact.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is any passanger is contact; otherwise, <c>false</c>.
        /// </value>
        private bool IsAnyPassangerIsContact
        {
            get
            {

                if (this.Session["Passangers"] != null)
                {


                    var passangers = (InterJetPassangers)this.Session["Passangers"];

                    if (passangers.GetAll().Any())
                    {

                        var pax = passangers.GetAll().FirstOrDefault(p => p.IsTheContact);

                        if (pax != null)
                        {

                            return true;
                        }

                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Sets the contact from passanger.
        /// </summary>
        private void SetContactFromPassanger()
        {

            if (this.Session["Passangers"] != null)
            {


                var passangers = (InterJetPassangers)this.Session["Passangers"];
                ComboBox titleComboBox =
                    this.ContactPanel.Controls.Find("contactTitleComboBox", true).FirstOrDefault() as ComboBox;
                if (titleComboBox != null)
                {
                    if (passangers.Contact != null)
                    {
                        titleComboBox.SelectedItem = passangers.Contact.Title;
                        var nameTextBox =
                            this.ContactPanel.Controls.Find("contactNameTextBox", true).FirstOrDefault() as
                            SmartTextBox;
                        nameTextBox.Text = passangers.Contact.Name;

                        var lastNameTextBox =
                            this.ContactPanel.Controls.Find("contactLastNameTextBox", true).FirstOrDefault() as
                            SmartTextBox;
                        lastNameTextBox.Text = passangers.Contact.LastName;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            LogProductivity.LogTransaction(Login.Agent, "4-Desplego Captura de contacto--Volaris");
            this.StarAnimation(true);
            this.SetToolTip();
            this.Worker.RunWorkerAsync();


        }

        private void SetToolTip()
        {

            ComboBox titleComboBox = this.GetComboBoxByName("contactTitleComboBox");
            this.ToolTiper.SetToolTip(titleComboBox, "Título del contacto".ToUpper());

            SmartTextBox nameTextBox = this.GetSmartTextBoxByName("contactNameTextBox");
            this.ToolTiper.SetToolTip(nameTextBox, "Nombre del contacto".ToUpper());

            SmartTextBox lastNameTextBox = this.GetSmartTextBoxByName("contactLastNameTextBox");
            this.ToolTiper.SetToolTip(lastNameTextBox, "Apellido del contacto".ToUpper());

            SmartTextBox addres1TextBox = this.GetSmartTextBoxByName("contactAddress1TextBox");
            this.ToolTiper.SetToolTip(addres1TextBox, "Dirección del contacto".ToUpper());

            SmartTextBox addres2TextBox = this.GetSmartTextBoxByName("contactAddress2TextBox");
            this.ToolTiper.SetToolTip(addres2TextBox, "Dirección del contacto".ToUpper());

            SmartTextBox addres3TextBox = this.GetSmartTextBoxByName("contactAddress3TextBox");
            this.ToolTiper.SetToolTip(addres3TextBox, "Dirección del contacto".ToUpper());


            SmartTextBox cityTextBox = this.GetSmartTextBoxByName("contactCityTextBox");
            this.ToolTiper.SetToolTip(cityTextBox, "Cuidad del contacto".ToUpper());

            //ComboBox stateTextComboBox = this.GetComboBoxByName("contactStateComboBox");
            //this.ToolTiper.SetToolTip(stateTextComboBox, "Estado del contacto".ToUpper());

            SmartTextBox postalCodeTextBox = this.GetSmartTextBoxByName("contactPostalCodeTextBox");
            this.ToolTiper.SetToolTip(postalCodeTextBox, "Codigo postal".ToUpper());

            ComboBox countryTextComboBox = this.GetComboBoxByName("contactCountryComboBox");
            this.ToolTiper.SetToolTip(countryTextComboBox, "País".ToUpper());


            SmartTextBox primaryTelephone = this.GetSmartTextBoxByName("contactPrimaryTelephoneTextBox");
            this.ToolTiper.SetToolTip(primaryTelephone, "Telefono primario del contacto".ToUpper());

            SmartTextBox alternTelephone = this.GetSmartTextBoxByName("contactAlternTelephoneTextbox");
            this.ToolTiper.SetToolTip(alternTelephone, "Telefono alterno del contacto".ToUpper());

            SmartTextBox cellPhoneTextBox = this.GetSmartTextBoxByName("contactCellPhoneTextBox");
            this.ToolTiper.SetToolTip(cellPhoneTextBox, "Celular del contacto".ToUpper());

            SmartTextBox faxTextBox = this.GetSmartTextBoxByName("contactFaxTextbox");
            this.ToolTiper.SetToolTip(faxTextBox, "Celular del contacto".ToUpper());

            SmartTextBox emailTextBox = this.GetSmartTextBoxByName("contactEmailTextBox");
            this.ToolTiper.SetToolTip(emailTextBox, "Email del contacto".ToUpper());

            SmartTextBox confirmationEmail = this.GetSmartTextBoxByName("contactEmailConfirmationTextBox");
            this.ToolTiper.SetToolTip(confirmationEmail, "Confirmación de email del contacto".ToUpper());


            this.ToolTiper.SetToolTip(ContinueToSellButton, "Click para continuar con la captura de la información".ToUpper());


            this.ToolTiper.SetToolTip(BackToPassangerButton, "Click para regresar a la captura de pasajeros".ToUpper());


        }


        public Button ContinueToSellButton { get; set; }
        public Button BackToPassangerButton { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _worker;

        /// <summary>
        /// Gets the worker.
        /// </summary>
        private BackgroundWorker Worker
        {
            get
            {
                if (this._worker == null)
                {
                    this._worker = new BackgroundWorker();
                    this._worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
                    this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
                }
                return _worker;
            }
        }

        public void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.PreLoad((InterJetAgentContact)e.Result);
            this.StarAnimation(false);
            ContinueToSellButton.Focus();

        }

        public void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //this.Countrys = this.GetCountrys();
            //this.GetStates();
            e.Result = this.GetAgentContact();
        }


        /// <summary>
        /// Gets the agent contact.
        /// </summary>
        /// <returns></returns>
        private InterJetAgentContact GetAgentContact()
        {

            Parameter parameter = ParameterBL.GetParameterValue("DireccionCTS");

            if (parameter != null)
            {
                string[] addresithPI = parameter.Values.Split('|');

                string[] names = Login.NombreCompleto.Split(' ');

                string name = "";
                string lastName = "";
                if (names.Length >= 3)
                {
                    name = names[0];
                    lastName = names[2];
                }
                else
                {
                    name = names[0];
                    lastName = names[1];
                }



                return new InterJetAgentContact
                {

                    Name = name,
                    LastName = lastName,
                    Email = Login.Mail,
                    Address1 = addresithPI[0],
                    Address2 = addresithPI[1],
                    Address3 = addresithPI[2],
                    City = addresithPI[3],
                    State = addresithPI[4],
                    Country = addresithPI[5],
                    PrimaryTelephone = addresithPI[6],
                    PostalCode = addresithPI[7]

                };

            }
            return new InterJetAgentContact();

        }


        /// <summary>
        /// Sets the contact.
        /// </summary>
        private void SetContact()
        {
            InterJetContact theContact = (InterJetContact)this.Session["Contact"];
            if (theContact != null)
            {
                ComboBox titleComboBox = this.GetComboBoxByName("contactTitleComboBox");
                titleComboBox.SelectedValue = theContact.Title;

                SmartTextBox nameTextBox = this.GetSmartTextBoxByName("contactNameTextBox");
                nameTextBox.Text = theContact.Name;

                SmartTextBox lastNameTextBox = this.GetSmartTextBoxByName("contactLastNameTextBox");
                lastNameTextBox.Text = theContact.LastName;

                SmartTextBox addres1TextBox = this.GetSmartTextBoxByName("contactAddress1TextBox");
                addres1TextBox.Text = theContact.Address1;

                SmartTextBox addres2TextBox = this.GetSmartTextBoxByName("contactAddress2TextBox");
                addres2TextBox.Text = theContact.Address2;

                SmartTextBox addres3TextBox = this.GetSmartTextBoxByName("contactAddress3TextBox");
                addres3TextBox.Text = theContact.Address3;

                SmartTextBox cityTextBox = this.GetSmartTextBoxByName("contactCityTextBox");
                cityTextBox.Text = theContact.City;

                ComboBox stateComboBox = this.GetComboBoxByName("contactStateComboBox");
                stateComboBox.SelectedValue = theContact.State;

                SmartTextBox postalCodeTextBox = this.GetSmartTextBoxByName("contactPostalCodeTextBox");
                postalCodeTextBox.Text = theContact.PostalCode;

                ComboBox countryTextComboBox = this.GetComboBoxByName("contactCountryComboBox");
                countryTextComboBox.SelectedValue = theContact.Country;


                SmartTextBox primaryTelephone = this.GetSmartTextBoxByName("contactPrimaryTelephoneTextBox");
                primaryTelephone.Text = theContact.PrimaryTelephone;

                SmartTextBox alternTelephone = this.GetSmartTextBoxByName("contactAlternTelephoneTextbox");
                alternTelephone.Text = theContact.AlternTelephone;

                SmartTextBox cellPhoneTextBox = this.GetSmartTextBoxByName("contactCellPhoneTextBox");
                cellPhoneTextBox.Text = theContact.CellPhone;

                SmartTextBox faxTextBox = this.GetSmartTextBoxByName("contactFaxTextbox");
                faxTextBox.Text = theContact.Fax;

                SmartTextBox emailTextBox = this.GetSmartTextBoxByName("contactEmailTextBox");
                emailTextBox.Text = theContact.Email;

                SmartTextBox confirmationEmail = this.GetSmartTextBoxByName("contactEmailConfirmationTextBox");
                confirmationEmail.Text = theContact.Email;
            }

        }




        public bool HasAContact
        {
            get
            {
                return this.Session["Contact"] != null;
            }
        }
    }
}
