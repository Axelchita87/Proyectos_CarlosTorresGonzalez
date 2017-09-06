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
    public class CatOriginSalesDAL
    {
        public List<CatOriginSales> GetOriginSales(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.CatOriginSalesResources.SP_GetCatalog_OriginSales);
            //Este StoredProcedure no lleva parametros
            //Lista de parametros

            List<CatOriginSales> GetOriginSalesList = new List<CatOriginSales>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _values = dr.GetOrdinal(Resources.CatOriginSalesResources.PARAM_VALUE);
                int _text = dr.GetOrdinal(Resources.CatOriginSalesResources.PARAM_TEXT);
                int _text2 = dr.GetOrdinal(Resources.CatOriginSalesResources.PARAM_TEXT2);
                

                while (dr.Read())
                {
                    CatOriginSales item = new CatOriginSales();
                    item.Values = (dr[_values] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_values);
                    item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                    item.Text2 = (dr[_text2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text2);
                    GetOriginSalesList.Add(item);
                }

            }
            return GetOriginSalesList;


        }
    }
}
