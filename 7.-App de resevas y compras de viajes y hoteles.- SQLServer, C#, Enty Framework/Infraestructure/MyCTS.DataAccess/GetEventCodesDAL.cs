using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class GetEventCodesDAL
    {
        public static List<ListItem> GetEventCodes(string connectionName, string location, int type)
        {
            List<ListItem> listEventCodes = new List<ListItem>();
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.EventCodesResources.SP_GetEventCodes);
             db.AddInParameter(dbCommand, Resources.EventCodesResources.PARAM_LOCATION, DbType.String, location);
            db.AddInParameter(dbCommand, Resources.EventCodesResources.PARAM_TYPE, DbType.Int32, type);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _code = dr.GetOrdinal(Resources.EventCodesResources.PARAM_EVENT_CODE);
                int _description = dr.GetOrdinal(Resources.EventCodesResources.PARAM_EVENT_DESCRIPTION);
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_code);
                    item.Text = dr.GetString(_description);
                    item.Text2 = string.Format("{0} - {1}", dr.GetString(_code), dr.GetString(_description));
                    listEventCodes.Add(item);
                }
            }

            return listEventCodes;
        }

    }
}
