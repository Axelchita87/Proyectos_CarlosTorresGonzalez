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
    public class QCControlsClientsDAL
    {
        public List<QCControlsClients> GetQCControls(string Attribute1, string Firm, string PCC, string Agent, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.QCControlsClientsResources.SP_GetQCControlsClients);
            db.AddInParameter(dbCommand, Resources.QCControlsClientsResources.PARAM_QUERY, DbType.String, Attribute1);
            db.AddInParameter(dbCommand, Resources.QCControlsClientsResources.PARAM_QUERY2, DbType.String, Firm);
            db.AddInParameter(dbCommand, Resources.QCControlsClientsResources.PARAM_QUERY3, DbType.String, PCC);
            db.AddInParameter(dbCommand, Resources.QCControlsClientsResources.PARAM_QUERY4, DbType.String, Agent);

            List<QCControlsClients> QCControlsList = new List<QCControlsClients>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _qcid = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_QCID);
                int _acvalue = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_QCVALUE);
                int _qcdescription = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_QCDESCRIPTION);
                int _ctrltype = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_CTRLTYPE);
                int _reservationctrltype = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_RESERVATIONCTRLTYPE);
                int _ctrlname = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_CTRLNAME);
                int _ctrldescription = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_CTRLDESCRIPTION);
                int _ctrllen = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_CTRLLEN);
                int _ctrlcurrentcriteria = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_CTRLCURRENTCRITERIA);
                int _allowinsertvalues = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_ALLOW_INSERT_VALUES);
                int _ctrlcatalogues = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_CTRLCATALOGUES);
                int _activeqcclient = dr.GetOrdinal(Resources.QCControlsClientsResources.PARAM_ACTIVEQCCLIENT);

                try
                {
                    while (dr.Read())
                    {
                        QCControlsClients item = new QCControlsClients();

                        item.QCId = (dr[_qcid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qcid);
                        item.QCValue = (dr[_acvalue] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_acvalue);
                        item.QCDescription = (dr[_qcdescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qcdescription);
                        item.CtrlType = (dr[_ctrltype] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrltype);
                        item.ReservationCtrlType = (dr[_reservationctrltype] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_reservationctrltype);
                        item.CtrlName = (dr[_ctrlname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlname);
                        item.CtrlDescription = (dr[_ctrldescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrldescription);
                        item.CtrlLen = (dr[_ctrllen] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_ctrllen);
                        item.CtrlCurrentCriteria = (dr[_ctrlcurrentcriteria] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlcurrentcriteria);
                        item.CtrlCatalogues = (dr[_ctrlcatalogues] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ctrlcatalogues);
                        item.AllowInsertvalues = dr.GetBoolean(_allowinsertvalues);
                        item.ActiveQCClient = (dr[_activeqcclient] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_activeqcclient);

                        QCControlsList.Add(item);
                    }
                }
                catch { }
            }
            return QCControlsList;
        }
    }
}

