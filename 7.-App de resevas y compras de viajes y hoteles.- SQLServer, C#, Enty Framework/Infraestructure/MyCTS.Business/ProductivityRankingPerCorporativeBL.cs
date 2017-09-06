using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
   public class ProductivityRankingPerCorporativeBL
    {
       public static List<ProductivityRankingPerCorporative> GetProductivityRankingPerCorporative(int IdType, string ProductivityDate)
       {
           List<ProductivityRankingPerCorporative> ProductivityRankingPerCorporativeList = new List<ProductivityRankingPerCorporative>();
           ProductivityRankingPerCorporativeDAL objProductivityRankingPerCorporative = new ProductivityRankingPerCorporativeDAL();
           try
           {
               try
               {
                   ProductivityRankingPerCorporativeList = objProductivityRankingPerCorporative.GetProductivityRankingPerCorporative(IdType, ProductivityDate, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
               }
               catch (Exception ex)
               {
                   new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   ProductivityRankingPerCorporativeList = objProductivityRankingPerCorporative.GetProductivityRankingPerCorporative(IdType, ProductivityDate, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
               }
           }
           catch
           { }
           return ProductivityRankingPerCorporativeList;

       }

    }
}
