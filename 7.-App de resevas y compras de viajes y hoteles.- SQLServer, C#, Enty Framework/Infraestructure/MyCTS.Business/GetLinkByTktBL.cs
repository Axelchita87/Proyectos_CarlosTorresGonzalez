using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetLinkByTktBL
    {
        public static List<GetLinkByTkt> GetLinkByTkt(string tkt, int OrgId)
        {
            List<GetLinkByTkt> listLink = new List<GetLinkByTkt>();
            GetLinkByTktDAL objLink = new GetLinkByTktDAL();
            try
            {
                try
                {
                    listLink = objLink.GetLinkByTktIndex(tkt, OrgId, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listLink = objLink.GetLinkByTktIndex(tkt, OrgId, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
            return listLink;
        }

    }
}
