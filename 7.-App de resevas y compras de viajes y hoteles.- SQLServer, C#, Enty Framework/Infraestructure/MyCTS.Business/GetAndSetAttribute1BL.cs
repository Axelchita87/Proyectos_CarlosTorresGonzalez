using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAndSetAttribute1BL
    {
        public static GetAndSetAttribute1 GetAttribute(string Location)
        {

            GetAndSetAttribute1 listAttribute = new GetAndSetAttribute1();
            GetAndSetAttribute1DAL objAttribute = new GetAndSetAttribute1DAL();
            try
            {
                try
                {
                    listAttribute = objAttribute.GetAttribute(Location, UserBL.OrgIdBL, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAttribute = objAttribute.GetAttribute(Location, UserBL.OrgIdBL, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return listAttribute;

        }
    }
}
