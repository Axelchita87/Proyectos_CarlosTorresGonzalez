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
    public class GetCatCarTypCodDescriptionDAL
    {
        public string GetCatCarTypCodDescription(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCatCarTypCodDescriptionResources.SP_GETCATCARTYPCODDESCRIPTION);
            db.AddInParameter(dbCommand, Resources.GetCatCarTypCodDescriptionResources.PARAM_QUERY1, DbType.String, code);
            string typeCode = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _typeCode = dr.GetOrdinal(Resources.GetCatCarTypCodDescriptionResources.PARAM_CATCARTYPCODDESCRIPTION);
                if (dr.Read())
                {
                    typeCode = dr.GetString(_typeCode);
                }
            }
            return typeCode;
        }
    }
}
