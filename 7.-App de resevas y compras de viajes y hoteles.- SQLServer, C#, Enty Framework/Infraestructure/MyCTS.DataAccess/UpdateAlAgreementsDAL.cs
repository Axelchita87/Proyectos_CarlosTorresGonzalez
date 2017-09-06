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
    public class UpdateAlAgreementsDAL
    {
        public void UpdateAlAgreements(string IDAlCode, string InternationalComission, string DomesticComission,
                                                        string TourCode, string ISO, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UpdateAlAgreementsResources.SP_UpdateAirLineAgreements);
            db.AddInParameter(dbCommand, Resources.UpdateAlAgreementsResources.PARAM_QUERY, DbType.String, IDAlCode);
            db.AddInParameter(dbCommand, Resources.UpdateAlAgreementsResources.PARAM_QUERY2, DbType.String, InternationalComission);
            db.AddInParameter(dbCommand, Resources.UpdateAlAgreementsResources.PARAM_QUERY3, DbType.String, DomesticComission);
            db.AddInParameter(dbCommand, Resources.UpdateAlAgreementsResources.PARAM_QUERY4, DbType.String, TourCode);
            db.AddInParameter(dbCommand, Resources.UpdateAlAgreementsResources.PARAM_QUERY5, DbType.String, ISO);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
