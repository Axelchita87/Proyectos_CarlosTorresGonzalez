using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SubDHLBL
    {

        public static List<SubDHL> GetSubDHL()
        {
            List<SubDHL> SubDHLList = new List<SubDHL>();
            SubDHLDAL objSubDHL = new SubDHLDAL();
            try
            {
                try
                {
                    SubDHLList = objSubDHL.GetSubDHL(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    SubDHLList = objSubDHL.GetSubDHL(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return SubDHLList;

        }
    }
}
