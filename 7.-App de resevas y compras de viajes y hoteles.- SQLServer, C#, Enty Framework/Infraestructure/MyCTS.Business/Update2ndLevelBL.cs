using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Update2ndLevelBL
    {
        public static void Update2ndLevel(string Pccid, string Level1, string Level2, string NewLevel2, string Email)
        {
            Update2ndLevelDAL objUpdate2ndLevel = new Update2ndLevelDAL();
            try
            {
                try
                {
                    objUpdate2ndLevel.UpdateStarLevel2(Pccid, Level1, Level2, NewLevel2, Email, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdate2ndLevel.UpdateStarLevel2(Pccid, Level1, Level2, NewLevel2, Email, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
