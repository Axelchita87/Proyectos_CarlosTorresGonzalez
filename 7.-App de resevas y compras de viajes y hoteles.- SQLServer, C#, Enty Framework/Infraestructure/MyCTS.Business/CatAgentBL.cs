using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatAgentBL
    {
        public static CatAgent GetSingleAgent(string FirmToSearch, string PCCToSearch)
        {
            CatAgent item = new CatAgent();
            CatAgentDAL objCatAgent = new CatAgentDAL();
            try
            {
                try
                {
                    item = objCatAgent.GetSingleAgent(FirmToSearch, PCCToSearch, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    item = objCatAgent.GetSingleAgent(FirmToSearch, PCCToSearch, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch { }
            return item;
        }

    }
}
