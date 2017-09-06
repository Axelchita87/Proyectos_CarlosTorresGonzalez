using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AirLinesBL
    {
        public static List<AirLines> GetAirLinesCodesAll(string fieldName, string fieldName2, string fieldValue)
        {
            
            List<AirLines> listAirLines = new List<AirLines>();
            AirLineDAL objAirLines = new AirLineDAL();
            try
            {
                try
                {
                    listAirLines = objAirLines.GetAirLinesCodesAll(fieldName, fieldName2, fieldValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirLines = objAirLines.GetAirLinesCodesAll(fieldName, fieldName2, fieldValue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }
            return listAirLines;

        }
    }
}
