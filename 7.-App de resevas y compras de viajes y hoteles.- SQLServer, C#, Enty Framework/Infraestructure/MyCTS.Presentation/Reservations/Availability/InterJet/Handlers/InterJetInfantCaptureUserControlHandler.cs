using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Collections;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetInfantCaptureUserControlHandler : InterJetUserControlHandler
    {


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

            this.FillControlsWithData();
            SetToolTip();

        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {

                var session = (InterJetSession)this.UserControl.Parameter;

                if (session != null)
                {
                    return session.Session;
                }
                else
                {
                    return new Hashtable();
                }
            }
        }

        private List<InterJetPassanger> GetPassangers()
        {

            var passangers = (InterJetPassangers)this.Session["Passangers"];

            return passangers.GetAllAdultsPassanger();

        }


        #region Clases Tipadas de los comboBox;

        private class Nationality
        {
            public string ID { get; set; }
            public string Text { get; set; }
        }

        private class Gender
        {
            public string ID { get; set; }
            public string Text { get; set; }
        }

        #endregion

        private ucInterJetInfantCapture CurrentUserControl
        {
            get
            {
                return this.UserControl as ucInterJetInfantCapture;
            }
        }


        /// <summary>
        /// Validates the text box.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="field">The field.</param>
        private void ValidateTextBox(TextBox textBox, string field)
        {
            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {

                    string msg = string.Format("PORFAVOR CAPTURE EL {0} DEL INFANTE.", field);
                    ErrorProvider.SetError(textBox, msg);
                    throw new Exception(msg);
                }

            }


        }

        /// <summary>
        /// Monthes the difference.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        private int MonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;


            return Math.Abs(monthsApart);
        }


        public Label InfantAgeLabel { get; set; }
        /// <summary>
        /// Validates the infate age.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        private void ValidateInfateAge(DateTime dateOfBirth)
        {

            if (MonthDifference(dateOfBirth, DateTime.Now) >= 25)
            {
                string msg = "LA edad del infante no puede ser mayor a 24 meses en el momento del vuelo, por favor registrelo como menor.".ToUpper();

                this.ErrorProvider.SetError(InfantAgeLabel, msg);
                throw new Exception("");
            }



        }

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        private void SetToolTip()
        {

            ComboBox nationalityComboBox = this.GetComboBoxByName("Nationality");
            ToolTiper.SetToolTip(nationalityComboBox, "Nacionalidad del infante.".ToUpper());

            TextBox nameTextBox = this.GetTextBoxByName("Name_");

            ToolTiper.SetToolTip(nameTextBox, "Nombre del infante.".ToUpper());
            TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
            ToolTiper.SetToolTip(lastNameTextBox, "Apellido del infante.".ToUpper());

            ComboBox titleComboBox = this.GetComboBoxByName("Title");
            ToolTiper.SetToolTip(titleComboBox, "titulo del infante.".ToUpper());


            ToolTiper.SetToolTip(this.CurrentUserControl, "Edad del infante.".ToUpper());

            ComboBox genderComboBox = this.GetComboBoxByName("Gender");

            ToolTiper.SetToolTip(genderComboBox, "Genero del infante.".ToUpper());
            ComboBox travelWithComboBox = this.GetComboBoxByName("TravelWith");

            ToolTiper.SetToolTip(travelWithComboBox, "Adulto que acompaña al infante.".ToUpper());

        }


        //TODO: Validar seleccion.
        private InterJetPassangerInfant GetInfant()
        {
            var infant = new InterJetPassangerInfant();

            ComboBox nationalityComboBox = this.GetComboBoxByName("Nationality");
            infant.Nationality = nationalityComboBox.SelectedValue.ToString();

            TextBox nameTextBox = this.GetTextBoxByName("Name_");
            ValidateTextBox(nameTextBox, "NOMBRE");
            infant.Name = nameTextBox.Text;

            TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
            ValidateTextBox(lastNameTextBox, "APELLIDO");
            infant.LastName = lastNameTextBox.Text;


            ComboBox titleComboBox = this.GetComboBoxByName("Title");

            ValidateInfateAge(this.CurrentUserControl.InfantDateOfBirth);
            infant.DateOfBirth = this.CurrentUserControl.InfantDateOfBirth;

            ComboBox genderComboBox = this.GetComboBoxByName("Gender");
            infant.Sex = genderComboBox.SelectedValue.ToString();

            ComboBox travelWithComboBox = this.GetComboBoxByName("TravelWith");
            var passangerAssigned = travelWithComboBox.SelectedItem as InterJetPassanger;

            if (passangerAssigned != null && passangerAssigned.CanBeInfantAssigned)
            {
                if (passangerAssigned is InterJetAdultPassanger)
                {

                    var adultPassanger = (InterJetAdultPassanger)passangerAssigned;
                    adultPassanger.AssignedInfant = infant;
                    infant.AssignedPassanger = adultPassanger;
                }
                if (passangerAssigned is InterJetSeniorAdultPassanger)
                {
                    var adultPassanger = (InterJetSeniorAdultPassanger)passangerAssigned;
                    adultPassanger.AssignedInfant = infant;
                    infant.AssignedPassanger = adultPassanger;
                }
            }
            return infant;
        }


        private void FillControlsWithData()
        {
            ComboBox nationalityComboBox = this.GetComboBoxByName("Nationality");
            nationalityComboBox.ValueMember = "Value";
            nationalityComboBox.DisplayMember = "Text";
            nationalityComboBox.DataSource = this.GetNationalitys();
            nationalityComboBox.SelectedValue = "MX";

            ComboBox genderComboBox = this.GetComboBoxByName("Gender");
            genderComboBox.DisplayMember = "Text";
            genderComboBox.ValueMember = "ID";
            genderComboBox.DataSource = this.GetGender();

            ComboBox titleComboBox = this.GetComboBoxByName("Title");
            titleComboBox.DisplayMember = "Text";
            titleComboBox.ValueMember = "ID";
            titleComboBox.DataSource = this.GetTitle();

            ComboBox travelWithComboBox = this.GetComboBoxByName("TravelWith");
            travelWithComboBox.DisplayMember = "NameAndLastName";

            travelWithComboBox.DataSource = this.GetPassangers();
        }

        /// <summary>
        /// Gets the nationalitys.
        /// </summary>
        /// <returns></returns>
        private ListItem[] GetNationalitys()
        {

            var newList = new List<ListItem>();
            foreach (ListItem item in ucInterJetContactPassangerCaptureForm.Countries)
            {

                ListItem newItem = new ListItem();
                newItem.Text = item.Text;
                newItem.Value = item.Value;
                newList.Add(newItem);

            }
            return newList.ToArray();

        }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <returns></returns>
        private List<Gender> GetGender()
        {
            var genders = new List<Gender>();
            genders.Add(new Gender { ID = "MI", Text = "HOMBRE" });
            genders.Add(new Gender { ID = "FI", Text = "MUJER" });
            return genders;
        }

        private ArrayList GetTitle()
        {
            var title = new ArrayList();
            title.Add(new { ID = "CHILD", Text = "Menor" });
            return title;
        }
        public InterJetPassangers Passangers
        {
            get;
            set;
        }

        public InterJetPassangerInfant Infant
        {
            get
            {
                return this.GetInfant();
            }
            set
            {
                this.SetInfant(value);

            }
        }

        public void SetInfant(InterJetPassangerInfant infant)
        {

            ComboBox nationalityComboBox = this.GetComboBoxByName("Nationality");
            nationalityComboBox.SelectedValue = infant.Nationality;


            ComboBox genderComboBox = this.GetComboBoxByName("Gender");
            genderComboBox.SelectedValue = infant.Sex;

            ComboBox titleComboBox = this.GetComboBoxByName("Title");
            titleComboBox.SelectedValue = infant.Title;

            TextBox nameTextBox = this.GetTextBoxByName("Name_");
            nameTextBox.Text = infant.Name;

            TextBox lastNameTextBox = this.GetTextBoxByName("LastName");
            lastNameTextBox.Text = infant.LastName;

            ComboBox travelWithComboBox = this.GetComboBoxByName("TravelWith");
            travelWithComboBox.SelectedItem = infant.AssignedPassanger;
        }
    }
}
