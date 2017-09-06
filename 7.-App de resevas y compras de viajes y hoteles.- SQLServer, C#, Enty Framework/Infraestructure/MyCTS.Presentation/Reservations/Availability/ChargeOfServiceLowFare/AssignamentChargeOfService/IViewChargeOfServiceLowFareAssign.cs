using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService
{
    public interface IViewChargeOfServiceLowFareAssign : IBaseView
    {
        List<IPassanger> Passangers { get; set; }
        List<FormOfPayment> CreditCards { get; set; }
    }
}
