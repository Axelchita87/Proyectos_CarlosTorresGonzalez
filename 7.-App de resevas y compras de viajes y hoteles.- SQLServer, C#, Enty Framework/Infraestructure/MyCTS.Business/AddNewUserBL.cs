using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class AddNewUserBL
    {
        public static void AddNewUser(string userName, string loweredUserName, string userMail, string AgentMail, string lastActivityDate,
                                      string firm, string password, string familyName, string agent, string queue, string pcc,
                                      string ta, string gds)
        {
            AddNewUserDAL objUser = new AddNewUserDAL();
            try
            {
                try
                {
                    objUser.AddNewUser(userName, loweredUserName, userMail, AgentMail, lastActivityDate, firm, password, familyName, agent, queue, pcc, ta, gds, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objUser.AddNewUser(userName, loweredUserName, userMail, AgentMail, lastActivityDate, firm, password, familyName, agent, queue, pcc, ta, gds, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }
    }
}
