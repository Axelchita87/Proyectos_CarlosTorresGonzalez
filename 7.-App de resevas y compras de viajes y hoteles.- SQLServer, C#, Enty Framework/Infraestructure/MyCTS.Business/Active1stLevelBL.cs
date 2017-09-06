using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Active1stLevelBL
    {
        public static void Active1stLevel(string Pccid, string Level1)
        {
            Active1stLevelDAL objActive1stLevel = new Active1stLevelDAL();
            try
            {
                try
                {
                    objActive1stLevel.ActiveStarLevel1(Pccid, Level1, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objActive1stLevel.ActiveStarLevel1(Pccid, Level1, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
