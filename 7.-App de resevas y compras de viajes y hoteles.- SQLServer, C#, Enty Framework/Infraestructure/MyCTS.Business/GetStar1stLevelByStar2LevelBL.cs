using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class GetStar1stLevelByStar2LevelBL
    {
        public static Boolean GetStar1stLevelByStar2Level(string level1, string pcc)
        {
            bool isNew = false;

            var objStar1Details =new GetStar1stLevelByStar2LevelDAL();
            try
            {
                try
                {
                    isNew = objStar1Details.GetStar1stLevelByStar2Level(level1, pcc, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    isNew = objStar1Details.GetStar1stLevelByStar2Level(level1, pcc, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            
            return isNew;
        }
    }
}
