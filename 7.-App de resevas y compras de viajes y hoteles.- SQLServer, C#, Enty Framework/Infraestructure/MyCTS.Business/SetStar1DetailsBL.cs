using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetStar1DetailsBL
    {
        public static void AddStars1Details(Star1Details s1Details)
        {
            var objSetStar1DetailsDAL = new SetStar1DetailsDAL();
            try
            {
                try
                {
                    objSetStar1DetailsDAL.AddStar1Details(s1Details, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch(Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetStar1DetailsDAL.AddStar1Details(s1Details, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
