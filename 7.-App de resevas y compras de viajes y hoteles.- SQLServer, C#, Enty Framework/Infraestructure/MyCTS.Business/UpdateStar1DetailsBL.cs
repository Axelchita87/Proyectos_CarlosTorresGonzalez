using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateStar1DetailsBL
    {
        public static void UpdateStar1Details(Star1Details objStar1Details)
        {
            var objUpdateStar1Details = new UpdateStar1DetailsDAL();
            try
            {
                try
                {
                    objUpdateStar1Details.UpdateS1Details(objStar1Details, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdateStar1Details.UpdateS1Details(objStar1Details, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch
            {
            }
        }
    }
}