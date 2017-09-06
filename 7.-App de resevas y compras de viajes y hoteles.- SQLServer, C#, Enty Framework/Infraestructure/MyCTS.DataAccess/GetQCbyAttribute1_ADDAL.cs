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
    public class GetQCbyAttribute1_ADDAL
    {
        public List<GetQCbyAttribute1_AD> GetAttribute(string attribute, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetQCbyAttribute1_ADResources.SP_GetQCbyAttribute1_AD);
            db.AddInParameter(dbCommand, Resources.GetQCbyAttribute1_ADResources.PARAM_QUERY, DbType.String, attribute);

            List<GetQCbyAttribute1_AD> attribute1List = new List<GetQCbyAttribute1_AD>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idctrl = dr.GetOrdinal(Resources.GetQCbyAttribute1_ADResources.PARAM_IDCTRL);
                int _valuectrl = dr.GetOrdinal(Resources.GetQCbyAttribute1_ADResources.PARAM_VALUECTRL);
                int _description = dr.GetOrdinal(Resources.GetQCbyAttribute1_ADResources.PARAM_DESCRIPTION);

                while (dr.Read())
                {
                    GetQCbyAttribute1_AD item = new GetQCbyAttribute1_AD();
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
