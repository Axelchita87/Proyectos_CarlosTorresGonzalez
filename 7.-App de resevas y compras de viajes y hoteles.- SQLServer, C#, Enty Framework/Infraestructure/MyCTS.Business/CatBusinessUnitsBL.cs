using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatBusinessUnitsBL
    {
        public static List<CatBusinessUnits> GetBusinessUnits()
        {
            List<CatBusinessUnits> listBusinessUnits = new List<CatBusinessUnits>();
            CatBusinessUnitsDAL objBusinessUnits = new CatBusinessUnitsDAL();
            try
            {
                try
                {
                    listBusinessUnits = objBusinessUnits.GetBusinessUnits(UserBL.OrgIdBL, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listBusinessUnits = objBusinessUnits.GetBusinessUnits(UserBL.OrgIdBL, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listBusinessUnits;
        }

    }
}
