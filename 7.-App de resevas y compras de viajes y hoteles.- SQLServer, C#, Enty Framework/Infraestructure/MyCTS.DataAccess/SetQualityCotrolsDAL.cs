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
    public class SetQualityCotrolsDAL
    {
        public void SetQualityCotrols(string description, string iDCtrl, string ctrlType, string ctrlName,
                            string ctrlDescription, int ctrlLen, string ctrlCurrentCriteria,
                            string ctrlCatalogues, bool allowInsertValues, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetQualityCotrolsResources.SP_SetQualityCotrols);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY, DbType.String, description);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY2, DbType.String, iDCtrl);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY3, DbType.String, ctrlType);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY4, DbType.String, ctrlName);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY5, DbType.String, ctrlDescription);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY6, DbType.Int32, ctrlLen);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY7, DbType.String, ctrlCurrentCriteria);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY8, DbType.String, ctrlCatalogues);
            db.AddInParameter(dbcomand, Resources.SetQualityCotrolsResources.PARAM_QUERY9, DbType.Boolean, allowInsertValues);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
