using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
   public class CatValuesCorporativeQualityControlsBL
    {
       public static List<CatValuesCorporativeQualityControls> GetValuesQualityControls(string DKToSearch, string Firm, string PCC)
       {
           List<CatValuesCorporativeQualityControls> GetValuesCorporativeQualityControlsList = new List<CatValuesCorporativeQualityControls>();
           CatValuesCorporativeQualityControlsDAL objValuesCorporativeQualityControls = new CatValuesCorporativeQualityControlsDAL();
           try
           {
               try
               {
                   GetValuesCorporativeQualityControlsList = objValuesCorporativeQualityControls.GetValuesQualityControls(DKToSearch, Firm, PCC, CommonENT.MYCTSDB_CONNECTION);
               }
               catch (Exception ex)
               {
                   new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   GetValuesCorporativeQualityControlsList = objValuesCorporativeQualityControls.GetValuesQualityControls(DKToSearch, Firm, PCC, CommonENT.MYCTSDBBACKUP_CONNECTION);
               }
               
           }
           catch
           { }
           return GetValuesCorporativeQualityControlsList;

       }
    }
}
