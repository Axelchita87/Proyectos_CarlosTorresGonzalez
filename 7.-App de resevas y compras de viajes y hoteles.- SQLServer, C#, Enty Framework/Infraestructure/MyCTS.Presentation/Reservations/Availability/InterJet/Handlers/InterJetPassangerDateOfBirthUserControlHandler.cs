using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Components;
using System.Windows.Forms;
using System.Globalization;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetPassangerDateOfBirthUserControlHandler : InterJetUserControlHandler
    {



        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            this.FillCombosBoxesWithData();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for infant.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is for infant; otherwise, <c>false</c>.
        /// </value>
        public bool IsForInfant
        {
            get;
            set;
        }
        public void Clear()
        {
            DateTime newTime = DateTime.Now;
            ComboBox daysCombo = this.GetComboBoxByName("daysCombo");
            daysCombo.SelectedItem = newTime.ToString("dd");

            var cultureInfo = new CultureInfo("es-MX");

            ComboBox monthsCombo = this.GetComboBoxByName("monthsCombo");
            monthsCombo.SelectedItem = newTime.ToString("MMM", cultureInfo).ToUpper();
            ComboBox yearsCombo = this.GetComboBoxByName("yearsCombo");
            yearsCombo.SelectedItem = newTime.ToString("yyyy");

        }




        public void SetDateOfBirth(DateTime newTime)
        {
            ComboBox daysCombo = this.GetComboBoxByName("daysCombo");
            daysCombo.SelectedItem = newTime.ToString("dd");

            var cultureInfo = new CultureInfo("es-MX");

            ComboBox monthsCombo = this.GetComboBoxByName("monthsCombo");
            monthsCombo.SelectedItem = newTime.ToString("MMM", cultureInfo).ToUpper();
            ComboBox yearsCombo = this.GetComboBoxByName("yearsCombo");
            yearsCombo.SelectedItem = newTime.ToString("yyyy");

        }


        /// <summary>
        /// Fills the combos boxes with data.
        /// </summary>
        private void FillCombosBoxesWithData()
        {
            ComboBox daysCombo = this.GetComboBoxByName("daysCombo");
            daysCombo.DataSource = this.GetDays();

            ComboBox monthsCombo = this.GetComboBoxByName("monthsCombo");
            monthsCombo.DataSource = this.GetMonths();

            ComboBox yearsCombo = this.GetComboBoxByName("yearsCombo");

            yearsCombo.DataSource = this.GetYears();
        }


        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        private DateTime GetDate()
        {

            ComboBox daysCombo = this.GetComboBoxByName("daysCombo");
            this.ValidateSelection(daysCombo, "DIA");
            ComboBox monthsCombo = this.GetComboBoxByName("monthsCombo");
            this.ValidateSelection(monthsCombo, "MES");
            ComboBox yearsCombo = this.GetComboBoxByName("yearsCombo");
            this.ValidateSelection(monthsCombo, "AÑO");

            string dateStringToParse = string.Format("{0}/{1}/{2}", daysCombo.SelectedItem.ToString(), monthsCombo.SelectedItem.ToString(), yearsCombo.SelectedItem.ToString());

            DateTime timeToCompare = DateTime.Parse(dateStringToParse);
            //if (this.IsForInfant)
            //{
            //    if (this.MonthDifference(DateTime.Now, timeToCompare) >= 25)
            //    {
            //        this.UserControl.Focus();
            //        throw new Exception("EL INFANTE TIENE UNA FECHA DE NACIMIENTO QUE EXCEDE LOS 11 MESES.POR FAVOR CANCELE LA RESERVACIÓN Y REGISTRELO COMO MENOR.");

            //    }
            //}

            return timeToCompare;

        }




        /// <summary>
        /// Monthes the difference.
        /// </summary>
        /// <param name="lValue">The l value.</param>
        /// <param name="rValue">The r value.</param>
        /// <returns></returns>
        private int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }


        /// <summary>
        /// Validates the selection.
        /// </summary>
        /// <param name="theComboToValidate">The combo to validate.</param>
        /// <param name="theField">The field.</param>
        private void ValidateSelection(ComboBox theComboToValidate, string theField)
        {
            if (theComboToValidate.SelectedItem == null)
            {
                theComboToValidate.Focus();
                throw new Exception(string.Format("POR FAVOR INDIQUE EL {0} EN LA FECHA DE NACIMIENTO.", theField.ToUpper()));
            }

        }
        /// <summary>
        /// Gets the years.
        /// </summary>
        /// <returns></returns>
        private string[] GetYears()
        {
            var years = new List<string>();
            for (int year = 1900; year <= DateTime.Now.Year; year++)
            {
                years.Add(year.ToString());
            }
            return years.OrderByDescending(e => e).ToArray();
        }

        /// <summary>
        /// Gets the months.
        /// </summary>
        /// <returns></returns>
        private string[] GetMonths()
        {
            return new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
        }

        /// <summary>
        /// Gets the days.
        /// </summary>
        /// <returns></returns>
        private string[] GetDays()
        {
            var days = new List<string>();
            for (int day = 1; day < 32; day++)
            {
                days.Add(day.ToString());
            }

            return days.ToArray();
        }


        /// <summary>
        /// Gets the get date of birth.
        /// </summary>
        public DateTime GetDateOfBirth
        {
            get
            {

                return this.GetDate();
            }

        }
    }
}
