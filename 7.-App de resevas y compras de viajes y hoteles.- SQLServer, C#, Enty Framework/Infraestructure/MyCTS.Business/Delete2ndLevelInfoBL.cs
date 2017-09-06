using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Delete2ndLevelInfoBL
    {

        public static void Delete2ndLevelInfo(string Pccid, string Level1, string Level2, string lineType, string Text)
        {
            Delete2ndLevelInfoDAL objDelete2ndLevelInfo = new Delete2ndLevelInfoDAL();
            try
            {
                try
                {
                    objDelete2ndLevelInfo.DeleteStarLevel2Info(Pccid, Level1, Level2, lineType, Text, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDelete2ndLevelInfo.DeleteStarLevel2Info(Pccid, Level1, Level2, lineType, Text, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}

