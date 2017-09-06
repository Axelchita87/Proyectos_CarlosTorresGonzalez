using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class CatQueueBL
    {
        public static CatQueue GetQueue(string QueueToSearch, string PCCToSearch)
        {
            CatQueue item = new CatQueue();
            CatQueueDAL objCatQueue = new CatQueueDAL();
            try
            {
                try
                {
                    item = objCatQueue.GetQueue(QueueToSearch, PCCToSearch, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    item = objCatQueue.GetQueue(QueueToSearch, PCCToSearch, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
            }
            catch { }
            return item;
        }
    }
}
