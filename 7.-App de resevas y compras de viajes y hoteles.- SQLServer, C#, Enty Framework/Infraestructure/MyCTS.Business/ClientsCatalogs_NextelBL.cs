using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
  public  class ClientsCatalogs_NextelBL
    {
      public static List<ListItem> ListWorkerNumber = null;
      
        public static List<ListItem> GetCatalog_ClientsCatalogs_Nextel()
        {
            List<ListItem> ClientsCatalogs_NextelList = new List<ListItem>();
            ClientsCatalogs_NextelDAL objClientsCatalogs_Nextel = new ClientsCatalogs_NextelDAL();
            try
            {
                try
                {
                    ClientsCatalogs_NextelList = objClientsCatalogs_Nextel.GetCatalog_ClientsCatalogs_Nextel(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ClientsCatalogs_NextelList = objClientsCatalogs_Nextel.GetCatalog_ClientsCatalogs_Nextel(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ClientsCatalogs_NextelList;

        }

      /// <summary>
      /// Codigo para predictivo
      /// </summary>
      /// <returns></returns>
      public static List<ListItem> GetCatalog_ClientsCatalogs_Nextel_Predictive(string StrToSearch)
      {
          if (StrToSearch.Length < 6)
          {
              GetElements(ref ListWorkerNumber);

              //Busca por CatAirLinAlfaId
              return ListWorkerNumber.FindAll(delegate(ListItem li)
              { return (li.Value.StartsWith(StrToSearch)); });
          }
          else
          {
              GetElements(ref ListWorkerNumber);

              //Busca por CatAirLinName
              return ListWorkerNumber.FindAll(delegate(ListItem li)
              { return (li.Text2.StartsWith(StrToSearch)); });
          }
          
      }

      public static void GetElements(ref List<ListItem> list)
      {
          if (list == null)
          {
              ListWorkerNumber = GetCatalog_ClientsCatalogs_Nextel();
          }
      }

      

      

      
    }
}
