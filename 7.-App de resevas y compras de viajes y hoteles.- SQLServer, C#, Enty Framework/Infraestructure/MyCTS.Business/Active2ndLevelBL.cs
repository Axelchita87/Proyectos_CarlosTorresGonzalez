using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Active2ndLevelBL
    {
        public static void Active2ndLevel(string Pccid, string Level1, string Level2)
        {
            Active2ndLevelDAL objActive2ndLevel = new Active2ndLevelDAL();
            try
            {
                try
                {
                    objActive2ndLevel.ActiveStarLevel2(Pccid, Level1, Level2, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch(Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objActive2ndLevel.ActiveStarLevel2(Pccid, Level1, Level2, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
