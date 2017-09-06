using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisAddRemarkResponsabilityHandler : VolarisResponsabilityHandler
    {
        public override void Execute(MyCTS.Entities.VolarisReservation reservation, string securityToken)
        {
            if(ServiceCallSuccess(new AddRemarksService{Reservation = reservation,SecurityToken = securityToken},MessageToSend))
            {
                if(Succesor != null)
                {
                    Succesor.Execute(reservation,securityToken);
                }
            }
        }
    }
}
