using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class GetLCCAirlinesDAL
    {
        public List<string> GetLCCAirlines(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetLCCAirlines.SP_GetLCCAirlines);

            List<string> airlinesLCC = new List<string>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    airlinesLCC.Add(dr.GetString(1));
                }
            }
            return airlinesLCC;
        }
    }
}
