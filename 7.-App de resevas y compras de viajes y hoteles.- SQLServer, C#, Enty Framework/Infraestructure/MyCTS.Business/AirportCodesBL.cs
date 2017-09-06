using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirportCodesBL
    {
        public static List<AirportCodes> GetAirportCodes(string fieldName,string fieldName2, string fieldValue)
        {
            List<AirportCodes> listAirportCodes = new List<AirportCodes>();
            AirportCodesDAL objAirportCodes = new AirportCodesDAL();
            try
            {
                try
                {
                    listAirportCodes = objAirportCodes.GetAirportCodes(fieldName, fieldName2, fieldValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirportCodes = objAirportCodes.GetAirportCodes(fieldName, fieldName2, fieldValue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch 
            { }
            return listAirportCodes;

        }
    }
}
