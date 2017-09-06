using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetTicketsByPNRBL
    {
        public static List<string> GetTKTByPNR(string pnr)
        {
            List<string> listTicket = new List<string>();
            GetTicketsByPNRDAL objGetTicket = new GetTicketsByPNRDAL();
            try
            {
                try
                {
                    listTicket = objGetTicket.GetTKTByPNR(pnr, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listTicket = objGetTicket.GetTKTByPNR(pnr, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
            return listTicket;
        }
    }
}
