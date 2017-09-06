using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.DateOfBirth
{
    public class VolarisDateOfBirthPresenter : IBasePresenter<IVolarisDateOfBirthView, VolarisDateOfBirthRepository>
    {
        #region Miembros de IBasePresenter<IVolarisDateOfBirthView,VolarisDateOfBirthRepository>

        public IVolarisDateOfBirthView View { get; set; }

        public VolarisDateOfBirthRepository Repository { get; set; }

        public void InitializeView()
        {
            LoadDataSource();
            View.BirthDay = DateTime.Now;
        }

        /// <summary>
        /// Loads the data source.
        /// </summary>
        private void LoadDataSource()
        {

            var months = new List<string>()
                             {
                                 {"Enero".ToUpper()},{"Febrero".ToUpper()},{"Marzo".ToUpper()},{"Abril".ToUpper()},{"Mayo".ToUpper()},{"Junio".ToUpper()},
                                 {"Julio".ToUpper()},{"Agosto".ToUpper()},{"Septiembre".ToUpper()},{"Octubre".ToUpper()}, {"Noviembre".ToUpper()},
                                 {"Diciembre".ToUpper()}
                             };
            View.SetMonths(months.ToArray());

            var days = new List<string>();
            const int daysInMonth = 31;

            for (int day = 1; day <= daysInMonth; day++)
            {
                days.Add(day.ToString(CultureInfo.InvariantCulture));
            }

            View.SetDays(days.ToArray());

            int yearsToCount = DateTime.Now.Year;
            var years = new List<string>();
            for (int year = 1900; year <= yearsToCount; year++)
            {
                years.Add(year.ToString(CultureInfo.InvariantCulture));
            }
            View.SetYears(years.ToArray());

        }

        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
