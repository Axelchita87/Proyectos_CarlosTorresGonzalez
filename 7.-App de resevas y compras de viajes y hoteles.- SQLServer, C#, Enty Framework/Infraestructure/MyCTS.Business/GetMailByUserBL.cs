using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetMailByUserBL
    {
        public static List<GetMailByUser> GetMailAndUser(string agent)
        {
            List<GetMailByUser> mailAndUserList = new List<GetMailByUser>();
            GetMailByUserDAL objMailAndUser = new GetMailByUserDAL();
            try
            {
                try
                {
                    mailAndUserList = objMailAndUser.GetUserAndMail(agent, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    mailAndUserList = objMailAndUser.GetUserAndMail(agent, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }
            return mailAndUserList; 
        }
    }
}
