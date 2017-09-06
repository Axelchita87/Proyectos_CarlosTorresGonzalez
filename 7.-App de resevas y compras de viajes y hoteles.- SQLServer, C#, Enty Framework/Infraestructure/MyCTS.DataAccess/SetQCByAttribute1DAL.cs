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
using System.Collections.Specialized;

namespace MyCTS.DataAccess
{
    public class SetQCByAttribute1DAL
    {
        public SetQCByAttribute1 GetAttribute(string attribute1, string status, string statusSite, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SetQCByAttribute1Resources.SP_SetQCByAttribute1);
            db.AddInParameter(dbCommand, Resources.SetQCByAttribute1Resources.PARAM_ATTRIBUTE1, DbType.String, attribute1);
            db.AddInParameter(dbCommand, Resources.SetQCByAttribute1Resources.PARAM_STATUS, DbType.String, status);
            db.AddInParameter(dbCommand, Resources.SetQCByAttribute1Resources.PARAM_STATUS_SITE, DbType.String, statusSite);

            SetQCByAttribute1 Attribute = new SetQCByAttribute1();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _attribute1 = dr.GetOrdinal(Resources.SetQCByAttribute1Resources.FIELD_ATTRIBUTE1);

                if(dr.Read())
                {
                    SetQCByAttribute1 item = new SetQCByAttribute1();
                    item.Attribute1 = dr.GetString(_attribute1);
                    Attribute = item;

                }

            }

            return Attribute;
        }
    }
}
