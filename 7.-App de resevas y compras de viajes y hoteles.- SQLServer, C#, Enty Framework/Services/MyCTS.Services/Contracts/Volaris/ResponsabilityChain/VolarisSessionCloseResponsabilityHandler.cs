using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisSessionCloseResponsabilityHandler : VolarisResponsabilityHandler
    {
        public override void Execute(VolarisReservation reservation, string securityToken)
        {
            if (ServiceCallSuccess(new CloseSessionService { SecurityToken = securityToken }, MessageToSend))
            {

            }
        }
    }
}
