using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetCtrlCataloguesBL
    {
        public static List<GetCtrlCatalogues> GetCtrlCatalogues(string ctrlType)
        {
            List<GetCtrlCatalogues> CtrlCataloguesList = new List<GetCtrlCatalogues>();
            GetCtrlCataloguesDAL objCtrlCatalogues = new GetCtrlCataloguesDAL();
            try
            {
                try
                {
                    CtrlCataloguesList = objCtrlCatalogues.GetCtrlCatalogues(ctrlType, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CtrlCataloguesList = objCtrlCatalogues.GetCtrlCatalogues(ctrlType, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return CtrlCataloguesList;
        }
    }
}
