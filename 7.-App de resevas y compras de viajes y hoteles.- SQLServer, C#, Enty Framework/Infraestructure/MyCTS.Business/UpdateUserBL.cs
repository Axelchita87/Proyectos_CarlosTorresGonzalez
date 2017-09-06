using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateUserBL
    {
        public static void UpdateUser(string Firm, string PCC, string CodeAgent, string UserName, string LoweredUserName,
                               string UserId, string UserMail, string TA, string Queue)
        {
            UpdateUserDAL objUpdateUser = new UpdateUserDAL();
            try
            {
                try
                {
                    objUpdateUser.UpdateUser(Firm, PCC, CodeAgent, UserName, LoweredUserName,UserId, UserMail, TA, Queue, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUpdateUser.UpdateUser(Firm, PCC, CodeAgent, UserName, LoweredUserName, UserId, UserMail, TA, Queue, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }

    }
}
