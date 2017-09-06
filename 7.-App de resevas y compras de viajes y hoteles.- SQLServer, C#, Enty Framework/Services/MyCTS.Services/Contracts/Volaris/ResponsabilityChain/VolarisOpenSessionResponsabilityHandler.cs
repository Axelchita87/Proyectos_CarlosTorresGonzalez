using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisOpenSessionResponsabilityHandler : VolarisResponsabilityHandler
    {
        public override void Execute(VolarisReservation reservation, string securityToken)
        {
            var service = new OpenSessionService { SecurityToken = securityToken };
            if (ServiceCallSuccess(service, MessageToSend))
            {
                if (Succesor != null)
                {
                    Succesor.Execute(reservation, service.SecurityToken);
                }
            }
            else
            {
                reservation.Status = VolarisReservationStatus.NotAccepted;
                CloseSession(service.SecurityToken);
            }
        }
    }
}
