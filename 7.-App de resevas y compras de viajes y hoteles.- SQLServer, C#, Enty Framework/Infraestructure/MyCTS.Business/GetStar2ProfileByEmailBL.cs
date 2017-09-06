using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetStar2ProfileByEmailBL
    {
        public  List<Star2ndLevelInfo> GetStar2LevelInfo(string eMail)
        {
            var star2LeveList = new List<Star2ndLevelInfo>();
            var objStar2LevelInfo = new GetStarLevel2ByEmailDAL();
            try
            {
                try
                {
                    star2LeveList = objStar2LevelInfo.GetStar2LevelInfo(eMail, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    star2LeveList = objStar2LevelInfo.GetStar2LevelInfo(eMail, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return star2LeveList;
        }
    }
}


