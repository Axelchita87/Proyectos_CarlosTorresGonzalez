using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisFraudCheckResponsabilityHandler : VolarisResponsabilityHandler
    {
        public override void Execute(Entities.VolarisReservation reservation, string securityToken)
        {
            if(ServiceCallSuccess(new FraudCheckService{Reservation = reservation,SecurityToken = securityToken},MessageToSend))
            {
               if(Succesor != null)
               {
                   Succesor.Execute(reservation,securityToken);
               }
            }
        }
    }
}
