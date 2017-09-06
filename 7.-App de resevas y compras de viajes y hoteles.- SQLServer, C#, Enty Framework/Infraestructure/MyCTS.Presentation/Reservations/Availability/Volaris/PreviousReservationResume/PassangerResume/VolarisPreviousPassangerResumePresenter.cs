using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PassangerResume
{
    public class VolarisPreviousPassangerResumePresenter : IBasePresenter<IVolarisPreviousPassangersResumeView, ucVolarisPreviousPassangersResumeRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPreviousPassangerResumeView,ucVolarisPreviousPassangeResumeRepository>

        public IVolarisPreviousPassangersResumeView View { get; set; }

        public ucVolarisPreviousPassangersResumeRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        /// <summary>
        /// Sets the passanger.
        /// </summary>
        /// <param name="passangers">The passangers.</param>
        public void SetPassanger(VolarisPassangers passangers)
        {
            if (passangers.HasAdults)
            {
                View.SetAdultPassanger(passangers.GetNumbreOfAdults());
            }

            if (passangers.HasChildren)
            {

                View.SetChildPassanger(passangers.GetNumberOfChildren());
            }

            if (passangers.HasInfants)
            {
                View.SetInfantPassanger(passangers.GetNumberOfInfants());
            }

        }
        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
