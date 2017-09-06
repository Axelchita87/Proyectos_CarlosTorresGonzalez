using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeleteUsersBL
    {
        public static void DeleteUsers(string Firm, string PCC)
        {
            DeleteUsersDAL objDeleteUsers = new DeleteUsersDAL();
            try
            {
                try
                {
                    objDeleteUsers.DeleteUsers(Firm, PCC, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteUsers.DeleteUsers(Firm, PCC, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }

    }
}
