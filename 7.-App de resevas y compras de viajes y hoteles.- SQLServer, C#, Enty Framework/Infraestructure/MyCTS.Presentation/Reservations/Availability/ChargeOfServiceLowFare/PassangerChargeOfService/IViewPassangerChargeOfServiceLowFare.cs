using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.PassangerChargeOfService
{
    public interface IViewPassangerChargeOfServiceLowFare : IBaseView
    {

        string PassangerName { get; set; }
        decimal Amount { get; set; }
        bool ApplyChargeOfServce { get; set; }
        FormOfPayment GenericCreditCard { get; set; }
        bool IsAssigned { get; set; }
        IPassanger Passanger { get; set; }
        bool UseCreditCard { get;  }
        bool UseCash { get;  }
        string ChargeOfServiceRemark { get; set; }



    }
}
