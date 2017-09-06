using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{ 
    public class GetTypesCarByCodeDAL
    {
        public string GetTypesCarByCode(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetTypesCarByCodeResources.SP_GETTYPESCARBYCODE);
            db.AddInParameter(dbCommand, Resources.GetTypesCarByCodeResources.PARAM_CODE, DbType.String, code);
            string vendCodeName = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _vendCodeName = dr.GetOrdinal(Resources.GetTypesCarByCodeResources.PARAM_TYPE);
                if (dr.Read())
                {
                    vendCodeName = dr.GetString(_vendCodeName);
                }
            }
            return vendCodeName;
        }
    }
}
