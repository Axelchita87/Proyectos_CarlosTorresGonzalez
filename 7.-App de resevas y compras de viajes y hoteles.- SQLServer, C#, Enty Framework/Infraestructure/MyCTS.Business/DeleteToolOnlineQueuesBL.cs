using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class DeleteToolOnlineQueuesBL
    {
        public static void DeleteToolOnlineQueues(string StrToSearch)
        {
            DeleteToolOnlineQueuesDAL objDeleteQueue = new DeleteToolOnlineQueuesDAL();
            try
            {
                try
                {
                    objDeleteQueue.DeleteToolOnlineQueues(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteQueue.DeleteToolOnlineQueues(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
