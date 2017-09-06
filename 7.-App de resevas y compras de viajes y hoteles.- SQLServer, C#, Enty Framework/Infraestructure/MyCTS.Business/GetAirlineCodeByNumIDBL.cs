using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class GetAirlineCodeByNumIDBL
    {
        public static string GetAirlineCode(string numberCode)
        {
            string airlineCode = string.Empty;
            GetAirlineCodeByNumIDDAL objAirline = new GetAirlineCodeByNumIDDAL();
            try
            {
                try
                {
                    airlineCode = objAirline.GetAirlineCode(numberCode, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    airlineCode = objAirline.GetAirlineCode(numberCode, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return airlineCode;
        }
    }
}
