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
    public class SetStarsLevel1DAL
    {

        public void AddStarsLevel1(string Pccid, string Star1Name, bool StarL2Exist, bool Active, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetStarsLevel1Resources.SP_SetStarsLevel1);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel1Resources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel1Resources.PARAM_QUERY2, DbType.String, Star1Name);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel1Resources.PARAM_QUERY3, DbType.Boolean, StarL2Exist);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel1Resources.PARAM_QUERY4, DbType.Boolean, Active);
           
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
