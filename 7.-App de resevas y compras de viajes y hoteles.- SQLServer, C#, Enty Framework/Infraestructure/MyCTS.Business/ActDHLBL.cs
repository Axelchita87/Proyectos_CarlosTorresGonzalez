using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ActDHLBL
    {
        public static List<ActDHL> GetActDHL()
        {
            List<ActDHL> ActDHLList = new List<ActDHL>();
            ActDHLDAL objActDHL = new ActDHLDAL();
            try
            {
                try
                {
                    ActDHLList = objActDHL.GetActDHL(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ActDHLList = objActDHL.GetActDHL(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ActDHLList;

        }

    }
}
