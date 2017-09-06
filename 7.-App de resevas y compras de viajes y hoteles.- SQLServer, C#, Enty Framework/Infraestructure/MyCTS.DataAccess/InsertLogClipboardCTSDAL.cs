using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MyCTS.DataAccess
{
    public class InsertLogClipboardCTSDAL
    {
        public int InsertLogClipboardCTS(DateTime date, string agent, Int16 optionUsed, string pnr, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.InsertLogClipboardCTSResources.SP_InsertLogClipboardCTS);
            db.AddInParameter(dbcommand, Resources.InsertLogClipboardCTSResources.PARAM_DATE, DbType.DateTime, date);
            db.AddInParameter(dbcommand, Resources.InsertLogClipboardCTSResources.PARAM_AGENT, DbType.String, agent);
            db.AddInParameter(dbcommand, Resources.InsertLogClipboardCTSResources.PARAM_OPTION_USED, DbType.Int16, optionUsed);
            db.AddInParameter(dbcommand, Resources.InsertLogClipboardCTSResources.PARAM_PNR, DbType.String, pnr);

            IDataReader dr = (SqlDataReader)db.ExecuteReader(dbcommand);

            dr.Read();
            return int.Parse(dr[0].ToString());
        }
    }
}
