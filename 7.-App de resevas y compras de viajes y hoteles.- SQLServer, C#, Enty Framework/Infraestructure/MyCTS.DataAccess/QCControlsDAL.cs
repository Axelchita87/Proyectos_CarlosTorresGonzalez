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
    public class QCControlsDAL
    {
        public List<QCControls> GetQCControls(string Attribute1, string Firm, string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.QCControlsResources.SP_GetQCControls);
            db.AddInParameter(dbCommand, Resources.QCControlsResources.PARAM_QUERY, DbType.String, Attribute1);
            db.AddInParameter(dbCommand, Resources.QCControlsResources.PARAM_QUERY2, DbType.String, Firm);
            db.AddInParameter(dbCommand, Resources.QCControlsResources.PARAM_QUERY3, DbType.String, PCC);

            List<QCControls> QCControlsList = new List<QCControls>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _qcid = dr.GetOrdinal(Resources.QCControlsResources.PARAM_QCID);
                int _acvalue = dr.GetOrdinal(Resources.QCControlsResources.PARAM_QCVALUE);
                int _qcdescription = dr.GetOrdinal(Resources.QCControlsResources.PARAM_QCDESCRIPTION);
                int _ctrltype = dr.GetOrdinal(Resources.QCControlsResources.PARAM_CTRLTYPE);
                int _ctrlname = dr.GetOrdinal(Resources.QCControlsResources.PARAM_CTRLNAME);
                int _ctrldescription = dr.GetOrdinal(Resources.QCControlsResources.PARAM_CTRLDESCRIPTION);
                int _ctrllen = dr.GetOrdinal(Resources.QCControlsResources.PARAM_CTRLLEN);
                int _ctrlcurrentcriteria = dr.GetOrdinal(Resources.QCControlsResources.PARAM_CTRLCURRENTCRITERIA);
                int _allowinsertvalues = dr.GetOrdinal(Resources.QCControlsResources.PARAM_ALLOW_INSERT_VALUES);
                int _ctrlcatalogues = dr.GetOrdinal(Resources.QCControlsResources.PARAM_CTRLCATALOGUES);



                while (dr.Read())
                {
                    QCControls item = new QCControls();

                    item.QCId = (dr[_qcid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qcid);
                    item.QCValue = (dr[_acvalue] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_acvalue);
                    item.QCDescription = (dr[_qcdescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qcdescription);
                    item.CtrlType = (dr[_ctrltype] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrltype);
                    item.CtrlName = (dr[_ctrlname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlname);
                    item.CtrlDescription = (dr[_ctrldescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrldescription);
                    item.CtrlLen = (dr[_ctrllen] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_ctrllen);
                    item.CtrlCurrentCriteria = (dr[_ctrlcurrentcriteria] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlcurrentcriteria);
                    item.CtrlCatalogues = (dr[_ctrlcatalogues] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlcatalogues);
                    item.AllowInsertvalues = dr.GetBoolean(_allowinsertvalues);

                    QCControlsList.Add(item);
                }

            }
            return QCControlsList;
        }
    }
}

