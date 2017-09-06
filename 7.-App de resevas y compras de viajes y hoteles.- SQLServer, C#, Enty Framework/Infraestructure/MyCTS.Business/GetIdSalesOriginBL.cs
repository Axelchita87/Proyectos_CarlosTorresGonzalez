using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetIdSalesOriginBL
    {
        public static string GetIdSalesOrigin(string search)
        {
            string Id = string.Empty;
            GetIdSalesOriginDAL objIdSales=new GetIdSalesOriginDAL();

            try
            {
                Id = objIdSales.GetIdSalesOrigin(search, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                Id = objIdSales.GetIdSalesOrigin(search, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

            return Id;
        }
    }
}
