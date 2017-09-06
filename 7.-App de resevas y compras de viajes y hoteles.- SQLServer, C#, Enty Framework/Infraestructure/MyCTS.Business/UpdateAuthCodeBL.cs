using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateAuthCodeBL
    {
        public static void UpdateAuthCode(string pnr, string authCode, string tickets)
        {
            UpdateAuthCodeDAL objUpdate = new UpdateAuthCodeDAL();

            try 
            {
                try 
                {
                    objUpdate.UpdateAuthCode(pnr, authCode, tickets, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdate.UpdateAuthCode(pnr, authCode, tickets, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
