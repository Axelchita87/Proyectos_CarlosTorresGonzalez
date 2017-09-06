using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateUsersBL
    {
        public static void UpdateUsers(string Firm, string PCC, string CodeAgent, string UserName, string LoweredUserName)
        {
            UpdateUsersDAL objUpdateUsers = new UpdateUsersDAL();
            try
            {
                try
                {
                    objUpdateUsers.UpdateUsers(Firm, PCC, CodeAgent, UserName, LoweredUserName, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdateUsers.UpdateUsers(Firm, PCC, CodeAgent, UserName, LoweredUserName, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
