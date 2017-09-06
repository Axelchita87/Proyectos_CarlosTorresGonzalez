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
    public class MyCTSVersionDAL
    {

        public List<MyCTSVersion> SetMyCTSVersion(string Firm, string PCC, string MyCTSVersion, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.MyCTSVersionResources.SP_SetMyCTSVersion);
            db.AddInParameter(dbCommand, Resources.MyCTSVersionResources.PARAM_QUERY, DbType.String, Firm);
            db.AddInParameter(dbCommand, Resources.MyCTSVersionResources.PARAM_QUERY2, DbType.String, PCC);
            db.AddInParameter(dbCommand, Resources.MyCTSVersionResources.PARAM_QUERY3, DbType.String, MyCTSVersion);


            List<MyCTSVersion> MyCTSVersionList = new List<MyCTSVersion>();


            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

            }

            return MyCTSVersionList;
        }

    }
}
