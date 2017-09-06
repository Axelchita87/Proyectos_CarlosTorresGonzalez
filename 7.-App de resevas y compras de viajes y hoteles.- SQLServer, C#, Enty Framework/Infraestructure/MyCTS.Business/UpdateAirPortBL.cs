using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateAirPortBL
    {
        public static void UpdateAirPort(string catAirPorCode, string catAirPorName, string catAirPorCountryId, string catAirPorCountryName)
        {
            UpdateAirPortDAL objAirPorts = new UpdateAirPortDAL();

            try
            {
                objAirPorts.UpdateAirPort(catAirPorCode, catAirPorName, catAirPorCountryId,catAirPorCountryName, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAirPorts.UpdateAirPort(catAirPorCode, catAirPorName, catAirPorCountryId, catAirPorCountryName, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }


    }
}
