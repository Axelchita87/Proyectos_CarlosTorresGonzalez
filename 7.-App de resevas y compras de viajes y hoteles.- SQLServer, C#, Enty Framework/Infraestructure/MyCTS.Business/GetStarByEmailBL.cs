using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetStarByEmailBL
    {
        public List<Star2ndLevelMail> GetStar2LevelMail(string eMail)
        {
            var star2LeveList = new List<Star2ndLevelMail>();
            var objStar2LevelInfo = new GetStarByEmailDAL();
            try
            {
                try
                {
                    star2LeveList = objStar2LevelInfo.GetStar2LevelMail(eMail, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    star2LeveList = objStar2LevelInfo.GetStar2LevelMail(eMail, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return star2LeveList;
        }
    }
}