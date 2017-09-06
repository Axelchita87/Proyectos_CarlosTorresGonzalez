using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SiteDHLBL
    {
        public static List<SiteDHL> GetSiteDHL()
        {
            List<SiteDHL> SiteDHLList = new List<SiteDHL>();
            SiteDHLDAL objSiteDHL = new SiteDHLDAL();
            try
            {
                try
                {
                    SiteDHLList = objSiteDHL.GetSiteDHL(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    SiteDHLList = objSiteDHL.GetSiteDHL(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return SiteDHLList;

        }
    }
}
