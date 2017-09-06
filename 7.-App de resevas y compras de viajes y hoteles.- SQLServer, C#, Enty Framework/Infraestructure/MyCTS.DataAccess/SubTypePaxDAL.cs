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
    public class SubTypePaxDAL
    {
        public List<SubTypePax> GetSubTypePax(string fieldValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.SubTypePaxResource.SP_GetSubTypePax);
            db.AddInParameter(dbcommand, Resources.SubTypePaxResource.PARAM_VALUE, DbType.String, fieldValue);

            List<SubTypePax> subtypePaxList = new List<SubTypePax>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _typepaxid = dr.GetOrdinal(Resources.SubTypePaxResource.PARAM_TYPEPAXID);
                int _subtypepaxid = dr.GetOrdinal(Resources.SubTypePaxResource.PARAM_SUBTYPEPAXID);
                int _subtypepaxname = dr.GetOrdinal(Resources.SubTypePaxResource.PARAM_SUBTYPEPAXNAME);

                while (dr.Read())
                {
                    SubTypePax item = new SubTypePax();
                    item.TypePaxID = dr.GetString(_typepaxid);
                    item.SubTypePaxID = dr.GetString(_subtypepaxid);
                    item.SubTypePaxName = dr.GetString(_subtypepaxname);
                    subtypePaxList.Add(item);
                }
            }
            return subtypePaxList;
        }
    }
}
