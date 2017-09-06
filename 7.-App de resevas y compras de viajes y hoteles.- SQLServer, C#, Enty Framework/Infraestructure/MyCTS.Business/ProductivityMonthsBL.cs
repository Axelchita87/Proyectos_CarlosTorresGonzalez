using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class ProductivityMonthsBL
    {
        public static List<ProductivityMonths> GetProductivityMonths()
        {
            List<ProductivityMonths> ProductivityMonthsList = new List<ProductivityMonths>();
            ProductivityMonthsDAL objProductivityMonths = new ProductivityMonthsDAL();
            try
            {
                try
                {
                    ProductivityMonthsList = objProductivityMonths.GetProductivityMonths(CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ProductivityMonthsList = objProductivityMonths.GetProductivityMonths(CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ProductivityMonthsList;

        }

    }
}
