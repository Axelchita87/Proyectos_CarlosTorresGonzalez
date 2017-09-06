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
    public class SubDHLDAL
    {
        public List<SubDHL> GetSubDHL(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SubDHLResources.SP_GetSubDHL);
            List<SubDHL> SubDHLList = new List<SubDHL>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _sub = dr.GetOrdinal(Resources.SubDHLResources.PARAM_SUB);



                while (dr.Read())
                {
                    SubDHL item = new SubDHL();
                    item.Sub = dr.GetString(_sub);
                    SubDHLList.Add(item);
                }
            }

            return SubDHLList;

        }
    }
}
