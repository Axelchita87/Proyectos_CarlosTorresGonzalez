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
    public class GetCtrlCataloguesDAL
    {
        public List<GetCtrlCatalogues> GetCtrlCatalogues(string ctrlType, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCtrlCataloguesResources.SP_GetCtrlCatalogues);
            db.AddInParameter(dbCommand, Resources.GetCtrlCataloguesResources.PARAM_QUERY, DbType.String, ctrlType);

            List<GetCtrlCatalogues> listCtrlCatalogues = new List<GetCtrlCatalogues>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _ctrlname = dr.GetOrdinal(Resources.GetCtrlCataloguesResources.PARAM_CTRLNAME);
                while (dr.Read())
                {
                    GetCtrlCatalogues item = new GetCtrlCatalogues();
                    item.ctrlName = dr.GetString(_ctrlname);
                    listCtrlCatalogues.Add(item);
                }
            }
            return listCtrlCatalogues;
        }
    }
}
