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
    public class SetAuthCodeDAL
    {
        public void SetAuthCode(string pnr, string authCode, string cardType, string amount, string bank, string ticket, DateTime date, string commandWP, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.AuthCodeResources.SP_SetAuthCode);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_PNR, DbType.String, pnr);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_AUTH_CODE, DbType.String, authCode);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_CARD_TYPE, DbType.String, cardType);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_AMOUNT, DbType.String, amount);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_BANK, DbType.String, bank);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_TICKET, DbType.String, ticket);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_DATE, DbType.DateTime, date);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_COMMAND_WP, DbType.String, commandWP);
            db.ExecuteNonQuery(dbcommand);
        }

        public void SetErrorCK(string pnr, string cardType, string amount, string bank, string msg, DateTime date, string commandCK, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.AuthCodeResources.SP_SetAuthCode);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_PNR, DbType.String, pnr);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_AUTH_CODE, DbType.String, null);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_CARD_TYPE, DbType.String, cardType);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_AMOUNT, DbType.String, amount);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_BANK, DbType.String, bank);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_TICKET, DbType.String, msg);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_DATE, DbType.DateTime, date);
            db.AddInParameter(dbcommand, Resources.AuthCodeResources.PARAM_COMMAND_WP, DbType.String, commandCK);
            db.ExecuteNonQuery(dbcommand);
        }
    }
}
