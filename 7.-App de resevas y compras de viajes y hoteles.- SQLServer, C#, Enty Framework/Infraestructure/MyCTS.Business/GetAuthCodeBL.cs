using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAuthCodeBL
    {
        public static AuthCode GetAuthCode(string pnr)
        {
            AuthCode AuthCode = new AuthCode();
            GetAuthCodeDAL objGetAuthCode = new GetAuthCodeDAL();

            try
            {
                try
                {
                    AuthCode = objGetAuthCode.GetAuthCode(pnr, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    AuthCode = objGetAuthCode.GetAuthCode(pnr, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }

            return AuthCode;
        }
    }
}
