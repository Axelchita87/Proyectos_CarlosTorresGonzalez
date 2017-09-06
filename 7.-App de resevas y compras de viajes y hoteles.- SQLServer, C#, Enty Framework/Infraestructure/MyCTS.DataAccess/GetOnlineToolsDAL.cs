using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class GetOnlineToolsDAL
    {
        public List<GetOnlineTools> GetOnlineTools(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetOnlineToolsResources.SP_GETONLINETOOLS);

            List<GetOnlineTools> getOnlineToolsList = new List<GetOnlineTools>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _toolname = dr.GetOrdinal(Resources.GetOnlineToolsResources.PARAM_TOOLNAME);

                while (dr.Read())
                {
                    GetOnlineTools item = new GetOnlineTools();
                    item.ToolName = dr.GetString(_toolname);
                    getOnlineToolsList.Add(item);
                }
            }
            return getOnlineToolsList;
        }
    }
}
