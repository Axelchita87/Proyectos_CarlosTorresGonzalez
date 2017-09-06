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
    public class CatMealCodesDAL
    {
        public List<ListItem> GetMealCodes(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatMealCodesResources.SP_GetMealCodes);
            db.AddInParameter(dbCommand, Resources.CatMealCodesResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> CatMealCodesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catmeacodalcode = dr.GetOrdinal(Resources.CatMealCodesResources.PARAM_CATMEACODALCODE);
                int _catmeacodcode = dr.GetOrdinal(Resources.CatMealCodesResources.PARAM_CATMEACODCODE);
                int _catmeacoddescription = dr.GetOrdinal(Resources.CatMealCodesResources.PARAM_CATMEACODDESCRIPCION);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_catmeacodalcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catmeacodalcode);
                    item.Text =string.Concat(((dr[_catmeacodalcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catmeacodalcode)),' ', 
                    ((dr[_catmeacodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catmeacodcode)), ' ',
                    ((dr[_catmeacoddescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catmeacoddescription))); 


                    CatMealCodesList.Add(item);


                }
            }

            return CatMealCodesList;
        }
    }
}
