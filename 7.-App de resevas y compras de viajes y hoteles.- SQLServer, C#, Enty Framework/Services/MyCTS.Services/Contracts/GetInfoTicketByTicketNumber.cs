using MyCTS.Services.BuildElectronicTicket;

namespace MyCTS.Services.Contracts
{
    public class GetInfoTicketByTicketNumber
    {
        /// <summary>
        /// Gets the info ticket by ticket number.
        /// </summary>
        /// <param name="sTicketNumber">The s ticket number.</param>
        public TicketInformationObject GetInfoTicketTicketNumber(string sTicketNumber)
        {
            TicketInformationObject respuesta = new TicketInformationObject();

            try
            {
                BuildElectronicTicket.MailProvider ws = new MyCTS.Services.BuildElectronicTicket.MailProvider();
                respuesta = ws.GetInfoTicketByTicketNumber(sTicketNumber);
            }
            catch
            {
                try
                {
                    BuildElectronicTicket.MailProvider ws = new MyCTS.Services.BuildElectronicTicket.MailProvider();
                    respuesta = ws.GetInfoTicketByTicketNumber(sTicketNumber);
                }
                catch { }
            }
            return respuesta;
        }     
    }
}
