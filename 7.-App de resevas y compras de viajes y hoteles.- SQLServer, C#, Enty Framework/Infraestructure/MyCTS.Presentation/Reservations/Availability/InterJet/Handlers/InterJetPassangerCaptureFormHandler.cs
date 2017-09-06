using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.Drawing;
using System.Collections;
using MyCTS.Forms.UI;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetPassangerCaptureFormHandler : InterJetFormHandler
    {
        #region Propierties

        public Button SearchButton { get; set; }

        public PictureBox ProfileIcon { get; set; }

        public Panel NationalityPanel { get; set; }

        public Label FristLevelLabel { get; set; }

        public Label RedDot { get; set; }




        public PictureBox Loading { get; set; }
        public Panel PassangersPanel
        {
            get;
            set;
        }
        public GroupBox PassangerGroupBox
        {
            get;
            set;
        }

        public Panel AdultsPanel
        {
            get;
            set;
        }
        public Panel ChildrenPanel
        {
            get;
            set;
        }

        public Panel SeniorPanel
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the first level profile text box.
        /// </summary>
        /// <value>
        /// The first level profile text box.
        /// </value>
        public SmartTextBox FirstLevelProfileTextBox { get; set; }

        /// <summary>
        /// Gets or sets the second level profile text box.
        /// </summary>
        /// <value>
        /// The second level profile text box.
        /// </value>
        public SmartTextBox SecondLevelProfileTextBox { get; set; }
        private InterJetControlFactory _factory;

        /// <summary>
        /// Gets the inter jet control factory.
        /// </summary>
        private InterJetControlFactory InterJetControlFactory
        {
            get
            {
                if (this._factory == null)
                {
                    this._factory = new InterJetControlFactory
                    {
                        InterJetPassangerCaptureFormHandler = this
                    };
                }
                return this._factory;
            }
        }


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
        /// Gets or sets the flow button panel.
        /// </summary>
        /// <value>
        /// The flow button panel.
        /// </value>
        public Panel FlowButtonPanel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current form.
        /// </summary>
        /// <value>
        /// The current form.
        /// </value>
        public CustomUserControl CurrentForm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        public Hashtable Session
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

        public ComboBox NationalityComboBox
        {
            get;
            set;
        }

        #endregion


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            LogProductivity.LogTransaction(Login.Agent, "3-Desplego Captura de usuarios --InterJet");
            //TODO: en caso de regresar verificar los pasajeros en session
            this.CreateDynamicPanels();
            SetToolTip();
            if (this.HasPassangers)
            {
                this.SetPassangers();

            }
            if (this.HasAProfile)
            {
                SetProfile();
            }
            //this.ResizePanels();
            this.LoadDataSourceNationality();
        }

        /// <summary>
        /// Sets the profile.
        /// </summary>
        private void SetProfile()
        {

            if (this.Profile != null)
            {

                this.FirstLevelProfileTextBox.Text = Profile.FirstLevelProfile;
                this.SecondLevelProfileTextBox.Text = this.Profile.SecondLevelProfile;
                this.ProfileIsSet = true;
            }
        }


        public Button ContinueToCaptureContactButton { get; set; }
        public Button BackToAvailabilityButton { get; set; }


        public PictureBox LookUpProfile { get; set; }

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        private void SetToolTip()
        {

            this.ToolTiper.SetToolTip(this.FirstLevelProfileTextBox, "Ingrese el perfil de primer nivel.".ToUpper());
            this.ToolTiper.SetToolTip(this.SecondLevelProfileTextBox, "Ingrese el perfil de segundo nivel.".ToUpper());
            this.ToolTiper.SetToolTip(this.LookUpProfile, "Click para buscar el perfil.".ToUpper());
            this.ToolTiper.SetToolTip(this.SearchButton, "Click para buscar el perfil.".ToUpper());
            this.ToolTiper.SetToolTip(this.ContinueToCaptureContactButton, "Click para capturar la información del contacto.".ToUpper());
            this.ToolTiper.SetToolTip(this.BackToAvailabilityButton, "Click para regresar a disponibilidad los segmentos vendidos hasta ahora se perderan.".ToUpper());

        }


        /// <summary>
        /// Sets the passangers.
        /// </summary>
        public void SetPassangers()
        {
            var passangers = (InterJetPassangers)this.Session["Passangers"];

            var panelsWithGroupBoxes = this.PassangerGroupBox.Controls.OfType<Panel>();

            var userControls = new List<ucInterJetPassangerCapture>();
            userControls = panelsWithGroupBoxes.Where(panel => panel.Controls.OfType<ucInterJetPassangerCapture>().FirstOrDefault() != null).
                                                 Select(panel => panel.Controls.OfType<ucInterJetPassangerCapture>().FirstOrDefault()).ToList();

            if (userControls.Count > 0)
            {
                foreach (ucInterJetPassangerCapture userControl in userControls.Reverse<ucInterJetPassangerCapture>())
                {
                    userControl.Passanger = passangers.GetAndRemove();
                }
            }

        }


        /// <summary>
        /// Keys down handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    this.DisplayContactPassangerForm();
                }
                catch (Exception exception)
                {


                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.DisplayInterJetAvailabilityForm();
            }




        }

        /// <summary>
        /// Searches the profile.
        /// </summary>
        public void SearchProfile()
        {

            if (string.IsNullOrEmpty(this.FirstLevelProfileTextBox.Text))
            {
                ErrorProvider.SetError(this.FirstLevelProfileTextBox, "Indique el perfil de primer nivel antes de realizar una busqueda.".ToUpper());
                FirstLevelProfileTextBox.Focus();
                throw new Exception("Indique el perfil de primer nivel antes de realizar una busqueda.".ToUpper());
            }
            if (string.IsNullOrEmpty(this.SecondLevelProfileTextBox.Text))
            {
                ErrorProvider.SetError(this.SecondLevelProfileTextBox, "Indique el perfil de segundo nivel antes de realizar una busqueda.".ToUpper());
                SecondLevelProfileTextBox.Focus();
                throw new Exception("Indique el perfil de segundo nivel antes de realizar una busqueda.".ToUpper());
            }

            this.StartProfileWorker();




        }


        /// <summary>
        /// Loads the data source nationality.
        /// </summary>
        private void LoadDataSourceNationality()
        {
            var nationailitys = new List<ListItem>();

            nationailitys.Add(new ListItem("Mexicana", "MX"));
            nationailitys.Add(new ListItem("Guatemalteca", "GT"));
            nationailitys.Add(new ListItem("EstadoUnidense", "US"));
            nationailitys.Add(new ListItem("Cubana", "CU"));
            nationailitys.Add(new ListItem("Otra", "OC"));


            this.NationalityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.NationalityComboBox.DataSource = nationailitys;
            this.NationalityComboBox.DisplayMember = "Text";
            this.NationalityComboBox.ValueMember = "Value";
            this.NationalityComboBox.SelectedValue = "MX";
        }

        /// <summary>
        /// Creates the dynamic panels.
        /// </summary>
        private void CreateDynamicPanels()
        {
            var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];
            if (userInput != null)
            {

                if (userInput.HasAdultsPassangers)
                {
                    this.InterJetControlFactory.LoadPassangerUserControl(this.PassangerGroupBox, userInput.AdultsPassangers, InterJetPassangerType.Adult, this.KeyDownHandler);
                }
                if (userInput.HasChildrenPassangers)
                {
                    this.InterJetControlFactory.LoadPassangerUserControl(this.PassangerGroupBox, userInput.ChildsPassangers, InterJetPassangerType.Child, this.KeyDownHandler);
                }
                if (userInput.HasSeniorsPassangers)
                {
                    this.InterJetControlFactory.LoadPassangerUserControl(this.PassangerGroupBox, userInput.SeniorsPassangers, InterJetPassangerType.Senior, this.KeyDownHandler);
                }
            }

            Control lastPanel = InterJetControlFactory.CurrentStack.Pop();
            int y_displacement = 180;
            this.FlowButtonPanel.Location = new Point(this.FlowButtonPanel.Location.X, lastPanel.Location.Y + y_displacement);
            InterJetControlFactory.CurrentStack.Clear();
        }


        /// <summary>
        /// Gets a value indicating whether this instance has passangers.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has passangers; otherwise, <c>false</c>.
        /// </value>
        public bool HasPassangers
        {
            get
            {

                return this.Session["Passangers"] != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _profileWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the profile worker.
        /// </summary>
        private BackgroundWorker ProfileWorker
        {
            get { return _profileWorker; }
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private void StartAnimation(bool enable)
        {

            //this.ProgressBar.Visible = enable;
            this.WaitingLabel.Visible = enable;
            this.ProfileIcon.Visible = enable;


            this.Loading.Visible = true;
        }

        /// <summary>
        /// Starts the profile worker.
        /// </summary>
        private void StartProfileWorker()
        {

            this.PassangerGroupBox.Visible = false;
            this.RedDot.Visible = false;
            this.NationalityPanel.Visible = false;
            this.FristLevelLabel.Visible = false;
            this.FirstLevelProfileTextBox.Visible = false;
            this.StartAnimation(true);
            ProfileWorker.DoWork += new DoWorkEventHandler(ProfileWorker_DoWork);
            ProfileWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProfileWorker_RunWorkerCompleted);
            //Timer.Tick += new EventHandler(Timer_Tick);
            //Timer.Interval = 100;
            //Timer.Enabled = true;
            //Timer.Start();
            ProfileWorker.RunWorkerAsync(new ProfileLevel
                                             {
                                                 FristLevel = this.FirstLevelProfileTextBox.Text,
                                                 SecondLevel = this.SecondLevelProfileTextBox.Text

                                             });

        }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Timer_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Percentage = 10;
            this.ProgressBar.SetProgComplete(this.ProgressBar.Percentage);
        }

        private bool ProfileIsSet { get; set; }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the ProfileWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void ProfileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ClearErrorProviderFromControls();
                StopProfileWorker();
                this.Loading.Visible = false;
                this.PassangerGroupBox.Visible = true;
                this.RedDot.Visible = true;
                this.NationalityPanel.Visible = true;
                this.FristLevelLabel.Visible = true;
                this.FirstLevelProfileTextBox.Visible = true;
                if (e.Error == null)
                {
                    var profile = (InterJetProfile)e.Result;
                    if (profile != null && !string.IsNullOrEmpty(profile.Name))
                    {

                        this.Session["Profile"] = profile;
                        SetProfileToPassanger(profile);
                        ProfileIsSet = true;
                    }
                    else
                    {
                        this.Session["Profile"] = null;
                        ProfileIsSet = false;
                        MessageBox.Show("No se encontraron los datos del perfil, verifique la información por favor.".ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    this.RecoverFromError();

                }

            }
            finally
            {

            }
        }

        /// <summary>
        /// Sets the profile to passanger.
        /// </summary>
        /// <param name="profile">The profile.</param>
        private void SetProfileToPassanger(InterJetProfile profile)
        {
            var panelsWithGroupBoxes = this.PassangerGroupBox.Controls.OfType<Panel>();
            var panelWithAPassanger =
                panelsWithGroupBoxes.FirstOrDefault(
                    panel => panel.Controls.OfType<ucInterJetPassangerCapture>().FirstOrDefault() != null);

            var control =
                panelWithAPassanger.Controls.OfType<ucInterJetPassangerCapture>().FirstOrDefault();
            if (control != null)
            {
                control.HasAProfile = true;
                control.Profile = profile;

            }

        }

        /// <summary>
        /// Clears the error provider from controls.
        /// </summary>
        private void ClearErrorProviderFromControls()
        {
            var panelsWithGroupBoxes = this.PassangerGroupBox.Controls.OfType<Panel>();
            var panelsWithPassanger =
                panelsWithGroupBoxes.Where(panel => panel.Controls.OfType<ucInterJetPassangerCapture>().Any());

            foreach (var panel in panelsWithPassanger)
            {
                var userControl = panel.Controls.OfType<ucInterJetPassangerCapture>().FirstOrDefault();
                if (userControl != null)
                {
                    userControl.ErrorProvider.Clear();
                }
            }


        }

        /// <summary>
        /// Handles the DoWork event of the ProfileWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void ProfileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var profileLevel = (ProfileLevel)e.Argument;

            InterJetProfile profile = ProfileService.GetProfile(profileLevel.SecondLevel, profileLevel.FristLevel);

            e.Result = profile;

        }

        /// <summary>
        /// Stops the profile worker.
        /// </summary>
        private void StopProfileWorker()
        {
            this.PassangerGroupBox.Visible = true;
            this.StartAnimation(false);
            ProfileWorker.DoWork -= new DoWorkEventHandler(ProfileWorker_DoWork);
            ProfileWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(ProfileWorker_RunWorkerCompleted);
            Timer.Tick -= new EventHandler(Timer_Tick);
            Timer.Enabled = false;
            Timer.Stop();

        }





        public Label WaitingLabel
        {
            get;
            set;

        }

        public GradProg.GradProg ProgressBar
        {
            get;
            set;
        }
        public System.Windows.Forms.Timer Timer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has A profile.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has A profile; otherwise, <c>false</c>.
        /// </value>
        private bool HasAProfile
        {
            get { return this.Session["Profile"] != null; }
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        private InterJetProfile Profile
        {
            get { return (InterJetProfile)this.Session["Profile"]; }
        }





        /// <summary>
        /// 
        /// </summary>
        private InterJetProfileBL _serviceProfile;

        /// <summary>
        /// Gets the profile service.
        /// </summary>
        private InterJetProfileBL ProfileService
        {
            get { return _serviceProfile ?? (_serviceProfile = new InterJetProfileBL()); }
        }


        /// <summary>
        /// Displays the contact passanger form.
        /// </summary>
        public void DisplayContactPassangerForm()
        {
            if (ProfileIsSet)
            {
                this.Session["Passangers"] = this.GetPassangers();
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm,
                                                "ucInterJetContactPassangerCaptureForm", this.CurrentForm.Parameter,
                                                null);
            }
            else
            {
                ErrorProvider.SetError(this.FirstLevelProfileTextBox, "No se ha indicado el perfil del pasajero, en caso de contar con uno, crear uno en el modulo de perfiles.".ToUpper());
                FirstLevelProfileTextBox.Focus();
            }
        }



        /// <summary>
        /// Displays the inter jet availability form.
        /// </summary>
        public void DisplayInterJetAvailabilityForm()
        {

            const string warningMessage = "¿Desea regresar a disponibilidad?\n" +
                                          "En caso de ser así se perderan todos los segmentos previamente vendidos.";

            DialogResult result = MessageBox.Show(warningMessage.ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {

                this.Session["SelectedFlights"] = null;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm, "ucInterJetAvailabilityOfFlights", this.CurrentForm.Parameter, null);
            }

        }


        /// <summary>
        /// Gets the passangers.
        /// </summary>
        /// <returns></returns>
        public InterJetPassangers GetPassangers()
        {
            var passangers = new List<InterJetPassanger>();
            var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];
            if (userInput != null)
            {

                if (userInput.HasAdultsPassangers)
                {
                    passangers.AddRange(this.GetPassangers(this.PassangerGroupBox, InterJetPassangerType.Adult));
                }
                if (userInput.HasChildrenPassangers)
                {
                    passangers.AddRange(this.GetPassangers(this.PassangerGroupBox, InterJetPassangerType.Child));
                }
                if (userInput.HasSeniorsPassangers)
                {
                    passangers.AddRange(this.GetPassangers(this.PassangerGroupBox, InterJetPassangerType.Senior));
                }
            }
            var interJetPassangers = new InterJetPassangers();
            interJetPassangers.AddPassangers(passangers);
            foreach (var pax in interJetPassangers.GetAll())
            {
                pax.Nationality = this.NationalityComboBox.SelectedValue.ToString();
            }


            return interJetPassangers;
        }


        /// <summary>
        /// Obtiene los pasajeros 
        /// </summary>
        /// <param name="mainGroupBox"></param>
        /// <param name="passangerType"></param>
        /// <returns></returns>
        private List<InterJetPassanger> GetPassangers(GroupBox mainGroupBox, InterJetPassangerType typeToSearch)
        {
            var passangers = new List<InterJetPassanger>();
            var panels = mainGroupBox.Controls.OfType<Panel>();
            var userControlsPassangers = panels.Select(e => e.Controls.OfType<ucInterJetPassangerCapture>().FirstOrDefault()).ToList();
            if (userControlsPassangers.Any())
            {
                passangers = userControlsPassangers.Where(userControl => userControl != null && userControl.PassangerType == typeToSearch).Select(uc => uc.Passanger).ToList();
            }
            var selectedFlights = (InterJetSelectedFlights)this.Session["SelectedFlights"];
            if (selectedFlights.HasInternationalSegments)
            {
                for (int i = 0; i < passangers.Count; i++)
                {
                    passangers[i].Title = "MR";
                }
            }
            return passangers;
        }





        private void ValidateTexBox(TextBox textBox, string field, string passangerId)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Focus();
                throw new Exception(string.Format("POR FAVOR CAPTURE EL CAMPO {0}, DEL PASAJERO {1}.", field, passangerId));
            }
        }

        private void ValidateComboBox(ComboBox comboBox, string field, string passangerId)
        {
            if (string.IsNullOrEmpty(comboBox.SelectedItem.ToString()))
            {
                comboBox.Focus();
                throw new Exception(string.Format("POR FAVOR CAPTURE EL CAMPO {0}, DEL PASAJERO {1}.", field, passangerId));
            }


        }



        public void OnContactChecked(object sender, EventArgs argument)
        {


            bool IsChecked = ((CheckBox)sender).Checked;
            GroupBox groupBox = (GroupBox)((CheckBox)sender).Parent.Parent;
            if (IsChecked)
            {
                if (groupBox != null)
                {
                    UnCheckedAllCheckBoxes(AdultsPanel);
                    UnCheckedAllCheckBoxes(SeniorPanel);
                }
                ((CheckBox)sender).CheckedChanged -= OnContactChecked;
                ((CheckBox)sender).Checked = true;
                ((CheckBox)sender).CheckedChanged += OnContactChecked;
            }



        }

        private static void CleanPanel(Panel panelToClean, int paxNumber)
        {

            CheckBox checkBoxToUnchecked = panelToClean.Controls.Find(string.Format("interjetIsContact{0}", paxNumber), true).FirstOrDefault() as CheckBox;
            if (checkBoxToUnchecked != null)
            {
                checkBoxToUnchecked.Checked = false;
            }
        }

        private void UnCheckedAllCheckBoxes(Panel panelToClean)
        {

            GroupBox groupBoxContainer = panelToClean.Controls.OfType<GroupBox>().FirstOrDefault();

            if (groupBoxContainer != null)
            {

                List<Panel> childrenPanels = groupBoxContainer.Controls.OfType<Panel>().ToList();

                int paxCounter = 0;
                foreach (Panel passangerPanel in childrenPanels)
                {
                    CleanPanel(passangerPanel, paxCounter);
                    paxCounter += 1;
                }


            }


        }

        private partial class ProfileLevel
        {
            public string FristLevel { get; set; }
            public string SecondLevel { get; set; }
        }



        public override void RecoverFromError()
        {
            base.RecoverFromError("Fallo de obtencion de perfil de InterJet");
        }
    }
}
