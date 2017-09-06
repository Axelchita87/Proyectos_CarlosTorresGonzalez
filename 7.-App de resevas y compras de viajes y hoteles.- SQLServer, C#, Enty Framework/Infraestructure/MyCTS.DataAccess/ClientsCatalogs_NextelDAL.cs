using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
   public  class ClientsCatalogs_NextelDAL
    {
       public List<ListItem> GetCatalog_ClientsCatalogs_Nextel(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ClientsCatalogs_NextelResources.SP_GetCatalog_ClientsCatalogs_Nextel);

            List<ListItem> ClientsCatalogs_NextelList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _value = dr.GetOrdinal(Resources.ClientsCatalogs_NextelResources.PARAM_VALUE);
                int _text = dr.GetOrdinal(Resources.ClientsCatalogs_NextelResources.PARAM_TEXT);
                int _text2 = dr.GetOrdinal(Resources.ClientsCatalogs_NextelResources.PARAM_TEXT2);
                
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_value);
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    
                    ClientsCatalogs_NextelList.Add(item);
                }
            }

            return ClientsCatalogs_NextelList;
        }


      

    }
}
