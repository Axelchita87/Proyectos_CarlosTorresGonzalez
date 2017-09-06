using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.CustomerDK.ContextSolver;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CustomerDK
{
    public class VolarisCustomerDKPresenter : IBasePresenter<IVolarisCustomerDKView,VolarisCustomerDKRepository>
    {
        #region Miembros de IBasePresenter<IVolarisCustomerDKView,VolarisCustomerDKRepository>

        public IVolarisCustomerDKView View { get; set; }

        public VolarisCustomerDKRepository Repository { get; set; }

        public EventHandler OnSearchCustomerDkCompleted { get; set; }
        public IProcessContext<VolarisReservation> Context { get; set; }
        public void InitializeView()
        {
            
        }

        public void SearchForCustomerDK(string userDk,int logOrgId, VolarisReservation reservation)
        {
            Context = new VolarisContextSolverCustomerDkWinForms
                          {
                              LogOrId = logOrgId,
                              UserDK = userDk,
                              OnCompleted = OnSearchCustomerDkCompleted
                              
                          };
            Context.Resolve(reservation);
        }

        public void UpdateView(object modelObject)
        {
           
        }

        #endregion
    }
}
