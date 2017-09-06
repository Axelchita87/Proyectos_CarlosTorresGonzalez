using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class Delete2ndLevelBL
    {
        public static void Delete2ndLevel(string secondStarName)
        {
            Delete2ndLevelDAL objDelete2ndLevel = new Delete2ndLevelDAL();
            try
            {
                try
                {
                    objDelete2ndLevel.Delete2ndLevel(secondStarName, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDelete2ndLevel.Delete2ndLevel(secondStarName, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
            }
            catch { }
        }
    }
}
