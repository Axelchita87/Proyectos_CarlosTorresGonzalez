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
    public class ActDHLDAL
    {

        public List<ActDHL> GetActDHL(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ActDHLResources.SP_GetActDHL);
            List<ActDHL> ActDHLList = new List<ActDHL>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _act = dr.GetOrdinal(Resources.ActDHLResources.PARAM_ACT);



                while (dr.Read())
                {
                    ActDHL item = new ActDHL();
                    item.Act = dr.GetString(_act);
                    ActDHLList.Add(item);
                }
            }

            return ActDHLList;

        }
    }
}
