using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeleteAuthCodeBL
    {
        public static void DeleteAuthCode(string pnr)
        {
            DeleteAuthCodeDAL objDeleteAuthCode = new DeleteAuthCodeDAL();

            try
            {
                try
                {
                    objDeleteAuthCode.DeleteAuthCode(pnr, CommonENT.MYCTSDB_CONNECTION);
                }

                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteAuthCode.DeleteAuthCode(pnr, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
