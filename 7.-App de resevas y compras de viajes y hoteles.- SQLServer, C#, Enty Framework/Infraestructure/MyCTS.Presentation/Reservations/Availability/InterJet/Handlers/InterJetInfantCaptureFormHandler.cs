using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Components;
using System.Collections;
using System.Windows.Forms;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetInfantCaptureFormHandler : InterJetFormHandler
    {
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
        /// Gets or sets the infant panel.
        /// </summary>
        /// <value>
        /// The infant panel.
        /// </value>
        public Panel InfantPanel
        {
            get;
            set;
        }

        private const string FIELD_TO_CAPTURE = "POR FAVOR INDIQUE EL CAMPO {0} DEL INFANTE {1}";

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {

                var session = (InterJetSession)this.CurrentForm.Parameter;

                if (session != null)
                {
                    return session.Session;
                }
                return new Hashtable();
            }
        }



        /// <summary>
        /// Backs to contacts.
        /// </summary>
        public void BackToContacts()
        {


            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm, "ucInterJetContactPassangerCaptureForm", this.CurrentForm.Parameter, null);
        }



        /// <summary>
        /// 
        /// </summary>
        private InterJetControlFactory _interJetControlFactory;

        /// <summary>
        /// Gets the inter jet control factory.
        /// </summary>
        public InterJetControlFactory InterJetControlFactory
        {
            get
            {
                return this._interJetControlFactory ?? (this._interJetControlFactory = new InterJetControlFactory());
            }
        }


        public GroupBox InfantMainGroupBox
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            if (this.Session["UserInput"] != null)
            {
                var userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];

                InterJetControlFactory.LoadInfantUserControl(this.InfantMainGroupBox, userInput.InfantsPassangers, this.CurrentForm.Parameter, this.KeyDownHandler);

                if (this.HasInfants)
                {
                    this.SetInfants();
                    this.Session["Infants"] = null;
                    var ticket = (InterJetTicket)this.Session["CurrentTicket"];
                    ticket.Passangers.RemoveInfants();

                }
            }
        }

        /// <summary>
        /// Sets the infants.
        /// </summary>
        private void SetInfants()
        {
            List<Panel> panelsWithInfants = this.InfantMainGroupBox.Controls.OfType<Panel>().ToList();

            if (panelsWithInfants.Count > 0)
            {
                List<ucInterJetInfantCapture> userControls = panelsWithInfants.Where(panel => panel.Controls.OfType<ucInterJetInfantCapture>().FirstOrDefault() != null).
                                                            Select(panel => panel.Controls.OfType<ucInterJetInfantCapture>().FirstOrDefault()).ToList();

                if (userControls.Count > 0)
                {

                    foreach (ucInterJetInfantCapture userControl in userControls)
                    {
                        userControl.Infant = this.InfantStack.Pop();
                    }


                }
            }
        }

        /// <summary>
        /// Clears the assignation.
        /// </summary>
        private void ClearAssignation()
        {
            var ticket = (InterJetTicket)this.Session["CurrentTicket"];
            foreach (var pax in ticket.Passangers.GetPassengerWithInfantsAssigned())
            {
                var adultPax = pax as InterJetAdultPassanger;
                if (adultPax != null)
                {
                    adultPax.AssignedInfant = null;

                }

                var seniorPax = pax as InterJetSeniorAdultPassanger;
                if (seniorPax != null)
                {
                    seniorPax.AssignedInfant = null;
                }


            }


        }

        /// <summary>
        /// 
        /// </summary>
        private Stack<InterJetPassangerInfant> _infantStack;
        /// <summary>
        /// Gets the infant stack.
        /// </summary>
        private Stack<InterJetPassangerInfant> InfantStack
        {
            get
            {

                if (this._infantStack == null)
                {
                    this._infantStack = this.GetStackOfInfants();
                }
                return this._infantStack;
            }
        }

        /// <summary>
        /// Gets the stack of infants.
        /// </summary>
        /// <returns></returns>
        private Stack<InterJetPassangerInfant> GetStackOfInfants()
        {

            var infants = (List<InterJetPassangerInfant>)this.Session["Infants"];
            var infantStack = new Stack<InterJetPassangerInfant>();
            foreach (InterJetPassangerInfant infant in infants.Reverse<InterJetPassangerInfant>())
            {
                infantStack.Push(infant);

            }

            return infantStack;
        }

        /// <summary>
        /// Continues to payment.
        /// </summary>
        public void ContinueToPayment()
        {

            var infants = this.GetInfants();
            var ticket = (InterJetTicket)this.Session["CurrentTicket"];
            ticket.Passangers.AddPassangers(infants.Cast<InterJetPassanger>().ToList());
            this.Session["Infants"] = infants;
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentForm, "ucInterJetPaymentForm", this.CurrentForm.Parameter, null);

        }




        //TODO: Agregar eventos al control de infantes y pagos.
        //TODO: Validar cuando se regresa de infantes a contactos y cargar de forma correcta los contacos.
        /// <summary>
        /// Keys down handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {

            try
            {
                if (sender is Control)
                {
                    var control = sender as Control;
                    ErrorProvider.SetError(control, "");
                }
                if (e.KeyCode == Keys.Enter)
                {

                    this.ContinueToPayment();

                }

                if (e.KeyCode == Keys.Escape)
                {
                    this.BackToContacts();
                }
            }
            catch (Exception exception)
            {

                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }



        /// <summary>
        /// Gets a value indicating whether this instance has infants.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has infants; otherwise, <c>false</c>.
        /// </value>
        private bool HasInfants
        {
            get
            {
                return this.Session["Infants"] != null;
            }
        }

        //private List<InterJetPassangerInfant> GetInfants()
        //{

        //    InterJetAvailabilityUserInput userInput = (InterJetAvailabilityUserInput)this.Session["UserInput"];
        //    List<InterJetPassangerInfant> infants = new List<InterJetPassangerInfant>();
        //    if (userInput != null)
        //    {
        //        int numberOfInfants = userInput.InfantsPassangers;
        //        for (int infantPaxIndex = 0; infantPaxIndex < numberOfInfants; infantPaxIndex++)
        //        {
        //            InterJetPassangerInfant infant = new InterJetPassangerInfant();

        //            Panel infantPanel = this.FindPanel(string.Format("Infant{0}", infantPaxIndex));
        //            GroupBox infantGroupBox = this.FindGroupBox(infantPanel, string.Format("InfantGroup{0}", infantPaxIndex));

        //            ComboBox genderComboBox = this.FindComboBox(infantGroupBox, string.Format("Gender{0}", infantPaxIndex));
        //            infant.Sex = genderComboBox.SelectedItem.ToString();
        //            this.ValidComboBox(genderComboBox, "SEXO", infantPaxIndex.ToString());
        //            ComboBox daysComboBox = this.FindComboBox(infantGroupBox, string.Format("dayOfBirth{0}", infantPaxIndex));
        //            this.ValidComboBox(daysComboBox, "DIA", infantPaxIndex.ToString());
        //            ComboBox monthComboBox = this.FindComboBox(infantGroupBox, string.Format("monthOfBirth{0}", infantPaxIndex));
        //            this.ValidComboBox(monthComboBox, "MES", infantPaxIndex.ToString());
        //            ComboBox yearComboBox = this.FindComboBox(infantGroupBox, string.Format("yearOfBirth{0}", infantPaxIndex));
        //            this.ValidComboBox(yearComboBox, "AÑO", infantPaxIndex.ToString());
        //            string dateOfBirthString = string.Format("{0}/{1}/{2}", daysComboBox.SelectedItem.ToString(), monthComboBox.SelectedItem.ToString(), yearComboBox.SelectedItem.ToString());
        //            infant.DateOfBirth = DateTime.Parse(dateOfBirthString);

        //            ComboBox countryComboBox = this.FindComboBox(infantGroupBox, string.Format("Country{0}", infantPaxIndex));
        //            infant.Country = countryComboBox.SelectedItem != null ? countryComboBox.SelectedValue.ToString() : "";

        //            ComboBox nacionalityComboBox = this.FindComboBox(infantGroupBox, string.Format("Nacionality{0}", infantPaxIndex));
        //            infant.Nationality = nacionalityComboBox.SelectedItem != null ? nacionalityComboBox.SelectedValue.ToString() : "";

        //            TextBox nameTextBox = this.FindTextBox(infantGroupBox, string.Format("Name{0}", infantPaxIndex));
        //            this.ValidateTextBox(nameTextBox, "NOMBRE", infantPaxIndex.ToString());
        //            infant.Name = nameTextBox.Text;

        //            TextBox lastNameTextBox = this.FindTextBox(infantGroupBox, string.Format("LastName{0}", infantPaxIndex));
        //            this.ValidateTextBox(lastNameTextBox, "APELLIDO", infantPaxIndex.ToString());
        //            infant.LastName = lastNameTextBox.Text;

        //            ComboBox selectedPassangerID = this.FindComboBox(infantGroupBox, string.Format("PassangerID{0}", infantPaxIndex));
        //            string idOfPassangerAssigned = (selectedPassangerID.SelectedItem as InterJetPassanger).ID;

        //            this.AsignInfantToPasanger(idOfPassangerAssigned, infant, selectedPassangerID);
        //            infants.Add(infant);
        //        }

        //    }

        //    return infants;
        //}

        /// <summary>
        /// Gets the infants.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<InterJetPassangerInfant> GetInfants()
        {
            this.ClearAssignation();
            var infants = new List<InterJetPassangerInfant>();
            List<Panel> panels = this.InfantMainGroupBox.Controls.OfType<Panel>().ToList();
            var userControls = new List<ucInterJetInfantCapture>();
            if (panels.Count > 0)
            {
                userControls = panels.Where(panel => panel.Controls.OfType<ucInterJetInfantCapture>().FirstOrDefault() != null)
                                                                   .Select(panel => panel.Controls.OfType<ucInterJetInfantCapture>().FirstOrDefault()).ToList();

                if (userControls.Count > 0)
                {

                    foreach (ucInterJetInfantCapture userControl in userControls)
                    {
                        infants.Add(userControl.Infant);
                    }

                }
            }

            foreach (InterJetPassangerInfant infantToCompare in infants)
            {
                InterJetPassangerInfant infantWithSamePassanger = infants.FirstOrDefault(infant => !infant.Name.Equals(infantToCompare.Name)
                                                                                                   && !infant.LastName.Equals(infantToCompare.LastName)
                                                                                                   && infant.AssignedPassanger.ID == infantToCompare.AssignedPassanger.ID);

                bool passangerIsAlreadyAssigned = infantWithSamePassanger != null;
                if (passangerIsAlreadyAssigned)
                {

                    infants.Clear();
                    if (userControls.Any())
                    {
                        var controlToWarn =
                            userControls.FirstOrDefault(
                                c =>
                                c.Infant.Name.Equals(infantToCompare.Name) &&
                                c.Infant.LastName.Equals(infantToCompare.LastName));
                        if (controlToWarn != null)
                        {

                            var msg = string.Format("POR FAVOR INDIQUE OTRO PASAJERO QUE ACOMPAÑE AL INFANTE {0}.",
                                                    infantWithSamePassanger.Name);
                            controlToWarn.WarnAboutPassangerSelected(msg);

                        }
                    }
                    throw new Exception(string.Format("POR FAVOR INDIQUE OTRO PASAJERO QUE ACOMPAÑE AL INFANTE {0}.", infantWithSamePassanger.Name));
                }



            }


            return infants;
        }

        private void ValidateTextBox(TextBox textBox, string field, string infantID)
        {

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Focus();
                throw new Exception(string.Format(InterJetInfantCaptureFormHandler.FIELD_TO_CAPTURE, field, infantID));
            }

        }

        private void ValidComboBox(ComboBox comboBox, string field, string infantID)
        {
            if (comboBox.SelectedItem == null)
            {
                comboBox.Focus();
                throw new Exception(string.Format(InterJetInfantCaptureFormHandler.FIELD_TO_CAPTURE, field, infantID));
            }
        }

        private Panel FindPanel(string name)
        {
            return this.InfantPanel.Controls.Find(name, true).FirstOrDefault() as Panel;
        }

        private GroupBox FindGroupBox(Panel panelToSearch, string name)
        {

            return panelToSearch.Controls.Find(name, true).FirstOrDefault() as GroupBox;
        }

        private TextBox FindTextBox(GroupBox groupBoxToSearch, string name)
        {
            return groupBoxToSearch.Controls.Find(name, true).FirstOrDefault() as TextBox;
        }

        private ComboBox FindComboBox(GroupBox groupBoxToSearch, string name)
        {
            return groupBoxToSearch.Controls.Find(name, true).FirstOrDefault() as ComboBox;
        }




        private void AsignInfantToPasanger(string idOfPassangerAssigned, InterJetPassangerInfant infant, ComboBox selectedPassangerID)
        {
            var passangers = (InterJetPassangers)this.Session["Passangers"];

            InterJetPassanger passanger = passangers.FindPassanger(idOfPassangerAssigned);
            if (passanger is InterJetAdultPassanger)
            {
                var adultPassanger = (InterJetAdultPassanger)passanger;
                if (!adultPassanger.HasAlreadyAInfant)
                {
                    adultPassanger.AssignedInfant = infant;
                    infant.AssignedPassanger = adultPassanger;
                }
                else
                {
                    selectedPassangerID.Focus();
                    throw new Exception(string.Format("POR FAVOR INDIQUE OTRO PASAJERO QUE ACOMPAÑE AL INFANTE {0}.", infant.Name));
                }
            }
            else
            {

                var seniorPassanger = (InterJetSeniorAdultPassanger)passanger;
                if (!seniorPassanger.HasAlreadyAInfant)
                {
                    seniorPassanger.AssignedInfant = infant;
                    infant.AssignedPassanger = seniorPassanger;
                }
                else
                {
                    selectedPassangerID.Focus();
                    throw new Exception(string.Format("POR FAVOR INDIQUE OTRO PASAJERO QUE ACOMPAÑE AL INFANTE {0}.", infant.Name));
                }
            }
        }

        public override void RecoverFromError()
        {
           
        }
    }
}
