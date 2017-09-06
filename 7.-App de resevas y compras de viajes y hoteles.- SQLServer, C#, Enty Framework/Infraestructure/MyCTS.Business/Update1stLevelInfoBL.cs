using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Update1stLevelInfoBL
    {
        public static void Update1stLevel1Info(string Pccid, string Level1, string lineType, string Text, string NewText)
        {
            Update1stLevelInfoDAL objUpdate1stLevel1Info = new Update1stLevelInfoDAL();
            try
            {
                try
                {
                    objUpdate1stLevel1Info.UpdateStarLevel1Info(Pccid, Level1, lineType, Text, NewText, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdate1stLevel1Info.UpdateStarLevel1Info(Pccid, Level1, lineType, Text, NewText, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
