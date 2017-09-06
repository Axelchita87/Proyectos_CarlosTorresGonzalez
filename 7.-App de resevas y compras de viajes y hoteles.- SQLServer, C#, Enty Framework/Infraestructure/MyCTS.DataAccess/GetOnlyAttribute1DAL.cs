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
    public class GetOnlyAttribute1DAL
    {
        public List<GetOnlyAttribute1> GetAttribute(string attribute, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetOnlyAttribute1Resources.SP_GETONLYATTRIBUTE1MyCTS);
            db.AddInParameter(dbCommand, Resources.GetOnlyAttribute1Resources.PARAM_QUERY1, DbType.String, attribute);
            //db.AddInParameter(dbCommand, Resources.GetOnlyAttribute1Resources.PARAM_ORG_ID, DbType.Int32, orgId);

            List<GetOnlyAttribute1> attribute1List = new List<GetOnlyAttribute1>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _locationDK = dr.GetOrdinal(Resources.GetOnlyAttribute1Resources.PARAM_LOCATION);
                while (dr.Read())
                {
                    GetOnlyAttribute1 item = new GetOnlyAttribute1();
                    item.LocationDK = dr.GetString(_locationDK);
                    attribute1List.Add(item);
                }
            }
            return attribute1List;
        }
    }
}
