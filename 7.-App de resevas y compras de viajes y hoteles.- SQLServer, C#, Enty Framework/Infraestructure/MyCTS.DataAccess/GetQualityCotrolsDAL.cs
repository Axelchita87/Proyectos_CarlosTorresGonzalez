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
    public class GetQualityCotrolsDAL
    {
        public List<GetQualityCotrols> GetQualityCotrols(string idCtrl, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetQualityCotrolsResources.SP_GetQualityCotrols);
            db.AddInParameter(dbCommand, Resources.GetQualityCotrolsResources.PARAM_QUERY, DbType.String, idCtrl);

            List<GetQualityCotrols> QCList = new List<GetQualityCotrols>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _description = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_DESCRIPTION);
                int _iDCtrl = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_IDCTRL);
                int _ctrlType = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_CTRLTYPE);
                int _ctrlDescription = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_CTRLDESCRIPTION);
                int _ctrlLen = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_CTRLLEN);
                int _ctrlCurrentCriteria = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_CTRLCURRENTCRITERIA);
                int _ctrlCatalogues = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_CTRLCATALOGUES);
                int _allowInsertValues = dr.GetOrdinal(Resources.GetQualityCotrolsResources.PARAM_ALLOWINSERTVALUES);

                while (dr.Read())
                {
                    GetQualityCotrols item = new GetQualityCotrols();
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    item.IDCtrl = (dr[_iDCtrl] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_iDCtrl);
                    item.CtrlType = (dr[_ctrlType] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlType);
                    item.CtrlDescription = (dr[_ctrlDescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlDescription);
                    item.CtrlLen = (dr[_ctrlLen] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_ctrlLen);
                    item.CtrlCurrentCriteria = (dr[_ctrlCurrentCriteria] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlCurrentCriteria);
                    item.CtrlCatalogues = (dr[_ctrlCatalogues] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlCatalogues);
                    item.AllowInsertValues = dr.GetBoolean(_allowInsertValues);

                    QCList.Add(item);
                }
            }
            return QCList;
        }
    }
}
