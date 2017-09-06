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
    public class ReportVolarisDAL
    {
        public List<ReportVolaris> ReportVolaris(DateTime Fecha, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.ReportVolarisResources.SP_ReportVolaris);
            db.AddInParameter(dbcomand, Resources.ReportInterjetResources.PARAM_QUERY, DbType.DateTime, Fecha);
            db.ExecuteNonQuery(dbcomand);

            List<ReportVolaris> lreport = new List<ReportVolaris>();
            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {
                int _fecha = dr.GetOrdinal(Resources.ReportVolarisResources.PARAM_QUERY);
                int _VolarisPNR = dr.GetOrdinal(Resources.ReportVolarisResources.PARAM_QUERY1);
                int _amount = dr.GetOrdinal(Resources.ReportVolarisResources.PARAM_QUERY2);

                while (dr.Read())
                {
                    ReportVolaris item = new ReportVolaris();
                    item.Fecha = (dr[_fecha] == DBNull.Value) ? Types.StringNullValue : (dr.GetDateTime(_fecha)).ToString();
                    item.VolarisPNR = (dr[_VolarisPNR] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_VolarisPNR)).ToString();
                    item.Amount = (dr[_amount] == DBNull.Value) ? Types.StringNullValue : (dr.GetDecimal(_amount)).ToString();
                    lreport.Add(item);
                }
            }
            return lreport;
        }
    }
}
