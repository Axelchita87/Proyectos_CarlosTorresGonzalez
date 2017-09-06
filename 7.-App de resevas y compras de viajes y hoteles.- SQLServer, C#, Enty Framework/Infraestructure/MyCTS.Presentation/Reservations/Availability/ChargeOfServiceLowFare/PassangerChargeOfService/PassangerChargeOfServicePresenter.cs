using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.PassangerChargeOfService
{
    public  class PassangerChargeOfServicePresenter: IBasePresenter<IViewPassangerChargeOfServiceLowFare,PassangerChargeOfServiceLowFareRepository>
    {
        #region Miembros de IBasePresenter<IViewPassangerChargeOfServiceLowFare,PassangerChargeOfServiceLowFareRepository>


        public void SetPassanger(IPassanger passanger)
        {
            _passanger = passanger;
        }

        private IPassanger _passanger;
        public IPassanger GetPassanger()
        {
            return _passanger;

        }

        public void LoadPassanger()
        {
          
              if(_passanger != null)
              {
                  
                  if(View != null)
                  {

                      View.PassangerName = string.Format("{0}.1 {1}", _passanger.ID, _passanger.FullName);
                      View.Amount = 0.00m;

                  }
              }

        }

        public IViewPassangerChargeOfServiceLowFare View { get; set; }

        public PassangerChargeOfServiceLowFareRepository Repository { get; set; }

        public void InitializeView()
        {
            
        }

        public void UpdateView(object modelObject)
        {
            
        }

        #endregion
    }
}
