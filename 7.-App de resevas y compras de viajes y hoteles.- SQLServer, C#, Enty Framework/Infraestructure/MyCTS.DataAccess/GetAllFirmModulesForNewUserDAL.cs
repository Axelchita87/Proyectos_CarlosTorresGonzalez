using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class GetAllFirmModulesForNewUserDAL
    {
        public TA GetTA(string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmMOdulesForNewUserResources.SP_GetTAForNewUser);
            db.AddInParameter(dbCommand, Resources.GetAllFirmMOdulesForNewUserResources.PARAM_PCC, DbType.String, pcc);
            TA ta = new TA();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _ta = dr.GetOrdinal(Resources.GetAllFirmMOdulesForNewUserResources.PARAM_TA);

                if (dr.Read())
                {
                    ta.Code = (dr[_ta] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ta);
                }
            }

            return ta;
        }

        public IATA GetIATA(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmMOdulesForNewUserResources.SP_GetIATAForNewUser);
            IATA iata = new IATA();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _iata = dr.GetOrdinal(Resources.GetAllFirmMOdulesForNewUserResources.PARAM_IATA);

                if (dr.Read())
                {
                    iata.Code = (dr[_iata] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_iata);
                }
            }

            return iata;
        }

        public Queue GetQUEUE(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmMOdulesForNewUserResources.SP_GetQueueForNewUser);
            Queue queue = new Queue();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _queue = dr.GetOrdinal(Resources.GetAllFirmMOdulesForNewUserResources.PARAM_QUEUE);

                if (dr.Read())
                {
                    queue.QueueCode = (dr[_queue] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_queue);
                }
            }

            return queue;
        }

        public Agent GetAgent(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmMOdulesForNewUserResources.SP_GetAgentForNewUser);
            Agent agent = new Agent();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _agent = dr.GetOrdinal(Resources.GetAllFirmMOdulesForNewUserResources.PARAM_AGENT);

                if (dr.Read())
                {
                    agent.AgentCode = (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
                }
            }

            return agent;
        }

        public Firm GetFirm(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmMOdulesForNewUserResources.SP_GetFirmForNewUser);
            Firm firm = new Firm();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _firm = dr.GetOrdinal(Resources.GetAllFirmMOdulesForNewUserResources.PARAM_FIRM);

                if (dr.Read())
                {
                    firm.FirmNumber = (dr[_firm] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_firm);
                }
            }

            return firm;
        }
    }
}
