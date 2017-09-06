using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class ValidateConcludedPNRDAL
    {
        public int ValidateConcludedPNR(string pnr, int orgid, string connectionName)
        {
            int count = 0;

            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ValidateConcludedPNRResources.SP_ValidateConcludedPNR);
            db.AddInParameter(dbCommand, Resources.ValidateConcludedPNRResources.PARAM_QUERY_PNR, DbType.String, pnr);
            db.AddInParameter(dbCommand, Resources.ValidateConcludedPNRResources.PARAM_QUERY_ORG_ID, DbType.Int32, orgid);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _count = dr.GetOrdinal(Resources.ValidateConcludedPNRResources.PARAM_COUNT);
                
                if (dr.Read())
                {
                    count = (dr[_count] == null) ? Types.IntegerNullValue : dr.GetInt32(_count);   
                }
            }          

            return count;
        }
    }
}
