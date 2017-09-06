using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Star2ndLevelInfoBL
    {
        public static List<Star2ndLevelInfo> GetStar2ndLevelInfo(string Pccid, string Level1, string Level2)
        {
            List<Star2ndLevelInfo> Star2ndLeveList = new List<Star2ndLevelInfo>();
            Star2ndLevelInfoDAL objStar2ndLevelInfo = new Star2ndLevelInfoDAL();
            try
            {
                try
                {
                    Star2ndLeveList = objStar2ndLevelInfo.GetStar2ndLevelInfo(Pccid, Level1, Level2, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    Star2ndLeveList = objStar2ndLevelInfo.GetStar2ndLevelInfo(Pccid, Level1, Level2, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return Star2ndLeveList;
        }
    }
}