using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisAirPricingResponsabilityHandler : VolarisResponsabilityHandler
    {
        public override void Execute(VolarisReservation reservation, string securityToken)
        {
            if (ServiceCallSuccess(new AirPriceService { Reservation = reservation, SecurityToken = securityToken }, MessageToSend))
            {
                if (Succesor != null)
                {
                    Succesor.Execute(reservation, securityToken);
                }
            }
            else
            {
                reservation.Status = VolarisReservationStatus.NotAccepted;
                IgnoreAndCloseSession(securityToken);
            }
        }
    }
}
