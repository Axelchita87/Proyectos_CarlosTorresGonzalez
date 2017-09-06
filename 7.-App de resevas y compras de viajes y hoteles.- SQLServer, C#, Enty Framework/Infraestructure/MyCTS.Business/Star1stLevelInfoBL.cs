using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Star1stLevelInfoBL
    {
        public static List<Star1stLevelInfo> GetStar1stLevelInfo(string Pccid, string Level1)
        {
            List<Star1stLevelInfo> Star1stLeveList = new List<Star1stLevelInfo>();
            Star1stLevelInfoDAL objStar1stLevelInfo = new Star1stLevelInfoDAL();
            try
            {
                try
                {
                    Star1stLeveList = objStar1stLevelInfo.GetStar1stLevelInfo(Pccid, Level1, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    Star1stLeveList = objStar1stLevelInfo.GetStar1stLevelInfo(Pccid, Level1, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return Star1stLeveList;
        }
    }
}
