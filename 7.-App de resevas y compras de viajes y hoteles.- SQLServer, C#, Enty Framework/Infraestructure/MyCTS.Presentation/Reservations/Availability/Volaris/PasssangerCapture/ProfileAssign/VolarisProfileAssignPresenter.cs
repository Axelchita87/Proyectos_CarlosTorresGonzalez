using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.EventArguments;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign
{
    public class VolarisProfileAssignPresenter : IBasePresenter<IVolarisProfileAssignView, VolarisProfileAssignRepository>
    {
        #region Miembros de IBasePresenter<IVolarisProfileAssignView,VolarisProfileAssignRepository>

        public IProcessContext<SearchProfileEventArgument> Context { get; set; }
        public IVolarisProfileAssignView View { get; set; }

        public VolarisProfileAssignRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }



        public void SearchProfile(SearchProfileEventArgument eventArgument)
        {

            Context.Resolve(eventArgument);
        }

        #endregion
    }
}
