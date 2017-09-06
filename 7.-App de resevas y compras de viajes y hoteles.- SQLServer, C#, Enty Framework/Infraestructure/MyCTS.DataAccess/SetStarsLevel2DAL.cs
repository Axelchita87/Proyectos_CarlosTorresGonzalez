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
    public class SetStarsLevel2DAL
    {

        public void AddStarsLevel2(string Pccid, string Star1id, string Star2Name, bool Active, string Email, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetStarsLevel2Resources.SP_SetStarsLevel2);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2Resources.PARAM_QUERY, DbType.String, Pccid);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2Resources.PARAM_QUERY2, DbType.String, Star1id);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2Resources.PARAM_QUERY3, DbType.String, Star2Name);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2Resources.PARAM_QUERY4, DbType.Boolean, Active);
            db.AddInParameter(dbcomand, Resources.SetStarsLevel2Resources.PARAM_EMAIL, DbType.String, Email);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
