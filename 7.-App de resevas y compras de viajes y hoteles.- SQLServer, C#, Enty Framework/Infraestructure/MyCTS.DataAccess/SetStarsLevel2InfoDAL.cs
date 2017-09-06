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
    public class SetStarsLevel2InfoDAL
    {
        public void AddStarsLevel2Info(string Pccid, string Level1, string Level2, string Type, string Text, DateTime Date, bool Purged, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetStarsLevel2InfoResources.SP_SetStarsLevel2Info);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY2, DbType.String, Level1);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY3, DbType.String, Level2);
            //db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY4, DbType.Int32, Line);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY5, DbType.String, Type);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY6, DbType.String, Text);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY7, DbType.DateTime, Date);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2InfoResources.PARAM_QUERY8, DbType.Boolean, Purged);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
