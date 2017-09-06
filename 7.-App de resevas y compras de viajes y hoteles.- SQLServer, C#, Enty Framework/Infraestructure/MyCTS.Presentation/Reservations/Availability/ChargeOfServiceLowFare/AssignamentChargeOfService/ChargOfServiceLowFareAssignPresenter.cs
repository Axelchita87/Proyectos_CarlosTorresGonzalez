using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService
{
    public class ChargOfServiceLowFareAssignPresenter : IBasePresenter<IViewChargeOfServiceLowFareAssign,ChargeOfServiceLowFareAssignRepository>
    {
        #region Miembros de IBasePresenter<IViewChargeOfServiceLowFareAssign,ChargeOfServiceLowFareAssignRepository>

        public IViewChargeOfServiceLowFareAssign View { get; set; }

        public List<IPassanger> Passangers { get; set; }

        public ChargeOfServiceLowFareAssignRepository Repository { get; set; }

        public void InitializeView()
        {
            
        }

        public void UpdateView(object modelObject)
        {
            
        }

        #endregion

        public void LoadData()
        {
            View.CreditCards = Repository.GetCards();
        }
    }
}
