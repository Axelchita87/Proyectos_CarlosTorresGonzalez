using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetStar1ProfileByDkBL
    {
        public static  List<Star1stLevelInfo> GetStar1ByDk(string customerDk)
        {
            var listtar1ByDk = new List<Star1stLevelInfo>();
            var objStar1ByDk = new GetStarlevel1ByDKDAL();
            try
            {
                try
                {
                    listtar1ByDk = objStar1ByDk.ObjGetStar1ByDk(customerDk, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listtar1ByDk = objStar1ByDk.ObjGetStar1ByDk(customerDk, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return listtar1ByDk;
        }
    }
}
