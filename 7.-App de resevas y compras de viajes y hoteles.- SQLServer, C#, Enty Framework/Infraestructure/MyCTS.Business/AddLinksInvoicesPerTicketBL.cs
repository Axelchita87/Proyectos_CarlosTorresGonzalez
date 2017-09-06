using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AddLinksInvoicesPerTicketBL
    {
        public static void AddLinksInvoicesPerTicket(string ticket, int timeOut)
        {
            AddLinksInvoicesPerTicketDAL objAddLinksInvoices = new AddLinksInvoicesPerTicketDAL();
            try
            {
                try
                {
                    objAddLinksInvoices.AddLinksInvoicesPerTicket(ticket, timeOut, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAddLinksInvoices.AddLinksInvoicesPerTicket(ticket, timeOut, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
