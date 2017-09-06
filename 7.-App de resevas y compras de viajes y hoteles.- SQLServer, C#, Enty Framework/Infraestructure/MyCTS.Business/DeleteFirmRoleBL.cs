using System;
using MyCTS.DataAccess;
using MyCTS.Entities;


namespace MyCTS.Business
{
    public class DeleteFirmRoleBL
    {
        public static void DeleteFirmRole(string UserName, string RoleName)
        {
            DeleteFirmRoleDAL objDeleteFirmRole = new DeleteFirmRoleDAL();
            try
            {
                try
                {
                    objDeleteFirmRole.DeleteFirmRole(UserName, RoleName, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objDeleteFirmRole.DeleteFirmRole(UserName, RoleName, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}

