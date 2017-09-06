using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{ 
    public class GetCityNameDAL
    {
        public string GetCityName(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCityNameResources.SP_GETCITYNAME);
            db.AddInParameter(dbCommand, Resources.GetCityNameResources.PARAM_CITYCODE, DbType.String, code);
            string vendCodeName = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _vendCodeName = dr.GetOrdinal(Resources.GetCityNameResources.PARAM_CATCITNAME);
                if (dr.Read())
                {
                    vendCodeName = dr.GetString(_vendCodeName);
                }
            }
            return vendCodeName;
        }
    }
}
