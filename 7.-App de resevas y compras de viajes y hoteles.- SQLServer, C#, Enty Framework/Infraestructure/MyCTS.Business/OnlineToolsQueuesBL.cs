using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class OnlineToolsQueuesBL
    {
        public static List<OnlineToolsQueues> GetOnlineToolsQueues()
        {
            List<OnlineToolsQueues> onlineQueuesList = new List<OnlineToolsQueues>();
            OnlineToolsQueuesDAL objGetQueues = new OnlineToolsQueuesDAL();
            try
            {
                try
                {
                    onlineQueuesList = objGetQueues.GetOnlineToolsQueues(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    onlineQueuesList = objGetQueues.GetOnlineToolsQueues(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return onlineQueuesList;
        } 
    }
}
