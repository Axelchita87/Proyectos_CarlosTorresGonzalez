using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.AvailabilitySearchPanel
{
    public class LowFareAvailabilitySearchPresenter : IBasePresenter<ILowFareAvailabilitySearchView, LowFareAvailabilitySearchRepository>
    {
        #region Miembros de IBasePresenter<ILowFareAvailabilitySearchView,LowFareAvailabilitySearchRepository>

        public ILowFareAvailabilitySearchView View { get; set; }

        public LowFareAvailabilitySearchRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
