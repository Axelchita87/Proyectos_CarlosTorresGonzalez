using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetInfoGroupBL
    {
        public static List<GetInfoGroup> GetInfoGroup(string pnr, int OrgId)
        {
            List<GetInfoGroup> listGetInfoGroup = new List<GetInfoGroup>();
            GetInfoGroupDAL objInfoGroup = new GetInfoGroupDAL();
            try
            {
                try
                {
                    listGetInfoGroup = objInfoGroup.GetInfoGroupIndex(pnr, OrgId, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listGetInfoGroup = objInfoGroup.GetInfoGroupIndex(pnr, OrgId, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
            return listGetInfoGroup;
        }
    }
}


