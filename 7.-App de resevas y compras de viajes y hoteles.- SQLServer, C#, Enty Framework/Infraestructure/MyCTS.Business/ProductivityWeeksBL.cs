using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class ProductivityWeeksBL
    {
        public static List<ProductivityWeeks> GetProductivityWeeks()
        {
            List<ProductivityWeeks> ProductivityWeeksList = new List<ProductivityWeeks>();
            ProductivityWeeksDAL objProductivityWeeks = new ProductivityWeeksDAL();
            try
            {
                try
                {
                    ProductivityWeeksList = objProductivityWeeks.GetProductivityWeeks(CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ProductivityWeeksList = objProductivityWeeks.GetProductivityWeeks(CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ProductivityWeeksList;

        }

    }
}
