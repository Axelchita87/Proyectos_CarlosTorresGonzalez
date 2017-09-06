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
   public class CiaDHLDAL
    {

       public List<CiaDHL> GetCiaDHL(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CiaDHLResources.SP_GetCiaDHL);
            List<CiaDHL> CiaDHLList = new List<CiaDHL>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _cia = dr.GetOrdinal(Resources.CiaDHLResources.PARAM_CIA);



                while (dr.Read())
                {
                    CiaDHL item = new CiaDHL();
                    item.Cia = dr.GetString(_cia);
                    CiaDHLList.Add(item);
                }
            }

            return CiaDHLList;

        }

    }
}
