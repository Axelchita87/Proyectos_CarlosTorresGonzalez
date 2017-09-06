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
    public class GetCatCarVenCodNameDAL
    {
        public string GetCatCarVenCodName(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCatCarVenCodNameResources.SP_GETCATCARVENCODENAME);
            db.AddInParameter(dbCommand, Resources.GetCatCarVenCodNameResources.PARAM_QUERY1, DbType.String, code);
            string vendCodeName = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _vendCodeName = dr.GetOrdinal(Resources.GetCatCarVenCodNameResources.PARAM_CATCARVENCODENAME);
                if (dr.Read())
                {
                    vendCodeName = dr.GetString(_vendCodeName);
                }
            }
            return vendCodeName;
        }
    }
}
