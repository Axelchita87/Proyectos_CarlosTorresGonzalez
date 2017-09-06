using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AddDetailsTktsLinksBL
    {
        public static void AddDetailsTktsLinks(string agent, string pnr, string ticket, string paxName, string linkVT, DateTime dateEmition)
        {
            AddDetailsTktsLinksDAL objAddDetailsTktsLinks = new AddDetailsTktsLinksDAL();
            try
            {
                try
                {
                    objAddDetailsTktsLinks.AddDetailsTktsLink(agent, pnr, ticket, paxName, linkVT, dateEmition, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAddDetailsTktsLinks.AddDetailsTktsLink(agent, pnr, ticket, paxName, linkVT, dateEmition, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
