using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UserAllAccessBL
    {
        public static string GetUserAllAccess(string PccId, string Firm)
        {
            string UserAllAccess = string.Empty;
            UserAllAccessDAL objUserAllAccess = new UserAllAccessDAL();
            try
            {
                try
                {
                    UserAllAccess = objUserAllAccess.GetUserAllAccess(PccId, Firm, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    UserAllAccess = objUserAllAccess.GetUserAllAccess(PccId, Firm, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }

            return UserAllAccess;
        }
    }
}