using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class InsertFirmRoleBL
    {
        public static InsertFirmRole InsertFirmRole(string Firm, string Pcc, string RoleName)
        {
            InsertFirmRole insertFirmRole = new InsertFirmRole();
            InsertFirmRoleDAL objFirmRole = new InsertFirmRoleDAL();

            try
            {
                insertFirmRole = objFirmRole.InsertFirmRole(Firm, Pcc, RoleName, CommonENT.MYCTSDBSECURITY_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                try
                {
                    insertFirmRole = objFirmRole.InsertFirmRole(Firm, Pcc, RoleName, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                catch
                {
                    insertFirmRole.Exist = false;
                }
            }
            return insertFirmRole;
        }
    }
}
