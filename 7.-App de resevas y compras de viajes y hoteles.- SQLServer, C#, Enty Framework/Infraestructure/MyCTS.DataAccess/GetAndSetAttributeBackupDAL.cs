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
using System.Collections.Specialized;

namespace MyCTS.DataAccess
{
    public class GetAndSetAttributeBackupDAL
    {
        public GetAndSetAttributeBackup GetAttribute(string Location, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAndSetAttributeBackupResources.SP_GetAndSetAttributeBackup);
            db.AddInParameter(dbCommand, Resources.GetAndSetAttributeBackupResources.PARAM_QUERY, DbType.String, Location);
            db.AddInParameter(dbCommand, Resources.GetAndSetAttributeBackupResources.PARAM_ORG_ID, DbType.String, OrgId);


            GetAndSetAttributeBackup Attribute = new GetAndSetAttributeBackup();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _attribute = dr.GetOrdinal(Resources.GetAndSetAttributeBackupResources.ATTRIBUTE1);

                while (dr.Read())
                {
                    GetAndSetAttributeBackup item = new GetAndSetAttributeBackup();
                    item.Attribute1 = dr.GetString(_attribute);
                    Attribute = item;

                }

            }

            return Attribute;
        }

    }
}