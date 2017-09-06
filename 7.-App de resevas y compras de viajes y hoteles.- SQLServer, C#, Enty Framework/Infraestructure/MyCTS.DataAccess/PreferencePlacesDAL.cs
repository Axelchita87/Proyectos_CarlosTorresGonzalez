using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class PreferencePlacesDAL
    {
        public List<PreferencePlaces> GetPreferencePlaces(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand("GetCatPreferencePlaces");
            List<PreferencePlaces> list = new List<PreferencePlaces>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    int _values = dr.GetOrdinal("Places");
                    PreferencePlaces item = new PreferencePlaces();
                    item.Places = (dr[_values] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_values);
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
