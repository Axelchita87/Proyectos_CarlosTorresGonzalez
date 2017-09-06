using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetLogNewFormatProfilesBL
    {
        public static List<GetLogNewFormatProfiles> GetLogNewFormatProfiles(string pcc, string level1Name, string level2Name, int level)
        {
            List<GetLogNewFormatProfiles> logList = new List<GetLogNewFormatProfiles>();
            GetLogNewFormatProfilesDAL objGetProfile = new GetLogNewFormatProfilesDAL();
            try
            {
                try
                {
                   logList = objGetProfile.GetLogNewFormatProfiles(pcc, level1Name, level2Name, level, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    logList = objGetProfile.GetLogNewFormatProfiles(pcc, level1Name, level2Name, level, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return logList;
        }
    }
}
