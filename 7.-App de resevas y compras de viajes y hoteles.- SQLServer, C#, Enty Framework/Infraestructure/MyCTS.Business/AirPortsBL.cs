using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirPortsBL
    {
        public static List<AirPorts> GetAirPorts(string strToSearch)
        {
            List<AirPorts> listAirPorts = new List<AirPorts>();
            AirPortsDAL objAirPorts = new AirPortsDAL();
            try
            {
                try
                {
                    listAirPorts = objAirPorts.GetAirPorts(strToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirPorts = objAirPorts.GetAirPorts(strToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAirPorts;
        }


    }
}
