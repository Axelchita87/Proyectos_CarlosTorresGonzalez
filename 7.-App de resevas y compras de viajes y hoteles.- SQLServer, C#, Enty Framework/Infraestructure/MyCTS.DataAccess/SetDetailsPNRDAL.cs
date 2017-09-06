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
    public class SetDetailsPNRDAL
    {
        public void AddDetailsPNR(string recLoc, string origin, string destination, string departureTime,
            string arrivalTime, string airlineCode, string flightNumber, Nullable<DateTime> departureDate,
            string airlineRef, DateTime traveldate,
            string location_dk, Nullable<Decimal> paxNumber, string paxType, string paxName, string paxLastName, string segmentType,
            string fareBasis, string pcc, string idGroup, string masterPNR, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetDetailsPNRResources.SP_SetDetailsPNR);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY, DbType.String, recLoc);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY2, DbType.String, origin);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY3, DbType.String, destination);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY4, DbType.String, departureTime);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY5, DbType.String, arrivalTime);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY6, DbType.String, airlineCode);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY7, DbType.String, flightNumber);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY8, DbType.DateTime, departureDate);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY9, DbType.String, airlineRef);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY10, DbType.DateTime, MyCTSConvert.ToDBValue(traveldate));
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY11, DbType.String, location_dk);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY12, DbType.String, paxNumber);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY13, DbType.String, paxType);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY14, DbType.String, paxName);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY15, DbType.String, paxLastName);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY16, DbType.String, segmentType);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY17, DbType.String, fareBasis);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY18, DbType.String, pcc);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY19, DbType.String, idGroup);
            db.AddInParameter(dbcomand, Resources.SetDetailsPNRResources.PARAM_QUERY20, DbType.String, masterPNR);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
