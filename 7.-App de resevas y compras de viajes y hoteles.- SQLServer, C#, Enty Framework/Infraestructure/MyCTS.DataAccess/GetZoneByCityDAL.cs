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
    public class GetZoneByCityDAL
    {
        public string GetZoneByCity(string city, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetZoneByCityResources.SP_GetZoneByCity);
            db.AddInParameter(dbCommand, Resources.GetZoneByCityResources.PARAM_CITY, DbType.String, city);

            string zone = string.Empty;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _zone = dr.GetOrdinal(Resources.GetZoneByCityResources.PARAM_ZONE);

                try
                {
                    if (dr.Read())
                    {
                        zone = (dr[_zone] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_zone);
                    }
                }
                catch { }
            }

            return zone;
        }
    }
}
