using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAttribute1BL
    {
        public static GetAttribute1 GetAttribute(string Location, int orgId)
        {

            GetAttribute1 listAttribute = new GetAttribute1();
            GetAttribute1DAL objAttribute = new GetAttribute1DAL();
            try
            {
                try
                {
                    listAttribute = objAttribute.GetAttribute(Location, orgId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAttribute = objAttribute.GetAttribute(Location, orgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return listAttribute;

        }
    }
}
