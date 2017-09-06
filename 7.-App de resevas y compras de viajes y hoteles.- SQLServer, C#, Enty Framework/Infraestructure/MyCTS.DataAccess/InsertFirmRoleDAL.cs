using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class InsertFirmRoleDAL
    {
        public InsertFirmRole InsertFirmRole(string Firm, string Pcc, string RoleName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.InsertFirmRoleResources.SP_InsertFirmRole);
            db.AddInParameter(dbcommand, Resources.InsertFirmRoleResources.PARAM_QUERY, DbType.String, Firm);
            db.AddInParameter(dbcommand, Resources.InsertFirmRoleResources.PARAM_QUERY1, DbType.String, Pcc);
            db.AddInParameter(dbcommand, Resources.InsertFirmRoleResources.PARAM_QUERY2, DbType.String, RoleName);

            InsertFirmRole item = null;

            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {

                if (dr.Read())
                {
                    item = new InsertFirmRole();

                }

            }

            return item;
        }
    }
}
