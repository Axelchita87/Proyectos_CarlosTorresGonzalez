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
    public class CatTransactionDAL
    {
        public void AddTransactions(string agent, string recLoc, string command, DateTime dateCreated, string areaGuid, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatTransactionsResources.SP_AddTransactions);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY, DbType.String, agent);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY2, DbType.String, recLoc);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY3, DbType.String, command);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY5, DbType.DateTime, dateCreated);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY4, DbType.String, areaGuid);

            db.ExecuteNonQuery(dbCommand);                       
        }

        public void AddCommandsTransaction(string agent, string recLoc, string command, DateTime dateCreated, string areaGuid, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatTransactionsResources.SP_AddCommandsTransaction);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY, DbType.String, agent);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY2, DbType.String, recLoc);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY3, DbType.String, command);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY5, DbType.DateTime, dateCreated);
            db.AddInParameter(dbCommand, Resources.CatTransactionsResources.PARAM_QUERY4, DbType.String, areaGuid);

            db.ExecuteNonQuery(dbCommand);           
        }

        /// <summary>
        /// Inserta registros batch de log
        /// </summary>
        /// <param name="sql">Cadena sql con instrucciones de inserción</param>
        /// <param name="connectionName">Cadena conexión</param>
        public void AddCommandsTransaction(string sql, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}

