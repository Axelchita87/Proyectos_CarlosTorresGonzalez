using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class CatEventCodeBL
    {
        public static List<ListItem> GetEventCodes(string location, int type)
        {
            List<ListItem> EventCodes = new List<ListItem>();            
            try
            {
                try
                {
                    EventCodes = GetEventCodesDAL.GetEventCodes(CommonENT.MYCTSDB_CONNECTION, location, type);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    EventCodes = GetEventCodesDAL.GetEventCodes(CommonENT.MYCTSDB_CONNECTION, location, type);
                }
            }
            catch
            { }
            return EventCodes;
        }
    }
}
