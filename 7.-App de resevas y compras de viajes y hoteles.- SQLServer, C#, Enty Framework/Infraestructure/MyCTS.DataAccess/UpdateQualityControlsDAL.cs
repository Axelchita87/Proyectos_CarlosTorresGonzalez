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
    public class UpdateQualityControlsDAL
    {
        public void UpdateQualityControls(string description, string iDCtrl, string ctrlType, string ctrlName,
                            string ctrlDescription, int ctrlLen, string ctrlCurrentCriteria,
                            string ctrlCatalogues, bool allowInsertValues, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateQualityControlsResources.SP_UpdateQualityControls);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY1, DbType.String, description);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY2, DbType.String, iDCtrl);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY3, DbType.String, ctrlType);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY4, DbType.String, ctrlName);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY5, DbType.String, ctrlDescription);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY6, DbType.Int32, ctrlLen);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY7, DbType.String, ctrlCurrentCriteria);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY8, DbType.String, ctrlCatalogues);
            db.AddInParameter(dbcomand, Resources.UpdateQualityControlsResources.PARAM_QUERY9, DbType.Boolean, allowInsertValues);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
