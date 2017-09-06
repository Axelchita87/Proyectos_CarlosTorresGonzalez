using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public class GetTicketsPNR
    {
        public static string[] GetTicketsByPNR(string RecLoc)
        {
            BuildElectronicTicket.MailProvider consulta = new MyCTS.Services.BuildElectronicTicket.MailProvider();
            return consulta.GetTicketsByPNR(RecLoc);            
        }
    }
}
