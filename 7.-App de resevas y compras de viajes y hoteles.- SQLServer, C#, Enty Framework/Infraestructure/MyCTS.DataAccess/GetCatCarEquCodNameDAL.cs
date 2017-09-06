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
    public class GetCatCarEquCodNameDAL
    {
        public string GetCatCarEquCodName(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCatCarEquCodNameResources.SP_GETCATCAREQUCODNAME);
            db.AddInParameter(dbCommand, Resources.GetCatCarEquCodNameResources.PARAM_QUERY1, DbType.String, code);
            string equipCode = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _equipCode = dr.GetOrdinal(Resources.GetCatCarEquCodNameResources.PARAM_CATCAREQUCODNAME);
                if (dr.Read())
                {
                    equipCode = dr.GetString(_equipCode);
                }
            }
            return equipCode;

        }
    }
}
