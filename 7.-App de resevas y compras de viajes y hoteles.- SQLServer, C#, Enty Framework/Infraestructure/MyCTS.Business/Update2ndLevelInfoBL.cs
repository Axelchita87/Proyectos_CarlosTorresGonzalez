using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Update2ndLevelInfoBL
    {
        public static void Update2ndLevelInfo(string Pccid, string Level1, string Level2, string LineType, string Text, string NewText)
        {
            Update2ndLevelInfoDAL objUpdate2ndLevelInfo = new Update2ndLevelInfoDAL();
            try
            {
                try
                {
                    objUpdate2ndLevelInfo.UpdateStarLevel2Info(Pccid, Level1, Level2, LineType, Text, NewText, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdate2ndLevelInfo.UpdateStarLevel2Info(Pccid, Level1, Level2, LineType, Text, NewText, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
