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
  public class CatCarEquipemetCodesDAL
    {
      public List<ListItem> GetEquipmentCodes(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCarEquipemetCodesResources.SP_GetEquipmentCodes);
            db.AddInParameter(dbCommand, Resources.CatCarEquipemetCodesResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> CarsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcarequcodcode = dr.GetOrdinal(Resources.CatCarEquipemetCodesResources.PARAM_CATCAREQUCODCODE);
                int _catcarequcodname = dr.GetOrdinal(Resources.CatCarEquipemetCodesResources.PARAM_CATCAREQUCODNAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_catcarequcodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcarequcodcode);
                    item.Text =string.Concat(((dr[_catcarequcodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcarequcodcode)),' ',
                    ((dr[_catcarequcodname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcarequcodname)));
                    CarsList.Add(item);

                }
            }

            return CarsList;
        }
    }
}
