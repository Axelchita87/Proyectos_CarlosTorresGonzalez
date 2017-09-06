using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.DataAccess.Resources;

namespace MyCTS.DataAccess
{
    public class UpdateStatusAllFirmModulesDAL
    {
        public void UpdateStatusTA(string ta, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateStatusTA);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_TA, DbType.String, ta);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateUnassignStatusTA(string ta, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateUnassignStatusTA);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_TA, DbType.String, ta);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateStatusQueue(string queue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateStatusQueue);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_QUEUE, DbType.String, queue);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateUnassignStatusQueue(string queue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateUnassignStatusQueue);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_QUEUE, DbType.String, queue);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateStatusAgent(string agent, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateStatusAgent);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_AGENT, DbType.String, agent);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateUnassignStatusAgent(string agent, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateUnassignStatusAgent);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_AGENT, DbType.String, agent);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateStatusFirm(string firm, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateStatusFirm);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_FIRM, DbType.String, firm);
            db.ExecuteNonQuery(dbcomand);
        }

        public void UpdateUnassignStatusFirm(string firm, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStatusAllFirmModulesResources.SP_UpdateUnassignStatusFirm);
            db.AddInParameter(dbcomand, UpdateStatusAllFirmModulesResources.PARAM_FIRM, DbType.String, firm);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
