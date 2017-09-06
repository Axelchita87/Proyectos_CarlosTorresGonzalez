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
    public class GetQCbyAttribute1DAL
    {
        public List<GetQCbyAttribute1> GetAttribute(string attribute, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetQCbyAttribute1Resources.SP_GetQCbyAttribute1);
            db.AddInParameter(dbCommand, Resources.GetQCbyAttribute1Resources.PARAM_QUERY, DbType.String, attribute);

            List<GetQCbyAttribute1> attribute1List = new List<GetQCbyAttribute1>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idctrl = dr.GetOrdinal(Resources.GetQCbyAttribute1Resources.PARAM_IDCTRL);
                int _valuectrl = dr.GetOrdinal(Resources.GetQCbyAttribute1Resources.PARAM_VALUECTRL);
                int _description = dr.GetOrdinal(Resources.GetQCbyAttribute1Resources.PARAM_DESCRIPTION);

                while (dr.Read())
                {
                    GetQCbyAttribute1 item = new GetQCbyAttribute1();
                    item.IdCtrl = dr.GetString(_idctrl);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    item.ValueCtrl = dr.GetString(_valuectrl);
                    attribute1List.Add(item);
                }
            }
            return attribute1List;
        }
    }
}
