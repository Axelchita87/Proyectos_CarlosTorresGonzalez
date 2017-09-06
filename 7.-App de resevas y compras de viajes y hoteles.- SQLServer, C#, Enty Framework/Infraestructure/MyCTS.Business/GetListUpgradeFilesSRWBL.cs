using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetListUpgradeFilesSRWBL
    {
        public static List<UpgradeFileSRW> GetListUpgradeFilesSRW()
        {
            List<UpgradeFileSRW> items = null;
            GetListUpgradeFilesSRWDAL objGetListUpgradeFilesSRW = new GetListUpgradeFilesSRWDAL();
            try
            {
                try
                {
                    items = objGetListUpgradeFilesSRW.GetListUpgradeFilesSRW(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    items = objGetListUpgradeFilesSRW.GetListUpgradeFilesSRW(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch { }

            return items;
        }
    }
}
