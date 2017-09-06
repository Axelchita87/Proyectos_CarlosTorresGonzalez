using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirlineFOPBL
    {
        public static List<AirlineFOP> GetAirlinFOP(string AirlineToSearch)
        {
            List<AirlineFOP> listAirlinFOP = new List<AirlineFOP>();
            AirlineFOPDAL objAirLineFOP = new AirlineFOPDAL();
            try
            {
                try
                {
                    listAirlinFOP = objAirLineFOP.GetAirlineFOPList(AirlineToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirlinFOP = objAirLineFOP.GetAirlineFOPList(AirlineToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAirlinFOP;
        }
    }
}
