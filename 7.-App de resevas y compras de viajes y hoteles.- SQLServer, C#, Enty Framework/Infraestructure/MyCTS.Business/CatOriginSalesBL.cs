using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatOriginSalesBL
    {
        public static List<CatOriginSales> GetOriginSales()
        {
            List<CatOriginSales> listOriginSales = new List<CatOriginSales>();
            CatOriginSalesDAL objOriginSales = new CatOriginSalesDAL();
            try
            {
                try
                {
                    listOriginSales = objOriginSales.GetOriginSales(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listOriginSales = objOriginSales.GetOriginSales(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listOriginSales;
        }

    }
}
