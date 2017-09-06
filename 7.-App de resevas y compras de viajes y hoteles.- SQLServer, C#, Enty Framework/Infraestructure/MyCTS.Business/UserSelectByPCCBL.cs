using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UserSelectByPCCBL
    {
        public static List<UserSelectByPCC> GetUsersSelectByPCC(string Firm, string PCC)
        {
            List<UserSelectByPCC> listUsersSelectByPCC = new List<UserSelectByPCC>();
            UserSelectByPCCDAL objProductivity = new UserSelectByPCCDAL();
            try
            {
                try
                {
                    listUsersSelectByPCC = objProductivity.GetUsersSelectByPCC(Firm, PCC, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listUsersSelectByPCC = objProductivity.GetUsersSelectByPCC(Firm, PCC, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return listUsersSelectByPCC;
        }

    }
}
