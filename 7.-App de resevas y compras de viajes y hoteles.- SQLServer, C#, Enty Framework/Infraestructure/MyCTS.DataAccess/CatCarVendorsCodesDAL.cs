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
    public class CatCarVendorsCodesDAL
    {
        public List<ListItem> GetVendorCodes(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCarVendorsCodesResources.SP_GetVendorCodes);
            db.AddInParameter(dbCommand, Resources.CatCarVendorsCodesResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> CarsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcarvencodcode = dr.GetOrdinal(Resources.CatCarVendorsCodesResources.PARAM_CATCARVENCODE);
                int _catcarvencodname = dr.GetOrdinal(Resources.CatCarVendorsCodesResources.PARAM_CATVENCODNAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_catcarvencodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcarvencodcode);
                    item.Text = string.Concat(((dr[_catcarvencodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcarvencodcode)), ' ',
                    ((dr[_catcarvencodname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcarvencodname)));
                    CarsList.Add(item);

                }
            }

            return CarsList;
        }
    }
}
