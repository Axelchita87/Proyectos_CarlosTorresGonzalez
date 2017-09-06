using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class OnlyAttribute1DAL
    {
        public string GetOnlyAttribute1(string attribute1,string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.OnlyAttribute1Resources.SP_GetOnlyAttributte1);
            db.AddInParameter(dbCommand, Resources.OnlyAttribute1Resources.PARAM_QUERY, DbType.String, attribute1);

            string listOnlyAttribute = string.Empty;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    int _attribute1 = dr.GetOrdinal(Resources.OnlyAttribute1Resources.PARAM_ATTRIBUTE1);

                    OnlyAttributte1 item = new OnlyAttributte1();

                    item.Attribute1 = (dr[_attribute1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_attribute1);
                    listOnlyAttribute= item.Attribute1;
                }
            }
            return listOnlyAttribute;
        }
    }
}
