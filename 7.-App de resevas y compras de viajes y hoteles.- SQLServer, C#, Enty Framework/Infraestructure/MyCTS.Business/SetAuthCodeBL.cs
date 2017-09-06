using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetAuthCodeBL
    {
        public static void SetAuthCode(string pnr, string authCode, string cardType, string amount, string bank, string ticket, DateTime date, string commandWP)
        {
            SetAuthCodeDAL objSetAuthCode = new SetAuthCodeDAL();

            try 
            {
                try 
                {
                    objSetAuthCode.SetAuthCode(pnr, authCode, cardType, amount, bank, ticket, date, commandWP, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetAuthCode.SetAuthCode(pnr, authCode, cardType, amount, bank, ticket, date, commandWP, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }


        public static void SetErrorCK(string pnr, string cardType, string amount, string bank, string msg, DateTime date, string commandCK)
        {
            SetAuthCodeDAL objSetErrorCk = new SetAuthCodeDAL();
            try {
                try
                {
                    objSetErrorCk.SetErrorCK(pnr, cardType, amount, bank, msg, date, commandCK, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetErrorCk.SetErrorCK(pnr, cardType, amount, bank, msg, date, commandCK, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
