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
using System.Data.SqlClient;
namespace MyCTS.DataAccess
{
    public class AddLinksInvoicesPerTicketDAL
    {
        public void AddLinksInvoicesPerTicket(string ticket,int timeOut, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddLinksInvoicesPerTicketResources.SP_AddLinksInvoicesPerTicket);
            dbcomand.CommandTimeout = timeOut;
            db.AddInParameter(dbcomand, Resources.AddLinksInvoicesPerTicketResources.PARAM_QUERY1, DbType.String, ticket);
           
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
