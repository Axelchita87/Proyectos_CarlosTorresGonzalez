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
    public class ConsultingFirmDAL
    {
        public List<ConsultingFirm> GetConsultingFirm(string FirmtoSearch,string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ConsultingFirmResources.SP_GetConsultingFirm);
            db.AddInParameter(dbCommand, Resources.ConsultingFirmResources.PARAM_QUERY, DbType.String, FirmtoSearch);

            List<ConsultingFirm> FirmList = new List<ConsultingFirm>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _agent = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_AGENT);
                int _familyname = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_FAMILYNAME);
                int _firm = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_FIRM);
                int _isyysabreblocked = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_ISMYSABREBLOCKED);
                int _myctsversion = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_MYCTSVERSION);
                int _password = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_PASSWORD);
                int _pcc = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_PCC);
                int _queue = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_QUEUE);
                int _ta = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_TA);
                int _usermail = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_USERMAIL);
                int _username = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_USERNAME);
                int _agentmail = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_AGENTMAIL);
                int _statusfirm = dr.GetOrdinal(Resources.ConsultingFirmResources.PARAM_STATUSFIRM);

                while (dr.Read())
                {
                    ConsultingFirm item = new ConsultingFirm();
                    item.Agent = (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
                    item.FamilyName = (dr[_familyname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_familyname);
                    item.Firm = (dr[_firm] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_firm); 
                    item.IsMySabreBlocked = dr.GetBoolean(_isyysabreblocked);
                    item.MyCTSVersion = (dr[_myctsversion] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_myctsversion);
                    item.Password = (dr[_password] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_password);
                    item.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                    item.Queue = (dr[_queue] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_queue);
                    item.TA = (dr[_ta] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ta);
                    item.UserMail = (dr[_usermail] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_usermail);
                    item.AgentMail = (dr[_agentmail] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agentmail);
                    item.StatusFirm = (dr[_statusfirm] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_statusfirm);
                    item.UserName = (dr[_username] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_username);
                    FirmList.Add(item);
                }
            }
            return FirmList;
        }
    }
}
