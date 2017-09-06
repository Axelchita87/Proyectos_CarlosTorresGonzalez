using MyCTS.Services.BuildElectronicTicket;

namespace MyCTS.Services.Contracts
{
    public class GetInfoPassengerByTicketNumber
    {
        /// <summary>
        /// Obtiene la información de un pasajero en base al número de boleto.
        /// </summary>
        /// <param name="ticketNumber">El número de ticket.</param>
        /// <returns></returns>
        public ObjectTicketByPNR GetInfoPassengerTicketNumber(string sTicketNumber)
        {
            ObjectTicketByPNR respuesta = new ObjectTicketByPNR();
            try
            {
                BuildElectronicTicket.MailProvider ws = new BuildElectronicTicket.MailProvider();
                respuesta = ws.GetInfoPassengerByTicketNumber(sTicketNumber);
            }
            catch
            {
                try
                {
                    BuildElectronicTicket.MailProvider ws = new BuildElectronicTicket.MailProvider();
                    respuesta = ws.GetInfoPassengerByTicketNumber(sTicketNumber);
                }
                catch { }
            }
            return respuesta;
        }
    }
}
