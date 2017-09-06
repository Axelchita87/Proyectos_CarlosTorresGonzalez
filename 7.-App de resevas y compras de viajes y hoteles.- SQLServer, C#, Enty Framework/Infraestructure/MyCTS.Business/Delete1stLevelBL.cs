using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class Delete1stLevelBL
    {
        public static void Delete1stLevel(string pcc, string firstStarName)
        {
            Delete1stLevelDAL objDelete1stLevel = new Delete1stLevelDAL();
            try
            {
                try
                {
                    objDelete1stLevel.Delete1stLevel(pcc, firstStarName, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDelete1stLevel.Delete1stLevel(pcc, firstStarName, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
            }
            catch { }
        }
    }
}
