using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class LogsApplicationBL
    {

        public static void AddLogApplication(LogsApplication item)
        {
            LogsApplicationDAL objLogApplication = new LogsApplicationDAL();
            try
            {
                try
                {
                    objLogApplication.AddLogApplication(item, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objLogApplication.AddLogApplication(item, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }
        }
    }
}
