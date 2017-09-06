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
    public class GetCorporativeFeaturesDAL
    {
        public List<GetCorporativeFeatures> GetCorporativeFeaturesIndex(string fieldValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCorporativeFeatures.SP_GetCorporativeFeatures);
            db.AddInParameter(dbCommand, Resources.GetCorporativeFeatures.PARAM_QUERY1, DbType.String, fieldValue);

            List<GetCorporativeFeatures> getCorporativeFeaturesList = new List<GetCorporativeFeatures>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _c21 = dr.GetOrdinal(Resources.GetCorporativeFeatures.PARAM_C21);
                int _c22 = dr.GetOrdinal(Resources.GetCorporativeFeatures.PARAM_C22);
                while (dr.Read())
                {
                    GetCorporativeFeatures item = new GetCorporativeFeatures();
                    item.C21 = dr.GetInt32(_c21);
                    item.C22 = dr.GetInt32(_c22);
                    getCorporativeFeaturesList.Add(item);

                }

            }

            return getCorporativeFeaturesList;
        }
    }
}
