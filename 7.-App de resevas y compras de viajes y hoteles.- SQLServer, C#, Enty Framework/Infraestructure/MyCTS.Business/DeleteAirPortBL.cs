using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeleteAirPortBL
    {
        public static void DeleteAirPort(string catAirPorCode)
        {
            DeleteAirPortDAL objAirPorts = new DeleteAirPortDAL();

            try
            {
                objAirPorts.DeleteAirPorts(catAirPorCode,CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAirPorts.DeleteAirPorts(catAirPorCode,CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }

    }
}
