using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class CatSubTypePaxDAL
    {
        public List<string> CatSubTypePax(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatSubTypePax.SP_GetCatSubTypePax);

            List<string> airlinesLCC = new List<string>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    airlinesLCC.Add(dr.GetString(2));
                }
            }
            return airlinesLCC;
        }
    }
}
