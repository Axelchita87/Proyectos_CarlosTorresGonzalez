using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.ContextSolver;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare
{
    public class ChargeOfServiceLowFarePresenter : IBasePresenter<IViewChargeOfServiceLowFare, ChargeOfServiceLowFareRepository>
    {
        #region Miembros de IBasePresenter<IViewChargeOfServiceLowFare,ChargeOfServiceLowFareRepository>

        public IViewChargeOfServiceLowFare View { get; set; }

        public ChargeOfServiceLowFareRepository Repository { get; set; }

        public IProcessContext<List<IPassanger>> Context { get; set; }


        public EventHandler OnComplete { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

        #endregion

        public void LoadChargeOfServiceComponents(List<IPassanger> passangers)
        {

            Context = new ChargeOfServiceContextSolverWinForms
                          {
                              OnCompleted = OnCompleted
                          };
            Context.Resolve(passangers);
        }

        private void OnCompleted(object sender, EventArgs eventArgs)
        {
            if(OnComplete != null)
            {
                OnComplete(sender, eventArgs);
            }
        }
    }
}
