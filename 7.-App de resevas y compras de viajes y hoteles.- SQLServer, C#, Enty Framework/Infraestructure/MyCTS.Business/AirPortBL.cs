using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirPortBL
    {
        public static List<AirPort> GetAirPort(string catAirPorCode)
        {
            List<AirPort> listAirPort = new List<AirPort>();
            AirPortDAL objAirPort = new AirPortDAL();
            try
            {
                try
                {
                    listAirPort = objAirPort.GetAirPort(catAirPorCode, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirPort = objAirPort.GetAirPort(catAirPorCode, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAirPort;
        }

    }
}
