using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class AddToolsOnlineQueuesBL
    {
        public static void AddToolsOnlineQueues(AddToolsOnlineQueues queue)
        {
            AddToolsOnlineQueuesDAL objQueues = new AddToolsOnlineQueuesDAL();
            try
            {
                try
                {
                    objQueues.AddToolsOnlineQueues(queue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objQueues.AddToolsOnlineQueues(queue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }
    }
}
