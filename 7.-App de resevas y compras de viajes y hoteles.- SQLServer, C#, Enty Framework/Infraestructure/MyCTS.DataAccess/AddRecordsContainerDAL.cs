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
    public class AddRecordsContainerDAL
    {
        public void AddRecordsContainer(string recLoc, string Agent, bool EmissionStatus, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddRecordsContainerResources.SP_AddRecordsContainer);
            db.AddInParameter(dbcomand, Resources.AddRecordsContainerResources.PARAM_QUERY, DbType.String, recLoc);
            db.AddInParameter(dbcomand, Resources.AddRecordsContainerResources.PARAM_QUERY2, DbType.String, Agent);
            db.AddInParameter(dbcomand, Resources.AddRecordsContainerResources.PARAM_QUERY3, DbType.Boolean, EmissionStatus);
            //db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY4, DbType.Boolean, DocumentationStatus);
            
            

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
