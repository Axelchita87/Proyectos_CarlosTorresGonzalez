using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
  public  class SetClientsCatalogsNextelBL
    {

      public static List<SetClientsCatalogsNextel> SetClientsCatalogsNextel(string Client, string Attribute1, string Attribute2,
                                                            string Attribute3)
      {
          List<SetClientsCatalogsNextel> SetClientsCatalogsNextelList = new List<SetClientsCatalogsNextel>();
          SetClientsCatalogsNextelDAL objSetClientsCatalogsNextel = new SetClientsCatalogsNextelDAL();
          try
          {
              SetClientsCatalogsNextelList = objSetClientsCatalogsNextel.SetClientsCatalogsNextel(CommonENT.MYCTSDB_CONNECTION, Client, Attribute1, Attribute2, Attribute3);
          }
          catch (Exception ex)
          {
              new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
              SetClientsCatalogsNextelList = objSetClientsCatalogsNextel.SetClientsCatalogsNextel(CommonENT.MYCTSDBBACKUP_CONNECTION, Client, Attribute1, Attribute2, Attribute3);
          }
          return SetClientsCatalogsNextelList;
      }
    }
}
