using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetZoneByCityBL
    {
        public static string GetZoneByCuty(string city)
        {
            GetZoneByCityDAL objGetZone = new GetZoneByCityDAL();
            string zone = string.Empty;

            try
            {
                try
                {
                    zone = objGetZone.GetZoneByCity(city, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    zone = objGetZone.GetZoneByCity(city, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return zone;
        }
    }
}
