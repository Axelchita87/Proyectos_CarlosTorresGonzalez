using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{ 
    public class GetVendorByCodeDAL
    {
        public string GetVendorByCode(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetVendorByCodeResources.SP_GETVENDORBYCODE);
            db.AddInParameter(dbCommand, Resources.GetVendorByCodeResources.PARAM_CODE, DbType.String, code);
            string vendCodeName = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _vendCodeName = dr.GetOrdinal(Resources.GetVendorByCodeResources.PARAM_VENDOR);
                if (dr.Read())
                {
                    vendCodeName = dr.GetString(_vendCodeName);
                }
            }
            return vendCodeName;
        }
    }
}
