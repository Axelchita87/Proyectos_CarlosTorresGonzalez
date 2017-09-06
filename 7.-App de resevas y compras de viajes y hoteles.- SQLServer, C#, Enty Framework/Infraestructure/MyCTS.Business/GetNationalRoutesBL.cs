using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class GetNationalRoutesBL
    {
        public static GetNationalRoutes NationalRoutes(string agent)
        {
            GetNationalRoutes nationalRoutes = new GetNationalRoutes();
            GetNationalRoutesDAL objNationalRoutes = new GetNationalRoutesDAL();
            try
            {
                try
                {
                    nationalRoutes = objNationalRoutes.NationalRoutes(agent, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    nationalRoutes = objNationalRoutes.NationalRoutes(agent, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return nationalRoutes;
        }
    }
}
