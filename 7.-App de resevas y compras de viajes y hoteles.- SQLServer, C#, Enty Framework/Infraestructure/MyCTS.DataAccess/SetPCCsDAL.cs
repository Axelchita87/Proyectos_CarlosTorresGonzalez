using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class SetPCCsDAL
    {
        public void SetPCCs(string catPccId, string catPccName, string status, string standardClass,
                            string specificClass, string confirmation, string businessClass1,
                            string businessClass2, string businessClass3, string businessClass4, int OrgId,
                            string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetPCCsResources.SP_SetPCCs);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY1, DbType.String, catPccId);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY2, DbType.String, catPccName);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY3, DbType.String, status);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY4, DbType.String, standardClass);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY5, DbType.String, specificClass);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY6, DbType.String, confirmation);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY7, DbType.String, businessClass1);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY8, DbType.String, businessClass2);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY9, DbType.String, businessClass3);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_QUERY10, DbType.String, businessClass4);
            db.AddInParameter(dbcomand, Resources.SetPCCsResources.PARAM_ORG_ID, DbType.Int32, OrgId);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}

