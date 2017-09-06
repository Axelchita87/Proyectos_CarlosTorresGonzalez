using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAndSetAttributeBackupBL
    {
        public static GetAndSetAttributeBackup GetAttribute(string Location, int OrgId)
        {

            GetAndSetAttributeBackup ItemAttribute = new GetAndSetAttributeBackup();
            GetAndSetAttributeBackupDAL objAttribute = new GetAndSetAttributeBackupDAL();
            try
            {
                try
                {
                    ItemAttribute = objAttribute.GetAttribute(Location, OrgId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ItemAttribute = objAttribute.GetAttribute(Location, OrgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return ItemAttribute;

        }
    }
}
