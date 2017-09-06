using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetProfileChangesBL
    {
        public static void SetProfile(string pccid, string agent, string starlevel1, string starlevel2, DateTime modifiedDate)
        {
            SetProfileChangesDAL objSetProfile = new SetProfileChangesDAL();
            try
            {
                try
                {
                    objSetProfile.SetProfileChanges(pccid, agent, starlevel1, starlevel2, modifiedDate, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetProfile.SetProfileChanges(pccid, agent, starlevel1, starlevel2, modifiedDate, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
