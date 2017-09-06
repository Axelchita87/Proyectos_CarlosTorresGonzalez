using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ProductivityPCCVsCorporativeBL
    {
        public static List<ProductivityPCCVsCorporative> GetProductivityPCCVsCorporative(string PCC, string ProductivityDate, int IdType)
        {
            List<ProductivityPCCVsCorporative> listProductivityPCCVsCorporative = new List<ProductivityPCCVsCorporative>();
            ProductivityPCCVsCorporativeDAL objProductivity = new ProductivityPCCVsCorporativeDAL();
            try
            {
                try
                {
                    listProductivityPCCVsCorporative = objProductivity.GetProductivityPCCVsCorporative(PCC, ProductivityDate, IdType, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listProductivityPCCVsCorporative = objProductivity.GetProductivityPCCVsCorporative(PCC, ProductivityDate, IdType, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return listProductivityPCCVsCorporative;
        }

    }
}
