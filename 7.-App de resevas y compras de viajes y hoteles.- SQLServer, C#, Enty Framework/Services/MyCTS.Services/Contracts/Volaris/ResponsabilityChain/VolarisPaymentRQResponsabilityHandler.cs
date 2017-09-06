using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisPaymentRQResponsabilityHandler : VolarisResponsabilityHandler
    {


        public override void Execute(VolarisReservation reservation, string securityToken)
        {
            if (ServiceCallSuccess(new PaymentRQService { Reservation = reservation, SecurityToken = securityToken }, MessageToSend))
            {
                if (Succesor != null)
                {
                    Succesor.Execute(reservation, securityToken);
                }
            }
            else
            {

                IgnoreAndCloseSession(securityToken);
            }
        }
    }
}
