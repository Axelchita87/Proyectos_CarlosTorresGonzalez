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
    public class GetTicketsByPNRDAL
    {
        public List<string> GetTKTByPNR(string pnr, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetTicketsByPNRResources.SP_GETTICKETBYPNR);
            db.AddInParameter(dbCommand, Resources.GetTicketsByPNRResources.PARAM_QUERY1, DbType.String, pnr);

            List<string> listTickets = new List<string>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _ticket = dr.GetOrdinal(Resources.GetTicketsByPNRResources.PARAM_TICKET);

                while (dr.Read())
                {
                    listTickets.Add(dr.GetString(_ticket));
                }
            }
            return listTickets;
        }
    }
}
