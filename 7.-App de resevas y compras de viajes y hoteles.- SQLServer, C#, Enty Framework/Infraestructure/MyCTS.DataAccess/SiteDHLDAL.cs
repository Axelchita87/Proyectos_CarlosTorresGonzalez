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
    public class SiteDHLDAL
    {
        public List<SiteDHL> GetSiteDHL(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SiteDHLResources.SP_GetSiteDHL);
            List<SiteDHL> SiteDHLList = new List<SiteDHL>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _site = dr.GetOrdinal(Resources.SiteDHLResources.PARAM_SITE);



                while (dr.Read())
                {
                    SiteDHL item = new SiteDHL();
                    item.Site = dr.GetString(_site);
                    SiteDHLList.Add(item);
                }
            }

            return SiteDHLList;

        }

    }
}
