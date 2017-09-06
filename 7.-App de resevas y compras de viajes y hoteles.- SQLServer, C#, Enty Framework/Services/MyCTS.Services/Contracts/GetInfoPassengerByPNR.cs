using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.BuildElectronicTicket;

namespace MyCTS.Services.Contracts
{
    public class GetInfoPassengerByPNR
    {
        /// <summary>
        /// Obtiene la información de un pasajero en base al número de boleto.
        /// </summary>
        /// <param name="ticketNumber">El número de ticket.</param>
        /// <returns></returns>
        public ObjectTicketByPNR GetInfoPassengerPNR(string sRecLoc)
        {
            ObjectTicketByPNR respuesta = new ObjectTicketByPNR();
            try
            {
                BuildElectronicTicket.MailProvider ws = new BuildElectronicTicket.MailProvider();
                respuesta = ws.GetInfoPassengerByPNR(sRecLoc);
            }
            catch
            {
                try
                {
                    BuildElectronicTicket.MailProvider ws = new BuildElectronicTicket.MailProvider();
                    respuesta = ws.GetInfoPassengerByPNR(sRecLoc);
                }
                catch { }
            }
            return respuesta;
        }
    }
}
