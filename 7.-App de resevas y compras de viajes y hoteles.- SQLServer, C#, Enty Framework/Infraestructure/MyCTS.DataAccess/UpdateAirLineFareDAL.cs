using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class UpdateAirLineFareDAL
    {
        public void UpdateAirLineFare(string catAirLinFarId, string catAirLinFarName, bool ccAut, bool ccMan,
                            bool cash, bool pMix, bool misc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateAirLineFareResources.SP_UpdateAirLineFare);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY, DbType.String, catAirLinFarId);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY2, DbType.String, catAirLinFarName);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY3, DbType.Boolean, ccAut);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY4, DbType.Boolean, ccMan);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY5, DbType.Boolean, cash);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY6, DbType.Boolean, pMix);
            db.AddInParameter(dbcomand, Resources.UpdateAirLineFareResources.PARAM_QUERY7, DbType.Boolean, misc);

            db.ExecuteNonQuery(dbcomand);
        }


    }
}
