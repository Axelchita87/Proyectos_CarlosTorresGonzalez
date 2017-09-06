using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class EnableDisableFirmBL
    {
        public static void EnableDisableFirm(string Firm,string PCC, int Active)
        {
            EnableDisableFirmDAL objEnableDisableFirm = new EnableDisableFirmDAL();
            try
            {
                try
                {
                    objEnableDisableFirm.EnableDisableFirm(Firm, PCC, Active, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objEnableDisableFirm.EnableDisableFirm(Firm, PCC, Active, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }

    }
}
