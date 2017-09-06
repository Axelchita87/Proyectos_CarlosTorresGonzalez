using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class GetNationalRoutesDAL
    {
        public GetNationalRoutes NationalRoutes(string route, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetNationalRoutes");
            db.AddInParameter(dbCommand, "@Route", DbType.String, route);
            GetNationalRoutes item = new GetNationalRoutes();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _citCouId = dr.GetOrdinal("CatCitCouId");
                while (dr.Read())
                {
                    item.CatCitCoudId = dr.GetString(_citCouId);
                }
            }

            return item;
        }
    }
}
