using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateTicketsLogOnlinePayServicesBL
    {
        public static void UpdateTicketsLogOnlinePayServices(string sFormTypeCodeFOP, int iPaxNumber, string sPNR, string sAutorizacion, string sOperacion, string sTicket, string sRemark)
        {
            UpdateTicketsLogOnlinePayServicesDAL updateTicketRemark = new UpdateTicketsLogOnlinePayServicesDAL();
            try
            {
                updateTicketRemark.UpdateTicketsLogOnlinePayServices(sFormTypeCodeFOP, iPaxNumber, sPNR, sAutorizacion, sOperacion, sTicket, sRemark, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    updateTicketRemark.UpdateTicketsLogOnlinePayServices(sFormTypeCodeFOP, iPaxNumber, sPNR, sAutorizacion, sOperacion, sTicket, sRemark, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}
