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
    public class CatHotelsDAL
    {
        public List<ListItem> GetHotels(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatHotelsResource.SP_GetHotels);
            db.AddInParameter(dbCommand, Resources.CatHotelsResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatHotelsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _cathotcode = dr.GetOrdinal(Resources.CatHotelsResource.PARAM_CATHOTCODE);
                int _cathotnamechain = dr.GetOrdinal(Resources.CatHotelsResource.PARAM_CATHOTNAMECHAIN);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_cathotcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_cathotcode);
                    item.Text = string.Concat((dr[_cathotcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_cathotcode),' ',(dr[_cathotnamechain] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_cathotnamechain));
                    CatHotelsList.Add(item);
                }
            }

            return CatHotelsList;

        }
    }
}
