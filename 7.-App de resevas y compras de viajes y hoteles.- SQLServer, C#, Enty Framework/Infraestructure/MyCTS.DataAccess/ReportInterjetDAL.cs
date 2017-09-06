using System;
using System.Collections;
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
    public class ReportInterjetDAL
    {
        public List<InterJetReport> ReportInterjet(DateTime Fecha, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.ReportInterjetResources.SP_ReportInterjet);
            db.AddInParameter(dbcomand, Resources.ReportInterjetResources.PARAM_QUERY, DbType.DateTime, Fecha);
            db.ExecuteNonQuery(dbcomand);

            List<InterJetReport> lreport = new List<InterJetReport>();
            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {
                int _fecha = dr.GetOrdinal(Resources.ReportInterjetResources.PARAM_QUERY);
                int _ResCode = dr.GetOrdinal(Resources.ReportInterjetResources.PARAM_QUERY1);
                int _amount = dr.GetOrdinal(Resources.ReportInterjetResources.PARAM_QUERY2);
                while (dr.Read())
                {
                    InterJetReport item = new InterJetReport();
                    item.Fecha = (dr[_fecha] == DBNull.Value) ? Types.StringNullValue : (dr.GetDateTime(_fecha)).ToString();
                    item.Tipo_reporte = (dr[_ResCode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ResCode);
                    item.Amount = (dr[_amount] == DBNull.Value) ? Types.StringValue : (dr.GetDecimal(_amount)).ToString();
                    lreport.Add(item);
                }
            }
            return lreport;
        }
    }
}
