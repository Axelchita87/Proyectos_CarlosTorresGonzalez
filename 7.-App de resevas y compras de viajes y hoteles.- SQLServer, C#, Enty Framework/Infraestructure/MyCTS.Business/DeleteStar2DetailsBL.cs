using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    class DeleteStar2DetailsBL
    {
        class DeleteStar2Details
        {
            public static void UpdateStars1Details(string id)
            {
                var objDeleteStar2DetailsDAL = new DeleteStar2DetailsDAL();
                try
                {
                    try
                    {
                        objDeleteStar2DetailsDAL.DeleteS2Details(id, CommonENT.MYCTSDBPROFILES_CONNECTION);
                    }
                    catch (Exception ex)
                    {
                        new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                        objDeleteStar2DetailsDAL.DeleteS2Details(id, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                    }
                }
                catch (Exception e) { }
            }
        }
    }
}
