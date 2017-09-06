using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetLogNewFormatProfilesBL
    {
        public static void SetLogNewFormatProfiles(string pccid, string name, string starlevel1, string starlevel2, DateTime modifiedDate)
        {
            SetLogNewFormatProfilesDAL objSetProfile = new SetLogNewFormatProfilesDAL();
            try
            {
                try
                {
                    objSetProfile.SetLogNewFormatProfiles(pccid, name, starlevel1, starlevel2, modifiedDate, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetProfile.SetLogNewFormatProfiles(pccid, name, starlevel1, starlevel2, modifiedDate, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
