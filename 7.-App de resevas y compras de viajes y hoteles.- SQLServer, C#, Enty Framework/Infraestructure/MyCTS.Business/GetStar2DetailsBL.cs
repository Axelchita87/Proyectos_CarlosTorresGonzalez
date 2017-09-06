using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetStar2DetailsBL
    {
        public Star2Details GetStar2Details(string level1, string level2)
        {
            var listStar2Details = new Star2Details();
            var objStar2Details = new GetStar2DetailsDAL();
            try
            {
                try
                {
                    listStar2Details = objStar2Details.ObjGetStar2Details(level1, level2, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listStar2Details = objStar2Details.ObjGetStar2Details(level1, level2, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return listStar2Details;
        }
    }
}
