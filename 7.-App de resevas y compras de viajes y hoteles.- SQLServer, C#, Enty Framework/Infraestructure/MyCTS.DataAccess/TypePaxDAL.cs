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
   public class TypePaxDAL
    {
       public List<TypePax> GetTypePax(string connectionName)
       {
           Database db = DatabaseFactory.CreateDatabase(connectionName);
           DbCommand dbcommand = db.GetStoredProcCommand(Resources.TypePaxResources.SP_GetTypePax);
           List<TypePax> typePaxList = new List<TypePax>();
           using (IDataReader dr = db.ExecuteReader(dbcommand))
           {
               int _typepaxid = dr.GetOrdinal(Resources.TypePaxResources.PARAM_TYPEPAXID);
               int _typepaxname = dr.GetOrdinal(Resources.TypePaxResources.PARAM_TYPEPAXNAME);
               while (dr.Read())
               {
                   TypePax item = new TypePax();
                   item.TypePaxID = dr.GetString(_typepaxid);
                   item.TypePaxName = dr.GetString(_typepaxname);
                   typePaxList.Add(item);
               }
           }
           return typePaxList;
       }
    }
}
