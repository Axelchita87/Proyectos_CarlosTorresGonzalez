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
    public class CatBusCodesDAL
    {
        public List<ListItem> GetBusCodes(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatBusCodesResource.SP_GetBusCodes);
            db.AddInParameter(dbCommand, Resources.CatBusCodesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatBusCodesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catbuscodcode = dr.GetOrdinal(Resources.CatBusCodesResource.PARAM_CATBUSCODCODE);
                int _catbuscodname = dr.GetOrdinal(Resources.CatBusCodesResource.PARAM_CATBUSCODNAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catbuscodcode);
                    item.Text = string.Concat(dr.GetString(_catbuscodcode), ' ', ((dr[_catbuscodname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catbuscodname)));
                    CatBusCodesList.Add(item);
                }
            }

            return CatBusCodesList;

        }
    }
}
