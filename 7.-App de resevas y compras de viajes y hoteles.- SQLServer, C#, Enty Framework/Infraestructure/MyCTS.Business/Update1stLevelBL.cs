using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Update1stLevelBL
    {
        public static void Update1stLevel(string Pccid, string Level1, string NewLevel1,int ProccesId)
        {
            Update1stLevelDAL objUpdate1stLevel = new Update1stLevelDAL();
            try
            {
                try
                {
                    objUpdate1stLevel.UpdateStarLevel1(Pccid, Level1, NewLevel1, ProccesId, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdate1stLevel.UpdateStarLevel1(Pccid, Level1, NewLevel1, ProccesId, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
