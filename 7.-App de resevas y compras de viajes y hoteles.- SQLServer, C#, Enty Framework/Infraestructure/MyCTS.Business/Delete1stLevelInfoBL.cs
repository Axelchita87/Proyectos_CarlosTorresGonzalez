using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Delete1stLevelInfoBL
    {
        public static void Delete1stLevelInfo(string Pccid, string Level1, string lineType, string Text)
        {
            Delete1stLevelInfoDAL objDelete1stLevelInfo = new Delete1stLevelInfoDAL();
            try
            {
                try
                {
                    objDelete1stLevelInfo.DeleteStarLevel1Info(Pccid, Level1, lineType, Text, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDelete1stLevelInfo.DeleteStarLevel1Info(Pccid, Level1, lineType, Text, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
