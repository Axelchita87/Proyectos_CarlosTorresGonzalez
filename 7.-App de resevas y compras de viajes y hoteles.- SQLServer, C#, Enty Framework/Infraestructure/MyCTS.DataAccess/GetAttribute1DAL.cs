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
    public class GetAttribute1DAL
    {
        public GetAttribute1 GetAttribute(string Location, int orgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAttribute1Resources.SP_GetAttribute1);
            db.AddInParameter(dbCommand, Resources.GetAttribute1Resources.PARAM_QUERY, DbType.String, Location);
            db.AddInParameter(dbCommand, Resources.GetAttribute1Resources.PARAM_ORG_ID, DbType.Int32, orgId);

            GetAttribute1 AttributeList = new GetAttribute1();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _attribute = dr.GetOrdinal(Resources.GetAttribute1Resources.ATTRIBUTE1);

                while (dr.Read())
                {
                    GetAttribute1 item = new GetAttribute1();
                    item.Attribute1 = dr.GetString(_attribute);
                    AttributeList = item;

                }

            }

            return AttributeList;
        }

    }
}