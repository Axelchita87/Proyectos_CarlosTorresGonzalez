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
    public class GetCodeMealToDIXDAL
    {
        public string GetCodeMealToDIX(string codeMeal, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCodeMealToDIXResources.SP_GETCODEMEALTODIX);
            db.AddInParameter(dbCommand, Resources.GetCodeMealToDIXResources.PARAM_QUERY1, DbType.String, codeMeal);
            string descriptionMeal = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _descriptionMeal = dr.GetOrdinal(Resources.GetCodeMealToDIXResources.PARAM_DESCRIPTIONMEAL);
                if (dr.Read())
                {
                    descriptionMeal = dr.GetString(_descriptionMeal);
                }
            }
            return descriptionMeal;
        }
    }
}
