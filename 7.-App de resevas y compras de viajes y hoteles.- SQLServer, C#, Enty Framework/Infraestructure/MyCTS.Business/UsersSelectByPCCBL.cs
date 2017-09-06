using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UsersSelectByPCCBL
    {
        public static List<UsersSelectByPCC> GetUsersSelectByPCC(string PCC)
        {
            List<UsersSelectByPCC> listUsersSelectByPCC = new List<UsersSelectByPCC>();
            UsersSelectByPCCDAL objProductivity = new UsersSelectByPCCDAL();
            try
            {
                try
                {
                    listUsersSelectByPCC = objProductivity.GetUsersSelectByPCC(PCC,CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listUsersSelectByPCC = objProductivity.GetUsersSelectByPCC(PCC,CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return listUsersSelectByPCC;
        }

    }
}
