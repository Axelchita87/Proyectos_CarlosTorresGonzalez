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
    public class AddDetailsTktsLinksDAL
    {
        public void AddDetailsTktsLink(string agent, string pnr, string ticket, string paxName, string linkVT, DateTime dateEmition, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddDetailsTktsLinksResources.SP_AddDetailsTktsLinks);
            db.AddInParameter(dbcomand, Resources.AddDetailsTktsLinksResources.PARAM_QUERY4, DbType.String, agent);
            db.AddInParameter(dbcomand, Resources.AddDetailsTktsLinksResources.PARAM_QUERY1, DbType.String, pnr);
            db.AddInParameter(dbcomand, Resources.AddDetailsTktsLinksResources.PARAM_QUERY2, DbType.String, ticket);
            db.AddInParameter(dbcomand, Resources.AddDetailsTktsLinksResources.PARAM_QUERY3, DbType.String, paxName);
            db.AddInParameter(dbcomand, Resources.AddDetailsTktsLinksResources.PARAM_QUERY5, DbType.String, linkVT);
            db.AddInParameter(dbcomand, Resources.AddDetailsTktsLinksResources.PARAM_QUERY6, DbType.DateTime, dateEmition);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
