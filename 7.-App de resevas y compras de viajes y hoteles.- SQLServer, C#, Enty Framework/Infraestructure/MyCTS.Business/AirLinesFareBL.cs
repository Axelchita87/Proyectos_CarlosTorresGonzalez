using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
   public class AirLinesFareBL
   {
       public static List<AirLinesFare> GetAirLinesFare()
      {
         List<AirLinesFare> listAirLinesFare = new List<AirLinesFare>();
         AirLinesFareDAL objAirLinesFare = new AirLinesFareDAL();
         try
         {
             try
             {
                 listAirLinesFare = objAirLinesFare.GetAirLinesFare(CommonENT.MYCTSDB_CONNECTION);
             }
             catch (Exception ex)
             {
                 new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                 listAirLinesFare = objAirLinesFare.GetAirLinesFare(CommonENT.MYCTSDBBACKUP_CONNECTION);
             }
         }
         catch
         { }
         return listAirLinesFare;
      }

   }
}
