using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class GetOnlineToolsBL
    {
        public static List<GetOnlineTools> GetOnlineTools()
        {
            List<GetOnlineTools> onlineToolsList = new List<GetOnlineTools>();
            GetOnlineToolsDAL objOnlineTools = new GetOnlineToolsDAL();
            try
            {
                try
                {
                    onlineToolsList = objOnlineTools.GetOnlineTools(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    onlineToolsList = objOnlineTools.GetOnlineTools(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return onlineToolsList;
        }
    }
}
