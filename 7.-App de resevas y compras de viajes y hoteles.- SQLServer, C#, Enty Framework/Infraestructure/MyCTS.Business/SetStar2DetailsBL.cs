using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class SetStar2DetailsBL
    {
        public static void AddStar2Details(Star2Details s2Details)
        {
            var objSetStar2DetailsDAL = new SetStar2DetailsDAL();
            try                            
            {
                try
                {
                    objSetStar2DetailsDAL.SetStar2Details(s2Details, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetStar2DetailsDAL.SetStar2Details(s2Details, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch{ }
        }
    }
}
