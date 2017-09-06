using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{
    public class SetAirLineAgreementsDAL
    {
        public void SetAirLineAgreements (string IDAlCode, string InternationalComission, string DomesticComission,
                                                                string TourCode,string ISO, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SetAirLineAgreementsResources.SP_SetAirLineAgreements);
            db.AddInParameter(dbCommand, Resources.SetAirLineAgreementsResources.PARAM_QUERY, DbType.String, IDAlCode);
            db.AddInParameter(dbCommand, Resources.SetAirLineAgreementsResources.PARAM_QUERY2, DbType.String, InternationalComission);
            db.AddInParameter(dbCommand, Resources.SetAirLineAgreementsResources.PARAM_QUERY3, DbType.String, DomesticComission);
            db.AddInParameter(dbCommand, Resources.SetAirLineAgreementsResources.PARAM_QUERY4, DbType.String, TourCode);
            db.AddInParameter(dbCommand, Resources.SetAirLineAgreementsResources.PARAM_QUERY5, DbType.String, ISO);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}
