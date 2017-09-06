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
    public class ProductivityMonthsDAL
    {
        public List<ProductivityMonths> GetProductivityMonths(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.ProductivityMonthsResources.SP_GetProductivityMonths);

            List<ProductivityMonths> ProductivityMonthsList = new List<ProductivityMonths>();

            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _months = dr.GetOrdinal(Resources.ProductivityMonthsResources.PARAM_MONTHS);
                while (dr.Read())
                {
                    ProductivityMonths item = new ProductivityMonths();
                    item.Months = (dr[_months] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_months);
                    ProductivityMonthsList.Add(item);
                }

            }

            return ProductivityMonthsList;
        }

    }
}
