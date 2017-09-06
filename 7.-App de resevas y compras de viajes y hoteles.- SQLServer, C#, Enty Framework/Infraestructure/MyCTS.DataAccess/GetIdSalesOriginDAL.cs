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
    public class GetIdSalesOriginDAL
    {
        public string GetIdSalesOrigin(string search, string connectionName)
        {
            string Id=string.Empty;
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetIdSalesOriginResources.SP_GetGetIdSalesOrigin);
            db.AddInParameter(dbCommand, Resources.GetIdSalesOriginResources.PARAM_SEARCH, DbType.String, search);
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _idsales = dr.GetOrdinal(Resources.GetIdSalesOriginResources.PARAM_ID);

                    if (dr.Read())
                    {
                        Id = dr.GetString(_idsales);
                    }
                }
            }
            catch { }

            return Id;
        }
    }
}
