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
    public class UpdatePriorityByAttribute1DAL
    {
        public void UpdatePriorities(int newPriority, string attribute1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdatePriorityByAttribute1Resources.SP_UPDATEPRIORITYBYATTRIBUTE1);
            db.AddInParameter(dbcomand, Resources.UpdatePriorityByAttribute1Resources.PARAM_QUERY1, DbType.Int32, newPriority);
            db.AddInParameter(dbcomand, Resources.UpdatePriorityByAttribute1Resources.PARAM_QUERY2, DbType.String, attribute1);
            
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
