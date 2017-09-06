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
    public class ProductivityWeeksDAL
    {
        public List<ProductivityWeeks> GetProductivityWeeks(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.ProductivityWeeksResources.SP_GetProductivityWeeks);

            List<ProductivityWeeks> ProductivityWeeksList = new List<ProductivityWeeks>();

            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _weeks = dr.GetOrdinal(Resources.ProductivityWeeksResources.PARAM_WEEKS);
                while (dr.Read())
                {
                    ProductivityWeeks item = new ProductivityWeeks();
                    item.Weeks = (dr[_weeks] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_weeks);
                    ProductivityWeeksList.Add(item);
                }

            }

            return ProductivityWeeksList;
        }

    }
}
