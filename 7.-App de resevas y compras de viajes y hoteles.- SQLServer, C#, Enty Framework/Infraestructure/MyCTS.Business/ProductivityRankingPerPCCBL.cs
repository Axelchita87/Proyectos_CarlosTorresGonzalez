using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ProductivityRankingPerPCCBL
    {
        public static List<ProductivityRankingPerPCC> GetProductivityRankingPerPCC(int IdType, string ProductivityDate, string PCC)
        {
            List<ProductivityRankingPerPCC> ProductivityRankingPerPCCList = new List<ProductivityRankingPerPCC>();
            ProductivityRankingPerPCCDAL objProductivityRankingPerPCC = new ProductivityRankingPerPCCDAL();
            try
            {
                try
                {
                    ProductivityRankingPerPCCList = objProductivityRankingPerPCC.GetProductivityRankingPerPCC(IdType, ProductivityDate,PCC, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ProductivityRankingPerPCCList = objProductivityRankingPerPCC.GetProductivityRankingPerPCC(IdType, ProductivityDate,PCC, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ProductivityRankingPerPCCList;

        }

    }
}
