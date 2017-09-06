using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.DateOfBirth;

namespace MyCTS.Presentation
{
    public partial class ucVolarisDateOfBirthControl : CustomUserControl, IVolarisDateOfBirthView
    {
        public ucVolarisDateOfBirthControl()
        {
            InitializeComponent();
        }

        #region Miembros de IVolarisDateOfBirthView

        public DateTime BirthDay
        {
            get { return CurrentBirth(); }
            set
            {

                dayComboBox.SelectedItem = value.Day.ToString(new CultureInfo("es-MX")).ToUpper();
                monthComboBox.SelectedItem = value.ToString("MMMM", new CultureInfo("es-MX")).ToUpper();
                yearComboBox.SelectedItem = value.ToString("yyyy", new CultureInfo("es-MX")).ToUpper();
            }
        }

        private DateTime CurrentBirth()
        {
            try
            {
                string selectedDay = this.dayComboBox.SelectedItem.ToString();
                string selectedMonth = this.monthComboBox.SelectedItem.ToString();
                string selectedYear = this.yearComboBox.SelectedItem.ToString();
                string dateString = string.Format("{0}/{1}/{2}", selectedDay, selectedMonth, selectedYear);
                var dateTime = DateTime.Parse(dateString);
                return dateTime;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        private VolarisDateOfBirthPresenter _presenter;
        private void ucVolarisDateOfBirthControl_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisDateOfBirthPresenter()
                             {

                                 View = this,
                                 Repository = new VolarisDateOfBirthRepository()
                             };
            _presenter.InitializeView();
        }

        #region Miembros de IVolarisDateOfBirthView


        public bool CheckForInfantBirthDay { get; set; }

        #endregion

        #region Miembros de IVolarisDateOfBirthView


        public void SetMonths(string[] months)
        {
            this.monthComboBox.Properties.Items.AddRange(months.ToList());
        }

        public void SetDays(string[] days)
        {
            this.dayComboBox.Properties.Items.AddRange(days.ToList());
        }

        public void SetYears(string[] years)
        {
            this.yearComboBox.Properties.Items.AddRange(years.ToList());
        }

        #endregion
    }
}
