using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Components.NullableHelper;
using System.Collections.Specialized;

namespace MyCTS.DataAccess
{
    public class UserAllAccessDAL
    {
        public string GetUserAllAccess(string PccId, string Firm, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UserAllAccessResources.SP_GetUserAllAccess);
            db.AddInParameter(dbCommand, Resources.UserAllAccessResources.PARAM_PCCID, DbType.String, PccId);
            db.AddInParameter(dbCommand, Resources.UserAllAccessResources.PARAM_FIRM, DbType.String, Firm);


            string UserAllAccess = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _firm = dr.GetOrdinal(Resources.UserAllAccessResources.FIELD_FIRM);

                if (dr.Read())
                {
                    UserAllAccess = dr.GetString(_firm);                
                }

            }

            return UserAllAccess;
        }

    }
}
