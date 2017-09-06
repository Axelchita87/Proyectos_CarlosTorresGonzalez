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
    public class CatSeaVendorsCodesDAL
    {
        public List<ListItem> GetSeaVendorsCodes(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatSeaVendorsCodesResource.SP_GetSeaVendorsCodes);
            db.AddInParameter(dbCommand, Resources.CatSeaVendorsCodesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatSeaVendorsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catseavencodcode = dr.GetOrdinal(Resources.CatSeaVendorsCodesResource.PARAM_CATSEAVENCODCODE);
                int _catseavencodname = dr.GetOrdinal(Resources.CatSeaVendorsCodesResource.PARAM_CATSEAVENCODNAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_catseavencodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catseavencodcode);
                    item.Text =string.Concat(((dr[_catseavencodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catseavencodcode)),' ', 
                    ((dr[_catseavencodname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catseavencodname)));
                    CatSeaVendorsList.Add(item);
                }
            }

            return CatSeaVendorsList;

        }
    }
}
