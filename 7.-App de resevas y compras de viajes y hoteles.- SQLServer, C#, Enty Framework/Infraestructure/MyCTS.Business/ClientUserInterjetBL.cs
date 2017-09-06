using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class ClientUserInterjetBL
    {
        public static void GetClientesUserInterjet(string user)
        {
            ClientUsersInterjetDAL objClientUserInterjet = new ClientUsersInterjetDAL();
            try
            {
                try
                {
                    objClientUserInterjet.GetClientesUserInterjet(user, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objClientUserInterjet.GetClientesUserInterjet(user, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }
    }
}
