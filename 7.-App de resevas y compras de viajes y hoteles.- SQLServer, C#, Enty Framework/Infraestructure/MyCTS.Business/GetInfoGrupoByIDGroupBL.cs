using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetInfoGroupByIDGroupBL
    {
        private static bool status;
        public static bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public static List<GetInfoGroup> GetInfoGroup(string idGroup, int OrgId)
        {
            List<GetInfoGroup> listGetInfoGroup = new List<GetInfoGroup>();
            GetInfoGroupByIDGroupDAL objInfoGroup = new GetInfoGroupByIDGroupDAL();
            try
            {
                try
                {
                    listGetInfoGroup = objInfoGroup.GetInfoGroupIndex(idGroup, OrgId, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                    status = true;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listGetInfoGroup = objInfoGroup.GetInfoGroupIndex(idGroup, OrgId, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                    status = false;
                }
            }
            catch { status = false; }
            return listGetInfoGroup;
        }
    }
}
