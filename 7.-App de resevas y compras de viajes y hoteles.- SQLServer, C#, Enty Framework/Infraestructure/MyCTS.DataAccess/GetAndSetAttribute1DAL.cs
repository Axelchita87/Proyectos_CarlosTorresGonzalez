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
    public class GetAndSetAttribute1DAL
    {
        public GetAndSetAttribute1 GetAttribute(string Location, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAndSetAttribute1Resources.SP_GetAttribute1);
            db.AddInParameter(dbCommand, Resources.GetAndSetAttribute1Resources.PARAM_QUERY, DbType.String, Location);
            db.AddInParameter(dbCommand, Resources.GetAndSetAttribute1Resources.PARAM_ORG_ID, DbType.Int32, OrgId);

            GetAndSetAttribute1 AttributeList = new GetAndSetAttribute1();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _attribute = dr.GetOrdinal(Resources.GetAndSetAttribute1Resources.ATTRIBUTE1);

                while (dr.Read())
                {
                    GetAndSetAttribute1 item = new GetAndSetAttribute1();
                    item.Attribute1 = dr.GetString(_attribute);
                    AttributeList = item;

                }

            }

            return AttributeList;
        }

    }
}