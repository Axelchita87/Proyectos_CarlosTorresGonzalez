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
    public class SetLocationDKNotAcceptedDAL
    {
        public List<SetLocationDKNotAccepted> InsertLocationDKNotAccepted(int ruleNumber, string locationDK, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetLocationDKNotAcceptedResources.SP_SETLOCATIONDKNOTACCEPTED);
            db.AddInParameter(dbcomand, Resources.SetLocationDKNotAcceptedResources.PARAM_QUERY1, DbType.Int32, ruleNumber);
            db.AddInParameter(dbcomand, Resources.SetLocationDKNotAcceptedResources.PARAM_QUERY2, DbType.String, locationDK);
            
            List<SetLocationDKNotAccepted> listLocationDK = new List<SetLocationDKNotAccepted>();
            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {
                int _locationDK = dr.GetOrdinal(Resources.SetLocationDKNotAcceptedResources.PARAM_QUERY2);
                while (dr.Read())
                {
                    SetLocationDKNotAccepted item = new SetLocationDKNotAccepted();
                    item.LocationDK = (dr[_locationDK] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_locationDK);
                    listLocationDK.Add(item);
                }
                return listLocationDK;
            }
        }
    }
}
