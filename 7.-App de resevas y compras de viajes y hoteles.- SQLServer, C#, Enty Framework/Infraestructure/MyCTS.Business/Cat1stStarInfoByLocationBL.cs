using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class Cat1stStarInfoByLocationBL
    {
        public static Cat1stStarInfoByLocation Get1stStarInfoByLocation(string Location)
        {
            Cat1stStarInfoByLocation firstStarInfo = new Cat1stStarInfoByLocation();
            Cat1stStarInfoByLocationDAL objGet1stStarInfo = new Cat1stStarInfoByLocationDAL();
            try
            {
                try
                {
                    firstStarInfo = objGet1stStarInfo.GetstStarInfoByLocation(Location, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    firstStarInfo = objGet1stStarInfo.GetstStarInfoByLocation(Location, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return firstStarInfo;
        }
    }
}
