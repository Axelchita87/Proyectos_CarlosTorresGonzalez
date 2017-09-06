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
    public class AirLineDAL
    {
        public List<AirLines> GetAirLinesCodesAll(string fieldName, string fieldName2, string fieldValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirLinesResource.SP_GetAirLinesCodesAll);
            db.AddInParameter(dbCommand, Resources.AirLinesResource.PARAM_QUERY, DbType.String, fieldName);
            db.AddInParameter(dbCommand, Resources.AirLinesResource.PARAM_QUERY2, DbType.String, fieldName2);
            db.AddInParameter(dbCommand, Resources.AirLinesResource.PARAM_VALUE, DbType.String, fieldValue);

            List<AirLines> airlinesList = new List<AirLines>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _airlinealfaid = dr.GetOrdinal(Resources.AirLinesResource.PARAM_AIRLINEALFAID);
                int _airlinename = dr.GetOrdinal(Resources.AirLinesResource.PARAM_AIRLINENAME);
                while (dr.Read())
                {
                    AirLines item = new AirLines();
                    item.AirlineAlfaID = dr.GetString(_airlinealfaid);
                    item.AirlineName = dr.GetString(_airlinename);
                    airlinesList.Add(item);

                }

            }

            return airlinesList;
        }
    
    }
}
