using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisSabreCommandResponsabilityHandler : VolarisResponsabilityHandler
    {
        public override void Execute(VolarisReservation reservation, string securityToken)
        {


            if(ServiceCallSuccess(new SabreCommandService{SecurityToken = securityToken},MessageToSend))
            {
                if(Succesor!= null)
                {
                    Succesor.Execute(reservation,securityToken);
                }
            }
            else
            {
                IgnoreAndCloseSession(securityToken);
            }
        }
    }
}
