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
    public class CteDHLDAL
    {
        public List<CteDHL> GetCteDHL(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CteDHLResources.SP_GetCteDHL);
            List<CteDHL> CteDHLList = new List<CteDHL>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _cte = dr.GetOrdinal(Resources.CteDHLResources.PARAM_CTE);



                while (dr.Read())
                {
                    CteDHL item = new CteDHL();
                    item.Cte = dr.GetString(_cte);
                    CteDHLList.Add(item);
                }
            }

            return CteDHLList;

        }
    }
}
