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
    public class CatCarTypeCodesDAL
    {
        public List<ListItem> GetTypeCodes(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCarTypeCodesResource.SP_GetTypeCodes);
            db.AddInParameter(dbCommand, Resources.CatCarTypeCodesResource.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> CarsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcartypcodcode = dr.GetOrdinal(Resources.CatCarTypeCodesResource.PARAM_CATCARTYPCODCODE);
                int _catcartypcoddescription = dr.GetOrdinal(Resources.CatCarTypeCodesResource.PARAM_CATCARTYPCODDESCRIPTION);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value= (dr[_catcartypcodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcartypcodcode);
                    item.Text = string.Concat(((dr[_catcartypcodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcartypcodcode)), ' ',
                    ((dr[_catcartypcoddescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcartypcoddescription)));
                    CarsList.Add(item);

                }
            }

            return CarsList;
        }
    }
}
