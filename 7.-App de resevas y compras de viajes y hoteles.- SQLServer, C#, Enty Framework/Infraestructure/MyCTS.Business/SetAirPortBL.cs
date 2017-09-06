using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetAirPortBL
    {
        public static void SetAirPorts(string catAirPorCode, string catAirPorName, string catAirPorCountryId, string catAirPorCountryName)
        {
            SetAirPortDAL objAirPorts = new SetAirPortDAL();

            try
            {
                objAirPorts.SetAirPorts(catAirPorCode, catAirPorName, catAirPorCountryId,catAirPorCountryName, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAirPorts.SetAirPorts(catAirPorCode, catAirPorName, catAirPorCountryId,catAirPorCountryName, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }

    }
}
